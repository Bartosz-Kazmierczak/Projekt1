using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Liniowy_pesymistyczny
{
    class Program
    {
        private static long CzasStart;
        private static object indeksLiczby;
        private static long CzasStop;
        private static double CzasRoznica;
        static long suma;
        static long ilosc;

        static int LinioweBezInstrumentacji(int[] tab, int Szukana)
        {
            for (int i = 0; i < tab.Count(); i++)
            {
                if (tab[i] == Szukana)
                {
                    return i;
                }

            }
            return 0;
        }
        static int Liniowe(int[] tab, int Szukana)
        {
            for (int i = 0; i < tab.Count(); i++)
            {
                ilosc++;
                if (tab[i] == Szukana)
                {
                    suma += tab[i];
                    return i;
                }

            }
            return 0;
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            int LosowaLiczba = r.Next();
            int szukana = -1;
            int Liczba = 0;
            Console.WriteLine("Wyszukiwanie liniowe - wariant pesymistyczny: ");
            Console.WriteLine();
            for (int i = 5368709; i < 268435456; i += 5368709)
            {
                
                Liczba++;
                int[] tablica = new int[i];

                for (int j = 0; j < tablica.Length; j++)
                {
                    tablica[j] = j;
                    suma += tablica[j];
                }


                //long wynik = suma / ilosc;
                CzasStart = Stopwatch.GetTimestamp();
                LinioweBezInstrumentacji(tablica, szukana);
                CzasStop = Stopwatch.GetTimestamp();
                indeksLiczby = Liniowe(tablica, szukana);
                CzasRoznica = (CzasStop - CzasStart) * (1.0 / Stopwatch.Frequency);
                Console.WriteLine("Nr porządkowy {0}, indeks  {1} Złożoność {2}, Czas {3}  ", Liczba, indeksLiczby, ilosc, CzasRoznica);

            }
            Console.ReadKey();
        }
    }
}


