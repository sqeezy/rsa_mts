using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace rsa_mts
{
    internal class RSA
    {
        private BigInteger _d;
        private BigInteger _e;
        private BigInteger _n;

        public RSA(int primeOne = 1327,
                   int primeTwo = 2099)
        {
            if (!IsPrime(primeOne) || !IsPrime(primeTwo))
            {
                throw new ArgumentException("Inputs have to be prime");
            }
            var p = new BigInteger(primeOne);
            var q = new BigInteger(primeTwo);

            _n = BigInteger.Multiply(p, q);
            var phiN = new BigInteger((primeOne - 1)*(primeTwo - 1));

            _e = new BigInteger(65537); //Fermatzahl
            _d = ModInverse(_e, phiN);
        }

        public int Encrypt(int msg)
        {
            return (int) ModPow(new BigInteger(msg), _e, _n);
        }

        public int Decrypt(int msg)
        {
            return (int) ModPow(new BigInteger(msg), _d, _n);
        }

        /// <summary>
        /// Sieb des Eratosthenes
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Arraylist mit Booleanwerten danach wird in isPrimzahl geschaut ob 
        /// diese Zahl in der Liste ist</returns>
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
        /// Methode um Modualre Inverse mittels Big Integer zu berechen
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <returns> modulare Inverse zweier Zahlen</returns>
        private BigInteger ModInverse(BigInteger a,
                                      BigInteger n)
        {
            BigInteger i = n,
                       v = 0,
                       d = 1;
            while (a > 0)
            {
                BigInteger t = i/a,
                           x = a;
                a = i%x;
                i = x;
                x = d;
                d = v - t*x;
                v = x;
            }
            v %= n;
            if (v < 0)
            {
                v = (v + n)%n;
            }
            return v;
        }

<<<<<<< HEAD
        /// <summary>
        /// Potenziert zwei Zahlen miteinander
        /// </summary>
        /// <param name="basis als BigInteger"></param>
        /// <param name="exponent als Integer"></param>
        /// <returns>Big Integer Ergebnis=basis^exponent</returns>
        public BigInteger potenzieren(BigInteger basis,
                                      int exponent)
        {
            BigInteger ergebnis = 1;
            if (exponent < 0)
            {
                exponent = exponent * -1;
                for (var i = 1; i <= exponent; ++i)
                {
                    ergebnis = ergebnis * basis;
                }
                return 1 / ergebnis;
            }
            else
            {
                for (var i = 1; i <= exponent; ++i)
                {
                    ergebnis = ergebnis * basis;
                }
            }
            return ergebnis;
        }

=======
>>>>>>> 90cd6e37035bde08ce1a374af59b43fbb325fc6b
        private BigInteger ModPow(BigInteger basis,
                                  BigInteger exp,
                                  BigInteger mod)
        {
            BigInteger result = 1;
            while (exp > 0)
            {
                if (!exp.IsEven)
                {
                    result = (result*basis)%mod;
                }
                exp >>= 1;
                basis = (basis*basis)%mod;
            }
            return result;
        }
    }
}