using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.Authorization.Accounts.Dto;

namespace Kis.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
