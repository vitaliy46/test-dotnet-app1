using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Kis.Noris.Api.Attribute;
using Kis.Noris.Api.Constants;
using Kis.Noris.Api.Dao;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Exceptions;
using ReferenceException = Kis.Noris.Api.Exceptions.ReferenceException;

namespace Kis.Noris.Api.Services
{
    /// <summary>
    /// Провайдер обновлений справочников, получающий обновления 
    /// из sql скриптов, полученных из определённой папки, расположенной
    /// на диске.
    /// </summary>
    /// <typeparam name="T">Тип записей справочника, для которого предоставляются обновления</typeparam>
    public abstract class SqlScriptUpdateProvider<T> : IUpdateProvider<T>
        where T: ReferenceEntity
    {
        /// <summary>
        /// Имя конфигурационного параметра, где указано имя строки подключения,
        /// используемой для временного размещения обрабатываемых скриптов
        /// </summary>
        public readonly string TempDbConnectionStringSettingKey = 
            "SqlScriptUpdateProvider" + ".TempDbConnectionName";

        private readonly ISqlScriptFileStorage _scriptFileStorage;
        private readonly IUpdatePackageFileStorage _updatePackageFileStorage;
       

        /// <summary>
        /// Защищённый конструктор.
        /// </summary>
        /// <param name="scriptFileStorage">Объект файлового хранилища, который отвечает за 
        /// поиск и получение файлов sql-скриптов</param>
        /// <param name="updatePackageFileStorage">Объект файлового хранилища, который отвечает
        /// за хранение и получение файлов обновлений во внутреннем формате обновлений</param>
        /// <exception cref="ArgumentNullException"><paramref name="scriptFileStorage"/> or 
        /// <paramref name="updatePackageFileStorage"/> is <see langword="null" />.</exception>
        protected SqlScriptUpdateProvider(ISqlScriptFileStorage scriptFileStorage, 
            IUpdatePackageFileStorage updatePackageFileStorage)
        {
            if (scriptFileStorage == null)
                throw new ArgumentNullException(nameof(scriptFileStorage));
            if (updatePackageFileStorage == null)
                throw new ArgumentNullException(nameof(updatePackageFileStorage));

            _scriptFileStorage = scriptFileStorage;
            _updatePackageFileStorage = updatePackageFileStorage;
        }

        /// <summary>
        /// При переопределнии возвращает именованную часть имени файла скрипта, определяемую по
        /// маске: [имя скрипта]__[дата релиза].sql
        /// </summary>
        protected virtual string ScriptName
        {
            get
            {
                var attribute = typeof (T).GetCustomAttributes(typeof(ReferenceAttribute),false).FirstOrDefault() as ReferenceAttribute;

                return attribute?.CodeSystem??String.Empty;
            }
        }

        /// <summary>
        /// Возвращает список описаний доступных обновлений
        /// </summary>
        /// <returns>Набор описаний обновлений</returns>
        public IEnumerable<UpdateInfo> GetAvailableUpdates()
        {
            // просмотреть данные обновлений, доступные в папке скриптов sql и файлов преобразованных
            // пакетов обновлений и вернуть список имеющихся данных об обновлениях
            var updateInfosOfScripts = _scriptFileStorage.GetScripts(ScriptName)
                .Select(o => new UpdateInfo(typeof (T), o.ReleaseDate));

            var updateInfosOfPackages = _updatePackageFileStorage.GetUpdates<T>()
                .Select(o => new UpdateInfo(typeof (T), o.ReleaseDateTo));

            return updateInfosOfScripts.Union(updateInfosOfPackages).ToArray();
        }

        /// <summary>
        /// Возвращает пакет обновления по переданному описанию обновления
        /// </summary>
        /// <param name="updateInfo">Объект, описывающий конкретное обновление</param>
        /// <returns>Пакет с данными обновления</returns>
        public UpdatePackage<T> GetUpdate(UpdateInfo updateInfo)
        {
            if (updateInfo == null) throw new ArgumentNullException(nameof(updateInfo));

            if(updateInfo.ReferenceDataType != typeof(T))
                throw new ReferenceException("Specified reference data type not supported");

            // проверить наличие пакета обновления в хранилище соответственного обновлению
            var updatePackages = _updatePackageFileStorage.GetUpdates<T>();
            var updatePackageFile = updatePackages
                .FirstOrDefault(o => o.ReleaseDateTo == updateInfo.ReleaseDate);

            // если пакет есть, вытащить его из хранилища и вернуть
            if (updatePackageFile != null) return updatePackageFile;
            
            // если нет
            // обратиться к хранилищу sql скриптов за файлом обновления
            var updateScripts = _scriptFileStorage.GetScripts(ScriptName);
            var scriptFile = updateScripts
                .FirstOrDefault(o => o.ReleaseDate == updateInfo.ReleaseDate);

            // если его нет, выдать исключение
            if(scriptFile == null)
                throw new ReferenceException("Can not found update package for specitied update info");

            // открыть временную базу для скрипта
            using (var tempDbConnection = 
                Database.Open(ConfigurationManager.AppSettings[TempDbConnectionStringSettingKey]))
            {
                // открыть файл скрипта для чтения текста в заданной кодировке
                using (var reader = new StreamReader(scriptFile.File.OpenRead(), Encoding.GetEncoding("windows-1251")))
                {
                    // представить файл как перечисление отдельных строк комманд, разделённых точкой с запятой
                    var commands = SplitSqlFileToCommands(reader);
                    // пройти по каждой команде
                    foreach (var command in commands)
                    {
                        // удалить из текста комманды подстроку со схемой и
                        // добавить к командам CREATE TABLE и SEQUENCE параметр TEMP
                        var command2 = command.Replace("\"directories_dto\".", "")
                            .Replace("CREATE SEQUENCE", "CREATE TEMP SEQUENCE")
                            .Replace("CREATE TABLE", "CREATE TEMP TABLE");
                        try
                        {
                            // передать команду на выполнение в базу
                            tempDbConnection.Execute(command2);
                        }
                        catch (Exception ex)
                        {
                            throw new ReadScriptException("Загрузка скрипта с обновлениями справочника невозможна.", updateInfo, ex);
                        }
                    }
                }

                var previousRelease =
                updatePackages.Select(o => o.ReleaseDateTo).Union(updateScripts.Select(o => o.ReleaseDate))
                    .Where(o => o < scriptFile.ReleaseDate).OrderByDescending(o => o).Select(o=>new DateTime?(o)).FirstOrDefault();

                // создаём новый пакет updatePackage
                var updatePackage = new UpdatePackage<T>(previousRelease, scriptFile.ReleaseDate);

                // перебираем все записи из таблицы
                var scriptRecords = tempDbConnection.Query<dynamic>($"select * from \"{TableName}\"");

                // получаем одну запись из временой базы
                foreach (var scriptRecord in scriptRecords)
                {
                    // маппим её на сущность ReferenceData
                    var referenceData = MapScriptToReferenceData(scriptRecord);

                    // добавляем сущность в пакет updatePackage с операцией "auto", т.к. данных об выполненной операции нет
                    updatePackage.Records.Add(new UpdatePackageItem<T>(referenceData, UpdateOperation.Auto));
                }

                // сохраняем пакет обновления в хранилище
                // todo

                // возвращаем пакет обновления
                return updatePackage;
            }
        }

        // считывает sql-скрипт из ридера по одной команде и возвращает 
        // список комманд
        private static IEnumerable<string> SplitSqlFileToCommands(TextReader reader)
        {
            char? inQuotesChar = null;
            var builder = new StringBuilder();
            // пока в файле есть ещё символы
            while (reader.Peek() >= 0)
            {
                var chr = (char)reader.Read();

                if (!inQuotesChar.HasValue && (chr == '\'' || chr == '"'))
                    inQuotesChar = chr;
                else if (inQuotesChar.HasValue && (inQuotesChar.Value == chr))
                    inQuotesChar = null;

                builder.Append(chr);

                if (chr != ';' || inQuotesChar.HasValue) continue;

                yield return builder.ToString();
                builder.Clear();
            }
        }

        /// <summary>
        /// Выполняет маппинг полученного из временной даты записи на 
        /// запись справочника. В наследниках следует реализовывать только 
        /// маппинг обычных свойств и полей, но не ссылочных.
        /// </summary>
        /// <param name="scriptRecord">Запись, полученная из временной базы. Имена полей объекта совпадают с именами 
        /// столбцов в скрипте</param>
        /// <returns></returns>
        protected abstract T MapScriptToReferenceData(dynamic scriptRecord);

        /// <summary>
        /// При переопаределении возвращает имя таблицы во временной базе, указанное в 
        /// файле скрипта. Имя таблицы указывается без схемы!!!
        /// </summary>
        public abstract string TableName { get; }
    }

