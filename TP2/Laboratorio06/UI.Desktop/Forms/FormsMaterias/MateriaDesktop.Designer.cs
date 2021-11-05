
namespace UI.Desktop.Forms.FormsMaterias
{
    partial class MateriaDesktop
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblIDMat = new System.Windows.Forms.Label();
            this.lblDescMat = new System.Windows.Forms.Label();
            this.lblHSSem = new System.Windows.Forms.Label();
            this.lblHSTot = new System.Windows.Forms.Label();
            this.lblIDPlan = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtIDEsp = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtHSSem = new System.Windows.Forms.TextBox();
            this.txtHSTot = new System.Windows.Forms.TextBox();
            this.cmbIDPlan = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9629851F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.01234F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.01234F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.01234F));
            this.tableLayoutPanel1.Controls.Add(this.lblIDMat, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDescMat, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHSSem, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblHSTot, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblIDPlan, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtIDEsp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDesc, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtHSSem, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHSTot, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbIDPlan, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(398, 401);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblIDMat
            // 
            this.lblIDMat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIDMat.AutoSize = true;
            this.lblIDMat.Location = new System.Drawing.Point(6, 27);
            this.lblIDMat.Name = "lblIDMat";
            this.lblIDMat.Size = new System.Drawing.Size(105, 17);
            this.lblIDMat.TabIndex = 0;
            this.lblIDMat.Text = "ID Especialidad";
            // 
            // lblDescMat
            // 
            this.lblDescMat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDescMat.AutoSize = true;
            this.lblDescMat.Location = new System.Drawing.Point(6, 91);
            this.lblDescMat.Name = "lblDescMat";
            this.lblDescMat.Size = new System.Drawing.Size(86, 34);
            this.lblDescMat.TabIndex = 1;
            this.lblDescMat.Text = "Descripcion materia";
            // 
            // lblHSSem
            // 
            this.lblHSSem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHSSem.AutoSize = true;
            this.lblHSSem.Location = new System.Drawing.Point(6, 171);
            this.lblHSSem.Name = "lblHSSem";
            this.lblHSSem.Size = new System.Drawing.Size(120, 17);
            this.lblHSSem.TabIndex = 2;
            this.lblHSSem.Text = "Horas Semanales";
            // 
            // lblHSTot
            // 
            this.lblHSTot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHSTot.AutoSize = true;
            this.lblHSTot.Location = new System.Drawing.Point(6, 243);
            this.lblHSTot.Name = "lblHSTot";
            this.lblHSTot.Size = new System.Drawing.Size(97, 17);
            this.lblHSTot.TabIndex = 3;
            this.lblHSTot.Text = "Horas Totales";
            // 
            // lblIDPlan
            // 
            this.lblIDPlan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIDPlan.AutoSize = true;
            this.lblIDPlan.Location = new System.Drawing.Point(6, 315);
            this.lblIDPlan.Name = "lblIDPlan";
            this.lblIDPlan.Size = new System.Drawing.Size(53, 17);
            this.lblIDPlan.TabIndex = 4;
            this.lblIDPlan.Text = "ID Plan";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(157, 369);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(289, 369);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtIDEsp
            // 
            this.txtIDEsp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtIDEsp, 2);
            this.txtIDEsp.Location = new System.Drawing.Point(137, 25);
            this.txtIDEsp.Name = "txtIDEsp";
            this.txtIDEsp.ReadOnly = true;
            this.txtIDEsp.Size = new System.Drawing.Size(258, 22);
            this.txtIDEsp.TabIndex = 7;
            // 
            // txtDesc
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDesc, 2);
            this.txtDesc.Location = new System.Drawing.Point(137, 75);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(258, 66);
            this.txtDesc.TabIndex = 8;
            // 
            // txtHSSem
            // 
            this.txtHSSem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtHSSem, 2);
            this.txtHSSem.Location = new System.Drawing.Point(137, 169);
            this.txtHSSem.Name = "txtHSSem";
            this.txtHSSem.Size = new System.Drawing.Size(258, 22);
            this.txtHSSem.TabIndex = 9;
            // 
            // txtHSTot
            // 
            this.txtHSTot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtHSTot, 2);
            this.txtHSTot.Location = new System.Drawing.Point(137, 241);
            this.txtHSTot.Name = "txtHSTot";
            this.txtHSTot.Size = new System.Drawing.Size(258, 22);
            this.txtHSTot.TabIndex = 10;
            // 
            // cmbIDPlan
            // 
            this.cmbIDPlan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cmbIDPlan, 2);
            this.cmbIDPlan.FormattingEnabled = true;
            this.cmbIDPlan.Location = new System.Drawing.Point(137, 312);
            this.cmbIDPlan.Name = "cmbIDPlan";
            this.cmbIDPlan.Size = new System.Drawing.Size(258, 24);
            this.cmbIDPlan.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 401);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MateriaDesktop";
            this.Text = "MateriaDesktop";
            this.Load += new System.EventHandler(this.MateriaDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblIDMat;
        private System.Windows.Forms.Label lblDescMat;
        private System.Windows.Forms.Label lblHSSem;
        private System.Windows.Forms.Label lblHSTot;
        private System.Windows.Forms.Label lblIDPlan;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtIDEsp;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtHSSem;
        private System.Windows.Forms.TextBox txtHSTot;
        private System.Windows.Forms.ComboBox cmbIDPlan;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}