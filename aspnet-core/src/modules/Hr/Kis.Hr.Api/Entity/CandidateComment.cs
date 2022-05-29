using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Hr.Api.Entity
{
    /// <summary>
    /// Комментарий о кандидате.
    /// </summary>
    public class CandidateComment : EntityBase<Guid>
    {
        /// <summary>
        /// Коментарий о кандидате.
        /// </summary>
        public Comment Comment { get; set; }
        public Guid CommentId { get; set; }

        /// <summary>
        /// Кандидат, о котором создан коментарий.
        /// </summary>
        public virtual Candidate Candidate { get; set; }
        public Guid CandidateId { get; set; }
    }
}
