using System;
using Kis.Base.Dto;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.Comment;

namespace Kis.TaskTrecker.Api.Dto
{
    /// <summary>
    /// Комментарий, добавленный к задаче
    /// </summary>
    public class IssueCommentDto : BaseDto<Guid>
    {
        /// <summary>
        /// Задача к которой сделан комментарий
        /// </summary>
        public Guid IssueId  { get; set; }

        public CommentDto Comment { get; set; }

        /// <summary>
        /// Отметка времени, затраченного на  выполнене работ по задаче.
        /// </summary>
        public  long? WorkTime { get; set; }

        /// <summary>
        /// Отметка о переводе Задачи на другой этап сделанная в конкретном комментарии.
        /// </summary>
        public virtual IssueStateDto State { get; set; }

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
