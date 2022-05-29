using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Связь между голосованием и прикрепленной ссылкой на дополнительные информационные материалам
    /// </summary>
    public class VoteLink : EntityBase<Guid>
    {
        public virtual Vote Vote { get; set; }
        public Guid VoteId { get; set; }

        public Link Link { get; set; }
        public Guid LinkId { get; set; }

    }
}
