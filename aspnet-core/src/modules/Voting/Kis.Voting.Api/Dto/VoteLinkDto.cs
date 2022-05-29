using System;
using Kis.Base.Dto;
using Kis.General.Api.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Связь между голосованием и прикрепленным медийным материалам
    /// </summary>
    public class VoteLinkDto : BaseDto<Guid>
    {
        public Guid VoteId { get; set; }

        public LinkDto Link { get; set; }
        public Guid LinkId { get; set; }

    }
}
