using System;
using Abp.Application.Services.Dto;
using Kis.Base.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Вариант ответа в голосованании
    /// </summary>
    public class PagedVoteOptionResultRequestDto : PagedResultRequestDto
    {
        public Guid? VoteId { get; set; }
    }
}
