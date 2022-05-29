using System;
using Kis.Base.Web.Controller;
using Kis.Organization.Api.Entity;
using Kis.Organization.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Organization.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationUnitContactController : KisControllerBase<IOrganizationUnitContactCrudAppService>
    {
        public OrganizationUnitContactController(IOrganizationUnitContactCrudAppService crudAppService) : base(crudAppService)
        {
        }
    }
}
