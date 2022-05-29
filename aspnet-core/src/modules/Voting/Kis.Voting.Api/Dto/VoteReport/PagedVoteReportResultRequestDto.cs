using System;
using Abp.Application.Services.Dto;

namespace Kis.Voting.Api.Dto.VoteMember
{

    public class PagedVoteReportResultRequestDto : PagedResultRequestDto
    {
        public Guid? VoteId { get; set; }
    }
}
