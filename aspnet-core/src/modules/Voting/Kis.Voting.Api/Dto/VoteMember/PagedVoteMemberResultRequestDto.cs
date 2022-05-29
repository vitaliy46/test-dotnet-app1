using System;
using Abp.Application.Services.Dto;

namespace Kis.Voting.Api.Dto.VoteMember
{

    public class PagedVoteMemberResultRequestDto : PagedResultRequestDto
    {
        public Guid? VoteId { get; set; }
        public long? UserId { get; set; }
    }
}
