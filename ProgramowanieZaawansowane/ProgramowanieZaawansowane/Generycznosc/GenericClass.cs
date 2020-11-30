using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProgramowanieZaawansowane.Generycznosc
{
    public class GenericClass<T> : IGenericInterface<T> where T : class 
    {
        public T Name { get; set; }

        public string PublicMethod<Titem>(Titem item)
        {
            return item.ToString();
        }
    }

    public interface IGenericInterface<T>
    {
        string PublicMethod<Titem>(Titem item);
    }
}
