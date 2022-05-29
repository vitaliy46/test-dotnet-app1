using System;
using Kis.Base.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Подтверждение получения уведомления
    /// </summary>
    public class NoticeReceiptConfimation : EntityBase<Guid>
    {
        /// <summary>
        /// Подписанное эл. подписью подтверждение об уведомлении начала голосования
        /// </summary>
        public string ConfimationXml { get; set; }

        public virtual Vote Vote { get; set; }
        public Guid VoteId { get; set; }

        /// <summary>
        /// Участник голосования
        /// </summary>
        public virtual VoteMember Member { get; set; }
        public Guid MemberId { get; set; }
    }
}
