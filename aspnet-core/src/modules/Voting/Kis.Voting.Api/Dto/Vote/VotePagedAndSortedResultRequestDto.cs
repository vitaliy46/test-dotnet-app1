using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using JetBrains.Annotations;

namespace Kis.Voting.Api.Dto.Vote
{

    public class VotePagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// Пользователь создавший голосование
        /// </summary>
        public long? InitiatorId { get; set; }

        /// <summary>
        /// Пользователь - участник голосования
        /// </summary>
        public long? UserId { get; set; }
    }
}
