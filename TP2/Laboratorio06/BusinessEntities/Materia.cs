using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string descripcion;
        private Plan plan;

        public Materia()
        {
            plan = new Plan();
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int HSSemanales { get; set; }
        public int HSTotales { get; set; }

        public Plan Plan
        {
            get { return plan; }
            set { plan = value; }
        }

        public int IDPlan
        {
            get { return Plan.ID; }
        }

        public string DescPlan
        {
            get { return Plan.Descripcion; }
        }
    }
}