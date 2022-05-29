using System.Text.RegularExpressions;
using Kis.Noris.Api.Exceptions.RosminzdravExceptions;
using Kis.Noris.Api.Service_References.Rosminzdrav.Nsi;

namespace Kis.Noris.Api.Extensions
{
    /// <summary>
    /// Класс для методов расширения объектов, принимаемых через веб-сервис Росминздрава
    /// </summary>
    public static class RosminzdravExtensions
    {
        /// <summary>
        /// Метод для проверки отсутствия ошибки в массиве объектов, присланном от веб-сервиса
        /// </summary>
        /// <param name="arrayOfMap">Массив объектов</param>
        /// <returns>Массив, запустивший метод и успешно прошедший проверку</returns>
        public static ArrayOfMap Check(this ArrayOfMap arrayOfMap)
        {
            // В случае, если веб-сервис вернет сообщение об ошибке, длина массива будет 1
            if (arrayOfMap.item.Length != 1)
                return arrayOfMap;

            // У первого элемента массива длина массива children, так же будет 1 в случае ошибки
            if (arrayOfMap.item[0].children.item.Length != 1)
                return arrayOfMap;

            // В таком случае в первом элементе массива children будет записана информация об ошибке
            // Код ошибки имеет вид 00x0000 и будет записан в поле key. Таким образом, проверяем первый элемент
            // children первого элемента map и если он соответствует рег.выражению, то генерируем exception,
            // а если нет - значит информация от веб-сервиса корректная
            string key = arrayOfMap.item[0].children.item[0].key;

            if (Regex.IsMatch(key, @"\d+x\d+"))
            {
                string errorDescription = arrayOfMap.item[0].children.item[0].value;
                throw new RosminzdravServiceException(key, errorDescription);
            }
            else
                return arrayOfMap;
        }
    }
}
