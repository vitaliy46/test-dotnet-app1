using Abp.Authorization;
using Abp.Localization;

namespace Kis.TaskTrecker.Authorization
{
    public class TaskTreckerAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.ProjectStateList, L("ProjectStateList"));
            context.CreatePermission(PermissionNames.ProjectStateManagement, L("ProjectStateManagement"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, KisConsts.LocalizationSourceName);
        }
    }
}
