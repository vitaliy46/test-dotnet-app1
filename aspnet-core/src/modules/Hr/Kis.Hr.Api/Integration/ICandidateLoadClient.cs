using System.Collections.Generic;
using Kis.Hr.Api.Dto;

namespace Kis.Hr.Api.Integration
{
    /// <summary>
    /// Определяет взаимодействие с клиентом для формирования им запросов 
    /// во внешние источники получения информации о кандидатах (рекрутинговые системы)
    /// Для каждого источника создается свой клиент (адаптер)
    /// </summary>
    public interface ICandidateLoadClient
    {
        /// <summary>
        /// Имя загрузчика данных, которое должно быть синхронизировано
        /// с источником данных, из которого он будет выгружать сведения о кандидатах.
        /// По этому именти менеджер загрузки будт находить и вызывать клиента загрузки.
        /// </summary>
        string CandidateLoaderName { get; }

        IList<CandidateDto> LoadCandidate(CandidateLoadFilter filter);
    }

  
}
