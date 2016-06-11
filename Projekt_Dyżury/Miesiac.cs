using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dyżury
{
    class Miesiac
    {
        public string DzienStartowy { get; set; }
        public string NazwaMiesiaca { get; set; }
        public int IloscDni { get; set; }
        enum DniTygodnia { Pn, Wt, Sr, Czw, Pt, Sob, Nd };
        private int numerLekarza = 0;
        public List<Dzien> AktualnyMiesiac = new List<Dzien>();
        public List<Lekarz> ListaLekarzy = new List<Lekarz>();
        int numerLekarzaDoZmiany;
        public int switcher { get; set; }


        private int SprawdzNumerDniaTygodnia(string dzien)
        {
            switch (dzien)
            {
                case "Pn": return (int)DniTygodnia.Pn; break;
                case "Wt": return (int)DniTygodnia.Wt; break;
                case "Sr": return (int)DniTygodnia.Sr; break;
                case "Czw": return (int)DniTygodnia.Czw; break;
                case "Pt": return (int)DniTygodnia.Pt; break;
                case "Sob": return (int)DniTygodnia.Sob; break;
                case "Nd": return (int)DniTygodnia.Nd; break;
                default: return (int)DniTygodnia.Pn; break;
            }
        }
        public void ZmianaDanych()
        {
            KtoregoLekarzaDaneZmienic();
            KtoreDaneZmienic();

        }

        public void KtoregoLekarzaDaneZmienic()
        {

            WypisaniePrzyZmianach();
            Boolean poprawnoscNumeruLekarzaDoZmiany = false;
            while (!poprawnoscNumeruLekarzaDoZmiany)
            {
                numerLekarzaDoZmiany = (int.Parse(Console.ReadLine()) - 1);
                if ((numerLekarzaDoZmiany + 1) <= ListaLekarzy.Count) poprawnoscNumeruLekarzaDoZmiany = true;
                else {
                    Console.Clear();
                    Console.WriteLine("Podano bledny numer! Sproboj jeszcze raz.\n");
                    WypisaniePrzyZmianach();
                }
            }
            Console.Clear();
        }

        private void WypisaniePrzyZmianach()
        {
            Console.WriteLine("Podaj numer lekarza ktorego dane chcesz zmienic, ponizej lista stworzonych lekarzy:\n");
            int licznikWypisania = 0;
            foreach (var Lekarz in ListaLekarzy)
            {
                Console.WriteLine((licznikWypisania + 1) + ". " + ListaLekarzy[licznikWypisania].Imie + " " + ListaLekarzy[licznikWypisania].Nazwisko + " ma " + ListaLekarzy[licznikWypisania].iloscDyzurow + " dyzurow.");
                licznikWypisania++;
            }

        }

        public void KtoreDaneZmienic()
        {


            do
            {
                WyswietlenieOpcjiDoZmiany();
                try
                {
                    switcher = KtoraOpcjeWybrano();
                }
                catch (Exception e)
                { }
                finally
                {
                    Console.Clear();
                }

            } while (switcher != 0);

        }

        private void WyswietlenieOpcjiDoZmiany()
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
        private int KtoraOpcjeWybrano()
        {
            switcher = int.Parse(Console.ReadLine());


            switch (switcher)
            {
                case 1:
                    Console.Clear();
                    ZmianaImienia();
                    break;
                case 2:
                    Console.Clear();
                    ZmianaNazwiska();
                    break;
                case 3:
                    Console.Clear();
                    ZmianaUlubionegoDnia();
                    break;
                case 4:
                    Console.Clear();
                    ZmianaUlubionejPory();
                    break;
                case 5:
                    Console.Clear();
                    ZmianaIlosciNiecianychDni();
                    Console.WriteLine("Ustaw nowe niechciane dni:\n");
                    ZmianaNumerowNiechcianychDni();
                    break;
                case 6:
                    Console.Clear();
                    ZmianaNumerowNiechcianychDni();
                    break;
                case 7:
                    Console.Clear();
                    AktualneDaneLekarza(numerLekarzaDoZmiany);
                    break;
                case 0: break;
                default:
                    Console.Clear();
                    break;

            }
            return switcher;
        }

        private void AktualneDaneLekarza(int numerLekarzaZmienianego)
        {
            Console.Write("Numer: ");
            ListaLekarzy[numerLekarzaZmienianego].Wypisanie(ListaLekarzy[numerLekarzaZmienianego].numerLekarza);
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


            Console.ReadKey();
        }

        private void ZmianaNumerowNiechcianychDni()
        {
            ListaLekarzy[numerLekarzaDoZmiany].TworzenieNiechcianychDni();
        }

        private void ZmianaIlosciNiecianychDni()
        {
            Console.WriteLine("Podaj nowa ilosc niechcianych dni:");
            ListaLekarzy[numerLekarzaDoZmiany].iloscDniNiechcianych = int.Parse(Console.ReadLine());
        }

        private void ZmianaUlubionejPory()
        {
            Console.WriteLine("Podaj nowa ulubiona pore (D - Dzien, N - Noc):");
            ListaLekarzy[numerLekarzaDoZmiany].ulubionyDzienPora = char.Parse(Console.ReadLine());
        }

        private void ZmianaUlubionegoDnia()
        {
            Console.WriteLine("Podaj nowy ulubiony dzien (Pn, Wt, Sr, Czw, Pt, So, Nd lub No(brak ulubionego dnia)):");
            ListaLekarzy[numerLekarzaDoZmiany].ulubionyDzien = Console.ReadLine();
        }

        private void ZmianaNazwiska()
        {
            Console.WriteLine("Podaj nowe Nazwisko:");
            ListaLekarzy[numerLekarzaDoZmiany].Nazwisko = Console.ReadLine();
        }

        private void ZmianaImienia()
        {
            Console.WriteLine("Podaj nowe Imie:");
            ListaLekarzy[numerLekarzaDoZmiany].Imie = Console.ReadLine();
        }

        public void PoczatekProgramu()
        {
            Console.WriteLine("Witaj w programie tworzacym plan dyzurow. Postepuj zgodnie z podanymi krokami aby stworzyc nowy plan. Powodzenia!");
            Console.WriteLine("Na poczatek podaj nazwe miesiaca w jezyku polskim. Wybierz z: Styczen, Luty, Marzec, Kwiecien, Maj, Czerwiec, Lipiec, Sierpien, Wrzesien, Pazdziernik, Listopad, Grudzien");
            this.NazwaMiesiaca = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Wspaniale! Teraz podaj ile dni znajduje sie w tym miesiacu!");
            this.IloscDni = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Wspaniale! Teraz podaj jakim dniem tygodnia rozpoczyna sie miesiac! Wybierz z: Pn, Wt, Sr, Czw, Pt, So, Nd. W razie błędu we wpisaniu zostanie przypisany Poniedziałek.");
            this.DzienStartowy = Console.ReadLine();
            Console.Clear();
            Console.Write("Wspaniale! Podstawowe dane zostaly zapisane! ");


        }
        public void NowyLekarz()
        {
            numerLekarza++;
            Lekarz tworzonyLekarz = new Lekarz();
            Console.WriteLine("Podaj imie nowego lekarza:");
            tworzonyLekarz.Imie = Console.ReadLine();
            Console.WriteLine("Podaj jego nazwisko:");
            tworzonyLekarz.Nazwisko = Console.ReadLine();
            tworzonyLekarz.numerLekarza = numerLekarza;
            Console.WriteLine("Podaj dzien tygodnia w ktorym lekarz chcial by miec dyzury (Pn, Wt, Sr, Czw, Pt, So, Nd) lub 'No' jezeli lekarz nie ma ulubionego dnia:");
            tworzonyLekarz.ulubionyDzien = Console.ReadLine();
            if (tworzonyLekarz.ulubionyDzien != "No")
            {
                Console.WriteLine("Podaj pore (D - dzien , N - noc):");
                tworzonyLekarz.ulubionyDzienPora = char.Parse(Console.ReadLine());
            }
            Console.WriteLine("Podaj ilosc dni w ktorych lekarz nie chce miec dyzurow:");
            tworzonyLekarz.iloscDniNiechcianych = int.Parse(Console.ReadLine());
            tworzonyLekarz.TworzenieNiechcianychDni();

            ListaLekarzy.Add(tworzonyLekarz);

            WypisanieStworzonegoLekarza(numerLekarza - 1);




        }
        private void WypisanieStworzonegoLekarza(int numerLekarza)
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


            Console.ReadKey();

        }

        private Boolean MozliwoscStworzenia()
        {
            int licznik = 0;
            if (ListaLekarzy.Count < 4) return false;
            foreach (var Lekarz in ListaLekarzy)
            {
                if (ListaLekarzy[licznik].iloscDniNiechcianych >= ((IloscDni * 2) / ListaLekarzy.Count) + 1) return false;

            }
            return true;
        }

        public void TworzenieDyzurow()
        {
            if (MozliwoscStworzenia())
            {
                string[] dni = { "Pn", "Wt", "Sr", "Czw", "Pt", "So", "Nd" };
                List<string> KolejneDniTygodnia = new List<string>(dni);

                int licznikDni = SprawdzNumerDniaTygodnia(DzienStartowy);

                for (int i = 0; i < IloscDni; i++)
                {
                    Dzien tworzonyDzien = new Dzien();
                    tworzonyDzien.NumerDnia = i + 1;
                    tworzonyDzien.NazwaDnia = dni[licznikDni++];
                    if (licznikDni == 7) licznikDni = 0;
                    AktualnyMiesiac.Add(tworzonyDzien);
                }
                PrzydzielanieChcianychDni();
                PrzydzielanieNieChcianychDni();

                Console.WriteLine("Dyzury zostaly przydzielone. Jeżeli chcesz przejsc dalej nacisnij dowolny klawisz.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Z obecnymi lekarzami nie da sie stworzyc listy dyzurow. Jest ich za malo lub posiadaja zbyt wiele niechcianych dni. Musisz dodac nowych lekarzy lub zaczac od poczatku.");
                Console.ReadKey();
            }





        }
        public void WypisanieIstniejacychLekarzy()
        {
            int licznikWypisania = 0;
            Console.WriteLine("Lista istniejacych lekarzy:\n");
            foreach (var Lekarz in ListaLekarzy)
            {
                Console.WriteLine((licznikWypisania + 1) + ". " + ListaLekarzy[licznikWypisania].Imie + " " + ListaLekarzy[licznikWypisania].Nazwisko + " ma " + ListaLekarzy[licznikWypisania].iloscDyzurow + " dyzurow.");
                licznikWypisania++;
            }
            Console.WriteLine("");
            Console.WriteLine("Aby przejsc do menu nacisnij dowolony przycisk.");
            Console.ReadKey();

        }
        private void PrzydzielanieChcianychDni()
        {
            for (int i = 0; i < IloscDni; i++)
            {
                List<int> numeryChcacychDzienLekarzy = new List<int>();
                List<int> numeryChcacychNocLekarzy = new List<int>();
                PrzygotowywanieTablicChcacychLekarzy(i, numeryChcacychDzienLekarzy, numeryChcacychNocLekarzy);

                if (numeryChcacychDzienLekarzy.Count == 1)
                {
                    JedenLekarzChcacyDzien(i, numeryChcacychDzienLekarzy);
                }
                else if (numeryChcacychDzienLekarzy.Count > 1)
                {
                    WieluLekarzyChcacychDzien(i, numeryChcacychDzienLekarzy);
                }


                if (numeryChcacychNocLekarzy.Count == 1)
                {
                    JedenLekarzChcacyNoc(i, numeryChcacychNocLekarzy);
                }
                else if (numeryChcacychNocLekarzy.Count > 1)
                {
                    WieluLekarzyChcacychNoc(i, numeryChcacychNocLekarzy);

                }

            }

        }

        private void WieluLekarzyChcacychNoc(int i, List<int> numeryChcacychNocLekarzy)
        {
            int lekarzZNajmniejszaIlosciaDyzurow = numeryChcacychNocLekarzy[0];
            for (int j = 0; j < numeryChcacychNocLekarzy.Count; j++)
            {
                if (ListaLekarzy[lekarzZNajmniejszaIlosciaDyzurow - 1].iloscDyzurow > ListaLekarzy[numeryChcacychNocLekarzy[j] - 1].iloscDyzurow) lekarzZNajmniejszaIlosciaDyzurow = numeryChcacychNocLekarzy[j];
            }
            if (sprawdzZgodnosc(lekarzZNajmniejszaIlosciaDyzurow, (i + 1)))
            {
                AktualnyMiesiac[i].NumerLekarzaNoc = lekarzZNajmniejszaIlosciaDyzurow;
                ListaLekarzy[lekarzZNajmniejszaIlosciaDyzurow - 1].iloscDyzurow++;
            }
        }

        private void JedenLekarzChcacyNoc(int i, List<int> numeryChcacychNocLekarzy)
        {
            if (sprawdzZgodnosc(numeryChcacychNocLekarzy[0], (i + 1)))
            {
                AktualnyMiesiac[i].NumerLekarzaNoc = ListaLekarzy[numeryChcacychNocLekarzy[0] - 1].numerLekarza;
                ListaLekarzy[numeryChcacychNocLekarzy[0] - 1].iloscDyzurow++;
            }
        }

        private void WieluLekarzyChcacychDzien(int i, List<int> numeryChcacychDzienLekarzy)
        {
            int lekarzZNajmniejszaIlosciaDyzurow = numeryChcacychDzienLekarzy[0];
            for (int j = 0; j < numeryChcacychDzienLekarzy.Count; j++)
            {
                if (ListaLekarzy[lekarzZNajmniejszaIlosciaDyzurow - 1].iloscDyzurow > ListaLekarzy[numeryChcacychDzienLekarzy[j] - 1].iloscDyzurow) lekarzZNajmniejszaIlosciaDyzurow = numeryChcacychDzienLekarzy[j];
            }
            if (sprawdzZgodnosc(lekarzZNajmniejszaIlosciaDyzurow, (i + 1)))
            {
                AktualnyMiesiac[i].NumerLekarzaDzien = lekarzZNajmniejszaIlosciaDyzurow;
                ListaLekarzy[lekarzZNajmniejszaIlosciaDyzurow - 1].iloscDyzurow++;
            }
        }

        private void JedenLekarzChcacyDzien(int i, List<int> numeryChcacychDzienLekarzy)
        {
            if (sprawdzZgodnosc(numeryChcacychDzienLekarzy[0], (i + 1)))
            {
                AktualnyMiesiac[i].NumerLekarzaDzien = ListaLekarzy[numeryChcacychDzienLekarzy[0] - 1].numerLekarza;
                ListaLekarzy[numeryChcacychDzienLekarzy[0] - 1].iloscDyzurow++;
            }
        }

        private void PrzygotowywanieTablicChcacychLekarzy(int i, List<int> numeryChcacychDzienLekarzy, List<int> numeryChcacychNocLekarzy)
        {
            for (int j = 0; j < ListaLekarzy.Count; j++)
            {
                if (ListaLekarzy[j].ulubionyDzien == AktualnyMiesiac[i].NazwaDnia && ListaLekarzy[j].ulubionyDzienPora == 'D') numeryChcacychDzienLekarzy.Add(ListaLekarzy[j].numerLekarza);
                if (ListaLekarzy[j].ulubionyDzien == AktualnyMiesiac[i].NazwaDnia && ListaLekarzy[j].ulubionyDzienPora == 'N') numeryChcacychNocLekarzy.Add(ListaLekarzy[j].numerLekarza);
            }
        }

        private Boolean sprawdzZgodnosc(int numerLekarza, int numerDnia)
        {
            Boolean test = ListaLekarzy[numerLekarza - 1].SprawdzanieNiechianychDni(numerDnia);
            return test;

        }

        private void PrzydzielanieNieChcianychDni()
        {
            for (int i = 0; i < IloscDni; i++)
            {

                if (AktualnyMiesiac[i].NumerLekarzaDzien == 0)
                {
                    List<int> Kandydaci = new List<int>();
                    ListaKandydatowZNajmniejszaLiczbaDyzurowDzien(i, Kandydaci);
                    WybranieLosowegoKandydataZNajmniejszaLiczbaDyzurowDzien(i, Kandydaci);

                }
                if (AktualnyMiesiac[i].NumerLekarzaNoc == 0)
                {
                    List<int> Kandydaci = new List<int>();
                    ListaKandydatowZNajmniejszaLiczbaDyzurowNoc(i, Kandydaci);
                    WybranieLosowegoKandydataZNajmniejszaLiczbaDyzurowNoc(i, Kandydaci);

                }

            }

        }

        private void WybranieLosowegoKandydataZNajmniejszaLiczbaDyzurowNoc(int i, List<int> Kandydaci)
        {
            Boolean czyJuzWylosowano = false;

            while (!czyJuzWylosowano)
            {
                int wylosowanaLiczba = 0;
                Random losowanie = new Random();
                if (Kandydaci.Count == 1)
                {
                }
                else { wylosowanaLiczba = losowanie.Next(0, Kandydaci.Count); }
                if (i != 0)
                {
                    if (AktualnyMiesiac[i - 1].NumerLekarzaNoc != Kandydaci[wylosowanaLiczba] && AktualnyMiesiac[i].NumerLekarzaDzien != Kandydaci[wylosowanaLiczba]) { AktualnyMiesiac[i].NumerLekarzaNoc = Kandydaci[wylosowanaLiczba]; ListaLekarzy[Kandydaci[wylosowanaLiczba] - 1].iloscDyzurow++; czyJuzWylosowano = true; }
                }
                else if (AktualnyMiesiac[i].NumerLekarzaDzien != Kandydaci[wylosowanaLiczba]) { AktualnyMiesiac[i].NumerLekarzaNoc = Kandydaci[wylosowanaLiczba]; ListaLekarzy[Kandydaci[wylosowanaLiczba] - 1].iloscDyzurow++; czyJuzWylosowano = true; }

            }
        }

        private void ListaKandydatowZNajmniejszaLiczbaDyzurowNoc(int i, List<int> Kandydaci)
        {
            Boolean czyJuzZnaleziono = false;
            int licznikDyzurow = 0;
            while (!czyJuzZnaleziono)
            {

                int licznik = 0;
                foreach (var Lekarz in ListaLekarzy)
                {

                    if (ListaLekarzy[licznik].iloscDyzurow == licznikDyzurow && sprawdzZgodnosc(licznik + 1, i + 1)) Kandydaci.Add(licznik + 1);
                    licznik++;
                }
                if (Kandydaci.Count != 0) czyJuzZnaleziono = true;
                else licznikDyzurow++;
            }
        }

        private void WybranieLosowegoKandydataZNajmniejszaLiczbaDyzurowDzien(int i, List<int> Kandydaci)
        {
            Boolean czyJuzWylosowano = false;

            while (!czyJuzWylosowano)
            {
                int wylosowanaLiczba = 0;
                Random losowanie = new Random();
                if (Kandydaci.Count == 1)
                {
                }
                else { wylosowanaLiczba = losowanie.Next(0, Kandydaci.Count); }
                if (i != 0)
                {
                    if (AktualnyMiesiac[i - 1].NumerLekarzaNoc != Kandydaci[wylosowanaLiczba] && AktualnyMiesiac[i - 1].NumerLekarzaDzien != Kandydaci[wylosowanaLiczba]) { AktualnyMiesiac[i].NumerLekarzaDzien = Kandydaci[wylosowanaLiczba]; ListaLekarzy[Kandydaci[wylosowanaLiczba] - 1].iloscDyzurow++; czyJuzWylosowano = true; }
                }
                else { AktualnyMiesiac[i].NumerLekarzaDzien = Kandydaci[wylosowanaLiczba]; ListaLekarzy[Kandydaci[wylosowanaLiczba] - 1].iloscDyzurow++; czyJuzWylosowano = true; }


            }
        }

        private void ListaKandydatowZNajmniejszaLiczbaDyzurowDzien(int i, List<int> Kandydaci)
        {
            Boolean czyJuzZnaleziono = false;
            int licznikDyzurow = 0;
            while (!czyJuzZnaleziono)
            {
                int licznik = 0;
                foreach (var Lekarz in ListaLekarzy)
                {
                    if (ListaLekarzy[licznik].iloscDyzurow == licznikDyzurow && sprawdzZgodnosc(licznik + 1, i + 1)) Kandydaci.Add(licznik + 1);
                    licznik++;
                }
                if (Kandydaci.Count != 0) czyJuzZnaleziono = true;
                else licznikDyzurow++;
            }
        }

        public void WypisanieIstniejacegoMiesiaca()
        {
            int licznikWypisania = 0;
            Console.WriteLine("Lista dyzurujacych lekarzy w kolejnych dniach:\n");

            foreach (var Dzien in AktualnyMiesiac)
            {
                Console.WriteLine(AktualnyMiesiac[licznikWypisania].NumerDnia + ") " + AktualnyMiesiac[licznikWypisania].NazwaDnia + ", Dzien-> " + ListaLekarzy[AktualnyMiesiac[licznikWypisania].NumerLekarzaDzien - 1].Imie + " " + ListaLekarzy[AktualnyMiesiac[licznikWypisania].NumerLekarzaDzien - 1].Nazwisko + " | Noc-> " + ListaLekarzy[AktualnyMiesiac[licznikWypisania].NumerLekarzaNoc - 1].Imie + " " + ListaLekarzy[AktualnyMiesiac[licznikWypisania].NumerLekarzaNoc - 1].Nazwisko);
                licznikWypisania++;
            }

            Console.WriteLine("");
            licznikWypisania = 0;
            foreach (var Lekarz in ListaLekarzy)
            {
                Console.WriteLine(ListaLekarzy[licznikWypisania].Imie + " " + ListaLekarzy[licznikWypisania].Nazwisko + " ma " + ListaLekarzy[licznikWypisania].iloscDyzurow + " dyzurow.");
                licznikWypisania++;

            }
            Console.WriteLine("");
            Console.WriteLine("Aby przejsc do menu nacisnij dowolony przycisk.");
            Console.ReadKey();
        }
        public void ZapisDoNotatnika()
        {
            int licznikWypisania = 0;
            Console.WriteLine(@"Podaj miejsce docelowe w ktorym chcesz zapisac liste dyzurow. (UWAGA! Podaj DOKŁADNĄ lokalizację np: C:\Users\Łukasz\Dyzury.txt)");
            string nazwa = Console.ReadLine();

            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(nazwa, true))
            {
                file.WriteLine("Stworzona lista dyzurow na miesiac " + NazwaMiesiaca + " to:");
                foreach (var Dzien in AktualnyMiesiac)
                {
                    file.WriteLine(AktualnyMiesiac[licznikWypisania].NumerDnia + ") " + AktualnyMiesiac[licznikWypisania].NazwaDnia + ", Dzien-> " + ListaLekarzy[AktualnyMiesiac[licznikWypisania].NumerLekarzaDzien - 1].Imie + " " + ListaLekarzy[AktualnyMiesiac[licznikWypisania].NumerLekarzaDzien - 1].Nazwisko + " | Noc-> " + ListaLekarzy[AktualnyMiesiac[licznikWypisania].NumerLekarzaNoc - 1].Imie + " " + ListaLekarzy[AktualnyMiesiac[licznikWypisania].NumerLekarzaNoc - 1].Nazwisko);
                    licznikWypisania++;
                }
            }
            Console.WriteLine("Liste dyzurow zapisano w lokalizacji: " + nazwa);
            Console.WriteLine("Aby przejsc do menu nacisnij dowolony przycisk.");
            Console.ReadKey();
        }


    }

}
