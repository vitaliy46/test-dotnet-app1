using System;
using Kis.Base.Web.Controller;
using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kis.Organization.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationUnitAddressController : KisControllerBase<IOrganizationUnitAddressCrudAppService>
    {
        public OrganizationUnitAddressController(IOrganizationUnitAddressCrudAppService crudAppService) : base(crudAppService)
        {
        }
    }
}
