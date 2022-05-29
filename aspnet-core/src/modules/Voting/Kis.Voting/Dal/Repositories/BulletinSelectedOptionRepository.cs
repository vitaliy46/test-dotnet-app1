using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Dao.Repositories
{
    /// <summary>
    /// BulletinSelectedOption repository
    /// </summary>
    public class BulletinSelectedOptionRepository:VotingRepositoryBase<BulletinSelectedOption>, IBulletinSelectedOptionRepository
    {
        public BulletinSelectedOptionRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        { }

    }
}
