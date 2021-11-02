using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes p " +
                    "INNER JOIN especialidades e on p.id_especialidad = e.id_especialidad", SqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan pla = new Plan();
                    pla.Id = (int)drPlanes["id_plan"];
                    pla.Descripcion = (string)drPlanes["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.Id = (int)drPlanes["id_especialidad"];
                    //esp.Descripcion = (string)drPlanes["desc_especialidad"];
                    pla.Especialidad = esp;
                    planes.Add(pla);

                }
                drPlanes.Close();
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
            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            try
            {
                OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan=@id", SqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    plan.Id = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.Especialidad.Id = (int)drPlanes["id_especialidad"];
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del Plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return plan;
        }

        public bool ExistePlan(string desc, int idEsp)
        {
            bool existePlan;
            try
            {
                OpenConnection();
                SqlCommand cmdExistePlan = new SqlCommand("select * from planes where desc_plan=@desc and id_especialidad=@idEsp", SqlConn);
                cmdExistePlan.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = desc;
                cmdExistePlan.Parameters.Add("@idEsp", SqlDbType.Int).Value = idEsp;
                existePlan = Convert.ToBoolean(cmdExistePlan.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia del Plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return existePlan;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el Plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Plan plan)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE planes SET desc_plan=@desc WHERE id_plan=@id and id_especialidad=@idEsp", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = plan.Id;
                cmdUpdate.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdUpdate.Parameters.Add("@idEsp", SqlDbType.Int).Value = plan.Especialidad.Id;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del Plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into planes(desc_plan, id_especialidad) " +
                "values(@desc, @idEsp) " +
                "select @@identity", SqlConn);
                cmdInsert.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdInsert.Parameters.Add("@idEsp", SqlDbType.Int).Value = plan.Especialidad.Id;
                plan.Id = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear un nuevo Plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
            {
                Delete(plan.Id);
            }
            else if (plan.State == BusinessEntity.States.New)
            {
                Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}