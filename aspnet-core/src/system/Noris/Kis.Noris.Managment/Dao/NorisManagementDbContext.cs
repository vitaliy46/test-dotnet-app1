using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Localization;
using Kis.General.Api.Entity;
using Kis.General.Dao.Mapping;
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
        typeof(NorisManagementRepositoryBase<>),
        typeof(NorisManagementRepositoryBase<,>)
    )]
    public class NorisManagementDbContext : AbpDbContext
    {
        public NorisManagementDbContext(DbContextOptions<NorisManagementDbContext> options) : base(options)
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
