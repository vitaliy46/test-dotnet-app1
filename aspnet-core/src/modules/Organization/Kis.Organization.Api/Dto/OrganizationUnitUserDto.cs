using System;
using Kis.Authorization.Users;
using Kis.Base.Dto;
using Kis.Base.Entity;
using Microsoft.Net.Http.Headers;

namespace Kis.Organization.Api.Entity
{
    /// <summary> Учетная запись для организации
    /// </summary>
    public class OrganizationUnitUserDto : BaseWithGuidIdDto
    {
        public Guid OrganizationUnitId { get; set; }

        public long UserId { get; set; }
    }
}
