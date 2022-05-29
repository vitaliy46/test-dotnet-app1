using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.Sessions.Dto;

namespace Kis.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
