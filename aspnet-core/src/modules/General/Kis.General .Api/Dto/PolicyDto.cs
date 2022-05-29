using System;

namespace Kis.General.Api.Dto
{
    /// <summary> Полис медицинского страхования
    /// </summary>
    public class PolicyDto : DocumentDto
    {
        /// <summary>
        /// Серия документа
        /// </summary>
        public string Series { get; set; }
        
        /// <summary>
        /// Дата окончания действия документа
        /// </summary>
        public DateTime EndDate { get; set; }
      
    }
}
