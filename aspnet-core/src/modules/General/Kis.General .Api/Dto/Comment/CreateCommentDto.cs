using System;
using System.Collections.Generic;
using Abp.Runtime.Validation;

namespace Kis.General.Api.Dto.Comment
{
    /// <summary>
    /// Комментарий к любой сущности
    /// </summary>
    public class CreateCommentDto : IShouldNormalize
    {
        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Медия файлы
        /// </summary>
        public IList<Guid> Medias { get; set; }
        /// <summary>
        /// Ссылки на внешние ресурсы
        /// </summary>
        public IList<Guid> Links { get; set; }

        public void Normalize()
        {
        }
    }
}
