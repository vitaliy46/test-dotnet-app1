using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Связь между голосованием и прикрепленным медийным материалам
    /// </summary>
    public class VoteMedia : EntityBase<Guid>
    {
        public virtual Vote Vote { get; set; }
        public Guid VoteId { get; set; }

        public Media Media { get; set; }
        public Guid MediaId { get; set; }

    }
}
