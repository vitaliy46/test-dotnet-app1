using System;
using Kis.Noris.Api.Constants;


namespace Kis.Noris.Api.Entity
{
    /// <summary>
    /// Базовый класс для элемента справочника. Содержит общий набор
    /// полей для всех записей.
    /// </summary>
    public abstract class ReferenceEntity
    {
        /// <summary>
        /// Уникальный идентификатор версии записи справочника.
        /// Ключевое поле справочника
        /// </summary>
        public Guid VersionId { get; set; }

        /// <summary>
        /// Идентификатор записи справочника. У разных 
        /// версий справочника он одинаковый
        /// </summary>
        public Guid RecordId { get; set; }

        /// <summary>
        /// Число-буквенный код записи справочника. Уникальный для
        /// каждой записи, но один для всех её версий.
        /// </summary>
        public string Code { get; set; }

        /// <summary> 
        /// Составной код записи, состоящий из нескольких кодов. Комбинация 
        /// кодов каждой записи
        /// </summary>
        public string[] Codes
        {
            get { return GetCodes(Code); }
            set { Code = MergeCodes(value); }
        }

        /// <summary>
        /// Начальная релиз-дата интервала дат релизов справочника.
        /// Интервал содержит набор релизов, в рамках которого текущая 
        /// версия записи была актуальна.
        /// В истории версий каждой записи интервалы не пересекаются, и идут 
        /// строго друг за другом.
        /// </summary>
        public DateTime ReleaseDateBegin { get; set; }

        /// <summary>
        /// Конечная релиз-дата интервала дат релизов справочника.
        /// Интервал содержит набор релизов, в рамках которого текущая 
        /// версия записи была актуальна. 
        /// В истории версий каждой записи интервалы не пересекаются, и идут 
        /// строго друг за другом.
        /// </summary>
        public DateTime ReleaseDateEnd { get; set; }

        /// <summary>
        /// Флаг актуальной записи. Указывает, что версия записи 
        /// является последней и принадлежит актуальной версии справочника
        /// </summary>
        public bool IsActual => ReleaseDateEnd == ReferenceBookConstants.ActualReleaseEndDate && !IsDeleted;

        /// <summary>
        /// Флаг удалённой записи. Устанавливается, если запись была удалена
        /// на текущей её версии и более в справочнике не используется
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Объединяет несколько кодов в один составной
        /// </summary>
        public static string MergeCodes(string[] codes)
        {
            if (codes == null)
                throw new ArgumentNullException("codes");

            return string.Join(";", codes);
        }

        /// <summary>
        /// Получает отдельные коды из составного кода
        /// </summary>
        public static string[] GetCodes(string code)
        {
            return code.Split(';');
        }
    }
}
