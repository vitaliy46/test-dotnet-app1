using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.Staff.Dao.Repositories
{
    public class StaffRepositoryBase<TEntity, TPrimaryKye> : EfCoreRepositoryBase<StaffDbContext, TEntity, TPrimaryKye>
        where TEntity : class, IEntity<TPrimaryKye>
    {
        public StaffRepositoryBase(IDbContextProvider<StaffDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    public class StaffRepositoryBase<TEntity> : EfCoreRepositoryBase<StaffDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public StaffRepositoryBase(IDbContextProvider<StaffDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
