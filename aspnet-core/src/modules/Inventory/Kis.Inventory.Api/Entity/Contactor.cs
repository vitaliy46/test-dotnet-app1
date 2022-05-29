using System;
using Kis.Base.Entity;
using Kis.Staff.Api.Entity;

namespace Kis.Inventory.Api.Entity
{
    /// <summary>
    /// Контактное лицо со стороны контрагента
    /// </summary>
    public class Contactor : EntityBase<Guid>
    {
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        public string Description { get; set; }
    }
}
