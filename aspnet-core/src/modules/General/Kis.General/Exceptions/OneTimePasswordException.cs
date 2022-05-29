using System;
using System.Collections.Generic;
using System.Text;

namespace Kis.General.Exceptions
{
    public class OneTimePasswordException : ApplicationException
    {
        public OneTimePasswordException()
        {

        }

        public OneTimePasswordException(String s) : base(s)
        {

        }

        public OneTimePasswordException(String s, Exception e) : base(s, e)
        {

        }
    }

    public class OneTimeNullPasswordException : OneTimePasswordException
    {
        public OneTimeNullPasswordException() : this("Необходимо запросить одноразовый пароль.")
        {

        }

        public OneTimeNullPasswordException(String s) : base(s)
        {

        }

        public OneTimeNullPasswordException(String s, Exception e) : base(s, e)
        {

        }
    }

    public class OneTimeNotConfirmedPasswordException : OneTimePasswordException
    {
        public OneTimeNotConfirmedPasswordException() : this("Действие не подтверждено одноразовым паролем.")
        {

        }

        public OneTimeNotConfirmedPasswordException(String s) : base(s)
        {

        }

        public OneTimeNotConfirmedPasswordException(String s, Exception e) : base(s, e)
        {

        }
    }

    public class OneTimePasswordIsAlreadyExistsException : OneTimePasswordException
    {
        public OneTimePasswordIsAlreadyExistsException() : this("Одноразовый пароль уже создан, необходимо его подтвердить")
        {

        }

        public OneTimePasswordIsAlreadyExistsException(String s) : base(s)
        {

        }

        public OneTimePasswordIsAlreadyExistsException(String s, Exception e) : base(s, e)
        {

        }
    }

    public class OneTimePasswordIsAlreadyConfirmedException : OneTimePasswordException
    {
        public OneTimePasswordIsAlreadyConfirmedException() : this("Одноразовый пароль уже подтвержден, выполните действие")
        {

        }

        public OneTimePasswordIsAlreadyConfirmedException(String s) : base(s)
        {

        }

        public OneTimePasswordIsAlreadyConfirmedException(String s, Exception e) : base(s, e)
        {

        }
    }
}
