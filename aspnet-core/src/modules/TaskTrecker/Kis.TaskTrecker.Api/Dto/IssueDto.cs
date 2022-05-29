using System;
using System.Collections.Generic;
using Kis.Base.Dto;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Задача  в проекте
    /// </summary>
    public class IssueDto : BaseDto<Guid>
    {
        /// <summary>
        /// Заголовок задачи
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Описание Задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Родительская задача
        /// </summary>
        public virtual IssueDto Parent { get; set; }
        public Guid? ParentId { get; set; }

        /// <summary>
        /// приоритет Задачи
        /// </summary>
        public Guid PriorityId { get; set; }

        /// <summary>
        /// Этап выполнения Задачи
        /// </summary>
        public  Guid StateId { get; set; }

        /// <summary>
        /// исполнитель задачи из числа сотрудников
        /// </summary>
        public Guid? PerformerId { get; set; }

        /// <summary>
        /// ссылка на проект к которой относится задача
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// планируемые дата и время завершения задачи
        /// </summary>
        public  DateTime? Dedline { get; set; }

        /// <summary>
        /// планируемое время необходимое для решения задачи
        /// реальное время рассчитывается из затрат времени указанных в комментариях к задаче
        /// </summary>
        public  long PlannedTime { get; set; }

        /// <summary>
        /// Файлы  прикрепленные к задаче. 
        /// </summary>
        public virtual IList<IssueMediaDto> Medias { get; set; }

        /// <summary>
        /// Комментарии по задаче. 
        /// </summary>
        public virtual IList<IssueCommentDto> Comments { get; set; }

        
        /// <summary>
        /// дата и время последнего запроса задачи пользователем
        /// </summary>
        public  DateTime? LastRead { get; set; }

        /// <summary>
        /// Пользователь, добавивший последний комментарий
        /// </summary>
        public  Guid? LastCommentUserId { get; set; }


        /// <summary>
        /// Просмотры задачи пользователями
        /// </summary>
        // public virtual IList<DealTaskRead> Readings { get; set; }
        
        /// <summary>
        /// История изменений исполнителя
        /// </summary>
        //public virtual IList<DealTaskUser> UserHistory { get; set; }

    }
}
