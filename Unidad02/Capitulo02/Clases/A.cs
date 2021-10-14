using System;
//using System.Console;

namespace Clases
{
    public class A
    {
        private string nombreInstancia;

        public string NombreInstancia
        {
            get { return nombreInstancia; }
            set { nombreInstancia = value; }
        }


        public A()
        {
            NombreInstancia = "Instancia sin nombre";
        }

        public A(string nombre)
        {
            NombreInstancia = nombre;
        }

        public void MostrarNombre()
        {
            Console.WriteLine(NombreInstancia);
        }

        public void M1()
        {
            Console.WriteLine("El método M1 fue invocado");
        }

        public void M2()
        {
            Console.WriteLine("El método M2 fue invocado");
        }

        public void M3()
        {
            Console.WriteLine("El método M3 fue invocado");
        }

    }
}

