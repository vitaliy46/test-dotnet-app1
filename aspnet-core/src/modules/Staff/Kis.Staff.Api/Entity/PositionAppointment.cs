using System;
using Kis.Base.Entity;

namespace Kis.Staff.Api.Entity
{
    /// <summary>
    /// Назначение сотрудника на должность.
    /// </summary>
    public class PositionAppointment : EntityBase<Guid>
    {
        /// <summary>
        /// Сотрудник.
        /// </summary>
        public virtual Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public virtual Position Position { get; set; }
        public Guid PositionId { get; set; }
    }
}
