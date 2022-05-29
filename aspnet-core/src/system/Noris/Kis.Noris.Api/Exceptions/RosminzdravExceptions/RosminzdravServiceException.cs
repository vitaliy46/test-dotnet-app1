using System;

namespace Kis.Noris.Api.Exceptions.RosminzdravExceptions
{
    /// <summary>
    /// Представляет ошибку, полученную от веб-сервиса Росминздрава
    /// </summary>
    public class RosminzdravServiceException : Exception
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public string Code { get; }

        public RosminzdravServiceException(string _code, string _description) : base(_description)
        {
            Code = _code;
        }
    }
}
