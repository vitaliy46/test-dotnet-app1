using System;
using Kis.Authorization.Users;
using Kis.Base.Entity;


namespace Kis.TaskTrecker.Api.Entity
{
    /// <summary>
    /// Проект, над которым работает компания
    /// </summary>
    public class Project : EntityBase<Guid>
    {
        /// <summary>
        /// Заголовок проекта
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание проекта
        /// </summary>
        public string Description { get; set; }

        public virtual ProjectState ProjectState { get; set; }
        public Guid ProjectStateId { get; set; }

        /// <summary>
        /// Менеджер проекта из числа пользователей системы с назначенной  Ролью Менеджера
        /// </summary>
        public User Manager { get; set; }
        public Guid? ManagerId { get; set; }

        /// <summary>
        /// Uri на диаграмму Ганта про проекту
        /// </summary>
        public string Gant { get; set; }
    }
}
