using System;
using System.Collections.Generic;
using System.Reflection;
using ProgramowanieZaawansowane.Delegacje;
using ProgramowanieZaawansowane.Generycznosc;
using ProgramowanieZaawansowane.Iteratory;
using ProgramowanieZaawansowane.KlasyCzesciowe;
using ProgramowanieZaawansowane.KowariancjaIKontrwariancja;
using ProgramowanieZaawansowane.Metody_rozszerzające;
using ProgramowanieZaawansowane.Refleksja;

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
            //MetodyRozszerzajace();
            //KlasaCzesciowa();
            //KowariancjaIKontrwariancja();
            //Refleksja1();
            Refleksja2();
            Console.ReadLine();
        }

        private static void Refleksja2()
        {
            var dog = Activator.CreateInstance(typeof(Dog)) as Dog;

            PropertyInfo[] properties = dog.GetType().GetProperties();
            PropertyInfo prop1 = properties[0];
            PropertyInfo prop2 = properties[1];

            prop1.SetValue(dog, 4);
            prop2.SetValue(dog, "wilczur");

            Console.WriteLine(dog.NumberOfLegs);
            Console.WriteLine(prop1.GetValue(dog, null));

            Console.WriteLine(dog.Breed);
            Console.WriteLine(prop2.GetValue(dog, null));

            //---

            ConstructorInfo defConstrTest = typeof(Dog).GetConstructor(new Type[0]);
            ConstructorInfo paramConstrTest = typeof(Dog).GetConstructor(new[] { typeof(int) });

            var objFromDefConstr = (Dog)defConstrTest.Invoke(null);
            var objFromParamConstr = (Dog)paramConstrTest.Invoke(new object[]{45});

            Console.WriteLine($"Pierwszy konstruktor, liczba nóg: {objFromDefConstr.NumberOfLegs}");
            Console.WriteLine($"Drui konstruktor, liczba nóg: {objFromParamConstr.NumberOfLegs}");

        }

        private static void Refleksja1()
        {
            Console.WriteLine("REFLEKSJA 1");
            MemberInfo info = typeof(MyClassToGetAttributeInfo);
            var attributes = info.GetCustomAttributes(true);

            for (int i = 0; i < attributes.Length; i++)
            {
                Console.WriteLine(attributes[i]);
                ExampleAttribute ea = (ExampleAttribute)attributes[i];
                Console.WriteLine($"info: {ea.message}");
            }


            Console.WriteLine("-------------------------------------------");
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
            Console.WriteLine($"Wynik odejmowania to: {odejmowanieDelegata(4, 2)}");

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
