using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Business.Entities;

namespace UI.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = (Usuario)Session["UsuarioActual"];

            string[] rol = { Usuario.Persona.Tipo.Substring(0, 1) };
            HttpContext.Current.User = new GenericPrincipal(HttpContext.Current.User.Identity, rol);

        }

        protected void menu_MenuItemDataBound(object sender, MenuEventArgs e)
        {

        }

        public string[] Rol { get; set; }
        public Usuario Usuario { get; set; }
    }
}