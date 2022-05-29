using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Kis.Noris.Api.Constants;
using Kis.Noris.Api.Criterias;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;
using Kis.Noris.Api.Exceptions;
using Kis.Noris.Api.Extensions;
using ReferenceException = Kis.Noris.Api.Exceptions.ReferenceException;

namespace Kis.Noris.Api.Services
{
    /// <summary>
    /// Базовая реализация объекта справочника, реализующая основные 
    /// функции работы со справочниками, и предназначенная для наследования
    /// классами конкретных справочников со своей расширенной структурой записей.
    /// </summary>
    /// <typeparam name="TReferenceEntity">Тип записи справочника</typeparam>
    /// <typeparam name="TDataContext">Тип контекста данных</typeparam>
    public abstract class ReferenceBookBase<TReferenceEntity, TDataContext> : IReferenceBook<TReferenceEntity>
        where TReferenceEntity : ReferenceEntity
        where TDataContext : class, IDataContext
    {
        private PropertyInfo[] _significantProperties;
        /// <summary>
        /// Значимые свойства записи справочника. По этим свойствам определяется, 
        /// изменилась ли запись в пакете обновления относительно её текущей версии в справочнике.
        /// Используется только для записей, для которых операцию обновления необходимо 
        /// определить самостоятельно автоматически.
        /// </summary>
        private PropertyInfo[] SignificantProperties
        {
            get
            {
                if (_significantProperties != null) return _significantProperties;

                var propertyInfos = _relationDefinitionInfos
                    .SelectMany(o1 => new[] { o1.RelationProperty, o1.RelationIdProperty });
                _significantProperties = typeof(TReferenceEntity).GetProperties()
                    .Where(o => o.DeclaringType != typeof(ReferenceEntity) ||
                                (o.DeclaringType == typeof(ReferenceEntity) &&
                                 o.Name == nameof(ReferenceEntity.IsDeleted)))
                    .Where(o => !propertyInfos.Contains(o))
                    .Where(o => o.CanWrite && o.CanRead)
                    .ToArray();
                return _significantProperties;

            }
        }

        /// <summary>
        /// Провайдер идентификаторов, для назначения их новым записям справочника
        /// </summary>
        public IIdentifierProvider<Guid> IdentifierProvider { get; set; }
        public IReferenceErrorQualifier ReferenceErrorQualifier { get; set; }

        /// <summary>
        /// Провайдер для получения соответствий типов dto свойств локальным справочникам
        /// и соответствий локальных справочников мастер-справочникам
        /// </summary>
        public IReferenceBookFactory ReferenceBookFactory { get; set; }

        public ILoggingService Logger { get; set; }

        public IDataContextScopeFactory DataContextScopeFactory { get; set; }

        /// <summary>
        /// Флаг, указывающий, что при выполнении запроса в результат должны включаться
        /// записи, помеченные как удалённые. По умолчанию они не возвращаются.
        /// </summary>
        // TODO потенциальная ошибка. Флаг может быть установлен из одного запроса и затем иметь силу для последующих запросов
        // Его нужно либо сбрасывать, либо перенести в другой контекст.
        protected bool WithDeleted;

        /// <summary>
        /// Список объектов, описывающих связи между записями текущего справочника
        /// и записями других справочников. Используется в процессе обновления справочника
        /// для актуализации идентификаторов 
        /// </summary>
        private readonly IList<RelationDefinitionInfo> _relationDefinitionInfos = new List<RelationDefinitionInfo>();

        /// <summary>
        /// Метод-запрос набора записей из текущего справочника
        /// </summary>
        /// <param name="criteria">Типизированный критерий выборки записей</param>
        /// <returns>Набор записей, удовлетворяющий критерию выборки, либо пустой набор</returns>
        /// <exception cref="ArgumentNullException">criteria is <see langword="null" />.</exception>
        /// <exception cref="NotSupportedCriteriaException">Критерий данного типа не поддерживается</exception>
        public ReferenceEntity QueryRecord(ICriteria criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            if (!(criteria is ICriteria<TReferenceEntity>))
                throw new NotSupportedCriteriaException(criteria);

            return QueryRecord((ICriteria<TReferenceEntity>)criteria);
        }
        ReferenceEntity IReferenceBook.Get(Guid versionId)
        {
            return Get(versionId);
        }


        public TReferenceEntity Get(Guid versionId)
        {
            using (var scope = DataContextScopeFactory.CreateReadOnly())
            {
                return scope.DataContexts.Get<TDataContext>().Set<TReferenceEntity>().Get(versionId);
            }
        }

        /// <summary>
        /// Метод-запрос единичной записи из текущего справочника. 
        /// </summary>
        /// <param name="criteria">Типизированный критерий выборки записей</param>
        /// <returns>Набор записей, удовлетворяющий критерию выборки, либо пустой набор</returns>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public virtual TReferenceEntity QueryRecord(ICriteria<TReferenceEntity> criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            using (var scope = DataContextScopeFactory.CreateReadOnly())
            {
                return scope.DataContexts.Get<TDataContext>().Set<TReferenceEntity>().Filter(criteria).SelectFirst();
            }

            /*var connection = GetConnection();
            try
            {
                var query = connection.GetSet<TRefData>().AsQueryable();
                query = (DisposeContextAfterQuery ? query.AsNoTracking() : query);
                query = _ApplyCriteria(query, criteria);
                return ExcludeDeleted(query).FirstOrDefault();
            }
            finally
            {
                if (DisposeContextAfterQuery) connection.Dispose();
            }*/
        }

