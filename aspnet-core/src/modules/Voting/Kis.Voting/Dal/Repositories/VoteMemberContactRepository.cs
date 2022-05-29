using Kis.Voting.Api.Entity;
using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;

namespace Kis.Voting.Dao.Repositories
{
    /// <summary>
    /// NoticeContact repository
    /// </summary>
    public class VoteMemberContactRepository : VotingRepositoryBase<VoteMemberContact>, IVoteMemberContactRepository
    {
        public VoteMemberContactRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
