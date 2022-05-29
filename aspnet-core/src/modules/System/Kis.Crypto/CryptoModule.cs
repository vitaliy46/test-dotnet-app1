using Abp.Modules;

namespace Kis.Crypto
{
    [DependsOn(typeof(KisCoreModule))]
    public class CryptoModule : AbpModule
    {
        public override void PreInitialize()
        {
        }
        
        public override void Initialize()
        {
            /// <summary>
            /// Регистрация компонентов текущей сборки в контейнере
            /// </summary>
            IocManager.RegisterAssemblyByConvention(typeof(CryptoModule).Assembly);
        }

        /// <summary>
        /// Выполнение настроечной логики после завершения сборки контейнера
        /// </summary>
        public override void PostInitialize()
        {
        }
        
    }
}
