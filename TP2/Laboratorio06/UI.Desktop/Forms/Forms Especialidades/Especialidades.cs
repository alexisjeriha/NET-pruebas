using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;
using UI.Desktop.Forms.Forms_Especialidades;

namespace UI.Desktop.Forms.Forms_Especialdades
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;

        }
        public void Listar()
        {
            EspecialidadLogic esp = new EspecialidadLogic();
            dgvEspecialidades.DataSource = esp.GetAll();
        }
        private void Especialidades_Load(object sender, EventArgs e)
        {
            Listar();
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

            EspecialidadDesktop formEsp = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formEsp.ShowDialog();
            Listar();

        }

        

        private void tsbEliminar_Click(object sender, EventArgs e)
        {

            int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).Id;
            EspecialidadDesktop formEsp = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
            formEsp.ShowDialog();
            Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            int ID = ((Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).Id;
            EspecialidadDesktop formEsp = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formEsp.ShowDialog();
            Listar();

        }
    }
}
