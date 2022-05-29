using System;
using System.Runtime.Serialization;

namespace Kis.Noris.Api.Dao.EF
{
    [Serializable]
    internal class NotRegisteredEntityException : Exception
    {
        public NotRegisteredEntityException()
        {
        }

        public NotRegisteredEntityException(string message) : base(message)
        {
        }

        public NotRegisteredEntityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotRegisteredEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}