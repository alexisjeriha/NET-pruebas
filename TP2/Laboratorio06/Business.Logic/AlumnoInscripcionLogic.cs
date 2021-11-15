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
            try
            {
                return alumnoInscripcionData.GetOne(ID);
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de la inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }

        }

        public bool ExisteInscripcion(int idAlu, int idCur)
        {
            try
            {
                return alumnoInscripcionData.ExisteInscripcion(idAlu, idCur);
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la Inscripcion", Ex);
                throw ExcepcionManejada;
            }
        }
        public List<AlumnoInscripcion> GetAll(int IDAlumno)
        {
            try
            {
                return alumnoInscripcionData.GetAll(IDAlumno);
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de las inscripciones del alumno", Ex);
                throw ExcepcionManejada;
            }
        }
        public List<AlumnoInscripcion> GetAll()
        {
            try
            {
                return alumnoInscripcionData.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de las inscripciones del alumno", Ex);
                throw ExcepcionManejada;
            }
        }
        public List<AlumnoInscripcion> GetRegulares()
        {
            try
            {
                return alumnoInscripcionData.GetRegulares();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de los alumnos regulares", Ex);
                throw ExcepcionManejada;
            }

        }
        public List<AlumnoInscripcion> GetAprobados()
        {
            try
            {
                return alumnoInscripcionData.GetAprobados();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de los alumnos aprobados", Ex);
                throw ExcepcionManejada;
            }
        }
        public List<AlumnoInscripcion> GetLibres()
        {
            try
            {
                return alumnoInscripcionData.GetLibres();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de los alumnos libres", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(AlumnoInscripcion inscripcion)
        {
            try
            {
                alumnoInscripcionData.Save(inscripcion);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al guardar la inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }

        }

        public void Delete(int ID)
        {
            try
            {
                alumnoInscripcionData.Delete(ID);
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
