using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

namespace rsa_mts
{
    class Verschluesselung
    {
        private Verwaltung verwaltung;

        // aktuelle Verwaltung wird uebergeben
        public Verschluesselung(Verwaltung v)
        {
            this.verwaltung = v;
        }

        /**
         * Methode welche klartext in geheimtext Verschluesselt
         * 
         * @param String
         *            eingabetext=klartext
         * @return String ausgabetext=geheimtext
         */
        public String verschluesseln(String eingabetext)
        {
            // Ursprung Ausgabetext
            String ausgabetext = "";

            // FŸr jedes Zeichen im Eingabetext
            for (int i = 0; i < eingabetext.Length; i++)
            {
                // zu Behandelndes Zeichen = eingabetext an der Stelle i
                char zubehandelndesZeichen = eingabetext.ElementAt(i);

                // zu behandelndes Zeichen wird eindeutige Zahl(int) vergeben und zu
                // BigInteger konvertiert da es sich genauer rechnen lŠsst
                BigInteger intValueOfChar = (int)zubehandelndesZeichen;

                // zwischenergebnis = zu Behandelndes Zeichen (bzw jetzt eindeutige zahl)hoch Variable e
                BigInteger zwischenergebnis = BigInteger.Pow(intValueOfChar, verwaltung.getE());

                //verschluesselte Zahl = zu Behandelndes Zeichen (bzw jetzt eindeutige zahl) modulo N

                BigInteger verschlZeichen = zwischenergebnis % (BigInteger)verwaltung.getN();
                //BigInteger verschluesseltesZeichen = zwischenergebnis.mod(BigInteger.valueOf(verwaltung.getN()));

                //Verschluesselte Zahl wird zu String konvertiert und dann an den Ausgabetext angehangen
                ausgabetext += (String)verschlZeichen.ToString() + ";";
            }
            //gibt ausgabetext zurueck
            return ausgabetext;
        }
    }
}
