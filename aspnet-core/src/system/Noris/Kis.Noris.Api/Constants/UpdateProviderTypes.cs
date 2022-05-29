namespace Kis.Noris.Api.Constants
{
    /// <summary>
    /// Тип провайдера обновлений
    /// </summary>
    public enum UpdateProviderTypes
    {
        /// <summary>
        /// Обновление через файл
        /// </summary>
        SqlScriptUpdateProvider,

        /// <summary>
        /// Обновление через веб-сервис Росминздрава
        /// </summary>
        RosminzdravUpdateProvider
    }
}
