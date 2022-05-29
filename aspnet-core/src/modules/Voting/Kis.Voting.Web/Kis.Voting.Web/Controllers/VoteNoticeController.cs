using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Kis.Base.Web.Controller;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Services.Crud;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Voting.Web.Controllers
{
    [AbpAuthorize()]
    [Route("api/[controller]")]
    public class VoteNoticeController : KisControllerBase<IVoteNoticeCrudAppService>
    {
        public VoteNoticeController(IVoteNoticeCrudAppService crudAppService) : base(crudAppService)
        { }

        
    }
}
