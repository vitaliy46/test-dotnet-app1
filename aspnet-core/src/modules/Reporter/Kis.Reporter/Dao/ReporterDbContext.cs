using System.Data.Common;
using System.Data.Entity;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using It2g.General.Api.Entity;
using It2g.Reporter.Dao.Repositories;

namespace It2g.Reporter.Dao
{

    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(ReporterRepositoryBase<>),
        typeof(ReporterRepositoryBase<,>)
    )]
    public class ReporterDbContext : AbpDbContext
    {
        public ReporterDbContext(): base("DbConnection")
        {}

        public ReporterDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {}

        public ReporterDbContext(DbConnection existingConnection)
            : base(existingConnection, false)
        {}

        public ReporterDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            
            //modelBuilder.Configurations.Add(new CandidateMap());
            

            //Эти маппинги используются наследниками в др. модулях, поэтому их исключил из регистрации EF
            modelBuilder.Ignore<Document>();
        }

        public virtual DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
    }

}
