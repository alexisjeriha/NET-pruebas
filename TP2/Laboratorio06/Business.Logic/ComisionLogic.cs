using Business.Entities;
using Data.Database;
using System;
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
            try
            {
                return ComisionData.GetOne(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de la comision", Ex);
                throw ExcepcionManejada;
            }

        }

        public bool Existe(int idPlan, string desc, int anio)
        {
            try
            {
                return ComisionData.ExisteComision(idPlan, desc, anio);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la Comision", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<Comision> GetAll()
        {
            try
            {
                return ComisionData.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Comision com)
        {
            try
            {
                ComisionData.Save(com);
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al guardar la comision.", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                ComisionData.Delete(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la comision.", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<Comision> GetComisionesParaInscripcion(int IDPlan, int IDAlumno)
        {
            try
            {
                return ComisionData.GetComisionesParaInscripcion(IDPlan, IDAlumno);
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar las comisiones disponibles para el alumno.", Ex);
                throw ExcepcionManejada;
            }
        }

        // Devuelve las comisiones con cupo para la materia indicada
        public List<Comision> GetComisionesDisponibles(int IDMateria)
        {
            try
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
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar las comisiones disponibles.", Ex);
                throw ExcepcionManejada;
            }

        }
    }
}
