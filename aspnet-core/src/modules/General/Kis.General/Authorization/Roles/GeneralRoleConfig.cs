using System.Collections.Generic;
using Abp.MultiTenancy;
using Abp.Zero.Configuration;
using Kis.Voting.Api.Roles;

namespace Kis.General.Authorization.Roles
{
    public static class GeneralRoleConfig
    {
        private static readonly List<StaticRoleDefinition> _generalRoles = new List<StaticRoleDefinition>();

        public static List<StaticRoleDefinition> Configure(IRoleManagementConfig roleManagementConfig)
        {
            // Static tenant roles

            _generalRoles.Add(
                new StaticRoleDefinition(VotingStaticRoleNames.Tenants.VoteManager, MultiTenancySides.Tenant)
                {
                    GrantedPermissions =
                    {
                        PermissionNames.StateManagement
                    }
                }
            );

            foreach (var role in _generalRoles)
            {
                roleManagementConfig.StaticRoles.Add(role);
            }

            return _generalRoles;
        }
    }
}
