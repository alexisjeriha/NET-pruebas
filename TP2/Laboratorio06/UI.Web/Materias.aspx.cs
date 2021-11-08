using Business.Logic;
using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Materias : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        MateriaLogic _logic;
        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
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
            descripcionTextBox.Text = Entity.Descripcion;

        }
        
        private void DDLPlanesLoad()
        {
            PlanLogic el = new PlanLogic();
            DropDownListPlanes.DataSource = el.GetAll();
            DropDownListPlanes.DataTextField = "Descripcion";
            DropDownListPlanes.DataValueField = "ID";
            DropDownListPlanes.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Plan--";
            init.Value = "-1";
            DropDownListPlanes.Items.Add(init);
            DropDownListPlanes.SelectedValue = "-1";
        }
        
        private void EnableForm(bool enable)
        {
            descripcionTextBox.Enabled = enable;
            hssemanalesTextBox.Enabled = enable;
            hstotalesTextBox.Enabled = enable;
            DropDownListPlanes.Enabled = enable;
        }

        private void ClearForm()
        {
            descripcionTextBox.Text = string.Empty;
            hssemanalesTextBox.Text = string.Empty;
            hstotalesTextBox.Text = string.Empty;
        }
        
        private void LoadEntity(Materia materia)
        {
            materia.Descripcion = descripcionTextBox.Text;
            materia.HSSemanales = Convert.ToInt32(hssemanalesTextBox.Text);
            materia.HSTotales = Convert.ToInt32(hstotalesTextBox.Text);
            materia.Plan.ID = Convert.ToInt32(DropDownListPlanes.SelectedItem.Value); //Checkear
        }
        
        private void SaveEntity(Materia materia)
        {
            Logic.Save(materia);
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
                formPanel.Visible = false;
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
                DDLPlanesLoad();
                formPanel.Visible = true;
                gridConfirmPanel.Visible = true; // Agregado
                gridActionsPanel.Visible = false;// Agregado
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
                    Entity = new Materia();
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
                    Entity = new Materia();
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
            gridConfirmPanel.Visible = false; 
            gridActionsPanel.Visible = true; 

        }
        
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            LoadGrid();
            formPanel.Visible = false;
            gridConfirmPanel.Visible = false;
            gridActionsPanel.Visible = true;
        }
        
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            DDLPlanesLoad();
            formPanel.Visible = true;
            gridConfirmPanel.Visible = true;
            gridActionsPanel.Visible = false; 
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        #endregion
        
        #region Properties

        private Materia Entity
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