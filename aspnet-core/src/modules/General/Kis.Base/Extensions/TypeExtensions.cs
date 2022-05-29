using System;

namespace Kis.Base.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsSubclassOfRawGeneric(this Type type, Type genericType)
        {
            if (type == null) throw new ArgumentNullException("type");

            while (type != null && type != typeof(object))
            {
                if (genericType == (type.IsGenericType ? type.GetGenericTypeDefinition() : type))
                    return true;
                type = type.BaseType;
            }
            return false;
        }
    }
}
