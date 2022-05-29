using Abp.Dependency;

namespace Kis.General
{
    /// <summary>
    /// Класс регистратора для компонентов, используемый контейнером зависимостей,
    /// для автоматической регистрации классов на основе конвенций (правил).
    /// Регистратор регистрирует классы, помеченные атрибутами <see cref="ServiceAttribute"/>, 
    /// <see cref="RepositoryAttribute"/>, <see cref="ComponentAttribute"/>
    /// на их собственный тип
    /// </summary>
    internal class ComponentConventionalRegistrar : IConventionalDependencyRegistrar
    {
        public void RegisterAssembly(IConventionalRegistrationContext context)
        {
            
        }

       
    }
}
