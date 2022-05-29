using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Dao.Repositories
{
    /// <summary>
    /// Vote Repository
    /// </summary>
    public class VoteRepository: VotingRepositoryBase<Vote>, IVoteRepository
    {
        public VoteRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
