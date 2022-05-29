using Abp.Authorization;
using Kis.Authorization.Roles;
using Kis.Authorization.Users;

namespace Kis.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
