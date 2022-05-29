using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kis.Base.Services.Bl;
using Kis.Base.Services.Crud;
using Kis.General.Api.Dto;

namespace Kis.General.Api.Services.Crud
{
    public interface IPersonContactCrudAppService : IAsyncCrudAppService<PersonContactDto, Guid>
    {
    }
}
