using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Kis.Crm.Api.Entity;
using Kis.Crm.Dao.Mapping;
using Kis.Crm.Dao.Repositories;
using Kis.General.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kis.Crm.Dao
{
    /// <summary>
    /// Класс взаимодействия служб Entity Framework с кодом описывающим модель бизнесс данных посредством DbContext.
    /// Этот класс вынесен на уровень DAO с целью сделать независимым доменную модель от способа взаимодействия с БД
    /// На уровне модуля этот класс расширяется DbSet сущностями своей бизнес модели
    /// </summary>
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(CrmRepositoryBase<>),
        typeof(CrmRepositoryBase<,>))]
    public class CrmDbContext : AbpDbContext
    {
        public virtual DbSet<BusinessContact> BusinessContacts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Contactor> Contactors { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<DealMedia> DealMediae { get; set; }
        public virtual DbSet<DealPayment> DealPayments { get; set; }
        public virtual DbSet<DealPaymentForm> DealPaymentForms { get; set; }
        public virtual DbSet<DealState> DealStates { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }


        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationLanguageText>()
            //    .Property(p => p.Value)
            //    .HasMaxLength(10485759); // any integer that is smaller than 10485760

            //В базовом классе находится механизм регистрации конфигураций в текущей сборке
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DealMap());
           

            //Эти маппинги используются наследниками в др. модулях, поэтому их исключил из регистрации EF
            modelBuilder.Ignore<Document>();
           
        }

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

       
    }

  
}
