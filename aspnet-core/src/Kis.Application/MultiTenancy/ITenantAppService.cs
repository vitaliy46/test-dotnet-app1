using Abp.Application.Services;
using Kis.MultiTenancy.Dto;

namespace Kis.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

