using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
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

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try { 
            Usuario usr = usuario.GetUsuarioForLogin(tbUsuario.Text, tbPasswd.Text);
            if (usr.ID != 0)
            {
                Session["UsuarioActual"] = usr;
                Page.Response.Redirect("~/Default.aspx");
            }
        
                else lblError.Visible = true;
            }
            catch (Exception)
            {
                lblError.Visible = true;
            }
        }

    }
}