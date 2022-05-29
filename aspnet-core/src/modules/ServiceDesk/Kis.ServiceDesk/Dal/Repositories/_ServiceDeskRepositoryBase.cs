using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.ServiceDesk.Dao.Repositories
{
    public class ServiceDeskRepositoryBase<TEntity> : EfCoreRepositoryBase<ServiceDeskDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public ServiceDeskRepositoryBase(IDbContextProvider<ServiceDeskDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
    /// <summary>
    /// Используется в случае если первичный ключ сушности не Guid  типа
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class ServiceDeskRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<ServiceDeskDbContext, TEntity, TPrimaryKey> 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public ServiceDeskRepositoryBase(IDbContextProvider<ServiceDeskDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
