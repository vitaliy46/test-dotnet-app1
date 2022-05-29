using System;
using System.Collections.Generic;
using Kis.Base.Dto;
using Kis.Noris.Api.Data.CriteriaApi;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Services
{
    /// <summary>
    /// Базовый нетипизированный интерфейс классов справочников.
    /// </summary>
    public interface IReferenceBook
    {
        /// <summary>
        /// Возвращает набор всех дат релизов текущего справочника
        /// </summary>
        /// <returns>Набор дат релизов</returns>
        IReadOnlyList<ReferenceRelease> GetReleases();

        /// <summary>
        /// Возвращает самую последнюю дату релиза, имеющуюся в справочнике
        /// </summary>
        /// <returns>Последняя дата релиза, либо null если справочник пуст</returns>
        ReferenceRelease GetActualRelease();

        /// <summary>
        /// Возвращает запись по её идентификатору версии.
        /// </summary>
        /// <param name="versionId">Идентификатор версии записи справочника</param>
        /// <returns>Версия записи с запрошенным ид, либо null, если её не удалось найти</returns>
        ReferenceEntity Get(Guid versionId);

        /// <summary>
        /// Метод-запрос единичной записи из текущего справочника. 
        /// </summary>
        /// <param name="criteria">Критерий выборки записей</param>
        /// <returns>Запись, удовлетворяющая критерию выборки, либо null</returns>
        ReferenceEntity QueryRecord(ICriteria criteria);

        /// <summary>
        /// Метод-запрос набора записей из текущего справочника
        /// </summary>
        /// <param name="criteria">Критерий выборки записей</param>
        /// <returns>Набор записей, удовлетворяющий критерию выборки, либо пустой набор</returns>
        IReadOnlyList<ReferenceEntity> QueryRecords(ICriteria criteria);
       
        /// <summary>
        /// Перекодирует справочное свойство какого либо типа в запись мастер справочника
        /// </summary>
        ReferenceEntity Transcode(BaseReferenceDto dto);

        /// <summary>
        /// Формирование критерия поиска в мастер справочнике записи по коду перекодировки
        /// Чаще всего перекодировка локального справочника осуществляется на поле Code мастер справочника.
        /// Но иногда это не так и в этом случае необходимо переопределить это метод, указав то поле мастер
        /// справочника на которое произведена перекодировка.
        /// </summary>
        /// <typeparam name="T">Тип мастер справочника для перекодировки на который происходит
        ///  формируется критерий в локальном справочнике</typeparam>
        /// <param name="code"></param>
        /// <returns></returns>
        ICriteria SearchMasterRecordByTranscode(string code);

        /// <summary>
        /// Формирование критерия поиска записи в справочнике по её коду
        /// </summary>
        /// <param name="codes">Массив строк, содержащих коды записи</param>
        /// <returns></returns>
        ICriteria SearchByCode(string[] codes);

        /// <summary>
        /// Возвращает тип сущности которой оперирует справочник.
        /// Создан для подсистемы сбора ошибок в справочнике
        /// </summary>
        /// <returns></returns>
        Type GetReferenceEntityType();
    }

    /// <summary>
    /// Базовый типизированный интерфейс классов справочников
    /// </summary>
    /// <typeparam name="TRefData">Тип объекта записи справочника</typeparam>
    public interface IReferenceBook<TRefData> : IReferenceBook
        where TRefData : ReferenceEntity
    {
        /// <summary>
        /// Возвращает запись по её идентификатору версии.
        /// </summary>
        /// <param name="versionId">Идентификатор версии записи справочника</param>
        /// <returns>Версия записи с запрошенным ид, либо null, если её не удалось найти</returns>
        new TRefData Get(Guid versionId);

        /// <summary>
        /// Метод-запрос единичной записи из текущего справочника. 
        /// </summary>
        /// <param name="criteria">Типизированный критерий выборки записей</param>
        /// <returns>Набор записей, удовлетворяющий критерию выборки, либо пустой набор</returns>
        TRefData QueryRecord(ICriteria<TRefData> criteria);

        /// <summary>
        /// Метод-запрос набора записей из текущего справочника
        /// </summary>
        /// <param name="criteria">Типизированный критерий выборки записей</param>
        /// <returns>Набор записей, удовлетворяющий критерию выборки, либо пустой набор</returns>
        IReadOnlyList<TRefData> QueryRecords(ICriteria<TRefData> criteria);

        /// <summary>
        /// Выполняет обновление записей справочника согласно содержимому пакета обновления
        /// Добавляет новые версии для записей, на которые влияет обновление
        /// Этот метод может выполнить обновление только с текущей актуальной версии справочника 
        /// на любую более новую.
        /// </summary>
        /// <param name="package">Пакет с данными обновления</param>
        void Update(UpdatePackage<TRefData> package);

        /// <summary>
        /// Перекодирует справочное свойство какого либо типа в запись мастер справочника
        /// </summary>
        new TRefData  Transcode(BaseReferenceDto dto);
        
       
    }
}