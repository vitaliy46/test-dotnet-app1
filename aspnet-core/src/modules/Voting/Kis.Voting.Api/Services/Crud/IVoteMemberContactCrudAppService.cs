using System;
using Kis.Base.Services.Crud;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Vote;

namespace Kis.Voting.Api.Services.Crud
{
    public interface IVoteMemberContactCrudAppService : IAsyncCrudAppServiceBase<VoteMemberContactDto, Guid, PagedVoteMemberContactResultRequestDto, VoteMemberContactDto, VoteMemberContactDto, VoteMemberContactDto, VoteMemberContactDto>
    {
    }


}
