using System;
using System.Collections.Generic;
using Kis.Base.Dto;

namespace Kis.Investors.Api.Dto
{
    /// <summary>
    /// Инвестиционное товарищество
    /// </summary>
    public class PlanePartnershipDto : BaseDto<Guid>
    {
       
        public string OrganizationName { get; set; }

        /// <summary>
        /// Управляющая компания из состава членов товарищества
        /// </summary>
        public Guid? ManagerId { get; set; }

    }
}
