using System;
using System.Linq;
using Kis.Noris.Api.Service_References.Rosminzdrav.Nsi;

namespace Kis.Noris.Api.Entity.Rosminzdrav
{
    /// <summary>
    /// Класс-обертка для представления версии справочника, полученного от веб-сервиса Росминздрава
    /// </summary>
    public class RosminzdravVersion
    {
        /// <summary>
        /// Номер версии справочника
        /// </summary>
        public string VersionNumber { get; set; }

        /// <summary>
        /// Дата релиза версии справочника
        /// </summary>
        public DateTime VersionDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="versionMap">Объект Map, в котором в виде массива Map[] хранятся сведения о версии справочника</param>
        public RosminzdravVersion(Map versionMap)
        {
            // Объект versionMap содержит свойство children класса ArrayOfMap, которое в свою очередь
            // содержит свойство item типа Map[]. Каждый из этих объектов Map в массиве соответствует
            // определенной информации о версии справочника. В свойстве Key содержится название поля,
            // в свойстве value - его значение

            // Ключи:
            // S_VERSION - номер версии справочника
            // V_DATE - дата релиза версии справочника

            // Если по какой-то причине не удается привести полученную от сервиса дату к .net-типу,
            // ставится минимально возможная дата

            VersionNumber = versionMap.children.item.FirstOrDefault(x => x.key == "S_VERSION").value;

            DateTime outDate;
            if (DateTime.TryParse(versionMap.children.item.FirstOrDefault(x => x.key == "V_DATE").value, out outDate))
                VersionDate = outDate;
            else VersionDate = DateTime.MinValue;
        }

        /// <summary>
        /// Проверяет на корректность данные, полученные из объекта сервсиа Росминздрава
        /// </summary>
        /// <returns>true - если проверка пройдена, false - если не пройдена</returns>
        public bool IsCorrect()
        {
            // Версия справочника считается корректной, если в свойстве VersionNumber есть какое-либо
            // значение и его дата не является минимально возможной датой в .net
            return (!string.IsNullOrEmpty(VersionNumber) && VersionDate != DateTime.MinValue);
        }
    }
}
