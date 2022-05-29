using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Api.Services.Bl
{
    /// <summary>
    /// Предоставляет контекст к которому относится голосование
    /// Под контекстом голосования могут подразумеваться: проекты, собрания, форумы и любые другие
    /// события и мероприятия в рамках котрых проводится голосование и к которым оно относится.
    /// Интерфейс может быть реализован разными способами в зависимости от специфики работы приложения
    /// Его реализация чаще всего находится в прикладном модуле, для которого используется голосование.
    /// </summary>
    public interface IVoteContextProvider : IApplicationService
    {

        Task<string> GetVoteContext(Guid contextId);
    }
}
