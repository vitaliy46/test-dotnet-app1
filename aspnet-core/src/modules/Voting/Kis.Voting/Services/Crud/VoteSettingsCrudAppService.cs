using System;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class VoteSettingsCrudAppService : AsyncCrudAppServiceBase<VoteSettings, VoteSettingsDto, Guid>, IVoteSettingsCrudAppService
    {
        public VoteSettingsCrudAppService([NotNull]IRepository<VoteSettings, Guid> repository) : base(repository)
        {
        }
    }
    
}
