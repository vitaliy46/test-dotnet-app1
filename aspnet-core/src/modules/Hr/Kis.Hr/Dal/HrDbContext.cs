using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Localization;
using Kis.General.Api.Entity;
using Kis.General.Dao.Mapping;
using Kis.Hr.Api.Entity;
using Kis.Hr.Dao.Mapping;
using Kis.Hr.Dao.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kis.Hr.Dao
{
    /// <summary>
    /// Класс взаимодействия служб Entity Framework с кодом описывающим модель бизнесс данных посредством DbContext.
    /// Этот класс вынесен на уровень DAO с целью сделать независимым доменную модель от способа взаимодействия с БД
    /// На уровне модуля этот класс расширяется DbSet сущностями своей бизнес модели
    /// </summary>
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(HrRepositoryBase<>),
        typeof(HrRepositoryBase<,>)
    )]
    public class HrDbContext : AbpDbContext
    {
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CandidateComment> CandidateComments { get; set; }
        public virtual DbSet<CandidateContact> CandidateContacts { get; set; }
        public virtual DbSet<CandidateLink> CandidateLinks { get; set; }
        public virtual DbSet<CandidateMedia> CandidateMediae { get; set; }
        public virtual DbSet<CandidateState> CandidateStates { get; set; }
        public virtual DbSet<InfomationSource> InfomationSources { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }


        public HrDbContext(DbContextOptions<HrDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(10485759); // any integer that is smaller than 10485760

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new CandidateMap());
            modelBuilder.ApplyConfiguration(new CandidateCommentMap());
            modelBuilder.ApplyConfiguration(new CandidateMediaMap());
            modelBuilder.ApplyConfiguration(new CandidateLinkMap());
            modelBuilder.ApplyConfiguration(new CandidateStateMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new VacancyMap());
            modelBuilder.ApplyConfiguration(new InfomationSourceMap());
            modelBuilder.ApplyConfiguration(new StateTransitionMap());

            //Эти маппинги используются наследниками в др. модулях, поэтому их исключил из регистрации EF
            modelBuilder.Ignore<Document>();
        }

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

       
    }

}
