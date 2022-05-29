
using Abp.BackgroundJobs;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Kis.Configuration;
using Kis.Crypto;
using Kis.General.Web;
using Kis.Investors.Web;
using Kis.Investors.WebHost.AppSettings;
using Kis.Investors.WebHost.Seed;
using Kis.Investors.WebHost.TestData;
using Kis.Organization.Web;
using Kis.TaskTrecker.Web;
using Kis.Voting.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Kis.Web.Host.Startup
{
    [DependsOn(typeof(WebInvestorModule), 
               typeof(WebVotingModule),
               typeof(WebOrganizationModule),
               typeof(WebGeneralModule),
               typeof(WebTaskTreckerModule),
               typeof(CryptoModule))]
    public class WebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public WebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.BackgroundJobs.UseHangfire();
            Configuration.Settings.Providers.Add<ApplicationSettingProvider>();
#if DEBUG
            ///Временно отключена валидация параметров методов всех контролеров
            //Configuration.Modules.AbpAspNetCore().IsValidationEnabledForControllers = false;
#endif
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebHostModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }
    }
}
