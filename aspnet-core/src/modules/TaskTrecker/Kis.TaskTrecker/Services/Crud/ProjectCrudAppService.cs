using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Services.Crud;
using Kis.TaskTrecker.Api.Dto;
using Kis.TaskTrecker.Api.Dto.Project;
using Kis.TaskTrecker.Api.Entity;
using Kis.TaskTrecker.Api.Services;

namespace Kis.TaskTrecker.Services.Crud
{
    public class ProjectCrudAppService : AsyncCrudAppServiceBase<Project, ProjectDto, 
        Guid, PagedProjectResultRequestDto, ProjectDto, ProjectDto, ProjectDto,
        ProjectDto>, IProjectCrudAppService
    {
        private readonly IProjectStateCrudAppService _projectStateCrudService;
        private readonly IStateCrudAppService _stateCrudService;
         

        public ProjectCrudAppService(
            [NotNull]IRepository<Project, Guid> repository,
            IProjectStateCrudAppService projectStateCrudService, [NotNull] IStateCrudAppService stateCrudService) : base(repository)
        {
            _stateCrudService = stateCrudService ?? throw new ArgumentNullException(nameof(stateCrudService));
            _projectStateCrudService = projectStateCrudService ?? throw new ArgumentNullException(nameof(projectStateCrudService));
        }

       public override async Task<ProjectDto> Get(Guid id)
        {
            var dto =  await this.Get(new ProjectDto { Id = id });

            dto.ProjectState.State = await _stateCrudService.Get(dto.ProjectState.StateId);

            return dto;
        }

        public override async Task<PagedResultDto<ProjectDto>> GetAll(PagedProjectResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<ProjectDto>();

            foreach (var item in result.Items)
            {
               // item.ProjectState = await _projectStateCrudService.Get(item.ProjectStateId);

                list.Add(item);
            }

            result.Items = list;

            return result;
        }
    
        public override async Task<ProjectDto> Update(ProjectDto input)
        {
            var dto = await base.Update(input);

            dto.ProjectState = await _projectStateCrudService.Get(dto.ProjectStateId);

            return dto;
        }

        public override async Task<ProjectDto> Create(ProjectDto input)
        {
            var dto =  await base.Create(input);

            dto.ProjectState = await _projectStateCrudService.Get(dto.ProjectStateId);

            return dto;
        }
    }

}
