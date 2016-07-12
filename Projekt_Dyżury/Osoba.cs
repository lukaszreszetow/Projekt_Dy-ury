using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dyżury
{
    abstract class Osoba
    {
        public abstract string Imie { get; set; }
        public abstract string Nazwisko { get; set; }
        public int iloscDniNiechcianych { get; set; }
        public string ulubionyDzien { get; set; }
        public char ulubionyDzienPora { get; set; }
        public abstract void TworzenieNiechcianychDni(int IloscDniWMiesiacu);
        public abstract void WypisanieNiechcianychDni(int numer);
        public abstract Boolean SprawdzanieNiechianychDni(int numer);
    }
}
