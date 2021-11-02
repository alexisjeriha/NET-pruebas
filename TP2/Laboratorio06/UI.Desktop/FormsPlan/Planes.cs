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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            PlanLogic ul = new PlanLogic();
            dgvPlanes.DataSource = ul.GetAll();
        }

        private void Planes_Load(object sender, EventArgs e)
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
            PlanDesktop PlanDesktop = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            PlanDesktop.ShowDialog();
            Listar();
        }
    }
}
