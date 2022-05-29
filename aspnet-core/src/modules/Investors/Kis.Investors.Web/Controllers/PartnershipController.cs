using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using AutoMapper;
using Kis.Base.Web.Controller;
using Kis.General.Api.Dto.Comment;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Services;
using Kis.Investors.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Investors.Web.Controllers
{
    [AbpAuthorize(PermissionNames.PartnershipManagement)]
    [Route("api/[controller]")]
    public class PartnershipController : KisControllerBase<IPartnershipCrudAppService>
    {
        public PartnershipController(IPartnershipCrudAppService crudAppService) : base(crudAppService)
        {
        }
        
        [HttpGet]
        public async Task<PlanePartnershipDto> Get()
        {
            PartnershipDto dto = new PartnershipDto();

            Guid id = Guid.Empty;

            Guid.TryParse(await SettingManager.GetSettingValueAsync("PartnershipId"), out id);

            if (id != Guid.Empty)
            {
                dto = await CrudService.Get(id);
            }

            return dto.MapTo<PlanePartnershipDto>();
        }

        [HttpPut("{id}")]
        public async Task<PlanePartnershipDto> Put([FromRoute]Guid id, [FromBody]PlanePartnershipDto value)
        {
            var existDto = await CrudService.Get(id);

            if (existDto != null && existDto.Id == id)
            {
                var dto = ObjectMapper.Map(value, existDto);

                dto = await CrudService.Update(dto);

                return dto.MapTo<PlanePartnershipDto>();
            }

            return null;

        }
        [HttpPost]
        public virtual async Task<PlanePartnershipDto> Post([FromBody] CreatePartnershipDto value)
        {
            var dto = ObjectMapper.Map<PlanePartnershipDto>(value).MapTo<PartnershipDto>();

            dto = await CrudService.Create(dto);

            return dto.MapTo<PlanePartnershipDto>();
        }

    }
}
