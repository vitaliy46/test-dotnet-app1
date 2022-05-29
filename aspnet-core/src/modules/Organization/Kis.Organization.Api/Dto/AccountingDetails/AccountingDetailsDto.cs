using System;
using Kis.Base.Dto;
using Kis.Base.Entity;
using Kis.Organization.Api.Entity;

namespace Kis.Organization.Api.Dto
{
    /// <summary>
    /// Банковские реквизиты организации
    /// </summary>
    public class AccountingDetailsDto : BaseDto<Guid>
    {
        public Guid OrganizationUnitId { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// ОГРН
        /// </summary>
        public string Ogrn { get; set; }
    }
}
