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
    public partial class Especialidades : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();

        }

        private void LoadForm(int ID)
        {
            Entity = Logic.GetOne(ID);
            descripcionTextBox.Text = Entity.Descripcion;
        }
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        EspecialidadLogic _logic;
        private EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new EspecialidadLogic();
                }
                return _logic;
            }
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                gridConfirmPanel.Visible = true; 
                gridActionsPanel.Visible = false;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
                EnableForm(true);

            }
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (FormMode)
            {

                case FormModes.Alta:
                    Entity = new Especialidad();
                    Entity.State = BusinessEntity.States.New;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    LoadGrid();
                    break;

                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    LoadGrid();
                    break;
                case FormModes.Modificacion:
                    Entity = new Especialidad();
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

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = false;
                gridConfirmPanel.Visible = true; // Agregado
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
            }
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

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            LoadGrid();
            formPanel.Visible = false;
            gridConfirmPanel.Visible = false;
            gridActionsPanel.Visible = true;
        }

        private void EnableForm(bool enable)
        {
            descripcionTextBox.Enabled = enable;
          
        }
        private void ClearForm()
        {
            descripcionTextBox.Text = string.Empty;
        }

        private void LoadEntity(Especialidad especialidad)
        {
            especialidad.Descripcion = descripcionTextBox.Text;

        }

        private void SaveEntity(Especialidad especialidad)
        {
            Logic.Save(especialidad);
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        #region Properties
        private Especialidad Entity { get; set; }
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