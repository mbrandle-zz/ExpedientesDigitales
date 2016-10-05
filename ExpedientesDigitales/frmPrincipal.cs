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
    public partial class frmPrincipal : Form
    {
        String usuarioActual = "";
        String numeroObra = "";
        public frmPrincipal(String usuario,Boolean administrador,Boolean reporteador,Boolean revision)
        {
            InitializeComponent();
            CargarAnos();
            usuarioActual = usuario;
            if (administrador)
            {                
                administrarToolStripMenuItem.Visible = true;
            }
            if (reporteador)
            {
                reporteadorToolStripMenuItem.Visible = true;
            }
            if (revision)
            {
                revisionToolStripMenuItem.Visible = true;
            }
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnFicha_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFicha = new OpenFileDialog();
            ofdFicha.Filter = "Archivo PDF|*.pdf";
            ofdFicha.Title = "Seleccione Ficha de Aprobación.";
            if (ofdFicha.ShowDialog() == DialogResult.OK)
            {
                txtFicha.Text = ofdFicha.FileName.ToString();
            }
        }

        private void btnAprob_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdAprob = new OpenFileDialog();
            ofdAprob.Filter = "Archivo PDF|*.pdf";
            ofdAprob.Title = "Seleccione Oficio de Aprobación, Anexo técnivo e Inf. Complem.";
            if (ofdAprob.ShowDialog() == DialogResult.OK)
            {
                txtAprob.Text = ofdAprob.FileName.ToString();
            }
        }

        private void btnFallo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFallo = new OpenFileDialog();
            ofdFallo.Filter = "Archivo PDF|*.pdf";
            ofdFallo.Title = "Seleccione Acta de Fallo";
            if (ofdFallo.ShowDialog() == DialogResult.OK)
            {
                txtFallo.Text = ofdFallo.FileName.ToString();
            }
        }

        private void btnContr_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdContr = new OpenFileDialog();
            ofdContr.Filter = "Archivo PDF|*.pdf";
            ofdContr.Title = "Seleccione Contrato";
            if (ofdContr.ShowDialog() == DialogResult.OK)
            {
                txtContr.Text = ofdContr.FileName.ToString();
            }
        }

        private void btnFianz_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFianz = new OpenFileDialog();
            ofdFianz.Filter = "Archivo PDF|*.pdf";
            ofdFianz.Title = "Seleccione Fianzas";
            if (ofdFianz.ShowDialog() == DialogResult.OK)
            {
                txtFianz.Text = ofdFianz.FileName.ToString();
            }
        }

        private void btnEstim_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdEstim = new OpenFileDialog();
            ofdEstim.Filter = "Archivo PDF|*.pdf";
            ofdEstim.Title = "Seleccione Estimaciones";
            if (ofdEstim.ShowDialog() == DialogResult.OK)
            {
                txtEstim.Text = ofdEstim.FileName.ToString();
            }
        }

        private void btnFiniq_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFiniq = new OpenFileDialog();
            ofdFiniq.Filter = "Archivo PDF|*.pdf";
            ofdFiniq.Title = "Seleccione Finiquito de Obra";
            if (ofdFiniq.ShowDialog() == DialogResult.OK)
            {
                txtFiniq.Text = ofdFiniq.FileName.ToString();
            }
        }

        private void btnCatal_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdCatal = new OpenFileDialog();
            ofdCatal.Filter = "Archivo PDF|*.pdf";
            ofdCatal.Title = "Seleccione Catálogo de Conceptos";
            if (ofdCatal.ShowDialog() == DialogResult.OK)
            {
                txtCatal.Text = ofdCatal.FileName.ToString();
            }
        }

        private void btnFotos_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFotos = new OpenFileDialog();
            ofdFotos.Filter = "Archivo PDF|*.pdf";
            ofdFotos.Title = "Seleccione Memoria Fotográfica";
            if (ofdFotos.ShowDialog() == DialogResult.OK)
            {
                txtFotos.Text = ofdFotos.FileName.ToString();
            }
        }

        private void btnPlano_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdPlano = new OpenFileDialog();
            ofdPlano.Filter = "Archivo PDF|*.pdf";
            ofdPlano.Title = "Seleccione Planos";
            if (ofdPlano.ShowDialog() == DialogResult.OK)
            {
                txtPlano.Text = ofdPlano.FileName.ToString();
            }
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

        private void cbAnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAnos.SelectedIndex != 0)
            {

                try
                {
                    cbNoObra.Enabled = true;
                    cbNoObra.Items.Clear();

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
                    cmdObras.CommandText = "select NoObra+'-'+NombreObra as InofoObra,NoObra from obras where Ano=@ano";
                    cmdObras.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    conn.Open();

                    SqlDataReader rdrObras = cmdObras.ExecuteReader();
                    while (rdrObras.Read())
                    {
                        cbNoObra.Items.Add(rdrObras.GetString(0).ToString());
                    }
                    rdrObras.Close();
                    conn.Close();
                    cbNoObra.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "ERROR");
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String[] separador=cbNoObra.Text.Split('-');
            numeroObra=separador[0];

            lblSubidoA.Text = "No";
            lblSubidoB.Text = "No";
            lblSubidoC.Text = "No";
            lblSubidoD.Text = "No";
            lblSubidoF.Text = "No";
            lblSubidoE.Text = "No";
            lblSubidoG.Text = "No";
            lblSubidoH.Text = "No";
            lblSubidoM.Text = "No";
            lblSubidoP.Text = "No";

            txtFicha.Text = "";
            txtAprob.Text = "";
            txtFallo.Text = "";
            txtContr.Text = "";
            txtFianz.Text = "";
            txtEstim.Text = "";
            txtFiniq.Text = "";
            txtCatal.Text = "";
            txtFotos.Text = "";
            txtPlano.Text = "";

            btnCargar.Enabled = true;
            btnFicha.Enabled = true;
            btnAprob.Enabled = true;
            btnFallo.Enabled = true;
            btnContr.Enabled = true;
            btnFianz.Enabled = true;
            btnEstim.Enabled = true;
            btnFiniq.Enabled = true;
            btnCatal.Enabled = true;
            btnFotos.Enabled = true;
            btnPlano.Enabled = true;

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
                SqlCommand cmdExpediente = new SqlCommand();
                cmdExpediente.Connection = conn;
                cmdExpediente.CommandText = "select * from expedientes where numeroObra=@numeroObra and Ano=@ano";
                cmdExpediente.Parameters.AddWithValue("@numeroObra", numeroObra);
                cmdExpediente.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                conn.Open();

                SqlDataReader rdrExpedientes = cmdExpediente.ExecuteReader();
                while (rdrExpedientes.Read())
                {
                    String strTipo = rdrExpedientes.GetString(3);
                    switch (strTipo)
                    {
                        case "A":
                            lblSubidoA.Text = "Sí";
                            break;

                        case "B":
                            lblSubidoB.Text = "Sí";
                            break;

                        case "C":
                            lblSubidoC.Text = "Sí";
                            break;

                        case "D":
                            lblSubidoD.Text = "Sí";
                            break;

                        case "F":
                            lblSubidoF.Text = "Sí";
                            break;

                        case "E":
                            lblSubidoE.Text = "Sí";
                            break;

                        case "G":
                            lblSubidoG.Text = "Sí";
                            break;

                        case "H":
                            lblSubidoH.Text = "Sí";
                            break;

                        case "M":
                            lblSubidoM.Text = "Sí";
                            break;

                        case "P":
                            lblSubidoP.Text = "Sí";
                            break;
                    }
                }
                rdrExpedientes.Close();
                conn.Close();
                //cbNoObra.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR");
            }
        }

        [DllImport("advapi32.DLL", SetLastError = true)]
        public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        private void btnCargar_Click(object sender, EventArgs e)
        {
            bool blSobreescribir = false;
            if (numeroObra.Equals(""))
            {
                MessageBox.Show("Error: " + "No Hay Obra Seleccionada ", "ERROR");
            }
            else
            {
                blSobreescribir = DocumentoSustituido();
                if (blSobreescribir)
                {
                    DialogResult dialogResult = MessageBox.Show("Está A Punto de Reemplazar  un Archivo Anteriormente Cargado ¿Desea Continuar?", "Atención ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Guardar();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else
                {
                    Guardar();
                }

            }
            //
            
        }

        private void estadoDeObrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporte frPpal = new frmReporte();
            frPpal.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frPpal = new frmUsuarios();
            frPpal.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            txtFicha.Text = "";
        }

        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            txtAprob.Text = "";
        }

        private void btnEliminar3_Click(object sender, EventArgs e)
        {
            txtFallo.Text = "";
        }

        private void btnEliminar4_Click(object sender, EventArgs e)
        {
            txtContr.Text = "";
        }

        private void btnEliminar5_Click(object sender, EventArgs e)
        {
            txtFianz.Text = "";
        }

        private void btnEliminar6_Click(object sender, EventArgs e)
        {
            txtEstim.Text = "";
        }

        private void btnEliminar7_Click(object sender, EventArgs e)
        {
            txtFiniq.Text = "";
        }

        private void btnEliminar8_Click(object sender, EventArgs e)
        {
            txtCatal.Text = "";
        }

        private void btnEliminar9_Click(object sender, EventArgs e)
        {
            txtFotos.Text = "";
        }

        private void btnEliminar10_Click(object sender, EventArgs e)
        {
            txtPlano.Text = "";
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            txtFicha.Text = "";
        }

        private void cargarObraManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargarObras frObras = new frmCargarObras();
            frObras.ShowDialog();
        }

        private void revisiónDeObraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRevision frRev = new frmRevision();
            frRev.ShowDialog();
        }

        private bool DocumentoSustituido()
        {
            bool blSustituido = false;

            if (!txtFicha.Text.Equals("") && lblSubidoA.Text.Equals("Sí"))
            {
                blSustituido = true;
            }
            if (!txtAprob.Text.Equals("") && lblSubidoB.Text.Equals("Sí"))
            {
                blSustituido = true;
            }
            if (!txtFallo.Text.Equals("") && lblSubidoC.Text.Equals("Sí"))
            {
                blSustituido = true;
            }
            if (!txtContr.Text.Equals("") && lblSubidoD.Text.Equals("Sí"))
            {
                blSustituido = true;
            }
            if (!txtFianz.Text.Equals("") && lblSubidoF.Text.Equals("Sí"))
            {
                blSustituido = true;
            }
            if (!txtEstim.Text.Equals("") && lblSubidoE.Text.Equals("Sí"))
            {
                blSustituido = true;
            }
            if (!txtFiniq.Text.Equals("") && lblSubidoG.Text.Equals("Sí"))
            {
                blSustituido = true;
            }
            if (!txtCatal.Text.Equals("") && lblSubidoH.Text.Equals("Sí"))
            {
                blSustituido = true;
            }
            if (!txtFotos.Text.Equals("") && lblSubidoM.Text.Equals("Sí"))
            {
                blSustituido = true;
            }
            if (!txtPlano.Text.Equals("") && lblSubidoP.Text.Equals("Sí"))
            {
                blSustituido = true;
            }

            return blSustituido;
        }


        private void Guardar()
        {
            try
            {
                String documentoActual = "";
                String[] separador = cbNoObra.Text.Split('-');
                numeroObra = separador[0];

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
                SqlCommand cmdExpediente = new SqlCommand();
                cmdExpediente.Connection = conn;
                conn.Open();


                //Cargar Ficha
                if (!txtFicha.Text.Equals(""))
                {
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    String[] rutas = txtFicha.Text.Split('\\');
                    documentoActual = rutas[rutas.Length - 1];
                    try
                    {
                        //MessageBox.Show("Copying file...");
                        if (LogonUser(usuarioRed, dominio, passwordRed, 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();
                            String rutaCompleta = ruta + cbAnos.Text + "\\GI\\" + numeroObra + "\\" + documentoActual;
                            File.Copy(txtFicha.Text, rutaCompleta, true);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + "Error Al Copiar Archivo ", "ERROR");
                        }
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                    cmdExpediente = new SqlCommand();
                    cmdExpediente.Connection = conn;
                    cmdExpediente.CommandText = "insert into expedientes (NumeroObra,NomArchivo,TipoDocumento,Usuario,Ano) " +
                        " values(@numeroObra,@nomArchivo,@tipodocumento,@usuario,@ano)";
                    cmdExpediente.Parameters.AddWithValue("@numeroObra", numeroObra);
                    cmdExpediente.Parameters.AddWithValue("@nomArchivo", documentoActual);
                    cmdExpediente.Parameters.AddWithValue("@tipodocumento", "A");
                    cmdExpediente.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmdExpediente.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    cmdExpediente.ExecuteNonQuery();
                }

                //Cargar Aprob
                if (!txtAprob.Text.Equals(""))
                {
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    String[] rutas = txtAprob.Text.Split('\\');
                    documentoActual = rutas[rutas.Length - 1];
                    try
                    {
                        //MessageBox.Show("Copying file...");
                        if (LogonUser(usuarioRed, dominio, passwordRed, 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();
                            String rutaCompleta = ruta + cbAnos.Text + "\\GI\\" + numeroObra + "\\" + documentoActual;
                            File.Copy(txtAprob.Text, rutaCompleta, true);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + "Error Al Copiar Archivo ", "ERROR");
                        }
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                    cmdExpediente = new SqlCommand();
                    cmdExpediente.Connection = conn;
                    cmdExpediente.CommandText = "insert into expedientes (NumeroObra,NomArchivo,TipoDocumento,Usuario,Ano) " +
                        " values(@numeroObra,@nomArchivo,@tipodocumento,@usuario,@ano)";
                    cmdExpediente.Parameters.AddWithValue("@numeroObra", numeroObra);
                    cmdExpediente.Parameters.AddWithValue("@nomArchivo", documentoActual);
                    cmdExpediente.Parameters.AddWithValue("@tipodocumento", "B");
                    cmdExpediente.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmdExpediente.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    cmdExpediente.ExecuteNonQuery();
                }

                //Cargar Fallo
                if (!txtFallo.Text.Equals(""))
                {
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    String[] rutas = txtFallo.Text.Split('\\');
                    documentoActual = rutas[rutas.Length - 1];
                    try
                    {
                        //MessageBox.Show("Copying file...");
                        if (LogonUser(usuarioRed, dominio, passwordRed, 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();
                            String rutaCompleta = ruta + cbAnos.Text + "\\GI\\" + numeroObra + "\\" + documentoActual;
                            File.Copy(txtFallo.Text, rutaCompleta, true);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + "Error Al Copiar Archivo ", "ERROR");
                        }
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                    cmdExpediente = new SqlCommand();
                    cmdExpediente.Connection = conn;
                    cmdExpediente.CommandText = "insert into expedientes (NumeroObra,NomArchivo,TipoDocumento,Usuario,Ano) " +
                        " values(@numeroObra,@nomArchivo,@tipodocumento,@usuario,@ano)";
                    cmdExpediente.Parameters.AddWithValue("@numeroObra", numeroObra);
                    cmdExpediente.Parameters.AddWithValue("@nomArchivo", documentoActual);
                    cmdExpediente.Parameters.AddWithValue("@tipodocumento", "C");
                    cmdExpediente.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmdExpediente.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    cmdExpediente.ExecuteNonQuery();
                }

                //Cargar Contr
                if (!txtContr.Text.Equals(""))
                {
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    String[] rutas = txtContr.Text.Split('\\');
                    documentoActual = rutas[rutas.Length - 1];
                    try
                    {
                        //MessageBox.Show("Copying file...");
                        if (LogonUser(usuarioRed, dominio, passwordRed, 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();
                            String rutaCompleta = ruta + cbAnos.Text + "\\GI\\" + numeroObra + "\\" + documentoActual;
                            File.Copy(txtContr.Text, rutaCompleta, true);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + "Error Al Copiar Archivo ", "ERROR");
                        }
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                    cmdExpediente = new SqlCommand();
                    cmdExpediente.Connection = conn;
                    cmdExpediente.CommandText = "insert into expedientes (NumeroObra,NomArchivo,TipoDocumento,Usuario,Ano) " +
                        " values(@numeroObra,@nomArchivo,@tipodocumento,@usuario,@ano)";
                    cmdExpediente.Parameters.AddWithValue("@numeroObra", numeroObra);
                    cmdExpediente.Parameters.AddWithValue("@nomArchivo", documentoActual);
                    cmdExpediente.Parameters.AddWithValue("@tipodocumento", "D");
                    cmdExpediente.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmdExpediente.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    cmdExpediente.ExecuteNonQuery();
                }

                //Cargar Fianza
                if (!txtFianz.Text.Equals(""))
                {
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    String[] rutas = txtFianz.Text.Split('\\');
                    documentoActual = rutas[rutas.Length - 1];
                    try
                    {
                        //MessageBox.Show("Copying file...");
                        if (LogonUser(usuarioRed, dominio, passwordRed, 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();
                            String rutaCompleta = ruta + cbAnos.Text + "\\GI\\" + numeroObra + "\\" + documentoActual;
                            File.Copy(txtFianz.Text, rutaCompleta, true);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + "Error Al Copiar Archivo ", "ERROR");
                        }
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                    cmdExpediente = new SqlCommand();
                    cmdExpediente.Connection = conn;
                    cmdExpediente.CommandText = "insert into expedientes (NumeroObra,NomArchivo,TipoDocumento,Usuario,Ano) " +
                        " values(@numeroObra,@nomArchivo,@tipodocumento,@usuario,@ano)";
                    cmdExpediente.Parameters.AddWithValue("@numeroObra", numeroObra);
                    cmdExpediente.Parameters.AddWithValue("@nomArchivo", documentoActual);
                    cmdExpediente.Parameters.AddWithValue("@tipodocumento", "F");
                    cmdExpediente.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmdExpediente.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    cmdExpediente.ExecuteNonQuery();
                }

                //Cargar Estim
                if (!txtEstim.Text.Equals(""))
                {
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    String[] rutas = txtEstim.Text.Split('\\');
                    documentoActual = rutas[rutas.Length - 1];
                    try
                    {
                        //MessageBox.Show("Copying file...");
                        if (LogonUser(usuarioRed, dominio, passwordRed, 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();
                            String rutaCompleta = ruta + cbAnos.Text + "\\GI\\" + numeroObra + "\\" + documentoActual;
                            File.Copy(txtEstim.Text, rutaCompleta, true);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + "Error Al Copiar Archivo ", "ERROR");
                        }
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                    cmdExpediente = new SqlCommand();
                    cmdExpediente.Connection = conn;
                    cmdExpediente.CommandText = "insert into expedientes (NumeroObra,NomArchivo,TipoDocumento,Usuario,Ano) " +
                        " values(@numeroObra,@nomArchivo,@tipodocumento,@usuario,@ano)";
                    cmdExpediente.Parameters.AddWithValue("@numeroObra", numeroObra);
                    cmdExpediente.Parameters.AddWithValue("@nomArchivo", documentoActual);
                    cmdExpediente.Parameters.AddWithValue("@tipodocumento", "E");
                    cmdExpediente.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmdExpediente.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    cmdExpediente.ExecuteNonQuery();
                }

                //Cargar Finiq
                if (!txtFiniq.Text.Equals(""))
                {
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    String[] rutas = txtFiniq.Text.Split('\\');
                    documentoActual = rutas[rutas.Length - 1];
                    try
                    {
                        //MessageBox.Show("Copying file...");
                        if (LogonUser(usuarioRed, dominio, passwordRed, 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();
                            String rutaCompleta = ruta + cbAnos.Text + "\\GI\\" + numeroObra + "\\" + documentoActual;
                            File.Copy(txtFiniq.Text, rutaCompleta, true);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + "Error Al Copiar Archivo ", "ERROR");
                        }
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                    cmdExpediente = new SqlCommand();
                    cmdExpediente.Connection = conn;
                    cmdExpediente.CommandText = "insert into expedientes (NumeroObra,NomArchivo,TipoDocumento,Usuario,Ano) " +
                        " values(@numeroObra,@nomArchivo,@tipodocumento,@usuario,@ano)";
                    cmdExpediente.Parameters.AddWithValue("@numeroObra", numeroObra);
                    cmdExpediente.Parameters.AddWithValue("@nomArchivo", documentoActual);
                    cmdExpediente.Parameters.AddWithValue("@tipodocumento", "G");
                    cmdExpediente.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmdExpediente.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    cmdExpediente.ExecuteNonQuery();
                }

                //Cargar Catal
                if (!txtCatal.Text.Equals(""))
                {
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    String[] rutas = txtCatal.Text.Split('\\');
                    documentoActual = rutas[rutas.Length - 1];
                    try
                    {
                        //MessageBox.Show("Copying file...");
                        if (LogonUser(usuarioRed, dominio, passwordRed, 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();
                            String rutaCompleta = ruta + cbAnos.Text + "\\GI\\" + numeroObra + "\\" + documentoActual;
                            File.Copy(txtCatal.Text, rutaCompleta, true);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + "Error Al Copiar Archivo ", "ERROR");
                        }
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                    cmdExpediente = new SqlCommand();
                    cmdExpediente.Connection = conn;
                    cmdExpediente.CommandText = "insert into expedientes (NumeroObra,NomArchivo,TipoDocumento,Usuario,Ano) " +
                        " values(@numeroObra,@nomArchivo,@tipodocumento,@usuario,@ano)";
                    cmdExpediente.Parameters.AddWithValue("@numeroObra", numeroObra);
                    cmdExpediente.Parameters.AddWithValue("@nomArchivo", documentoActual);
                    cmdExpediente.Parameters.AddWithValue("@tipodocumento", "H");
                    cmdExpediente.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmdExpediente.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    cmdExpediente.ExecuteNonQuery();
                }

                //Cargar Fotos
                if (!txtFotos.Text.Equals(""))
                {
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    String[] rutas = txtFotos.Text.Split('\\');
                    documentoActual = rutas[rutas.Length - 1];
                    try
                    {
                        //MessageBox.Show("Copying file...");
                        if (LogonUser(usuarioRed, dominio, passwordRed, 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();
                            String rutaCompleta = ruta + cbAnos.Text + "\\GI\\" + numeroObra + "\\" + documentoActual;
                            File.Copy(txtFotos.Text, rutaCompleta, true);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + "Error Al Copiar Archivo ", "ERROR");
                        }
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                    cmdExpediente = new SqlCommand();
                    cmdExpediente.Connection = conn;
                    cmdExpediente.CommandText = "insert into expedientes (NumeroObra,NomArchivo,TipoDocumento,Usuario,Ano) " +
                        " values(@numeroObra,@nomArchivo,@tipodocumento,@usuario,@ano)";
                    cmdExpediente.Parameters.AddWithValue("@numeroObra", numeroObra);
                    cmdExpediente.Parameters.AddWithValue("@nomArchivo", documentoActual);
                    cmdExpediente.Parameters.AddWithValue("@tipodocumento", "M");
                    cmdExpediente.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmdExpediente.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    cmdExpediente.ExecuteNonQuery();
                }

                //Cargar Plano
                if (!txtPlano.Text.Equals(""))
                {
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    String[] rutas = txtPlano.Text.Split('\\');
                    documentoActual = rutas[rutas.Length - 1];
                    try
                    {
                        //MessageBox.Show("Copying file...");
                        if (LogonUser(usuarioRed, dominio, passwordRed, 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();
                            String rutaCompleta = ruta + cbAnos.Text + "\\GI\\" + numeroObra + "\\" + documentoActual;
                            File.Copy(txtPlano.Text, rutaCompleta, true);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + "Error Al Copiar Archivo ", "ERROR");
                        }
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                    cmdExpediente = new SqlCommand();
                    cmdExpediente.Connection = conn;
                    cmdExpediente.CommandText = "insert into expedientes (NumeroObra,NomArchivo,TipoDocumento,Usuario,Ano) " +
                        " values(@numeroObra,@nomArchivo,@tipodocumento,@usuario,@ano)";
                    cmdExpediente.Parameters.AddWithValue("@numeroObra", numeroObra);
                    cmdExpediente.Parameters.AddWithValue("@nomArchivo", documentoActual);
                    cmdExpediente.Parameters.AddWithValue("@tipodocumento", "P");
                    cmdExpediente.Parameters.AddWithValue("@usuario", usuarioActual);
                    cmdExpediente.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    cmdExpediente.ExecuteNonQuery();
                }


                conn.Close();

                MessageBox.Show("Proceso Finalizado Correctamente ", "Carga Correcta");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR");
            }


            lblSubidoA.Text = "No";
            lblSubidoB.Text = "No";
            lblSubidoC.Text = "No";
            lblSubidoD.Text = "No";
            lblSubidoF.Text = "No";
            lblSubidoE.Text = "No";
            lblSubidoG.Text = "No";
            lblSubidoH.Text = "No";
            lblSubidoM.Text = "No";
            lblSubidoP.Text = "No";

            txtFicha.Text = "";
            txtAprob.Text = "";
            txtFallo.Text = "";
            txtContr.Text = "";
            txtFianz.Text = "";
            txtEstim.Text = "";
            txtFiniq.Text = "";
            txtCatal.Text = "";
            txtFotos.Text = "";
            txtPlano.Text = "";

            btnCargar.Enabled = false;
            btnFicha.Enabled = false;
            btnAprob.Enabled = false;
            btnFallo.Enabled = false;
            btnContr.Enabled = false;
            btnFianz.Enabled = false;
            btnEstim.Enabled = false;
            btnFiniq.Enabled = false;
            btnCatal.Enabled = false;
            btnFotos.Enabled = false;
            btnPlano.Enabled = false;
        }

        private void sincronizarArchivosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void crearCarpetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCrearCarpetas frCrearCarpeta = new frmCrearCarpetas();
            frCrearCarpeta.ShowDialog();
        }
    }
}
