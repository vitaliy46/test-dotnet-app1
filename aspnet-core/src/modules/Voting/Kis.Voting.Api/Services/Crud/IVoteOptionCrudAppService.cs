using System;
using Kis.Base.Services.Crud;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Vote;

namespace Kis.Voting.Api.Services.Crud
{
    public interface IVoteOptionCrudAppService : IAsyncCrudAppServiceBase<VoteOptionDto, Guid, PagedVoteOptionResultRequestDto, VoteOptionDto, VoteOptionDto, VoteOptionDto, VoteOptionDto>
    {
    }


}