    public interface ISqlScriptFileStorage
    {
        /// <summary>
        /// Возвращает список объектов скриптов, имеющихся в папке скриптов и подходящих 
        /// под переданное имя
        /// </summary>
        /// <param name="namePattern">Имя скрипта, содержащееся в имени файла (часть без расширения и даты релиза)</param>
        /// <returns>Набор объектов скриптов</returns>
        IEnumerable<ScriptFile> GetScripts(string namePattern);
    }

    /// <summary>
    /// Объект, обслуживающий папку с sql-скриптами обновлений
    /// </summary>
    public class SqlScriptFileStorage : ISqlScriptFileStorage
    {
        private readonly DirectoryInfo _scriptDirectory;

        public SqlScriptFileStorage(DirectoryInfo scriptDirectory)
        {
            if (scriptDirectory == null)
                throw new ArgumentNullException(nameof(scriptDirectory));
            _scriptDirectory = scriptDirectory;
        }

        /// <summary>
        /// Маска имени файла для поиска подходящих скриптов
        /// </summary>
        //public const string PatternTemplate = @"{0}__\[(\d{{1,2}}\.\d{{1,2}}\.\d{{4}})\]\.sql";
        public const string PatternTemplate = @"{0}__\[(\d{{1,2}}\.\d{{1,2}}\.\d{{4}}(\s\d{{1,2}}\.\d{{1,2}}\.\d{{1,2}})?)\].sql";

