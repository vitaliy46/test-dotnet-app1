using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Localization;
using Kis.General.Api.Entity;
using Kis.Staff.Api.Entity;
using Kis.Staff.Dao.Mapping;
using Kis.Staff.Dao.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kis.Staff.Dao
{
    /// <summary>
    /// Класс взаимодействия служб Entity Framework с кодом описывающим модель бизнесс данных посредством DbContext.
    /// Этот класс вынесен на уровень DAO с целью сделать независимым доменную модель от способа взаимодействия с БД
    /// На уровне модуля этот класс расширяется DbSet сущностями своей бизнес модели
    /// </summary>
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(StaffRepositoryBase<>),
        typeof(StaffRepositoryBase<,>)
    )]
    public class StaffDbContext : AbpDbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeContact> EmployeeContacts { get; set; }
        public virtual DbSet<Karma> Karmas { get; set; }
        public virtual DbSet<KarmaType> KarmaTypes { get; set; }
        public virtual DbSet<KarmaVote> KarmaVotes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PositionAppointment> PositionAppointments { get; set; }

        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(10485759); // any integer that is smaller than 10485760

            base.OnModelCreating(modelBuilder);
            
            
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new PositionMap());
            modelBuilder.ApplyConfiguration(new PositionAppointmentMap());
            modelBuilder.ApplyConfiguration(new KarmaMap());
            modelBuilder.ApplyConfiguration(new KarmaTypeMap());
            modelBuilder.ApplyConfiguration(new KarmaVoteMap());
            
            //Эти маппинги используются наследниками в др. модулях, поэтому их исключил из регистрации EF
            modelBuilder.Ignore<Document>();
        }

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

       
    }

}
