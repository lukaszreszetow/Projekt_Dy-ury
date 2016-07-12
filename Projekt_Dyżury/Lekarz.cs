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

        public override void TworzenieNiechcianychDni(int IloscDniWMiesiacu)
        {
            this.niechcianeDni = new int[this.iloscDniNiechcianych];
            for (int i = 0; i < this.iloscDniNiechcianych; i++)
            {
                Boolean testpoprawnosci = false;
                do
                {
                    Console.WriteLine("Podaj numer dnia w ktorym lekarz nie chce miec dyzurow (" + (i + 1) + "):");
                    try
                    {
                        int numerDnia = int.Parse(Console.ReadLine());
                        if (numerDnia <= 0 || numerDnia > IloscDniWMiesiacu) Console.WriteLine("Blad wprowadzenia, sproboj jeszcze raz.");
                        else { this.niechcianeDni[i] = numerDnia; testpoprawnosci = true; }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Blad wprowadzenia, sproboj jeszcze raz.");
                    }
                } while (!testpoprawnosci);
            }
        } 
        public void TworzenieLekarza(List<Lekarz> ListaLekarzy, int IloscDni, int numerLekarza)
        {
            
            Console.WriteLine("Podaj imie nowego lekarza:");
            this.Imie = Console.ReadLine();
            Console.WriteLine("Podaj jego nazwisko:");
            this.Nazwisko = Console.ReadLine();
            this.numerLekarza = numerLekarza;
            WprowadzenieUlubionegoDnia();
            if (this.ulubionyDzien != "No")
            {
                Console.WriteLine("Podaj pore (D - dzien , N - noc):");
                this.ulubionyDzienPora = char.Parse(Console.ReadLine());
            }
            Console.WriteLine("Podaj ilosc dni w ktorych lekarz nie chce miec dyzurow:");
            this.iloscDniNiechcianych = int.Parse(Console.ReadLine());
            TworzenieNiechcianychDni(IloscDni);         

        }
        public void WypisanieStworzonegoLekarza(int numerLekarza, List<Lekarz> ListaLekarzy)
        {
            Console.Clear();
            Console.WriteLine("Stworzyles nowego lekarza!");
            Console.Write("Numer: ");
            ListaLekarzy[numerLekarza].Wypisanie(ListaLekarzy[numerLekarza].numerLekarza);
            Console.Write("Imie: ");
            ListaLekarzy[numerLekarza].Wypisanie(ListaLekarzy[numerLekarza].Imie);
            Console.Write("Nazwisko: ");
            ListaLekarzy[numerLekarza].Wypisanie(ListaLekarzy[numerLekarza].Nazwisko);
            if (ListaLekarzy[numerLekarza].ulubionyDzien != "No")
            {
                Console.Write("Preferowany dzien: ");
                ListaLekarzy[numerLekarza].Wypisanie(ListaLekarzy[numerLekarza].ulubionyDzien);
                if (ListaLekarzy[numerLekarza].ulubionyDzienPora == 'D') Console.WriteLine("Pora: Dzien");
                else Console.WriteLine("Pora: Noc");
            }
            Console.Write("Ilosc niechcianych dni: ");
            ListaLekarzy[numerLekarza].Wypisanie(ListaLekarzy[numerLekarza].iloscDniNiechcianych);
            if (ListaLekarzy[numerLekarza].iloscDniNiechcianych != 0)
            {
                ListaLekarzy[numerLekarza].WypisanieNiechcianychDni(numerLekarza);

            }
            Console.WriteLine("");
            Console.WriteLine("Aby przejsc do menu nacisnij dowolony przycisk.");
            Console.ReadKey();

        }
        private void WprowadzenieUlubionegoDnia()
        {
            Boolean blad = true;
            do
            {
                Console.WriteLine("Podaj dzien tygodnia w ktorym lekarz chcial by miec dyzury (Pn, Wt, Sr, Czw, Pt, So, Nd) lub 'No' jezeli lekarz nie ma ulubionego dnia:");
                string ulubionyDzien = Console.ReadLine();
                if (ulubionyDzien == "Pn" || 
                    ulubionyDzien == "Wt" || 
                    ulubionyDzien == "Sr" || 
                    ulubionyDzien == "Czw" || 
                    ulubionyDzien == "Pt" || 
                    ulubionyDzien == "So" || 
                    ulubionyDzien == "Nd" || 
                    ulubionyDzien == "No")
                { this.ulubionyDzien = ulubionyDzien; blad = false; }
                else Console.WriteLine("Blad wprowadzenia, sproboj ponownie.");
            } while (blad);

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
