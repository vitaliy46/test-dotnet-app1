using System;
using Abp.Application.Services;

namespace Kis.Voting.Api.Services.Bl
{
    /// <summary>
    /// Сервис предоставляющий различные виды подсчета голосования: мажоритарное, альтернативное, рейтинговое 
    /// </summary>
    public interface IVotingTypeService : IApplicationService
    {
        /// <summary>
        /// Предоставляет сервис для подсчета голосов
        /// В настройках системы голосования предварительно должен выбираться вид подсчета голосов.
        /// Это можно делать непосредственно для каждого голосования или применять
        /// один вид для всех голосований, предварительно указав его в настройках
        /// </summary>
        /// <returns></returns>
        IVotingApplicationService GetVotingService();

        /// <summary>
        /// TODO пока в порядке бреда
        /// </summary>
        /// <param name="votingType"></param>
        /// <returns></returns>
        IVotingApplicationService GetVotingService(Guid  votingType);
    }
}
