using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Kis.Base.Dto;

namespace Kis.Base.Extensions
{
    /// <summary>
    /// Методы расширения различных классов
    /// </summary>
    public static class ListExtensions
    {
        

        public static IList<T> EmptyIfNull<T>(this IList<T> list)
        {
            return list ?? new List<T>();
        }

        public static IReadOnlyList<T> AsReadOnly<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            return new ReadOnlyCollection<T>(list);
        }

        /// <summary>
        /// Используется в тестах для контроля возвращаемых значений при парсинге
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static string ToString<T>(this IList<T> list)
            where T : BaseDto<Guid>
        {
            var toString = "";

            foreach (var item in list)
            {
                toString += item.ToString();
            }

            return toString;
        }



    }
}
