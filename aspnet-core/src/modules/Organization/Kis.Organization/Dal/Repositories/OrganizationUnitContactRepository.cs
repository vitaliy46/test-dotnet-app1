using Abp.EntityFrameworkCore;
using Kis.Organization.Api.Dao.Repositories;
using Kis.Organization.Api.Entity;

namespace Kis.Organization.Dao.Repositories
{
    /// <summary>
    /// Представляет репозиторий организационных единиц.
    /// </summary>
    public class OrganizationUnitContactRepository : OrganizationRepositoryBase<OrganizationUnitContact>, IOrganizationUnitContactRepository
    {
        public OrganizationUnitContactRepository(IDbContextProvider<OrganizationDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
