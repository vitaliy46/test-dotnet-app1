using System;
using System.Collections.Generic;

namespace Kis.Base.Extensions
{
    public static class TypeReflectionExtensions
    {
        /// <summary>
        /// Метод возвращает иерархию наследования данного типа Type в последовательности
        /// от текущего типа до типа <see cref="object"/>
        /// </summary>
        /// <param name="type">Тип, для которого разворачивается иерархия наледования</param>
        /// <param name="includeSelf">Если установлено, текущий переданный тип также возвращается в результирующей последовательности</param>
        /// <returns>Последовательность типов предков текущего типа</returns>
        public static IEnumerable<Type> EnumerateHierarchy(this Type type, bool includeSelf = false)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (includeSelf) yield return type;

            var current = type.BaseType;
            while (current != null)
            {
                yield return current;
                current = current.BaseType;
            }
        }
    }
}
