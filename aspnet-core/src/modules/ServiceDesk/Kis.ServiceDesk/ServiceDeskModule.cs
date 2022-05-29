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
using Kis.ServiceDesk.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kis.ServiceDesk
{
    /// <summary>
    /// Модуль основных бизнес понятий системы Urish.
    /// Включает работу с персональными данными физических лиц,
    /// их документами и статусами, мед. организациями, их подразделениями, 
    /// сотрудниками и должностями.
    /// Предназначен для предоставления своих данных для других 
    /// более специфичных прикладных модулей системы.
    /// </summary>
    [DependsOn(typeof(GeneralModule)
       // ,typeof(AbpEntityFrameworkCoreModule)
        )]
    public class ServiceDeskModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            //Регистрация контекста БД в модуле
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<ServiceDeskDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        ServiceDeskDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        ServiceDeskDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }

            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(ServiceDeskModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ServiceDeskModule).Assembly);
        }

        /// <summary>
        /// Выполнение настроечной логики после завершения сборки контейнера
        /// </summary>
        public override void PostInitialize()
        {
        }
        
    }
}
