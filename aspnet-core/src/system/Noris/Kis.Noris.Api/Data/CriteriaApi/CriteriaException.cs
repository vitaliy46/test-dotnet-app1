using System;

namespace Kis.Noris.Api.Data.CriteriaApi
{
    /// <summary>
    /// Базовое общее исключение для ошибок в применении критериев в процессе выполнения запросов
    /// </summary>
    public class CriteriaException : Exception
    {
        /// <summary>
        /// Объект критерия, послуживший причиной исключения
        /// </summary>
        public ICriteria Criteria { get; private set; }

        public CriteriaException(string message, ICriteria criteria) : base(message)
        {
            Criteria = criteria;
        }
    }

    /// <summary>
    /// Возникает, когда в метод запроса передан объект критерия, тип которого им не поддерживается
    /// </summary>
    public class NotSupportedCriteriaException : CriteriaException
    {
        public NotSupportedCriteriaException(ICriteria criteria)
            :base($"Not supported criteria type \"{criteria.GetType()}\"", criteria)
        { }

        public NotSupportedCriteriaException(string message, ICriteria criteria) : base(message, criteria)
        { }
    }
}