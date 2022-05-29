using System.Collections.Generic;
using Abp.AutoMapper;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using Kis.Authorization.Users;
using Kis.General.RoleSeed;
using Kis.Investors.Authorization;
using Kis.Investors.Authorization.Roles;
using Kis.Investors.Dao;
using Kis.Organization;
using Kis.TaskTrecker;

namespace Kis.Investors
{
    /// <summary>
    /// Модуль основных бизнес понятий системы Urish.
    /// Включает работу с персональными данными физических лиц,
    /// их документами и статусами, мед. организациями, их подразделениями, 
    /// сотрудниками и должностями.
    /// Предназначен для предоставления своих данных для других 
    /// более специфичных прикладных модулей системы.
    /// </summary>
    [DependsOn(typeof(TaskTreckerModule)
        , typeof(OrganizationModule))]
    public class InvestorsModule : AbpModule
    {
        private List<StaticRoleDefinition> _roleList;

        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<InvestorsAuthorizationProvider>();
            //Регистрация контекста БД в модуле
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<InvestorsDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        InvestorsDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        InvestorsDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }

            // Configure roles
            _roleList = InvestorsRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(InvestorsModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(InvestorsModule).GetAssembly());
        }

        /// <summary>
        /// Выполнение настроечной логики после завершения сборки контейнера
        /// </summary>
        public override void PostInitialize()
        {
            // TODO: пока хардкодим TenantId, иначе не добавляются тестовые пользователи
            RoleSeedHelper.SeedHostDb(IocManager, _roleList, 1, new InvestorsAuthorizationProvider());
        }
    }
}
