using System;
using Kis.Base.Dto;
using Kis.Organization.Api.Dto;

namespace Kis.Staff.Api.Dto
{
    /// <summary>
    /// Должность в организации
    /// </summary>
    public class PositionDto : BaseDto<Guid>
    {
        public string Name { get; set; }

        public OrganizationUnitDto OrganizationUnit { get; set; }
    }
}