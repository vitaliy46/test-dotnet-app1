using Abp.EntityFrameworkCore;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Entity;

namespace Kis.Investors.Dao.Repositories
{
    public class InvestedProjectRepository : InvestorsRepositoryBase<InvestedProject>, IInvestedProjectRepository
    {
        public InvestedProjectRepository(IDbContextProvider<InvestorsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}