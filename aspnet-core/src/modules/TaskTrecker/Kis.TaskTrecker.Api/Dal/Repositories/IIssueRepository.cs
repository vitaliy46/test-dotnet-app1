﻿using System;
using Abp.Domain.Repositories;
using Kis.TaskTrecker.Api.Entity;

namespace Kis.TaskTrecker.Api.Dao.Repositories
{
    public interface IIssueRepository : IRepository<Issue, Guid>
    {
    }
}
