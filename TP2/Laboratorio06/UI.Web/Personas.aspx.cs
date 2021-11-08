using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    class DropItem
    {
        public int IDTipo { get; set; }
        public string Tipo { get; set; }
    }

    public partial class Personas : System.Web.UI.Page
    {
        PersonaLogic _logic;

        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            nombreTextBox.Text = Entity.Nombre;
            apellidoTextBox.Text = Entity.Apellido;
            direccionTextBox.Text = Entity.Direccion;
            emailTextBox.Text = Entity.Email;
            telefonoTextBox.Text = Entity.Telefono;
            fechaNacTextBox.Text = Entity.FechaNacimiento.ToString("yyyy-MM-dd");
            legajoTextBox.Text = Entity.Legajo.ToString();
            tipoDropDownList.SelectedValue = Entity.Tipo.ToString();
            iDPlanDropDownList.SelectedValue = Entity.Plan.Descripcion;
        }
        private void LoadGrid()
        {
            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();
        }

        private void LoadDrop()
        {
            PlanLogic pl = new PlanLogic();
            iDPlanDropDownList.DataSource = pl.GetAll();
            iDPlanDropDownList.DataTextField = "Descripcion";
            iDPlanDropDownList.DataValueField = "Id";
            iDPlanDropDownList.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Plan--";
            init.Value = "-1";
            iDPlanDropDownList.Items.Add(init);
            iDPlanDropDownList.SelectedValue = "-1";


            tipoDropDownList.DataSource = new DropItem[]
            {
                  new DropItem{ IDTipo = 1, Tipo = "Alumno" },
                  new DropItem{ IDTipo = 2, Tipo = "Docente" },
            };

            ListItem ini = new ListItem();

            tipoDropDownList.DataTextField = "Tipo";
            tipoDropDownList.DataValueField = "IDTipo";
            ini.Text = "--Seleccionar Tipo--";
            ini.Value = "-1";
            tipoDropDownList.SelectedValue = "-1";


        }


        private void EnableForm(bool enable)
        {
            nombreTextBox.Enabled = enable;
            apellidoTextBox.Enabled = enable;
            direccionTextBox.Enabled = enable;
            emailTextBox.Enabled = enable;
            telefonoTextBox.Enabled = enable;
            fechaNacTextBox.Enabled = enable;
            legajoTextBox.Enabled = enable;
            tipoDropDownList.Enabled = enable;
        }

        private void ClearForm()
        {
            nombreTextBox.Text = string.Empty;
            apellidoTextBox.Text = string.Empty;
            direccionTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            telefonoTextBox.Text = string.Empty;
            fechaNacTextBox.Text = string.Empty;
            legajoTextBox.Text = string.Empty;

        }

        private void LoadEntity(Persona pers)
        {
            pers.Nombre = nombreTextBox.Text;
            pers.Apellido = apellidoTextBox.Text;
            pers.Direccion = direccionTextBox.Text;
            pers.Email = emailTextBox.Text;
            pers.Telefono = telefonoTextBox.Text;
            pers.FechaNacimiento = DateTime.Parse(fechaNacTextBox.Text);
            pers.Legajo = int.Parse(legajoTextBox.Text);
            pers.Tipo = int.Parse(tipoDropDownList.SelectedItem.Value);
            pers.Plan.Id = Convert.ToInt32(iDPlanDropDownList.SelectedItem.Value); //Checkear
        }

        private void SaveEntity(Persona pers)
        {
            Logic.Save(pers);
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
                LoadDrop();
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
                    Entity = new Persona();
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
                    Entity = new Persona();
                    Entity.IdPersona = SelectedID;
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
            LoadDrop();
            formPanel.Visible = true;
            gridConfirmPanel.Visible = true;
            gridActionsPanel.Visible = false;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        #endregion

        #region Properties

        private Persona Entity
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
