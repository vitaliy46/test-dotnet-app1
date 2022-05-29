using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.Investors.Dao.Repositories
{
    public class InvestorsRepositoryBase<TEntity> : EfCoreRepositoryBase<InvestorsDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public InvestorsRepositoryBase(IDbContextProvider<InvestorsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
    /// <summary>
    /// Используется в случае если первичный ключ сушности не Guid  типа
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class InvestorsRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<InvestorsDbContext, TEntity, TPrimaryKey> 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public InvestorsRepositoryBase(IDbContextProvider<InvestorsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
