using System;
using Abp.Domain.Repositories;
using Kis.Organization.Api.Entity;

namespace Kis.Organization.Api.Dal.Repositories
{
    
    public interface IOrganizationUnitUserRepository : IRepository<OrganizationUnitUser, Guid?>
    {
    }
}