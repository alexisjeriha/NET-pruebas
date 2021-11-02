using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            fillCmb();
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic planLogic = new PlanLogic();
            try
            {
                PlanActual = planLogic.GetOne(ID);
                fillCmb();
                MapearDeDatos();
            }
            catch (Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fillCmb()
        {
            try
            {
                EspecialidadLogic EspecialidadNegocio = new EspecialidadLogic();
                cmbIDEsp.DataSource = EspecialidadNegocio.GetAll();
                cmbIDEsp.ValueMember = "ID";
                cmbIDEsp.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearDeDatos()
        {
            //txtIDplan.Text = PlanActual.ID.ToString();
            txtDesc.Text = PlanActual.Descripcion;
            cmbIDEsp.SelectedValue = PlanActual.Especialidad.Id;

            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    PlanActual = new Plan { State = BusinessEntity.States.New };
                    break;
                case ModoForm.Baja:
                    PlanActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    PlanActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                {
                    PlanActual.Id = Convert.ToInt32(txtIDplan.Text);
                }
                PlanActual.Descripcion = txtDesc.Text;
                PlanActual.Especialidad.Id = Convert.ToInt32(cmbIDEsp.SelectedValue);
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                PlanLogic planLogic = new PlanLogic();
                if (Modo != ModoForm.Alta || !planLogic.ExistePlan(PlanActual.Descripcion, PlanActual.Especialidad.Id))
                {
                    planLogic.Save(PlanActual);
                }
                else this.Notificar("Ya existe este Plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            Boolean valido = true;
            if (this.txtDesc.Text == String.Empty || this.cmbIDEsp.SelectedItem == null)
            {
                valido = false;
                this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return valido;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
