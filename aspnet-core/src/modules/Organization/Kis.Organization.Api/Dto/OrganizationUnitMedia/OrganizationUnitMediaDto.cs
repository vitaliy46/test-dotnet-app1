using System;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;

namespace Kis.Organization.Api.Dto
{
    /// <summary>
    /// Связь организации с файлом (сканкопией)
    /// </summary>
    public class OrganizationUnitMediaDto : BaseDto<Guid>
    {
        public Guid OrganizationUnitId { get; set; }

        public MediaDto Media { get; set; }
        public Guid MediaId { get; set; }
    }
}
