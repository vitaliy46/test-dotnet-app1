using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Kis.Noris.Api.Attribute;
using Kis.Noris.Api.Constants;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Entity.Rosminzdrav;
using Kis.Noris.Api.Exceptions;
using Kis.Noris.Api.Exceptions.RosminzdravExceptions;
using Kis.Noris.Api.Extensions;
using Kis.Noris.Api.Service_References.Rosminzdrav.Nsi;

namespace Kis.Noris.Api.Services
{
    /// <summary>
    /// Провайдер обновления справочников, получающий обновления через сервис Росминздрава
    /// </summary>
    /// <typeparam name="T">Тип записей справочника, для которого предоставляются обновления</typeparam>
    public abstract class RosminzdravUpdateProvider<T> : IUpdateProvider<T> where T : ReferenceEntity
    {
        readonly serviceClient _client;
        readonly string _userKey;
        IList<RosminzdravUpdateInfo> _updates;

        public IReferenceBook<T> ReferenceBook { get; set; }

        public IReferenceErrorManager ReferenceErrorManager { get; set; }

        protected RosminzdravUpdateProvider()
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains("rosminzdravUserKey"))
                throw new Exception("User key for Rosminzdrav NSI not found in config");

            _userKey = ConfigurationManager.AppSettings["rosminzdravUserKey"];

