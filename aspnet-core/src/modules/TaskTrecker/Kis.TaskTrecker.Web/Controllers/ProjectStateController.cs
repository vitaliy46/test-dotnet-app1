using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using AutoMapper;
using JetBrains.Annotations;
using Kis.Base.Web.Controller;
using Kis.Controllers;
using Kis.TaskTrecker.Api.Dto;
using Kis.TaskTrecker.Api.Dto.ProjectState;
using Kis.TaskTrecker.Api.Services;
using Kis.TaskTrecker.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kis.TaskTrecker.Web.Controllers
{
    [AbpAuthorize()]
    [Route("api/[controller]")]
    public class ProjectStateController : KisControllerBase<IProjectStateCrudAppService>
    {
        public ProjectStateController([NotNull] IProjectStateCrudAppService crudService) : base(crudService)
        {
        }

        [AbpAuthorize(PermissionNames.ProjectStateList)]
        [HttpGet]
        public async Task<PagedResultDto<ProjectStateShortDto>> Get()
        {
            var result = await CrudService.GetAll(new PagedProjectStateResultRequestDto());
            var pageResultDto = new PagedResultDto<ProjectStateShortDto>()
            {
                TotalCount = result.TotalCount,
                Items = result.Items.ToList().Select(x => Mapper.Map<ProjectStateShortDto>(x)).ToList()
            };

            return pageResultDto;
        }

        [AbpAuthorize(PermissionNames.ProjectStateManagement)]
        [HttpGet("{id}")]
        public async Task<ProjectStateDto> Get([FromRoute]Guid id)
        {
            var dto = await CrudService.Get(id);

            return dto;
        }

        [AbpAuthorize(PermissionNames.ProjectStateManagement)]
        [HttpPut("{id}")]
        public async Task<ProjectStateDto> Put([FromRoute]Guid id, [FromBody] ProjectStateDto value)
        {
            var dto = await CrudService.Update(value);

            return dto;
        }

        [AbpAuthorize(PermissionNames.ProjectStateManagement)]
        [HttpPost]
        public virtual async Task<ProjectStateDto> Post([FromBody] CreateProjectStateDto value)
        {
            var dto = ObjectMapper.Map<ProjectStateDto>(value);

            dto = await CrudService.Create(dto);

            return dto;
        }

        [AbpAuthorize(PermissionNames.ProjectStateManagement)]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            await CrudService.Delete(id);

            return new OkResult();
        }
    }
}
