using System;
using Abp.Domain.Repositories;
using Kis.Base.Services.Bl;
using Kis.Hr.Api.Dto;
using Kis.Hr.Api.Entity;
using Kis.Hr.Api.Services;

namespace Kis.Hr.Services.Crud
{
    public class InformationSourceAsyncCrudAppService : AsyncCrudAppServiceBase<InfomationSource, InformationSourceDto, Guid>, IInformationSourceAsyncCrudAppService
    {
        public InformationSourceAsyncCrudAppService(IRepository<InfomationSource, Guid> repository) : base(repository)
        {}
    }

   
}
