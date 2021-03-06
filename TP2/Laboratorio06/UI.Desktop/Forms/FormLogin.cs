using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;
using UI.Desktop.Forms;

namespace UI.Desktop
{
    public partial class FormLogin : Form
    {
        private UsuarioLogic usuario;
        public FormLogin()
        {
            InitializeComponent();
            usuario = new UsuarioLogic();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usr = usuario.GetUsuarioForLogin(txtUsuario.Text, txtPass.Text);

                if (usr.ID != 0)
                {
                    MessageBox.Show("Usted ha ingresado al sistema correctamente.", "Ingreso");
                    DialogResult = DialogResult.OK;
                    txtPass.Text = String.Empty;
                    switch (usr.Persona.Tipo)
                    {
                        case "Alumno":
                            FormAlumnos formAlumnos = new FormAlumnos();
                            formAlumnos.Alumno = usr;
                            formAlumnos.ShowDialog();
                            break;
                        case "Docente":
         
                            formDocentes formDocentes = new formDocentes();
                            formDocentes.Docente = usr;
                            formDocentes.ShowDialog();
                            break;

                        default:
                            break;
                    }


                }

                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud.un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
