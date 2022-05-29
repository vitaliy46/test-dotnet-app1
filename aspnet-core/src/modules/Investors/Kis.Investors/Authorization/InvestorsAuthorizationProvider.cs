using Abp.Authorization;
using Abp.Localization;


namespace Kis.Investors.Authorization
{
    public class InvestorsAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.InvestedProjectList, L("InvestedProjectList"));
            context.CreatePermission(PermissionNames.InvestedProjectDetails, L("InvestedProjectDetails"));
            context.CreatePermission(PermissionNames.InvestedProjectManagement, L("InvestedProjectManagement"));

            context.CreatePermission(PermissionNames.InvestorManagement, L("InvestorManagement"));
            context.CreatePermission(PermissionNames.InvestorForProject, L("InvestorForProject"));

            context.CreatePermission(PermissionNames.PartnershipManagement, L("PartnershipManagement"));

            context.CreatePermission(PermissionNames.PartnershipMemberManagement, L("PartnershipMemberManagement"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, KisConsts.LocalizationSourceName);
        }
    }
}
