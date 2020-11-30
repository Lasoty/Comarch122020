using System;

namespace ProgramowanieZaawansowane.Metody_rozszerzające
{
    public static class StringExtension
    {
        public static int ZwrocLiczbeLiter(this string str, char znak) 
            => Array.FindAll(str.ToCharArray(), c => c.Equals(znak)).Length;
    }
}
