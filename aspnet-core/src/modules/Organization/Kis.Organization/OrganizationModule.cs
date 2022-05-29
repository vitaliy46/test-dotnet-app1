using Abp.AutoMapper;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Kis.General;
using Kis.Organization.Dao;

namespace Kis.Organization
{
    [DependsOn(
        //typeof(BaseModule),
        //typeof(AbpEntityFrameworkCoreModule),
        typeof(GeneralModule))]
    public class OrganizationModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            //Регистрация контекста БД в модуле
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<OrganizationDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        OrganizationDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        OrganizationDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }

            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(OrganizationModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrganizationModule).Assembly);
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
