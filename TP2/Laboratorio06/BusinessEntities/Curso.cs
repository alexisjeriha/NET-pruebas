using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private Materia materia;
        private Comision comision;
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }
        public Curso()
        {
            materia = new Materia();
            comision = new Comision();
        }

        public Comision Comision
        {
            get { return comision; }
            set { comision = value; }
        }
        public string DescComision
        {
            get { return comision.DescComision; }
        }
        public Materia Materia
        {
            get { return materia; }
            set { materia = value; }
        }
        public string DescMateria
        {
            get { return materia.Descripcion; }
        }
    }
}
