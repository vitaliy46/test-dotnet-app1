using System;
using Kis.Base.Dto;
using Kis.Organization.Api.Dto;


namespace Kis.Investors.Api.Dto
{
    /// <summary>
    /// Инвестиционное товарищество
    /// </summary>
    public class PartnershipDto : BaseDto<Guid>
    {
        /// <summary>
        /// Организация представляющая товарищество 
        /// </summary>
        public OrganizationUnitDto Organization { get; set; }
        public Guid OrganizationId { get; set; }


        /// <summary>
        /// Управляющая компания из состава членов товарищества
        /// </summary>
        public Guid? ManagerId { get; set; }
    }
}
