using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Binarne_średnie
{
    class Program
    {

        private static object indeksLiczby;
        static ulong suma;
        static double CzasRoznica;
        static ulong dlugosc;
        static long ilosc;
        static int Binarne(int[] tab, int Wartosc, int WielkoscTablicy)
        {
            ilosc = 0;
            suma = 0;
            dlugosc = 0;
            int Lewa = 0;
            int Prawa = WielkoscTablicy - 1;
            int Srodek = 0;
            while (Lewa <= Prawa)
            {
                suma += (ulong)tab[ilosc];
                dlugosc += (ulong)Math.Pow(2, ilosc - 1);
                Srodek = (Lewa + Prawa) / 2;
                if (tab[Srodek] == Wartosc)
                {
                    ilosc++;
                    suma += (ulong)tab[ilosc];
                    dlugosc += (ulong)Math.Pow(2, ilosc - 1);
                    return Srodek;

                }
                else if (tab[Srodek] < Wartosc)
                {
                    ilosc++;
                    suma += (ulong)tab[ilosc];
                    dlugosc += (ulong)Math.Pow(2, ilosc - 1);
                    Lewa = Srodek + 1;

                }
                else
                {
                    ilosc++;
                    suma += (ulong)tab[ilosc];
                    dlugosc += (ulong)Math.Pow(2, ilosc - 1);
                    Prawa = Srodek - 1;

                }
            }
            return 0;
        }
        static int BinarneBezInstrumentacji(int[] tab, int Wartosc, int WielkoscTablicy)
        {

            int Lewa = 0;
            int Prawa = WielkoscTablicy - 1;
            int Srodek = 0;
            while (Lewa <= Prawa)
            {
                Srodek = (Lewa + Prawa) / 2;
                if (tab[Srodek] == Wartosc)
                {

                    return Srodek;
                }
                else if (tab[Srodek] < Wartosc)
                {
                    Lewa = Srodek + 1;
                }
                else
                {
                    Prawa = Srodek - 1;
                }
            }
            return 0;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Wyszukiwanie binarne - wariant średni: ");
            Console.WriteLine();
            int Liczba = 0;

            for (int i = 5368709; i < 268435456; i += 5368709)
            {

                Liczba++;
                int[] tablica = new int[i];
                int szukana = tablica.Length - 1;

                for (int j = 0; j < i; j++)
                {
                    tablica[j] = j;
                }

                Array.Sort(tablica);

                var Czas = new System.Diagnostics.Stopwatch();
                Czas.Start();

                indeksLiczby = BinarneBezInstrumentacji(tablica, szukana, tablica.Length);
                Czas.Stop();
                CzasRoznica = Czas.ElapsedTicks;
                indeksLiczby = Binarne(tablica, szukana, tablica.Length);
                ulong Wynik = suma / (ulong)ilosc;
                Console.WriteLine("Nr porządkowy {0}, indeks  {1} Złożoność {2}, Czas {3} " + "ticks/s  ", Liczba, indeksLiczby, Wynik, CzasRoznica);


            }
            Console.ReadKey();
        }
    }
}



