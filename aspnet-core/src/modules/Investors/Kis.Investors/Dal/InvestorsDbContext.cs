using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
//using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Localization;
using Kis.Authorization.Users;
using Kis.General.Api.Entity;
using Kis.Investors.Api.Entity;
using Kis.Investors.Dao.Mapping;
using Kis.Investors.Dao.Repositories;
using Kis.Organization.Api.Entity;
using Kis.TaskTrecker.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kis.Investors.Dao
{
    /// <summary>
    /// Класс взаимодействия служб Entity Framework с кодом описывающим модель бизнесс данных посредством DbContext.
    /// Этот класс вынесен на уровень DAO с целью сделать независимым доменную модель от способа взаимодействия с БД
    /// На уровне модуля этот класс расширяется DbSet сущностями своей бизнес модели
    /// </summary>
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(InvestorsRepositoryBase<>),
        typeof(InvestorsRepositoryBase<,>))]
    public class InvestorsDbContext : AbpDbContext
    {
        public virtual DbSet<Investor> Investors { get; set; }
        public virtual DbSet<InvestedProject> InvestedProjects { get; set; }
        public virtual DbSet<MemberContactor> MemberContactors { get; set; }
        public virtual DbSet<Partnership> Partnerships { get; set; }
        public virtual DbSet<PartnershipMember> PartnershipMembers { get; set; }

        public InvestorsDbContext(DbContextOptions<InvestorsDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationLanguageText>()
            //    .Property(p => p.Value)
            //    .HasMaxLength(10485759); // any integer that is smaller than 10485760

            //В базовом классе находится механизм регистрации конфигураций в текущей сборке
            base.OnModelCreating(modelBuilder);
            //https://www.npgsql.org/efcore/value-generation.html - для автогенерации Id типа Guid
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new InvestorMap());
            modelBuilder.ApplyConfiguration(new InvestedProjectMap());
            modelBuilder.ApplyConfiguration(new MemberContactorMap());
            modelBuilder.ApplyConfiguration(new PartnershipMap());
            modelBuilder.ApplyConfiguration(new PartnershipMemberMap());

            
            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<PermissionSetting>();
            modelBuilder.Ignore<UserPermissionSetting>();
            modelBuilder.Ignore<RolePermissionSetting>();
            modelBuilder.Ignore<Setting>();
            modelBuilder.Ignore<UserClaim>();
            modelBuilder.Ignore<UserLogin>();
            modelBuilder.Ignore<UserRole>();
            modelBuilder.Ignore<UserToken>();
            modelBuilder.Ignore<Project>();
            modelBuilder.Ignore<OrganizationUnit>();
            modelBuilder.Ignore<OrganizationUnitAddress>();
            modelBuilder.Ignore<OrganizationUnitContact>();
            modelBuilder.Ignore<OrganizationUnitMedia>();
            modelBuilder.Ignore<Project>();
            modelBuilder.Ignore<ProjectState>();
            modelBuilder.Ignore<Address>();
            modelBuilder.Ignore<Address>();
            modelBuilder.Ignore<Contact>();
            modelBuilder.Ignore<State>();
            modelBuilder.Ignore<PersonAddress>();
            modelBuilder.Ignore<Person>();
            modelBuilder.Ignore<PersonContact>();
            modelBuilder.Ignore<PersonUser>();
            modelBuilder.Ignore<Policy>();

        }

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
    }

  
}
