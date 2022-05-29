using System;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Медиа информация
    /// </summary>
    public class Media : EntityBase<Guid>
    {
        /// <summary>
        /// Тип медиа информации
        /// </summary>
        //public virtual MediaType MediaType { get; set; }
        //public Guid? MediaTypeId { get; set; }

        /// <summary>
        /// Любая метка, котрую программист может повесить на медиаинформацию
        /// и по ней выбирать ее из общего перечня
        /// Служит альтернативой MediaType
        /// </summary>
        public string Label { get; set; }
        
        /// <summary>
        /// Оригинальное имя файла из источника
        /// </summary>
        public string FileName { get; set; }
        
        /// <summary>
        /// Полный путь на диске сервера к медиа информации
        /// </summary>
        public string Path { get; set; }
        
        /// <summary>
        /// Описание к медиа информации
        /// </summary>
        public string Description { get; set; }
        
    }
}
