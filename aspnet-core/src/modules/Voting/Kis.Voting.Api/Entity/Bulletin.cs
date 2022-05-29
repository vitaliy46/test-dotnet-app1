using System;
using System.Collections.Generic;
using Kis.Base.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Бюллетень голосовавния заполненый участником голососвания
    /// </summary>
    public class Bulletin : EntityBase<Guid>
    {
        /// <summary>
        /// Пользователь системы учавствующий в голосовании
        /// </summary>
        public virtual VoteMember VoteMember { get; set; }
        public Guid VoteMemberId { get; set; }


        /// <summary>
        /// Объявленное голосование
        /// </summary>
        public virtual Vote Vote { get; set; }
        public Guid VoteId { get; set; }

        public virtual IList<BulletinSelectedOption> BulletinSelectedOptions { get; set; }
        /// <summary>
        /// Xml документ c результатом голососвания по бюллетеню
        /// Этот документ подписан эл. подписью.
        /// </summary>
        public string VotingResultXml { get; set; }
    }
}
