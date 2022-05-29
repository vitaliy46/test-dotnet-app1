using System;

using Kis.Base.Entity;
using Kis.Organization.Api.Entity;

namespace Kis.Staff.Api.Entity
{
    /// <summary>
    /// Должность в организации.
    /// </summary>
    public class Position : EntityBase<Guid>
    {
        /// <summary>
        /// Структурное подразделение в котором существует должность.
        /// </summary>
        public virtual OrganizationUnit OrganizationUnit { get; set; }
        public Guid OrganizationUnitId { get; set; }

        /// <summary>
        /// Название должности.
        /// </summary>
        public string Name { get; set; }
    }
}
