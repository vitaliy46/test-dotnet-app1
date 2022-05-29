using System.Collections.Generic;
using Abp.AutoMapper;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Zero.Configuration;
using Kis.General;
using Kis.General.RoleSeed;
using Kis.TaskTrecker.Authorization;
using Kis.TaskTrecker.Authorization.Roles;
using Kis.TaskTrecker.Dal;

namespace Kis.TaskTrecker
{
    /// <summary>
    /// Модуль основных бизнес понятий системы Urish.
    /// Включает работу с персональными данными физических лиц,
    /// их документами и статусами, мед. организациями, их подразделениями, 
    /// сотрудниками и должностями.
    /// Предназначен для предоставления своих данных для других 
    /// более специфичных прикладных модулей системы.
    /// </summary>
    [DependsOn(typeof(GeneralModule))]
    public class TaskTreckerModule : AbpModule
    {
        private List<StaticRoleDefinition> _roleList;

        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TaskTreckerAuthorizationProvider>();
            //Регистрация контекста БД в модуле
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<TaskTreckerDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        TaskTreckerDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        TaskTreckerDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }

            // Configure roles
            _roleList = TaskTreckerRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(TaskTreckerModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TaskTreckerModule).Assembly);
        }

        /// <summary>
        /// Выполнение настроечной логики после завершения сборки контейнера
        /// </summary>
        public override void PostInitialize()
        {
            // TODO: пока хардкодим TenantId, иначе не добавляются тестовые пользователи
            RoleSeedHelper.SeedHostDb(IocManager, _roleList, 1, new TaskTreckerAuthorizationProvider());
        }
        
    }
}
