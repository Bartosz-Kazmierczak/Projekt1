using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projekt_do_zrobienia
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
                Srodek = (Lewa + Prawa) / 2;
                if (tab[Srodek] == Wartosc)
                {
                    ilosc++;
                    suma += (ulong)tab[ilosc];
                    dlugosc += (ulong)Math.Pow(2, ilosc - 1);

                }
                else if (tab[Srodek] < Wartosc)
                {
                    ilosc++;
                    suma += (ulong)tab[ilosc];
                    Lewa = Srodek + 1;
                    dlugosc += (ulong)Math.Pow(2, ilosc - 1);
                }
                else
                {
                    ilosc++;
                    suma += (ulong)tab[ilosc];
                    Prawa = Srodek - 1;
                    dlugosc += (ulong)Math.Pow(2, ilosc - 1);
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
            ilosc = 0;
            suma = 0;
            dlugosc = 0;
            Random r = new Random();
            int LosowaLiczba = r.Next();
            int Liczba = 0;

            Console.WriteLine("Wyszukiwanie binarne - wariant pesymistyczny: ");

            Console.WriteLine();

            for (int i = 5368709; i < 268435456; i += 5368709)
            {
                int szukana = -1;

                Liczba++;
                int[] tablica = new int[i];
                for (int j = 0; j < tablica.Length; j++)
                {
                    tablica[j] = j + 1;

                }

                Array.Sort(tablica);

                var Czas = new System.Diagnostics.Stopwatch();

                Czas.Start();
                BinarneBezInstrumentacji(tablica, szukana, tablica.Length);
                Czas.Stop();
                CzasRoznica = Czas.ElapsedTicks;
                indeksLiczby = Binarne(tablica, szukana, tablica.Length);
                ulong Wynik = suma / (ulong)ilosc;

                Console.WriteLine("Nr porządkowy {0}, indeks  {1} Złożoność {2}, Czas {3}  ", Liczba, indeksLiczby, Wynik, CzasRoznica);


            }

        }
    }
}