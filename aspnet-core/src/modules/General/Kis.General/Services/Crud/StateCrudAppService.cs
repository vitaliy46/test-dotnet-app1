using System;
using System.Linq;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.General.Api.Entity;
using Kis.General.Api.Services.Crud;

namespace Kis.General.Services.Crud
{
    public class StateCrudAppService : AsyncCrudAppServiceBase<State, StateDto, Guid, PagedStateResultRequestDto, StateDto, StateDto, StateDto, StateDto>, IStateCrudAppService
    {
        public StateCrudAppService([NotNull]IRepository<State, Guid> repository) : base(repository)
        {
        }

        protected override IQueryable<State> ApplySorting(IQueryable<State> query, PagedStateResultRequestDto input)
        {
            return base.ApplySorting(query, input).OrderBy(x=> x.Name);
        }
    }
    
}
