using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {


        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", SqlConn);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();

                    esp.Id = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];

                    especialidades.Add(esp);

                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return especialidades;
        }

        public Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades where id_especialidad = @id", SqlConn);
                // Cambio en funcionalidad respecto a lo extablecido en enunciado -> Evaluar
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdEspecialidades.ExecuteNonQuery();
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {
                    esp.Id = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }
                drEspecialidades.Close(); // ?
            }
            catch (Exception)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la especialidad");
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return esp;
        }

        public void Delete(int ID)
        {

            try
            {
                //abrimos la conexión
                OpenConnection();
                //creamos la sentencia sql y asignamos un valor al parámetro
                SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                //ejecutamos la sentencia sql
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            //Especialidades.Remove(GetOne(ID));
        }

        protected void Update(Especialidad esp)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "UPDATE especialidades SET desc_especialidad = @desc_esp " +
                "WHERE id_especialidad=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = esp.Id;
                cmdSave.Parameters.Add("@desc_esp", SqlDbType.VarChar, 50).Value = esp.Descripcion;
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Especialidad esp)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into especialidades (desc_especialidad) " +
                "values (@desc_esp) " +
                "select @@identity", SqlConn); //esta línea es para recuperar el ID que asignó el sql automáticamente
                cmdSave.Parameters.Add("@desc_esp", SqlDbType.VarChar, 50).Value = esp.Descripcion;
                esp.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //así se obtiene el ID que asignó al BD automáticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al crear especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Save(Especialidad esp)
        {

            if (esp.State == BusinessEntity.States.Deleted)
            {
                Delete(esp.Id);
            }

            else if (esp.State == BusinessEntity.States.New)
            {
                Insert(esp);

            }
            else if (esp.State == BusinessEntity.States.Modified)
            {
                Update(esp);
            }
            esp.State = BusinessEntity.States.Unmodified;
        }

    }
}
