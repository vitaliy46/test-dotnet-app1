using System;
using Kis.Base.Services.Crud;
using Kis.TaskTrecker.Api.Dto;

namespace Kis.TaskTrecker.Api.Services
{
    public interface IIssueStateCrudAppService : IAsyncCrudAppService<IssueStateDto, Guid>
    {
    }

    
}
