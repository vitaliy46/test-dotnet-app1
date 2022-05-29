using System;
using Abp;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;

namespace Kis.Organization.Api.Dto
{
    /// <summary>
    /// Связь организации с файлом (сканкопией)
    /// </summary>
    public class CreateOrganizationUnitMediaDto : IShouldNormalize
    {
        public Guid OrganizationUnitId { get; set; }

        public CreateMediaDto Media { get; set; }
        public void Normalize()
        {
        }
    }
}
