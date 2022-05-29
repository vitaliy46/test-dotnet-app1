using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Kis.ServiceDesk.Dao.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kis.ServiceDesk.Dao
{
    /// <summary>
    /// Класс взаимодействия служб Entity Framework с кодом описывающим модель бизнесс данных посредством DbContext.
    /// Этот класс вынесен на уровень DAO с целью сделать независимым доменную модель от способа взаимодействия с БД
    /// На уровне модуля этот класс расширяется DbSet сущностями своей бизнес модели
    /// </summary>
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(ServiceDeskRepositoryBase<>),
        typeof(ServiceDeskRepositoryBase<,>))]
    public class ServiceDeskDbContext : AbpDbContext
    {
       
        public ServiceDeskDbContext(DbContextOptions<ServiceDeskDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationLanguageText>()
            //    .Property(p => p.Value)
            //    .HasMaxLength(10485759); // any integer that is smaller than 10485760

            //В базовом классе находится механизм регистрации конфигураций в текущей сборке
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new ProjectMap());
           

           
        }

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

       
    }

  
}
