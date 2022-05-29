using Abp.EntityFrameworkCore;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Entity;

namespace Kis.Investors.Dao.Repositories
{
    public class MemberContactorRepository : InvestorsRepositoryBase<MemberContactor>, IMemberContactorRepository
    {
        public MemberContactorRepository(IDbContextProvider<InvestorsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}