using System;

namespace Kis.Noris.Api.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при работе со справочниками, их обновлении и использовании.
    /// </summary>
    public class ReferenceException : Exception
    {
        public ReferenceException(string message) : base(message)
        { }

        public ReferenceException(string message, Exception innerException): base(message, innerException)
        { }
    }
}