using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.TaskTrecker.Dal.Repositories
{
    public class TaskTreckerRepositoryBase<TEntity> : EfCoreRepositoryBase<TaskTreckerDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public TaskTreckerRepositoryBase(IDbContextProvider<TaskTreckerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
    /// <summary>
    /// Используется в случае если первичный ключ сушности не Guid  типа
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class TaskTreckerRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<TaskTreckerDbContext, TEntity, TPrimaryKey> 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public TaskTreckerRepositoryBase(IDbContextProvider<TaskTreckerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
