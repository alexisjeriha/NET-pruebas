using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private CursoAdapter cursoData;

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public CursoAdapter CursoData
        {
            get { return cursoData; }
            set { cursoData = value; }
        }

        public Curso GetOne(int ID)
        {
            try
            {
                return CursoData.GetOne(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }

        }

        public List<Curso> GetAll()
        {
            try
            {
                return CursoData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }

        }

        public bool ExisteCurso(int idMat, int idCom, int anio)
        {
            try
            {
                return CursoData.ExisteCurso(idMat, idCom, anio);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia del curso", Ex);
                throw ExcepcionManejada;
            }

        }

        public void Save(Curso curso)
        {
            try
            {
                CursoData.Save(curso);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al guardar", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                CursoData.Delete(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el Curso", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
