using System.Collections.Generic;
using Abp.MultiTenancy;
using Abp.Zero.Configuration;
using Kis.Voting.Api.Roles;

namespace Kis.TaskTrecker.Authorization.Roles
{
    public static class TaskTreckerRoleConfig
    {
        private static readonly List<StaticRoleDefinition> _taskTreckerRoles = new List<StaticRoleDefinition>();

        public static List<StaticRoleDefinition> Configure(IRoleManagementConfig roleManagementConfig)
        {
            // Static tenant roles

            _taskTreckerRoles.Add(
                new StaticRoleDefinition(VotingStaticRoleNames.Tenants.VoteManager, MultiTenancySides.Tenant)
                {
                    GrantedPermissions =
                    {
                        PermissionNames.ProjectStateList,
                        PermissionNames.ProjectStateManagement
                    }
                }
            );

            _taskTreckerRoles.Add(
                new StaticRoleDefinition(VotingStaticRoleNames.Tenants.VoteMember, MultiTenancySides.Tenant)
                {
                    GrantedPermissions =
                    {
                        PermissionNames.ProjectStateList
                    }
                }
            );

            foreach (var role in _taskTreckerRoles)
            {
                roleManagementConfig.StaticRoles.Add(role);
            }

            return _taskTreckerRoles;
        }
    }
}
