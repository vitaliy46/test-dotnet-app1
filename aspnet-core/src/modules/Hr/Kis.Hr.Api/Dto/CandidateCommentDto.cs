using System;
using Abp.AutoMapper;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.Hr.Api.Entity;

namespace Kis.Hr.Api.Dto
{
    /// <summary>
    /// Представляет коментарий о кандидате.
    /// </summary>
    [AutoMapTo(typeof(CandidateComment))]
    public class CandidateCommentDto : BaseDto<Guid>
    {
        /// <summary>
        /// Коментарий.
        /// </summary>
        public CommentDto Comment { get; set; }

        /// <summary>
        /// Кандидат, о котором написан комментарий.
        /// </summary>
        public CandidateDto Candidate { get; set; }
        
    }
}
