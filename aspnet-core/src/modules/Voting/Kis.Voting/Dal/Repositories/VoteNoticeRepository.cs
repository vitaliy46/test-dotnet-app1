using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Dao.Repositories
{
    /// <summary>
    /// VoteNotice repository
    /// </summary>
    public class VoteNoticeRepository: VotingRepositoryBase<VoteNotice>, IVoteNoticeRepository
    {
        public VoteNoticeRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        { }
    }

}
