using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using AutoMapper;
using JetBrains.Annotations;
using Kis.Base.Web.Controller;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Services;
using Kis.Investors.Api.Services.Bl;
using Kis.Investors.Authorization;
using Kis.Voting.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Investors.Web.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    public class InvestorController : KisControllerBase<IInvestorCrudAppService>
    {
        private readonly IInvestorApplicationService _investorAppService;

        public InvestorController(IInvestorCrudAppService crudAppService,
            [NotNull] IInvestorApplicationService investorAppService) : base(crudAppService)
        {
            _investorAppService = investorAppService ?? throw new ArgumentNullException(nameof(investorAppService));
        }
        /// <summary>
        /// Формируется список инвесторов для проекта, чтобы отобразить его в форме при детальном 
        /// просмотре проекта
        /// </summary>
        /// <param name="id"> иденитфикатор проекта</param>
        /// <returns></returns>
        [AbpAuthorize(PermissionNames.InvestorManagement, PermissionNames.InvestorForProject)]
        [HttpGet("/GetForProject/{id}")]
        public async Task<IList<InvestorForProjectDto>> GetForProject([FromRoute]Guid id)
        {
            var dto = await _investorAppService.GetByProjectId(id);

            return dto.Select(x=>x.MapTo<InvestorForProjectDto>()).ToList();
        }

        /// <summary>
        /// Возвращает список проектов, в которых член товаришества принимает участие
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [AbpAuthorize(PermissionNames.InvestorManagement)]
        [HttpGet("/GetProjects/{memberId}")]
        public async Task<IList<InvestorsProjectDto>> GetProjects([FromRoute]Guid memberId)
        {
            // TODO: Id участника должен браться из сессии текущего пользователя
            return await _investorAppService.GetProjects(memberId);
        }

        [AbpAuthorize(PermissionNames.InvestorManagement)]
        [HttpPut("{id}")]
        public async Task<InvestorForProjectDto> Put([FromRoute]Guid id, [FromBody]UpdateInvestorDto value)
        {
            var existDto = await CrudService.Get(id);

            if (existDto != null && existDto.Id == id)
            {
                var dto = ObjectMapper.Map(value, existDto);

                dto = await CrudService.Update(dto);

                return dto.MapTo<InvestorForProjectDto>();
            }

            return null;

        }

        [AbpAuthorize(PermissionNames.InvestorManagement)]
        [HttpPost]
        public virtual async Task<InvestorForProjectDto> Post([FromBody] CreateInvestorDto value)
        {
            var dto = ObjectMapper.Map<InvestorDto>(value);

            dto = await CrudService.Create(dto);

            return dto.MapTo<InvestorForProjectDto>();
        }

        [AbpAuthorize(PermissionNames.InvestorManagement)]
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            await CrudService.Delete(id);

            return new OkResult();
        }

    }
}
