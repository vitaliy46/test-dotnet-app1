using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Organization.Api.Entity
{
    /// <summary>
    /// Адрес структурного подразделения.
    /// </summary>
    public class OrganizationUnitAddress : EntityBase<Guid>
    {
        /// <summary>
        /// Адрес.
        /// </summary>
        public Address Address { get; set; }
        public Guid AddressId { get; set; }

        /// <summary>
        /// Организационная единица.
        /// </summary>
        public virtual OrganizationUnit OrganizationUnit { get; set; }
        public Guid OrganizationUnitId { get; set; }
    }
}
