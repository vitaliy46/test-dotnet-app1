using System;
using System.Collections.Generic;
using Kis.Base.Dto;
using Kis.Organization.Api.Dto;
using Kis.TaskTrecker.Api.Dto;

namespace Kis.Investors.Api.Dto
{
    public class InvestedProjectDto : BaseDto<Guid>
    {
        public ProjectDto Project { get; set; }
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Управляющая компания по реализации проекта
        /// </summary>
        public OrganizationUnitDto ManagingCompany { get; set; }
        public Guid ManagingCompanyId { get; set; }
    }
}
