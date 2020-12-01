using System;

namespace ProgramowanieZaawansowane.Refleksja
{
    internal class ExampleAttribute : Attribute
    {
        public readonly string message;

        public ExampleAttribute(string message)
        {
            this.message = message;
        }

        public string Topic { get; set; }
    }
}