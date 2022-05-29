using Kis.Voting.Api.Entity;
using System;
using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;

namespace Kis.Voting.Dao.Repositories
{
    /// <summary>
    /// VoteSettings repository 
    /// </summary>
    public class VoteSettingsRepository : VotingRepositoryBase<VoteSettings, Guid>, IVoteSettingsRepository
    {
        public VoteSettingsRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
