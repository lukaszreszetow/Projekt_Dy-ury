using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dyżury
{
    public class Miesiac
    {
        public string DzienStartowy { get; set; }
        public string NazwaMiesiaca { get; set; }
        public int IloscDni { get; set; }
        enum DniTygodnia { Pn, Wt, Sr, Czw, Pt, Sob, Nd };
        private int numerLekarza = 0;
        public int blad = 8;
        List<Dzien> AktualnyMiesiac = new List<Dzien>();
        List<Lekarz> ListaLekarzy = new List<Lekarz>();
        public int switcher { get; set; }
               

        public void PoczatekProgramu()
        {
            OdpalanieProgramu odpalanie = new OdpalanieProgramu();
            Console.WriteLine("Witaj w programie tworzacym plan dyzurow. Postepuj zgodnie z podanymi krokami aby stworzyc nowy plan. Powodzenia!");
            NazwaMiesiaca = odpalanie.PodanieMiesiaca();
            IloscDni = odpalanie.UstawianieIlosciDniWMiesiacu(NazwaMiesiaca);
            Console.Clear();
            DzienStartowy = odpalanie.PodanieDniaPoczatkowego();
            Console.Clear();
            Console.Write("Wspaniale! Podstawowe dane zostaly zapisane!");

        }

        public void ZmianaDanych()
        {
            ZmianaDanych zmiana = new ZmianaDanych(ListaLekarzy, IloscDni);
        }
        #region AkcjeNaLekarzach
        public void NowyLekarz()
        {
            numerLekarza++;
            Lekarz tworzenieLekarza = new Lekarz();
            tworzenieLekarza.TworzenieLekarza(ListaLekarzy, IloscDni, numerLekarza);
            ListaLekarzy.Add(tworzenieLekarza);
            tworzenieLekarza.WypisanieStworzonegoLekarza(numerLekarza - 1, ListaLekarzy);            
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
        #endregion
        #region TworzeniePlanu
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

        private int SprawdzNumerDniaTygodnia(string dzien)
        {
            switch (dzien)
            {
                case "Pn": return (int)DniTygodnia.Pn;
                case "Wt": return (int)DniTygodnia.Wt;
                case "Sr": return (int)DniTygodnia.Sr;
                case "Czw": return (int)DniTygodnia.Czw;
                case "Pt": return (int)DniTygodnia.Pt;
                case "Sob": return (int)DniTygodnia.Sob;
                case "Nd": return (int)DniTygodnia.Nd;
            }
            return 0;
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
        #endregion

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
