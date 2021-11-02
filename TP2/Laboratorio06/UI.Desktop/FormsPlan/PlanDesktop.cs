using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop.FormsPlan
{
    public partial class PlanDesktop : ApplicationForm
    {
        public PlanDesktop()
        {
            InitializeComponent();
        }

        private void PlanDesktop_Load(object sender, EventArgs e)
        {

        }
        Plan planActual;

        public Plan PlanActual
        {
            get { return planActual; }
            set { planActual = value; }
        }

        public PlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            fillCbx();
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic planLogic = new PlanLogic();
            try
            {
                PlanActual = planLogic.GetOne(ID);
                fillCbx();
                MapearDeDatos();
            }
            catch (Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillCbx()
        {
            try
            {
                EspecialidadLogic EspecialidadNegocio = new EspecialidadLogic();
                cbxEspecialidad.DataSource = EspecialidadNegocio.GetAll();
                cbxEspecialidad.DisplayMember = "Descripcion";
                cbxEspecialidad.ValueMember = "ID";
                cbxEspecialidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            txtID.Text = PlanActual.ID.ToString();
            txtDescripcion.Text = PlanActual.Descripcion;
            cbxEspecialidad.SelectedValue = PlanActual.Especialidad.ID;

            switch (Modo)
            {
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
                default:
                    btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Baja:
                    PlanActual.State = Plan.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    PlanActual.State = Plan.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    PlanActual = new Plan();
                    PlanActual.State = Plan.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.State = Plan.States.Modified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                {
                    PlanActual.ID = Convert.ToInt32(txtID.Text);
                }
                PlanActual.Descripcion = txtDescripcion.Text;
                PlanActual.Especialidad.ID = Convert.ToInt32(cbxEspecialidad.SelectedValue);
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                PlanLogic planLogic = new PlanLogic();
                if (Modo != ModoForm.Alta || !planLogic.ExistePlan(PlanActual.Descripcion, PlanActual.Especialidad.ID))
                {
                    planLogic.Save(PlanActual);
                }
                else Notificar("Ya existe este Plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            Boolean valido = true;
            if (txtDescripcion.Text == String.Empty || cbxEspecialidad.SelectedItem == null)
            {
                valido = false;
                Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return valido;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
