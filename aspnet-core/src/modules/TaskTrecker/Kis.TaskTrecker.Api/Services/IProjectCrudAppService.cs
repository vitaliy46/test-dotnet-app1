using System;
using Kis.Base.Services.Bl;
using Kis.Base.Services.Crud;
using Kis.TaskTrecker.Api.Dto;
using Kis.TaskTrecker.Api.Dto.Project;

namespace Kis.TaskTrecker.Api.Services
{
    public interface IProjectCrudAppService : IAsyncCrudAppServiceBase<ProjectDto, Guid, PagedProjectResultRequestDto, ProjectDto, ProjectDto, ProjectDto, ProjectDto>
    {
    }

    
}
