using System;
using System.Collections.Generic;

namespace Kis.Noris.Api.Exceptions
{
    public class NamedKeyNotFoundException : KeyNotFoundException
    {
        public string KeyName { get; }

        public NamedKeyNotFoundException(string key, string message) :
            base(message)
        {
            this.KeyName = key;
        }

        public NamedKeyNotFoundException(string key, string message, Exception innerException) :
            base(message, innerException)
        {
            this.KeyName = key;
        }
    }
}
