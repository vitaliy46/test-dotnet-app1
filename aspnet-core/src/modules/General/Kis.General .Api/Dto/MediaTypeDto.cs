using System;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Справочник типов медиа данных (Тестовые задания,портфолио, фото, ...)
    /// </summary>
    public class MediaTypeDto : BaseDto<Guid>
    {
        public string Name { get; set; }
        public string SystemName { get; set; }
    }
}
