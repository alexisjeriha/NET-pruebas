using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas per " +
                    "INNER JOIN planes p on per.id_plan = p.id_plan", SqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Tipo = (int)drPersonas["tipo_persona"];
                    per.Direccion = (string)drPersonas["direccion"];

                    Plan plan = new Plan();
                    plan.ID = (int)drPersonas["id_plan"];
                    per.Plan = plan;

                    personas.Add(per);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return personas;
        }

        public Persona GetOne(int ID)
        {

            Persona per = new Persona();

            try
            {
                OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona=@id", SqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Tipo = (int)drPersonas["tipo_persona"];
                    per.Direccion = (string)drPersonas["telefono"];
                    per.Plan.ID = (int)drPersonas["id_plan"]; 
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return per;
        }

        public bool ExistePersona(Persona per)
        {
            bool existePersona;


            try
            {
                OpenConnection();
                SqlCommand cmdExistePersona = new SqlCommand("select * from personas where nombre=@nom " +
                    " and apellido=@ape and direccion = @dir and email = @email and telefono = @tel and fecha_nac = @fecnac" +
                    " and legajo = @leg and tipo_persona = @tipo and id_plan = @idplan", SqlConn);
                cmdExistePersona.Parameters.Add("@nom", SqlDbType.VarChar, 50).Value = per.Nombre;
                cmdExistePersona.Parameters.Add("@ape", SqlDbType.VarChar, 50).Value = per.Apellido;
                cmdExistePersona.Parameters.Add("@dir", SqlDbType.VarChar, 50).Value = per.Direccion;
                cmdExistePersona.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = per.Email;
                cmdExistePersona.Parameters.Add("@tel", SqlDbType.VarChar, 50).Value = per.Telefono;
                cmdExistePersona.Parameters.Add("@fecnac", SqlDbType.DateTime).Value = per.FechaNacimiento;
                cmdExistePersona.Parameters.Add("@leg", SqlDbType.Int).Value = per.Legajo;
                cmdExistePersona.Parameters.Add("@tipo", SqlDbType.Int).Value = per.Tipo;
                cmdExistePersona.Parameters.Add("@idplan", SqlDbType.Int).Value = per.Plan.ID;
                existePersona = Convert.ToBoolean(cmdExistePersona.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la persona", Ex);
                throw ExcepcionManejada;
            }

            return existePersona;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }


        }
        public void Update(Persona per)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                 "UPDATE personas SET nombre = @nom, apellido = @ape, direccion = @dir, email = @email, " +
                 "telefono = @tel, fecha_nac = @fecnac, legajo = @leg, tipo_persona = @tipo, id_plan=@idplan " +
                 "WHERE id_persona=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = per.ID;
                cmdUpdate.Parameters.Add("@nom", SqlDbType.VarChar, 50).Value = per.Nombre;
                cmdUpdate.Parameters.Add("@ape", SqlDbType.VarChar, 50).Value = per.Apellido;
                cmdUpdate.Parameters.Add("@dir", SqlDbType.VarChar, 50).Value = per.Direccion;
                cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = per.Email;
                cmdUpdate.Parameters.Add("@tel", SqlDbType.VarChar, 50).Value = per.Telefono;
                cmdUpdate.Parameters.Add("@fecnac", SqlDbType.DateTime).Value = per.FechaNacimiento;
                cmdUpdate.Parameters.Add("@leg", SqlDbType.Int).Value = per.Legajo;
                cmdUpdate.Parameters.Add("@tipo", SqlDbType.Int).Value = per.Tipo;
                cmdUpdate.Parameters.Add("@idplan", SqlDbType.Int).Value = per.Plan.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Persona per)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "insert into personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan)" +
                    "values (@nom, @ape, @dir, @email, @tel, @fecnac, @leg, @tipo, @idplan)" +
                    "select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@nom", SqlDbType.VarChar, 50).Value = per.Nombre;
                cmdInsert.Parameters.Add("@ape", SqlDbType.VarChar, 50).Value = per.Apellido;
                cmdInsert.Parameters.Add("@dir", SqlDbType.VarChar, 50).Value = per.Direccion;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = per.Email;
                cmdInsert.Parameters.Add("@tel", SqlDbType.VarChar, 50).Value = per.Telefono;
                cmdInsert.Parameters.Add("@fecnac", SqlDbType.DateTime).Value = per.FechaNacimiento;
                cmdInsert.Parameters.Add("@leg", SqlDbType.Int).Value = per.Legajo;
                cmdInsert.Parameters.Add("@tipo", SqlDbType.Int).Value = per.Tipo;
                cmdInsert.Parameters.Add("@idplan", SqlDbType.Int).Value = per.Plan.ID;
                per.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Persona per)
        {
            if (per.State == BusinessEntity.States.Deleted)
            {
                Delete(per.ID);
            }

            else if (per.State == BusinessEntity.States.New)
            {
                Insert(per);
            }

            else if (per.State == BusinessEntity.States.Modified)
            {
                Update(per);
            }
            per.State = BusinessEntity.States.Unmodified;
        }

    }
}
