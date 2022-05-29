using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using System;
using Kis.Base.Services.Crud;
using Kis.General.Api.Dto;


namespace Kis.General.Api.Services.Crud
{
    public interface IStateCrudAppService : IAsyncCrudAppServiceBase<StateDto, Guid, PagedStateResultRequestDto, StateDto, StateDto, StateDto, StateDto>
    {
    }
}
