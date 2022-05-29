using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Dto.Bulletin;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Api.Services.Bl
{
    /// <summary>
    /// Сервис управления функциями модуля голосования 
    /// </summary>
    public interface IVotingApplicationService : IApplicationService
    {
        /// <summary>
        /// Возвращает PagedResultDto с голосованиями для текущего пользователя
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<VoteShortDto>> GetVotesPagedResultDto();

        /// <summary>
        /// В зависимости от типа механизма подсчета голосов производится выбор соответсвующего
        /// алгоритма (стратегии) и рассчет голосов
        /// TODO пока расчет производится одним простым алгоритмом
        /// </summary>
        Task CalculateAndSaveResult(Guid voteId);

        /// <summary>
        /// Возвращает результат подсчета голосов в Xml формате
        /// </summary>
        /// <param name="voteId"></param>
        /// <returns></returns>
        Task<byte[]> GetResultReportAsync(Guid voteId);

        /// <summary>
        /// Публикует голосование
        /// </summary>
        /// <param name="vote"></param>
        /// <returns></returns>
        Task<VoteDto> Publish(VoteDto vote);

        /// <summary>
        /// Сохраняет голосование вместе со списком участников, переданых в составе 
        /// голосования
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<VoteDto> SaveAsync(VoteDto input);

        /// <summary>
        /// Участник проголосовал за какой либо пункт
        /// </summary>
        /// <param name="input"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<(BulletinDto bulletin, float votersPersent)> Voted(BulletinDto input);
    }
}
