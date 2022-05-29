using System;
using System.Threading;

namespace Kis.Base.Utilities
{
    /// <summary>
    /// Модернизированная консоль, в которой можно выводить текст на экран с форматированием
    /// При необходимости эта консоль может работать в потокобезопасном режиме, установкой соответ
    /// параметра needLock в true
    /// </summary>
    public static class Mconsole
    {
        //Фиктивное поле, используемое для блокировки вывода на монитор
        private static readonly object LockObject = "Abc";

        public static void WriteLine(Mstring str, bool needLock = false)
        {
            _wrap(needLock, () =>
            {
                var bColor = Console.BackgroundColor;

                var fColor = Console.ForegroundColor;

                Console.BackgroundColor = str.Bcolor;

                Console.ForegroundColor = str.Fcolor;

                Console.WriteLine(str.Str);

                Console.BackgroundColor = bColor;

                Console.ForegroundColor = fColor;
            });
        }

        public static void WriteLine(Mstring[] strings, bool needLock = false)
        {
            _wrap(needLock, () =>
            {
                foreach (var mstring in strings)
                {
                    Write(mstring);
                }

                Console.WriteLine();
            });
        }

        public static void WriteLine(bool needLock = false)
        {
            _wrap(needLock, Console.WriteLine);
        }

        public static void Write(Mstring str, bool needLock = false)
        {
            _wrap(needLock, () =>
            {
                var bColor = Console.BackgroundColor;

                var fColor = Console.ForegroundColor;

                Console.BackgroundColor = str.Bcolor;

                Console.ForegroundColor = str.Fcolor;

                Console.Write(str.Str);

                Console.BackgroundColor = bColor;

                Console.ForegroundColor = fColor;
            });
        }
        public static void Write(Mstring[] strings, bool needLock = false)
        {
            _wrap(needLock, () =>
            {
                foreach (var mstring in strings)
                {
                    Write(mstring);
                }
            });
        }

        /// <summary>
        /// Потокобезопасное исполнение по мере необходимости
        /// </summary>
        /// <param name="needLock"></param>
        /// <param name="action"></param>
        private static void _wrap(bool needLock, Action action)
        {
            if (needLock)
                lock (LockObject)
                {
                    Console.Write("Thread id: {0}  ", Thread.CurrentThread.ManagedThreadId);
                    action();
                }
            else
            {
                action();
            }
        }
    }
}
