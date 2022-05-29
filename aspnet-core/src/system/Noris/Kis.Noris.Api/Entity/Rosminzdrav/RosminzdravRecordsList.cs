using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kis.Noris.Api.Service_References.Rosminzdrav.Nsi;

namespace Kis.Noris.Api.Entity.Rosminzdrav
{
    /// <summary>
    /// Класс-обертка для представления списка записей справочника, полученного от веб-сервиса Росминздрава
    /// </summary>
    public class RosminzdravRecordsList : IEnumerable<RosminzdravRecord>
    {
        /// <summary>
        /// Массив для хранения списка записей
        /// </summary>
        private RosminzdravRecord[] records;

        /// <summary>
        /// Индексатор
        /// </summary>
        public RosminzdravRecord this[int index]
        {
            get { return records[index]; }
        }

        public RosminzdravRecordsList(ArrayOfMap arrayOfMap)
        {
            // В объекте arrayOfMap свойство item является массивом, каждый элемент которого соответствует
            // одной записи. Сначала инициализируем массив длиной свойства item, после чего последовательно
            // инициализируем каждый элемент массива, передавая в его конструктор элемент массива item

            records = new RosminzdravRecord[arrayOfMap.item.Length];

            for (int i = 0; i < records.Length; i++)
                records[i] = new RosminzdravRecord(arrayOfMap.item[i]);
        }

        public IEnumerator<RosminzdravRecord> GetEnumerator()
        {
            return records.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
