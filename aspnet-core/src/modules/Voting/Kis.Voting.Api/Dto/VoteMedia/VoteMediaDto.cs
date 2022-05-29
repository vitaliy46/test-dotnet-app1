using System;
using Kis.Base.Dto;
using Kis.General.Api.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Связь между голосованием и прикрепленным медийным материалам
    /// </summary>
    public class VoteMediaDto : BaseDto<Guid>
    {
        public Guid VoteId { get; set; }

        public MediaDto Media { get; set; }
        public Guid MediaId { get; set; }

    }
}
