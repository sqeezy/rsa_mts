using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace rsa_mts
{
    /// <summary>
    /// A class to encrypt single chunks of data using the RSA encryption.
    /// This is not the standard implementation which uses padding and encrypt greater blocks of data.
    /// </summary>
    public class RSA
    {
        private readonly BigInteger _d;
        private readonly BigInteger _e;
        private readonly BigInteger _n;

        /// <summary>
        /// Initializes a new instance of the <see cref="RSA"/> class.
        /// This constructor is private because a method to find e and d for the algorithm is missing at the momment.
        /// </summary>
        /// <param name="primeOne">The prime one.</param>
        /// <param name="primeTwo">The prime two.</param>
        /// <exception cref="System.ArgumentException">Inputs have to be prime.</exception>
        private RSA(int primeOne,
                   int primeTwo, int primeThree)
        {
            if (!IsPrime(primeOne) || !IsPrime(primeTwo) || !IsPrime(primeThree) || GGT(((primeOne - 1) * (primeTwo - 1)), primeThree) != 1)
            {
                throw new ArgumentException("Inputs have to be prime and e must be coprime to ((p-1) * (q-1))");
            }
            var p = new BigInteger(primeOne);
            var q = new BigInteger(primeTwo);
            var e = new BigInteger(primeThree);
            _e = (BigInteger)e;

            _n = BigInteger.Multiply(p, q);
            var phiN = new BigInteger((primeOne - 1) * (primeTwo - 1));

            //e = new BigInteger(65537); //Fermatzahl - Default that works with given default primes.
            _d = ModInverse(_e, phiN);
        }

        /// <summary>
        /// Constructor with default values.
        /// </summary>
        public RSA(): this(1327, 2099, 65537)
        {
        }

        /// <summary>
        /// Encrypts the specified message.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <returns></returns>
        /// <exception cref="RsaException">A problem occured while encrypting.</exception>
        public int Encrypt(int msg)
        {
            try
            {
                return (int)ModPow(new BigInteger(msg), _e, _n);
            }
            catch (Exception ex)
            {
                throw new RsaException("A problem occured while encrypting: ", ex);
            }
        }

        /// <summary>
        /// Decrypts the specified message.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <returns></returns>
        /// <exception cref="RsaException">A problem occured while decrypting.</exception>
        public int Decrypt(int msg)
        {
            try
            {
                return (int)ModPow(new BigInteger(msg), _d, _n);
            }
            catch (Exception ex)
            {
                throw new RsaException("A problem occured while decrypting: ", ex);
            }
        }

        /// <summary>
        /// Sieve of Erathosthenes
        /// Method to determine weather a number is prime or not.
        /// </summary>
        /// <param name="n">The number which we want to check.</param>
        private bool IsPrime(int n)
        {
            // Legt eine neue Liste an
            var zahlenListe = new List<bool>();

            // Füllt die neue Liste mit lauter true-Elementen
            for (var i = 0; i <= n; i++)
            {
                zahlenListe.Add(true);
            }

            for (var i = 2; i <= n; i++)
            {
                if (zahlenListe[i])
                {
                    var j = i;
                    do
                    {
                        j = j + i;
                        if (j <= n)
                        {
                            // Ist die Zahl ein Vielfaches einer
                            // Primzahl, dann wird sie mit false
                            // markiert
                            zahlenListe[j] = false;
                        }
                    } while (j <= n);
                }
            }

            return zahlenListe.ElementAt(n);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gegebeneZahl1"></param>
        /// <param name="gegebeneZahl2"></param>
        public int GGT(int gegebeneZahl1, int gegebeneZahl2)
        {
            int rest = -1;
            int vorherigerRest = -1;

            while (rest != 0)
            {
                rest = gegebeneZahl1 % gegebeneZahl2;

                if (rest != 0)
                {
                    vorherigerRest = rest;
                }

                gegebeneZahl1 = gegebeneZahl2;
                gegebeneZahl2 = (int)rest;
            }
            return vorherigerRest;
        }

        /// <summary>
        /// Computes the modular inverse of a number in relation to a certain modulus.
        /// </summary>
        /// <param name="a">The number to compute the inverse to.</param>
        /// <param name="n">The modulus to which we relate</param>
        /// <returns>The modular inverse.</returns>
        private BigInteger ModInverse(BigInteger a,
                                      BigInteger n)
        {
            BigInteger i = n,
                       v = 0,
                       d = 1;
            while (a > 0)
            {
                BigInteger t = i / a,
                           x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0)
            {
                v = (v + n) % n;
            }
            return v;
        }

        /// <summary>
        /// Computes the modulus of a number which we get from raising some base to a certain power.
        /// </summary>
        /// <param name="baseToRaise">The basis.</param>
        /// <param name="power">The power.</param>
        /// <param name="modulus">The modulus.</param>
        /// <returns></returns>
        private BigInteger ModPow(BigInteger baseToRaise,
                                  BigInteger power,
                                  BigInteger modulus)
        {
            BigInteger result = 1;
            while (power > 0)
            {
                if (!power.IsEven)
                {
                    result = (result * baseToRaise) % modulus;
                }
                power >>= 1;
                baseToRaise = (baseToRaise * baseToRaise) % modulus;
            }
            return result;
        }
    }
}