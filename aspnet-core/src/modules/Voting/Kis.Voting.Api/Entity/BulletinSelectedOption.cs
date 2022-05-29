using System;
using Kis.Base.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Варианты ответов в бюллетене пользователя по голосованию
    /// </summary>
    public class BulletinSelectedOption : EntityBase<Guid>
    {
        /// <summary>
        /// Бюллетень пользователя
        /// </summary>
        public virtual Bulletin Bulletin { get; set; }
        public Guid BulletinId { get; set; }
        
        /// <summary>
        /// Выбранный вариант в бюллетене
        /// </summary>
        public virtual VoteOption SelectedOption { get; set; }
        public Guid SelectedOptionId { get; set; }

    }
}
