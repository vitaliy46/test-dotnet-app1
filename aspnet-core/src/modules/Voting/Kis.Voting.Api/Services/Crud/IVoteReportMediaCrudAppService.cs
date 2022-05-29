using System;

using Kis.Base.Services.Bl;
using Kis.Base.Services.Crud;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.VoteMember;

namespace Kis.Voting.Api.Services.Crud
{
    public interface IVoteReportMediaCrudAppService : IAsyncCrudAppServiceBase<VoteReportMediaDto, Guid, PagedVoteReportMediaResultRequestDto, VoteReportMediaDto, VoteReportMediaDto, VoteReportMediaDto, VoteReportMediaDto>
    {
    }


}
