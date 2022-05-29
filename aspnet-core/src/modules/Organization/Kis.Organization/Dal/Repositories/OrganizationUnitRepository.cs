using Abp.EntityFrameworkCore;
using Kis.Organization.Api.Dao.Repositories;
using Kis.Organization.Api.Entity;

namespace Kis.Organization.Dao.Repositories
{
    /// <summary>
    /// Представляет репозиторий организационных единиц.
    /// </summary>
    public class OrganizationUnitRepository : OrganizationRepositoryBase<OrganizationUnit>, IOrganizationUnitRepository
    {
        public OrganizationUnitRepository(IDbContextProvider<OrganizationDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
