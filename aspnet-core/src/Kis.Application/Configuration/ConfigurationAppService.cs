using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Kis.Configuration.Dto;

namespace Kis.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : KisAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
