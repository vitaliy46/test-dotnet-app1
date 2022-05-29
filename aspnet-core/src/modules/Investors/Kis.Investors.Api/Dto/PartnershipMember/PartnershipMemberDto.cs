using System;
using Kis.Base.Dto;
using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Entity;

namespace Kis.Investors.Api.Dto
{
    /// <summary>
    /// Член инвестиционного товарищества
    /// </summary>
    public class PartnershipMemberDto : BaseDto<Guid>
    {
        public OrganizationUnitDto Organization { get; set; }
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Контактное лицо члена товарищества
        /// </summary>
        public MemberContactorDto Contactor { get; set; }
        
        public bool IsAllowSmsNotification { get; set; }
    }
}
