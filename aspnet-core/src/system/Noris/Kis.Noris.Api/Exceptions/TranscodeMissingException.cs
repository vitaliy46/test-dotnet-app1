using System;
using Kis.Noris.Api.Services;

namespace Kis.Noris.Api.Exceptions
{
    /// <summary>
    /// Возникает при перекодировании записи справочника и обнаружении
    /// отсутствия кода перекодировки.
    /// </summary>
    public class TranscodeMissingException : ReferenceException
    {
        /// <summary>
        /// Справочник, с которого происходит перекодировка 
        /// </summary>
        public IReferenceBook ReferenceBook { get; }
        /// <summary>
        /// Справочник, на который перекодируется текущий справочник
        /// </summary>
        public IReferenceBook MasterReferenceBook { get; }
        public string[] Codes { get; }

        public TranscodeMissingException(IReferenceBook referenceBook, IReferenceBook masterReferenceBook, string[] codes, string message="") 
                                    : base(message)
        {
            ReferenceBook = referenceBook;
            MasterReferenceBook = masterReferenceBook;
            Codes = codes;
        }

        public TranscodeMissingException(IReferenceBook referenceBook, IReferenceBook masterReferenceBookType, string[] codes, Exception innerException, string message="") 
                                     : base(message, innerException)
        {
            ReferenceBook = referenceBook;
            MasterReferenceBook = masterReferenceBookType;
            Codes = codes;
        }
    }
}
