using System;
using Kis.Base.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Уведомление участников о проведении голосованания
    /// </summary>
    public class VoteNoticeDto : BaseDto<Guid>
    {
        /// <summary>
        /// Текстовое сообщение уведомления
        /// </summary>
        public string Message { get; set; }

        public Guid VoteId { get; set; }
    }
}
