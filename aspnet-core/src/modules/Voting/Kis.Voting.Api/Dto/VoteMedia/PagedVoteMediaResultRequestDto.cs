using System;
using Abp.Application.Services.Dto;
using Kis.Base.Dto;

namespace Kis.Voting.Api.Dto
{
    public class PagedVoteMediaResultRequestDto : PagedResultRequestDto
    {
        public Guid? VoteId { get; set; }
    }
}
