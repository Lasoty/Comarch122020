using System;
using System.Collections.Generic;
using ProgramowanieZaawansowane.Delegacje;
using ProgramowanieZaawansowane.Generycznosc;
using ProgramowanieZaawansowane.Iteratory;
using ProgramowanieZaawansowane.KlasyCzesciowe;
using ProgramowanieZaawansowane.KowariancjaIKontrwariancja;
using ProgramowanieZaawansowane.Metody_rozszerzające;

namespace ProgramowanieZaawansowane
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Generycznosc();
            //Iteratory();
            //Delegacje();
            MetodyRozszerzajace();
            KlasaCzesciowa();
            KowariancjaIKontrwariancja();
            Console.ReadLine();
        }

        private static void KowariancjaIKontrwariancja()
        {
            IEnumerable<Auto> Metoda()
            {
                return new List<Auto>();
            }

            IEnumerable<Pojazd> listaPojazd1 = Metoda();
            IEnumerable<Auto> listaAuto1 = Metoda();
            //IEnumerable<Audi> listaPojazd2 = Metoda();

            IJakisInterfejs<Auto> Metoda2()
            {
                return null;
            }

            IJakisInterfejs<Auto> listaAuto2 = Metoda2();
            IJakisInterfejs<Audi> listaAudi2 = Metoda2();


        }

        private static void KlasaCzesciowa()
        {
            Samochod samochod = new Samochod();
            samochod.LiczbaDrzwi = 5;
            samochod.Uruchom();
        }

        private static void MetodyRozszerzajace()
        {
            Console.WriteLine("Metody Rozszerzajace");
            string napis = "hahaha";

            int liczbaLiter = napis.ZwrocLiczbeLiter('a');
            Console.WriteLine($"Liczba szukanych liter to: {liczbaLiter}.");

            Console.WriteLine("-------------------------------------------");
        }

        private static void Delegacje()
        {
            Console.WriteLine("Delegacje");

            DelegatorKalkulator delegatorKalkulator = new DelegatorKalkulator();
            Delegata1 dodawanieDelegata = new Delegata1(delegatorKalkulator.Dodawanie);

            int wynikDodawania = dodawanieDelegata.Invoke(2, 3);
            Console.WriteLine($"Wynik dodawania: {wynikDodawania}");

            Delegata1 odejmowanieDelegata = delegatorKalkulator.Odejmowanie;
            Console.WriteLine($"Wynik odejmowania to: {odejmowanieDelegata(4,2)}");

            //Func<string> logger = null; //Delegat moze być nullem

            delegatorKalkulator.ZapiszDoLogu(GenerujLog);

            Console.WriteLine("-------------------------------------------");
        }

        private static string GenerujLog()
        {
            return "Jest to zawartość logu";
        }

        private static void Iteratory()
        {
            Console.WriteLine("ITERATORY");

            IteratorExample iteratorExample = new IteratorExample();
            IEnumerable<int> data = iteratorExample.PobierzDane();

            Console.WriteLine("Rozpoczęcie pętli");

            foreach (int item in data)
            {
                Console.WriteLine($"Odczyt wartości w pętli: {item}");
                if (item > 6)
                    break;
            }

            Console.WriteLine("-------------------------------------------");
        }

        private static void Generycznosc()
        {
            Console.WriteLine("GENERYCZNOŚĆ");

            IGenericInterface<string> genericTest = new GenericClass<string>();
            string val = genericTest.PublicMethod(456);
            Console.WriteLine($"Wynik to {val}.");

            List<string> listaS = new List<string>();

            Console.WriteLine("-------------------------------------------");
        }
    }
}
