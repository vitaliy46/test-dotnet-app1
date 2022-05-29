using System;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Связь комментария с файлом
    /// </summary>
    public class CommentMediaDto : BaseDto<Guid>
    {
        public Guid CommentId { get; set; }

        public MediaDto Media { get; set; }
        public Guid MediaId { get; set; }
    }
}
