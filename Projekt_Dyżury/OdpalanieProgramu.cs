using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dyżury
{
    public class OdpalanieProgramu : Miesiac
    {
        enum IloscDniWMiesiacach {
            Styczen = 31,
            Luty = 28,
            Marzec = 31,
            Kwiecien = 30,
            Maj = 31,
            Czerwiec = 30,
            Lipiec = 31,
            Sierpien = 31,
            Wrzesien = 30,
            Pazdziernik = 31,
            Listopad = 30,
            Grudzien = 31
        };

        public string PodanieDniaPoczatkowego()
        {
            Console.WriteLine("Podaj jakim dniem tygodnia rozpoczyna sie miesiac! Wybierz z: Pn, Wt, Sr, Czw, Pt, So, Nd.");
            string dzienTygodnia = Console.ReadLine();
            switch (dzienTygodnia)
            {
                case "Pn": return dzienTygodnia; 
                case "Wt": return dzienTygodnia; 
                case "Sr": return dzienTygodnia;
                case "Czw": return dzienTygodnia;
                case "Pt": return dzienTygodnia; 
                case "Sob": return dzienTygodnia;
                case "Nd": return dzienTygodnia; 
                default: { Console.Clear(); Console.WriteLine("Blad we wprowadzaniu, odpowiedz jeszcze raz."); return PodanieDniaPoczatkowego(); }; 
            }

           
        }
        public string PodanieMiesiaca()
        {
            Console.WriteLine("Na poczatek podaj nazwe miesiaca w jezyku polskim. Wybierz z: Styczen, Luty, Marzec, Kwiecien, Maj, Czerwiec, Lipiec, Sierpien, Wrzesien, Pazdziernik, Listopad, Grudzien");
            string miesiac = Console.ReadLine();
            if (miesiac == "Styczen" ||
                miesiac == "Luty" ||
                miesiac == "Marzec" ||
                miesiac == "Kwiecien" ||
                miesiac == "Maj" ||
                miesiac == "Czerwiec" ||
                miesiac == "Lipiec" ||
                miesiac == "Sierpien" ||
                miesiac == "Wrzesien" ||
                miesiac == "Pazdziernik" ||
                miesiac == "Listopad" ||
                miesiac == "Grudzien") return miesiac;
            else { Console.WriteLine("Blad we wprowadzaniu, sproboj ponownie"); return PodanieMiesiaca(); }
            
        }
        public int UstawianieIlosciDniWMiesiacu(string NazwaMiesiaca)
        {
            switch (NazwaMiesiaca)
            {
                case "Styczen": return (int)IloscDniWMiesiacach.Styczen; 
                case "Luty": return RokPrzestepny(); 
                case "Marzec": return (int)IloscDniWMiesiacach.Marzec;
                case "Kwiecien": return (int)IloscDniWMiesiacach.Kwiecien;
                case "Maj": return (int)IloscDniWMiesiacach.Maj; 
                case "Czerwiec": return (int)IloscDniWMiesiacach.Czerwiec;
                case "Lipiec": return (int)IloscDniWMiesiacach.Lipiec; 
                case "Sierpien": return (int)IloscDniWMiesiacach.Sierpien; 
                case "Wrzesien": return (int)IloscDniWMiesiacach.Wrzesien; 
                case "Pazdziernik": return (int)IloscDniWMiesiacach.Pazdziernik;
                case "Listopad": return (int)IloscDniWMiesiacach.Listopad; 
                case "Grudzien": return (int)IloscDniWMiesiacach.Grudzien; 
               }
            return 0;
        }
        private int RokPrzestepny()
        {
            Console.WriteLine("Czy jest to rok przestepny? Tak / Nie");
            string przestepny;
            przestepny = Console.ReadLine();
            switch (przestepny)
            {
                case "Tak": return (int)IloscDniWMiesiacach.Luty + 1;
                case "Nie": return (int)IloscDniWMiesiacach.Luty;
                default: { Console.Clear(); Console.WriteLine("Blad we wprowadzaniu, odpowiedz jeszcze raz."); return RokPrzestepny(); } 
            }
        }

    }
}