using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.Hr.Dao.Repositories
{
    public class HrRepositoryBase<TEntity, TPrimaryKye> : EfCoreRepositoryBase<HrDbContext, TEntity, TPrimaryKye>
        where TEntity : class, IEntity<TPrimaryKye>
    {
        public HrRepositoryBase(IDbContextProvider<HrDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    public class HrRepositoryBase<TEntity> : EfCoreRepositoryBase<HrDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public HrRepositoryBase(IDbContextProvider<HrDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
