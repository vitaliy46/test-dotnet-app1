using System;
using Abp.Application.Services.Dto;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;

namespace Kis.Organization.Api.Dto
{
    /// <summary>
    /// Связь организации с файлом (сканкопией)
    /// </summary>
    public class PagedOrganizationUnitMediaResultRequestDto : PagedResultRequestDto
    {
        public string Label { get; set; }

        public Guid OrganizationId { get; set; }
    }
}
