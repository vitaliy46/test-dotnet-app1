using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using JetBrains.Annotations;

namespace Kis.Voting.Api.Dto.Vote
{

    public class VoteResultPagedAndSortedRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? VoteId { get; set; }
    }
}
