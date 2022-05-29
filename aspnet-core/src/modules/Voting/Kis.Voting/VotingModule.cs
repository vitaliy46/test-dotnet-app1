using System.Collections.Generic;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Runtime.Session;
using Abp.Zero.Configuration;
using Kis.Authorization.Users;
using Kis.General;
using Kis.General.RoleSeed;
using Kis.MultiTenancy;
using Kis.Voting.Authorization;
using Kis.Voting.Authorization.Roles;
using Kis.Voting.Dao;
using Kis.Voting.Services.Bl;

namespace Kis.Voting
{
    /// <summary>
    /// Модуль основных бизнес понятий системы Urish.
    /// Включает работу с персональными данными физических лиц,
    /// их документами и статусами, мед. организациями, их подразделениями, 
    /// сотрудниками и должностями.
    /// Предназначен для предоставления своих данных для других 
    /// более специфичных прикладных модулей системы.
    /// </summary>
    [DependsOn(
        typeof(GeneralModule) 
        //typeof(AbpEntityFrameworkCoreModule)
        )]
    public class VotingModule : AbpModule
    {
        private List<StaticRoleDefinition> _roleList;

        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<VoteAuthorizationProvider>();
            // Регистрация контекста БД в модуле
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<VotingDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        VotingDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        VotingDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }

            // Configure roles
            _roleList = VotingRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(VotingModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки в контейнере
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VotingModule).Assembly);
            IocManager.Register<MajorityVoteCalculator, MajorityVoteCalculator>(DependencyLifeStyle.Transient);
        }

        /// <summary>
        /// Выполнение настроечной логики после завершения сборки контейнера
        /// </summary>
        public override void PostInitialize()
        {
            // TODO: пока хардкодим TenantId, иначе не добавляются тестовые пользователи
            RoleSeedHelper.SeedHostDb(IocManager, _roleList, 1, new VoteAuthorizationProvider());
        }
    }
}
