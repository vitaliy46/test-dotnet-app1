using Kis.Noris.Api.Dpo;

namespace Kis.Noris.Api.Exceptions.RosminzdravExceptions
{
    /// <summary>
    /// Представляет ошибку, возникающую при попытке обновить через веб-сервис Росминздрава справочник,
    /// чья структура была изменена
    /// </summary>
    public class RosminzdravUpdateException : RosminzdravServiceException
    {
        /// <summary>
        /// Версия, с которой запрашиваются изменения
        /// </summary>
        public string OldVersion { get; }

        /// <summary>
        /// Версия, на которую запрашиваются изменения
        /// </summary>
        public string NewVersion { get; }

        public string ErrorIdentifier { get; }

        public ReferenceErrorDpo ErrorInfo { get; }

        public RosminzdravUpdateException(string _oldVersion, string _newVersion, string _errorIdentifier)
            : base("03x0007", "Структуры версий справочников не эквивалентны")
        {
            this.OldVersion = _oldVersion;
            this.NewVersion = _newVersion;
            this.ErrorIdentifier = _errorIdentifier;
        }

        public RosminzdravUpdateException(string _oldVersion, string _newVersion, string _errorIdentifier, ReferenceErrorDpo _errorInfo)
            : base("03x0007", "Структуры версий справочников не эквивалентны")
        {
            this.OldVersion = _oldVersion;
            this.NewVersion = _newVersion;
            this.ErrorIdentifier = _errorIdentifier;
            this.ErrorInfo = _errorInfo;
        }
    }
}
