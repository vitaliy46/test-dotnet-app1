using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using AutoMapper;
using JetBrains.Annotations;
using Kis.Base.Web.Controller;
using Kis.Controllers;
using Kis.General.Api.Dto;
using Kis.General.Api.Services.Crud;
using Kis.General.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Kis.General.Web.Controllers
{
    [AbpAuthorize(PermissionNames.StateManagement)]
    [Route("api/[controller]")]
    public class StateController : KisControllerBase<IStateCrudAppService>
    {

        public StateController([NotNull] IStateCrudAppService crudService) : base (crudService)
        {}

        [HttpGet]
        public async Task<PagedResultDto<StateDto>> Get()
        {
            var result = await CrudService.GetAll(new PagedStateResultRequestDto());
            var pageResultDto = new PagedResultDto<StateDto>()
            {
                TotalCount = result.TotalCount,
                Items = result.Items.ToList().Select(x => Mapper.Map<StateDto>(x)).ToList()
            };

            return pageResultDto;
        }

        [HttpPut("{id}")]
        public async Task<StateDto> Put([FromRoute]Guid id, [FromBody] UpdateStateDto value)
        {
            var existDto = await CrudService.Get(id);

            if (existDto != null)
            {
                existDto = ObjectMapper.Map(value, existDto);

                existDto = await CrudService.Update(existDto);

                return existDto;
            }

            return null;
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            await CrudService.Delete(new StateDto(){Id = id});

            return new OkResult();
        }
    }
}
