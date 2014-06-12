using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Numerics;
using System.Text;

namespace rsa_mts
{
    internal class RSA
    {
        private BigInteger _p;
        private BigInteger _q;
        private BigInteger _n;
        private BigInteger _phi_n;
        private BigInteger _e;
        private BigInteger _d;

        public RSA(int p = 17, int q = 19)
        {
            //Testen ob p und q prim sind
        }

        public Tuple<int, int> PublicKey
        {
            get
            {
                try
                {
                    return new Tuple<int, int>((int) _e, (int) _n);
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Some error thing.");
                    Console.ReadKey();
                    throw new RsaException("Error because of BigInteger to int cast.");
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Tuple<int, int> PrivateKey
        {
            get
            {
                try
                {
                    return new Tuple<int, int>((int) _d, (int) _n);
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Some error thing.");
                    Console.ReadKey();
                    throw new RsaException("Error because of BigInteger to int cast.");
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private bool IsPrime(int n)
        {
            throw new NotImplementedException();
        }

        public byte[] Encrypt(byte[] data)
        {
            throw new NotImplementedException();
        }

        public byte[] Decrypt(byte[] encryptedData)
        {
            throw new NotImplementedException();
        }
    }
}