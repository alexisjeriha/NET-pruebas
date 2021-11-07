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
using UI.Desktop.Forms.FormsMaterias;

namespace UI.Desktop
{
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            MateriaLogic ul = new MateriaLogic();
            dgvMaterias.DataSource = ul.GetAll();
        }
        private void Materias_Load(object sender, EventArgs e)
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

        private void tsNuevaMat_Click(object sender, EventArgs e)
        {
            MateriaDesktop MateriaDesktop = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            MateriaDesktop.ShowDialog();
            Listar();
        }

        private void tsEditarMat_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows != null)
            {
                int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formPlan = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
                Listar();
            }
        }

        private void tsEliminarMat_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar la Materia seleccionada?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                try
                {
                    int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                    MateriaDesktop formEsp = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formEsp.ShowDialog();
                    Listar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
