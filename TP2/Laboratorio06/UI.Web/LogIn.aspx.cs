using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class LogIn : Page
    {
        private UsuarioLogic usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = new UsuarioLogic();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usr = new Usuario();
                usr = usuario.GetUsuarioYClave(tbUsuario.Text);

                if (tbUsuario.Text == usr.NombreUsuario && tbPasswd.Text == usr.Clave) //tbUsuario.Text == usr.NombreUsuario && tbPass.Text == usr.Clave
                {
                    Session["NombreUsuario"] = usr.Nombre;
                    Response.Redirect("~/Default.aspx");
                }
                else lblError.Visible = true;
            }
            catch (Exception)
            {
                lblError.Visible = true;
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Write("Usted es idiota");
        }
    }
}