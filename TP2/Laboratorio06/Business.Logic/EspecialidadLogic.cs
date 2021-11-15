using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private EspecialidadAdapter EspecialidadData;
        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            try
            {
                return EspecialidadData.GetAll();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
        }

        public Especialidad GetOne(int ID)
        {
            try
            {
                return EspecialidadData.GetOne(ID);
            }
            catch (Exception)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la especialidad");
                throw ExcepcionManejada;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                EspecialidadData.Delete(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Especialidad esp)
        {
            try
            {
                EspecialidadData.Save(esp);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al guardar especialidad", Ex);
                throw ExcepcionManejada;
            }
        }

    }
}
