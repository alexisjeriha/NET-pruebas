using System;
using Business.Entities;
using Business.Logic;
using System.Windows.Forms;

namespace UI.Desktop.Forms.Forms_Especialidades
{
    public partial class EspecialidadesForm : ApplicationForm
    {
        public EspecialidadesForm()
        {
            InitializeComponent();
        }
        public Especialidad espActual { get; set; }
        private void EspecialidadesForm_Load(object sender, EventArgs e)
        {

        }

        public EspecialidadesForm(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public EspecialidadesForm(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            espActual = new EspecialidadLogic().GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            tbID.Text = espActual.ID.ToString();
            tbDescripcion.Text = espActual.Descripcion;

            switch (Modo)
            {
                case ModoForm.Alta:
                    lblModo.Text = "Nueva Especialidad";
                    break;
                case ModoForm.Modificacion:
                    lblModo.Text = "Modificar Especialidad";
                    break;
                case ModoForm.Baja:
                    lblModo.Text = "Eliminar Especialidad";
                    break;
                case ModoForm.Consulta:
                    lblModo.Text = "Especialidad";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    espActual = new Especialidad { State = BusinessEntity.States.New };
                    break;
                case ModoForm.Baja:
                    espActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    espActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    espActual.State = BusinessEntity.States.Unmodified;
                    break;

            }

            if (Modo == ModoForm.Modificacion) { espActual.ID = int.Parse(tbID.Text); }
            espActual.Descripcion = tbDescripcion.Text;
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new EspecialidadLogic().Save(espActual);
        }

        public override bool Validar()
        {
            bool EsValido = true;
            foreach (Control oControls in Controls)
            {
                if (oControls is TextBox && oControls.Text == String.Empty && oControls != tbID)
                {
                    EsValido = false;
                    break;
                }
            }
            if (EsValido == false)
                Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return EsValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
