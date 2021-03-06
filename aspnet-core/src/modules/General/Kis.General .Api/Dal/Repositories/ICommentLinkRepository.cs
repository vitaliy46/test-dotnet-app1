using System;
using Abp.Domain.Repositories;
using Kis.General.Api.Entity;

namespace Kis.General.Api.Dal.Repositories
{
    /// <summary>
    /// Представляет репозиторий для персон.
    /// </summary>
    public interface ICommentLinkRepository : IRepository<CommentLink, Guid>
    {
    }
}
