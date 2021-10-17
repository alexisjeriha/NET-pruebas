using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuarios : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }
        
        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }
        private void LoadGrid()
        {
            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();

        }
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Funcionalidad futura ?
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            //Funcionalidad futura ?
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            //Funcionalidad futura ?
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            //Funcionalidad futura ?
        }
    }
}