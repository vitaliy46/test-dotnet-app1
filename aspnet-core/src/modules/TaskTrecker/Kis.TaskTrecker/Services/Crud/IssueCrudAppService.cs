using System;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.TaskTrecker.Api.Dto;
using Kis.TaskTrecker.Api.Entity;
using Kis.TaskTrecker.Api.Services;

namespace Kis.TaskTrecker.Services.Crud
{
    public class IssueCrudAppService : AsyncCrudAppServiceBase<Issue, IssueDto, Guid>, IIssueCrudAppService
    {
        public IssueCrudAppService([NotNull]IRepository<Issue, Guid> repository) : base(repository)
        {
        }
    }
    
}
