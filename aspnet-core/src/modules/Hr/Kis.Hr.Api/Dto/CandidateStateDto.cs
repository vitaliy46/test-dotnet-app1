using System;
using Kis.Base.Dto;
using Kis.General.Api.Dto;

namespace Kis.Hr.Api.Dto
{
    /// <summary>
    /// Состояние кандидата на вакансию.
    /// </summary>
    public class CandidateStateDto : BaseDto<Guid>
    {
        /// <summary>
        /// Кандидат.
        /// </summary>
        public CandidateDto Candidate { get; set; }

        /// <summary>
        /// Состояние кандидата.
        /// </summary>
        public StateDto State { get; set; }

        /// <summary>
        /// Дата перевода в текущее состояние.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Причина, обоснование и пр. перевода в состояние.
        /// </summary>
        public string Comment { get; set; }
    }
}
