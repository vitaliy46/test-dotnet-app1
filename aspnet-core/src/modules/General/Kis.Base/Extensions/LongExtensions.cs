using System;

namespace Kis.Base.Extensions
{
    public static class LongExtensions
    {
        public static Guid ToGuid(this long value)
        {
            var bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}
