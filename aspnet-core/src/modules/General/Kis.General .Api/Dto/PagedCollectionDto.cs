using System;
using System.Collections.Generic;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// DTO для REST-методов, возвращающих некоторую коллекцию данных, который содержит 
    /// свойствад для обеспечения пагинации
    /// </summary>
    /// <typeparam name="T">Тип DTO, которые требуется вернуть</typeparam>
    public class PagedCollectionDto<T>
        where T : BaseDto<Guid>
    {
        /// <summary>
        /// Кол-во объектов, возвращаемых в ответе
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Общее кол-во объектов
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Коллекция возвращаемых объектов
        /// </summary>
        public IEnumerable<T> Items { get; set; }
    }
}
