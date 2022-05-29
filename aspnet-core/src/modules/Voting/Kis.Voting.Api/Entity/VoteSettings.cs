using System;
using Kis.Base.Entity;
using Kis.Voting.Api.Constant;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Настройка системы голосования.
    /// Каждый организатор голосования может под себя настроить
    /// систему голосования
    /// </summary>
    public class VoteSettings : EntityBase<Guid>
    {
        /// <summary>
        /// Пользователь, использующий систему голосования
        /// </summary>
        //public User User { get; set; }
        public long UserId { get; set; }

        /// <summary>
        /// Указывает на необходимость подписания
        /// </summary>
        public  bool IsNeedSign { get; set; }

        /// <summary>
        /// Вид подсчета результатов голосования
        /// </summary>
        public VotingCalculationTypes VotingCalculationType { get; set; }
    }
}
