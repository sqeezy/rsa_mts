using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsa_mts
{
    class Program
    {
        static void Main(string[] args)
        {

            // Neue Instanz der Verwaltung
            Verwaltung verwaltung = new Verwaltung();
            // Zeile ist anfangs null
            String zeile = null;


            Console.WriteLine("Moechten Sie einen Klartext verschluesseln? Waehlen Sie die 1");

            Console.WriteLine("Oder wenn sie Einen Geheimtext entschluesseln wollen, waehlen Sie die 2");

            zeile = verwaltung.einlesenNachricht();
            if (zeile.Equals("1"))
            {


                Console.WriteLine("Bitte geben Sie die zweistellige Primzahl = e, die ihnen mitgeteilt wurde ein");
                // Zugiff auf Verwaltung einlesen PrimzahlE , da noch ueberprueft
                // wird ob teilerfremd
                zeile = verwaltung.einlesenPrimzahlE();
                // wenn Primzahl und teilerfremd, wird diese in int geparst und e
                // zugewiesen
                verwaltung.setE(Convert.ToInt32(zeile));

                Console.WriteLine("Bitte geben Sie n ein");

                zeile = verwaltung.einlesenN();
                // wenn Primzahl und teilerfremd, wird diese in int geparst und e
                // zugewiesen
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

            }
            else if (zeile.Equals("2"))
            {

                // Zweistellig ist wichtig sonst kommen bei der entschluesselung
                // kryptische Ergebnisse raus
                Console.WriteLine("bitte geben sie die zweistellige Primzahl = p ein:");
                // Zugiff auf Verwaltung einlesen Primzahl
                zeile = verwaltung.einlesenPrimzahl();

                // wenn Primzahl, wird diese in int geparst und p zugewiesen
                verwaltung.setP(Convert.ToInt32(zeile));

                // Zweistellig ist wichtig sonst kommen bei der entschluesselung
                // kryptische Ergebnisse raus
                Console.WriteLine("Bitte geben Sie die andere zweistellige Primzahl = q ein:");
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
                Console.WriteLine("Nun bitte der zu entschluesselne Code.");
                // neue Instanz der Entschluesselung wird gestartet und die
                // Verwaltung uebergeben
                Entschluesselung entschluesselung = new Entschluesselung(verwaltung);
                String code = verwaltung.einlesenNachricht();
                Console.WriteLine("Entschluesselt: "
                        + entschluesselung.entschluesseln(code, verwaltung.getN(),
                                verwaltung.getE()));

            }

        }
    }

}

