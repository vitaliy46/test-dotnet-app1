using System;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Hr.Api.Dto;
using Kis.Hr.Api.Entity;
using Kis.Hr.Api.Services;

namespace Kis.Hr.Services.Crud
{
    public class VacancyAsyncCrudAppService : AsyncCrudAppServiceBase<Vacancy, VacancyDto, Guid>, IVacancyAsyncCrudAppService
    {
        public VacancyAsyncCrudAppService([NotNull] IRepository<Vacancy, Guid> repository) : base(repository) {}
    }
    
}
