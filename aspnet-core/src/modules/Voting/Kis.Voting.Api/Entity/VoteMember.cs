using System;
using Kis.Authorization.Users;
using Kis.Base.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Участник голосования
    /// </summary>
    public class VoteMember : EntityBase<Guid>
    {
        /// <summary>
        /// Как правило указывается ФИО участника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пользователь, котрый будет учавтвовать в голосовании
        /// </summary>
        public User User { get; set; }
        public long UserId { get; set; }

        /// <summary>
        /// Объявленное голосование голосовании
        /// </summary>
        public virtual Vote Vote { get; set; }
        public Guid VoteId { get; set; }

        /// <summary>
        /// Контактные данные для уведомления участника о голососвании.
        /// Механизм отправки уведомлений опирается на тип контактных данных.
        /// </summary>
        public virtual VoteMemberContact VoteMemberContact { get; set; }
        public Guid VoteMemberContactId { get; set; }
    }
}
