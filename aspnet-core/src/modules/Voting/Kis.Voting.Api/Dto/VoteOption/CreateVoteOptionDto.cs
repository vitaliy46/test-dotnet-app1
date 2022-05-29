using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Вариант ответа в голосованании
    /// </summary>
    public class CreateVoteOptionDto : IShouldNormalize
    {
        public string Text { get; set; }

        public void Normalize()
        {
        }
    }
}
