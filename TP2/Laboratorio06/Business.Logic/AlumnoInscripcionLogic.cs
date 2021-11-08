using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        private AlumnoInscripcionAdapter alumnoInscripcionData;

        public AlumnoInscripcionLogic()
        {
            alumnoInscripcionData = new AlumnoInscripcionAdapter();
        }

        public AlumnoInscripcionAdapter InscripcionData
        {
            get { return alumnoInscripcionData; }
            set { alumnoInscripcionData = value; }
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            return alumnoInscripcionData.GetOne(ID);
        }

        public bool ExisteInscripcion(int idAlu, int idCur)
        {
            return alumnoInscripcionData.ExisteInscripcion(idAlu, idCur);
        }

        public List<AlumnoInscripcion> GetAll(int IDAlumno)
        {
            return alumnoInscripcionData.GetAll(IDAlumno);
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return alumnoInscripcionData.GetAll();
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            alumnoInscripcionData.Save(inscripcion);
        }

        public void Delete(int ID)
        {
            alumnoInscripcionData.Delete(ID);
        }
    }
}

