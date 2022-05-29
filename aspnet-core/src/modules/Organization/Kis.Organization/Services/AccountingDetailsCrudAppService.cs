using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Organization.Api.Dto;
using Kis.Organization.Api.Entity;
using Kis.Organization.Api.Services;

namespace Kis.Organization.Services
{
    public class AccountingDetailsCrudAppService : AsyncCrudAppServiceBase<AccountingDetails, AccountingDetailsDto, Guid>, IAccountingDetailsCrudAppService
    {
        public AccountingDetailsCrudAppService([NotNull]IRepository<AccountingDetails, Guid> repository) : base(repository)
        {
        }
    }
}
