using System;
using Kis.Base.Entity;

namespace Kis.Staff.Api.Entity
{
    /// <summary>
    /// Голос сотрудника, отданный за карму другого сотрудника.
    /// </summary>
    public class KarmaVote : EntityBase<Guid>
    {
        /// <summary>
        /// Сотрудник, проголосовавший за карму какого либо сотрудника.
        /// Сотрудник не может голосовать за свою карму.
        /// </summary>
        public virtual Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Карма, за которую голосует какой либо сотрудник.
        /// </summary>
        public virtual Karma Karma { get; set; }
        public Guid KarmaId { get; set; }
    }
}
