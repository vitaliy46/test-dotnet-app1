using System;
using Kis.Base.Entity;

namespace Kis.General.Api.Entity
{
    /// <summary>
    /// Справочник типов медиа данных (Тестовые задания,портфолио, фото, ИНН ...)
    /// </summary>
    public class MediaType : EntityBase<Guid>
    {
        /// <summary>
        /// Визуально отображаемое имя типа файла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Системное имя должно быть уникально, на английском и удобно в использовании в коде
        /// для отбора нужных медиа по названию типа.
        /// Разработчики должны беспокоиться об уникальности таких имен, котрые используются в коде.
        /// </summary>
        public  string SystemName { get; set; }
    }
}
