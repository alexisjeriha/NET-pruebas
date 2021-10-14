using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_V2;

namespace LabClases02
{
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            A a = b;
            a.F();
            b.F();
            a.G();
            b.G();
            Console.ReadKey();
        }
    }
}
