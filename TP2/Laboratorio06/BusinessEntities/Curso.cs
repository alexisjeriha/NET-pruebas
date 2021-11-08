using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private string descripcion;
        private Materia materia;
        private Comision comision;        
        public Curso()
        {
            materia = new Materia();
            comision = new Comision();
        }
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public Comision Comision
        {
            get { return comision; }
            set { comision = value; }
        }

        public Materia Materia
        {
            get { return materia; }
            set { materia = value; }
        }       
        public string DescComision
        {
            get { return comision.DescComision; }
        }
        public string DescMateria
        {
            get { return Materia.Descripcion; }
        }
    }
}
