using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ExpedientesDigitales
{
    public partial class frmCrearCarpetas : Form
    {
        public frmCrearCarpetas()
        {
            InitializeComponent();
            CargarAnos();
        }


        public void CargarAnos()
        {
            cbAnos.Items.Clear();
            cbAnos.Items.Add("-- Seleccione Año --");
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
                SqlCommand cmdAnos = new SqlCommand();
                cmdAnos.Connection = conn;
                cmdAnos.CommandText = "select distinct ano from obras order by ano asc";
                conn.Open();

                SqlDataReader rdrAnos = cmdAnos.ExecuteReader();
                while (rdrAnos.Read())
                {
                    cbAnos.Items.Add(rdrAnos.GetInt32(0).ToString());
                }
                rdrAnos.Close();
                conn.Close();
                cbAnos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
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
                SqlCommand cmdObras = new SqlCommand();
                cmdObras.Connection = conn;
                cmdObras.CommandText = "select NoObra from obras where Ano=@ano";
                cmdObras.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                conn.Open();

                SqlDataReader rdrObras = cmdObras.ExecuteReader();
                string path = @"C:\GeneradorCarpetas\" + cbAnos.Text.ToString() + @"\GI";
                while (rdrObras.Read())
                {

                    string pathString = System.IO.Path.Combine(path, rdrObras.GetString(0));
                    System.IO.Directory.CreateDirectory(pathString);
                }
                rdrObras.Close();
                conn.Close();
                MessageBox.Show("Proceso Terminado", "Aviso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR");
            }
        }
    }
}
