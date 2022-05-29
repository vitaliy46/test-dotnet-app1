using Abp.EntityFrameworkCore;
using Kis.General.Dao.Repositories;
using Kis.Organization.Api.Dal.Repositories;
using Kis.Organization.Api.Entity;
using Kis.Organization.Dao;
using Kis.Organization.Dao.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kis.Organization.Dal.Repositories
{
    public class OrganizationUnitUserRepository : OrganizationRepositoryBase<OrganizationUnitUser, Guid?>, IOrganizationUnitUserRepository
    {
        public OrganizationUnitUserRepository(IDbContextProvider<OrganizationDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
