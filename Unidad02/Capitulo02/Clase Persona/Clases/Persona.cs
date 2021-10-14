using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    
    public class Persona
    {
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Edad { get; set; }
        public String DNI { get; set; }



        public Persona(String nombre, String apellido, int edad, String dni)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            DNI = dni;
            Console.WriteLine("Se ha instanciado correctamente la persona");
               
        }

        ~Persona()
        {
            Console.WriteLine("La persona ha sido destruída existosamente");
        }

        public String GetFullName()
        {
            String nombreCompleto = Nombre + " " + Apellido;
            return nombreCompleto;
            
        }

        public int GetAge()
        {
            return Edad;
        }
    }
}
