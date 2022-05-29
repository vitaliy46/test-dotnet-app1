using System;
using JetBrains.Annotations;
using Kis.Base.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Вариант ответа в голосованании
    /// </summary>
    public class UpdateVoteOptionDto : BaseDto<Guid>
    {
        public string Text { get; set; }
    }
}
