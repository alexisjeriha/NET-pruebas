using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
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
                drUsuarios.Close();
            }
            catch (Exception)
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
                "values (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email) " +
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
            try
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
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar usuario", Ex);
                throw ExcepcionManejada;
            }
        }


        public Usuario GetUsuarioYClave(string nombreUsuario)
        {
            Usuario usr = new Usuario();

            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand("select * from usuarios where nombre_usuario = @nombre_usuario", SqlConn);
                cmd.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = nombreUsuario;

                SqlDataReader drUsuarios = cmd.ExecuteReader();

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
                drUsuarios.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                CloseConnection();
            }
            return usr;
        }

        public Usuario GetUsuarioForLogin(string user, string pass)
        {
            Usuario usr = new Usuario();
            try
            {
                OpenConnection();
                SqlCommand cmdGetUsuario = new SqlCommand("Select * from usuarios u INNER JOIN personas p on u.id_persona=p.id_persona "
                    + "INNER JOIN planes pl on pl.id_plan=p.id_plan INNER JOIN especialidades e on pl.id_especialidad=e.id_especialidad where nombre_usuario=@user and clave=@pass", SqlConn);
                cmdGetUsuario.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                cmdGetUsuario.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                SqlDataReader drUsuarios = cmdGetUsuario.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];

                    Persona per = new Persona();
                    per.ID = (int)drUsuarios["id_persona"];
                    per.Nombre = (string)drUsuarios["nombre"];
                    per.Apellido = (string)drUsuarios["apellido"];
                    per.Email = (string)drUsuarios["email"];
                    per.Direccion = (string)drUsuarios["direccion"];
                    per.Telefono = (string)drUsuarios["telefono"];
                    per.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    per.Legajo = (int)drUsuarios["legajo"];
                    switch ((int)drUsuarios["tipo_persona"])
                    {
                        case 1:
                            per.Tipo = "Alumno";
                            break;
                        case 2:
                            per.Tipo = "Docente";
                            break;

                    }
                    Plan pla = new Plan();
                    pla.ID = (int)drUsuarios["id_plan"];
                    pla.Descripcion = (string)drUsuarios["desc_plan"];
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drUsuarios["id_especialidad"];
                    esp.Descripcion = (string)drUsuarios["desc_especialidad"];
                    pla.Especialidad = esp;
                    per.Plan = pla;
                    usr.Persona = per;
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return usr;
        }

    }
}
