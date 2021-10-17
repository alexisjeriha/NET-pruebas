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

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            nombreTextBox.Text = Entity.Nombre;
            apellidoTextBox.Text = Entity.Apellido;
            emailTextBox.Text = Entity.EMail;
            habilitadoCheckBox.Checked = Entity.Habilitado;
            nombreUsuarioTextBox.Text = Entity.NombreUsuario;
        }

        private void EnableForm(bool enable)
        {
            nombreTextBox.Enabled = enable;
            apellidoTextBox.Enabled = enable;
            emailTextBox.Enabled = enable;
            nombreUsuarioTextBox.Enabled = enable;
            claveTextBox.Visible = enable;
            claveLabel.Visible = enable;
            repetirClaveTextBox.Visible = enable;
            repetirClaveLabel.Visible = enable;
        }

        private void ClearForm()
        {
            nombreTextBox.Text = string.Empty;
            apellidoTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            habilitadoCheckBox.Checked = false;
            nombreUsuarioTextBox.Text = string.Empty;
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = nombreTextBox.Text;
            usuario.Apellido = apellidoTextBox.Text;
            usuario.EMail = emailTextBox.Text;
            usuario.NombreUsuario = nombreUsuarioTextBox.Text;
            usuario.Clave = claveTextBox.Text;
            usuario.Habilitado = habilitadoCheckBox.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            Logic.Save(usuario);
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }


        #region Event Handlers
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                gridConfirmPanel.Visible = true; // Agregado
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
            }
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                gridConfirmPanel.Visible = true; // Agregado
                gridActionsPanel.Visible = false;// Agregado
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        // No se si la funcionalidad estaba asociada a este boton ya que en el enunciado refería 
        // a aceptarLinkButton_Click
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch(FormMode)
                {

                case FormModes.Alta:
            // Duda modificación punto 39
            Entity = new Usuario();
                Entity.ID = SelectedID;
                Entity.State = BusinessEntity.States.Modified;
                LoadEntity(Entity);
                SaveEntity(Entity);
                LoadGrid();
                break;

                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    LoadGrid();
                    break;
                case FormModes.Modificacion:
                    Entity = new Usuario();
                    Entity.ID = SelectedID;
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    LoadGrid();
                    break;
                default:
                    break;
            }
            formPanel.Visible = false;
            gridConfirmPanel.Visible = false; // Agregado
            gridActionsPanel.Visible = true; // Agregado

        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            // Chequear que no sea necesaria funcionalidad extra.
            LoadGrid();
            formPanel.Visible = false;
            gridConfirmPanel.Visible = false; // Agregado
            gridActionsPanel.Visible = true; // Agregado
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            gridConfirmPanel.Visible = true; // Agregado
            gridActionsPanel.Visible = false; // Agregado
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        #endregion

        #region Properties

        private Usuario Entity
        {
            get;
            set;
        }
        private int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null) { return (int)ViewState["SelectedID"]; }
                else { return 0; }
            }
            set
            {
                ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get { return (SelectedID != 0); }
        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }

        #endregion
    }
}