using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.General.Api.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Связь между голосованием и прикрепленным медийным материалам
    /// </summary>
    public class CreateVoteMediaDto : IShouldNormalize
    {
        public Guid VoteId { get; set; }

        public CreateMediaDto Media { get; set; }


        public void Normalize()
        {}
    }
}
