using System;

namespace Kis.Noris.Api.Entity.Rosminzdrav
{
    /// <summary>
    /// Представляет описание обновления справочника, поступившего из НСИ Росминздрава
    /// </summary>
    public class RosminzdravUpdateInfo : UpdateInfo
    {
        public RosminzdravUpdateInfo(Type referenceDataType, DateTime releaseDate, string version, string code) : base(referenceDataType, releaseDate)
        {
            Version = version;
            Code = code;
        }

        /// <summary>
        /// Версия справочника
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Код справочника
        /// </summary>
        public string Code { get; set; }
    }
}
