using System;
using Kis.Noris.Api.Constants;

namespace Kis.Noris.Api.Exceptions
{
    /// <summary>
    /// Возникает если ошибка не находится в определенном состоянии
    /// </summary>
    public class ErrorStateException : Exception
    {
        /// <summary>
        /// Идентификатор ошибки
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Состояние ошибки
        /// </summary>
        public ReferenceErrorStates State { get; }

        public ErrorStateException(string identifier, ReferenceErrorStates currentState, string message)
            : base(message)
        {
            this.Identifier = identifier;
            this.State = currentState;
        }
    }
}
