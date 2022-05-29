using System;
using Kis.Base.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Уведомление участников о проведении голосованания
    /// </summary>
    public class VoteNotice : EntityBase<Guid>
    {
        /// <summary>
        /// Текстовое сообщение уведомления
        /// </summary>
        public string Message { get; set; }

        public virtual Vote Vote { get; set; }
        public Guid VoteId { get; set; }
    }
}
