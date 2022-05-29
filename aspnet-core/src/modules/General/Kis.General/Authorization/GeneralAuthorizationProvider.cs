using Abp.Authorization;
using Abp.Localization;

namespace Kis.General.Authorization
{
    public class GeneralAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.StateManagement, L("StateManagement"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, KisConsts.LocalizationSourceName);
        }
    }
}