        /// <summary>
        /// Метод-запрос набора записей из текущего справочника
        /// </summary>
        /// <param name="criteria">Критерий выборки записей</param>
        /// <exception cref="NotSupportedCriteriaException">Критерий данного типа не поддерживается</exception>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public IReadOnlyList<ReferenceEntity> QueryRecords(ICriteria criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            if (!(criteria is ICriteria<TReferenceEntity>))
                throw new NotSupportedCriteriaException(criteria);

            return QueryRecords((ICriteria<TReferenceEntity>)criteria);
        }



        /// <summary>
        /// Метод-запрос набора записей из текущего справочника
        /// </summary>
        /// <param name="criteria">Критерий выборки записей</param>
        /// <returns>Набор записей, удовлетворяющий критерию выборки, либо пустой набор</returns>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        public virtual IReadOnlyList<TReferenceEntity> QueryRecords(ICriteria<TReferenceEntity> criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            using (var scope = DataContextScopeFactory.CreateReadOnly())
            {
                return scope.DataContexts.Get<TDataContext>().Set<TReferenceEntity>().Filter(criteria).SelectAll();
            }

            /*var connection = GetConnection();
            try
            {
                var query = connection.GetSet<TRefData>().AsQueryable();
                query = (DisposeContextAfterQuery ? query.AsNoTracking() : query);

                query = _ApplyCriteria(query, criteria);
                return ExcludeDeleted(query).ToArray();
            }
            finally
            {
                if (DisposeContextAfterQuery) connection.Dispose();
            }*/
        }

        /// <summary>
        /// Возвращает набор всех дат релизов текущего справочника
        /// </summary>
        /// <returns>Набор дат релизов</returns>
        public IReadOnlyList<ReferenceRelease> GetReleases()
        {
            using (var scope = DataContextScopeFactory.CreateReadOnly())
            {
                return scope.DataContexts.Get<TDataContext>().Set<ReferenceRelease<TReferenceEntity>>().SelectAll();
            }

            /*var connection = GetConnection();
                try
                {
                    _releaseCache =
                        connection.GetSet<TReferenceEntity>().Select(o => o.ReleaseDateBegin)
                            .Distinct().OrderByDescending(o => o).ToArray();
                }
                finally
                {
                    if(DisposeContextAfterQuery) connection.Dispose();
                }
                return _releaseCache;
                */
        }

        /// <summary>
        /// Возвращает самую последнюю дату релиза, имеющуюся в справочнике
        /// </summary>
        /// <returns>Последняя дата релиза, либо null если справочник пуст</returns>
        public ReferenceRelease GetActualRelease()
        {
            using (var scope = DataContextScopeFactory.CreateReadOnly())
            {
                return scope.DataContexts.Get<TDataContext>().Set<ReferenceRelease<TReferenceEntity>>()
                    .OrderDesc(o => o.ReleaseDate).SelectFirst();
            }
        }

        /// <summary>
        /// Этот метод вызывается всегда на мастер справочнике. 
        /// 1. По свойству dto ищется связанный справочник используя фабрику и маппинг
        /// 2. Если найденный по маппингу справочник окажется локальным, то у него должен
        /// быть код перекодировки на текущий мастер справочник
        /// 3. Находится запись в связанном справочнике по критериям поиска 
        /// (главным образом по коду или комбинации кодов)
        /// 4. Если сущность связанного справочника не относится к числу мастер справочников, 
        /// то производится перекодировка на сущность текущего мастер-справочника.
        /// </summary>
        /// <param name="dto">тип справочного свойства в dto сущности</param>
        public TReferenceEntity Transcode(BaseReferenceDto dto)
        {
            if (dto == null)
            {
                Logger.Debug<BaseReferenceDto>(
                    $"Нет данных для перекодировки справочника {typeof(TReferenceEntity).Name}");

#if DEBUG
                Mconsole.WriteLine(new Mstring(
                    $"Нет данных для перекодировки справочника {typeof(TReferenceEntity).Name}", ConsoleColor.DarkRed));
#endif
                return null;
            }

            // 1. Запрос к фабрике на получение ссылки на справочник связанный по типу dto записи
            var referenceBook = ReferenceBookFactory.GetReferenceBook(dto.GetType(), "Указать тип информационной системы");

            if (referenceBook == null)
            {
                var errorMsg =
                    $"В таблице маппингов не зарегистрирован справочник, соответствующий типу dto свойства {dto.GetType().Name}";
                Logger.Error<BaseReferenceDto>(errorMsg);

                throw new Exception(errorMsg);
            }

            //2. получение записи из связанного справочника по коду или составному коду в dto свойстве
            //В том случае если поиск осуществляется не по одному полю Code а по составным полям
            //то формируется комбинированный код из нескольких полей 
            var codes = new[] { dto.Code }.Concat(dto.ExtraCodes.EmptyIfNull()).ToArray();
            var referenceRecord = referenceBook.QueryRecord(_searchByCode(codes));

            if (referenceRecord == null)
                throw new CodeMissingException(referenceBook, codes);

            //Нужно понять, связанный с типом dpo свойства справочник, является мастер справочником или одним из справочников,
            //которые имеют коды перекодировки на мастер справочник
            bool isMasterReference = !(referenceRecord is ITransCode);

            if (isMasterReference)
            {
                //справочник относится к числу мастер-справочников
                return (TReferenceEntity)referenceRecord;
            }

            // 3. Так как справочник из маппинга оказался не мастер справочник, то по коду перекодировки из локального
            // справочника   находится запись мастер справочника
            ReferenceEntity resultRecord = null;
            if (((ITransCode)referenceRecord).TransCode == string.Empty)
            {
                //Фиксируем ошибку отсутствия кода перекодировки для отдела НСИ
                throw new TranscodeMissingException(referenceBook, this, referenceRecord.Codes);
            }

            resultRecord =
                QueryRecord(referenceBook.SearchMasterRecordByTranscode(((ITransCode)referenceRecord).TransCode));

            if (resultRecord == null)
                throw new CodeMissingException(this, codes);

            return (TReferenceEntity)resultRecord;
        }

        ReferenceEntity IReferenceBook.Transcode(BaseReferenceDto dto)
        {
            return Transcode(dto);
        }
        public class SampleReference : ReferenceEntity
        {
            public string Prop { get; set; }
        }

        protected virtual ICriteria _searchByCode(IEnumerable<string> codes)
        {
            return Criteria.For<ReferenceEntity>().ByCode(codes.ToArray()).InActual();
        }

        public virtual ICriteria SearchMasterRecordByTranscode(string code)
        {
            return Criteria.For<ReferenceEntity>().ByCode(new[] { code }).InActual();
        }

        /// <summary>
        /// Формирование критерия поиска записи в справочнике по её коду
        /// </summary>
        /// <param name="codes">Массив строк, содержащих коды записи</param>
        /// <returns></returns>
        public virtual ICriteria SearchByCode(string[] codes)
        {
            return _searchByCode(codes);
        }

        /// <summary>
        /// Возвращает тип сущности которой оперирует справочник.
        /// Создан для подсистемы сбора ошибок ввозникающих при работе со справочниками
        /// </summary>
        public Type GetReferenceEntityType()
        {
            return typeof(TReferenceEntity);
        }

        // Исключает из запроса все удалённые записи
        private IQueryable<TReferenceEntity> ExcludeDeleted(IQueryable<TReferenceEntity> query)
        {
            return !WithDeleted ? query.Where(o => !o.IsDeleted) : query;
        }



        // Вызывается при выполнении запроса для обработки объекта критерия и применения его 
        // к запросу данных. Он также разворачивает объект набора критериев, для 
        // обработки его содержимого по отдельности.
        /*private IQueryable<TReferenceEntity> _ApplyCriteria(IQueryable<TReferenceEntity> query, ICriteria<TReferenceEntity> criteria)
        {
            if (criteria == null || criteria is NullCriteria<TReferenceEntity>) return query;

            var criteriaSet = criteria as CriteriaSet<TReferenceEntity>;

            query = criteriaSet != null
                ? criteriaSet.Aggregate(query, _ApplyCriteria)
                : ApplyCriteria(query, criteria);

            return query;
        }*/

        /// <summary>
        /// Метод, выполняющий обработку одного критерия и модифицирующий результирующий запрос.
        /// Он выполняется в QueryRecords или QueryRecord перед тем, как запрос будет передан в базу данных.
        /// Вызывается по одному разу для каждого объекта критерия, содержащегося в составном критерии.
        /// Базовая реализация определяет обработку основных критериев.
        /// Может быть переопределён в наследниках, для обеспечения поддержки 
        /// дополнительных критериев выборки, специфичных для конкретных справочников.
        /// </summary>
        /// <param name="query">Объект запроса, на который влияет критерий</param>
        /// <param name="criteria">Объект критерия запроса. Сюда не попадает объект составного критерия, а только составляющие его подкритерии</param>
        /// <returns>Объект запроса, получившийся в результате применения критерия к исходному запросу.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="criteria"/> is <see langword="null" />.</exception>
        /// <exception cref="NotSupportedCriteriaException">Критерий данного типа не поддерживается</exception>
        /// <exception cref="CriteriaException">Ошибка в применении критерия запроса, проблемный критерий указан в свойстве <see cref="CriteriaException.Criteria"/></exception>
        /// <remarks>При переопределении в наследнике следует вызывать базовую реализацию метода, если вы хотите обеспечить
        /// поддержки базовых критериев. Либо не вызывать, если вы хотите переопределить поведение базовых критериев. Также следует бросать исключение 
        /// <see cref="NotSupportedCriteriaException"/>, либо вызывать базовый метод, если был передан критерий, не предусмотренный обработкой вашего переопределения.</remarks>
        protected virtual IQueryable<TReferenceEntity> ApplyCriteria(IQueryable<TReferenceEntity> query, ICriteria<TReferenceEntity> criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));

            var byVersionId = criteria as ByVersionIdCriteria;
            if (byVersionId != null)
                return query.Where(o => o.VersionId == byVersionId.VersionId);

            var byRecordId = criteria as ByRecordIdCriteria;
            if (byRecordId != null)
                return query.Where(o => o.RecordId == byRecordId.RecordId);

            var byCode = criteria as ByCodeCriteria;
            if (byCode != null)
                return query.Where(o => o.Code == byCode.Code);

            if (criteria is InActualCriteria)
                return query.Where(o => o.ReleaseDateEnd == ReferenceBookConstants.ActualReleaseEndDate);

            var inRelease = criteria as InReleaseCriteria;
            if (inRelease != null)
            {
                if (!GetReleases().Select(o => o.ReleaseDate).Contains(inRelease.ReleaseDate))
                    throw new CriteriaException("Specified release date not found in reference book", inRelease);

                return query.Where(o => o.ReleaseDateBegin <= inRelease.ReleaseDate &&
                                        o.ReleaseDateEnd >= inRelease.ReleaseDate);
            }

            var codesCriteria = criteria as ByCodesCriteria;
            if (codesCriteria != null)
            {
                return query.Where(o => codesCriteria.Codes.Contains(o.Code));
            }

            var idsCriteria = criteria as ByRecordIdsCriteria;
            if (idsCriteria != null)
            {
                return query.Where(o => idsCriteria.RecordIds.Contains(o.RecordId));
            }

            var versionIdsCriteria = criteria as ByVersionIdsCriteria;
            if (versionIdsCriteria != null)
            {
                return query.Where(o => versionIdsCriteria.VersionIds.Contains(o.VersionId));
            }

            if (criteria is WithDeletedCriteria)
            {
                WithDeleted = true;
                return query;
            }

            throw new NotSupportedCriteriaException(criteria);
        }

        // todo добавить в класс два виртуальных метода, для предобработки запроса и для постобработки,
        // чтобы можно было вносить изменения в запрос перед его выполнением

        /// <summary>
        /// Выполняет обновление записей справочника согласно содержимому пакета обновления
        /// Добавляет новые версии для записей, на которые влияет обновление
        /// Этот метод может выполнить обновление только с текущей актуальной версии справочника 
        /// на любую более новую.
        /// </summary>
        /// <param name="package">Пакет обновления, который требуется применить к справочнику</param>
        /// <exception cref="ReferenceException">Проблема при выполнении обновления справочника. Подробности в
        /// описании и внутреннем исключении</exception>
        /// <exception cref="ArgumentNullException"><paramref name="package"/> is <see langword="null" />.</exception>
        public void Update(UpdatePackage<TReferenceEntity> package)
        {
            if (package == null) throw new ArgumentNullException(nameof(package));

            // проверить, что версия справочника обновляется с текущей актуальной
            var actualRelease = GetActualRelease();
            if (actualRelease?.ReleaseDate != package.ReleaseDateFrom)
                throw new ReferenceException(
                    "Update package is not compatible with current reference book, because it can be " +
                    $"update only from current actual version \"{actualRelease?.ReleaseDate.ToString("yyyy.MM.dd") ?? "null"}\" to another new");

            // проверить, что версия, на которую обновляемся новее текущей
            if (package.ReleaseDateTo <= (package.ReleaseDateFrom ?? DateTime.MinValue))
                throw new ReferenceException("Update package ToReleaseDate can't be less or equals to FromReleaseDate");

            using (var scope = DataContextScopeFactory.Create())
            {
                var context = scope.DataContexts.Get<TDataContext>();
                var repo = context.Set<TReferenceEntity>();
                var repositories = _relationDefinitionInfos.Select(o => o.RelationProperty.PropertyType)
                    .Distinct()
                    .Select(o => new { type = o, repo = GetRepoOrDefault(context, o) })
                    .ToDictionary(o => o.type, o => o.repo);

                // разбить все записи обновления на части
                foreach (var packageChunk in package.Records.ToChunks(100))
                {
                    // получить из актуального справочника все записи с теми же кодами, что и у данных обновления, сохранить в кеш
                    var updatedCodes = packageChunk.Select(o => o.Record.Code).ToArray();
                    var existedRecords = repo.Filter(Criteria.For<ReferenceEntity>().InActual().ByCodes(updatedCodes)).SelectAll();

                    // взять одну запись обновления
                    foreach (var packageItem in packageChunk)
                    {
                        // найти в кеше запись с тем же кодом
                        var previousVersion =
                            existedRecords.FirstOrDefault(o => o.Code == packageItem.Record.Code);
                        try
                        {
                            // применить к записи справочника операцию, указанную в обновлении
                            ApplyOperationToRecord(packageItem, package, previousVersion, repo, context, repositories);
                        }
                        catch (Exception ex)
                        {
                            throw new RecordUpdateException($"Не удалось обновить запись с кодом: {packageItem.Record.Code}", ex); ;
                        }

                    }
                }
                scope.SaveChanges();
            }
        }

        /// <summary>
        /// Применяет элемент обновления записи к записи согласно указанной в нём операции обновления
        /// </summary>
        private void ApplyOperationToRecord(UpdatePackageItem<TReferenceEntity> packageItem, UpdatePackage<TReferenceEntity> package, TReferenceEntity previousVersion, IDataSet<TReferenceEntity> repo, TDataContext context, Dictionary<Type, IDataSet> repositories)
        {
            switch (packageItem.Operation)
            {
                // если операция обновления записи == "добавлена", то
                case UpdateOperation.Addition:
                    // если в кеше есть запись с тем же кодом
                    if (previousVersion != null)
                        throw new ReferenceException(
                            $"Record with code \"{packageItem.Record.Code}\" already exist and can't be added twice");

                    // добавить версию новой записи в справочник
                    AddNewVersion(packageItem, package, null, repo, context, repositories);
                    break;

                // если операция обновления записи == "изменена" или "удалена", то
                case UpdateOperation.Modification:
                case UpdateOperation.Removal:
                    // если она не существует или флаг "удалена" установлен
                    if (previousVersion == null)
                        throw new ReferenceException(
                            $"Record with code \"{packageItem.Record.Code}\" not exist and can't be modified");
                    //if (previousVersion.IsDeleted)
                    //    throw new ReferenceException(
                    //        $"Record with code \"{packageItem.Record.Code}\" is marked as deleted and can't be modified");

                    // снять актуальность с предыдущей версии записи из кеша
                    if (!previousVersion.IsDeleted)
                        previousVersion.ReleaseDateEnd = package.ReleaseDateFrom ?? DateTime.MinValue;

                    // добавить новую версию существующей записи
                    AddNewVersion(packageItem, package, previousVersion.RecordId, repo, context, repositories);
                    break;

                case UpdateOperation.Auto:
                    // автоматически определить операцию на основе текущего состояния записи
                    if (previousVersion == null)
                    {
                        // предыдущей версии записи нет, по этому нужно её добавить
                        ApplyOperationToRecord(
                            new UpdatePackageItem<TReferenceEntity>(packageItem.Record, UpdateOperation.Addition),
                            package, null, repo, context, repositories);
                    }
                    else
                    {
                        // предыдущая версия записи есть, нужно определить, отличается ли она от уже существующей и
                        // добавить её, если различия имеются
                        if (IsDifferentVersion(packageItem.Record, previousVersion))
                        {
                            ApplyOperationToRecord(new UpdatePackageItem<TReferenceEntity>(packageItem.Record,
                                packageItem.Record.IsDeleted ? UpdateOperation.Removal : UpdateOperation.Modification),
                                package, previousVersion, repo, context, repositories);
                        }
                        else
                        {
                            previousVersion.ReleaseDateBegin = package.ReleaseDateTo;
                        }
                    }
                    break;
            }
        }

        private bool IsDifferentVersion(TReferenceEntity newVersion, TReferenceEntity previousVersion)
        {
            // сравнить две записи по значимым свойствам и вернуть true, если есть различия
            return SignificantProperties.Any(o => !object.Equals(o.GetValue(newVersion), o.GetValue(previousVersion)));
        }

        // Добавляет новую версию записи, отражающую в ней соответственную операцию обновления
        private void AddNewVersion(UpdatePackageItem<TReferenceEntity> packageItem, UpdatePackage<TReferenceEntity> package, Guid? previousRecordId, IDataSet<TReferenceEntity> repo, TDataContext context, Dictionary<Type, IDataSet> repositories)
        {
            var record = packageItem.Record;
            record.VersionId = IdentifierProvider.NewIdentifier();
            record.RecordId = previousRecordId ?? IdentifierProvider.NewIdentifier();
            record.ReleaseDateBegin = package.ReleaseDateTo;
            record.ReleaseDateEnd = packageItem.Operation == UpdateOperation.Removal ? package.ReleaseDateTo : ReferenceBookConstants.ActualReleaseEndDate;
            record.IsDeleted = packageItem.Operation == UpdateOperation.Removal;

            // обработать связанные записи других справочников
            AssignRelatedReferenceRecords(record, context, repositories);
            repo.Add(record);
        }

        // Обрабатывает связи текущей записи с записями других справочников, согласно данным в
        // описаниях связей, объявленных в справочнике.
        private void AssignRelatedReferenceRecords(TReferenceEntity record, TDataContext context, Dictionary<Type, IDataSet> repositories)
        {
            // для каждого поля кода из связаного справочника и соответственного ему поля со связанной сущностью
            foreach (var definitionInfo in _relationDefinitionInfos)
            {
                // получить значение кода
                var code = (string)definitionInfo.RelationCodeProperty.GetValue(record);

                // получить объект связанного справочника
                var referenceBook = definitionInfo.RelatedReferenceBookFactory();
                if (referenceBook == null)
                    throw new ReferenceException("Related reference book factory return null object");

                // получить из связанного справочника запись с кодом той версии, которая была наиболее актуальной
                //  на момент релиза текущей записи
                var relatedRecords = referenceBook.QueryRecords(Criteria.For<ReferenceEntity>().ByCode(code));
                var relatedRecord = relatedRecords.Where(o => o.ReleaseDateBegin <= record.ReleaseDateBegin)
                    .OrderByDescending(o => o.ReleaseDateBegin)
                    .FirstOrDefault();
                // если такой записи нет, вернуть исключение и прервать работу
                if (relatedRecord == null)
                    throw new ReferenceException("Can not find related reference record for code " + code + " and release " +
                                                 record.ReleaseDateBegin.ToString("yyyy.MM.dd") + " in " +
                                                 referenceBook.GetType().Name);
                try
                {
                    var ownedRelatedRecord =
                        repositories[definitionInfo.RelationProperty.PropertyType]?.Get(relatedRecord.VersionId);
                    // присвоить связанную запись в поле связи текущей записи
                    definitionInfo.RelationProperty.SetValue(record, ownedRelatedRecord);
                    // присвоить id связанной записи в поле id внешнего ключа
                    definitionInfo.RelationIdProperty.SetValue(record, relatedRecord.VersionId);
                }
                catch (Exception exception)
                {
                    throw new ReferenceException(
                        "Can not assign related property " + definitionInfo.RelationProperty.Name +
                        " of record or corresponding foreign id property", exception);
                }
            }
        }

        private static IDataSet GetRepoOrDefault(TDataContext context, Type propertyType)
        {
            IDataSet set;
            var exist = context.TrySet(propertyType, out set);
            return exist ? set : null;
        }

        /// <summary>
        /// Объявляет связь между записями текущего справочника и записями других связанных
        /// записей. Используется при актуализации ссылок при обновлении записей справочника
        /// </summary>
        /// <typeparam name="TRelatedReferenceEntity">Тип связанной записи справочника</typeparam>
        /// <param name="relationProperty">Лямбда, указывающая свойство-связь с объектом записи другого справочника</param>
        /// <param name="relationCodeProperty">Лямбда, указывающая свойство, в котором хранится код связанной записи</param>
        /// <param name="relatedReferenceBookFactory">Делегат, возвращающий объект связанного справочника</param>
        /// <param name="relationIdProperty">Лямбда, указывающая свойство, в котором хранится id связанной сущности</param>
        protected void DefineRelation<TRelatedReferenceEntity>(Expression<Func<TReferenceEntity, TRelatedReferenceEntity>> relationProperty,
            Expression<Func<TReferenceEntity, Guid?>> relationIdProperty,
            Expression<Func<TReferenceEntity, string>> relationCodeProperty,
            Func<IReferenceBook<TRelatedReferenceEntity>> relatedReferenceBookFactory)
            where TRelatedReferenceEntity : ReferenceEntity
        {
            if (relationProperty == null)
                throw new ArgumentNullException(nameof(relationProperty));
            if (relationIdProperty == null)
                throw new ArgumentNullException(nameof(relationIdProperty));
            if (relationCodeProperty == null)
                throw new ArgumentNullException(nameof(relationCodeProperty));
            if (relatedReferenceBookFactory == null)
                throw new ArgumentNullException(nameof(relatedReferenceBookFactory));

            _relationDefinitionInfos.Add(new RelationDefinitionInfo
            {
                RelationProperty = relationProperty.GetPropertyFromExpression(),
                RelationIdProperty = relationIdProperty.GetPropertyFromExpression(),
                RelationCodeProperty = relationCodeProperty.GetPropertyFromExpression(),
                RelatedReferenceBookFactory = relatedReferenceBookFactory
            });
        }

        /// <summary>
        /// Хранит данные описания связанной записи
        /// </summary>
        private struct RelationDefinitionInfo
        {
            public PropertyInfo RelationProperty;
            public PropertyInfo RelationIdProperty;
            public PropertyInfo RelationCodeProperty;
            public Func<IReferenceBook> RelatedReferenceBookFactory;
        }
    }
}
