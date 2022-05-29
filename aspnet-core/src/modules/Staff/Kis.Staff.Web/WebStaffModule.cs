using Abp.AutoMapper;
using Abp.Modules;
using Kis.Web.Core;

namespace Kis.Staff.Web
{

    [DependsOn(typeof(StaffModule),
        typeof(WebCoreModule))]
    public class WebStaffModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            // Настройка контекста данных на мигрирование до последней версии
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HrDbContext, Configuration>());

            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(WebStaffModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            var thisAssembly = typeof(WebStaffModule).Assembly;
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
