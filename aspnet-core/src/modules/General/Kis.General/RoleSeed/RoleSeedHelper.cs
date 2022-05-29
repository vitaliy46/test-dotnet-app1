using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Microsoft.EntityFrameworkCore;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using Abp.Zero.Configuration;
using Kis.Authorization.Roles;
using Kis.EntityFrameworkCore;

namespace Kis.General.RoleSeed
{
    /// <summary>
    /// Класс для записи в БД ролей и их привилегий
    /// </summary>
    public static class RoleSeedHelper
    {
        private static List<StaticRoleDefinition> _roleList;
        private static AuthorizationProvider _authorizationProvider;

        // TODO: пока хардкодим TenantId в методах модулей PostInitialize, иначе не добавляются тестовые пользователи
        private static int? _tenantId;

        public static void SeedHostDb(IIocResolver iocResolver, List<StaticRoleDefinition> roleList, int? tenantId, AuthorizationProvider authorizationProvider)
        {
            _roleList = roleList;
            _tenantId = tenantId;
            _authorizationProvider = authorizationProvider;
            WithDbContext<KisDbContext>(iocResolver, SeedHostDb);
        }

        /// <summary>
        /// Проверяем есть ли роль в базе, если нет - записываем ее вместе с привилегиями
        /// </summary>
        /// <param name="context"></param>
        public static void SeedHostDb(KisDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            foreach (var staticRoleDefinition in _roleList)
            {
                // Получаем все привилегии для роли, определенные в AuthorizationProvider модуля
                var permissions = PermissionFinder
                    .GetAllPermissions(_authorizationProvider)
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) &&
                                staticRoleDefinition.GrantedPermissions.Contains(p.Name))
                    .ToList();

                // Пробуем получить роль из БД
                var role = context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == staticRoleDefinition.RoleName);

                // Если роли нет, добавляем ее в БД
                if (role == null)
                {
                    role = context.Roles
                        .Add(new Role(_tenantId, staticRoleDefinition.RoleName, staticRoleDefinition.RoleName)
                        {
                            IsStatic = true
                        }).Entity;

                    context.SaveChanges();
                }
                else
                {
                    // Если роль существует в БД, получаем существующие привилегии
                    var existingRolePermissions = context.RolePermissions.IgnoreQueryFilters().Where(x => x.RoleId == role.Id).ToList().Select(rolePermissionSetting => new Permission(rolePermissionSetting.Name)).ToList();

                    // Исключаем существующие привилегии, остаются только новые которые надо добавить
                    permissions = permissions.Select(p => p.Name).Except(existingRolePermissions.Select(ep => ep.Name)).Select(x => new Permission(x)).ToList();
                }

                // Если есть новые привилегии для роли, записываем их в БД
                if (permissions.Any())
                {
                    context.Permissions.AddRange(
                        permissions.Select(permission => new RolePermissionSetting
                            {
                                TenantId = _tenantId,
                                Name = permission.Name,
                                IsGranted = true,
                                RoleId = role.Id
                            }
                        )
                    );

                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Организуем трансзакцию для метода SeedHostDb, он выполняется либо полностью либо отказ всех действий
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="iocResolver"></param>
        /// <param name="contextAction"></param>
        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}
