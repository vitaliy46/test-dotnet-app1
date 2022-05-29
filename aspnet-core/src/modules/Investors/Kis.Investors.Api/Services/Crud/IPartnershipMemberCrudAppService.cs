using System;
using Kis.Base.Services.Bl;
using Kis.Base.Services.Crud;
using Kis.Investors.Api.Dto;

namespace Kis.Investors.Api.Services
{
    public interface IPartnershipMemberCrudAppService : IAsyncCrudAppServiceBase<PartnershipMemberDto, Guid, PagedPartnershipMemberResultRequestDto, PartnershipMemberDto, PartnershipMemberDto, PartnershipMemberDto, PartnershipMemberDto>
    {
    }

    
}
