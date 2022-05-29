using System;
using Abp.Domain.Repositories;
using Kis.Investors.Api.Entity;

namespace Kis.Investors.Api.Dao.Repositories
{
    /// <summary>
    /// Репозиторий для инвестора.
    /// </summary>
    public interface IPartnershipMemberRepository : IRepository<PartnershipMember, Guid>
    {
        
    }
}
