using System;
using Kis.Base.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Вариант ответа в голосованании
    /// </summary>
    public class GetVoteOptionDto : BaseDto<Guid>
    {
        public string Text { get; set; }
    }
}
