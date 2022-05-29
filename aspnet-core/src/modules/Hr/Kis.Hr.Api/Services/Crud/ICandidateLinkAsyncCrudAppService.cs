using System;
using Kis.Base.Services.Bl;
using Kis.Hr.Api.Dto;

namespace Kis.Hr.Api.Services
{
    /// <summary>
    /// Представляет сервис для ссылок, добавляемых кандидату.
    /// </summary>
    public interface ICandidateLinkAsyncCrudAppAppService : IAsyncCrudAppService<CandidateLinkDto, Guid>
    {
    }
}
