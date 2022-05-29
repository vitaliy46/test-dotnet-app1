using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Dao.Repositories
{
    public class VoteOptionRepository: VotingRepositoryBase<VoteOption>, IVoteOptionRepository
    {
        public VoteOptionRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        { }
    }

}