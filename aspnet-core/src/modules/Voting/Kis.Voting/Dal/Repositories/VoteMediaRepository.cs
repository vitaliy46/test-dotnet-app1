using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Dao.Repositories
{
    /// <summary>
    /// VoteMedia repository
    /// </summary>
    public class VoteMediaRepository : VotingRepositoryBase<VoteMedia>, IVoteMediaRepository
    {
        public VoteMediaRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
