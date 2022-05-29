using System;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Kis.Organization.Dao.Repositories
{
    public class OrganizationRepositoryBase<TEntity, TPrimaryKye> : EfCoreRepositoryBase<OrganizationDbContext, TEntity, TPrimaryKye>
        where TEntity : class, IEntity<TPrimaryKye>
    {
        public OrganizationRepositoryBase(IDbContextProvider<OrganizationDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    public class OrganizationRepositoryBase<TEntity> : EfCoreRepositoryBase<OrganizationDbContext, TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        public OrganizationRepositoryBase(IDbContextProvider<OrganizationDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
