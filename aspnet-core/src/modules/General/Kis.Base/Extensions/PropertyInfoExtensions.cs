using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Kis.Base.Extensions
{
    public static class PropertyInfoExtensions
    {
        //Проверяет наличие атрибута Required  у свойства
        public static bool IsRequired(this PropertyInfo property)
        {
            if (property.CustomAttributes.Any(x => x.AttributeType == typeof(RequiredAttribute)))
                return true;

            return false;
        }



    }
}
