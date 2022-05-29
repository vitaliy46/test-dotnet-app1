using System;
using Kis.Base.Entity;

namespace Kis.TaskTrecker.Api.Entity
{
    /// <summary>
    /// Приоритет задачи назначенной в проекте
    /// </summary>
    public class IssuePriority : EntityBase<Guid>
    {
        public string Name { get; set; }
    }
}
