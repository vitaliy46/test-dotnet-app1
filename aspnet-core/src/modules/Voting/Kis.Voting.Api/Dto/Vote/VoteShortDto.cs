using System;
using System.Collections.Generic;
using Kis.Base.Dto;
using Kis.Voting.Api.Constant;

namespace Kis.Voting.Api.Dto
{
    /// <summary>
    /// Обьъявление о проведении голосования по какому либо вопросу
    /// </summary>
    public class VoteShortDto : BaseDto<Guid>
    {
        /// <summary>
        /// Порядковый номер голосований
        /// </summary>
        public long Number { get; set; }

        /// <summary>
        /// Вопрос предлагаемый на голосование
        /// </summary>
        public string Theme { get; set; }

        public string ContextName { get; set; }

        /// <summary>
        /// Указывает на то, что пользователь уже принял участие по
        /// этому голосованию и может посмотреть его результаты
        /// </summary>
        public bool IsVoted { get; set; }

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

        public string VoteStateName { get; set; }
       
    }
}
