using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Principal;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ExpedientesDigitales
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            cbAdmin.Checked = false;
            cbReporte.Checked = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool blAdmin = false;
            bool blReporte = false;
            bool campos = true;
            bool blrevision = false;

            if (cbAdmin.Checked)
            {
                blAdmin = true;
            }
            if (cbReporte.Checked)
            {
                blReporte = true;
            }
            if (cbRevision.Checked)
            {
                blrevision = true;
            }

            if(txtNombre.Text.Equals(""))
            {
                campos = false;
            }
            if (txtPass.Text.Equals(""))
            {
                campos = false;
            }
            if (txtUsuario.Text.Equals(""))
            {
                campos = false;
            }

            if (campos)
            {

                try
                {
                    Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;
                    String host = confCollection["host"].Value.ToString();
                    String usuario = confCollection["usuario"].Value.ToString();
                    String password = confCollection["password"].Value.ToString();
                    String catalogo = confCollection["catalog"].Value.ToString();
                    string conString = "Data Source=" + host + "; Initial Catalog=" + catalogo + ";User ID=" + usuario + ";Password=" + password + "";
                    SqlConnection conn = new SqlConnection(conString);
                    SqlCommand cmdUsuarios = new SqlCommand();
                    cmdUsuarios.CommandText = "insert into usuarios (Usuario,Nombre,Password,Activo,Administrador,Reporte,Revision) values (@usuario,@nombre,@pass,@activo,@admin,@reporte,@revision)";
                    cmdUsuarios.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmdUsuarios.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmdUsuarios.Parameters.AddWithValue("@pass", txtPass.Text);
                    cmdUsuarios.Parameters.AddWithValue("@activo", true);
                    cmdUsuarios.Parameters.AddWithValue("@admin", blAdmin);
                    cmdUsuarios.Parameters.AddWithValue("@reporte", blReporte);
                    cmdUsuarios.Parameters.AddWithValue("@revision", blrevision);
                    cmdUsuarios.Connection = conn;
                    conn.Open();
                    cmdUsuarios.ExecuteNonQuery();
                    conn.Close();


                    txtUsuario.Text = "";
                    txtPass.Text = "";
                    txtNombre.Text = "";
                    cbAdmin.Checked = false;
                    cbReporte.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "ERROR");
                }
            }
            else
            {
                MessageBox.Show("Error: Los Campos Nombre, Usuario y Password Deben Estar Llenos", "ERROR");
            }
        }
    }
}
