using System;
using Kis.Base.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Вариант ответа в голосованании
    /// </summary>
    public class VoteOptionDto : BaseDto<Guid>
    {
        public string Text { get; set; }
     
        public Guid VoteId { get; set; }
    }
}
