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
    public partial class frmCargarObras : Form
    {
        public frmCargarObras()
        {
            InitializeComponent();
        }

        private void frmCargarObras_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

                if (cbA.Checked)
                {
                    SqlCommand cmdExpediente = new SqlCommand();
                    cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido,Ano) values(@obra,'x',@tipo,'Mario',getdate(),@ano);";
                    cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                    cmdExpediente.Parameters.AddWithValue("@tipo", "A");
                    cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                    cmdExpediente.Connection = conn;
                    conn.Open();
                    cmdExpediente.ExecuteNonQuery();
                    conn.Close();
                }
                if (cbB.Checked)
                {
                    SqlCommand cmdExpediente = new SqlCommand();
                    cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido,Ano) values(@obra,'x',@tipo,'Mario',getdate(),@ano);";
                    cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                    cmdExpediente.Parameters.AddWithValue("@tipo", "B");
                    cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                    cmdExpediente.Connection = conn;
                    conn.Open();
                    cmdExpediente.ExecuteNonQuery();
                    conn.Close();
                }
                if (cbC.Checked)
                {
                    SqlCommand cmdExpediente = new SqlCommand();
                    cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido,Ano) values(@obra,'x',@tipo,'Mario',getdate(),@ano);";
                    cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                    cmdExpediente.Parameters.AddWithValue("@tipo", "C");
                    cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                    cmdExpediente.Connection = conn;
                    conn.Open();
                    cmdExpediente.ExecuteNonQuery();
                    conn.Close();
                }
                if (cbD.Checked)
                {
                    SqlCommand cmdExpediente = new SqlCommand();
                    cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                    cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                    cmdExpediente.Parameters.AddWithValue("@tipo", "D");
                    cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                    cmdExpediente.Connection = conn;
                    conn.Open();
                    cmdExpediente.ExecuteNonQuery();
                    conn.Close();
                }
                if (cbF.Checked)
                {
                    SqlCommand cmdExpediente = new SqlCommand();
                    cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                    cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                    cmdExpediente.Parameters.AddWithValue("@tipo", "F");
                    cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                    cmdExpediente.Connection = conn;
                    conn.Open();
                    cmdExpediente.ExecuteNonQuery();
                    conn.Close();
                }
                if (cbE.Checked)
                {
                    SqlCommand cmdExpediente = new SqlCommand();
                    cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                    cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                    cmdExpediente.Parameters.AddWithValue("@tipo", "E");
                    cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                    cmdExpediente.Connection = conn;
                    conn.Open();
                    cmdExpediente.ExecuteNonQuery();
                    conn.Close();
                }
                if (cbG.Checked)
                {
                    SqlCommand cmdExpediente = new SqlCommand();
                    cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                    cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                    cmdExpediente.Parameters.AddWithValue("@tipo", "G");
                    cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                    cmdExpediente.Connection = conn;
                    conn.Open();
                    cmdExpediente.ExecuteNonQuery();
                    conn.Close();
                }
                if (cbH.Checked)
                {
                    SqlCommand cmdExpediente = new SqlCommand();
                    cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                    cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                    cmdExpediente.Parameters.AddWithValue("@tipo", "H");
                    cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                    cmdExpediente.Connection = conn;
                    conn.Open();
                    cmdExpediente.ExecuteNonQuery();
                    conn.Close();
                }
                if (cbM.Checked)
                {
                    SqlCommand cmdExpediente = new SqlCommand();
                    cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                    cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                    cmdExpediente.Parameters.AddWithValue("@tipo", "M");
                    cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                    cmdExpediente.Connection = conn;
                    conn.Open();
                    cmdExpediente.ExecuteNonQuery();
                    conn.Close();
                }
                if (cbP.Checked)
                {
                    SqlCommand cmdExpediente = new SqlCommand();
                    cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                    cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                    cmdExpediente.Parameters.AddWithValue("@tipo", "P");
                    cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                    cmdExpediente.Connection = conn;
                    conn.Open();
                    cmdExpediente.ExecuteNonQuery();
                    conn.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR");
            }
            txtObra.Text = "";


        }

        private void txtObra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
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

                    if (cbA.Checked)
                    {
                        SqlCommand cmdExpediente = new SqlCommand();
                        cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido,Ano) values(@obra,'x',@tipo,'Mario',getdate(),@ano);";
                        cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                        cmdExpediente.Parameters.AddWithValue("@tipo", "A");
                        cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                        cmdExpediente.Connection = conn;
                        conn.Open();
                        cmdExpediente.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (cbB.Checked)
                    {
                        SqlCommand cmdExpediente = new SqlCommand();
                        cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido,Ano) values(@obra,'x',@tipo,'Mario',getdate(),@ano);";
                        cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                        cmdExpediente.Parameters.AddWithValue("@tipo", "B");
                        cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                        cmdExpediente.Connection = conn;
                        conn.Open();
                        cmdExpediente.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (cbC.Checked)
                    {
                        SqlCommand cmdExpediente = new SqlCommand();
                        cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido,Ano) values(@obra,'x',@tipo,'Mario',getdate(),@ano);";
                        cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                        cmdExpediente.Parameters.AddWithValue("@tipo", "C");
                        cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                        cmdExpediente.Connection = conn;
                        conn.Open();
                        cmdExpediente.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (cbD.Checked)
                    {
                        SqlCommand cmdExpediente = new SqlCommand();
                        cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                        cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                        cmdExpediente.Parameters.AddWithValue("@tipo", "D");
                        cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                        cmdExpediente.Connection = conn;
                        conn.Open();
                        cmdExpediente.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (cbF.Checked)
                    {
                        SqlCommand cmdExpediente = new SqlCommand();
                        cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                        cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                        cmdExpediente.Parameters.AddWithValue("@tipo", "F");
                        cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                        cmdExpediente.Connection = conn;
                        conn.Open();
                        cmdExpediente.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (cbE.Checked)
                    {
                        SqlCommand cmdExpediente = new SqlCommand();
                        cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                        cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                        cmdExpediente.Parameters.AddWithValue("@tipo", "E");
                        cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                        cmdExpediente.Connection = conn;
                        conn.Open();
                        cmdExpediente.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (cbG.Checked)
                    {
                        SqlCommand cmdExpediente = new SqlCommand();
                        cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                        cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                        cmdExpediente.Parameters.AddWithValue("@tipo", "G");
                        cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                        cmdExpediente.Connection = conn;
                        conn.Open();
                        cmdExpediente.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (cbH.Checked)
                    {
                        SqlCommand cmdExpediente = new SqlCommand();
                        cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                        cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                        cmdExpediente.Parameters.AddWithValue("@tipo", "H");
                        cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                        cmdExpediente.Connection = conn;
                        conn.Open();
                        cmdExpediente.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (cbM.Checked)
                    {
                        SqlCommand cmdExpediente = new SqlCommand();
                        cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                        cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                        cmdExpediente.Parameters.AddWithValue("@tipo", "M");
                        cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                        cmdExpediente.Connection = conn;
                        conn.Open();
                        cmdExpediente.ExecuteNonQuery();
                        conn.Close();
                    }
                    if (cbP.Checked)
                    {
                        SqlCommand cmdExpediente = new SqlCommand();
                        cmdExpediente.CommandText = "INSERT into expedientes(NumeroObra,NomArchivo,TipoDocumento,Usuario,fechaSubido) values(@obra,'x',@tipo,'Mario',getdate());";
                        cmdExpediente.Parameters.AddWithValue("@obra", txtObra.Text);
                        cmdExpediente.Parameters.AddWithValue("@tipo", "P");
                        cmdExpediente.Parameters.AddWithValue("@ano", txtAno.Text);
                        cmdExpediente.Connection = conn;
                        conn.Open();
                        cmdExpediente.ExecuteNonQuery();
                        conn.Close();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "ERROR");
                }
                txtObra.Text = "";

            }
        }
    }
}
