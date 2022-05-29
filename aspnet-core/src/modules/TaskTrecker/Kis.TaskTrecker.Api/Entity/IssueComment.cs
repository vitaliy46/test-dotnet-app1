using System;
using Kis.Base.Entity;
using Kis.General.Api.Entity;

namespace Kis.TaskTrecker.Api.Entity
{
    /// <summary>
    /// Комментарий, добавленный к задаче
    /// </summary>
    public class IssueComment : EntityBase<Guid>
    {
        /// <summary>
        /// Задача к которой сделан комментарий
        /// </summary>
        public virtual Issue Issue { get; set; }
        public Guid IssueId { get; set; }

        public  Comment Comment { get; set; }
        public Guid CommentId { get; set; }

        /// <summary>
        /// Отметка времени, затраченного на  выполнене работ по задаче.
        /// </summary>
        public  long? WorkTime { get; set; }

        /// <summary>
        /// Отметка о переводе Задачи на другой этап сделанная в конкретном комментарии.
        /// </summary>
        public virtual IssueState State { get; set; }
        public Guid StateId { get; set; }

        /// <summary>
        /// Сотрудник добавивший комментарий. Это могут быть те, кто так или иначе были связаны с задачей.
        /// То есть были исполнителями или являются исполнителями + руководитель этого сотрудника 
        /// (или несколько если так определено в орг. структуре) Менеджер сделки в рамках которой 
        /// стоит задача, Продюсеры по этой сделке.
        /// </summary>
        //Это свойство берется из унаследованного свойства Created

        //Дата добавления комментария берется из унаследованного свойства CreatedDate 


    }
}
