using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Localization;
using Kis.Authorization.Users;
using Kis.General.Api.Entity;
using Kis.General.Dal.Mapping;
using Kis.General.Dao.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kis.General.Dao
{
    /// <summary>
    /// Класс взаимодействия служб Entity Framework с кодом описывающим модель бизнесс данных посредством DbContext.
    /// Этот класс вынесен на уровень DAO с целью сделать независимым доменную модель от способа взаимодействия с БД
    /// На уровне модуля этот класс расширяется DbSet сущностями своей бизнес модели
    /// </summary>
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(GeneralRepositoryBase<>),
        typeof(GeneralRepositoryBase<,>))]
    public class GeneralDbContext : AbpDbContext
    {
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentLink> CommentLinks { get; set; }
        public virtual DbSet<CommentMedia> CommentMedias { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<Media> Medias { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonUser> PersonUsers { get; set; }
        public virtual DbSet<PersonAddress> PersonAddresses { get; set; }
        public virtual DbSet<PersonContact> PersonContacts { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<StateTransition> StateTransitions { get; set; }
        public virtual DbSet<Workflow> Workflows { get; set; }
        public virtual DbSet<OneTimePassword> OneTimePasswords { get; set; }

        public GeneralDbContext(DbContextOptions<GeneralDbContext> options) : base(options)
        {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationLanguageText>()
            //    .Property(p => p.Value)
            //    .HasMaxLength(10485759); // any integer that is smaller than 10485760

            base.OnModelCreating(modelBuilder);
            //https://www.npgsql.org/efcore/value-generation.html - для автогенерации Id типа Guid
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new CommentLinkMap());
            modelBuilder.ApplyConfiguration(new CommentMediaMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new LinkMap());
            modelBuilder.ApplyConfiguration(new MediaTypeMap());
            modelBuilder.ApplyConfiguration(new MediaMap());
            modelBuilder.ApplyConfiguration(new PolicyMap());
            modelBuilder.ApplyConfiguration(new PersonAddressMap());
            modelBuilder.ApplyConfiguration(new PersonContactMap());
            modelBuilder.ApplyConfiguration(new PersonUserMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new StateTransitionMap());
            modelBuilder.ApplyConfiguration(new WorkflowMap());
            modelBuilder.ApplyConfiguration(new OneTimePasswordMap());

            //Эти маппинги используются наследниками в др. модулях, поэтому их исключил из регистрации EF
            modelBuilder.Ignore<Document>();
            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<PermissionSetting>();
            modelBuilder.Ignore<UserPermissionSetting>();
            modelBuilder.Ignore<RolePermissionSetting>();
            modelBuilder.Ignore<Setting>();
            modelBuilder.Ignore<UserClaim>();
            modelBuilder.Ignore<UserLogin>();
            modelBuilder.Ignore<UserRole>();
            modelBuilder.Ignore<UserToken>();
        }

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

       
    }

  
}
