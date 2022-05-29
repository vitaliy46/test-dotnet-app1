using System;

namespace Kis.Base.Utilities
{
    /// <summary>
    /// Методы, реализующие монаду "Maybe"
    /// </summary>
    public static class Maybe
    {
        /// <summary>
        /// Возвращает null, если текущий объект равен <value>null</value>, иначе
        /// возвращает результат функции evaluator
        /// </summary>
        public static TResult With<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator)
            where TInput : class where TResult : class
        {
            if (evaluator == null)
                throw new ArgumentNullException(nameof(evaluator));
            return obj == null ? null : evaluator(obj);
        }

        /// <summary>
        /// Возвращает специфицированный результат failureValue, если текущий объект
        /// равен null, иначе возвращает результат функции evaluator
        /// </summary>
        public static TResult Result<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator,
            TResult failureValue) where TInput : class
        {
            if (evaluator == null)
                throw new ArgumentNullException(nameof(evaluator));
            return obj == null ? failureValue : evaluator(obj);
        }
    }
}
