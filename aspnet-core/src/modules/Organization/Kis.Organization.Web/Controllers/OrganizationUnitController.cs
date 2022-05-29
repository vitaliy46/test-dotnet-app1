using System;
using System.Threading.Tasks;
using Kis.Base.Web.Controller;
using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Organization.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationUnitController : KisControllerBase<IOrganizationUnitCrudAppService>
    {
        public OrganizationUnitController(IOrganizationUnitCrudAppService crudAppService) : base(crudAppService)
        {
           
        }

        //[HttpPut("{id}")]
        //public async Task<OrganizationUnitDto> Put([FromRoute]Guid id, [FromBody] UpdateOrganizationUnitDto value)
        //{
        //    var existDto = await CrudService.Get(id);

        //    if (existDto != null && existDto.Id == id)
        //    {
        //        var dto = ObjectMapper.Map<OrganizationUnitDto>(value);

        //        dto = await CrudService.Update(dto);

        //        return dto;
        //    }

        //    return null;
        //}
    }
}
