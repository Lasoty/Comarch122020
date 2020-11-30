using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramowanieZaawansowane.KlasyCzesciowe
{
    public partial class Samochod
    {
        partial void Zatankuj(float iloscPaliwa)
        {
            Console.WriteLine($"Zatankowano {iloscPaliwa}.");
        }

        public void Uruchom()
        {
            Console.WriteLine("Samochod działa");
        }
    }
}
