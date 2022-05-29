using System;
using Kis.Base.Web.Controller;
using Kis.General.Api.Dto;
using Kis.General.Api.Services.Crud;
using Microsoft.AspNetCore.Mvc;


namespace Kis.General.Web.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    public class MediaTypeController : KisControllerBase<IMediaTypeCrudAppService>
    {
        public MediaTypeController(IMediaTypeCrudAppService crudAppService) : base(crudAppService)
        { }
    }
}
