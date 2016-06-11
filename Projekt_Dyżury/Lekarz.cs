using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dyżury
{
    class Lekarz : Osoba, InterfejsLekarz
    {
        public override string Imie { get; set; }
        public override string Nazwisko { get; set; }
        public int numerLekarza { get; set; }
        public int iloscDniNiechcianych { get; set; }
        public string ulubionyDzien { get; set; }
        public char ulubionyDzienPora { get; set; }
        private int[] niechcianeDni;
        public int iloscDyzurow { get; set; }

        public override void TworzenieNiechcianychDni()
        {
            this.niechcianeDni = new int[this.iloscDniNiechcianych];
            for (int i = 0; i < this.iloscDniNiechcianych; i++)
            {
                Console.WriteLine("Podaj numer dnia w ktorym lekarz nie chce miec dyzurow (" + (i + 1) + "):");
                this.niechcianeDni[i] = int.Parse(Console.ReadLine());
            }
        }

        public override Boolean SprawdzanieNiechianychDni(int numerDnia)
        {
            Boolean zgodnosc = true;
            for (int i = 0; i < this.iloscDniNiechcianych; i++)
            {
                if (niechcianeDni[i] == numerDnia) zgodnosc = false;
            }
            return zgodnosc;
        }

        public override void WypisanieNiechcianychDni(int numer)
        {
            Array.Sort(this.niechcianeDni);
            Console.Write("Numery tych dni: ");
            for (int i = 0; i < this.iloscDniNiechcianych; i++)
            {
                Console.Write(this.niechcianeDni[i]);
                if (i != (this.iloscDniNiechcianych - 1))
                {
                    Console.Write(", ");
                }
            }
        }

        public void Wypisanie(string napis)
        {
            Console.Write(napis + "\n");
        }
        public void Wypisanie(int numer)
        {
            Console.Write(numer + "\n");
        }
        public void Wypisanie(char znak)
        {
            Console.Write(znak + "\n");
        }
    }
}
