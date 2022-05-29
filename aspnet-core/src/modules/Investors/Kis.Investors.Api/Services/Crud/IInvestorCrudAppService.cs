using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kis.Base.Services.Crud;
using Kis.Investors.Api.Dto;

namespace Kis.Investors.Api.Services
{
    public interface IInvestorCrudAppService : IAsyncCrudAppServiceBase<InvestorDto, Guid, PagedInvestorRequestDto, InvestorDto, InvestorDto, InvestorDto, InvestorDto>
    {}
}
