using System;
using Kis.Base.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Вариант ответа в голосованании
    /// </summary>
    public class VoteOption : EntityBase<Guid>
    {
        public string Text { get; set; }

        public virtual Vote Vote { get; set; }
        public Guid VoteId { get; set; }
    }
}
