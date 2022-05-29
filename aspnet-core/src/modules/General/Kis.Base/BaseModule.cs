using System;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;



namespace Kis.Base
{
    /// <summary>
    /// Модуль ядра системы Urish. Не несёт в себе никакой бизнес-специфики. 
    /// Подключает конвенции регистрации для
    /// основных видов служб: репозиториев данных, сервисов и других компонентов,
    /// а также конфигурационных сервисов.
    /// </summary>
    [DependsOn(typeof(KisApplicationModule))]
    public class BaseModule : AbpModule
    {
        /// <summary>
        /// Предварительное подключение конвенций регистрации для контейнера,
        /// для автоматической регистрации контекстов данных, конфигураций и 
        /// компонентов системы (репозиториев и сервисов).
        /// </summary>
        public override void PreInitialize()
        {
            IocManager.AddConventionalRegistrar(new ConfigurationConventionalRegistrar());
            IocManager.AddConventionalRegistrar(new ComponentConventionalRegistrar());

            // включение поддержки внедрения коллекции зависимостей.
            // Эта настройка позволяет контейнеру внедрять зависимости в свойства вида T[], IList<T>, IEnumerable<T>, ICollection<T>,
            // пытаясь подставить в них коллекцию со всеми зайденными реализациями типа T. 
            // Если ни одной зависимости типа T нет, контейнер внедрит пустую коллекцию
            IocManager.IocContainer.Kernel.Resolver.AddSubResolver(new CollectionResolver(IocManager.IocContainer.Kernel, true));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки и сборки модели справочников в контейнере
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BaseModule).Assembly);

            // регистрация делегата-фабрики компонентов для возможности другим конпонентам
            // опосредованно запрашивать зависимости из контейнера
            IocManager.IocContainer.Register(
                Component.For<Func<Type, string, object>>().Instance((type, name) => IocManager.Resolve(type)));
        }

        /// <summary>
        /// Выполнение настроечной логики после завершения сборки контейнера
        /// </summary>
        public override void PostInitialize()
        {
        }

      
    }
}
