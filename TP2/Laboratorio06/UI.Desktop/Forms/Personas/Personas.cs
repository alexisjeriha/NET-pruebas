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

namespace UI.Desktop.Forms.FormsPersonas
{
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
            dgvPersonas.AutoGenerateColumns = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

            public void Listar(string tipo)
            {
                    PersonaLogic pl = new PersonaLogic();
                    if (tipo == "Todos")
                        dgvPersonas.DataSource = pl.GetAll();
                    else if (tipo == "Alumnos")
                        dgvPersonas.DataSource = pl.GetAlumnos();
                    else if (tipo == "Docentes")
                        dgvPersonas.DataSource = pl.GetDocentes();
            }
        

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar("Todos");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar("Todos");
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            PersonaDesktop personaDesktop = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            personaDesktop.ShowDialog();
            Listar("Todos");
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.SelectedRows != null)
            {
            
                int ID = ((Persona)dgvPersonas.SelectedRows[0].DataBoundItem).IdPersona;
                PersonaDesktop formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPersona.ShowDialog();

                Listar("Todos");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar el Plan seleccionado?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                try
                {
                    int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).IdPersona;
                    PersonaDesktop formPer = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formPer.ShowDialog();
                    Listar("Todos");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listar("Todos");
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listar("Alumnos");
        }

        private void docentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listar("Docentes");
        }
    }
}
