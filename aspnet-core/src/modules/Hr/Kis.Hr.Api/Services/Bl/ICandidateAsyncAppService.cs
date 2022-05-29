using System;
using Abp.Application.Services;
using Kis.Base.Services.Bl;
using Kis.General.Api.Dto;
using Kis.Hr.Api.Dto;

namespace Kis.Hr.Api.Services
{
    public interface ICandidateAsyncAppService : IApplicationService
    {
        /// <summary>
        /// Добавление кандидата
        /// </summary>
        /// <param name="person"></param>
        /// <param name="vacancy"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        CandidateDto Add(PersonDto person, VacancyDto vacancy, string source);

        /// <summary>
        /// Задание приоритетного вида связи
        /// </summary>
        /// <param name="candidate"></param>
        /// <param name="contact"></param>
        void SetPriorityCommunication(CandidateDto candidate, string contact);

        /// <summary>
        /// Отклонение кандидата
        /// </summary>
        /// <param name="candidate"></param>
        /// <param name="comment"></param>
        void Decline(CandidateDto candidate, string comment);

        /// <summary>
        /// Задание результата собеседования
        /// </summary>
        /// <param name="candidate"></param>
        /// <param name="resultId"></param>
        void SetInterviewResult(CandidateDto candidate, int resultId);

        /// <summary>
        /// Процесс подписания оффера компании с кандидатом.
        /// В перспективе здесь можно задействовать блокчейн для закрепления сошлашения 
        /// и наложения обязательств на компанию и кандидата.
        /// </summary>
        /// <param name="candidate"></param>
        /// <param name="offer">пока тип стороковый, но в последствии структуру оффера можно формализовать</param>
        void SignOffer(Guid candidateId, Guid organizationId, string offer);
    }
}
