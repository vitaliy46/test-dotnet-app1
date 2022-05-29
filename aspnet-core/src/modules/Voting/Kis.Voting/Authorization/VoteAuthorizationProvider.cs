using Abp.Authorization;
using Abp.Localization;


namespace Kis.Voting.Authorization
{
    public class VoteAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // Vote
            context.CreatePermission(PermissionNames.VoteList, L("VoteList"));
            context.CreatePermission(PermissionNames.VoteDetails, L("VoteDetails"));
            context.CreatePermission(PermissionNames.VoteManagement, L("VoteManagement"));
            context.CreatePermission(PermissionNames.Voting, L("Voting"));

            // VoteMember
            context.CreatePermission(PermissionNames.VoteMemberGetCurrentForVote, L("VoteMemberGetCurrentForVote"));

            // VoteMedia
            context.CreatePermission(PermissionNames.VoteMediaManagement, L("VoteMediaManagement"));
            context.CreatePermission(PermissionNames.VoteMediaGet, L("VoteMediaGet"));

            // Bulletin
            context.CreatePermission(PermissionNames.BulletinForVote, L("BulletinForVote"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, KisConsts.LocalizationSourceName);
        }
    }
}
