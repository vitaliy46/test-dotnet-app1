using Abp.AutoMapper;
using Abp.Modules;
using Kis.Base;

namespace Kis.Voting.Web
{

    [DependsOn(typeof(VotingModule),
        typeof(BaseWebModule))]
    public class WebVotingModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            //Configuration.MultiTenancy.IgnoreFeatureCheckForHostUsers = true;

            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(WebVotingModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            var thisAssembly = typeof(WebVotingModule).Assembly;
            IocManager.RegisterAssemblyByConvention(thisAssembly);
        }

        /// <summary>
        /// Выполнение настроечной логики после завершения сборки контейнера
        /// </summary>
        public override void PostInitialize()
        {
        }
        
        /// <summary>
        /// This method is called when the application is being shutdown.
        /// </summary>
        public override void Shutdown()
        {

        }


    }
}
