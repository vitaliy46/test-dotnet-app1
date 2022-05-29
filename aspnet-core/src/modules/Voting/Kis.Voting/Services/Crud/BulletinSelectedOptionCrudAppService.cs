using System;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.BulletinSelectedOption;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class BulletinSelectedOptionCrudAppService : AsyncCrudAppServiceBase<BulletinSelectedOption, BulletinSelectedOptionDto, Guid>, IBulletinSelectedOptionCrudAppService
    {
        public BulletinSelectedOptionCrudAppService([NotNull]IRepository<BulletinSelectedOption, Guid> repository) : base(repository)
        {
        }
    }
    
}
