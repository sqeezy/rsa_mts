using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace rsa_mts
{
    class Entschluesselung
    {
        private Verwaltung verwaltung;

        //aktuelle Verwaltung wird uebergeben
        public Entschluesselung(Verwaltung v)
        {
            this.verwaltung = v;
        }

        /**
         * Methode um geheimtext zu entschluesseln
         * @param String geheimtext
         * @param int n - als schluessel
         * @param int e - als schluessel
         * @return String Klartext
         */
        public String entschluesseln(String geheimtext, int n, int e)
        {
            //e zu BigInteger konvertiert damit Rechnung genauer ist
            BigInteger eBig = (BigInteger)e;
            //phiVonN zu BigInteger konvertiert damit Rechnung genauer ist
            BigInteger bigPhiVonN = (BigInteger)verwaltung.getPhiVonN();
            //d = multiplikative Inverse von e
            BigInteger d = modInverse(eBig, bigPhiVonN);

            //KLartext ist zunaechst leer
            String klartext = "";

            //geheimtext wird bei ; gesplittet und in ein Array gefuegt - dadurch benoetigt man keine Groessenangabe
            String[] codes = geheimtext.Split(new Char[] { ';' });

            //fuer jeden Code im Array
            foreach (String code in codes)
            {

                //code wird zu long geparst - da BigInteger nur int's und longs annimmt
                long codeAlsLong = Convert.ToInt32(code);

                //code(aktuell als long) wird zu bigInteger konvertiert da es genauer rechnet
                BigInteger codeBI = (BigInteger)codeAlsLong;

                //zwischenrechnung = code wird mit d potenziert
                double zwischenrechnung = Math.Pow((double)codeBI, (double)d);

                //brauchbare Zahl = der int-Wert von zwischenrechnung modulo n
                int brauchbareZahl = (int)zwischenrechnung % n;

                //brauchbare zahl wird zu char gecastet - da jeder char eine eindeute ID hat
                char gesuchterBuchstabe = (char)(brauchbareZahl);

                //klartext wird um gesuchten Buchstaben erweitert  
                klartext += gesuchterBuchstabe;
            }

            // gibt klartext zurueck
            return klartext;
        }

        /// <summary>
        /// Methode um Modualre Inverse mittels Big Integer zu berechen
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <returns> modulare Inverse zweier Zahlen</returns>
        private BigInteger modInverse(BigInteger a, BigInteger n)
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
    }
}


