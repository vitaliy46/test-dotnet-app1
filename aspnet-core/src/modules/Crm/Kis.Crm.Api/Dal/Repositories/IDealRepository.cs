﻿using System;
using Abp.Domain.Repositories;
using Kis.Crm.Api.Entity;

namespace Kis.Crm.Api.Dao.Repositories
{
    public interface IDealRepository : IRepository<Deal, Guid>
    {
    }
}
