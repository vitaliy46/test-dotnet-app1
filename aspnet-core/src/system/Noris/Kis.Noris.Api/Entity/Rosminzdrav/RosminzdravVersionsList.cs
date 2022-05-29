using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kis.Noris.Api.Service_References.Rosminzdrav.Nsi;

namespace Kis.Noris.Api.Entity.Rosminzdrav
{
    /// <summary>
    /// Класс-обертка для хранения списка версий определенного справочника, полученного от веб-сервиса Росминздрава
    /// </summary>
    public class RosminzdravVersionsList : IEnumerable<RosminzdravVersion>
    {
        /// <summary>
        /// Массив для хранения списка версий
        /// </summary>
        private RosminzdravVersion[] versions;

        public RosminzdravVersionsList(ArrayOfMap arrayOfMap)
        {
            // В объекте arrayOfMap свойство item является массивом, каждый элемент которого соответствует
            // одной версии. Сначала инициализируем массив длиной свойства item, после чего последовательно
            // инициализируем каждый элемент массива, передавая в его конструктор элемент массива item

            versions = new RosminzdravVersion[arrayOfMap.item.Length];

            for (int i = 0; i < versions.Length; i++)
                versions[i] = new RosminzdravVersion(arrayOfMap.item[i]);
        }

        /// <summary>
        /// Индексатор
        /// </summary>
        public RosminzdravVersion this[int index]
        {
            get
            {
                return versions[index];
            }
        }

        public IEnumerator<RosminzdravVersion> GetEnumerator()
        {
            return versions.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
