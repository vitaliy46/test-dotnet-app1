using System;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Hr.Api.Dto;
using Kis.Hr.Api.Entity;
using Kis.Hr.Api.Services;

namespace Kis.Hr.Services.Crud
{
    public class CandidateCommentAsyncCrudAppService : AsyncCrudAppServiceBase<CandidateComment, CandidateCommentDto, Guid>, ICandidateCommentAsyncCrudAppService
    {
        public CandidateCommentAsyncCrudAppService([NotNull] IRepository<CandidateComment, Guid> candidateCommentRepository) 
            : base(candidateCommentRepository)
        {}
    }
    
}
