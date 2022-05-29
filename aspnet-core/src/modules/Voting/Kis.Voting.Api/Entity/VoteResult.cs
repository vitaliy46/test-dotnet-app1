using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Результат голосования.
    /// Подписывается эл. подписью
    /// </summary>
    public class VoteResult : EntityBase<Guid>
    {
        public virtual Vote Vote { get; set; }
        public Guid VoteId { get; set; }

        /// <summary>
        /// Подписанная эл. подписью xml структура результата голосования
        /// В структуру входят:
        /// 1. Все выбранные участниками голосования путкты, за которые  они проголосовали
        /// 2. Пунты за которые голосовали с процентами голосов
        /// 3. Кворум: количество участников и процент от общего числа голосующих
        /// 4. Идентификатор голосования
        /// 5. Текстовое сообщение резюмирующее результаты голосования.
        /// 6. Координатор голосования: его  id  и ФИО
        /// </summary>
        public string SignedResult { get; set; }

        public string TextResult { get; set; }
    }
}
