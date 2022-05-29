using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Hr.Api.Entity
{
    /// <summary>
    /// Ссылка на внешний интернет ресурс, прикрепленная к кандидату.
    /// </summary>
    public class CandidateLink : EntityBase<Guid>
    {
        /// <summary>
        /// Ссылка на интернет ресурс.
        /// </summary>
        public Link Link { get; set; }
        public Guid LinkId { get; set; }

        /// <summary>
        /// Кандидат на рабочее место.
        /// </summary>
        public virtual Candidate Candidate { get; set; }
        public Guid CandidateId { get; set; }
    }
}
