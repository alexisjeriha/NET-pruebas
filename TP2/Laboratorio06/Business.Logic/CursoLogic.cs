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
            return CursoData.GetOne(ID);
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public bool ExisteCurso(int idMat, int idCom, int anio)
        {
            return CursoData.ExisteCurso(idMat, idCom, anio);
        }

        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }

        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }
    }
}
