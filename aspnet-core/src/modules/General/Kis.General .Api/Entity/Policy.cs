using System;

namespace Kis.General.Api.Entity
{
    /// <summary> Полис медицинского страхования
    /// </summary>
    public class Policy : Document
    {
        /// <summary>
        /// Серия документа
        /// </summary>
        //[Index]
        public string Series { get; set; }
        
        /// <summary>
        /// Дата окончания действия документа
        /// </summary>
        public DateTime EndDate { get; set; }

        public virtual Person Person { get; set; }
        public  Guid PersonId { get; set; }


    }
}
