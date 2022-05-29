using System;
using Kis.Base.Services.Bl;
using Kis.Hr.Api.Dto;

namespace Kis.Hr.Api.Services
{
    /// <summary>
    /// Представляет сервис для источников информации.
    /// </summary>
    public interface IInformationSourceAsyncCrudAppService : IAsyncCrudAppService<InformationSourceDto, Guid>
    {}
}
