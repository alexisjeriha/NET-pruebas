using Business.Entities;
using Data.Database;
using System.Collections.Generic;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private ComisionAdapter comisionData;

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public ComisionAdapter ComisionData
        {
            get { return comisionData; }
            set { comisionData = value; }
        }

        public Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
        }

        public bool Existe(int idPlan, string desc, int anio)
        {
            return ComisionData.ExisteComision(idPlan, desc, anio);
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public void Save(Comision com)
        {
            ComisionData.Save(com);
        }

        public void Delete(int ID)
        {
            ComisionData.Delete(ID);
        }

        public List<Comision> GetComisionesParaInscripcion(int IDPlan, int IDAlumno)
        {
            return ComisionData.GetComisionesParaInscripcion(IDPlan, IDAlumno);
        }

        // Devuelve las comisiones con cupo para la materia indicada
        public List<Comision> GetComisionesDisponibles(int IDMateria)
        {
            List<Comision> comisiones = new List<Comision>();
            CursoLogic curlog = new CursoLogic();
            foreach (Curso c in curlog.GetAll())
            {
                if (c.Materia.ID == IDMateria) // && c.Cupo > 0
                {
                    comisiones.Add(c.Comision);
                }
            }
            return comisiones;
        }
    }
}
