using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Localization;
using Kis.Authorization.Users;
using Kis.General.Api.Entity;
using Kis.Voting.Api.Entity;
using Kis.Voting.Dao.Mapping;
using Kis.Voting.Dao.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kis.Voting.Dao
{
    /// <summary>
    /// Класс взаимодействия служб Entity Framework с кодом описывающим модель бизнесс данных посредством DbContext.
    /// Этот класс вынесен на уровень DAO с целью сделать независимым доменную модель от способа взаимодействия с БД
    /// На уровне модуля этот класс расширяется DbSet сущностями своей бизнес модели
    /// </summary>
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(VotingRepositoryBase<>),
        typeof(VotingRepositoryBase<,>))]
    public class VotingDbContext : AbpDbContext
    {
        public virtual DbSet<Bulletin> Bulletins { get; set; }
        public virtual DbSet<BulletinSelectedOption> BulletinSelectedOptionss { get; set; }
        public virtual DbSet<VoteMemberContact> VoteMemberContacts { get; set; }
        public virtual DbSet<NoticeReceiptConfimation> NoticeReceiptConfimations { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<VoteLink> VoteLinks { get; set; }
        public virtual DbSet<VoteMedia> VoteMediae{ get; set; }
        public virtual DbSet<VoteMember> VoteMembers { get; set; }
        public virtual DbSet<VoteNotice> VoteNotices { get; set; }
        public virtual DbSet<VoteOption> VoteOptions { get; set; }
        public virtual DbSet<VoteReport> VoteReports { get; set; }
        public virtual DbSet<VoteReportMedia> VoteReportMediae { get; set; }
        public virtual DbSet<VoteSettings> VoteSettingses { get; set; }
       public virtual DbSet<VoteResult> VoteResults { get; set; }



        public VotingDbContext(DbContextOptions<VotingDbContext> options) : base(options)
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

            modelBuilder.ApplyConfiguration(new BulletinMap());
            modelBuilder.ApplyConfiguration(new BulletinSelectedOptionMap());
            modelBuilder.ApplyConfiguration(new VoteMemberContactMap());
            modelBuilder.ApplyConfiguration(new NoticeReceiptConfimationMap());
            modelBuilder.ApplyConfiguration(new VoteMap());
            modelBuilder.ApplyConfiguration(new VoteMediaMap());
            modelBuilder.ApplyConfiguration(new VoteLinkMap());
            modelBuilder.ApplyConfiguration(new VoteMemberMap());
            modelBuilder.ApplyConfiguration(new VoteNoticeMap());
            modelBuilder.ApplyConfiguration(new VoteOptionMap());
            modelBuilder.ApplyConfiguration(new VoteReportMap());
            modelBuilder.ApplyConfiguration(new VoteReportMediaMap());
            modelBuilder.ApplyConfiguration(new VoteSettingsMap());
            modelBuilder.ApplyConfiguration(new VoteResultMap());

            //Эти маппинги используются наследниками в др. модулях, поэтому их исключил из регистрации EF
            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<PermissionSetting>();
            modelBuilder.Ignore<UserPermissionSetting>();
            modelBuilder.Ignore<RolePermissionSetting>();
            modelBuilder.Ignore<Setting>();
            modelBuilder.Ignore<UserClaim>();
            modelBuilder.Ignore<UserLogin>();
            modelBuilder.Ignore<UserRole>();
            modelBuilder.Ignore<UserToken>();
            modelBuilder.Ignore<Contact>();
            modelBuilder.Ignore<Link>();
            modelBuilder.Ignore<MediaType>();
            modelBuilder.Ignore<State>();
            modelBuilder.Ignore<Media>();
        }

        

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

       
    }

  
}
