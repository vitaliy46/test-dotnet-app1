using System;
using System.Collections.Generic;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Services
{
    [Serializable]
    public class SignedVoteResult : SortedDictionary<uint, VoteOptionDto>
    {
    }
}