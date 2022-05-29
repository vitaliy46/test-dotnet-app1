using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.Hr.Dao.Repositories
{
    public class NorisManagementRepositoryBase<TEntity, TPrimaryKye> : EfCoreRepositoryBase<NorisManagementDbContext, TEntity, TPrimaryKye>
        where TEntity : class, IEntity<TPrimaryKye>
    {
        public NorisManagementRepositoryBase(IDbContextProvider<NorisManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    public class NorisManagementRepositoryBase<TEntity> : EfCoreRepositoryBase<NorisManagementDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public NorisManagementRepositoryBase(IDbContextProvider<NorisManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
