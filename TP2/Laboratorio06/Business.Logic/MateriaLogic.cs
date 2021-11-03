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
            return MateriaData.ExisteMateria(idPlan, desc);
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public void Save(Materia mat)
        {
            MateriaData.Save(mat);
        }

        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }

        public List<Materia> GetMateriasParaInscripcion(int IDPlan, int IDAlumno)
        {
            return MateriaData.GetMateriasParaInscripcion(IDPlan, IDAlumno);
        }
    }
}