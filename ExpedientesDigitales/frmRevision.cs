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
using Microsoft.Office.Interop;
using ExpedientesDigitales.Classes;

namespace ExpedientesDigitales
{
    public partial class frmRevision : Form
    {
        public frmRevision()
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
             Informe();
        }

        public void Informe()
        {
            try
            {
                if (cbAnos.SelectedIndex != 0)
                {
                    String consulta = "";
                    if (txtObra.Text.Equals(""))
                    {
                        consulta = "select distinct(e.TipoDocumento),e.NumeroObra,e.Ano,u.nombre " +
                            "from expedientes e inner join usuarios u on e.Usuario=u.Usuario " +
                            "where e.ano=" + cbAnos.Text + " order by e.NumeroObra";
                    }
                    else
                    {
                        consulta = "select distinct(e.TipoDocumento),e.NumeroObra,e.Ano,u.nombre " +
                            "from expedientes e inner join usuarios u on e.Usuario=u.Usuario " +
                            "where e.ano=" + cbAnos.Text + " and e.numeroObra=" + txtObra.Text + " order by e.numeroobra";
                    }

                    String strTabla = "<html><head><title></title></head><body bgcolor='#3da1ba'><p>" +
                        "<table border='1'celpadding='10%' bordercolor='Gainsboro' bgcolor='FFFFFF'  style='color:#000'><tr align='center'><td><strong>OBRA</strong></td><td><strong>Tipo Documento</strong></td><td><strong>Año</strong></td><td><strong>Usuario</strong></td><td><strong>Ubicación</strong></td></tr>";

                    Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

                    String dominio = confCollection["dominio"].Value.ToString();
                    String ruta = confCollection["ruta"].Value.ToString();
                    String usuarioRed = confCollection["usuarioRed"].Value.ToString();
                    String passwordRed = confCollection["passwordRed"].Value.ToString();

                    String host = confCollection["host"].Value.ToString();
                    String usuario = confCollection["usuario"].Value.ToString();
                    String password = confCollection["password"].Value.ToString();
                    String catalogo = confCollection["catalog"].Value.ToString();
                    string conString = "Data Source=" + host + "; Initial Catalog=" + catalogo + ";User ID=" + usuario + ";Password=" + password + "";

                    SqlConnection conn = new SqlConnection(conString);
                    SqlCommand cmdExpedientes = new SqlCommand();
                    cmdExpedientes.Connection = conn;
                    cmdExpedientes.CommandText = consulta;
                    conn.Open();
                    SqlDataReader rdrExpedientes = cmdExpedientes.ExecuteReader();
                    while (rdrExpedientes.Read())
                    {
                        String strBloque = "<tr style='width=100%' align='center'><td><strong>" + rdrExpedientes.GetString(1) + "</strong></td>" +
                            "<td>" + rdrExpedientes.GetString(0) + "</td><td>" + rdrExpedientes.GetInt32(2) + "</td><td>" + rdrExpedientes.GetString(3) + "</td>" +
                            "<td><a href='" + ruta + cbAnos.Text + "\\GI\\" + rdrExpedientes.GetString(1) + "\\' target='_blank'>Abrir</a></tr>";
                        strTabla = strTabla + strBloque;
                    }
                    rdrExpedientes.Close();
                    conn.Close();
                    strTabla = strTabla + "</table></p></body></html>";
                    wbInforme.DocumentText = strTabla;
                }
                else
                {
                    MessageBox.Show("Error: No Se Selecciono Año", "ERROR");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR");
            }
        }

        private void txtObra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                Informe();
            }
        }
    }
}
