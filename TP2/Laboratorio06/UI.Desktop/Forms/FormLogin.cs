using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                var usr = new Usuario();
                usr = usuario.GetUsuarioYClave(txtUsuario.Text);

                if (this.txtUsuario.Text == usr.NombreUsuario && this.txtPass.Text == usr.Clave)
                {
                    MessageBox.Show("Usted ha ingresado al sistema correctamente.", "Ingreso");
                    this.DialogResult = DialogResult.OK;
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
    }
}
