using System;
using System.Collections.Generic;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Комментарий к любой сущности/
    /// Понятие комментария довольно комплексное, включающее возможность добваления ссылок и
    /// любых медиафайлов
    /// </summary>
    public class Comment : EntityBase<Guid>
    {
        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Медия файлы
        /// </summary>
        public virtual IList<CommentMedia> Medias { get; set; }
        /// <summary>
        /// Ссылки на внешние ресурсы
        /// </summary>
        public virtual IList<CommentLink> Links { get; set; }
    }
}
