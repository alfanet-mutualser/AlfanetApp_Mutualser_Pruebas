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
// Referencias SpreadsheetLigth y DocumentFormat.openXML
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using DevExpress.Web.ASPxGridView;

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

        if (!IsPostBack)
        {
			this.RadDatePicker1.SelectedDate = Convert.ToDateTime("01/" + "01/" + DateTime.Now.Year.ToString()); 
            this.RadDatePicker2.SelectedDate = DateTime.Now;

            DataTable tabla = ((DataView)AlfaWeb.Select(DataSourceSelectArguments.Empty)).Table;
            Session["Datosss"] = tabla;

            //LOG ACCESO
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
            string Datosfin1 = " Reporte Radicadores.";
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Insert Log Acceso Dinamicos repor radicadores
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Acceso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            Acceso.InsertReportes(LogId, username, Fechain, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
            //Actualiza consecutivo
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        else
        {
            //ASPxGridView1.Settings.filter AutoFilterCondition = DevExpress.Web.ASPxGridView.AutoFilterCondition.Contains;

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
            Session["DatosUpdate"] = dt;

            DataTable tabla = ((DataView)AlfaWeb.Select(DataSourceSelectArguments.Empty)).Table;
            Session["Datosss"] = tabla;
            //DataSet ds = new DataSet();
            //ds.Tables.Add(tabla);

            //DataView _filter = new DataView(ds.Tables[0]);
            //if (!string.IsNullOrEmpty("RadicadoCodigo"))
            //{
            //    _filter.RowFilter = "Category = '" + category + "'";
            //}
            //_filter.RowFilter = string.Format();
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
                string NombreArchivo = "ReporteRadicadores" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".xlsx";
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
                foreach (DataColumn column in dt.Columns)
                {
                    osldocument.SetCellStyle(1, ic, style);
                    osldocument.SetColumnWidth(ic, 20);
                    if (ic == 1) { column.ColumnName = "Documento"; osldocument.SetColumnWidth(ic, 12); }
                    if (ic == 2) { column.ColumnName = "Grupo"; }
                    if (ic == 3) { column.ColumnName = "Fecha Radicacion"; }
                    if (ic == 4) { osldocument.SetColumnWidth(ic, 75); }
                    if (ic == 6) { column.ColumnName = "Digitador"; }
                    ic++;
                }
                for (int i = 0; i < dt.Rows.Count + 2; i++)
                {
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

    //protected void Export(Boolean saveAs)
    //{
    //    DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint();
    //    MemoryStream stream = new MemoryStream();
    //    //this.ASPxGridViewExporter1.op
    //    //this.ASPxGridViewExporter1.OptionsPrint.PrintHeadersOnEveryPage = true;
    //    //this.ASPxGridViewExporter1.OptionsPrint.PrintFilterHeaders = DefaultBoolean.True;
    //    //this.ASPxGridViewExporter1.OptionsPrint.PrintColumnHeaders = DefaultBoolean.True;
    //    //this.ASPxGridViewExporter1.OptionsPrint.PrintRowHeaders = DefaultBoolean.True;
    //    //this.ASPxGridViewExporter1.OptionsPrint.PrintDataHeaders = DefaultBoolean.True;

    //    String contentType = "";
    //    String fileName = "";

    //    try
    //    {
    //        int caseSwitch = 1;
    //        if (this.listExportFormat.SelectedIndex != 1)
    //        {
    //            switch (this.listExportFormat.SelectedIndex)
    //            {
    //                case 0:
    //                    contentType = "application/pdf";
    //                    fileName = "PivotGrid.pdf";
    //                    this.ASPxGridViewExporter1.WritePdf(stream);
    //                    break;
    //                case 1:
    //                    contentType = "application/ms-excel";
    //                    fileName = "PivotGrid.xls";
    //                    this.ASPxGridViewExporter1.WriteXls(stream);
    //                    break;
    //                case 2:
    //                    contentType = "text/enriched";
    //                    fileName = "PivotGrid.rtf";
    //                    this.ASPxGridViewExporter1.WriteRtf(stream);
    //                    break;
    //                case 3:
    //                    contentType = "text/plain";
    //                    fileName = "PivotGrid.txt";
    //                    this.ASPxGridViewExporter1.WriteCsv(stream);
    //                    break;
    //            }
    //            Byte[] buffer = stream.GetBuffer();
    //            // Dim buffer() As Byte = stream.GetBuffer()

    //            String disposition;
    //            if (saveAs)
    //            {
    //                disposition = "attachment";
    //            }
    //            else
    //            {
    //                disposition = "inline";
    //            }

    //            Response.Clear();
    //            Response.Buffer = false;
    //            Response.AppendHeader("Content-Type", contentType);
    //            Response.AppendHeader("Content-Transfer-Encoding", "binary");
    //            Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
    //            Response.BinaryWrite(buffer);
    //            Response.End();
    //        }
    //        else //  Generar Excel en formato .xlsx  -- JUAN FIGUEREDO 24-SEPT-2020
    //        {
    //            string NombreArchivo = "ReporteRadicadores" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".xlsx";
    //            string name = AppDomain.CurrentDomain.BaseDirectory + "Excel.xlsx";
    //            SLDocument osldocument = new SLDocument();

    //            SLStyle style = new SLStyle();
    //            style.Font.FontSize = 12;
    //            style.Font.Bold = true;
    //            SLStyle styleCOL = new SLStyle();

    //            style = osldocument.CreateStyle();
    //            style.FormatCode = "dd/mm/yyyy hh:mm:ss ";

    //            DataTable dt = new DataTable();
    //            List<string> dataColumnNames = new List<string>();
    //            foreach (GridViewColumn item in ASPxGridView1.Columns)
    //            {
    //                GridViewEditDataColumn dataColumn = item as GridViewEditDataColumn;
    //                if (dataColumn != null)
    //                {
    //                    dt.Columns.Add(dataColumn.FieldName);
    //                    dataColumnNames.Add(dataColumn.FieldName);
    //                }
    //            }
    //            for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
    //            {
    //                //for (int j = 0; j < ASPxGridView1.Columns.Count; j++)
    //                //{
    //                //    if (ASPxGridView1.Rows[i].Cells[j].Value == null)
    //                //    {

    //                //    }
    //                //}
    //                object[] rowValues = ASPxGridView1.GetRowValues(i, dataColumnNames.ToArray()) as object[];
    //                dt.Rows.Add(rowValues);
    //            } 
    //            int ic = 1;
    //            //int i = 0;
    //            foreach (DataColumn column in dt.Columns)
    //            {
    //                osldocument.SetCellStyle(1, ic, style);
    //                osldocument.SetColumnWidth(ic, 20);
    //                if (ic == 1) { column.ColumnName = "Documento"; osldocument.SetColumnWidth(ic, 12); }
    //                if (ic == 2) { column.ColumnName = "Grupo"; }
    //                if (ic == 3) { column.ColumnName = "Fecha Radicacion"; }
    //                if (ic == 4) { osldocument.SetColumnWidth(ic, 75); }
    //                if (ic == 6) { column.ColumnName = "Digitador"; }
    //                ic++;
    //            }
    //            for (int i = 0; i < dt.Rows.Count + 2; i++)
    //            {
    //                osldocument.SetCellStyle(i, 3, style);
    //            }

    //            osldocument.ImportDataTable(1, 1, dt, true);
    //            Session.Remove("Datosss");
    //            //osldocument.SaveAs(pathfile);
    //            Response.Clear();
    //            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //            //this.ASPxGridViewExporter1.WriteXls(stream);
    //            Response.AddHeader("Content-Disposition", "attachment; filename=" + NombreArchivo);
    //            osldocument.SaveAs(Response.OutputStream);
    //            Response.End();
    //        }
    //    }
    //    catch (Exception error)
    //    {
    //        this.ExceptionDetails.Text = "Se ha presentado un problema, por favor intente nuevamente o en su defecto realice una consulta con menor cantidad de registros.  " + error;
    //    }
    //}
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        //this.ConsultaRegistros.OptionsChartDataSource.ChartDataVertical = !CheckBox1.Checked;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
		this.ASPxGridView1.DataSourceID = "AlfaWeb";
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
        string Datosini = "Consultar Reporte radicadores entre FECHAS";//FechaIni + FechaFin
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
        //Insert log de consulta dinami repor radicadores
        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Consultar = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
        Consultar.InsertReportes(LogId, username, Fechain, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
        //Actualiza Consecutivo
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
    }
    //protected void ASPxGridView1_Load(object sender, EventArgs e)
    //{
    //   // ASPxGridView1.Settings.ShowFilterRowMenu = chkFilterRowMenu.Checked;
    //    ASPxGridView1.SettingsBehavior.FilterRowMode = (GridViewFilterRowMode)Enum.Parse(typeof(GridViewFilterRowMode), filterRowModeCombo.Text, true);
    //}
}
