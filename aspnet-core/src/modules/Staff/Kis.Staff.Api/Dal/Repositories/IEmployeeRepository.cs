﻿using System;
using Abp.Domain.Repositories;
using Kis.Staff.Api.Entity;

namespace Kis.Staff.Api.Dao.Repositories
{
    /// <summary>
    /// Интерфейс репозитория для <see cref="Employee"/>.
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
    }
}
