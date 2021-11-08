using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private Plan plan;
        public Comision()
        {
            Plan = new Plan();
        }
        //public int ID { get; set; }
        public string DescComision { get; set; }
        public int AnioEspecialidad { get; set; }
        public Plan Plan
        {
            get { return plan; }
            set { plan = value; }
        }
        public int IdPlan
        {
            get { return Plan.ID; }
        }

        //Duda si lo siguiente es necesario
        public string DescPlan
        {
            get { return Plan.Descripcion; }
        }

        public string DescEspecialidad
        {
            get { return Plan.Especialidad.Descripcion; }
        }
    }
}
