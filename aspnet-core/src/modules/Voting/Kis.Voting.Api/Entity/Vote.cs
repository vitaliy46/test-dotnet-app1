using System;
using System.Collections.Generic;
using Kis.Base.Entity;
using Kis.Voting.Api.Constant;

namespace Kis.Voting.Api.Entity
{
    /// <summary>
    /// Объявление о проведении голосования по какому либо вопросу
    /// </summary>
    public class Vote : EntityBase<Guid>
    {
        /// <summary>
        /// Порядковый номер голосований
        /// </summary>
        public long Number { get; set; }

        /// <summary>
        /// Вопрос предлагаемый на голосование
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// Текстовое описание
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Результат голосования
        /// </summary>
        public virtual VoteResult VoteResult { get; set; }

        /// <summary>
        /// Инициатор голосования, тот кто его создал. Это может быть любой субъект в системе
        /// в одном из прикладных модулей: сотрудник, пользователь системы, член совета и др.
        /// </summary>
        //public User Initiator { get; set; }
        public long InitiatorId { get; set; }

        /// <summary>
        /// Контекст, в рамках которого создано голосование. Это может быть собрание, какое-либо сообщение
        /// пост на форуме, проект и пр. Все это зависит от прикладного модуля, где используется голосование.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        /// Предоставляется возможность множественног выбора вариантов ответа
        /// </summary>
        public bool IsMultilieChoice { get; set; }

        /// <summary>
        /// Варианты ответов в голосовании
        /// </summary>
        public virtual IList<VoteOption> Options { get; set; }

        /// <summary>
        /// Любые медийные материалы для
        /// </summary>
        public virtual IList<VoteMedia> Medias { get; set; }
        
        /// <summary>
        /// Ссылки на информационные материалы
        /// </summary>
        public virtual IList<VoteLink> Links { get; set; }

        /// <summary>
        /// Минимально допустимый процент кворума в голосовании
        /// </summary>
        public  Single QuorumPct { get; set; }

        /// <summary>
        /// Минимально допустимый процент голосов принимающих решения 
        /// </summary>
        public Single DecisionMakersPct { get; set; }
        
        /// <summary>
        /// Признак того, что голосование было опубликовано
        /// а значит созданы фоновые задачи для оповещения участников
        /// После этого момента невозможно удалить голосование
        /// </summary>
        public bool IsPublished { get; set; }

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
        public VotingCalculationTypes VotingCalculationType { get; set; }

        /// <summary>
        /// Формат отчета голосования. Устанавливается координатором голосования.
        /// </summary>
        public VoteReportFormats? ReportFormat { get; set; }

    }
}
