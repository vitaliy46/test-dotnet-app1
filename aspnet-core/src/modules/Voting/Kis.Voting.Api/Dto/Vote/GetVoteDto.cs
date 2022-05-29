using System;
using System.Collections.Generic;
using Kis.Authorization.Users;
using Kis.Base.Dto;
using Kis.Voting.Api.Constant;
using Kis.Voting.Api.Entity;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Обьъявление о проведении голосования по какому либо вопросу
    /// </summary>
    public class GetVoteDto : BaseDto<Guid>
    {
        /// <summary>
        /// Текстовое описание
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// Порядковый номер голосований
        /// </summary>
        public long Number { get; set; }

        /// <summary>
        /// Контекст, в рамках которого создано голосование. Это может быть собрание, какое-либо сообщение
        /// пост на форуме и пр. Все это зависит от прикладного модуля, где используется голосование.
        /// </summary>
        public string ContextName { get; set; }
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
        /// Варианты ответов в голосовании
        /// </summary>
        public IList<VoteOptionDto> Options { get; set; }
    }
}
