using System.Collections.Generic;
using Abp.AutoMapper;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Zero.Configuration;
using Kis.Base;
using Kis.General.Authorization;
using Kis.General.Authorization.Roles;
using Kis.General.Dao;
using Kis.General.RoleSeed;

namespace Kis.General
{
    /// <summary>
    /// Модуль основных бизнес понятий системы Urish.
    /// Включает работу с персональными данными физических лиц,
    /// их документами и статусами, мед. организациями, их подразделениями, 
    /// сотрудниками и должностями.
    /// Предназначен для предоставления своих данных для других 
    /// более специфичных прикладных модулей системы.
    /// </summary>
    [DependsOn(typeof(BaseModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class GeneralModule : AbpModule
    {
        private List<StaticRoleDefinition> _roleList;

        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            // Настройка контекста данных на мигрирование до последней версии
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GeneralDbContext, Configuration>());
            //Регистрация контекста БД в модуле
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<GeneralDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        GeneralDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        GeneralDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }

            // Configure roles
            _roleList = GeneralRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(GeneralModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GeneralModule).Assembly);
        }

        /// <summary>
        /// Выполнение настроечной логики после завершения сборки контейнера
        /// </summary>
        public override void PostInitialize()
        {
            // TODO: пока хардкодим TenantId, иначе не добавляются тестовые пользователи
            RoleSeedHelper.SeedHostDb(IocManager, _roleList, 1, new GeneralAuthorizationProvider());
        }
        
    }
}
