using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private MateriaAdapter materiaData;

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public MateriaAdapter MateriaData
        {
            get { return materiaData; }
            set { materiaData = value; }
        }

        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }

        public bool Existe(int idPlan, string desc)
        {
            try
            {
                return MateriaData.ExisteMateria(idPlan, desc);
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la materia", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<Materia> GetAll()
        {
            try
            {
                return MateriaData.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Materia mat)
        {
            try
            {
                MateriaData.Save(mat);
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al guardar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                MateriaData.Delete(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la materia", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<Materia> GetMateriasParaInscripcion(int IDPlan, int IDAlumno)
        {
            try
            {
                return MateriaData.GetMateriasParaInscripcion(IDPlan, IDAlumno);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar las materias disponibles para el alumno.", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
