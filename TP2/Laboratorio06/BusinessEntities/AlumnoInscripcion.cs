using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities 
{
    public class AlumnoInscripcion : BusinessEntity
    {

        private Persona alumno;
        private Curso curso;

        public AlumnoInscripcion()
        {
            alumno = new Persona();
            curso = new Curso();
        }

        public String Condicion { get; set; }

        public Persona Alumno { get; set; }

        public Curso Curso 
        { 
            get { return curso; }
            set { curso = value; }
        }

        public int Nota { get; set; }

        public string DescComision
        {
            get { return Curso.Comision.DescComision; }
        }

        public string DescMateria
        {
            get { return Curso.DescMateria; }
        }

        public int AnioCurso
        {
            get { return Curso.AnioCalendario; }
        }

        public string Apellido
        {
            get { return Alumno.Apellido; }
        }

        public string Nombre
        {
            get { return Alumno.Nombre; }
        }
    }
}

