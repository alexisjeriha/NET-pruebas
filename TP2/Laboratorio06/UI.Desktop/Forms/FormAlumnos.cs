using System;
using System.Windows.Forms;
using UI.Desktop.Forms.Forms_Especialdades;
using UI.Desktop.Forms.FormsComisiones;
using UI.Desktop.Forms.FormsPersonas;
using UI.Desktop.FormsPlan;
using Business.Entities;

namespace UI.Desktop.Forms
{
    public partial class FormAlumnos : Form
    {
        public FormAlumnos()
        {
            InitializeComponent();
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

        public Usuario Alumno { get; set; }

        private void FormAlumnos_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = string.Format("Bienvenido Alumno: {0}, {1}", Alumno.Persona.Apellido, Alumno.Persona.Nombre);
            lblCarrera.Text = Alumno.Persona.Plan.Especialidad.Descripcion;
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad aún no programada para escritorio. Diríjase a la Página Web. ","Inscripciones no disponibles") ;
        }
    }
}
