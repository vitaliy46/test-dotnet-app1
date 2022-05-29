using Kis.Noris.Api.Dpo;

namespace Kis.Noris.Api.Entity
{
    /// <summary>
    /// Представляет результат проверки ошибки
    /// </summary>
    public class ResultOfErrorCheck
    {
        /// <summary>
        /// Объект, представляющий информацию об ошибке
        /// </summary>
        public ReferenceErrorDpo ErrorInfo { get; set; }

        /// <summary>
        /// Результат проверки
        /// </summary>
        public bool ResultOfCheck { get; set; }

        public ResultOfErrorCheck(ReferenceErrorDpo errorInfo, bool resultOfCheck)
        {
            this.ErrorInfo = errorInfo;
            this.ResultOfCheck = resultOfCheck;
        }
    }
}
