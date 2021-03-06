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

        class ComboItem
        {
            public int IDTipo { get; set; }
            public string Tipo { get; set; }
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
                cbIdPlan.DisplayMember = "Descripcion";
                cbIdPlan.SelectedIndex = -1;

                cbTipo.DataSource = new ComboItem[]
                {
                    new ComboItem{ IDTipo = 1, Tipo = "Alumno" },
                    new ComboItem{ IDTipo = 2, Tipo = "Docente" },
                };
                cbTipo.ValueMember = "IDTipo";
                cbTipo.DisplayMember = "Tipo";
                cbTipo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            txtID.Text = PersonaActual.ID.ToString();
            txtNombre.Text = PersonaActual.Nombre;
            txtApellido.Text = PersonaActual.Apellido;
            txtDireccion.Text = PersonaActual.Direccion;
            txtEmail.Text = PersonaActual.Email;
            txtTelefono.Text = PersonaActual.Telefono;
            txtLegajo.Text = PersonaActual.Legajo.ToString();
            cbTipo.Text = PersonaActual.Tipo;
            dtNac.Value = PersonaActual.FechaNacimiento;
            cbIdPlan.SelectedValue = PersonaActual.Plan.ID;


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
                    PersonaActual.ID = int.Parse(txtID.Text);
                }

                PersonaActual.Nombre = txtNombre.Text;
                PersonaActual.Apellido = txtApellido.Text;
                PersonaActual.Direccion = txtDireccion.Text;
                PersonaActual.Email = txtEmail.Text;
                PersonaActual.Legajo = int.Parse(txtLegajo.Text);

                PersonaActual.Tipo = cbTipo.SelectedValue.ToString(); //Puede dar error, comprobar
                PersonaActual.FechaNacimiento = dtNac.Value;

                PersonaActual.Telefono = txtTelefono.Text;
                PersonaActual.Plan.ID = Convert.ToInt32(cbIdPlan.SelectedValue);
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

            if (cbIdPlan.SelectedItem == null || txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtDireccion.Text == string.Empty ||
                txtEmail.Text == string.Empty || txtLegajo.Text == string.Empty ||
                cbTipo.SelectedItem == null || dtNac.Value == null || txtTelefono.Text == string.Empty)
            {
                esValido = false;
                this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!(Validaciones.EsMailValido(this.txtEmail.Text)))
            {
                esValido = false;
                this.Notificar("Ingrese un formato válido de email", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
