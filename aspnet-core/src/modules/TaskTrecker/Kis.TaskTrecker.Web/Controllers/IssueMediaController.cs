using System;
using Kis.Base.Web.Controller;
using Kis.TaskTrecker.Api.Dto;
using Kis.TaskTrecker.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kis.TaskTrecker.Web.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    public class IssueMediaController : KisControllerBase<IIssueMediaCrudAppService>
    {
        public IssueMediaController(IIssueMediaCrudAppService crudAppService) : base(crudAppService)
        { }
    }
}
