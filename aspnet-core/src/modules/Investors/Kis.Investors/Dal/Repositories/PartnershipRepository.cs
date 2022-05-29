using Abp.EntityFrameworkCore;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Entity;


namespace Kis.Investors.Dao.Repositories
{
    public class PartnershipRepository : InvestorsRepositoryBase<Partnership>, IPartnershipRepository
    {
        public PartnershipRepository(IDbContextProvider<InvestorsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}