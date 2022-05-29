using System;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Связь ссылки с сомментарием
    /// </summary>
    public class CommentLink : EntityBase<Guid>
    {
        public virtual Comment Comment { get; set; }
        public Guid CommentId { get; set; }
        
        public virtual Link Link { get; set; }
        public Guid LinkId { get; set; }
    }
}
