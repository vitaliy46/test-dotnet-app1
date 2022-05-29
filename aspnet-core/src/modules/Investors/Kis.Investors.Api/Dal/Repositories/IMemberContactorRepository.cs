using System;
using Abp.Domain.Repositories;
using Kis.Investors.Api.Entity;

namespace Kis.Investors.Api.Dao.Repositories
{
    public interface IMemberContactorRepository : IRepository<MemberContactor, Guid>
    {
        
    }
}
