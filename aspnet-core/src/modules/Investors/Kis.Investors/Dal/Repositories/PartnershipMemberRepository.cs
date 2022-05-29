using Abp.EntityFrameworkCore;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Entity;

namespace Kis.Investors.Dao.Repositories
{
    public class PartnershipMemberRepository : InvestorsRepositoryBase<PartnershipMember>, IPartnershipMemberRepository
    {
        public PartnershipMemberRepository(IDbContextProvider<InvestorsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}