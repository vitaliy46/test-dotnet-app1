using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Staff.Api.Entity
{
    /// <summary>
    /// Контактные данные сотрудника.
    /// </summary>
    public class EmployeeContact : EntityBase<Guid>
    {
        public virtual Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        public Contact Contact { get; set; }
        public Guid ContactId { get; set; }
    }
}
