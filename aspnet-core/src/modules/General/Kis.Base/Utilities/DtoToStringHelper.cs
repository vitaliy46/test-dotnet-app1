using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kis.Base.Utilities
{
    /// <summary>
    /// Используется в тестовых методах для отображения в строковом формате 
    /// иерархического содержимого Dto объектов 
    /// </summary>
    public class DtoToStringHelper
    {
        /// <summary>
        /// https://support.microsoft.com/ru-ru/kb/320727
        /// Производит сравнение свойств в порядке возрастания приоритета:
        /// 1. Свойства простых типов
        /// 2. Строковые типы
        /// 3. Ссылочные типы
        /// 4. Списочные типы
        /// </summary>
        class PropertyComparer: IComparer<PropertyInfo>
        {
            public int Compare(PropertyInfo p1, PropertyInfo p2)
            {
                if ((p1.PropertyType.IsValueType && !p2.PropertyType.IsValueType)
                    ||(p1.PropertyType == typeof(String)) && !(p2.PropertyType == typeof(String)) && !p2.PropertyType.IsValueType)
                {
                    return -1;
                }
                if ((!p1.PropertyType.IsValueType && p2.PropertyType.IsValueType)
                    ||(!p1.PropertyType.IsValueType && !(p1.PropertyType == typeof(String)) && (p2.PropertyType == typeof(String))))
                {
                    return 1;
                }
                
                    return 0;
            }

        }
        
        /// <summary>
        /// Рекурсивный метод отображения содержимого объектов со значениями их свойств
        /// </summary>
        /// <param name="obj">объект произвольного типа, значения которого будут преобразованы в текст</param>
        ///  <param name="prefix">Для сдвигания вправо вложенных свойств</param>
        /// <param name="parentTypes">Список типов, которые находятся уже выше по иерархии вложенности.
        /// Используется для исключения зацикливания рекурсивной функции при обходе свойств</param>
        /// <returns></returns>
        public string ToString(object obj, IList<Type> parentTypes, string prefix = "")
        {
            var sufix = ">\n\r";
            var type = obj.GetType();
            var toString = prefix+"<"+type.Name + sufix;
            prefix += "  ";//Для сдвигания вправо вложенных свойств
            if(parentTypes == null) parentTypes = new List<Type>();
            //Ранжирование свойств для удобства сравнительного анализа
            var properties = type.GetProperties().OrderBy(x=> x, new PropertyComparer());

            foreach (var property in properties)
            {
                //Исключаются из обработки свойства, тип которых уже встречался 
                //выше в иерархии композиции и агрегации
                var exclude = parentTypes.Any(t=> t == property.PropertyType);

                if (new string[] { "ParentDto", "Entity", "IsProvided" }.Any(x=> x == property.Name) || exclude)
                {
                    //TODO дополнительно исключить свойства ссылающиеся на родительские 
                    //сущности для избежания зацикливания рекурсии
                    continue;
                }
                var propertyInstace = property.GetValue(obj);

                if (propertyInstace != null)
                {
                    if (property.PropertyType.IsValueType || property.PropertyType == typeof(String))
                    {
                        //Для свойств простейших типов
                        toString += $"{prefix}<{property.Name}>{propertyInstace.ToString()}</{property.Name}{sufix}";
                    }
                    else if (property.PropertyType.IsGenericType 
                            && property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
                    //Свойства списочных типов
                    {
                        foreach (var item in (IList)propertyInstace)
                        {
                            //Для ссылочных свойств
                            var _parentTypes = parentTypes.ToList();

                            _parentTypes.Add(property.PropertyType);
                            
                            toString += $"{ToString(item, _parentTypes, prefix)}";
                        }
                    }
                    else
                    {//Для ссылочных свойств
                        var _parentTypes = parentTypes.ToList();

                        _parentTypes.Add(property.PropertyType);

                        toString += $"{ToString(propertyInstace, _parentTypes, prefix)}";
                    }
                }
                else
                {
                    //Не установлено значение для свойства
                    toString += $"{prefix}<{property.Name}>null</{property.Name}{sufix}";
                }
            }

            toString += prefix + "</" + type.Name + sufix;


            return toString;
        }
        
    }
}
