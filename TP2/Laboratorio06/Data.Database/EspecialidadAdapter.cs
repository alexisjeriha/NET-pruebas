using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;



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
            catch(Exception)
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
        }
                

        protected void Update(Especialidad especialidad)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "UPDATE especialidades SET desc_especialidad = @Descripcion" +
                "WHERE id_especialidad=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.Id;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos de la especialdad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }


        protected void Insert(Especialidad especialidad)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into especialidades (id_especialdad, desc_especialdad) " +
                "values (@id, @descripcion) " +
                "select @@identity", SqlConn); //esta línea es para recuperar el ID que asignó el sql automáticamente

                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                especialidad.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //así se obtiene el ID que asignó al BD automáticamente
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

        
        public void Save(Especialidad especialidad)
        {

            if (especialidad.State == BusinessEntity.States.Deleted)
            {
                Delete(especialidad.Id);
            }

            else if (especialidad.State == BusinessEntity.States.New)
            {
                Insert(especialidad);

            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }

    }
}
