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

namespace UI.Desktop.Forms.FormsPersonas
{
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
            dgvPersonas.AutoGenerateColumns = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            dgvPersonas.DataSource = pl.GetAll();
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
