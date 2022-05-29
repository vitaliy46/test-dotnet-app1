using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Kis.Controllers
{
    public abstract class KisControllerBase: AbpController
    {
        protected KisControllerBase()
        {
            LocalizationSourceName = KisConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
