using System;

namespace Kis.Noris.Api.Exceptions
{
    /// <summary>
    /// Возникает при попытке обновления/добавления записи в справочник
    /// </summary>
    public class RecordUpdateException : ReferenceException
    {

        public RecordUpdateException(string message) : base(message)
        {
        }

        public RecordUpdateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
