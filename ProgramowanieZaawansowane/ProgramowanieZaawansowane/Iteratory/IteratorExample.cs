using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProgramowanieZaawansowane.Iteratory
{
    class IteratorExample
    {
        public IEnumerable<int> PobierzDane()
        {
            Console.WriteLine($"Początek metody {nameof(PobierzDane)}.");

            IList<int> list = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Aktualna wartość: {0}.");
                yield return i;
            }

            Console.WriteLine($"Koniec metody {nameof(PobierzDane)}.");
        }
    }
}
