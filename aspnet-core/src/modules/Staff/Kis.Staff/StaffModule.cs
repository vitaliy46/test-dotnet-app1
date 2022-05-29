using Abp.AutoMapper;
using Abp.Dependency;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.EntityFrameworkCore.Uow;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Kis.Base;
using Kis.Core;
using Kis.Core.Configuration;
using Kis.Core.Logging;
using Kis.Core.Web;
using Kis.General;
using Kis.Organization;
using Kis.Staff.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kis.Staff
{
    [DependsOn(
        //typeof(BaseModule),
        //typeof(AbpEntityFrameworkCoreModule),
        typeof(OrganizationModule))]
    public class StaffModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            //Регистрация контекста БД в модуле
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<StaffDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        StaffDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        StaffDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }

            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(StaffModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(StaffModule).Assembly);
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
