using System;
using System.Collections.Generic;
using System.Text;

namespace Kis.Voting.Exceptions
{
    public class BulletingException : ApplicationException
    {
        public BulletingException()
        {

        }

        public BulletingException(String s) : base(s)
        {

        }

        public BulletingException(String s, Exception e) : base(s, e)
        {

        }
    }

    public class IsVotedBulletingException : BulletingException
    {
        public IsVotedBulletingException() : this("Текущий пользователь уже проголосовал.")
        {

        }

        public IsVotedBulletingException(String s) : base(s)
        {

        }

        public IsVotedBulletingException(String s, Exception e) : base(s, e)
        {

        }
    }

    public class NotVoteMemberBulletingException : BulletingException
    {
        public NotVoteMemberBulletingException() : this("Пользователь не является участником данного голосования.")
        {

        }

        public NotVoteMemberBulletingException(String s) : base(s)
        {

        }

        public NotVoteMemberBulletingException(String s, Exception e) : base(s, e)
        {

        }
    }

    public class AccessViolationBulletingException : BulletingException
    {
        public AccessViolationBulletingException() : this("Пользователь пытается проголосовать от имени другого участника.")
        {

        }

        public AccessViolationBulletingException(String s) : base(s)
        {

        }

        public AccessViolationBulletingException(String s, Exception e) : base(s, e)
        {

        }
    }
}
