using System;

namespace Kis.Hr.Api.Integration
{
    /// <summary>
    /// Управляет процессом загрузки сведений о кандидатах их внешних источников
    /// данных.
    /// Самый простой сценари - это директивное обращение к определенному клиенту (адаптеру)
    /// для инициализации процесса загрузки. Долее сложный сценарий может предусматривать регламентную загрузку
    /// по установленному режиму для каждого источника данных
    /// </summary>
    public interface IIntegrationCandidateLoadManager
    {
        /// <summary>
        /// Инициализирует загрузку данных о кандидатах из указанного источника
        /// </summary>
        /// <param name="infomationSourceId"></param>
        void LoadCandidates(Guid infomationSourceId);
    }
}
