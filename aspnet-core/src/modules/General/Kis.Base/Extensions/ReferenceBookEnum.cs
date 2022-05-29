using System;

namespace Kis.Base.Extensions
{
    /// <summary>
    /// Атрибут для элементов перечислений, которые представлены справочниками в системе.
    /// Привязывает к каждому элементу перечисления метаданные, необходимые для 
    /// формирования записей в соответствующем справочнике
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class RefBookRecordAttribute : Attribute
    {
        /// <summary>
        /// Возвращает/задаёт числовой идентификатор элемента справочника, уникальный в 
        /// пределах перечисления
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Возвращает идентификатор записи, преобразованный в Guid
        /// </summary>
        public Guid Guid { get { return Id.ToGuid(); } }
        /// <summary>
        /// Уникальный человеко-ориентированный код записи справочника
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Описание/расшифровка записи справочника
        /// </summary>
        public string Name { get; set; }
    }

    public static class RefBookEnumExtension
    {
        public static RefBookRecordAttribute GetRef(this Enum value)
        {
            if (value == null) throw new ArgumentNullException("value");
            var attribute = value.GetEnumAttribute<RefBookRecordAttribute>();
            if (attribute == null)
                throw new Exception("Перечисление не содержит атрибута RefBookRecord с данными справочника");
            return attribute;
        }
    }
}
