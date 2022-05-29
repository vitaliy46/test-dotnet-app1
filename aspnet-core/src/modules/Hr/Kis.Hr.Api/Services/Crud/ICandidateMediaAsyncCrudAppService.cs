using System;
using Kis.Base.Services.Bl;
using Kis.Hr.Api.Dto;

namespace Kis.Hr.Api.Services
{
    /// <summary>
    /// Представляет сервис CRUD-операций для файлов, прикрепляемых к кандидатам.
    /// </summary>
    public interface ICandidateMediaAsyncCrudAppService : IAsyncCrudAppService<CandidateMediaDto, Guid>
    {}
}
