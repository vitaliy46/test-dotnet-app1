using System;

namespace Kis.Noris.Api.Entity
{
    /// <summary>
    /// Представляет краткую информацию о справочнике, получаемую из Entity-сущности,
    /// представляющий справочник
    /// </summary>
    public class ReferenceBookShortInfo
    {
        /// <summary>
        /// Имя класса Entity-сущности справочника
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Краткое имя справочника, используемое при формировании имени файлов обновления
        /// справочника и получаемое из атрибута Entity-сущности справочника
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Человекопонятное описание справочника, получаемое из атрибута Entity-сущности справочника
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Текущая версия справочника
        /// </summary>
        public DateTime? CurrentVersion { get; set; }

        /// <summary>
        /// Тип справочника - мастер или локальный
        /// </summary>
        public string ReferenceBookType { get; set; }
    }
}
