using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones m INNER JOIN planes p on m.id_plan = p.id_plan "
                   + " INNER JOIN especialidades e on p.id_especialidad = e.id_especialidad", SqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.DescComision = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];

                    Plan pla = new Plan();
                    pla.ID = (int)drComisiones["id_plan"];
                    pla.Descripcion = (string)drComisiones["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drComisiones["id_especialidad"];
                    esp.Descripcion = (string)drComisiones["desc_especialidad"];

                    pla.Especialidad = esp;
                    com.Plan = pla;
                    comisiones.Add(com);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("select * from comisiones m INNER JOIN planes p on m.id_plan = p.id_plan "
                    + "INNER JOIN especialidades e on p.id_especialidad = e.id_especialidad where id_comision=@id", SqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComision = cmdComision.ExecuteReader();
                if (drComision.Read())
                {
                    com.ID = (int)drComision["id_comision"];
                    com.DescComision = (string)drComision["desc_comision"];
                    com.AnioEspecialidad = (int)drComision["anio_especialidad"];

                    Plan pla = new Plan();
                    pla.ID = (int)drComision["id_plan"];
                    pla.Descripcion = (string)drComision["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drComision["id_especialidad"];
                    esp.Descripcion = (string)drComision["desc_especialidad"];

                    pla.Especialidad = esp;
                    com.Plan = pla;
                }

                drComision.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return com;
        }

        public bool ExisteComision(int idplan, string desc, int anio)
        {
            bool existePlan;
            try
            {
                OpenConnection();
                SqlCommand cmdExistePlan = new SqlCommand("select * from comisiones where desc_comision=@desc and anio_especialidad=@anio and id_plan=@idplan", SqlConn);
                cmdExistePlan.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = desc;
                cmdExistePlan.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                cmdExistePlan.Parameters.Add("@idplan", SqlDbType.Int).Value = idplan;
                existePlan = Convert.ToBoolean(cmdExistePlan.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la Comision", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Comision com)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE comisiones SET desc_comision=@desc, anio_especialidad=@anio, id_plan=@idplan " +
                    "WHERE id_comision=@id", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = com.ID;
                cmdUpdate.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = com.DescComision;
                cmdUpdate.Parameters.Add("@anio", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdUpdate.Parameters.Add("@idplan", SqlDbType.Int).Value = com.Plan.ID;
                //cmdUpdate.Parameters.Add("@planid", SqlDbType.Int).Value = com.Plan.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Comision com)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into comisiones(desc_comision,anio_especialidad,id_plan) " +
                "values(@desc,@anio,@idplan) " +
                "select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = com.DescComision;
                cmdInsert.Parameters.Add("@anio", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdInsert.Parameters.Add("@idplan", SqlDbType.Int).Value = com.Plan.ID;
                com.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear una nueva comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Comision com)
        {
            if (com.State == BusinessEntity.States.Deleted)
            {
                Delete(com.ID);
            }
            else if (com.State == BusinessEntity.States.New)
            {
                Insert(com);
            }
            else if (com.State == BusinessEntity.States.Modified)
            {
                Update(com);
            }
            com.State = BusinessEntity.States.Unmodified;
        }

        public List<Comision> GetComisionesParaInscripcion(int IDPlan, int IDAlumno)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                OpenConnection();
                SqlCommand cmdGGetComisionesParaInscripcion = new SqlCommand("select * from comisiones m INNER JOIN planes p on m.id_plan = p.id_plan "
                    + "INNER JOIN personas pe on pe.id_plan=p.id_plan WHERE id_persona=@idAlumno and pe.id_plan=@idPlan", SqlConn);
                cmdGGetComisionesParaInscripcion.Parameters.Add("@idPlan", SqlDbType.Int).Value = IDPlan;
                cmdGGetComisionesParaInscripcion.Parameters.Add("@idAlumno", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drComisiones = cmdGGetComisionesParaInscripcion.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.DescComision = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];

                    Plan pla = new Plan();
                    pla.ID = (int)drComisiones["id_plan"];
                    com.Plan = pla;
                    comisiones.Add(com);
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar las comisiones disponibles para el alumno.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return comisiones;
        }
    }
}
