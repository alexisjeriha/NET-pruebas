
namespace UI.Desktop.Forms.FormsPersonas
{
    partial class Personas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Personas));
            this.tcPersonas = new System.Windows.Forms.ToolStripContainer();
            this.tlPersonas = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.tsPersonas = new System.Windows.Forms.ToolStrip();
            this.tbAgregar = new System.Windows.Forms.ToolStripButton();
            this.tbEditar = new System.Windows.Forms.ToolStripButton();
            this.tbEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.IdPers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombrePersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LegajoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcPersonas.ContentPanel.SuspendLayout();
            this.tcPersonas.TopToolStripPanel.SuspendLayout();
            this.tcPersonas.SuspendLayout();
            this.tlPersonas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.tsPersonas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPersonas
            // 
            // 
            // tcPersonas.ContentPanel
            // 
            this.tcPersonas.ContentPanel.Controls.Add(this.tlPersonas);
            this.tcPersonas.ContentPanel.Size = new System.Drawing.Size(948, 540);
            this.tcPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPersonas.Location = new System.Drawing.Point(0, 0);
            this.tcPersonas.Name = "tcPersonas";
            this.tcPersonas.Size = new System.Drawing.Size(948, 565);
            this.tcPersonas.TabIndex = 0;
            this.tcPersonas.Text = "toolStripContainer1";
            // 
            // tcPersonas.TopToolStripPanel
            // 
            this.tcPersonas.TopToolStripPanel.Controls.Add(this.tsPersonas);
            // 
            // tlPersonas
            // 
            this.tlPersonas.ColumnCount = 2;
            this.tlPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tlPersonas.Controls.Add(this.dgvPersonas, 0, 0);
            this.tlPersonas.Controls.Add(this.btnSalir, 1, 1);
            this.tlPersonas.Controls.Add(this.btnActualizar, 0, 1);
            this.tlPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPersonas.Location = new System.Drawing.Point(0, 0);
            this.tlPersonas.Name = "tlPersonas";
            this.tlPersonas.RowCount = 2;
            this.tlPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.85185F));
            this.tlPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.148149F));
            this.tlPersonas.Size = new System.Drawing.Size(948, 540);
            this.tlPersonas.TabIndex = 0;
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPers,
            this.NombrePersona,
            this.ApellidoPersona,
            this.EmailPersona,
            this.TelefonoPersona,
            this.FechaNacimiento,
            this.LegajoPersona,
            this.TipoPersona,
            this.IDPlan});
            this.tlPersonas.SetColumnSpan(this.dgvPersonas, 2);
            this.dgvPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonas.Location = new System.Drawing.Point(3, 3);
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.Size = new System.Drawing.Size(942, 490);
            this.dgvPersonas.TabIndex = 0;
            // 
            // tsPersonas
            // 
            this.tsPersonas.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPersonas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAgregar,
            this.tbEditar,
            this.tbEliminar});
            this.tsPersonas.Location = new System.Drawing.Point(3, 0);
            this.tsPersonas.Name = "tsPersonas";
            this.tsPersonas.Size = new System.Drawing.Size(81, 25);
            this.tsPersonas.TabIndex = 0;
            // 
            // tbAgregar
            // 
            this.tbAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAgregar.Image = ((System.Drawing.Image)(resources.GetObject("tbAgregar.Image")));
            this.tbAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAgregar.Name = "tbAgregar";
            this.tbAgregar.Size = new System.Drawing.Size(23, 22);
            this.tbAgregar.Text = "Agregar Persona";
            // 
            // tbEditar
            // 
            this.tbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tbEditar.Image")));
            this.tbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbEditar.Name = "tbEditar";
            this.tbEditar.Size = new System.Drawing.Size(23, 22);
            this.tbEditar.Text = "Editar Persona";
            // 
            // tbEliminar
            // 
            this.tbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tbEliminar.Image")));
            this.tbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbEliminar.Name = "tbEliminar";
            this.tbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tbEliminar.Text = "Eliminar Persona";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSalir.Location = new System.Drawing.Point(851, 503);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(91, 29);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizar.Location = new System.Drawing.Point(751, 503);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(91, 29);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // IdPers
            // 
            this.IdPers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdPers.DataPropertyName = "IdPersona";
            this.IdPers.HeaderText = "ID";
            this.IdPers.Name = "IdPers";
            // 
            // NombrePersona
            // 
            this.NombrePersona.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombrePersona.DataPropertyName = "Nombre";
            this.NombrePersona.HeaderText = "Nombre";
            this.NombrePersona.Name = "NombrePersona";
            // 
            // ApellidoPersona
            // 
            this.ApellidoPersona.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ApellidoPersona.DataPropertyName = "Apellido";
            this.ApellidoPersona.HeaderText = "Apellido";
            this.ApellidoPersona.Name = "ApellidoPersona";
            // 
            // EmailPersona
            // 
            this.EmailPersona.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EmailPersona.DataPropertyName = "Email";
            this.EmailPersona.HeaderText = "Email";
            this.EmailPersona.Name = "EmailPersona";
            this.EmailPersona.ReadOnly = true;
            // 
            // TelefonoPersona
            // 
            this.TelefonoPersona.DataPropertyName = "Telefono";
            this.TelefonoPersona.HeaderText = "Telefono";
            this.TelefonoPersona.Name = "TelefonoPersona";
            this.TelefonoPersona.ReadOnly = true;
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.DataPropertyName = "FechaNacimiento";
            this.FechaNacimiento.HeaderText = "Fecha de nacimiento";
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.ReadOnly = true;
            // 
            // LegajoPersona
            // 
            this.LegajoPersona.DataPropertyName = "Legajo";
            this.LegajoPersona.HeaderText = "Legajo";
            this.LegajoPersona.Name = "LegajoPersona";
            this.LegajoPersona.ReadOnly = true;
            // 
            // TipoPersona
            // 
            this.TipoPersona.DataPropertyName = "Tipo";
            this.TipoPersona.HeaderText = "Tipo";
            this.TipoPersona.Name = "TipoPersona";
            this.TipoPersona.ReadOnly = true;
            // 
            // IDPlan
            // 
            this.IDPlan.DataPropertyName = "IDPlan";
            this.IDPlan.HeaderText = "ID Plan";
            this.IDPlan.Name = "IDPlan";
            this.IDPlan.ReadOnly = true;
            // 
            // Personas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 565);
            this.Controls.Add(this.tcPersonas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Personas";
            this.Text = "Personas";
            this.Load += new System.EventHandler(this.Personas_Load);
            this.tcPersonas.ContentPanel.ResumeLayout(false);
            this.tcPersonas.TopToolStripPanel.ResumeLayout(false);
            this.tcPersonas.TopToolStripPanel.PerformLayout();
            this.tcPersonas.ResumeLayout(false);
            this.tcPersonas.PerformLayout();
            this.tlPersonas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.tsPersonas.ResumeLayout(false);
            this.tsPersonas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcPersonas;
        private System.Windows.Forms.TableLayoutPanel tlPersonas;
        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.ToolStrip tsPersonas;
        private System.Windows.Forms.ToolStripButton tbAgregar;
        private System.Windows.Forms.ToolStripButton tbEditar;
        private System.Windows.Forms.ToolStripButton tbEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPers;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombrePersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn LegajoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPlan;
    }
}