using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramowanieZaawansowane.Refleksja
{
    class Dog
    {
        public int NumberOfLegs { get; set; }

        public string Breed { get; set; }

        public Dog()
        {
            
        }

        public Dog(int number)
        {
            NumberOfLegs = number;
        }

        public void SetDogBread(string bread)
        {
            this.Breed = bread;
            Console.WriteLine($"Rasa psa: {bread}");
        }

        public void SetLegsNumber(int number)
        {
            this.NumberOfLegs = number;
        }

        public void Display()
        {
            Console.WriteLine($"Liczba nóg: {NumberOfLegs}");
            Console.WriteLine($"Rasa psa: {Breed}");
        }
    }
}
