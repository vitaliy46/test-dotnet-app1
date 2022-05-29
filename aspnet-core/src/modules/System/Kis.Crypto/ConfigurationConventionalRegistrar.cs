using Abp.Dependency;

namespace Kis.Crypto
{
    /// <summary>
    /// Класс регистратора для контекстов данных, используемый контейнером зависимостей,
    /// для автоматической регистрации классов на основе конвенций (правил).
    /// Регистратор регистрирует классы, помеченные атрибутом <see cref="ConfigurationAttribute"/>
    /// на их собственный тип
    /// </summary>
    internal class ConfigurationConventionalRegistrar : IConventionalDependencyRegistrar
    {
        public void RegisterAssembly(IConventionalRegistrationContext context)
        {
        }
    }
}
