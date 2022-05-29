using System;
using Abp.Domain.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Api.Dal.Repositories
{
    
    public interface IPersonUserRepository : IRepository<PersonUser, Guid>
    {
    }
}