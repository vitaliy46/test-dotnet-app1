using System;

namespace Kis.Noris.Api.Data
{
    public static class DataContextScopeExtensions
    {
        /// <summary>
        /// Возвращает контекст данных по его типу из набора контекстов <see cref="IDataContextScope"/>,
        /// если он там есть, иначе пытается его получить из фабрики контекстов или создать его через <see cref="Activator"/>
        /// </summary>
        /// <typeparam name="TDataContext">Тип запрашиваемого контекста</typeparam>
        /// <param name="scope">Набор контекстов</param>
        /// <returns>Запрашиваемый контекст данных</returns>
        public static TDataContext GetContext<TDataContext>(this IDataContextScope scope) where TDataContext : class, IDataContext
        {
            if (scope == null) throw new ArgumentNullException(nameof(scope));

            return scope.DataContexts.Get<TDataContext>();
        }

        /// <summary>
        /// Возвращает контекст данных по его типу из набора контекстов <see cref="IDataContextScope"/>,
        /// если он там есть, иначе пытается его получить из фабрики контекстов или создать его через <see cref="Activator"/>
        /// </summary>
        /// <typeparam name="TDataContext">Тип запрашиваемого контекста</typeparam>
        /// <param name="scope">Набор контекстов</param>
        /// <returns>Запрашиваемый контекст данных</returns>
        public static TDataContext GetContext<TDataContext>(this IDataContextReadOnlyScope scope) where TDataContext : class, IDataContext
        {
            if (scope == null) throw new ArgumentNullException(nameof(scope));

            return scope.DataContexts.Get<TDataContext>();
        }
    }
}
