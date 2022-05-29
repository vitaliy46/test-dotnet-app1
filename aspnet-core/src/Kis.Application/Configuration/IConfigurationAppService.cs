using System.Threading.Tasks;
using Kis.Configuration.Dto;

namespace Kis.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
