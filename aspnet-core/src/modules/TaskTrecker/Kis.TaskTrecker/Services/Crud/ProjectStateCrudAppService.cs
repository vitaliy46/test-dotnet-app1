using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.General.Api.Services.Crud;
using Kis.TaskTrecker.Api.Dto;
using Kis.TaskTrecker.Api.Dto.ProjectState;
using Kis.TaskTrecker.Api.Entity;
using Kis.TaskTrecker.Api.Services;

namespace Kis.TaskTrecker.Services.Crud
{
    public class ProjectStateCrudAppService : AsyncCrudAppServiceBase<ProjectState, ProjectStateDto,
        Guid, PagedProjectStateResultRequestDto, ProjectStateDto, ProjectStateDto, ProjectStateDto,
        ProjectStateDto>, IProjectStateCrudAppService
    {
        private readonly IStateCrudAppService _stateCrudService;

        public ProjectStateCrudAppService(
            [NotNull]IRepository<ProjectState, Guid> repository,
            IStateCrudAppService stateCrudService) : base(repository)
        {
            _stateCrudService = stateCrudService;
        }

        public override async Task<ProjectStateDto> Get(ProjectStateDto input)
        {
            var dto = await base.Get(input);

            dto.State = await _stateCrudService.Get(dto.StateId);

            return dto;
        }

        public override async Task<ProjectStateDto> Get(Guid id)
        {

            return await this.Get(new ProjectStateDto() { Id = id });
        }

        public override async Task<PagedResultDto<ProjectStateDto>> GetAll(PagedProjectStateResultRequestDto input)
        {
            var result = await base.GetAll(input);

            var list = new List<ProjectStateDto>();

            foreach (var item in result.Items)
            {
                item.State = await _stateCrudService.Get(item.StateId);

                list.Add(item);
            }

            result.Items = list;

            return result;
        }

        public override async Task<ProjectStateDto> Create(ProjectStateDto input)
        {
            var state = await _stateCrudService.Create(input.State);

            input.StateId = state.Id;

            var dto =  await base.Create(input);

            dto.State = state;

            return dto;
        }

        public override async Task<ProjectStateDto> Update(ProjectStateDto input)
        {
            var projectStateDto = await base.Update(input);
            projectStateDto.State = await _stateCrudService.Update(input.State);

            return projectStateDto;
        }

       public override async Task Delete(ProjectStateDto input)
        {
            await base.Delete(input.Id);

            await _stateCrudService.Delete(input.State.Id);
        }

        public override async Task Delete(Guid id)
        {
            var dto = await base.Get(id);

            if (dto == null)
            {
                throw new Exception("Попытка удалить несуществующую запись");
            }
            await base.Delete(id);

            await _stateCrudService.Delete(dto.StateId);
        }

        protected override IQueryable<ProjectState> ApplySorting(IQueryable<ProjectState> query, PagedProjectStateResultRequestDto input)
        {
            return base.ApplySorting(query, input).OrderBy(x=> x.Order);
        }
    }
    
}
