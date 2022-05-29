using System;

namespace Kis.Noris.Api.Extensions
{
    public static class TaskExtensions
    {
        public const string ReferenceQueue = "reference";

        /// <summary>
        /// Указывает, что задачу нужно запускать в очереди <see cref="ReferenceQueue"/>
        /// </summary>
        /// <param name="workContext"></param>
        /// <returns></returns>
        public static T InReferenceQueue<T>(this T workContext) where T : WorkContext
        {
            if (workContext == null) throw new ArgumentNullException(nameof(workContext));

            workContext.Queue = ReferenceQueue;
            return workContext;
        }

        /// <summary>
        /// Указывает, что задачу нужно запускать в очереди <see cref="ReferenceQueue"/>
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static Task InReferenceQueue(this Task task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));

            task.Context.Queue = ReferenceQueue;
            return task;
        }
    }
}
