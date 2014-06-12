using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsa_mts
{
    class Program
    {
        /// <summary>
        /// Main Methode
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
<<<<<<< HEAD
=======
            byte[] data = FileRead.Read("textdatei.txt");

            //ausgabe in konsole

            //verschlüsseln

            //ausgabe in konsole

            //entschlüsseln

            //ausgabe in konsole
        }

        //erstmal ersetzt
   /*     static void Main_old(string[] args)
        {

>>>>>>> 61b282a0a7b51f3f4c1fd398daa62c2051c343c1
            // Neue Instanz der Verwaltung
            Verwaltung verwaltung = new Verwaltung();
            // Zeile ist anfangs null
            String zeile = null;

            Console.WriteLine("Moechten Sie einen Klartext verschluesseln? Waehlen Sie die 1");

            Console.WriteLine("Oder wenn sie Einen Geheimtext entschluesseln wollen, waehlen Sie die 2");

            //Zwar wird keine Nachricht eingelesen, Methode bietet sich dafuer aber an
            zeile = verwaltung.einlesenNachricht();
            
            //wen 1 eingegeben wurde, wird Klartext verschluesselt
            if (zeile.Equals("1"))
            {
                Console.WriteLine("Bitte geben Sie die mindestens zweistellige Primzahl = e, die ihnen mitgeteilt wurde ein");
                // Zugiff auf Verwaltung einlesen PrimzahlE , da noch ueberprueft
                // wird ob teilerfremd
                zeile = verwaltung.einlesenPrimzahlE();
                // wenn e = Primzahl und teilerfremd, wird diese in int geparst und e in der Verwaltung
                // zugewiesen
                verwaltung.setE(Convert.ToInt32(zeile));

                Console.WriteLine("Bitte geben Sie n ein");

                //n einlesen
                zeile = verwaltung.einlesenN();
                //n wird zu int konvertiert und in der Verwaltung gesetzt
                verwaltung.setN(Convert.ToInt32(zeile));

                Console.WriteLine("NACHRICHT");
                Console.WriteLine("************************");
                Console.WriteLine("Nun bitte die zu verschluesselnde Nachricht");
                // Zugiff auf Verwaltung einlesen Nachricht
                zeile = verwaltung.einlesenNachricht();

                // neue Instanz der Verschluesselung wird gestartet und die
                // Verwaltung uebergeben
                Verschluesselung verschluesselung = new Verschluesselung(verwaltung);

                // code = verschluesselter text
                String code = verschluesselung.verschluesseln(zeile);
                Console.WriteLine("Verschluesselt " + code);
                Console.WriteLine("");
                Console.WriteLine("OEFFENTLICHE SCHLUESSEL");
                Console.WriteLine("n= " + verwaltung.getClearN());
                Console.WriteLine("e= " + verwaltung.getE());
                Console.ReadKey();
            }

            //wenn 2 eingegeben wurde wird geheimtext entschluesselt
            else if (zeile.Equals("2"))
            {
                // Zweistellig ist wichtig sonst kommen bei der entschluesselung
                // kryptische Ergebnisse raus
                Console.WriteLine("bitte geben sie eine mindestens zweistellige Primzahl = p ein:");
                // Zugiff auf Verwaltung einlesen Primzahl
                zeile = verwaltung.einlesenPrimzahl();

                // wenn Primzahl, wird diese in int geparst und p zugewiesen
                verwaltung.setP(Convert.ToInt32(zeile));

                // Zweistellig ist wichtig sonst kommen bei der entschluesselung
                // kryptische Ergebnisse raus
                Console.WriteLine("Bitte geben Sie die andere mindestens zweistellige Primzahl = q ein:");
                // Zugiff auf Verwaltung einlesen Primzahl
                zeile = verwaltung.einlesenPrimzahl();
                // wenn Primzahl, wird diese in int geparst und q zugewiesen
                verwaltung.setQ(Convert.ToInt32(zeile));

                Console.WriteLine("Bitte geben Sie den Zahl e vom oeffentlichen Schluessel ein, welcher ihnen mitgeteilt wurde");
                // Zugiff auf Verwaltung einlesen PrimzahlE , da noch ueberprueft
                // wird ob teilerfremd
                zeile = verwaltung.einlesenPrimzahlE();
                // wenn Primzahl und teilerfremd, wird diese in int geparst und e
                // zugewiesen
                verwaltung.setE(Convert.ToInt32(zeile));
                Console.WriteLine("GEHEIMCODE");
                Console.WriteLine("***************************************");
                Console.WriteLine("Nun bitte der zu entschluesselne Code.");
                // neue Instanz der Entschluesselung wird gestartet und die
                // aktuelle Verwaltung wird uebergeben
                Entschluesselung entschluesselung = new Entschluesselung(verwaltung);
                String code = verwaltung.einlesenNachricht();
                Console.WriteLine("Entschluesselt: "
                        + entschluesselung.entschluesseln(code, verwaltung.getN(),
                                verwaltung.getE()));
                Console.ReadKey();
            }
        }
    */}
}

