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
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Legajo { get; set; }
        public string Tipo { get; set; }

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

        public string DescPlan
        {
            get { return Plan.Descripcion; }
        }
    }
}
