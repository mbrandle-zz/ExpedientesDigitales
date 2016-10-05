namespace ExpedientesDigitales
{
    partial class frmReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporte));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gbAnos = new System.Windows.Forms.GroupBox();
            this.btAceptar = new System.Windows.Forms.Button();
            this.cbAnos = new System.Windows.Forms.ComboBox();
            this.wbReporte = new System.Windows.Forms.WebBrowser();
            this.gbExcel = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.gbAnos.SuspendLayout();
            this.gbExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(287, 605);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // gbAnos
            // 
            this.gbAnos.Controls.Add(this.btAceptar);
            this.gbAnos.Controls.Add(this.cbAnos);
            this.gbAnos.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAnos.ForeColor = System.Drawing.Color.White;
            this.gbAnos.Location = new System.Drawing.Point(12, 12);
            this.gbAnos.Name = "gbAnos";
            this.gbAnos.Size = new System.Drawing.Size(258, 89);
            this.gbAnos.TabIndex = 1;
            this.gbAnos.TabStop = false;
            this.gbAnos.Text = "Año";
            this.gbAnos.Enter += new System.EventHandler(this.gbAnos_Enter);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(161)))), ((int)(((byte)(186)))));
            this.btAceptar.Location = new System.Drawing.Point(177, 52);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 27);
            this.btAceptar.TabIndex = 1;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = false;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // cbAnos
            // 
            this.cbAnos.FormattingEnabled = true;
            this.cbAnos.Location = new System.Drawing.Point(6, 22);
            this.cbAnos.Name = "cbAnos";
            this.cbAnos.Size = new System.Drawing.Size(246, 24);
            this.cbAnos.TabIndex = 0;
            this.cbAnos.SelectedIndexChanged += new System.EventHandler(this.cbAnos_SelectedIndexChanged);
            // 
            // wbReporte
            // 
            this.wbReporte.Location = new System.Drawing.Point(293, 0);
            this.wbReporte.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbReporte.Name = "wbReporte";
            this.wbReporte.Size = new System.Drawing.Size(769, 593);
            this.wbReporte.TabIndex = 2;
            // 
            // gbExcel
            // 
            this.gbExcel.Controls.Add(this.btnExcel);
            this.gbExcel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbExcel.ForeColor = System.Drawing.Color.White;
            this.gbExcel.Location = new System.Drawing.Point(18, 116);
            this.gbExcel.Name = "gbExcel";
            this.gbExcel.Size = new System.Drawing.Size(258, 59);
            this.gbExcel.TabIndex = 2;
            this.gbExcel.TabStop = false;
            this.gbExcel.Text = "Excel";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(161)))), ((int)(((byte)(186)))));
            this.btnExcel.Location = new System.Drawing.Point(122, 22);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(130, 27);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "Generar Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(161)))), ((int)(((byte)(186)))));
            this.ClientSize = new System.Drawing.Size(1074, 605);
            this.Controls.Add(this.gbExcel);
            this.Controls.Add(this.wbReporte);
            this.Controls.Add(this.gbAnos);
            this.Controls.Add(this.splitter1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporte";
            this.Text = "Reporte de Obras";
            this.gbAnos.ResumeLayout(false);
            this.gbExcel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox gbAnos;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.ComboBox cbAnos;
        private System.Windows.Forms.WebBrowser wbReporte;
        private System.Windows.Forms.GroupBox gbExcel;
        private System.Windows.Forms.Button btnExcel;
    }
}