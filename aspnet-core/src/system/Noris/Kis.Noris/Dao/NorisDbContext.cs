using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Localization;
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
        typeof(NorisRepositoryBase<>),
        typeof(NorisRepositoryBase<,>)
    )]
    public class NorisDbContext : AbpDbContext
    {
        public NorisDbContext(DbContextOptions<NorisDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(10485759); // any integer that is smaller than 10485760

            base.OnModelCreating(modelBuilder);
            
            
        }

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

       
    }

}
