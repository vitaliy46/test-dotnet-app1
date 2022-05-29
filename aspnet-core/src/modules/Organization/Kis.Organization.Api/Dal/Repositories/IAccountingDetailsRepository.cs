using System;
using Abp.Domain.Repositories;
using Kis.Organization.Api.Entity;

namespace Kis.Organization.Api.Dao.Repositories
{
    /// <summary>
    /// Банковские реквизиты организации
    /// </summary>
    public interface IAccountingDetailsRepository : IRepository<AccountingDetails, Guid>
    {
    }
}
