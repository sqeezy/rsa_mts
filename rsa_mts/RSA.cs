using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace rsa_mts
{
    internal class RSA
    {
        private BigInteger _n;
        private BigInteger _e;
        private BigInteger _d;

        public RSA(int primeOne = 1327, int primeTwo = 2099)
        {
            if (!IsPrime(primeOne)||!IsPrime(primeTwo))
            {
                throw new ArgumentException("Inputs have to be prime");
            }
            BigInteger p = new BigInteger(primeOne);
            BigInteger q = new BigInteger(primeTwo);

            _n = BigInteger.Multiply(p, q);
            BigInteger phiN = new BigInteger((primeOne - 1)*(primeTwo - 1));

            _e = new BigInteger(65537);//Fermatzahl
            _d = ModInverse(_e, phiN);
        }

        public int Encrypt(int msg)
        {
<<<<<<< HEAD
            get
            {
                try
                {
                    return new Tuple<int, int>((int)_e, (int)_n);
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
=======
            return (int)BigInteger.ModPow(new BigInteger(msg), _e, _n);
>>>>>>> 1f4c7733736d931bd34d7f39dc5cfc95cf008512
        }

        public int Decrypt(int msg)
        {
<<<<<<< HEAD
            get
            {
                try
                {
                    return new Tuple<int, int>((int)_d, (int)_n);
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
=======
            return (int) BigInteger.ModPow(new BigInteger(msg), _d, _n);
>>>>>>> 1f4c7733736d931bd34d7f39dc5cfc95cf008512
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
            List<bool> zahlenListe = new List<bool>();

            // Füllt die neue Liste mit lauter true-Elementen
            for (int i = 0; i <= n; i++)
            {
                zahlenListe.Add(true);
            }

            for (int i = 2; i <= n; i++)
            {

                if (zahlenListe[i] == true)
                {
                    int j = i;
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

<<<<<<< HEAD

        public byte[] Encrypt(byte[] data)
        {
            // Ursprung Ausgabetext
            byte[] ausgabetext = new byte[data.Length];

            // Fuer jedes Zeichen im Eingabetext
            for (int i = 0; i < data.Length; i++)
            {
                // zu Behandelndes Zeichen = eingabetext an der Stelle i
                byte zubehandelndesZeichen = data[i];

                // zu behandelndes Zeichen wird eindeutige Zahl(int) vergeben und zu
                // BigInteger konvertiert da es sich genauer rechnen laesst
                BigInteger bigValueOfByte = (int)zubehandelndesZeichen;

                // zwischenergebnis = zu Behandelndes Zeichen (bzw jetzt eindeutige zahl)hoch Variable e
                BigInteger zwischenergebnis = potenzieren(bigValueOfByte, (int)_e);

                //verschluesselte Zahl = zu Behandelndes Zeichen (bzw jetzt eindeutige zahl) modulo N
                BigInteger verschluesseltesZeichen = zwischenergebnis % _n;

                //Verschluesselte Zahl wird zu String konvertiert und dann an den Ausgabetext angehangen
                ausgabetext[i] = (byte)verschluesseltesZeichen;
            }
            //gibt ausgabetext/Geheimtext zurueck
            return ausgabetext;
        }


        public byte[] Decrypt(byte[] encryptedData)
        {
            //d = multiplikative Inverse von e
            _d = modInverse(_e, _phi_n);

            //d als int wird benoetigt, da BigInteger.pow ein int als exponent benoetigt
            int dAlsInt = (int)_d;

            //Neues byteArray fuer spaeteren klartext
            byte[] klartext = new byte[encryptedData.Length];

            //fuer jeden Code im Array
            for (int i = 0; i < klartext.Length; ++i)
            {
                //code wird zu int geparst - da BigInteger nur int's und longs annimmt
                int codeAlsLong = Convert.ToInt32(klartext[i]);

                //code(aktuell als int) wird zu bigInteger konvertiert da es genauer rechnet
                BigInteger codeBI = (BigInteger)codeAlsLong;

                //zwischenrechnung = code wird mit d(int) potenziert
                BigInteger zwischenrechnung = potenzieren(codeBI, dAlsInt);

                //brauchbare Zahl = der int-Wert von zwischenrechnung modulo n
                int brauchbareZahl = (int)(zwischenrechnung % (BigInteger)_n);

                //brauchbare zahl wird zu char gecastet - da jeder char eine eindeute ID hat
                byte gesuchterBuchstabe = (byte)brauchbareZahl;

                //klartext wird um gesuchten Buchstaben erweitert  
                klartext[i] = gesuchterBuchstabe;
            }

            // gibt klartext zurueck
            return klartext;
        }

        /// <summary>
=======
         /// <summary>
>>>>>>> 1f4c7733736d931bd34d7f39dc5cfc95cf008512
        /// Methode um Modualre Inverse mittels Big Integer zu berechen
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <returns> modulare Inverse zweier Zahlen</returns>
        private BigInteger ModInverse(BigInteger a, BigInteger n)
        {
            BigInteger i = n, v = 0, d = 1;
            while (a > 0)
            {
                BigInteger t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }

        /// <summary>
        /// Potenziert zwei Zahlen miteinander
        /// </summary>
        /// <param name="basis als BigInteger"></param>
        /// <param name="exponent als Integer"></param>
        /// <returns>Big Integer Ergebnis=basis^exponent</returns>
        public BigInteger potenzieren(BigInteger basis, int exponent)
        {
            BigInteger ergebnis = 1;
            for (int i = 1; i <= exponent; ++i)
            {
                ergebnis = ergebnis * basis;
            }
            return ergebnis;
        }
    }
}