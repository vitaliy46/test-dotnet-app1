using System;
using System.Collections.Generic;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Services
{
    //TODO рефакторить
    //public interface IReferenceBookManager
    //{
        
    //    ReferenceBookInfo AddRefBook<T>(IReferenceBook<T> refBook) where T : ReferenceEntity;
    //    IList<ReferenceBookInfo> GetAllBooks();
    //    IList<ReferenceBookInfo> GetBooks();
    //    ReferenceError CheckUpdates(string [] codes);
    //    ReferenceError Update(string [] codes);
    //    ReferenceRecord GetBookRecords(string code, DateTime? release = null);
    //    ReferenceScript GetScripts(string code, DateTime? release = null);
    //    //ReferenceScript SaveScript(HttpPostedFileBase file, string code, DateTime date); Временно отключен
    //    ReferenceScript DeleteScript(string code, DateTime release);
        
    //}

    /// <summary>
    /// Интерфейс содержит методы для выполнения различных операций со справочниками
    /// </summary>
    public interface IReferenceBookManager
    {
        /// <summary>
        /// Возвращает список объектов, содержащих информацию о справочниках, получаемую 
        /// из объекта IReferenceBook и его атрибута Reference
        /// </summary>
        /// <returns></returns>
        IEnumerable<ReferenceBookShortInfo> GetAll();

        /// <summary>
        /// Осуществляет поиск справочника по названию его Entity-сущности и возвращает
        /// краткую информацию о справочнике
        /// </summary>
        /// <param name="className">Имя Entity-сущности, представляющей справочник</param>
        /// <returns></returns>
        ReferenceBookShortInfo GetReferenceBookShortInfoByEntityName(string className);

        /// <summary>
        /// Метод принимает скрипт с обновлением справочника в виде массива байтов, формирует 
        /// его имя и кладет в папку, путь к которой указан в файле конфигурации
        /// </summary>
        /// <param name="script">Массив байтов, содержащий файл со скриптом</param>
        /// <param name="fileName">Имя загружаемого файла</param>
        /// <returns>Булевое значение, показывающее, успешно ли произошло перемещение файла</returns>
        void UploadReferenceBookUpdateScript(byte[] script, string fileName);

        /// <summary>
        /// Возвращает объект IReferenceBook по названию его entity-сущности
        /// </summary>
        /// <param name="entityName">Название entity-сущности</param>
        /// <returns></returns>
        IReferenceBook GetReferenceBook(string entityName);

        /// <summary>
        /// Метод ищет в папке, определенной в файле конфигурации, скрипт с обновлением справочника по 
        /// его кодовому обозначению и дате обновления и перемещает его в папку для некорректных скриптов
        /// </summary>
        /// <param name="fileName">Кодовое обозначение справочника</param>
        /// <param name="UpdateDate">Дата обновления</param>
        void ReplaceInvalidReferenceBookUpdateScript(string fileName, DateTime UpdateDate);
    }
}
