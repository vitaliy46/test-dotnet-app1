using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Dao.Repositories
{
    public class VoteLinkRepository: VotingRepositoryBase<VoteLink>, IVoteLinkRepository
    {
        public VoteLinkRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
