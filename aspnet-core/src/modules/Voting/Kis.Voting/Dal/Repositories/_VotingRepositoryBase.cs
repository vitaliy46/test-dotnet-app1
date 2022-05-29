using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.Voting.Dao.Repositories
{
    public class VotingRepositoryBase<TEntity> : EfCoreRepositoryBase<VotingDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public VotingRepositoryBase(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
    /// <summary>
    /// Используется в случае если первичный ключ сущности не Guid  типа
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class VotingRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<VotingDbContext, TEntity, TPrimaryKey> 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public VotingRepositoryBase(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
