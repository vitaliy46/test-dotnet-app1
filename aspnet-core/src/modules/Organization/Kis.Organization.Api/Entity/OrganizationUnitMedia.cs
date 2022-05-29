using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Organization.Api.Entity
{
    /// <summary>
    /// Связь организации с файлом (сканкопией)
    /// </summary>
    public class OrganizationUnitMedia : EntityBase<Guid>
    {
        public virtual OrganizationUnit OrganizationUnit { get; set; }
        public Guid OrganizationUnitId { get; set; }

        public Media Media { get; set; }
        public Guid MediaId { get; set; }
    }
}
