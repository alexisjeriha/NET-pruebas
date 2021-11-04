namespace UI.Desktop.FormsPlan
{
    partial class PlanDesktop
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
            this.tcPlanDesktop = new System.Windows.Forms.ToolStripContainer();
            this.tlPlanDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblIDplan = new System.Windows.Forms.Label();
            this.lblDescPlan = new System.Windows.Forms.Label();
            this.lblIdEsp = new System.Windows.Forms.Label();
            this.txtIDplan = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cmbIDEsp = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tcPlanDesktop.ContentPanel.SuspendLayout();
            this.tcPlanDesktop.SuspendLayout();
            this.tlPlanDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPlanDesktop
            // 
            // 
            // tcPlanDesktop.ContentPanel
            // 
            this.tcPlanDesktop.ContentPanel.Controls.Add(this.tlPlanDesktop);
            this.tcPlanDesktop.ContentPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tcPlanDesktop.ContentPanel.Size = new System.Drawing.Size(287, 186);
            this.tcPlanDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPlanDesktop.Location = new System.Drawing.Point(0, 0);
            this.tcPlanDesktop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tcPlanDesktop.Name = "tcPlanDesktop";
            this.tcPlanDesktop.Size = new System.Drawing.Size(287, 206);
            this.tcPlanDesktop.TabIndex = 0;
            this.tcPlanDesktop.Text = "toolStripContainer1";
            // 
            // tlPlanDesktop
            // 
            this.tlPlanDesktop.ColumnCount = 4;
            this.tlPlanDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.432703F));
            this.tlPlanDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.30353F));
            this.tlPlanDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.26377F));
            this.tlPlanDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tlPlanDesktop.Controls.Add(this.lblIDplan, 1, 0);
            this.tlPlanDesktop.Controls.Add(this.lblDescPlan, 1, 1);
            this.tlPlanDesktop.Controls.Add(this.lblIdEsp, 1, 2);
            this.tlPlanDesktop.Controls.Add(this.txtIDplan, 2, 0);
            this.tlPlanDesktop.Controls.Add(this.txtDesc, 2, 1);
            this.tlPlanDesktop.Controls.Add(this.cmbIDEsp, 2, 2);
            this.tlPlanDesktop.Controls.Add(this.btnAceptar, 2, 3);
            this.tlPlanDesktop.Controls.Add(this.btnCancelar, 3, 3);
            this.tlPlanDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPlanDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlPlanDesktop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlPlanDesktop.Name = "tlPlanDesktop";
            this.tlPlanDesktop.RowCount = 4;
            this.tlPlanDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.26689F));
            this.tlPlanDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.2669F));
            this.tlPlanDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.2669F));
            this.tlPlanDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.19931F));
            this.tlPlanDesktop.Size = new System.Drawing.Size(287, 186);
            this.tlPlanDesktop.TabIndex = 0;
            // 
            // lblIDplan
            // 
            this.lblIDplan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIDplan.AutoSize = true;
            this.lblIDplan.Location = new System.Drawing.Point(10, 19);
            this.lblIDplan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIDplan.Name = "lblIDplan";
            this.lblIDplan.Size = new System.Drawing.Size(42, 13);
            this.lblIDplan.TabIndex = 0;
            this.lblIDplan.Text = "ID Plan";
            // 
            // lblDescPlan
            // 
            this.lblDescPlan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDescPlan.AutoSize = true;
            this.lblDescPlan.Location = new System.Drawing.Point(10, 65);
            this.lblDescPlan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescPlan.Name = "lblDescPlan";
            this.lblDescPlan.Size = new System.Drawing.Size(66, 26);
            this.lblDescPlan.TabIndex = 1;
            this.lblDescPlan.Text = "Descripción plan";
            // 
            // lblIdEsp
            // 
            this.lblIdEsp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIdEsp.AutoSize = true;
            this.lblIdEsp.Location = new System.Drawing.Point(10, 123);
            this.lblIdEsp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdEsp.Name = "lblIdEsp";
            this.lblIdEsp.Size = new System.Drawing.Size(81, 13);
            this.lblIdEsp.TabIndex = 2;
            this.lblIdEsp.Text = "Especialidad";
            // 
            // txtIDplan
            // 
            this.txtIDplan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlPlanDesktop.SetColumnSpan(this.txtIDplan, 2);
            this.txtIDplan.Location = new System.Drawing.Point(99, 16);
            this.txtIDplan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIDplan.Name = "txtIDplan";
            this.txtIDplan.ReadOnly = true;
            this.txtIDplan.Size = new System.Drawing.Size(185, 20);
            this.txtIDplan.TabIndex = 3;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlPlanDesktop.SetColumnSpan(this.txtDesc, 2);
            this.txtDesc.Location = new System.Drawing.Point(99, 68);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(185, 20);
            this.txtDesc.TabIndex = 4;
            // 
            // cmbIDEsp
            // 
            this.cmbIDEsp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlPlanDesktop.SetColumnSpan(this.cmbIDEsp, 2);
            this.cmbIDEsp.FormattingEnabled = true;
            this.cmbIDEsp.Location = new System.Drawing.Point(99, 119);
            this.cmbIDEsp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbIDEsp.Name = "cmbIDEsp";
            this.cmbIDEsp.Size = new System.Drawing.Size(185, 21);
            this.cmbIDEsp.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(117, 161);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(56, 19);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(208, 161);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(64, 19);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // PlanDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 206);
            this.Controls.Add(this.tcPlanDesktop);
            this.Name = "PlanDesktop";
            this.Text = "PlanDesktop";
            this.Load += new System.EventHandler(this.PlanDesktop_Load);
            this.tcPlanDesktop.ContentPanel.ResumeLayout(false);
            this.tcPlanDesktop.ResumeLayout(false);
            this.tcPlanDesktop.PerformLayout();
            this.tlPlanDesktop.ResumeLayout(false);
            this.tlPlanDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcPlanDesktop;
        private System.Windows.Forms.TableLayoutPanel tlPlanDesktop;
        private System.Windows.Forms.Label lblIDplan;
        private System.Windows.Forms.Label lblDescPlan;
        private System.Windows.Forms.Label lblIdEsp;
        private System.Windows.Forms.TextBox txtIDplan;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.ComboBox cmbIDEsp;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}