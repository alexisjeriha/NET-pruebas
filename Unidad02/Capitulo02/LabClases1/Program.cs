using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace LabClases1
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A("UwU");
            B b = new B();
            a.MostrarNombre();
            b.M3();
            b.M4();
            Console.WriteLine("Hola");
        }
    }
}
