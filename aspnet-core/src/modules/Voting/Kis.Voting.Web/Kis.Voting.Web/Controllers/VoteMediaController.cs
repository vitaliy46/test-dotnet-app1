using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Kis.Base.Web.Controller;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Vote;
using Kis.Voting.Api.Services.Crud;
using Kis.Voting.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Voting.Web.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    public class VoteMediaController : KisControllerBase<IVoteMediaCrudAppService>
    {
        public VoteMediaController(IVoteMediaCrudAppService crudAppService) : base(crudAppService)
        { }

        [AbpAuthorize(PermissionNames.VoteMediaGet)]
        [HttpGet("/GetByVoteId/{voteId}")]
        public async Task<IList<VoteMediaDto>> GetByVoteId([FromRoute]Guid voteId)
        {
           var result = await CrudService.GetAll(new PagedVoteMediaResultRequestDto{VoteId = voteId});

           return result.Items.ToList();
        }

        [AbpAuthorize(PermissionNames.VoteMediaManagement)]
        [HttpPost]
        public async Task<VoteMediaDto> Post([FromBody]CreateVoteMediaDto value)
        {
            var dto = await CrudService.Create(value.MapTo<VoteMediaDto>());

            return dto;
        }

        [AbpAuthorize(PermissionNames.VoteMediaManagement)]
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await CrudService.Delete(id);
        }
    }
}
