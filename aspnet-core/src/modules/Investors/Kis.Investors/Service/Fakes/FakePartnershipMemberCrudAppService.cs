using System;
using Kis.Base.Services.Fake;
using Kis.Investors.Api.Dto;
using Kis.Investors.Api.Services;

namespace Kis.Investors.Service.Fakes
{
    public class FakePartnershipMemberCrudAppService : FakeAsyncCrudServiceBase<PartnershipMemberDto, Guid>, IPartnershipMemberCrudAppService
    {
    }

}
