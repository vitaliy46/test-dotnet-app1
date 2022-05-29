using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Hr.Api.Entity
{
    /// <summary>
    /// Состояние кандидата на вакансию, в котором он когда-то пребывал 
    /// или пребывет сейчас.
    /// </summary>
    public class CandidateState : EntityBase<Guid>
    {
        /// <summary>
        /// Кандидат которому назначено состояние.
        /// </summary>
        public virtual Candidate Candidate { get; set; }
        public Guid CandidateId { get; set; }

        /// <summary>
        /// Состояние назначенное кандидату.
        /// </summary>
        public virtual State State { get; set; }
        public Guid StateId { get; set; }

        /// <summary>
        /// Дата перевода в текущее состояние.
        /// </summary>
        public DateTime TransitionDate { get; set; }

        /// <summary>
        /// Причина, обоснование и пр. перевода в текущее состояние.
        /// </summary>
        public string Comment { get; set; }
    }
}
