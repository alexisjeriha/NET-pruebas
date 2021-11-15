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

    public partial class Notas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        AlumnoInscripcionLogic _logic;
        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AlumnoInscripcionLogic();
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
            notaTextBox.Text = Entity.Nota.ToString();


        }

        private void EnableForm(bool enable)
        {
            notaTextBox.Enabled = enable;

        }

        private void ClearForm()
        {
            notaTextBox.Text = string.Empty;

        }

        private void LoadEntity(AlumnoInscripcion inscripcion)
        {
            inscripcion.Nota = int.Parse(notaTextBox.Text);


        }

        private void SaveEntity(AlumnoInscripcion inscripcion)
        {
            Logic.Save(inscripcion);
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
            if (int.Parse(notaTextBox.Text) >= 0 && int.Parse(notaTextBox.Text) <= 10)
            {
                Entity = new AlumnoInscripcion();
                Entity = Logic.GetOne(SelectedID);
                Entity.State = BusinessEntity.States.Modified;
                LoadEntity(Entity);
                Entity.Nota = int.Parse(notaTextBox.Text);
                if (int.Parse(notaTextBox.Text) >= 4 && int.Parse(notaTextBox.Text) <= 6)
                {
                    Entity.Condicion = "Regular";
                }
                else if (int.Parse(notaTextBox.Text) > 6)
                {
                    Entity.Condicion = "Aprobado";
                }

                else if (int.Parse(notaTextBox.Text) == 0)
                {
                    Entity.Condicion = "Inscripto";
                }

                else
                {
                    Entity.Condicion = "Libre";
                }


                SaveEntity(Entity);
                LoadGrid();


                formPanel.Visible = false;
                gridConfirmPanel.Visible = false;
                gridActionsPanel.Visible = true;
            }
            else
            {
                Response.Write("<script> alert(" + "'Debe ingresar una nota válida'" + ") </script>");
            }

            notaTextBox.Text = string.Empty;

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
            formPanel.Visible = true;
            gridConfirmPanel.Visible = true;
            gridActionsPanel.Visible = false;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        #endregion

        #region Properties

        private AlumnoInscripcion Entity
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
