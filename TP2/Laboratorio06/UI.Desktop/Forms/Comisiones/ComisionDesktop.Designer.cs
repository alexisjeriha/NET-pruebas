
namespace UI.Desktop.Forms.FormsComisiones
{
    partial class ComisionDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtIdComision = new System.Windows.Forms.TextBox();
            this.txtDescComision = new System.Windows.Forms.TextBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.cbIdPlan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel1.Controls.Add(this.txtIdComision, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescComision, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAnio, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbIdPlan, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 236);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtIdComision
            // 
            this.txtIdComision.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIdComision.Location = new System.Drawing.Point(169, 11);
            this.txtIdComision.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdComision.Name = "txtIdComision";
            this.txtIdComision.ReadOnly = true;
            this.txtIdComision.Size = new System.Drawing.Size(129, 22);
            this.txtIdComision.TabIndex = 0;
            // 
            // txtDescComision
            // 
            this.txtDescComision.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescComision, 2);
            this.txtDescComision.Location = new System.Drawing.Point(169, 55);
            this.txtDescComision.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescComision.Name = "txtDescComision";
            this.txtDescComision.Size = new System.Drawing.Size(269, 22);
            this.txtDescComision.TabIndex = 1;
            // 
            // txtAnio
            // 
            this.txtAnio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAnio.Location = new System.Drawing.Point(169, 99);
            this.txtAnio.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(129, 22);
            this.txtAnio.TabIndex = 2;
            // 
            // cbIdPlan
            // 
            this.cbIdPlan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbIdPlan.FormattingEnabled = true;
            this.cbIdPlan.Location = new System.Drawing.Point(169, 141);
            this.cbIdPlan.Margin = new System.Windows.Forms.Padding(4);
            this.cbIdPlan.Name = "cbIdPlan";
            this.cbIdPlan.Size = new System.Drawing.Size(129, 24);
            this.cbIdPlan.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Comision ID";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Año";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 145);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Plan";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(169, 180);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(130, 52);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(307, 180);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 52);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // ComisionDesktop
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(444, 236);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ComisionDesktop";
            this.Text = "ComisionDesktop";
            this.Load += new System.EventHandler(this.ComisionDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtIdComision;
        private System.Windows.Forms.TextBox txtDescComision;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.ComboBox cbIdPlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}