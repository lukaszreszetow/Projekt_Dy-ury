using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dyżury
{
    class ZmianaDanych : Miesiac
    {
       int numerLekarzaDoZmiany;

        public ZmianaDanych(List<Lekarz> ListaLekarzy, int IloscDni)
        {
            KtoregoLekarzaDaneZmienic(ListaLekarzy);
            KtoreDaneZmienic(ListaLekarzy, IloscDni);
        }

        public void KtoregoLekarzaDaneZmienic(List<Lekarz> ListaLekarzy)
        {

            WypisaniePrzyZmianach(ListaLekarzy);
            Boolean poprawnoscNumeruLekarzaDoZmiany = false;
            while (!poprawnoscNumeruLekarzaDoZmiany)
            {
                numerLekarzaDoZmiany = (int.Parse(Console.ReadLine()) - 1);
                if ((numerLekarzaDoZmiany + 1) <= ListaLekarzy.Count && (numerLekarzaDoZmiany + 1) > 0) poprawnoscNumeruLekarzaDoZmiany = true;
                else {
                    Console.Clear();
                    Console.WriteLine("Podano bledny numer! Sproboj jeszcze raz.\n");
                    WypisaniePrzyZmianach(ListaLekarzy);
                }
            }
            Console.Clear();
        }
        private void WypisaniePrzyZmianach(List<Lekarz> ListaLekarzy)
        {
            Console.WriteLine("Podaj numer lekarza ktorego dane chcesz zmienic, ponizej lista stworzonych lekarzy:\n");
            int licznikWypisania = 0;
            foreach (var Lekarz in ListaLekarzy)
            {
                Console.WriteLine((licznikWypisania + 1) + ". " + ListaLekarzy[licznikWypisania].Imie + " " + ListaLekarzy[licznikWypisania].Nazwisko + " ma " + ListaLekarzy[licznikWypisania].iloscDyzurow + " dyzurow.");
                licznikWypisania++;
            }

        }

        public void KtoreDaneZmienic(List<Lekarz> ListaLekarzy, int IloscDni)
        {
            do
            {
                WyswietlenieOpcjiDoZmiany(ListaLekarzy);
                try
                {
                    switcher = KtoraOpcjeWybrano(ListaLekarzy, IloscDni);
                }
                catch (Exception e)
                {
                    Console.Clear();
                    switcher = blad;
                    Console.WriteLine("Blad wprowadzania. Sproboj ponownie.");
                }

            } while (switcher != 0);

        }
        private void WyswietlenieOpcjiDoZmiany(List<Lekarz> ListaLekarzy)
        {
            Console.WriteLine("Ktore dane lekarza " + (numerLekarzaDoZmiany + 1) + " chcesz zmienic?\n");
            Console.WriteLine("1) Imie.");
            Console.WriteLine("2) Nazwisko.");
            Console.WriteLine("3) Ulubiony dzien.");
            Console.WriteLine("4) Ulubiona pora.");
            Console.WriteLine("5) Ilosc niechcianych dni.");
            Console.WriteLine("6) Numery niechcianych dni.");
            Console.WriteLine("7) Wyswietl aktualne danego tego lekarza.");
            Console.WriteLine("0) Powrot.");

        }
        private int KtoraOpcjeWybrano(List<Lekarz> ListaLekarzy, int IloscDni)
        {
            switcher = int.Parse(Console.ReadLine());


            switch (switcher)
            {
                case 1:
                    Console.Clear();
                    ZmianaImienia(ListaLekarzy);
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    ZmianaNazwiska(ListaLekarzy);
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    ZmianaUlubionegoDnia(ListaLekarzy);
                    if (ListaLekarzy[numerLekarzaDoZmiany].ulubionyDzienPora == '\0' && ListaLekarzy[numerLekarzaDoZmiany].ulubionyDzien != "No") ZmianaUlubionejPory(ListaLekarzy);
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    if (ListaLekarzy[numerLekarzaDoZmiany].ulubionyDzien == "No")
                    {
                        Console.WriteLine("Nie mozna wybrac ulubionej pory gdy lekarz nie ma ulubionego dnia!");
                    }
                    else {
                        ZmianaUlubionejPory(ListaLekarzy);
                        Console.Clear();
                    }
                    break;
                case 5:
                    Console.Clear();
                    ZmianaIlosciNiecianychDni(ListaLekarzy);
                    Console.WriteLine("Ustaw nowe niechciane dni:");
                    ZmianaNumerowNiechcianychDni(ListaLekarzy, IloscDni);
                    Console.Clear();
                    break;
                case 6:
                    Console.Clear();
                    if (ListaLekarzy[numerLekarzaDoZmiany].iloscDniNiechcianych == 0) { Console.WriteLine("Dany lekarz ma 0 niechcianych dni."); }
                    else {
                        ZmianaNumerowNiechcianychDni(ListaLekarzy, IloscDni);
                        Console.Clear();
                    }
                    break;
                case 7:
                    Console.Clear();
                    AktualneDaneLekarza(numerLekarzaDoZmiany, ListaLekarzy);
                    Console.Clear();
                    break;
                case 0: break;
                default:
                    Console.Clear();
                    Console.WriteLine("Nie ma takiej wartosci, sproboj ponownie.");
                    break;

            }
            return switcher;
        }
        private void ZmianaNumerowNiechcianychDni(List<Lekarz> ListaLekarzy, int IloscDni)
        {
            ListaLekarzy[numerLekarzaDoZmiany].TworzenieNiechcianychDni(IloscDni);
        }

        private void ZmianaIlosciNiecianychDni(List<Lekarz> ListaLekarzy)
        {
            Console.WriteLine("Podaj nowa ilosc niechcianych dni:");
            ListaLekarzy[numerLekarzaDoZmiany].iloscDniNiechcianych = int.Parse(Console.ReadLine());
        }

        private void ZmianaUlubionejPory(List<Lekarz> ListaLekarzy)
        {
            Console.WriteLine("Podaj nowa ulubiona pore (D - Dzien, N - Noc):");
            ListaLekarzy[numerLekarzaDoZmiany].ulubionyDzienPora = char.Parse(Console.ReadLine());
        }

        private void ZmianaUlubionegoDnia(List<Lekarz> ListaLekarzy)
        {
            Console.WriteLine("Podaj nowy ulubiony dzien (Pn, Wt, Sr, Czw, Pt, So, Nd lub No(brak ulubionego dnia)):");
            string ulubionyDzien = Console.ReadLine();
            if (ulubionyDzien == "Pn" || ulubionyDzien == "Wt" || ulubionyDzien == "Sr" || ulubionyDzien == "Czw" || ulubionyDzien == "Pt" || ulubionyDzien == "So" || ulubionyDzien == "Nd" || ulubionyDzien == "No")
            { ListaLekarzy[numerLekarzaDoZmiany].ulubionyDzien = ulubionyDzien; }
            else { Console.WriteLine("Blad wprowadzania, sproboj ponownie."); ZmianaUlubionegoDnia(ListaLekarzy); }

        }

        private void ZmianaNazwiska(List<Lekarz> ListaLekarzy)
        {
            Console.WriteLine("Podaj nowe Nazwisko:");
            ListaLekarzy[numerLekarzaDoZmiany].Nazwisko = Console.ReadLine();
        }

        private void ZmianaImienia(List<Lekarz> ListaLekarzy)
        {
            Console.WriteLine("Podaj nowe Imie:");
            ListaLekarzy[numerLekarzaDoZmiany].Imie = Console.ReadLine();
        }
        private void AktualneDaneLekarza(int numerLekarzaZmienianego, List<Lekarz> ListaLekarzy)
        {
            Console.Write("Numer: ");
            ListaLekarzy[numerLekarzaZmienianego].Wypisanie(ListaLekarzy[numerLekarzaZmienianego].numerLekarza+1);
            Console.Write("Imie: ");
            ListaLekarzy[numerLekarzaZmienianego].Wypisanie(ListaLekarzy[numerLekarzaZmienianego].Imie);
            Console.Write("Nazwisko: ");
            ListaLekarzy[numerLekarzaZmienianego].Wypisanie(ListaLekarzy[numerLekarzaZmienianego].Nazwisko);
            if (ListaLekarzy[numerLekarzaZmienianego].ulubionyDzien != "No")
            {
                Console.Write("Preferowany dzien: ");
                ListaLekarzy[numerLekarzaZmienianego].Wypisanie(ListaLekarzy[numerLekarzaZmienianego].ulubionyDzien);
                if (ListaLekarzy[numerLekarzaZmienianego].ulubionyDzienPora == 'D') Console.WriteLine("Pora: Dzien");
                else Console.WriteLine("Pora: Noc");
            }
            Console.Write("Ilosc niechcianych dni: ");
            ListaLekarzy[numerLekarzaZmienianego].Wypisanie(ListaLekarzy[numerLekarzaZmienianego].iloscDniNiechcianych);
            if (ListaLekarzy[numerLekarzaZmienianego].iloscDniNiechcianych != 0)
            {
                ListaLekarzy[numerLekarzaZmienianego].WypisanieNiechcianychDni(numerLekarzaZmienianego);

            }
            Console.WriteLine("");
            Console.WriteLine("Aby przejsc do menu nacisnij dowolony przycisk.");
            Console.ReadKey();
        }
    }
}
