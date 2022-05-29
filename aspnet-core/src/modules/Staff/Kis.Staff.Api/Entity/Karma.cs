using System;
using System.Collections.Generic;
using Kis.Base.Entity;

namespace Kis.Staff.Api.Entity
{
    /// <summary>
    /// Действие, какого либо типа, которое привело к создание кармического атома, 
    /// влияющего на суммарную карму сотрудника.
    /// </summary>
    public class Karma: EntityBase<Guid>
    {
        /// <summary>
        /// Сотрудник, которому начисляется карма.
        /// </summary>
        public virtual Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Тип кармы определяющий величину, котрая будет добавлена/вычтена из общей кармы.
        /// </summary>
        public virtual KarmaType KarmaType { get; set; }
        public Guid KarmaTypeId { get; set; }

        /// <summary>
        /// Сотрудник, который добавил карму.
        /// </summary>
        public virtual Employee CreatedBy { get; set; }
        public Guid CreatedById { get; set; }

        /// <summary>
        /// Список голосов отданных сотрудниками за карму для др. сотрудника.
        /// </summary>
        public virtual IList<KarmaVote> KarmaVotes { get; set; }
    }
}
