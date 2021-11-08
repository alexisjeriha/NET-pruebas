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

            Usuario usr = usuario.GetUsuarioForLogin(tbUsuario.Text, tbPasswd.Text);
            Session["UsuarioActual"] = usr;
            Page.Response.Redirect("~/Default.aspx");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Write("Lo lamentamos, usted será dado de baja de la academia :(");
        }

    }
}