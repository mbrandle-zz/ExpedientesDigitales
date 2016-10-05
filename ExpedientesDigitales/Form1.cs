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

namespace ExpedientesDigitales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            IniciarSesion();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                IniciarSesion();
            }
        }

        public void IniciarSesion()
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
                SqlCommand cmdLogin = new SqlCommand();
                cmdLogin.Connection = conn;
                cmdLogin.CommandText = "select * from usuarios where Usuario=@usuario and Password=@psw and activo=1";
                cmdLogin.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmdLogin.Parameters.AddWithValue("@psw", txtPassword.Text);
                conn.Open();

                SqlDataReader rdrLogin = cmdLogin.ExecuteReader();
                if (rdrLogin.Read())
                {
                    this.Hide();
                    frmPrincipal frPpal = new frmPrincipal(txtUsuario.Text,rdrLogin.GetBoolean(5),rdrLogin.GetBoolean(6),rdrLogin.GetBoolean(7));
                    frPpal.Show();
                }
                else
                {
                    MessageBox.Show("Datos Incorrectos O Usuario Inactivo.  ", "Error De Autenticación");
                }
                rdrLogin.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR");
            }
        }
    }
}
