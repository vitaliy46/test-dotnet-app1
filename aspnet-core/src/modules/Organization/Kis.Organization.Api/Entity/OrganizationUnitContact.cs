using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Organization.Api.Entity
{
    /// <summary>
    /// Сонтактные данные структурного подразделения
    /// </summary>
    public class OrganizationUnitContact : EntityBase<Guid>
    {
        public virtual OrganizationUnit OrganizationUnit { get; set; }
        public Guid OrganizationUnitId { get; set; }

        public Contact Contact { get; set; }
        public Guid ContactId { get; set; }
    }
}
