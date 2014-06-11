using System;

namespace rsa_mts
{
    internal class RsaException : Exception
    {
        public RsaException(string msg):base(msg)
        {
        }
    }
}