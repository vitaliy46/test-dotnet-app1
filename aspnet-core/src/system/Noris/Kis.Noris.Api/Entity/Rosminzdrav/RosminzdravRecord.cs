using System.Collections.Generic;
using Kis.Noris.Api.Exceptions;
using Kis.Noris.Api.Service_References.Rosminzdrav.Nsi;

namespace Kis.Noris.Api.Entity.Rosminzdrav
{
    /// <summary>
    /// Класс-обертка для представления записи справочника, полученного от веб-сервиса Росминздрава
    /// </summary>
    public class RosminzdravRecord
    {
        /// <summary>
        /// Словарь, в котором хранятся поля записи и их значения
        /// </summary>
        private IDictionary<string, string> _dictionary;

        public RosminzdravRecord(Map recordMap)
        {
            // В свойстве children объекта recordMap хранится массив item со списком полей и их значениями,
            // представляющие данные записи. Для каждого элемента массива создается запись в поле
            // _dictionary, куда в качестве ключа записывается значением из свойства KEY элемента массива,
            // а качестве значения - значение свойства VALUE элемента массива

            _dictionary = new Dictionary<string, string>();

            foreach (Map m in recordMap.children.item)
                _dictionary.Add(m.key, m.value);
        }

        /// <summary>
        /// Индексатор по полю записи
        /// </summary>
        /// <param name="key">Наименование поля</param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                try
                {
                    return _dictionary[key];
                }
                catch (KeyNotFoundException ex)
                {
                    throw new NamedKeyNotFoundException(key, ex.Message);
                }
            }
        }
    }
}
