using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;


namespace Kis.Investors.Web
{
    [DependsOn(typeof(InvestorsModule))]
    public class WebInvestorModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(WebInvestorModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {

            IocManager.RegisterAssemblyByConvention(typeof(WebInvestorModule).GetAssembly());
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
