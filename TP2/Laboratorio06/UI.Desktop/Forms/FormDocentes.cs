using System;
using System.Windows.Forms;
using UI.Desktop.Forms.Forms_Especialdades;
using UI.Desktop.Forms.FormsComisiones;
using UI.Desktop.Forms.FormsPersonas;
using UI.Desktop.FormsPlan;
using Business.Entities;

namespace UI.Desktop.Forms
{
    public partial class formDocentes : Form
    {
        public formDocentes()
        {
          
            InitializeComponent();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Personas formpersona = new Personas();
            formpersona.ShowDialog();
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones grilla = new Comisiones();
            grilla.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias grilla = new Materias();
            grilla.ShowDialog();
        }

        public Usuario Docente { get; set; }
        private void formDocentes_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = string.Format("Bienvenido Docente: {0}, {1}",Docente.Persona.Apellido,Docente.Persona.Nombre);
        }
    }
}
