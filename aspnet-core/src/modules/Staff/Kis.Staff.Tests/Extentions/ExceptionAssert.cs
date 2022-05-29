using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kis.Staff.Tests.Extentions
{
    /// <summary>
    /// Содержит статичные методы для тестирования генерации исключений. Применительно с MSTest.
    /// </summary>
    public static class ExceptionAssert
    {
        /// <summary>
        /// Принимает в качестве параметра делегат, инкапсулирующий метод, 
        /// который необходимо проверить на выброс исключения типа <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <param name="task">Делегат, инкапсулирующий метод в кототром ожидается генерация исключения</param>
        /// <param name="paramName">Ожидаемое имя параметра, вызвавшее исключение</param>
        public static void Throws(Action task, string paramName = "")
        {
            try
            {
                task();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException),
                    $"Было вызвано исключение типа {ex.GetType()} не соответствующее ожидаемому типу.");
                Assert.IsTrue(((ArgumentNullException)ex).ParamName == paramName,
                    $"Имя параметра, ставшего причиной исключения {((ArgumentNullException)ex).ParamName} не соответствует ожидаемому значению {paramName}.");
                return;
            }

            Assert.Fail($"Ожидаемое исключение типа {typeof(ArgumentNullException)} не было вызвано.");
        }

        /// <summary>
        /// Принимает в качестве параметра делегат, инкапсулирующий метод, 
        /// который необходимо проверить на выброс исключения указанного типа.
        /// </summary>
        /// <typeparam name="T">Тип ожидаемого исключения</typeparam>
        /// <param name="task">Делегат, инкапсулирующий метод в котором ожидается исключение</param>
        public static void Throws<T>(Action task) where T : Exception
        {
            try
            {
                task();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(T), $"Было вызвано исключение типа {ex.GetType()} не соответствующее ожидаемому типу.");
                return;
            }

            if (typeof(T).Equals(new Exception().GetType())) Assert.Fail("Ожидаемое исключение не было вызвано.");
            else Assert.Fail($"Ожидаемое исключение типа {typeof(T)} не было вызвано.");
        }
    }
}
