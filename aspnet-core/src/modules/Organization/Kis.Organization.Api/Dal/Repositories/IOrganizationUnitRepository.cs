using System;
using Abp.Domain.Repositories;
using Kis.Organization.Api.Entity;

namespace Kis.Organization.Api.Dao.Repositories
{
    /// <summary>
    /// Представляет репозиторий организационных единиц.
    /// </summary>
    public interface IOrganizationUnitRepository : IRepository<OrganizationUnit, Guid>
    {
    }
}
