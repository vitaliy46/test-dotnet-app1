using System;
using Kis.Base.Services.Bl;
using Kis.Staff.Api.Dto;

namespace Kis.Staff.Api.Services
{
    public interface IPositionAsyncCrudAppService : IAsyncCrudAppService<PositionDto, Guid>
    {
    }
}
