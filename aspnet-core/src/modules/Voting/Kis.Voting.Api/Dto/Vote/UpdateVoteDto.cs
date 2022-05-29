using System;
using System.Collections.Generic;
using Abp;
using Abp.Runtime.Validation;
using Kis.Base.Dto;
using Kis.Voting.Api.Constant;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Обьъявление о проведении голосования по какому либо вопросу
    /// </summary>
    public class UpdateVoteDto : BaseDto<Guid>
    {
        /// <summary>
        /// Порядковый номер голосований
        /// </summary>
        // public long Number { get; set; }

        /// <summary>
        /// Вопрос предлагаемый на голосование
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// Инициатор голосования, тот кто его создал. Это может быть любой субъект в системе
        /// в одном из прикладных модулей: сотрудник, пользователь системы, член совета и др.
        /// </summary>
        //public long InitiatorId { get; set; }

        /// <summary>
        /// Контекст, в рамках которого создано голосование. Это может быть собрание, какое-либо сообщение
        /// пост на форуме и пр. Все это зависит от прикладного модуля, где используется голосование.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        /// Процент кворума в голосовании
        /// </summary>
        public Single QuorumPct { get; set; }

        /// <summary>
        /// Процент принимающих решения голосов
        /// </summary>
        public Single DecisionMakersPct { get; set; }

        /// <summary>
        /// Предоставляется возможность множественног выбора вариантов ответа
        /// </summary>
        public bool IsMultilieChoice { get; set; }

        /// <summary>
        /// Дата и время начала голосования
        /// </summary>
        public DateTime BeginDateTime { get; set; }

        /// <summary>
        /// Дата и время окончания голосования
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Дата и время рассылки уведомления
        /// </summary>
        public DateTime NoteSendingDateTime { get; set; }

        /// <summary>
        /// Вид подсчета для этого голосования. Он может быть принят из настроек,
        /// или переназначен создателем голосования.
        /// </summary>
        //public VotingCalculationTypes VotingCalculationType { get; set; }
        
        /// <summary>
        /// Варианты ответов в голосовании
        /// </summary>
        public virtual IList<VoteOptionDto> Options { get; set; }

       
    }
}
