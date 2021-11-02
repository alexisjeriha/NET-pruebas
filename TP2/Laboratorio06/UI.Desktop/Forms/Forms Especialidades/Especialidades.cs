using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.Forms.Forms_Especialdades
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            this.dgvEntidades.AutoGenerateColumns = false;

        }

        private void Especialidades_Load(object sender, EventArgs e)
        {

        }
    }
}
