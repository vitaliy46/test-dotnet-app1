using System;
using Abp.Runtime.Validation;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Медиа информация
    /// </summary>
    public class CreateMediaDto : IShouldNormalize
    {
        /// <summary>
        /// Оригинальное имя файла из источника
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Любая метка, котрую программист может повесить на медиаинформацию
        /// и по ней выбирать ее из общего перечня
        /// Служит альтернативой MediaType
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Полный путь на диске сервера к медиа информации
        /// </summary>
        public string Path { get; set; }
        
        /// <summary>
        /// Описание к медиа информации
        /// </summary>
        public string Description { get; set; }

        public void Normalize()
        {
        }
    }
}
