using System;
using System.Collections.Generic;
using Kis.Hr.Api.Dto;

namespace Kis.Hr.Api.Integration
{
    /// <summary>
    /// Посредством этого сервиса клиенты (адаптеры) производят загрузку информации о кандидатах
    /// из различных источников данных
    /// </summary>
    public interface IIntegrationCandidateService
    {
        /// <summary>
        /// На основе списка Id переданых из внешнего источника данных производится проверка о наличии
        /// в БД уже сохраненных ранее кандидатах
        /// </summary>
        /// <param name="candidateIdList"></param>
        /// <param name="dataSource">внешний источник данных</param>
        /// <returns></returns>
        IList<string> CheckCandidatesForExist(IList<string> candidateIdList, Guid dataSourceId);

        /// <summary>
        /// Передаются сведения о кандидатах, собранных из внешних источников данных,
        /// для их  сохраниния в БД.
        /// На основе определенной логики могут быть выявлены дублирующие кандидаты,
        /// сведения о которых поступили из разных источников данных
        /// </summary>
        /// <param name="candidates"></param>
        void PushCandidates(IList<CandidateDto>candidates);
    }
}
