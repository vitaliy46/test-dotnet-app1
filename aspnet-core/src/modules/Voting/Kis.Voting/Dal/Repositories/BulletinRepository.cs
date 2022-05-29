using System;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using Kis.Voting.Api.Dao.Repositories;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Dao.Repositories
{
    /// <summary>
    /// Bulletin repository
    /// </summary>
    public class BulletinRepository: VotingRepositoryBase<Bulletin>, IBulletinRepository
    {
        public BulletinRepository(IDbContextProvider<VotingDbContext> dbContextProvider) : base(dbContextProvider)
        { }

        #region Update not accessible

        public override Bulletin Update(Bulletin entity)
        {
            return null;
        }

        public override Bulletin Update(Guid id, Action<Bulletin> updateAction)
        {
            return null;
        }

        public override Task<Bulletin> UpdateAsync(Bulletin entity)
        {
            return null;
        }

        public override Task<Bulletin> UpdateAsync(Guid id, Func<Bulletin, Task> updateAction)
        {
            return null;
        }
        #endregion
    }
}
