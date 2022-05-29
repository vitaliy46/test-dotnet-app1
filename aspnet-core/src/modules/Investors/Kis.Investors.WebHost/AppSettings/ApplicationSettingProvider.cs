using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Localization;

namespace Kis.Investors.WebHost.AppSettings
{
    public class ApplicationSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition("SmtpServerAddress",
                    "smtp.yandex.ru",
                    scopes: SettingScopes.Application | SettingScopes.Tenant,
                    displayName: new FixedLocalizableString("smpt server address")
                    
                ),
                new SettingDefinition("SmtpServerPort",
                    "587",
                    scopes: SettingScopes.Application | SettingScopes.Tenant,
                    displayName: new FixedLocalizableString("smpt server port")
                ),
                new SettingDefinition("PartnershipId",
                    "00000000-0000-0000-0000-000000000000",
                    scopes: SettingScopes.Application | SettingScopes.Tenant
                   
                ),
            };
        }
    }
}
