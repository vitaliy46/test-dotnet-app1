using System;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Связь ссылки с сомментарием
    /// </summary>
    public class CommentLinkDto : BaseDto<Guid>
    {
        public Guid CommentId { get; set; }

        public LinkDto Link { get; set; }
        public Guid LinkId { get; set; }
    }
}
