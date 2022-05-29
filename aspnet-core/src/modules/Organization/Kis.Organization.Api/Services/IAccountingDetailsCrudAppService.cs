using System;
using Kis.Base.Services.Crud;
using Kis.Organization.Api.Dto;

namespace Kis.Organization.Api.Services
{
    public interface IAccountingDetailsCrudAppService : IAsyncCrudAppService<AccountingDetailsDto, Guid>
    {
        
    }
}