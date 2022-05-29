using System;
using Kis.Base.Services.Crud;
using Kis.Voting.Api.Dto;

namespace Kis.Voting.Api.Services.Crud
{
    public interface IVoteMediaCrudAppService :
        IAsyncCrudAppServiceBase<VoteMediaDto, Guid,
            PagedVoteMediaResultRequestDto, VoteMediaDto,
            VoteMediaDto, VoteMediaDto, VoteMediaDto>
    {
    }


}
