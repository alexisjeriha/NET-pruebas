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
        public override bool Validar()
        {
            bool EsValido = true;
            foreach (Control oControls in Controls)
            {
                if (oControls is TextBox && oControls.Text == String.Empty && oControls != txtID)
                {
                    EsValido = false;
                    break;
                }
            }
            if (EsValido == false)
                Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (txtClave.Text != txtConfirmarClave.Text)
            {
                EsValido = false;
                Notificar("La clave no coincide con la confirmacion de la misma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtClave.Text.Length < 8)
            {
                EsValido = false;
                Notificar("La clave debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
