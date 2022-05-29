using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kis.Base.Extensions
{
    public static class EnumerableExtensions
    {
        private static IEnumerable<T> TakeN<T>(IEnumerator<T> enumerator, int n)
        {
            var i = 1;
            yield return enumerator.Current;
            while (i < n && enumerator.MoveNext())
            {
                yield return enumerator.Current;
                i++;
            }
        }

        /// <summary>
        /// Разбивает входную коллекцию объектов на части указанного размера и 
        /// возвращает набор частей
        /// </summary>
        /// <typeparam name="T">Тип объектов в коллекции</typeparam>
        /// <param name="items">Входная коллекция элементов</param>
        /// <param name="chunkSize">Максимальное число элементов в одной части</param>
        /// <returns>Набор частей из целевой коллекции</returns>
        /// <exception cref="ArgumentException">Размер части должен быть больше 1.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null" />.</exception>
        public static IEnumerable<IEnumerable<T>> ToChunks<T>(this IEnumerable<T> items,
            int chunkSize)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (chunkSize <= 0)
                throw new ArgumentException("Размер части должен быть больше 0.");

            using (var enumerator = items.GetEnumerator())
                while (enumerator.MoveNext())
                    yield return TakeN(enumerator, chunkSize).ToArray();
        }

        /// <summary>
        /// Разбивает входную коллекцию объектов на указанное количество равных частей
        /// </summary>
        /// <typeparam name="T">Тип объектов в коллекции</typeparam>
        /// <param name="items">Входная коллекция элементов</param>
        /// <param name="chunksCount">Количество частей, на которое нужно разбить коллекцию</param>
        /// <returns>Набор частей из целевой коллекции</returns>
        /// <exception cref="ArgumentException">Число частей не может быть меньше либо равно 0.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="items"/> is <see langword="null" />.</exception>
        public static IEnumerable<IEnumerable<T>> ToNChunks<T>(this ReadOnlyCollection<T> items, int chunksCount)
        {
            if(chunksCount <= 0) 
                throw new ArgumentException("Chunk count can not be 0 or negative");
            var chunkSize = (int)Math.Ceiling((double)items.Count / chunksCount);
            return items.ToChunks(chunkSize);
        }

        /// <summary> Возвращается пустой список, если при обращении к нему он оказался не инициализирован
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> list)
        {
            return list ?? Enumerable.Empty<T>();
        }
    }
}
