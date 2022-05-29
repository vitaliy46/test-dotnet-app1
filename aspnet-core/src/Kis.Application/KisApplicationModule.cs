using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Kis.Authorization;

namespace Kis
{
    [DependsOn(
        typeof(KisCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class KisApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<KisAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(KisApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
