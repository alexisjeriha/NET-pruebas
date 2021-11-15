using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter planData;

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public PlanAdapter PlanData
        {
            get { return planData; }
            set { planData = value; }
        }

        public Plan GetOne(int ID)
        {
            try
            {
                return PlanData.GetOne(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del plan", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<Plan> GetAll()
        {
            try
            {
                return PlanData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
        }

        public bool ExistePlan(string desc, int idEsp)
        {
            try
            {
                return PlanData.ExistePlan(desc, idEsp);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia del Plan", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Plan plan)
        {
            try
            {
                PlanData.Save(plan);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al guardar el Plan", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                PlanData.Delete(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el Plan", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
