using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.BackgroundJobs;
using Abp.Configuration;
using Abp.EntityHistory;
using Abp.Localization;
using Abp.MultiTenancy;
using Abp.Notifications;
using Abp.Organizations;
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Kis.Authorization.Roles;
using Kis.Authorization.Users;
using Kis.MultiTenancy;

namespace Kis.EntityFrameworkCore
{
    public class KisDbContext : AbpZeroDbContext<Tenant, Role, User, KisDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public KisDbContext(DbContextOptions<KisDbContext> options)
            : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(10485759); // any integer that is smaller than 10485760

            //Для автогенерации идентификаторов в сущностях
            //https://www.npgsql.org/efcore/value-generation.html
            modelBuilder.ForNpgsqlUseIdentityColumns();

            modelBuilder.Entity<EntityChangeSet>().ToTable("entity_change_sets", "core");
            modelBuilder.Entity<EntityChange>().ToTable("entity_changes", "core");
            modelBuilder.Entity<NotificationSubscriptionInfo>().ToTable("notification_subscription_infos", "core");
            modelBuilder.Entity<UserNotificationInfo>().ToTable("user_notification_infos", "core");
            modelBuilder.Entity<TenantNotificationInfo>().ToTable("tenant_notification_infos", "core");
            modelBuilder.Entity<UserOrganizationUnit>().ToTable("user_organization_units", "core");
            modelBuilder.Entity<OrganizationUnit>().ToTable("organization_units", "core");
            modelBuilder.Entity<ApplicationLanguageText>().ToTable("application_language_texts", "core");
            modelBuilder.Entity<ApplicationLanguage>().ToTable("application_languages", "core");
            modelBuilder.Entity<AuditLog>().ToTable("audit_logs", "core");
            modelBuilder.Entity<Setting>().ToTable("settings", "core");
            modelBuilder.Entity<UserPermissionSetting>().ToTable("user_permission_settings", "core");
            modelBuilder.Entity<RolePermissionSetting>().ToTable("role_permission_settings", "core");
            modelBuilder.Entity<PermissionSetting>().ToTable("permission_settings", "core");
            modelBuilder.Entity<RoleClaim>().ToTable("role_claims", "core");
            modelBuilder.Entity<UserToken>().ToTable("user_tokens", "core");
            modelBuilder.Entity<UserClaim>().ToTable("user_claims", "core");
            modelBuilder.Entity<UserRole>().ToTable("user_role", "core");
            modelBuilder.Entity<UserLoginAttempt>().ToTable("user_login_attempts", "core");
            modelBuilder.Entity<UserLogin>().ToTable("user_login", "core");
            modelBuilder.Entity<User>().ToTable("users", "core");
            modelBuilder.Entity<Role>().ToTable("roles", "core");
            modelBuilder.Entity<EntityPropertyChange>().ToTable("entity_property_changes", "core");
            modelBuilder.Entity<Tenant>().ToTable("tenants", "core");
            modelBuilder.Entity<Edition>().ToTable("editions", "core");
            modelBuilder.Entity<FeatureSetting>().ToTable("feature_settings", "core");
            modelBuilder.Entity<TenantFeatureSetting>().ToTable("tenant_feature_settings", "core");
            modelBuilder.Entity<EditionFeatureSetting>().ToTable("edition_feature_settings", "core");
            modelBuilder.Entity<BackgroundJobInfo>().ToTable("background_job_infos", "core");
            modelBuilder.Entity<UserAccount>().ToTable("user_accounts", "core");
            modelBuilder.Entity<NotificationInfo>().ToTable("notification_infos", "core");
            modelBuilder.Entity<OrganizationUnitRole>().ToTable("organization_unit_role", "core");

        }
    }
}
