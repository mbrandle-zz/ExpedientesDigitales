namespace ExpedientesDigitales
{
    partial class frmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbReporte = new System.Windows.Forms.CheckBox();
            this.cbAdmin = new System.Windows.Forms.CheckBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbRevision = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbRevision);
            this.groupBox1.Controls.Add(this.cbReporte);
            this.groupBox1.Controls.Add(this.cbAdmin);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbReporte
            // 
            this.cbReporte.AutoSize = true;
            this.cbReporte.Location = new System.Drawing.Point(196, 85);
            this.cbReporte.Name = "cbReporte";
            this.cbReporte.Size = new System.Drawing.Size(84, 20);
            this.cbReporte.TabIndex = 10;
            this.cbReporte.Text = "Reporte";
            this.cbReporte.UseVisualStyleBackColor = true;
            // 
            // cbAdmin
            // 
            this.cbAdmin.AutoSize = true;
            this.cbAdmin.Location = new System.Drawing.Point(28, 85);
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Size = new System.Drawing.Size(125, 20);
            this.cbAdmin.TabIndex = 9;
            this.cbAdmin.Text = "Administrador";
            this.cbAdmin.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(387, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(297, 23);
            this.txtNombre.TabIndex = 8;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(196, 43);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(169, 23);
            this.txtPass.TabIndex = 7;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(28, 43);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(152, 23);
            this.txtUsuario.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre Completo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(161)))), ((int)(((byte)(186)))));
            this.btnGuardar.Location = new System.Drawing.Point(639, 119);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(82, 27);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbRevision
            // 
            this.cbRevision.AutoSize = true;
            this.cbRevision.Location = new System.Drawing.Point(327, 85);
            this.cbRevision.Name = "cbRevision";
            this.cbRevision.Size = new System.Drawing.Size(89, 20);
            this.cbRevision.TabIndex = 11;
            this.cbRevision.Text = "Revisión";
            this.cbRevision.UseVisualStyleBackColor = true;
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(161)))), ((int)(((byte)(186)))));
            this.ClientSize = new System.Drawing.Size(767, 196);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUsuarios";
            this.Text = "Agregar Usuarios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbReporte;
        private System.Windows.Forms.CheckBox cbAdmin;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.CheckBox cbRevision;
    }
}