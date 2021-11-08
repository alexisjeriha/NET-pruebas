using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Planes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        PlanLogic _logic;
        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
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
            DropDownListEspecialidades.SelectedValue = Entity.Especialidad.ID.ToString();
        }

        private void DDLEspecialidadesLoad()
        {
                EspecialidadLogic el = new EspecialidadLogic();
                DropDownListEspecialidades.DataSource = el.GetAll();
                DropDownListEspecialidades.DataTextField = "Descripcion";
                DropDownListEspecialidades.DataValueField = "ID";
                DropDownListEspecialidades.DataBind();
                ListItem init = new ListItem();
                init.Text = "--Seleccionar Especialidad--";
                init.Value = "-1";
                DropDownListEspecialidades.Items.Add(init);
                DropDownListEspecialidades.SelectedValue = "-1";
        }
        private void EnableForm(bool enable)
        {
            descripcionTextBox.Enabled = enable;
            DropDownListEspecialidades.Enabled = enable;
        }

        private void ClearForm()
        {
            descripcionTextBox.Text = string.Empty;

        }

        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = descripcionTextBox.Text;
            plan.Especialidad.ID = Convert.ToInt32(DropDownListEspecialidades.SelectedItem.Value); //Checkear
        }
        private void SaveEntity(Plan plan)
        {
            Logic.Save(plan);
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
                DDLEspecialidadesLoad();
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
                    Entity = new Plan();
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
                    Entity = new Plan();
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
            DDLEspecialidadesLoad();
            formPanel.Visible = true;
            gridConfirmPanel.Visible = true;
            gridActionsPanel.Visible = false; 
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        #endregion

        #region Properties

        private Plan Entity
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