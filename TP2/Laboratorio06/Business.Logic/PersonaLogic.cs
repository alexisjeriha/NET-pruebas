using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter personaData;

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter(); 
        }

        public PersonaAdapter PersonaData
        {
            get { return personaData; }
            set { personaData = value; }
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }

        public Persona GetOne(int id)
        {
            return PersonaData.GetOne(id);
        }

        public bool ExistePersona(Persona per)
        {
            return PersonaData.ExistePersona(per);
        }

        public void Update(Persona per)
        {
            PersonaData.Update(per);
        }

        public void Save(Persona per)
        {
            PersonaData.Save(per);
        }

        public void Delete(int id)
        {
            PersonaData.Delete(id);
        }
    }
}
