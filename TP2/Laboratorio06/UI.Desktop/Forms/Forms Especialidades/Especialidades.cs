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
using UI.Desktop.Forms.Forms_Especialidades;

namespace UI.Desktop.Forms.Forms_Especialdades
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;

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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            
            EspecialidadesForm formEsp = new EspecialidadesForm(ApplicationForm.ModoForm.Alta);
            formEsp.ShowDialog();
            Listar();
            
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            
            int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).Id;
            EspecialidadesForm formEsp = new EspecialidadesForm(ID, ApplicationForm.ModoForm.Modificacion);
            formEsp.ShowDialog();
            Listar();
            
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            
            int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).Id;
            EspecialidadesForm formEsp = new EspecialidadesForm(ID, ApplicationForm.ModoForm.Baja);
            formEsp.ShowDialog();
            Listar();
            
        }
    }
}
