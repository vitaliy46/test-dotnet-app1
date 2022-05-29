using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.Hr.Dao.Repositories
{
    public class NorisRepositoryBase<TEntity, TPrimaryKye> : EfCoreRepositoryBase<NorisDbContext, TEntity, TPrimaryKye>
        where TEntity : class, IEntity<TPrimaryKye>
    {
        public NorisRepositoryBase(IDbContextProvider<NorisDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    public class NorisRepositoryBase<TEntity> : EfCoreRepositoryBase<NorisDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public NorisRepositoryBase(IDbContextProvider<NorisDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
