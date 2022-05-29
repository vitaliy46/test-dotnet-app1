using System;
using System.Collections.Generic;
using Kis.Authorization.Users;
using Kis.Base.Entity;

namespace Kis.TaskTrecker.Api.Entity
{
    /// <summary>
    /// Задача  в проекте
    /// </summary>
    public class Issue : EntityBase<Guid>
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
        public virtual Issue Parent { get; set; }
        public Guid? ParentId { get; set; }

        /// <summary>
        /// приоритет Задачи
        /// </summary>
        public virtual IssuePriority Priority { get; set; }
        public Guid PriorityId { get; set; }

        /// <summary>
        /// Этап выполнения Задачи
        /// </summary>
        public virtual IssueState State { get; set; }
        public  Guid StateId { get; set; }

        /// <summary>
        /// исполнитель задачи из числа сотрудников
        /// </summary>
        public User Performer { get; set; }
        public Guid? PerformerId { get; set; }

        /// <summary>
        /// ссылка на проект к которой относится задача
        /// </summary>
        public virtual Project Project { get; set; }
        public Guid ProjectId { get; set; }

        /// <summary>
        /// планируемые дата и время завершения задачи
        /// </summary>
        public  DateTime? Dedline { get; set; }

        /// <summary>
        /// планируемое время необходимое для решения задачи
        /// реальное время рассчитывается из затрат времени указанных в комментариях к задаче
        /// </summary>
        public  long? PlannedTime { get; set; }

        /// <summary>
        /// Файлы  прикрепленные к задаче. 
        /// </summary>
        public virtual IList<IssueMedia> Medias { get; set; }

        /// <summary>
        /// Комментарии по задаче. 
        /// </summary>
        public virtual IList<IssueComment> Comments { get; set; }

        
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
