using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Kis.General.Api.Entity;
using Kis.Inventory.Api.Entity;
using Kis.Inventory.Dao.Mapping;
using Kis.Inventory.Dao.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kis.Inventory.Dao
{
    /// <summary>
    /// Класс взаимодействия служб Entity Framework с кодом описывающим модель бизнесс данных посредством DbContext.
    /// Этот класс вынесен на уровень DAO с целью сделать независимым доменную модель от способа взаимодействия с БД
    /// На уровне модуля этот класс расширяется DbSet сущностями своей бизнес модели
    /// </summary>
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(InventoryRepositoryBase<>),
        typeof(InventoryRepositoryBase<,>))]
    public class InventoryDbContext : AbpDbContext
    {
        public virtual DbSet<Contactor> Contactors { get; set; }
        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<Api.Entity.Inventory> Inventories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ReceiptOrder> ReceiptOrders { get; set; }
        public virtual DbSet<ReceiptOrderType> ReceiptOrderTypes { get; set; }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationLanguageText>()
            //    .Property(p => p.Value)
            //    .HasMaxLength(10485759); // any integer that is smaller than 10485760

            //В базовом классе находится механизм регистрации конфигураций в текущей сборке
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new InventoryMap());
           

            //Эти маппинги используются наследниками в др. модулях, поэтому их исключил из регистрации EF
            modelBuilder.Ignore<Document>();
           
        }

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

       
    }

  
}
