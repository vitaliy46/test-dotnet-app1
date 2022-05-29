using System;
using System.Linq;
using Kis.Base.Entity;

namespace Kis.Base.Extensions
{
    public static class EntityExtensions
    {
        /// <summary>
        /// Выбирает записи, являющиеся удалёнными по состоянию на текущую дату
        /// </summary>
        /// <typeparam name="TId">Тип уникального идентификатора записи</typeparam>
        /// <typeparam name="TEntity">Тип записи</typeparam>
        /// <param name="query">Запрос, на котором выполняется выборка удалённых записей</param>
        /// <returns>Запрос, содержащий только удалённые на текущую дату записи</returns>
        public static IQueryable<TEntity> WhereDeleted<TEntity, TId>(this IQueryable<TEntity> query)
            where TEntity : EntityBase<TId>
            where TId : struct
        {
            return query.WhereDeletedAt<TEntity, TId>(DateTime.UtcNow);
        }

        /// <summary>
        /// Выбирает записи, являющиеся удалёнными по состоянию на указанную дату
        /// </summary>
        /// <typeparam name="TId">Тип уникального идентификатора записи</typeparam>
        /// <typeparam name="TEntity">Тип записи</typeparam>
        /// <param name="query">Запрос, на котором выполняется выборка удалённых записей</param>
        /// <param name="givenDate">Дата в UTC времени, по состоянию на которую выбираются удалённые записи</param>
        /// <returns>Запрос, содержащий только удалённые на указанную дату записи</returns>
        public static IQueryable<TEntity> WhereDeletedAt<TEntity, TId>(this IQueryable<TEntity> query, DateTime givenDate)
            where TEntity : EntityBase<TId>
            where TId : struct
        {
            if (query == null) throw new ArgumentNullException("query");
            return query.Where(o => o.DeletionTime != null && o.DeletionTime <= givenDate);
        }

        /// <summary>
        /// Выбирает записи, являющиеся актуальными (не удалёнными) по состоянию на текущую дату
        /// </summary>
        /// <typeparam name="TId">Тип уникального идентификатора записи</typeparam>
        /// <typeparam name="TEntity">Тип записи</typeparam>
        /// <param name="query">Запрос, на котором выполняется выборка актуальных записей</param>
        /// <returns>Запрос, содержащий только актуальные на текущую дату записи</returns>
        public static IQueryable<TEntity> WhereNotDeleted<TEntity, TId>(this IQueryable<TEntity> query)
            where TEntity : EntityBase<TId>
            where TId : struct
        {
            return query.WhereNotDeletedAt<TEntity, TId>(DateTime.UtcNow);
        }

        /// <summary>
        /// Выбирает записи, являющиеся актуальными (не удалёнными) по состоянию на указанную дату
        /// </summary>
        /// <typeparam name="TId">Тип уникального идентификатора записи</typeparam>
        /// <typeparam name="TEntity">Тип записи</typeparam>
        /// <param name="query">Запрос, на котором выполняется выборка актуальных записей</param>
        /// <param name="givenDate">Дата в UTC времени, по состоянию на которую выбираются актуальные записи</param>
        /// <returns>Запрос, содержащий только актуальные на указанную дату записи</returns>
        public static IQueryable<TEntity> WhereNotDeletedAt<TEntity, TId>(this IQueryable<TEntity> query, DateTime givenDate)
            where TEntity : EntityBase<TId>
            where TId : struct
        {
            if (query == null) throw new ArgumentNullException("query");
            return query.Where(o => o.DeletionTime == null || o.DeletionTime > givenDate);
        }
    }
}
