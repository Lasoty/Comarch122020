using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramowanieZaawansowane.KlasyCzesciowe
{
    partial class Samochod
    {
        public int LiczbaDrzwi { get; set; }

        public float Pojemnosc { get; set; }

        partial void Zatankuj(float iloscPaliwa);
    }
}
