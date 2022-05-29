using System;
using Kis.Base.Dto;

namespace Kis.Investors.Api.Dto
{
    /// <summary>
    /// Член инвестиционного товарищества
    /// </summary>
    public class PartnershipMemberShortDto : BaseDto<Guid>
    {
        public string OrganizationName { get; set; }

        public string ContactorName { get; set; }

        /// <summary>
        /// Количество проектов в которых товарищь принимает участие в качестве инвестора
        /// </summary>
        public int ProjectsCount { get; set; }
    }
}
