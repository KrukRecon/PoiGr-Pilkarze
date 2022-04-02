using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02_4
{
    class Piłkarz
    {
        private string nazwisko;
        public string Nazwisko {
            
            get => nazwisko;

            set 
            {
                nazwisko = value.Trim();
            } 
        
        }   
        public string Imię { get; set; }
        public int Waga { get; set; }
        public int Wzrost { get; set; }

        public Pozycja Pozycja { get; set; }

        public Piłkarz() { }

        public Piłkarz(string imie, string nazwisko, int wzrost, int waga, Pozycja pozycja)
        {
            Imię = imie;
            Nazwisko = nazwisko;
            Wzrost = wzrost;
            Waga = waga;
            Pozycja = pozycja;
        }

        public Piłkarz(Piłkarz p)
        {
            Imię=p.Imię;
            Nazwisko = p.Nazwisko;
            Waga = p.Waga;
            Wzrost = p.Wzrost;
            Pozycja = p.Pozycja;
        }

        public override string ToString()
        {
            return $"{Nazwisko} {Imię}, pozycja: {Pozycja}, waga: {Waga} [kg], wzrost: {Wzrost} [cm]";
        }
    }
    

}
