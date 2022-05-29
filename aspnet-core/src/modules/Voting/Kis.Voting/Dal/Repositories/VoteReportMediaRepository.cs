using Kis.Voting.Api.Entity;
using System;
using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;

namespace Kis.Voting.Dao.Repositories
{
    /// <summary>
    /// VoteReportMedia repository
    /// </summary>
    public class VoteReportMediaRepository : VotingRepositoryBase<VoteReportMedia, Guid>, IVoteReportMediaRepository
    {
        public VoteReportMediaRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
