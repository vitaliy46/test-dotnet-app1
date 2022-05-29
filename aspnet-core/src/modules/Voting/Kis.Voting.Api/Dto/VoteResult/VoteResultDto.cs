using Kis.Base.Dto;
using Kis.Voting.Api.Entity;
using System;



namespace Kis.Voting.Api.Dto
{
    /// <summary>
 /// Результат голосования.
 /// </summary>
  public  class VoteResultDto : BaseDto<Guid>
    {
        public  VoteDto Vote { get; set; }
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
