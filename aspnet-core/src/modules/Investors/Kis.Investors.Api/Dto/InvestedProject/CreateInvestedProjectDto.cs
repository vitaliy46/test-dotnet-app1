using System;
using System.Collections.Generic;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.Organization.Api.Dto;
using Kis.TaskTrecker.Api.Dto;

namespace Kis.Investors.Api.Dto
{
    public class CreateInvestedProjectDto : IShouldNormalize
    {
        public CreateProjectDto Project { get; set; }

        /// <summary>
        /// Управляющая компания по реализации проекта
        /// </summary>
        public CreateOrganizationUnitDto ManagingCompany { get; set; }

 
        public void Normalize()
        {}
    }
}
