using System;
using System.Numerics;

namespace Kis.Base.Extensions
{
    public static class GuidExtensions
    {
        public static BigInteger ToNumber(this Guid guid)
        {
            var guidb = guid.ToByteArray();
            var bytes = new byte[guidb.Length + 1];
            Array.Reverse(guidb, 0, 4);
            Array.Reverse(guidb, 4, 2);
            Array.Reverse(guidb, 6, 2);
            Buffer.BlockCopy(guidb, 0, bytes, 1, guidb.Length);
            Array.Reverse(bytes, 0, bytes.Length);
            return new BigInteger(bytes);
        }
    }
}