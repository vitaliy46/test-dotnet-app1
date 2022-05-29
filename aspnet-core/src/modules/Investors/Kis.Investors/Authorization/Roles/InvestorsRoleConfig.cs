using System.Collections.Generic;
using Abp.MultiTenancy;
using Abp.Zero.Configuration;
using Kis.Voting.Api.Roles;

namespace Kis.Investors.Authorization.Roles
{
    public static class InvestorsRoleConfig
    {
        private static readonly List<StaticRoleDefinition> _investorsRoles = new List<StaticRoleDefinition>();

        public static List<StaticRoleDefinition> Configure(IRoleManagementConfig roleManagementConfig)
        {
            // Static tenant roles

            _investorsRoles.Add(
                new StaticRoleDefinition(VotingStaticRoleNames.Tenants.VoteManager, MultiTenancySides.Tenant)
                {
                    GrantedPermissions =
                    {
                        PermissionNames.InvestedProjectList,
                        PermissionNames.InvestedProjectDetails,
                        PermissionNames.InvestedProjectManagement,
                        PermissionNames.InvestorManagement,
                        PermissionNames.PartnershipManagement,
                        PermissionNames.PartnershipMemberManagement
                    }
                }
            );

            _investorsRoles.Add(
                new StaticRoleDefinition(VotingStaticRoleNames.Tenants.VoteMember, MultiTenancySides.Tenant)
                {
                    GrantedPermissions =
                    {
                        PermissionNames.InvestedProjectList,
                        PermissionNames.InvestedProjectDetails,
                        PermissionNames.InvestorForProject
                    }
                }
            );

            foreach (var role in _investorsRoles)
            {
                roleManagementConfig.StaticRoles.Add(role);
            }

            return _investorsRoles;
        }
    }
}
