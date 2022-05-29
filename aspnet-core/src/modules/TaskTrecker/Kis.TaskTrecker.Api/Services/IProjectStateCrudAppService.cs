using System;
using Kis.Base.Services.Bl;
using Kis.Base.Services.Crud;
using Kis.TaskTrecker.Api.Dto;
using Kis.TaskTrecker.Api.Dto.ProjectState;

namespace Kis.TaskTrecker.Api.Services
{
    public interface IProjectStateCrudAppService : IAsyncCrudAppServiceBase<ProjectStateDto, Guid, PagedProjectStateResultRequestDto, ProjectStateDto, ProjectStateDto, ProjectStateDto, ProjectStateDto>
    {
    }

    
}
