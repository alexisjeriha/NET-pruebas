using System;
using Business.Entities;
using Business.Logic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.Forms.FormsMaterias
{
    public partial class MateriaDesktop : ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();
        }

        private void MateriaDesktop_Load(object sender, EventArgs e)
        {

        }
        Materia materiaActual;

        public Materia MateriaActual
        {
            get { return materiaActual; }
            set { materiaActual = value; }
        }
        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            fillCmb();
        }
        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaLogic MateriaLogic = new MateriaLogic();
            try
            {
                MateriaActual = MateriaLogic.GetOne(ID);
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
                MateriaLogic MateriaNegocio = new MateriaLogic();
                cmbIDPlan.DataSource = MateriaNegocio.GetAll();
                cmbIDPlan.ValueMember = "ID";
                cmbIDPlan.DisplayMember = "Descripcion";
                cmbIDPlan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearDeDatos()
        {
            txtIDEsp.Text = MateriaActual.ID.ToString();
            txtDesc.Text = MateriaActual.Descripcion;
            txtHSSem.Text = MateriaActual.HSSemanales.ToString();
            txtHSTot.Text = MateriaActual.HSTotales.ToString();
            cmbIDPlan.SelectedValue = MateriaActual.Plan.Id;

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
                    MateriaActual = new Materia { State = BusinessEntity.States.New };
                    break;
                case ModoForm.Baja:
                    MateriaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    MateriaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    MateriaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                {
                    MateriaActual.ID = int.Parse(txtIDEsp.Text);
                }
                MateriaActual.Descripcion = txtDesc.Text;
                MateriaActual.HSSemanales = int.Parse(txtHSSem.Text);
                MateriaActual.HSTotales = int.Parse(txtHSTot.Text);
                MateriaActual.Plan.Id = Convert.ToInt32(cmbIDPlan.SelectedValue);
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                MateriaLogic MateriaLogic = new MateriaLogic();
                if (Modo != ModoForm.Alta || !MateriaLogic.Existe(MateriaActual.Plan.Id, MateriaActual.Descripcion))
                {
                    MateriaLogic.Save(MateriaActual);
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
            Boolean EsValido = true;
            if (cmbIDPlan.SelectedItem == null)
                EsValido = false;
            if (txtDesc.Text == String.Empty || txtHSSem.Text == String.Empty || txtHSTot.Text == String.Empty)
                EsValido = false;
            if (EsValido == false)
                Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return EsValido;
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
