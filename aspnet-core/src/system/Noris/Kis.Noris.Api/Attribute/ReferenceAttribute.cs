using System;

namespace Kis.Noris.Api.Attribute
{
    /// <summary>
    /// Атрибут, которым помечаются объекты справочных сущностей, содержащий
    /// метаданные справочника
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ReferenceAttribute : System.Attribute
    {
        public ReferenceAttribute(string codeSystem, string codeSystemName)
        {
            CodeSystem = codeSystem;
            CodeSystemName = codeSystemName;
        }

        /// <summary>
        /// Уникальный идентификатор справочника, принятый в системе кодирования справочников, 
        /// может быть как OID, так и другой число-буквенный идентификатор
        /// </summary>
        public string CodeSystem { get; private set; }

        /// <summary>
        /// Наименование справочника, присвоенное системой кодирования справочников
        /// </summary>
        public string CodeSystemName { get; private set; }
    }
}
