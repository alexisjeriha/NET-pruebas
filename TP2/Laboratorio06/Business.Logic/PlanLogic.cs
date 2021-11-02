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
            return PlanData.GetOne(ID);
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public bool ExistePlan(string desc, int idEsp)
        {
            return PlanData.ExistePlan(desc, idEsp);
        }

        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }
    }
}