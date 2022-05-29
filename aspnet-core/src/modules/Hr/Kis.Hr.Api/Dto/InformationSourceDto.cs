using System;
using Kis.Base.Dto;

namespace Kis.Hr.Api.Dto
{
    public class InformationSourceDto : BaseDto<Guid>
    {
        public string SourceName { get; set; }

        /// <summary>
        /// Указывает на наличие api у источника получения информации
        /// который можно использовать для автоматизированной загрузки данных
        /// </summary>
        public bool HasApi { get; set; }
    }
}
