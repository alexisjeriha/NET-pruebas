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
    public partial class Inscripciones : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridInscripciones();
            if (gridView.SelectedIndex == -1)
            {
                eliminarLinkButton.Visible = false;
                gridActionsPanel.Visible = true;
            }
        }

        AlumnoInscripcionLogic _logic;

        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new AlumnoInscripcionLogic();
                return _logic;
            }
        }

        AlumnoInscripcion _Entity;

        private AlumnoInscripcion Entity
        {
            get
            {
                if (_Entity != null)
                    return _Entity;
                else
                    return null;
            }
            set
            {
                _Entity = value;
            }
        }

        public Usuario UsuarioActual
        {
            get { return (Usuario)Session["UsuarioActual"]; }
        }

        private int SelectedIDInscripciones
        {
            get
            {
                if (ViewState["SelectedIDInscripciones"] != null)
                    return (int)ViewState["SelectedIDInscripciones"];
                else
                    return 0;
            }
            set
            {
                ViewState["SelectedIDInscripciones"] = value;
            }
        }

        private int SelectedIDMaterias
        {
            get
            {
                if (ViewState["SelectedIDMaterias"] != null)
                    return (int)ViewState["SelectedIDMaterias"];
                else
                    return 0;
            }
            set
            {
                ViewState["SelectedIDMaterias"] = value;
            }
        }

        private int SelectedIDComisiones
        {
            get
            {
                if (ViewState["SelectedIDComisiones"] != null)
                    return (int)ViewState["SelectedIDComisiones"];
                else
                    return 0;
            }
            set
            {
                ViewState["SelectedIDComisiones"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (SelectedIDInscripciones != 0);
            }
        }

        private void LoadGridInscripciones()
        {
                gridView.DataSource = Logic.GetAll(((Usuario)Session["UsuarioActual"]).Persona.ID);
                gridView.DataBind();
        }

        private void LoadGridMaterias()
        {

                MateriaLogic matlog = new MateriaLogic();
                GridViewMaterias.DataSource = matlog.GetMateriasParaInscripcion(UsuarioActual.Persona.Plan.ID, UsuarioActual.Persona.ID);
                GridViewMaterias.DataBind();

        }

        private void LoadGridComisiones()
        {
            try
            {
                ComisionLogic comlog = new ComisionLogic();
                GridViewComisiones.DataSource = comlog.GetComisionesDisponibles(SelectedIDMaterias);
                GridViewComisiones.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void EnableForm(bool enable)
        {
            GridViewMaterias.Visible = enable;
            GridViewComisiones.Visible = enable;
        }

        private void ClearForm()
        {
            gridView.SelectedIndex = -1;
            GridViewMaterias.SelectedIndex = -1;
            GridViewComisiones.DataSource = null;
            GridViewComisiones.DataBind();
            lblCom.Visible = false;
        }

        private void DeleteEntity(int id)
        {
            try
            {
                Logic.Delete(id);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadEntity(AlumnoInscripcion ins)
        {
            try
            {
                ins.Alumno = UsuarioActual.Persona;
                ins.Condicion = "Inscripto";
                CursoLogic curlog = new CursoLogic();
                foreach (Curso c in curlog.GetAll())
                {
                    if (c.Comision.ID == SelectedIDComisiones && c.Materia.ID == SelectedIDMaterias)
                    {
                        c.Cupo--;
                        ins.Curso = c;
                        ins.Curso.State = BusinessEntity.States.Modified;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void SaveEntity(AlumnoInscripcion ins)
        {
                Logic.Save(ins);
        }

        private void ClearSession()
        {
            Session["SelectedID"] = null;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIDInscripciones = (int)gridView.SelectedValue;
            eliminarLinkButton.Visible = true;
        }

        protected void GridViewMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIDMaterias = (int)GridViewMaterias.SelectedValue;
            LoadGridComisiones();
            lblCom.Visible = true;
        }

        protected void GridViewComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIDComisiones = (int)GridViewComisiones.SelectedValue;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                DeleteEntity(SelectedIDInscripciones);
                LoadGridInscripciones();
                eliminarLinkButton.Visible = false;
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            gridActionsPanel.Visible = false;
            GridViewMaterias.Visible = true;

            LoadGridMaterias();
            ClearForm();
            EnableForm(true);
        }

        private bool Validar()
        {
            if (SelectedIDComisiones == 0 || SelectedIDMaterias == 0)
                return false;
            else return true;
        }


        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Entity = new AlumnoInscripcion();
                LoadEntity(Entity);
                if (!Logic.ExisteInscripcion(Entity.Alumno.ID, Entity.Curso.ID))
                {
                    SaveEntity(Entity);
                }
                else
                    Response.Write("<script>window.alert('Ya se encuentra inscripto a ese cursado.');</script>");
            }
            ClearSession();
            ClearForm();
            formPanel.Visible = false;
            gridActionsPanel.Visible = true;
            eliminarLinkButton.Visible = false;
            LoadGridInscripciones();
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            formPanel.Visible = false;
            gridActionsPanel.Visible = true;
            eliminarLinkButton.Visible = false;
        }

        public class Modes : Page
        {
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
        }
    }
}