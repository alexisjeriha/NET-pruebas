using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public Usuario UsuarioActual { get; set; }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;

            UsuarioActual = new UsuarioLogic().GetOne(ID);
            MapearDeDatos();



        }
        public override void MapearDeDatos()
        {
            txtID.Text = UsuarioActual.ID.ToString();
            chkHabilitado.Checked = UsuarioActual.Habilitado;
            txtNombre.Text = UsuarioActual.Nombre;
            txtApellido.Text = UsuarioActual.Apellido;
            txtUsuario.Text = UsuarioActual.NombreUsuario;
            txtEMail.Text = UsuarioActual.EMail;

            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual = new Usuario { State = BusinessEntity.States.New };
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;

            }

            if (Modo == ModoForm.Modificacion) { UsuarioActual.ID = int.Parse(txtID.Text); }
            UsuarioActual.Habilitado = chkHabilitado.Checked;
            UsuarioActual.Nombre = txtNombre.Text;
            UsuarioActual.Apellido = txtApellido.Text;
            UsuarioActual.Clave = txtClave.Text;
            UsuarioActual.EMail = txtEMail.Text;
            UsuarioActual.NombreUsuario = txtUsuario.Text;

        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new UsuarioLogic().Save(UsuarioActual);
        }
        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public override bool Validar() //FALTA VALIDAR EMAIL
        {
            bool EsValido = true;
            foreach (Control oControls in this.Controls)
            {
                if (oControls is TextBox && oControls.Text == System.String.Empty && oControls != this.txtID)
                {
                    EsValido = false;
                    break;
                }
            }
            if (EsValido == false)
                this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                EsValido = false;
                this.Notificar("La clave no coincide con la confirmacion de la misma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this.txtClave.Text.Length < 8)
            {
                EsValido = false;
                this.Notificar("La clave debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!IsEmailValid(this.txtEMail.ToString()))
            {
                Notificar("El email no es valido",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                EsValido = false;
            }

            return EsValido;

        }

        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }

        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
