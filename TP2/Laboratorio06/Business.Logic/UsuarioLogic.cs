using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private UsuarioAdapter UsuarioData;
        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public Usuario GetOne(int ID)
        {
            try
            {
                return UsuarioData.GetOne(ID);
            }
            catch (Exception)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario");
                throw ExcepcionManejada;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                UsuarioData.Delete(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Usuario usr)
        {
            try
            {
                UsuarioData.Save(usr);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar usuario", Ex);
                throw ExcepcionManejada;
            }
        }
        public Usuario GetUsuarioYClave(string nombreUsuario)
        {
            try
            {
                return UsuarioData.GetUsuarioYClave(nombreUsuario);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }

        }

        public Usuario GetUsuarioForLogin(string user, string pass)
        {
            try
            {
                return UsuarioData.GetUsuarioForLogin(user, pass);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
        }

    }
}
