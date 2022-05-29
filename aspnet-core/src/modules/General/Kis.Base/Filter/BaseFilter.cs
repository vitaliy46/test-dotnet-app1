using System;

namespace Kis.Base.Filter
{
    /// <summary>
    /// Базовый класс для всех фильтров на выборку данных
    /// Данные импортируемые из внешних систем обязательно должны иметь
    /// свойства соответствующие  двум указанным критериям
    /// </summary>
    public class BaseFilter
    { 
        /// <summary>
        /// Идентификатор из внешней системы
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Идентификатор самой внешней системы
        /// </summary>
        public Guid? InformationSystemId { get; set; }
    }
}
