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
            try
            {
                return PersonaData.GetAll(0);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
        }
        public List<Persona> GetAlumnos()
        {
            try
            {
                return PersonaData.GetAll(1);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<Persona> GetDocentes()
        {
            try
            {
                return PersonaData.GetAll(2);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
        }
        public Persona GetOne(int id)
        {
            try
            {
                return PersonaData.GetOne(id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
        }

        public bool ExistePersona(Persona per)
        {
            try
            {
                return PersonaData.ExistePersona(per);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la persona", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Update(Persona per)
        {
            try
            {
                PersonaData.Update(per);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Persona per)
        {
            try
            {
                PersonaData.Save(per);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al guardar persona", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(int id)
        {
            try
            {
                PersonaData.Delete(id);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la persona", Ex);
                throw ExcepcionManejada;
            }
        }
    }
}
