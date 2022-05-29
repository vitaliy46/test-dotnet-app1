using System;
using Abp.Application.Services.Dto;

namespace Kis.Voting.Api.Dto.Bulletin
{

    public class PagedBulletinResultRequestDto : PagedResultRequestDto
    {
        public long? UserId;

        public Guid? VoteMemberId { get; set; }

        public Guid? VoteId;
    }
}
