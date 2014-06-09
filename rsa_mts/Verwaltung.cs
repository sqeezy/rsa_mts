using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace rsa_mts
{
    class Verwaltung
    {
        private int p;
	private int q;
	private int e;
	private int ggT;

	private String zeile = null;

	// Wird benötigt um einzulesen
	String myConsole = Console.In.ReadLine();

	/**
	 * 
	 * @return int Primzahl P
	 */
	public int getP() {
		return p;
	}

	/**
	 * setzt Primzal P
	 * 
	 * @param p
	 */
	public void setP(int p) {
		this.p = p;
	}

	/**
	 * 
	 * @return int Primzahl Q
	 */
	public int getQ() {
		return q;
	}

	/**
	 * setzt Primzahl Q
	 * 
	 * @param q
	 */
	public void setQ(int q) {
		this.q = q;
	}

	/**
	 * N ist das Produkt aus P & Q
	 * 
	 * @return int N
	 */
	public int getN() {
		return p * q;
	}

	/**
	 * ist das Produkt aus P-1 * Q-1
	 * 
	 * @return int Phi von N
	 */
	public int getPhiVonN() {
		return ((p - 1) * (q - 1));
	}

	/**
	 * 
	 * @return int Primzahl e
	 */
	public int getE() {
		return e;
	}

	/**
	 * setzt die Primzahl e
	 * 
	 * @param e
	 */
	public void setE(int e) {
		this.e = e;
	}

	/**
	 * 
	 * @return int Groesster Gemeinsamer Teiler
	 */
	public int getGGT() {
		return ggT;
	}

	/**
	 * Die Methode nutzt die Methode aussieben um Festzustellen ob eine Zahl
	 * eine Primzahl ist oder nicht
	 * 
	 * @param zahl
	 * @return boolean ob es eine Primzahl ist oder nicht
	 */
	private bool isPrimzahl(int zahl) {
		// Zahl wird an aussieben übergeben
		List<bool> liste = aussieben(zahl);

		return liste.ElementAt(zahl);
	}

	/**
	 * Sieb des Eratosthenes
	 * 
	 * @param zahl
	 * @return Arraylist mit Booleanwerten danach wird in isPrimzahl geschaut ob
	 *         diese Zahl in der Liste ist
	 */
	public static List<bool> aussieben(double zahl) {

		// Legt eine neue Liste an
        bool[] zahlenArray = new bool[Convert.ToInt32(zahl)];
		//List<bool> zahlenListe = new List<bool>();

		// Füllt die neue Liste mit lauter true-Elementen
		for (int i = 0; i <= zahl; i++) {
            zahlenArray[i] = true;
			//zahlenListe.Add(true);
		}

		for (int i = 2; i <= zahl; i++) {

			if (zahlenArray[i] == true) {
				int j = i;
				do {
					j = j + i;
					if (j <= zahl) {
						// Ist die Zahl ein Vielfaches einer
						// Primzahl, dann wird sie mit false
						// markiert
                        zahlenArray[i] = false;
					}
				} while (j <= zahl);
			}
		}
        List<bool> zahlenListe = zahlenArray.ToList();
		return zahlenListe;
	}

	/**
	 * Methode um P & Q einzulesen
	 * 
	 * @return String Primzahl wenn sie denn eine ist
	 */
	public String einlesenPrimzahl() {
		try {
			// Einlesen
			zeile = Console.In.ReadLine();
			// Zeile darf nicht leer sein
			if (!zeile.Equals("") && zeile != null) {
				// Wenn es eine Primzahl ist wird diese als String zurueck
				// gegeben
				if (this.isPrimzahl(Convert.ToInt32(zeile))) {
					return zeile;
				}
				// Wenn keine Primzahl wird die Methode rekursiv aufgerufen und
				// Pruefung erfolgt eneut
				else {
					Console.WriteLine("Das war keine Primzahl. Bitte Primzahl eingeben");
					return einlesenPrimzahl();
				}
				// Wenn nichts eingegeben wurde, wird die Methode rekursiv
				// aufgerufen und Pruefung erfolgt eneut
			} else {
				Console.WriteLine("Da wurde nichts eingegeben");
				return einlesenPrimzahl();
			}
			// Wirft Exception -- sollte aber nie passieren
		} catch (Exception e) {
			e.StackTrace.ToString();
		}
		return null;
	}

	/**
	 * Methode um e einzulesen
	 * 
	 * @return String Primzahl wenn sie denn eine ist und teilerfremd mit N ist
	 */
	public String einlesenPrimzahlE() {
		try {
			// Einlesen
			zeile = Console.In.ReadLine();
			// Zeile darf nicht leer sein
			if (!zeile.Equals("") && zeile != null) {
				// Wenn es eine Primzahl ist und diese Teilefremd zu N ist, wird
				// diese als String zurück gegeben
				if (this.isPrimzahl(Convert.ToInt32(zeile))) {
					setggT(Convert.ToInt32(zeile), getPhiVonN());
					if (getGGT() != 1) {
						// Wenn nicht Teilerfremd wird die Methode rekursiv
						// aufgerufen und Prüfung erfolgt eneut
						Console.WriteLine("Diese Zahlen sind nicht Teilerfremd! Bitte nochmal versuchen.");
						return einlesenPrimzahlE();
					} else {
						return zeile;
					}
					// Wenn keine Primzahl wird die Methode rekursiv aufgerufen
					// und Prüfung erfolgt eneut
				} else {
					Console.WriteLine("Das war keine Primzahl ! Bitte Primzahl eingeben");
					return einlesenPrimzahlE();
				}
				// Wenn nichts eingegeben wurde, wird die Methode rekursiv
				// aufgerufen und Prüfung erfolgt eneut
			} else {
				Console.WriteLine("Da wurde nichts eingegeben");
			}
			// Wirft Exception -- sollte aber nie passieren
		} catch (Exception e) {
            e.StackTrace.ToString();
		}
		return null;
	}

	/**
	 * Methode um Nachricht einzulesen
	 * 
	 * @return String eingelesene Zeile
	 */
	public String einlesenNachricht() {
		try {
			zeile = Console.In.ReadLine();
			return zeile;
		} catch (Exception e) {
            e.StackTrace.ToString();
		}
		return null;

	}

	/**
	 * Sucht den größten gemeinsamen Teiler von zwei NatŸrlichen Zahlen
	 * 
	 * @return int ggT
	 */
	public void setggT(int gegebeneZahl1, int gegebeneZahl2) {
		int rest = -1;
		int vorherigerRest = -1;

		while (rest != 0) {
			rest = gegebeneZahl1 % gegebeneZahl2;

			if (rest != 0) {
				vorherigerRest = rest;
			}

			gegebeneZahl1 = gegebeneZahl2;
			gegebeneZahl2 = Convert.ToInt32(rest);
		}
		this.ggT = vorherigerRest;
	}
    }
}
