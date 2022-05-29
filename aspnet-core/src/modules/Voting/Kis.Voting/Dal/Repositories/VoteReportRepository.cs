using Kis.Voting.Api.Entity;
using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;

namespace Kis.Voting.Dao.Repositories
{
    /// <summary>
    /// VoteReport repository 
    /// </summary>
    public class VoteReportRepository : VotingRepositoryBase<VoteReport>, IVoteReportRepository
    {
        public VoteReportRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
