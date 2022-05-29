using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.Crm.Dao.Repositories
{
    public class CrmRepositoryBase<TEntity> : EfCoreRepositoryBase<CrmDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public CrmRepositoryBase(IDbContextProvider<CrmDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
    /// <summary>
    /// Используется в случае если первичный ключ сушности не Guid  типа
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class CrmRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<CrmDbContext, TEntity, TPrimaryKey> 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public CrmRepositoryBase(IDbContextProvider<CrmDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
