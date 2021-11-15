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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            ComisionLogic ul = new ComisionLogic();
            dgvComisiones.DataSource = ul.GetAll();
        }
        private void Comisiones_Load(object sender, EventArgs e)
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
            
            ComisionDesktop ComisionDesktop = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            ComisionDesktop.ShowDialog();
            Listar();
            
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            
            if (dgvComisiones.SelectedRows != null)
            {
                int ID = ((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formComision.ShowDialog();
                Listar();
            }
            
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar la Comision seleccionada?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                try
                {
                    int ID = ((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                    ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formComision.ShowDialog();
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
