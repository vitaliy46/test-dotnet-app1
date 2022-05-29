using System;
using System.Text;

namespace Kis.Base.Extensions
{

    public static class StringExtensions
    {
        /// <summary> Используется для сравнения строк взятых из БД и приходящих в виде импортированных данных
        /// без учета регистра и пробелов в конце и начале строки
        /// </summary>
        /// <param name="s"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool EqualsFine(this string s, string other)
        {
            return other != null && s.Trim().ToUpper().Equals(other.Trim().ToUpper());
        }

        public static string AsFormat(this string format, params object[] arg)
        {
            if (format == null) throw new ArgumentNullException("format");

            return string.Format(format, arg);
        }

        public static string ToBase64(this string str, Encoding encoding)
        {
            if (str == null) throw new ArgumentNullException("str");

            var bytes = encoding.GetBytes(str);
            return Convert.ToBase64String(bytes);
        }

        public static string ToBase64(this string str)
        {
            return ToBase64(str, Encoding.UTF8);
        }
    }
}
