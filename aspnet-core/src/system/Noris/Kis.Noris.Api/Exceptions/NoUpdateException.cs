using System;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Exceptions
{
    /// <summary>
    /// Представляет ошибку, возникшую при попытке обновления справочника вследствие того, что в файле 
    /// обновления не было добавлено или исправлено ни одной записи
    /// </summary>
    public class NoUpdateException : Exception
    {
        public UpdateInfo UpdateInformaton { get; private set; }

        public NoUpdateException()
        { }

        public NoUpdateException(string message) : base(message)
        { }

        public NoUpdateException(UpdateInfo updateInfo, string message) : base(message)
        {
            UpdateInformaton = updateInfo;
        }
    }
}
