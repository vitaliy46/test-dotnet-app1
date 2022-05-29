using System;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace It2g.Reporter.Dao.Repositories
{
    public class ReporterRepositoryBase<TEntity> : EfRepositoryBase<ReporterDbContext, TEntity, Guid >
        where TEntity : class, IEntity<Guid>
    {
        public ReporterRepositoryBase(IDbContextProvider<ReporterDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
    public class ReporterRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ReporterDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public ReporterRepositoryBase(IDbContextProvider<ReporterDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
