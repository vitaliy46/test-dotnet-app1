using System.Collections.Generic;
using Abp.MultiTenancy;
using Abp.Zero.Configuration;
using Kis.Authorization.Roles;
using Kis.Voting.Api.Roles;

namespace Kis.Voting.Authorization.Roles
{
    public static class VotingRoleConfig
    {
        private static readonly List<StaticRoleDefinition> _voteRoles = new List<StaticRoleDefinition>();

        public static List<StaticRoleDefinition> Configure(IRoleManagementConfig roleManagementConfig)
        {
            // Static tenant roles

            _voteRoles.Add(
                new StaticRoleDefinition(VotingStaticRoleNames.Tenants.VoteManager, MultiTenancySides.Tenant)
                {
                    GrantedPermissions =
                    {
                        PermissionNames.VoteList,
                        PermissionNames.VoteDetails,
                        PermissionNames.VoteManagement,
                        PermissionNames.VoteMediaManagement,
                        PermissionNames.VoteMediaGet
                    }
                }
            );

            _voteRoles.Add(
                new StaticRoleDefinition(VotingStaticRoleNames.Tenants.VoteMember, MultiTenancySides.Tenant)
                {
                    GrantedPermissions =
                    {
                        PermissionNames.VoteList,
                        PermissionNames.Voting,
                        PermissionNames.VoteMemberGetCurrentForVote,
                        PermissionNames.VoteMediaGet,
                        PermissionNames.BulletinForVote
                    }
                }
            );

            foreach (var role in _voteRoles)
            {
                roleManagementConfig.StaticRoles.Add(role);
            }

            return _voteRoles;
        }
    }
}
