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

namespace UI.Desktop.Forms.FormsComisiones
{
    public partial class ComisionDesktop : ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {

        }

        Comision comisionActual;
        public Comision ComisionActual
        {
            get { return comisionActual; }
            set { comisionActual = value; }
        }
        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            fillCmb();
        }
        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ComisionLogic comisionLogic = new ComisionLogic();
            try
            {
                ComisionActual = comisionLogic.GetOne(ID);
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
                PlanLogic planNegocio = new PlanLogic();
                cbIdPlan.DataSource = planNegocio.GetAll();
                cbIdPlan.ValueMember = "ID";
                cbIdPlan.DisplayMember = "Descripcion";
                cbIdPlan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearDeDatos()
        {
            txtIdComision.Text = ComisionActual.IdComision.ToString();
            txtDescComision.Text = ComisionActual.DescComision;
            txtAnio.Text = ComisionActual.AnioEspecialidad.ToString();
            cbIdPlan.SelectedValue = ComisionActual.Plan.Id;

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
                    ComisionActual = new Comision { State = BusinessEntity.States.New };
                    break;
                case ModoForm.Baja:
                    ComisionActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    ComisionActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                {
                    ComisionActual.IdComision = int.Parse(txtIdComision.Text);
                }
                ComisionActual.DescComision = txtDescComision.Text;
                ComisionActual.AnioEspecialidad = int.Parse(txtAnio.Text);
                ComisionActual.Plan.Id = Convert.ToInt32(cbIdPlan.SelectedValue);
            }
        }
        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                ComisionLogic comisionLogic = new ComisionLogic();
                if (Modo != ModoForm.Alta || !comisionLogic.Existe(ComisionActual.IdComision, ComisionActual.DescComision, ComisionActual.AnioEspecialidad))
                {
                    comisionLogic.Save(ComisionActual);
                }
                else Notificar("Ya existe esta Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            Boolean valido = true;
            if (txtDescComision.Text == String.Empty || txtAnio.Text == String.Empty || cbIdPlan.SelectedItem == null)
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
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
