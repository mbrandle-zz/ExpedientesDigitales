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
    public partial class frmReporte : Form
    {
        List<RenglonReporte> lRenglones = new List<RenglonReporte>();
        public frmReporte()
        {
            InitializeComponent();
            CargarAnos();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                lRenglones = new List<RenglonReporte>();

                Boolean boolFicha = false;
                Boolean boolAprob = false;
                Boolean boolFallo = false;
                Boolean boolContr = false;
                Boolean boolFianz = false;
                Boolean boolEstim = false;
                Boolean boolFiniq = false;
                Boolean boolCatal = false;
                Boolean boolFotos = false;
                Boolean boolPlano = false;

                RenglonReporte renglonTitulos = new RenglonReporte();
                renglonTitulos.Obra = "OBRA";
                renglonTitulos.Ficha = "FICHA";
                renglonTitulos.Aprob = "APROB";
                renglonTitulos.Fallo = "FALLO";
                renglonTitulos.Contr = "CONTR";
                renglonTitulos.Fianza = "FIANZ";
                renglonTitulos.Estim = "ESTIM";
                renglonTitulos.Finiq = "FINIQ";
                renglonTitulos.Catal = "CATAL";
                renglonTitulos.Fotos = "FOTOS";
                renglonTitulos.Plano = "PLANO";
                lRenglones.Add(renglonTitulos);

                String strTabla = "<html><head><title></title></head><body bgcolor='#3da1ba'><p>" +
                    "<table border='1'celpadding='10%' bordercolor='Gainsboro' bgcolor='FFFFFF'  style='color:#000'><tr align='center'><td><strong>OBRA</strong></td><td><strong>FICHA</strong></td><td><strong>APROB</strong></td><td><strong>FALLO</strong></td><td><strong>CONTR</strong></td>" +
                    "<td color='#FFFFFF'><strong>FIANZ</strong></td><td color='#FFFFFF'><strong>ESTIM</strong></td><td color='#FFFFFF'><strong>FINIQ</strong></td><td color='#FFFFFF'><strong>CATAL</strong></td><td color='#FFFFFF'><strong>FOTOS</strong></td><td color='#FFFFFF'><strong>PLANO</strong></td></tr>";

                String obraActual = "";

                string strBloque = "";

                if (cbAnos.SelectedIndex != 0)
                {
                    Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

                    String host = confCollection["host"].Value.ToString();
                    String usuario = confCollection["usuario"].Value.ToString();
                    String password = confCollection["password"].Value.ToString();
                    String catalogo = confCollection["catalog"].Value.ToString();
                    string conString = "Data Source=" + host + "; Initial Catalog=" + catalogo + ";User ID=" + usuario + ";Password=" + password + "";

                    SqlConnection conn = new SqlConnection(conString);
                    SqlCommand cmdExpedientes = new SqlCommand();
                    cmdExpedientes.Connection = conn;
                    cmdExpedientes.CommandText = "select Tipodocumento,NumeroObra,ano  from expedientes where Ano=@ano order by numeroObra asc";
                    cmdExpedientes.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    conn.Open();
                    SqlDataReader rdrExpedientes = cmdExpedientes.ExecuteReader();
                    while (rdrExpedientes.Read())
                    {
                        String newObra = rdrExpedientes.GetString(1);
                        RenglonReporte nuevoRenglon = new RenglonReporte();
                        if (!obraActual.Equals(newObra))
                        {                            
                            strBloque = "<tr style='width=100%' align='center'><td><strong>" + obraActual + "</strong></td>";
                            nuevoRenglon.Obra = obraActual;
                            if (boolFicha)
                            {
                                strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                                nuevoRenglon.Ficha = "Sí";
                            }
                            else
                            {
                                strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                                nuevoRenglon.Ficha = "No";
                            }
                            if (boolAprob)
                            {
                                strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                                nuevoRenglon.Aprob = "Sí";
                            }
                            else
                            {
                                strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                                nuevoRenglon.Aprob = "No";
                            }
                            if (boolFallo)
                            {
                                strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                                nuevoRenglon.Fallo = "Sí";
                            }
                            else
                            {
                                strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                                nuevoRenglon.Fallo = "No";
                            }
                            if (boolContr)
                            {
                                strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                                nuevoRenglon.Contr = "Sí";
                            }
                            else
                            {
                                strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                                nuevoRenglon.Contr = "No";
                            }
                            if (boolFianz)
                            {
                                strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                                nuevoRenglon.Fianza = "Sí";
                            }
                            else
                            {
                                strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                                nuevoRenglon.Fianza = "No";
                            }
                            if (boolEstim)
                            {
                                strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                                nuevoRenglon.Estim = "Sí";
                            }
                            else
                            {
                                strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                                nuevoRenglon.Estim = "No";
                            }
                            if (boolFiniq)
                            {
                                strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                                nuevoRenglon.Finiq = "Sí";
                            }
                            else
                            {
                                strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                                nuevoRenglon.Finiq = "No";
                            }
                            if (boolCatal)
                            {
                                strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                                nuevoRenglon.Catal = "Sí";
                            }
                            else
                            {
                                strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                                nuevoRenglon.Catal = "No";
                            }
                            if (boolFotos)
                            {
                                strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                                nuevoRenglon.Fotos = "Sí";
                            }
                            else
                            {
                                strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                                nuevoRenglon.Fotos = "No";
                            }
                            if (boolPlano)
                            {
                                strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                                nuevoRenglon.Plano = "Sí";
                            }
                            else
                            {
                                strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                                nuevoRenglon.Plano = "No";
                            }
                            strBloque = strBloque + "</tr>";

                            if (obraActual != (""))
                            {
                                strTabla = strTabla + strBloque;
                                lRenglones.Add(nuevoRenglon);
                            }

                            obraActual = newObra;
                            strBloque = "";


                            boolFicha = false;
                            boolAprob = false;
                            boolFallo = false;
                            boolContr = false;
                            boolFianz = false;
                            boolEstim = false;
                            boolFiniq = false;
                            boolCatal = false;
                            boolFotos = false;
                            boolPlano = false;
                        }

                        String strTipo = rdrExpedientes.GetString(0);
                        switch (strTipo)
                        {
                            case "A":
                                boolFicha = true;
                                break;

                            case "B":
                                boolAprob = true;
                                break;

                            case "C":
                                boolFallo = true;
                                break;

                            case "D":
                                boolContr = true;
                                break;

                            case "F":
                                boolFianz = true;
                                break;

                            case "E":
                                boolEstim = true;
                                break;

                            case "G":
                                boolFiniq = true;
                                break;

                            case "H":
                                boolCatal = true;
                                break;

                            case "M":
                                boolFotos = true;
                                break;

                            case "P":
                                boolPlano = true;
                                break;
                        }
                    }

                    RenglonReporte nuevoRenglon2 = new RenglonReporte();
                    strBloque = "<tr style='width=100%' align='center'><td><strong>" + obraActual + "</strong></td>";
                    nuevoRenglon2.Obra = obraActual;
                    if (boolFicha)
                    {
                        strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                        nuevoRenglon2.Ficha = "Sí";
                    }
                    else
                    {
                        strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                        nuevoRenglon2.Ficha = "No";
                    }
                    if (boolAprob)
                    {
                        strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                        nuevoRenglon2.Aprob = "Sí";
                    }
                    else
                    {
                        strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                        nuevoRenglon2.Aprob = "No";
                    }
                    if (boolFallo)
                    {
                        strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                        nuevoRenglon2.Fallo = "Sí";
                    }
                    else
                    {
                        strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                        nuevoRenglon2.Fallo = "No";
                    }
                    if (boolContr)
                    {
                        strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                        nuevoRenglon2.Contr = "Sí";
                    }
                    else
                    {
                        strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                        nuevoRenglon2.Contr = "No";
                    }
                    if (boolFianz)
                    {
                        strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                        nuevoRenglon2.Fianza = "Sí";
                    }
                    else
                    {
                        strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                        nuevoRenglon2.Fianza = "No";
                    }
                    if (boolEstim)
                    {
                        strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                        nuevoRenglon2.Estim = "Sí";
                    }
                    else
                    {
                        strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                        nuevoRenglon2.Estim = "No";
                    }
                    if (boolFiniq)
                    {
                        strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                        nuevoRenglon2.Finiq = "Sí";
                    }
                    else
                    {
                        strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                        nuevoRenglon2.Finiq = "No";
                    }
                    if (boolCatal)
                    {
                        strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                        nuevoRenglon2.Catal = "Sí";
                    }
                    else
                    {
                        strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                        nuevoRenglon2.Catal = "No";
                    }
                    if (boolFotos)
                    {
                        strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                        nuevoRenglon2.Fotos = "Sí";
                    }
                    else
                    {
                        strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                        nuevoRenglon2.Fotos = "No";
                    }
                    if (boolPlano)
                    {
                        strBloque = strBloque + "<td bgcolor='#C6EFCE'>Sí</td>";
                        nuevoRenglon2.Plano = "Sí";
                    }
                    else
                    {
                        strBloque = strBloque + "<td bgcolor='#FFC7CE'>No</td>";
                        nuevoRenglon2.Plano = "No";
                    }                    
                    strBloque = strBloque + "</tr>";
                    strTabla = strTabla + strBloque;
                    lRenglones.Add(nuevoRenglon2);
                    rdrExpedientes.Close();

                    //Inicio Obras Sin Archivos

                    SqlCommand cmdObrasFaltantes = new SqlCommand();
                    cmdObrasFaltantes.Connection = conn;
                    cmdObrasFaltantes.CommandText = "select NoObra from obras where ano=@ano and noobra not in (select numeroobra from expedientes)";
                    cmdObrasFaltantes.Parameters.AddWithValue("@ano", cbAnos.Text.ToString());
                    //conn.Open();
                    SqlDataReader rdrObrasFaltantes = cmdObrasFaltantes.ExecuteReader();
                    while (rdrObrasFaltantes.Read())
                    {
                        strBloque = "<tr style='width=100%' align='center'><td><strong>" + rdrObrasFaltantes.GetString(0) + "</strong></td><td bgcolor='#FFC7CE'>No</td><td bgcolor='#FFC7CE'>No</td><td bgcolor='#FFC7CE'>No</td><td bgcolor='#FFC7CE'>No</td><td bgcolor='#FFC7CE'>No</td><td bgcolor='#FFC7CE'>No</td>" +
                            "<td bgcolor='#FFC7CE'>No</td><td bgcolor='#FFC7CE'>No</td><td bgcolor='#FFC7CE'>No</td><td bgcolor='#FFC7CE'>No</td></tr>";
                        strTabla = strTabla + strBloque;

                        nuevoRenglon2 = new RenglonReporte();
                        nuevoRenglon2.Obra = rdrObrasFaltantes.GetString(0);
                        nuevoRenglon2.Ficha = "No";
                        nuevoRenglon2.Aprob = "No";
                        nuevoRenglon2.Fallo = "No";
                        nuevoRenglon2.Contr = "No";
                        nuevoRenglon2.Fianza = "No";
                        nuevoRenglon2.Estim = "No";
                        nuevoRenglon2.Finiq = "No";
                        nuevoRenglon2.Catal = "No";
                        nuevoRenglon2.Fotos = "No";
                        nuevoRenglon2.Plano = "No";
                        lRenglones.Add(nuevoRenglon2);
                    }
                    rdrObrasFaltantes.Close();
                    //Fin Obras Sin Archivos

                    strBloque = "</table></p></body></html>";
                    strTabla = strTabla + strBloque;
                    conn.Close();
                    wbReporte.DocumentText = strTabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR");
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = 1;

                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet1 = null;
                worksheet1 = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets[1];
                workbook.Sheets[1].Activate();

                worksheet1.Cells[1, 1].Font.Bold = true;
                worksheet1.Cells[1, 2].Font.Bold = true;
                worksheet1.Cells[1, 3].Font.Bold = true;
                worksheet1.Cells[1, 4].Font.Bold = true;
                worksheet1.Cells[1, 5].Font.Bold = true;
                worksheet1.Cells[1, 6].Font.Bold = true;
                worksheet1.Cells[1, 7].Font.Bold = true;
                worksheet1.Cells[1, 8].Font.Bold = true;
                worksheet1.Cells[1, 9].Font.Bold = true;
                worksheet1.Cells[1, 10].Font.Bold = true;
                worksheet1.Cells[1, 11].Font.Bold = true;

                foreach (RenglonReporte rActual in lRenglones)
                {
                    worksheet1.Cells[indice, 1] = rActual.Obra;
                    worksheet1.Cells[indice, 1].Font.Bold = true;
                    worksheet1.Cells[indice, 2] = rActual.Ficha;
                    worksheet1.Cells[indice, 3] = rActual.Aprob;
                    worksheet1.Cells[indice, 4] = rActual.Fallo;
                    worksheet1.Cells[indice, 5] = rActual.Contr;
                    worksheet1.Cells[indice, 6] = rActual.Fianza;
                    worksheet1.Cells[indice, 7] = rActual.Estim;
                    worksheet1.Cells[indice, 8] = rActual.Finiq;
                    worksheet1.Cells[indice, 9] = rActual.Catal;
                    worksheet1.Cells[indice, 10] = rActual.Fotos;
                    worksheet1.Cells[indice, 11] = rActual.Plano;

                    indice++;
                }                

                string fileDestination = @"C:\xxxx.xls";
                if (File.Exists(fileDestination))
                {
                    File.Delete(fileDestination);
                }

                workbook.SaveAs(fileDestination, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                workbook.Close(true, Type.Missing, Type.Missing);                
                app.Quit();
                Process.Start(fileDestination);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR");
            }
        }

        private void cbAnos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gbAnos_Enter(object sender, EventArgs e)
        {

        }
    }
}
