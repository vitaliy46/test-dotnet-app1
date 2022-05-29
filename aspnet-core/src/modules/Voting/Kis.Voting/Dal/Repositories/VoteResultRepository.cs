using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Dao.Repositories
{
    /// <summary>
    /// VoteResult Repository
    /// </summary>
 public   class VoteResultRepository: VotingRepositoryBase<VoteResult>, IVoteResultRepository
    {
        public VoteResultRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        { }
    }
}
