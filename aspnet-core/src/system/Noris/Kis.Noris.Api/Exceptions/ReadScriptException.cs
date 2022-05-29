using System;
using Kis.Noris.Api.Entity;

namespace Kis.Noris.Api.Exceptions
{
    /// <summary>
    /// Возникает при попытке чтения и записи в БД sql скрипта содержащего информацию об\
    /// обновлении справочника
    /// </summary>
    public class ReadScriptException : ReferenceException
    {
        public UpdateInfo UpdateInformation { get; private set; }
        public ReadScriptException(string message, UpdateInfo updateInfo) : base(message)
        {
            UpdateInformation = updateInfo;
        }

        public ReadScriptException(string message, UpdateInfo updateInfo, Exception innerException) : base(message, innerException)
        {
            UpdateInformation = updateInfo;
        }
    }
}
