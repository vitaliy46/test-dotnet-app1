using System;
using System.Threading.Tasks;
using Kis.Base.Web.Controller;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Services;
using Microsoft.AspNetCore.Mvc;


namespace Kis.Investors.Web.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    public class MemberContactorController : KisControllerBase<IMemberContactorCrudAppService>
    {
        public MemberContactorController(IMemberContactorCrudAppService crudAppService) : base(crudAppService)
        {}

        [HttpGet("{id}")]
        public async Task<MemberContactorDto> Get([FromRoute]Guid id)
        {
            var dto = await CrudService.Get(id);

            return dto;
        }

    }
}
