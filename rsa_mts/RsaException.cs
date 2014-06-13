using System;

namespace rsa_mts
{
    /// <summary>
    /// A exception class special for this rsa implementation.
    /// </summary>
    internal class RsaException : Exception
    {
        public RsaException(string msg):base(msg)
        {
        }

        public RsaException(string msg,
                            Exception e) : base(msg, e)
        {
        }
    }
}