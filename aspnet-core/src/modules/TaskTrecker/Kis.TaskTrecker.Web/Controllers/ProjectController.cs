using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AutoMapper;
using JetBrains.Annotations;
using Kis.Base.Web.Controller;
using Kis.Controllers;
using Kis.TaskTrecker.Api.Dto;
using Kis.TaskTrecker.Api.Dto.Project;
using Kis.TaskTrecker.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kis.TaskTrecker.Web.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    public class ProjectController : KisControllerBase<IProjectCrudAppService>
    {
        public ProjectController([NotNull] IProjectCrudAppService crudService) : base(crudService)
        {}

        //[HttpGet]
        //public  async Task<PagedResultDto<ProjectShortDto>> Get()
        //{
        //    var result = await CrudService.GetAll(new PagedProjectResultRequestDto());
        //    var pageResultDto = new PagedResultDto<ProjectShortDto>()
        //    {
        //        TotalCount = result.TotalCount,
        //        Items = result.Items.ToList().Select(x=> Mapper.Map<ProjectShortDto>(x)).ToList()
        //    };

        //    return pageResultDto;
        //}

        //[HttpGet("{id}")]
        //public async  Task<ProjectDto> Get([FromRoute]Guid id)
        //{
        //    var dto = await CrudService.Get(id);

        //    return dto;
        //}

        //[HttpPut("{id}")]
        //public async Task<ProjectDto> Put([FromRoute]Guid id, [FromBody]UpdateProjectDto value)
        //{
        //    var dto = ObjectMapper.Map<ProjectDto>(value);

        //    dto = await CrudService.Update(dto);

        //    return dto;
        //}

        //[HttpPost]
        //public virtual async Task<ProjectDto> Post([FromBody] CreateProjectDto value)
        //{
        //    var dto = ObjectMapper.Map<ProjectDto>(value);

        //    dto = await CrudService.Create(dto);

        //    return dto;
        //}

        //[HttpDelete("{id}")]
        //public virtual async Task<ActionResult> Delete([FromRoute]Guid id)
        //{
        //    await CrudService.Delete(id);

        //    return new OkResult();
        //}
    }
}