        /// <summary>
        /// Возвращает список объектов скриптов, имеющихся в папке скриптов и подходящих 
        /// под переданное имя
        /// </summary>
        /// <param name="namePattern">Имя скрипта, содержащееся в имени файла (часть без расширения и даты релиза)</param>
        /// <returns>Набор объектов скриптов</returns>
        public IEnumerable<ScriptFile> GetScripts(string namePattern)
        {
            var sqlFiles = _scriptDirectory.GetFiles("*.sql");
            var regex = string.Format(PatternTemplate, namePattern);
            var enumerable = sqlFiles.Where(o => Regex.IsMatch(o.Name, regex, RegexOptions.IgnoreCase))
                .Select(o =>
                {
                    var scriptFile = new ScriptFile();
                    scriptFile.File = o;
                    DateTime datetime;
                    var match = Regex.Match(o.Name, regex, RegexOptions.IgnoreCase);
                    var parseResult = DateTime.TryParseExact(match.Groups[1].Value, new string[] { "dd.MM.yyyy HH.mm.ss", "dd.MM.yyyy" }, 
                        null, System.Globalization.DateTimeStyles.None, out datetime);
                    scriptFile.ReleaseDate = datetime;
                    return new {scriptFile, parseResult};
                });
            var scripts = enumerable.Where(o => o.parseResult).Select(o => o.scriptFile);
            return scripts;
        }
    }

    // todo Тут ещё ничего толком не реализовано. Отложено до лучших времён.
    public interface IUpdatePackageFileStorage
    {
        IEnumerable<UpdatePackageFile<T>> GetUpdates<T>()
            where T : ReferenceEntity;
    }

    public class UpdatePackageFileStorage : IUpdatePackageFileStorage
    {
        public IEnumerable<UpdatePackageFile<T>> GetUpdates<T>()
            where T : ReferenceEntity
        {
            return Enumerable.Empty<UpdatePackageFile<T>>();
        }
    }

    public class UpdatePackageFile<T> : UpdatePackage<T>
        where T : ReferenceEntity
    {
        private FileInfo _file;
        private bool _fileLoaded;

        public UpdatePackageFile(DateTime? releaseDateFrom, DateTime releaseDateTo, FileInfo packageFile) : base(releaseDateFrom, releaseDateTo)
        {
            _file = packageFile;
        }

        public override IList<UpdatePackageItem<T>> Records
        {
            get
            {
                EnsureFileLoaded();
                return base.Records;
            }
        }

        private void EnsureFileLoaded()
        {
            if(_fileLoaded) return;

            // проверить наличие файла архива с обновлением и открыть его
            using (var zipstream = new ZipInputStream(_file.OpenRead()))
            {
                // найти в нём xml файл с обновлением и открыть
                //zipstream.GetNextEntry().
            }
        }
    }

    /// <summary>
    /// Объект, описывающий файл скрипта. Содержит сам файл и дату его релиза.
    /// </summary>
    public class ScriptFile
    {
        public FileInfo File { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
