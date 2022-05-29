using System.Collections.Generic;
using Kis.Base.Dto;

namespace Kis.Base.Contracts
{
    /// <summary>
    /// Контракт данных для списочных форм
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    public class GetAllContract<TDto, TId>
        where TDto :  BaseDto<TId>
    {
        /// <summary>
        /// Количество запрошенных данных
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Общее количество данных
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Набор данных
        /// </summary>
        public ICollection<TDto> Items { get; set; }

        /// <summary>
        /// Форматированная строка, указывающая какие свойства пользовательских типов 
        /// нужно вернуть загруженными, а все остальные - только ссылками на ресурсы
        /// </summary>
        public string Extract { get; set; }
    }
}
