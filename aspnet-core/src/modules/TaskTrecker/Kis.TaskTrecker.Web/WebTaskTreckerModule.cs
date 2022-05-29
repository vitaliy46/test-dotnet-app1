using Abp.AutoMapper;
using Abp.Modules;
using Kis.Base;
using Kis.General;

namespace Kis.TaskTrecker.Web
{
    [DependsOn(typeof(GeneralModule),
        typeof(BaseWebModule))]
    public class WebTaskTreckerModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(WebTaskTreckerModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            var thisAssembly = typeof(WebTaskTreckerModule).Assembly;
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
