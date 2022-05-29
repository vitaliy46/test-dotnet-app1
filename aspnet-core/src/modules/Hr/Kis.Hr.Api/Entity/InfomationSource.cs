using System;
using Kis.Base.Entity;

namespace Kis.Hr.Api.Entity
{
    /// <summary>
    /// Источник поступления информации о чем либо.
    /// </summary>
    public class InfomationSource : EntityBase<Guid>
    {
        /// <summary>
        /// Название источника.
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// Указывает на наличие api у источника получения информации
        /// который можно использовать для автоматизированной загрузки данных.
        /// </summary>
        public bool HasApi { get; set; }
    }
}
