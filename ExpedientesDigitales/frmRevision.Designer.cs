namespace ExpedientesDigitales
{
    partial class frmRevision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRevision));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.cbAnos = new System.Windows.Forms.ComboBox();
            this.gbAnos = new System.Windows.Forms.GroupBox();
            this.gbObra = new System.Windows.Forms.GroupBox();
            this.txtObra = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.wbInforme = new System.Windows.Forms.WebBrowser();
            this.gbAnos.SuspendLayout();
            this.gbObra.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(296, 522);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // cbAnos
            // 
            this.cbAnos.FormattingEnabled = true;
            this.cbAnos.Location = new System.Drawing.Point(6, 22);
            this.cbAnos.Name = "cbAnos";
            this.cbAnos.Size = new System.Drawing.Size(246, 24);
            this.cbAnos.TabIndex = 0;
            // 
            // gbAnos
            // 
            this.gbAnos.Controls.Add(this.cbAnos);
            this.gbAnos.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAnos.ForeColor = System.Drawing.Color.White;
            this.gbAnos.Location = new System.Drawing.Point(12, 12);
            this.gbAnos.Name = "gbAnos";
            this.gbAnos.Size = new System.Drawing.Size(258, 55);
            this.gbAnos.TabIndex = 2;
            this.gbAnos.TabStop = false;
            this.gbAnos.Text = "Año";
            // 
            // gbObra
            // 
            this.gbObra.Controls.Add(this.btnAceptar);
            this.gbObra.Controls.Add(this.txtObra);
            this.gbObra.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbObra.ForeColor = System.Drawing.Color.White;
            this.gbObra.Location = new System.Drawing.Point(12, 90);
            this.gbObra.Name = "gbObra";
            this.gbObra.Size = new System.Drawing.Size(258, 92);
            this.gbObra.TabIndex = 3;
            this.gbObra.TabStop = false;
            this.gbObra.Text = "Obra";
            // 
            // txtObra
            // 
            this.txtObra.Location = new System.Drawing.Point(6, 22);
            this.txtObra.Name = "txtObra";
            this.txtObra.Size = new System.Drawing.Size(246, 23);
            this.txtObra.TabIndex = 0;
            this.txtObra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObra_KeyPress);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(161)))), ((int)(((byte)(186)))));
            this.btnAceptar.Location = new System.Drawing.Point(169, 58);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 28);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // wbInforme
            // 
            this.wbInforme.Location = new System.Drawing.Point(302, 0);
            this.wbInforme.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbInforme.Name = "wbInforme";
            this.wbInforme.Size = new System.Drawing.Size(887, 522);
            this.wbInforme.TabIndex = 4;
            // 
            // frmRevision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(161)))), ((int)(((byte)(186)))));
            this.ClientSize = new System.Drawing.Size(1201, 522);
            this.Controls.Add(this.wbInforme);
            this.Controls.Add(this.gbObra);
            this.Controls.Add(this.gbAnos);
            this.Controls.Add(this.splitter1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRevision";
            this.Text = "Revisión de Obras";
            this.gbAnos.ResumeLayout(false);
            this.gbObra.ResumeLayout(false);
            this.gbObra.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox cbAnos;
        private System.Windows.Forms.GroupBox gbAnos;
        private System.Windows.Forms.GroupBox gbObra;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtObra;
        private System.Windows.Forms.WebBrowser wbInforme;
    }
}