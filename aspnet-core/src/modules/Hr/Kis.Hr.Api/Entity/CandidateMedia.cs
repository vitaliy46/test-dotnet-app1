using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Hr.Api.Entity
{
    /// <summary>
    /// Файлы любого содержания, прикрепленные к кандидату.
    /// </summary>
    public class CandidateMedia : EntityBase<Guid>
    {
        /// <summary>
        /// Медиа информация.
        /// </summary>
        public Media Media { get; set; }
        public Guid MediaId { get; set; }

        /// <summary>
        /// Кандидат на рабочее место.
        /// </summary>
        public virtual Candidate Candidate { get; set; }
        public Guid CandidateId { get; set; }
    }
}
