using System;
using Kis.Base.Dto;

namespace Kis.General.Api.Dto
{
    /// <summary>
    /// Ссылка на интернет ресурс
    /// </summary>
    public class LinkDto : BaseDto<Guid>
    {
        /// <summary>
        /// Уникальный адрес данного интернет ресурса
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Описание к данной ссылке(описание)
        /// </summary>
        public string Description { get; set; }
    }
}
