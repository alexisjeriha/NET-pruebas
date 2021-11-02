using System;
using System.Windows.Forms;
using UI.Desktop.Forms.Forms_Especialdades;
using UI.Desktop.FormsPlan;

namespace UI.Desktop.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            FormLogin appLogin = new FormLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {

                this.Dispose();

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios grilla = new Usuarios();
            grilla.ShowDialog();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades grilla = new Especialidades();
            grilla.ShowDialog();
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            Planes grillaplanes = new Planes();
            grillaplanes.ShowDialog();
        }
    }
}
