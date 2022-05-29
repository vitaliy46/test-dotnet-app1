using System;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Kis.Investors.Api.Dao.Repositories;
using Kis.Investors.Api.Entity;

namespace Kis.Investors.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для <see cref="Project"/>
    /// </summary>
    public class InvestorRepository : InvestorsRepositoryBase<Investor>, IInvestorRepository
    {
        public InvestorRepository(IDbContextProvider<InvestorsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}