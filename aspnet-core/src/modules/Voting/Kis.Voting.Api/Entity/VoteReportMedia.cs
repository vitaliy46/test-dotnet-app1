using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Материалы для отчета по голосованию
    /// </summary>
    public class VoteReportMedia : EntityBase<Guid>
    {
        public virtual VoteReport VoteReport { get; set; }
        public Guid VoteReportId { get; set; }
        
        /// <summary>
        /// Любые медийные материалы для отчета. Это могут быть графики для наглядности.
        /// </summary>
        public Media Media { get; set; }
        public Guid MediaId { get; set; }
    }
}
