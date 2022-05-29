using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.General.Dao.Repositories
{
    public class GeneralRepositoryBase<TEntity> : EfCoreRepositoryBase<GeneralDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public GeneralRepositoryBase(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
    /// <summary>
    /// Используется в случае если первичный ключ сушности не Guid  типа
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class GeneralRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<GeneralDbContext, TEntity, TPrimaryKey> 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public GeneralRepositoryBase(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
