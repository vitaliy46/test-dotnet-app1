using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Kis.Base.Web.Controller;
using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Organization.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationUnitMediaController : KisControllerBase<IOrganizationUnitMediaCrudAppService>
    {

        public OrganizationUnitMediaController(IOrganizationUnitMediaCrudAppService crudAppService) : base(crudAppService)
        {
        }

        [HttpGet("MediaByLabel")]
        public async Task<OrganizationUnitMediaDto> Get(Guid organizationId, string label)
        {
            //TODO в последствии можно передавать запрос на application service

            var filter = new PagedOrganizationUnitMediaResultRequestDto
            {
                Label = label,
                OrganizationId = organizationId
            };

            var dto = (await CrudService.GetAll(filter)).Items.FirstOrDefault();

            return dto;
        }

        [HttpPost]
        public async Task<OrganizationUnitMediaDto> Post([FromBody] CreateOrganizationUnitMediaDto input)
        {
            var dto = await CrudService.Create(input.MapTo<OrganizationUnitMediaDto>());

            return dto;
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            await CrudService.Delete(id);

            return new OkResult();
        }
    }
}
