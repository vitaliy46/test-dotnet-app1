using System;
using Abp.Authorization;
using Kis.Base.Web.Controller;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Services.Crud;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Voting.Web.Controllers
{
    [AbpAuthorize()]
    [Route("api/[controller]")]
    public class VoteReportMediaController : KisControllerBase<IVoteReportMediaCrudAppService>
    {
        public VoteReportMediaController(IVoteReportMediaCrudAppService crudAppService) : base(crudAppService)
        { }
    }
}
