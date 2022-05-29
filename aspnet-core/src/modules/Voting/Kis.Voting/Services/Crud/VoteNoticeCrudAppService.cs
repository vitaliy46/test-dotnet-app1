using System;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class VoteNoticeCrudAppService : AsyncCrudAppServiceBase<VoteNotice, VoteNoticeDto, Guid>, IVoteNoticeCrudAppService
    {
        public VoteNoticeCrudAppService([NotNull]IRepository<VoteNotice, Guid> repository) : base(repository)
        {
        }
    }
    
}
