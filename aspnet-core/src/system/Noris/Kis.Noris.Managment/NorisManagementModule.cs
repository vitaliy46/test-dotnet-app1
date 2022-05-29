using Abp.AutoMapper;
using Abp.Dependency;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Uow;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Kis.Core;
using Kis.Core.Configuration;
using Kis.Core.Logging;
using Kis.Core.Web;
using Kis.General;
using Kis.Hr.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kis.Hr
{
    [DependsOn(typeof(GeneralModule)
       )]
    public class NorisManagementModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            // Настройка контекста данных на мигрирование до последней версии
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HrDbContext, Configuration>());

            //Регистрация контекста БД в модуле
            //if (!SkipDbContextRegistration)
            //{
            //    Configuration.Modules.AbpEfCore().AddDbContext<HrDbContext>(options =>
            //    {
            //        if (options.ExistingConnection != null)
            //        {
            //            HrDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
            //        }
            //        else
            //        {
            //            HrDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            //        }
            //    });
            //}

            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(NorisManagementModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NorisManagementModule).Assembly);
        }
    }
}
