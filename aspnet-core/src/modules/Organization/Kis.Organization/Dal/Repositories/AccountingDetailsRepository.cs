using Abp.EntityFrameworkCore;
using Kis.Organization.Api.Dal.Repositories;
using Kis.Organization.Api.Dao.Repositories;
using Kis.Organization.Api.Entity;
using Kis.Organization.Dao;
using Kis.Organization.Dao.Repositories;

namespace Kis.Organization.Dao.Repositories
{ /// <summary>
  /// Представляет репозиторий банковских реквезитов организации.
  /// </summary>
    public class AccountingDetailsRepository : OrganizationRepositoryBase<AccountingDetails>, IAccountingDetailsRepository
    {
        public AccountingDetailsRepository(IDbContextProvider<OrganizationDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
