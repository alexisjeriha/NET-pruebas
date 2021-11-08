using System;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private Plan plan;
        public Persona()
        {
            Plan = new Plan();
        }

        // Datos particulares de la persona
        public int IdPersona { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Email { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Legajo { get; set; }
        public String Tipo { get; set; }

        //Plan asociado a la persona
        public Plan Plan
        {
            get { return plan; }
            set { plan = value; }
        }

        public int IDPlan
        {
            get { return Plan.Id; }
        }
    }
}
