using System;
using Kis.Base.Services.Bl;
using Kis.Base.Services.Crud;
using Kis.TaskTrecker.Api.Dto;

namespace Kis.TaskTrecker.Api.Services
{
    public interface IIssueCrudAppService : IAsyncCrudAppService<IssueDto, Guid>
    {
    }

    
}
