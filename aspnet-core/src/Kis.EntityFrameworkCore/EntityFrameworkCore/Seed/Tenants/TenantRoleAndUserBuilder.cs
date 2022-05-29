using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Kis.Authorization;
using Kis.Authorization.Roles;
using Kis.Authorization.Users;

namespace Kis.EntityFrameworkCore.Seed.Tenants
{
    public class TenantRoleAndUserBuilder
    {
        private readonly KisDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(KisDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            // Admin role

            var adminRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin) { IsStatic = true }).Entity;
                _context.SaveChanges();
            }

            // Grant all permissions to admin role

            var grantedPermissions = _context.Permissions.IgnoreQueryFilters()
                .OfType<RolePermissionSetting>()
                .Where(p => p.TenantId == _tenantId && p.RoleId == adminRole.Id)
                .Select(p => p.Name)
                .ToList();

            var permissions = PermissionFinder
                .GetAllPermissions(new KisAuthorizationProvider())
                .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) &&
                            !grantedPermissions.Contains(p.Name))
                .ToList();

            if (permissions.Any())
            {
                _context.Permissions.AddRange(
                    permissions.Select(permission => new RolePermissionSetting
                    {
                        TenantId = _tenantId,
                        Name = permission.Name,
                        IsGranted = true,
                        RoleId = adminRole.Id
                    })
                );
                _context.SaveChanges();
            }

            // Admin user
            // !!! AbpUserBase.AdminUserName

            //var adminUser = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == "admin2");
            //if (adminUser == null)
            //{
            //    adminUser = User.CreateTenantAdminUser(_tenantId, "admin2@defaulttenant.com");
            //    adminUser.UserName = "admin2";
            //    adminUser.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(adminUser, "123qwe");
            //    adminUser.IsEmailConfirmed = true;
            //    adminUser.IsActive = true;

            //    _context.Users.Add(adminUser);
            //    _context.SaveChanges();

            //    // Assign Admin role to admin user
            //    _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));

            //    var voteManagerRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == "VoteManager");
            //    if (voteManagerRole != null) _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, voteManagerRole.Id));

            //    _context.SaveChanges();
            //}

            // Admin users for tenant

            var voteAdmin1 = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == "voteadmin");
            if (voteAdmin1 == null)
            {
                var user = new User
                {
                    TenantId = _tenantId,
                    UserName = "voteadmin",
                    Name = "Евгений",
                    Surname = "Лямин",
                    EmailAddress = "evglyamin1@gmail.com",
                    IsEmailConfirmed = true,
                    IsActive = true
                };

                user.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(user, "123qwe");
                user.SetNormalizedNames();

                voteAdmin1 = _context.Users.Add(user).Entity;
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, voteAdmin1.Id, adminRole.Id));

                var voteManagerRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == "VoteManager");
                if (voteManagerRole != null) _context.UserRoles.Add(new UserRole(_tenantId, voteAdmin1.Id, voteManagerRole.Id));

                _context.SaveChanges();
            }

            var voteAdmin2 = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == "zaplatin");
            if (voteAdmin2 == null)
            {
                var user = new User
                {
                    TenantId = _tenantId,
                    UserName = "zaplatin",
                    Name = "Евгений",
                    Surname = "Заплатин",
                    EmailAddress = "zefslab1@gmail.com",
                    IsEmailConfirmed = true,
                    IsActive = true
                };

                user.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(user, "123qwe");
                user.SetNormalizedNames();

                voteAdmin2 = _context.Users.Add(user).Entity;
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, voteAdmin2.Id, adminRole.Id));

                var voteManagerRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == "VoteManager");
                if (voteManagerRole != null) _context.UserRoles.Add(new UserRole(_tenantId, voteAdmin2.Id, voteManagerRole.Id));

                _context.SaveChanges();
            }

            var voteAdmin3 = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == "berezin");
            if (voteAdmin3 == null)
            {
                var user = new User
                {
                    TenantId = _tenantId,
                    UserName = "berezin",
                    Name = "Виталий",
                    Surname = "Березин",
                    EmailAddress = "vitalij461@gmail.com",
                    IsEmailConfirmed = true,
                    IsActive = true
                };

                user.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(user, "123qwe");
                user.SetNormalizedNames();

                voteAdmin3 = _context.Users.Add(user).Entity;
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, voteAdmin3.Id, adminRole.Id));

                var voteManagerRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == "VoteManager");
                if (voteManagerRole != null) _context.UserRoles.Add(new UserRole(_tenantId, voteAdmin3.Id, voteManagerRole.Id));

                _context.SaveChanges();
            }

            
        }
    }
}
