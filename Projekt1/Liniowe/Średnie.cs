using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Liniowy_średni
{
    class Program
    {
        static int maxRozmiarTablicy = 268435456;

        static long wynik, liczbaoperacji, suma;

        static void Main()
        {
            Console.WriteLine("Wyszukiwanie liniowe - wariant średni: ");
            Console.WriteLine();
            for (int i = maxRozmiarTablicy - 50000; i < maxRozmiarTablicy; i += 1000)
            {

                int[] tab = new int[i];
                for (int a = 0; a < tab.Length; a++)
                {
                    tab[a] = a + 1;
                }
                int szukana = i / 2;
                int pozycja;

                long ElapsedTime = 0;
                double ElapsedSeconds = 0;
                long StartingTime = Stopwatch.GetTimestamp();
                LinioweBezInstrumentacji(tab, szukana);
                long EndingTime = Stopwatch.GetTimestamp();
                ElapsedTime = EndingTime - StartingTime;
                ElapsedSeconds = ElapsedTime * (1.0 / Stopwatch.Frequency);
                pozycja = Liniowe(tab, szukana);
                wynik = suma / liczbaoperacji;
                Console.WriteLine("Nr indeksu: " + tab.Length + " Szukana liczba: " +szukana + " Pozycja: " + pozycja + " Wynik: " + wynik + " Czas: " + ElapsedSeconds );



            }
        }
        static int LinioweBezInstrumentacji(int[] tab, int szukana)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] == szukana)
                {
                    return i;
                }

            }
            return -1;
        }
        static int Liniowe(int[] tab, int szukana)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                liczbaoperacji++;
                suma += tab[i];
                if (tab[i] == szukana)
                {
                    return i;
                }

            }
            return -1;

            Console.ReadKey();
        }

    }
}