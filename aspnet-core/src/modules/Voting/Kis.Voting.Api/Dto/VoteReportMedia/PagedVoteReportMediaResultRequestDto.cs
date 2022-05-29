using System;
using Abp.Application.Services.Dto;

namespace Kis.Voting.Api.Dto.VoteMember
{

    public class PagedVoteReportMediaResultRequestDto : PagedResultRequestDto
    {
        public Guid? VoteReportId { get; set; }
    }
}
