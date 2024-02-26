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
using DevExpress.XtraExport;
using System.Drawing;
using DevExpress.Web.ASPxGridView;
// Referencias SpreadsheetLigth y DocumentFormat.openXML
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;


public partial class AlfaNetReportes_Dinamicos_ReporteDevoluciones : System.Web.UI.Page
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
        // System.Net.IPHostEntry hostEntry = Dns.GetHostEntry(Session["IP"].ToString());
        // Dns.BeginGetHostEntry(Request.UserHostAddress, new AsyncCallback(GetHostNameCallBack), Request.UserHostAddress);

        string FechaInicio = null;

        //WebChartControl1.SeriesDataMember = "Series";
        //WebChartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
        //WebChartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
        //ASPxGridView1.Settings.ShowFilterRowMenu = true;

        //ASPxGridView1.FilterExpression = "ProcedenciaDireccion = TRANS 60 Nº 114 A 55 and CiudadNombre = BOGOTA D.C.";

        if (!IsPostBack)
        {

            DataTable tabla = ((DataView)Procedimiento.Select(DataSourceSelectArguments.Empty)).Table;
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
            int NumeroDocumento = Convert.ToInt32("0");
            string GrupoCod = "";
            string Datosini = "Acceso a modulo";
            string Datosfin1 = " Reporte Devoluciones";
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Insert log acceso reporte devoluciones
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Acceso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            Acceso.InsertReportes(LogId, username, Fechain, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
            //Actuualiza consecutivo
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

        }
        else
        {
            //DataTable dtata = ((DataView)Procedimiento.Select(DataSourceSelectArguments.Empty)).Table;
            //Session["Datosss"] = dtata;
            DataTable dt = new DataTable();
            List<string> dataColumnNames = new List<string>();
            foreach (GridViewColumn item in ASPxGridView1.Columns)
            {
                GridViewEditDataColumn dataColumn = item as GridViewEditDataColumn;
                if (dataColumn != null)
                {
                    dt.Columns.Add(dataColumn.FieldName);
                    dataColumnNames.Add(dataColumn.FieldName);
                }
            }
            for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
            {
                object[] rowValues = ASPxGridView1.GetRowValues(i, dataColumnNames.ToArray()) as object[];
                dt.Rows.Add(rowValues);
            }
        }
    }
    // public void GetHostNameCallBack(IAsyncResult asyncResult)
    // {
        // string userHostAddress = (string)asyncResult.AsyncState;
        // System.Net.IPHostEntry hostEntry = System.Net.Dns.EndGetHostEntry(asyncResult);
        // Session["Nombrepc"] = hostEntry.HostName;
        // // tenemos el nombre del equipo cliente en hostEntry.HostName
    // }
    protected void ButtonOpen_Click(object sender, EventArgs e)
    {
        Export(false);
    }
    protected void ButtonSaveAs_Click(object sender, EventArgs e)
    {
        Export(true);
    }
    protected void Export(Boolean saveAs)
    {
        DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint();
        MemoryStream stream = new MemoryStream();
        //this.ASPxGridViewExporter1.op
        //this.ASPxGridViewExporter1.OptionsPrint.PrintHeadersOnEveryPage = true;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintFilterHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintColumnHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintRowHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintDataHeaders = DefaultBoolean.True;

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
                        this.ASPxGridViewExporter1.WritePdf(stream);
                        break;
                    case 1:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        this.ASPxGridViewExporter1.WriteXls(stream);
                        break;
                    case 2:
                        contentType = "text/enriched";
                        fileName = "PivotGrid.rtf";
                        this.ASPxGridViewExporter1.WriteRtf(stream);
                        break;
                    case 3:
                        contentType = "text/plain";
                        fileName = "PivotGrid.txt";
                        this.ASPxGridViewExporter1.WriteCsv(stream);
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
                string NombreArchivo = "ReporteDevoluciones" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".xlsx";
                string name = AppDomain.CurrentDomain.BaseDirectory + "Excel.xlsx";
                SLDocument osldocument = new SLDocument();

                SLStyle style = new SLStyle();
                style.Font.FontSize = 12;
                style.Font.Bold = true;
                SLStyle styleCOL = new SLStyle();

                style = osldocument.CreateStyle();
                style.FormatCode = "dd/mm/yyyy hh:mm:ss ";

                //DataTable dt = new DataTable();
                //dt = (DataTable)Session["Datosss"];
                DataTable dt = new DataTable();
                List<string> dataColumnNames = new List<string>();
                foreach (GridViewColumn item in ASPxGridView1.Columns)
                {
                    GridViewEditDataColumn dataColumn = item as GridViewEditDataColumn;
                    if (dataColumn != null)
                    {
                        dt.Columns.Add(dataColumn.FieldName);
                        dataColumnNames.Add(dataColumn.FieldName);
                    }
                }
                for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
                {
                    object[] rowValues = ASPxGridView1.GetRowValues(i, dataColumnNames.ToArray()) as object[];
                    dt.Rows.Add(rowValues);
                }

                int ic = 1;
                //int i = 0;
                foreach (DataColumn column in dt.Columns)
                {
                    osldocument.SetCellStyle(1, ic, style);
                    osldocument.SetColumnWidth(ic, 20);
                    if (ic == 1) { column.ColumnName = "Registro"; osldocument.SetColumnWidth(ic, 12); }
                    if (ic == 2) { column.ColumnName = "Fecha Devolucion"; }
                    if (ic == 3) { column.ColumnName = "Fecha Registro Devolucion"; }
                    if (ic == 4) { osldocument.SetColumnWidth(ic, 75); }
                    if (ic == 5) { column.ColumnName = "Procedencia"; }
                    if (ic == 6) { column.ColumnName = "Motivo Devolucion"; }
                    if (ic == 9) { column.ColumnName = "Dependencia Remitente"; }

                    ic++;
                }
                for (int i = 0; i < dt.Rows.Count + 2; i++)
                {
                    osldocument.SetCellStyle(i, 2, style);
                    osldocument.SetCellStyle(i, 3, style);

                }

                osldocument.ImportDataTable(1, 1, dt, true);
                Session.Remove("Datosss");
                //osldocument.SaveAs(pathfile);
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //this.ASPxGridViewExporter1.WriteXls(stream);
                Response.AddHeader("Content-Disposition", "attachment; filename=" + NombreArchivo);
                osldocument.SaveAs(Response.OutputStream);
                Response.End();
            }
        }
        catch (Exception error)
        {
            this.ExceptionDetails.Text = "Se ha presentado un problema, por favor intente nuevamente o en su defecto realice una consulta con menor cantidad de registros.  " + error;
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        //this.ConsultaRegistros.OptionsChartDataSource.ChartDataVertical = !CheckBox1.Checked;
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
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
        int NumeroDocumento = Convert.ToInt32("0");
        string GrupoCod = "";
        string Datosini = "Consultar reporte devoluciones entre fechas";//Fechaini + Fechafin
        string Datosfin1 = RadDatePicker1.DbSelectedDate.ToString() + " | " + RadDatePicker2.DbSelectedDate.ToString();
        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
        DateTime FechaFin = DateTime.Now;
        Int64 LogId = Convert.ToInt64(LOG);
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        //Insert log consulta reporte devoluciones
        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Consultar = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
        Consultar.InsertReportes(LogId, username, Fechain, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
        //Actualiza consecutivo
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
		
		this.Procedimiento.SelectParameters["WFMovimientoFecha"].DefaultValue = RadDatePicker1.DbSelectedDate.ToString();
        this.Procedimiento.SelectParameters["WFMovimientoFecha1"].DefaultValue = RadDatePicker2.DbSelectedDate.ToString();
		//this.ASPxGridView1.DataSourceID = "Procedimiento";
        this.ASPxGridView1.DataBind();
        // SetFilterESP(fieldNaturalezaNombre, ASPxComboBox1.SelectedItem.Value.ToString());
        // SetFilterESP(fieldYearGT, ASPxComboBox2.SelectedItem.Text);
        Procedimiento.Dispose();
        ASPxGridView1.Dispose();
    }



}






