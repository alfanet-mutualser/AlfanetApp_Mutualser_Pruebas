using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Utils;
using System.IO;
using DevExpress.XtraCharts;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
// Referencias SpreadsheetLigth y DocumentFormat.openXML
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

public partial class AlfaNetReportes_Dinamicos_InformeGestion : System.Web.UI.Page
{
    string ModuloLog = "REPORTES DINAMICOS";
    string ConsecutivoCodigo = "10";

    protected void Page_Load(object sender, EventArgs e)
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork")
            {
                String IPAdd = string.Empty;
                IPAdd = Request.ServerVariables["HTTP_X_FORWARDER_FOR"];
                if (String.IsNullOrEmpty(IPAdd))
                {
                    IPAdd = Request.ServerVariables["REMOTE_ADDR"];
                    localIP = IPAdd.ToString();
                    Session["IP"] = localIP;
                }
            }
        }
		Session["Nombrepc"] = host.HostName.ToString();

        //WebChartControl1.SeriesDataMember = "Series";
        //WebChartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
        //WebChartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
        if (!IsPostBack)
        {
            //this.ConsultaRegistros.par SelectParameters["WFMovimientoFecha"].DefaultValue = this.TxtFechaInicial.Text;
            //this.ConsultaRegistros.SelectParameters["WFMovimientoFecha1"].DefaultValue = this.TxtFechaFinal.Text;
            //this.ConsultaRegistros.DataSourceID = "ODSWFExpediente";
            // this.ReportViewer1.LocalReport.DataSources[0].DataSourceId = "";
            //DataSet Items = new DataSet();
            //Items = AlfaWeb.data  Data();
            //this.ConsultaRegistros.DataBind();
            DataTable tabla = ((DataView)AlfaWeb.Select(DataSourceSelectArguments.Empty)).Table;

            Session["Datosss"] = tabla;

            string ActLogCod = "ACCESO";
            DateTime Fechain = DateTime.Now;
            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            //Se Realiza el Log
            int NumeroDocumento = Convert.ToInt32("0");
            string GrupoCod = "";
            string Datosini = "Acceso a modulo";
            string Datosfin1 = "Informe Gestion.";
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Insert log acceso 
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Acceso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            Acceso.InsertReportes(LogId, username, Fechain, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
            //Actualiza consecutivo
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

        }
        else
        {
            DataTable dtata = ((DataView)AlfaWeb.Select(DataSourceSelectArguments.Empty)).Table;

            //DataTable dt = new DataTable();
            // dt = ConsultaRegistros.DataSource as DataTable;

            Session["Datosss"] = dtata;

        }
    }	
    protected void ButtonOpen_Click(object sender, EventArgs e)
    {
        Export(false);
    }
    protected void ButtonSaveAs_Click(object sender, EventArgs e)
    {

        //LOG CONSULTA
        string ActLogCod = "CONSULTAR";
        DateTime Fechain = DateTime.Now;
        //OBTENER CONSECUTIVO DE LOGS
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
        DataRow[] fila = Conse.Select();
        string x = fila[0].ItemArray[0].ToString();
        string LOG = Convert.ToString(x);
        //Se Realiza el Log
        int NumeroDocumento = Convert.ToInt32("0");
        string GrupoCod = "";
        string Datosini = "Informe Gesion entre Fechas";//FECHA INI + FECHA FIN
        string Datosfin1 = ASPxComboBox1.SelectedItem.ToString(); //Recupera el año de la busqueda
        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
        DateTime FechaFin = DateTime.Now;
        Int64 LogId = Convert.ToInt64(LOG);
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        //Insert de log consulta
        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Consultar = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
        Consultar.InsertReportes(LogId, username, Fechain, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
        //Actualiza Consecutivo
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
		
		Export(true);

    }
    protected void Export(Boolean saveAs)
    {
        DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint();
        MemoryStream stream = new MemoryStream();
        this.ASPxPivotGridExporter1.OptionsPrint.PrintHeadersOnEveryPage = true;
        this.ASPxPivotGridExporter1.OptionsPrint.PrintFilterHeaders = DefaultBoolean.True;
        this.ASPxPivotGridExporter1.OptionsPrint.PrintColumnHeaders = DefaultBoolean.True;
        this.ASPxPivotGridExporter1.OptionsPrint.PrintRowHeaders = DefaultBoolean.True;
        this.ASPxPivotGridExporter1.OptionsPrint.PrintDataHeaders = DefaultBoolean.True;

        String contentType = "";
        String fileName = "";

        try
        {

            int caseSwitch = 1;
            if (this.listExportFormat.SelectedIndex != 1)
            {
                switch (this.listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/pdf";
                        fileName = "PivotGrid.pdf";
                        this.ASPxPivotGridExporter1.ExportToPdf(stream);
                        break;
                    case 1:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        this.ASPxPivotGridExporter1.ExportToXls(stream);
                        break;
                    case 2:
                        contentType = "multipart/related";
                        fileName = "PivotGrid.mht";
                        this.ASPxPivotGridExporter1.ExportToMht(stream, "utf-8", "ASPxPivotGrid Printing Sample", true);
                        break;
                    case 3:
                        contentType = "text/enriched";
                        fileName = "PivotGrid.rtf";
                        this.ASPxPivotGridExporter1.ExportToRtf(stream);
                        break;
                    case 4:
                        contentType = "text/plain";
                        fileName = "PivotGrid.txt";
                        this.ASPxPivotGridExporter1.ExportToText(stream);
                        break;
                    case 5:
                        contentType = "text/html";
                        fileName = "PivotGrid.htm";
                        ASPxPivotGridExporter1.ExportToHtml(stream, "utf-8", "ASPxPivotGrid Printing Sample", true);
                        break;
                }
                Byte[] buffer = stream.GetBuffer();
                // Dim buffer() As Byte = stream.GetBuffer()

                String disposition;
                if (saveAs)
                {
                    disposition = "attachment";
                }
                else
                {
                    disposition = "inline";
                }

                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", contentType);
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
                Response.BinaryWrite(buffer);
                Response.End();
            }
            else //  Generar Excel en formato .xlsx  -- JUAN FIGUEREDO 24-SEPT-2020
            {
                string NombreArchivo = "InformeGestion" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".xlsx";
                string name = AppDomain.CurrentDomain.BaseDirectory + "Excel.xlsx";
                SLDocument osldocument = new SLDocument();

                SLStyle style = new SLStyle();
                style.Font.FontSize = 12;
                style.Font.Bold = true;
                SLStyle styleCOL = new SLStyle();

                style = osldocument.CreateStyle();
                style.FormatCode = "dd/mm/yyyy hh:mm:ss ";

                DataTable dt = new DataTable();
                dt = (DataTable)Session["Datosss"];

                int ic = 1;
                //int i = 0;
                foreach (DataColumn column in dt.Columns)
                {
                    osldocument.SetCellStyle(1, ic, style);
                    osldocument.SetColumnWidth(ic, 20);
                    if (ic == 1) { column.ColumnName = "Radicado"; osldocument.SetColumnWidth(ic, 12); }
                    if (ic == 2) { column.ColumnName = "Fecha Radicacion"; }
                    if (ic == 4) { osldocument.SetColumnWidth(ic, 30); }
                    if (ic == 6) { column.ColumnName = "Fecha Vencimiento"; }
                    if (ic == 7) { column.ColumnName = "Dep.Actual"; }
                    ic++;
                }
                for (int i = 0; i < dt.Rows.Count + 2; i++)
                {
                    osldocument.SetCellStyle(i, 2, style);
                    osldocument.SetCellStyle(i, 6, style);
                    osldocument.SetCellStyle(i, 13, style);
                }

                osldocument.ImportDataTable(1, 1, dt, true);
                //osldocument.SaveAs(pathfile);
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //this.ASPxGridViewExporter1.WriteXls(stream);
                Response.AddHeader("Content-Disposition", "attachment; filename=" + NombreArchivo);
                osldocument.SaveAs(Response.OutputStream);
                Response.End();
                Session["Datosss"] = null;
            }
        }
        catch (Exception error)
        {
            this.ExceptionDetails.Text = "Se ha presentado un problema, por favor intente nuevamente o en su defecto realice una consulta con menor cantidad de registros.  " + error;
        }
    }

    protected void ASPxComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.AlfaWeb.SelectParameters["WFMovimientoFecha"].DefaultValue = "01/01/" + ASPxComboBox1.SelectedItem.Text;
        this.AlfaWeb.SelectParameters["WFMovimientoFecha1"].DefaultValue = "31/12/" + ASPxComboBox1.SelectedItem.Text;
        ConsultaRegistros.DataBind();
        AlfaWeb.Dispose();
        ConsultaRegistros.Dispose();

    }


    protected void ASPxComboBox1_DataBound(object sender, EventArgs e)
    {
        ASPxComboBox1.SelectedIndex = ASPxComboBox1.Items.Count - 1;
    }
}
