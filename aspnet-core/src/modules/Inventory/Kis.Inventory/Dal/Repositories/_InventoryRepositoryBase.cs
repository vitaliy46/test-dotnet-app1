using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.Inventory.Dao.Repositories
{
    public class InventoryRepositoryBase<TEntity> : EfCoreRepositoryBase<InventoryDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public InventoryRepositoryBase(IDbContextProvider<InventoryDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
    /// <summary>
    /// Используется в случае если первичный ключ сушности не Guid  типа
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class InventoryRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<InventoryDbContext, TEntity, TPrimaryKey> 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public InventoryRepositoryBase(IDbContextProvider<InventoryDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
