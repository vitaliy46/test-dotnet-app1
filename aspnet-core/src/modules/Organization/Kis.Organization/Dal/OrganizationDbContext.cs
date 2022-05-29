using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Localization;
using Kis.Authorization.Users;
using Kis.General.Api.Entity;
using Kis.Organization.Api.Entity;
using Kis.Organization.Dal.Mapping;
using Kis.Organization.Dao.Mapping;
using Kis.Organization.Dao.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kis.Organization.Dao
{
    /// <summary>
    /// Класс взаимодействия служб Entity Framework с кодом описывающим модель бизнесс данных посредством DbContext.
    /// Этот класс вынесен на уровень DAO с целью сделать независимым доменную модель от способа взаимодействия с БД
    /// На уровне модуля этот класс расширяется DbSet сущностями своей бизнес модели
    /// </summary>
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(OrganizationRepositoryBase<>),
        typeof(OrganizationRepositoryBase<,>)
    )]
    public class OrganizationDbContext : AbpDbContext
    {
        public virtual DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public virtual DbSet<OrganizationUnitUser> OrganizationUnitUsers { get; set; }
        public virtual DbSet<OrganizationUnitAddress> OrganizationUnitAddresses { get; set; }
        public virtual DbSet<OrganizationUnitContact> OrganizationUnitContacts { get; set; }
        public virtual DbSet<OrganizationUnitMedia> OrganizationUnitMedias { get; set; }
        public virtual DbSet<AccountingDetails> AccountingDetails { get; set; }

        public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options) : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationLanguageText>()
            //    .Property(p => p.Value)
            //    .HasMaxLength(10485759); // any integer that is smaller than 10485760
            //https://www.npgsql.org/efcore/value-generation.html - для автогенерации Id типа Guid
            modelBuilder.HasPostgresExtension("uuid-ossp");

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new OrganizationUnitMap());
            modelBuilder.ApplyConfiguration(new OrganizationUnitUserMap());
            modelBuilder.ApplyConfiguration(new OrganizationUnitAddressMap());
            modelBuilder.ApplyConfiguration(new OrganizationUnitContactMap());
            modelBuilder.ApplyConfiguration(new OrganizationUnitMediaMap());
            modelBuilder.ApplyConfiguration(new AccountingDetailsMap());

            // Т.к. в сущностях модуля есть связь с User, эти сущности требуется исключить,
            // иначе они попадают в миграцию, даже если есть Ignore в конфигурации маппинга
            // (возможно баг в EF или ABP)
            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<UserToken>();
            modelBuilder.Ignore<PermissionSetting>();
            modelBuilder.Ignore<UserPermissionSetting>();
            modelBuilder.Ignore<RolePermissionSetting>();
            modelBuilder.Ignore<Setting>();
            modelBuilder.Ignore<UserClaim>();
            modelBuilder.Ignore<UserLogin>();
            modelBuilder.Ignore<UserRole>();
            modelBuilder.Ignore<Policy>();
            modelBuilder.Ignore<Abp.Localization.ApplicationLanguageText>();
            modelBuilder.Ignore<Person>();
            modelBuilder.Ignore<Address>();
            modelBuilder.Ignore<Contact>();
            modelBuilder.Ignore<PersonAddress>();
            modelBuilder.Ignore<PersonContact>();
            modelBuilder.Ignore<PersonUser>();
            modelBuilder.Ignore<Media>();
            modelBuilder.Ignore<MediaType>();
        }

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

       
    }

}
