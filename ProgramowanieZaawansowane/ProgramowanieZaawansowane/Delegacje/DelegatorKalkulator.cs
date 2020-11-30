using System;

namespace ProgramowanieZaawansowane.Delegacje
{
    public delegate int Delegata1(int arg1, int arg2);

    class DelegatorKalkulator
    {
        public int Dodawanie(int x, int y)
        {
            return x + y;
        }

        public int Odejmowanie(int x, int y)
        {
            return x - y;
        }

        public void ZapiszDoLogu(Func<string> messageGenerator)
        {
            Console.WriteLine("Rozpoczęcie zapisu do logu.");
            Console.WriteLine(messageGenerator?.Invoke());
            Console.WriteLine("Koniec zapisu.");
        }
    }
}
