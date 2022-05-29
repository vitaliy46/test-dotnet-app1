using Abp.EntityFrameworkCore;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Dao.Repositories
{
    public class KarmaVoteRepository : StaffRepositoryBase<KarmaVote>, IKarmaVoteRepository
    {
        public KarmaVoteRepository(IDbContextProvider<StaffDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}