using System;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Ссылка на интернет ресурс
    /// </summary>
    public class Link : EntityBase<Guid>
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
