using System;
using Kis.Authorization.Users;
using Kis.Base.Entity;
using Microsoft.Net.Http.Headers;

namespace Kis.Organization.Api.Entity
{
    /// <summary> Учетная запись для организации
    /// </summary>
    public class OrganizationUnitUser : EntityWithGuidIdBase
    {
        public virtual OrganizationUnit OrganizationUnit { get; set; }
        public Guid OrganizationUnitId { get; set; }

        public User User { get; set; }
        public long UserId { get; set; }
    }
}
