using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Kis.Base.Extensions
{
    public static class EnumExtensions
    {
        public static T[] GetEnumAttributes<T>(this Enum enumValue)
            where T : Attribute
        {
            var type = enumValue.GetType();
            var attributes = type.GetMember(Enum.GetName(type, enumValue))[0].GetCustomAttributes(typeof(T), false);
            return attributes.Cast<T>().ToArray();
        }

        public static T GetEnumAttribute<T>(this Enum enumValue)
            where T : Attribute
        {
            var attributes = enumValue.GetEnumAttributes<T>();
            return (attributes.Length > 0) ? attributes[0] : null;
        }
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            if (name == null)
            {
                return null;
            }

            var field = type.GetField(name);
            if (field == null)
            {
                return null;
            }

            var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attr != null ? attr.Description : null;
        }

        public static string GetDisplayName(this Enum value)
        {
            //На основе знаяения элемента перечисления получает тип перечисления
            var type = value.GetType();
            //Находим имя элемента перечисления
            var name = Enum.GetName(type, value);

            if (name == null)
            {
                return null;
            }
            //Получаем поле с найденныи именем
            var field = type.GetField(name);
            if (field == null)
            {
                return null;
            }
            //У поля ищется соответсвующий атирбут и возвращается значение его свойства Name
            var attr = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
            return attr != null ? attr.Name : null;
        }
    }
}
