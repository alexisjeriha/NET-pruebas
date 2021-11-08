using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop.Forms.FormsPersonas
{
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
        }

        public Persona PersonaActual { get; set; }

        public PersonaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            fillCmb();
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PersonaActual = new PersonaLogic().GetOne(ID);
            fillCmb();
            MapearDeDatos();
        }

        private void fillCmb()
        {
            try
            {
                PlanLogic planNegocio = new PlanLogic();
                cbIdPlan.DataSource = planNegocio.GetAll();
                cbIdPlan.ValueMember = "ID";
                cbIdPlan.SelectedIndex = -1;


            }
            catch (Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            txtID.Text = PersonaActual.IdPersona.ToString();
            txtNombre.Text = PersonaActual.Nombre;
            txtApellido.Text = PersonaActual.Apellido;
            txtDireccion.Text = PersonaActual.Direccion;
            txtEmail.Text = PersonaActual.Email;
            txtTelefono.Text = PersonaActual.Telefono;
            txtLegajo.Text = PersonaActual.Legajo.ToString();
            txtTipo.Text = PersonaActual.Tipo.ToString();
            dtNac.Value = PersonaActual.FechaNacimiento;
            cbIdPlan.SelectedValue = PersonaActual.Plan.Id;

            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    PersonaActual = new Persona { State = BusinessEntity.States.New };
                    break;
                case ModoForm.Baja:
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    PersonaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    PersonaActual.State = BusinessEntity.States.Unmodified;
                    break;

            }

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                {
                    PersonaActual.IdPersona = int.Parse(txtID.Text);
                }

                PersonaActual.Nombre = txtNombre.Text;
                PersonaActual.Apellido = txtApellido.Text;
                PersonaActual.Direccion = txtDireccion.Text;
                PersonaActual.Email = txtEmail.Text;
                PersonaActual.Legajo = int.Parse(txtLegajo.Text);
                PersonaActual.Tipo = txtTipo.Text;
                PersonaActual.FechaNacimiento = dtNac.Value;

                PersonaActual.Telefono = txtTelefono.Text;
                PersonaActual.Plan.Id = Convert.ToInt32(cbIdPlan.SelectedValue);
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                PersonaLogic personaLogic = new PersonaLogic();
                if (Modo != ModoForm.Alta || !personaLogic.ExistePersona(PersonaActual))
                {
                    personaLogic.Save(PersonaActual);
                }
                else this.Notificar("Ya existe esta Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            bool esValido = true;

            if (this.cbIdPlan.SelectedItem == null)
            {
                esValido = false;
                this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return esValido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }
    }
}