            _client = new serviceClient();
        }

        /// <summary>
        /// Возвращает список описаний доступных обновлений
        /// </summary>
        /// <returns>Набор описаний обновлений</returns>
        public virtual IEnumerable<UpdateInfo> GetAvailableUpdates()
        {
            _updates = new List<RosminzdravUpdateInfo>();

            // Поиск кода справочника через атрибут ReferenceAttribute
            var code = GetReferenceBookOid();

            try
            {
                // Получение списка версий справочника
                var getVersionListAnswer = _client.getVersionList(_userKey, code).Check();

                RosminzdravVersionsList versionsList = new RosminzdravVersionsList(getVersionListAnswer);

                // Необходимо каждой версии поставить в соответствие уникальную дату
                // Т.к. есть версии, датированные одной датой, необходимо к каждой более поздней версии
                // добавлять по одной секунде

                // Получение массива дат, соответствующих всем росминздравовским версиям
                DateTime[] versionsDatetimes = versionsList.Select(x => x.VersionDate).Distinct().ToArray();

                // В цикле берем каждую уникальную дату, перебираем версии, соответствующие ей и 
                // добавляем в список обновлений
                foreach (DateTime dateTime in versionsDatetimes)
                {
                    int second = 0;
                    foreach (RosminzdravVersion version in versionsList.Where(x => x.VersionDate == dateTime))
                    {
                        if (!version.IsCorrect()) continue;

                        // К каждой новой версии, соответствующей одной дате, добавляем секунду
                        DateTime dateTimeToUpdateInfo = dateTime.AddSeconds(second++);

                        _updates.Add(new RosminzdravUpdateInfo(typeof(T), dateTimeToUpdateInfo,
                            version.VersionNumber, code));
                    }
                }
                return _updates;
            }
            catch (RosminzdravServiceException)
            {
                throw;
            }
        }

        /// <summary>
        /// Возвращает пакет обновления по переданному описанию обновления
        /// </summary>
        /// <param name="updateInfo">Объект, описывающий конкретное обновление</param>
        /// <returns>Пакет с данными обновления</returns>
        public virtual UpdatePackage<T> GetUpdate(UpdateInfo updateInfo)
        {
            if (updateInfo == null)
                throw new ArgumentNullException(nameof(updateInfo));

            if (updateInfo.ReferenceDataType != typeof(T))
                throw new Exception("Specified type is not supported");

            // Поиск переданного объекта в списке доступных обновлений. Если объект не найден, список формируется
            // еще раз
            if (!_updates.Contains(updateInfo)) _updates = (List<RosminzdravUpdateInfo>)GetAvailableUpdates();
            if (!_updates.Contains(updateInfo)) throw new Exception("updInfo");

            // Получение актуальной версии справочника
            DateTime? actualReleaseDate = ReferenceBook.GetActualRelease()?.ReleaseDate;

            RosminzdravUpdateInfo rosminUpdateInfo = updateInfo as RosminzdravUpdateInfo;

            // Поиск индекса объекта текущего обновления в списке обновлений. Если индекс больше 0, то
            // ищем обновление, предществующего текущего - его дата будет датой, с которой происходит 
            // обновление. Если индекс = 0, значит предыдущих версий справочника не было
            var index = _updates.IndexOf(rosminUpdateInfo);

            string refBookOid = GetReferenceBookOid();

            var updatePackage = new UpdatePackage<T>(actualReleaseDate, updateInfo.ReleaseDate);

            ArrayOfMap partsOfReferenceBook;
            if (index == 0) // Если предыдущих версий справочника нет, скачиваем все записи
            {
                // Т.к. некоторые справочники большие и передаются по частям, всегда запрашиваем кол-во частей
                // и в цикле запрашиваем записи по определенной части
                var items = ReceiveRecordsFromGetRefbook(rosminUpdateInfo.Version);
                foreach (var item in items)
                    updatePackage.Records.Add(item);

            }
            else // Если предыдущие версии справочника есть, скачиваем новые записи
            {
                string oldVersion = _updates[index - 1].Version;
                string newVersion = rosminUpdateInfo.Version;

                try
                {
                    // Запрашивается список изменений между версиями
                    partsOfReferenceBook = _client.getRefbookUpdate(_userKey, refBookOid, oldVersion, newVersion).Check();

                    RosminzdravRecordsList recordsUpdatesList = new RosminzdravRecordsList(partsOfReferenceBook);

                    foreach (var record in recordsUpdatesList)
                    {
                        var operation = record["OPER"];
                        UpdateOperation oper;
                        switch (operation)
                        {
                            case "i": oper = UpdateOperation.Addition; break;
                            case "u": oper = UpdateOperation.Modification; break;
                            case "d": oper = UpdateOperation.Removal; break;
                            default: oper = UpdateOperation.NoChange; break;
                        }

                        bool isDeleted = oper == UpdateOperation.Removal ? true : false;
                        updatePackage.Records.Add(new UpdatePackageItem<T>(mapPartToReferenceData(record, isDeleted), UpdateOperation.Auto));
                    }
                }
                catch (RosminzdravServiceException ex) when (ex.Code == "03x0002")
                {
                    // Ошибка 03x0002 - версия справочника не содержит изменений

                    throw new NoUpdateException(rosminUpdateInfo, "No update");
                }
                catch (RosminzdravServiceException ex) when (ex.Code == "03x0007")
                {
                    // Ошибка 03x0007 - структуры версий справочников не эквивалентны

                    // Формируется идентификатор ошибки, состоящий из имени класса-сущности, 
                    // кодовой фразы, характеризующей ошибку и номера версий, при обновлении на которую возникла ошибка
                    string errorIdentifier = typeof(T).Name + ":ChangedStructure:" + newVersion;
                    
                    // Поиск ошибки с таким идентификатором в БД. Если ошибка не найдена, генерируется exception
                    var findedError = ReferenceErrorManager.FindError(errorIdentifier, ReferenceErrors.ChangedStructure);
                    if (findedError == null)
                        throw new RosminzdravUpdateException(oldVersion, newVersion, errorIdentifier);

                    // Если ошибка найдена, проверяется ее статус. Если статус не "Закрыта", генерируется exception
                    if (findedError.State == ReferenceErrorStates.Closed)
                    {
                        try
                        {
                            // Если ошибка закрыта, то скачивается весь справочник новой версии
                            var items = ReceiveRecordsFromGetRefbook(newVersion);
                            foreach (var item in items)
                                updatePackage.Records.Add(item);

                            // Т.к. новая версия справочника закачивается полностью, у нас нет данных об
                            // удалении записей старой версии. Поэтому требуется взять все актуальные записи 
                            // старой версии, сравнить с записями в новой версии и добавить удаление тех записей,
                            // которых нет в новой версии справочника

                            // Получаем коды записей, актуальных на момент предыдущего обновления
                            var recordsForPreviousDate = ReferenceBook.Get(_updates[index - 1].ReleaseDate).Where(x => x.IsActual == true);
                            string[] codesForPreviousDate = recordsForPreviousDate.Select(x => x.Code).ToArray();

                            // Коды записей, полученные в новой версии
                            string[] updatedCodes = updatePackage.Records.Select(x => x.Record).Select(x => x.Code).ToArray();

                            // Получаем разность множеств
                            var exceptCodes = codesForPreviousDate.Except(updatedCodes);

                            // Если есть такие записи, формируем запись на удаление
                            foreach (string exceptCode in exceptCodes)
                            {
                                T recordToDelete = recordsForPreviousDate.FirstOrDefault(x => x.Code == exceptCode);
                                updatePackage.Records.Add(new UpdatePackageItem<T>(recordToDelete, UpdateOperation.Removal));
                            }
                        }
                        catch (NamedKeyNotFoundException)
                        {
                            // Возникнет, если, несмотря на статус "Закрыта", преобразование записей Росминздрава
                            // в нашу сущность, не получится
                            throw new RosminzdravUpdateException(oldVersion, newVersion, errorIdentifier, findedError);
                        }
                    }
                    else
                        throw new ErrorStateException(errorIdentifier, findedError.State, "Ошибка должна быть закрыта");
                    
                }
            }
            return updatePackage;
        }

        protected abstract T mapPartToReferenceData(RosminzdravRecord record, bool isDeleted);

        /// <summary>
        /// Метод запрашивает записи справочника указанной версии и пытается преобразовать в 
        /// объект записи справочника
        /// </summary>
        /// <param name="version"></param>
        public void Check(string version)
        {
            // Некоторые спраовочники могут быть большими и возвращать ошибку, поэтому запрашивается только 1-я часть
            var records = _client.getRefbookPartial(_userKey, GetReferenceBookOid(), version, "1").Check();
            RosminzdravRecordsList recordsList = new RosminzdravRecordsList(records);

            // Достаточно попытаться преобразовать только первый элемент списка. Он точно будет не пустой, т.к.
            // в случае пустого справочника возвращается ошибка
            T reference = mapPartToReferenceData(recordsList[0], false);
        }

        /// <summary>
        /// Возвращает OID справочника, содержащийся в свойстве CodeSystem атрибута Reference
        /// </summary>
        /// <returns></returns>
        private string GetReferenceBookOid()
        {
            var attr = typeof(T).GetCustomAttributes(typeof(ReferenceAttribute), false);
            if (attr == null || attr.Length != 1) throw new Exception("Code is not defined");

            return ((ReferenceAttribute)attr[0]).CodeSystem;
        }

        /// <summary>
        /// Метод возвращает версию справочника Росминздрава за указанную дату (если версий несколько,
        /// возвращается последняя)
        /// </summary>
        /// <param name="updateDate">Дата, за которую требуется версия</param>
        private string GetVersionByDate(DateTime updateDate)
        {
            var mapVersions = _client.getVersionList(_userKey, GetReferenceBookOid());

            RosminzdravVersionsList versionsList = new RosminzdravVersionsList(mapVersions);

            string lastVersion = versionsList.Where(x => x.VersionDate == updateDate)
                .Last().VersionNumber;

            return lastVersion;
        }

        private List<UpdatePackageItem<T>> ReceiveRecordsFromGetRefbook(string version)
        {
            string refBookOid = GetReferenceBookOid();

            List<UpdatePackageItem<T>> packageItems = new List<UpdatePackageItem<T>>();

            var partsMap = _client.getRefbookParts(_userKey, refBookOid, version);
            RosminzdravPartsInfo partsInfo = new RosminzdravPartsInfo(partsMap);

            for (int i = 1; i <= partsInfo.CountParts; i++)
            {
                var recordsMap = _client.getRefbookPartial(_userKey, refBookOid, version, i.ToString());

                RosminzdravRecordsList recordsList = new RosminzdravRecordsList(recordsMap);
                foreach (RosminzdravRecord record in recordsList)
                    packageItems.Add(new UpdatePackageItem<T>(mapPartToReferenceData(record, false), UpdateOperation.Auto));
            }

            return packageItems;
        }
    }
}
