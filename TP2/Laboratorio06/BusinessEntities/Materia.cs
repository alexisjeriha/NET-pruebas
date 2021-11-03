using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {

        private Plan plan;

        public Materia()
        {
            plan = new Plan();
        }

        public string Descripcion { get; set; }
        public int HSSemanales { get; set; }
        public int HSTotales { get; set; }

        public Plan Plan
        {
            get { return plan; }
            set { plan = value; }
        }

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