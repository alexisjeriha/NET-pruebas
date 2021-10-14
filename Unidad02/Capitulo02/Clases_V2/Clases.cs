using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_V2
{
    public class A
    {
        public void F() { Console.WriteLine("A.F"); }
        public virtual void G() { Console.WriteLine("A.G"); }
    }

    public class B : A
    {
        new public void F() { Console.WriteLine("B.F"); }
        public override void G() { Console.WriteLine("B.G"); }
    }
}




