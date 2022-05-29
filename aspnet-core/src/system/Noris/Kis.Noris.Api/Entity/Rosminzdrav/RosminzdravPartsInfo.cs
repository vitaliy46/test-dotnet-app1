using System.Linq;
using Kis.Noris.Api.Service_References.Rosminzdrav.Nsi;

namespace Kis.Noris.Api.Entity.Rosminzdrav
{
    /// <summary>
    /// Класс-обертка для веб-запроса количества частей справочника, полученного от веб-сервиса Росминздрава
    /// </summary>
    public class RosminzdravPartsInfo
    {
        /// <summary>
        /// Количество частей, в которых размещены данные справочника
        /// </summary>
        public int CountParts { get; set; }

        public RosminzdravPartsInfo(ArrayOfMap arrayOfMap)
        {
            // Объект arrayOfMap содержит свойство item класса Map[]. В случае запроса кол-ва частей
            // справочника этот массив состоит только из одного элемента, который и отражает это кол-во.
            // В единственном элементе массива item расположено свойство children класса ArrayOfMap. 
            // В его свойстве-массиве item также расположен единственный элемент Map, который содержит в свойстве value
            // кол-во частей справочника

            // Ключи:
            // partsAmount - кол-во частей справочника

            string countStr = arrayOfMap.item[0].children.item.FirstOrDefault(x => x.key == "partsAmount").value;
            CountParts = int.Parse(countStr);
        }
    }
}
