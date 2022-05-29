using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Kis.Base
{
    /// <summary>
    /// Модуль ядра системы Urish. Не несёт в себе никакой бизнес-специфики. 
    /// Подключает конвенции регистрации для
    /// основных видов служб: репозиториев данных, сервисов и других компонентов,
    /// а также конфигурационных сервисов.
    /// </summary>
    [DependsOn(typeof(BaseModule)
        ,typeof(KisWebCoreModule))]
    public class BaseWebModule : AbpModule
    {
        /// <summary>
        /// Предварительное подключение конвенций регистрации для контейнера,
        /// для автоматической регистрации контекстов данных, конфигураций и 
        /// компонентов системы (репозиториев и сервисов).
        /// </summary>
        public override void PreInitialize()
        {
            //Настройка конфигурации Automapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                config.AddProfiles(typeof(BaseWebModule).Assembly));
        }

        /// <summary>
        /// Регистрация компонентов текущей сборки и сборки модели справочников в контейнере
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BaseWebModule).GetAssembly());

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
