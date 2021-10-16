using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        //private static List<Usuario> Usuarios;

     /*
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Usuario>();
                    Usuario usr;
                    usr = new Usuario();
                    usr.ID = 1;
                    usr.State = BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.EMail = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Usuario();
                    usr.ID = 2;
                    usr.State = BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.EMail = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Usuario();
                    usr.ID = 3;
                    usr.State = BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.EMail = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion 
        */ // Datos en memoria

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", SqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];

                    usuarios.Add(usr);

                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", SqlConn);
                // Cambio en funcionalidad respecto a lo extablecido en enunciado -> Evaluar
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdUsuarios.ExecuteNonQuery();
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                }
                drUsuarios.Close(); // ?
            }
            catch(Exception)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario");
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return usr;
        }

        public void Delete(int ID)
        {

            try
            {
                //abrimos la conexión
                OpenConnection();
                //creamos la sentencia sql y asignamos un valor al parámetro
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                //ejecutamos la sentencia sql
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            //Usuarios.Remove(GetOne(ID));
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, " +
                "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email " +
                "WHERE id_usuario=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into usuarios (nombre_usuario, clave,habilitado, nombre, apellido, email) " +
                "values (@nombre_usuario, @clave, @hábilitado, @nombre, @apellido, @email) " +
                "select @@identity", SqlConn); //esta línea es para recuperar el ID que asignó el sql automáticamente
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //así se obtiene el ID que asignó al BD automáticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Save(Usuario usuario)
        {

            if (usuario.State == BusinessEntity.States.Deleted)
            {
                Delete(usuario.ID);
            }

            else if (usuario.State == BusinessEntity.States.New)
            {
                Insert(usuario);

            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }


    }
}
