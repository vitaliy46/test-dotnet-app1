using Abp.EntityFrameworkCore;
using Kis.General.Api.Entity;
using Kis.General.Dao;
using Kis.General.Dao.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Kis.General.Api.Dal.Repositories;

namespace Kis.General.Dal.Repositories
{
    public class PersonUserRepository : GeneralRepositoryBase<PersonUser, Guid>, IPersonUserRepository
    {
        public PersonUserRepository(IDbContextProvider<GeneralDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
