using System;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Exceptions
{
    /// <summary>
    /// Возникает при поиске записи по коду
    /// </summary>
    public class CodeMissingException : ReferenceException
    {
        /// <summary>
        /// Справочник, в котором отсутсвует искомый код 
        /// </summary>
        public IReferenceBook ReferenceBook { get; }

        public string[] Codes { get; }

        public CodeMissingException(IReferenceBook referenceBook, string[] codes, string message = "" ) : base(message)
        {
            ReferenceBook = referenceBook;
            Codes = codes;
        }

        public CodeMissingException(IReferenceBook referenceBook, string[] codes, Exception innerException, string message = "") : base(message, innerException)
        {
            ReferenceBook = referenceBook;
            Codes = codes;
        }
    }
}
