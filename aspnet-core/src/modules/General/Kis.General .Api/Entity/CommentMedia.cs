using System;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Связь комментария с файлом
    /// </summary>
    public class CommentMedia : EntityBase<Guid>
    {
        public virtual Comment Comment { get; set; }
        public Guid CommentId { get; set; }

        public virtual Media Media { get; set; }
        public Guid MediaId { get; set; }
    }
}
