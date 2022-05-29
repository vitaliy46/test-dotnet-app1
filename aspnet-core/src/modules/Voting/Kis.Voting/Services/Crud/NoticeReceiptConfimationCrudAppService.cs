using System;
using Abp.Domain.Repositories;
using JetBrains.Annotations;
using Kis.Base.Services.Bl;
using Kis.Voting.Api.Dto;
using Kis.Voting.Api.Entity;
using Kis.Voting.Api.Services.Crud;

namespace Kis.Voting.Service.Crud
{
    public class NoticeReceiptConfimationCrudAppService : AsyncCrudAppServiceBase<NoticeReceiptConfimation, NoticeReceiptConfimationDto, Guid>, INoticeReceiptConfimationCrudAppService
    {
        public NoticeReceiptConfimationCrudAppService([NotNull]IRepository<NoticeReceiptConfimation, Guid> repository) : base(repository)
        {
        }
    }
    
}
