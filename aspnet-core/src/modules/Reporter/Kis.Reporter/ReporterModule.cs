using Abp.AutoMapper;
using Abp.Modules;
using It2g.Core;
using It2g.General.Api.Entity;
using It2g.Reporter.Dao;
using It2g.Reporter.Migrations;
using System.Data.Entity;
using System.Reflection;

namespace It2g.Reporter
{

    [DependsOn(
        typeof(CoreModule)
    )]
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class ReporterModule : AbpModule
    {
        public override void PreInitialize()
        {
            // Настройка контекста данных на мигрирование до последней версии
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ReporterDbContext, Configuration>());
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ReporterModule).Assembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(ReporterModule).Assembly));
        }

        /// <summary>
        /// Выполнение настроечной логики после завершения сборки контейнера
        /// </summary>
        public override void PostInitialize()
        {
        }
        
    }
}
