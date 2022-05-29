using Abp.EntityFrameworkCore;
using Kis.Hr.Api.Dao.Repositories;
using Kis.Hr.Api.Entity;

namespace Kis.Hr.Dao.Repositories
{
    public class CandidateRepository : HrRepositoryBase<Candidate>, ICandidateRepository
    {
        public CandidateRepository(IDbContextProvider<HrDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
