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

        /// <summary>
        /// Methode die den Klartext verschluesselt.
        /// Uebergeben wird dabei nur der Klartext,
        /// da ja in der bereits im Konstruktor die Verwaltung uebergeben wurde 
        /// und somit alle benoetigten Daten da sind.
        /// </summary>
        /// <param name="eingabetext"></param>
        /// <returns>String Geheimtext</returns>

        public String verschluesseln(String eingabetext)
        {
            // Ursprung Ausgabetext
            String ausgabetext = "";

            // Fuer jedes Zeichen im Eingabetext
            for (int i = 0; i < eingabetext.Length; i++)
            {
                // zu Behandelndes Zeichen = eingabetext an der Stelle i
                char zubehandelndesZeichen = eingabetext[i];

                // zu behandelndes Zeichen wird eindeutige Zahl(int) vergeben und zu
                // BigInteger konvertiert da es sich genauer rechnen laesst
                BigInteger bigValueOfChar = (int)zubehandelndesZeichen;

                // zwischenergebnis = zu Behandelndes Zeichen (bzw jetzt eindeutige zahl)hoch Variable e
                BigInteger zwischenergebnis = BigInteger.Pow(bigValueOfChar, verwaltung.getE());

                //verschluesselte Zahl = zu Behandelndes Zeichen (bzw jetzt eindeutige zahl) modulo N
                BigInteger verschluesseltesZeichen = zwischenergebnis % ((BigInteger)verwaltung.getClearN());

                //Verschluesselte Zahl wird zu String konvertiert und dann an den Ausgabetext angehangen
                ausgabetext += verschluesseltesZeichen.ToString() + ";";
            }
            //gibt ausgabetext/Geheimtext zurueck
            return ausgabetext;
        }

    }
}
