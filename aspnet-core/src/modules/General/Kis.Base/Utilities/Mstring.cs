using System;

namespace Kis.Base.Utilities
{
    /// <summary>
    /// Модернизированный класс строки, котрая содержит в себе дополнительную информацию о ее форматировании при выводе ее на устройства вывода (экран)
    /// </summary>
    public class Mstring
    {
        /// <summary>
        /// Содержимое строки
        /// </summary>
        public string Str { get; set; }

        /// <summary>
        /// Цвет текста
        /// </summary>
        public ConsoleColor Fcolor { get; set; }

        /// <summary>
        /// Цвет фона
        /// </summary>
        public ConsoleColor Bcolor { get; set; }

        public Mstring()
        {
            Fcolor = Console.ForegroundColor;

            Bcolor = Console.BackgroundColor;
        }

        public Mstring(string str) : this()
        {
            Str = str;
        }

        public Mstring(string str, ConsoleColor fColor) : this(str)
        {
            Fcolor = fColor;
        }

        public Mstring(string str, ConsoleColor fColor, ConsoleColor bColor) : this(str, fColor)
        {
            Bcolor = bColor;
        }


    }
}
