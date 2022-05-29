using System;
using Kis.Base.Services.Bl;
using Kis.Base.Services.Crud;
using Kis.Investors.Api.Dto;

namespace Kis.Investors.Api.Services
{
    public interface IPartnershipCrudAppService : IAsyncCrudAppService<PartnershipDto, Guid>
    {
    }

    
}
