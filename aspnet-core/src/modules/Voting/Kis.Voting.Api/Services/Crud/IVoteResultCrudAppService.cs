using Kis.Voting.Api.Dto;
using System;
using Kis.Base.Services.Crud;
using Kis.Voting.Api.Dto.Vote;


namespace Kis.Voting.Api.Services.Crud
{
    public interface IVoteResultCrudAppService: IAsyncCrudAppServiceBase<VoteResultDto, Guid, VoteResultPagedAndSortedRequestDto, VoteResultDto, VoteResultDto, VoteResultDto, VoteResultDto>
    {
    }
}
