using System;
using Kis.Base.Services.Crud;
using Kis.General.Api.Dto;

namespace Kis.General.Api.Services.Crud
{
    public interface IContactCrudAppService : IAsyncCrudAppService<ContactDto, Guid>
    {
    }

    
}
