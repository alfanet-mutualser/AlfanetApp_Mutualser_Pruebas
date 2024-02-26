using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
public partial class _ReporteUsuario : System.Web.UI.Page 
{
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "ERROR";
    string ModuloLog = "REPORTES";
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
                localIP = ip.ToString();
                Session["IP"] = localIP;
            }
        }
        Session["Nombrepc"] = host.HostName.ToString();
        if (!IsPostBack)
        {
            List<ReportParameter> parametros = new List<ReportParameter>();
            // Añado los parámetros necesarios.
            parametros.Add(new ReportParameter("Fecha", DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString()));
            // Añado el/los parámetro/s al ReportViewer.
            this.SerieReportViewer.LocalReport.SetParameters(parametros);

            // Creo uno o varios parámetros de tipo ReportParameter con sus valores.
            ReportParameter parametro = new ReportParameter("Fecha", DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
            // Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            this.SerieReportViewer.LocalReport.SetParameters(new ReportParameter[] { parametro });
        }
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
        //Se Realiza el Log
        int NumeroDocumento = Convert.ToInt32("0");
        string GrupoCod = "";
        string Datosini = "Acceso a modulo";
        string Datosfin1 = "Reportes Seguridad.";
        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
        DateTime FechaFin = DateTime.Now;
        Int64 LogId = Convert.ToInt64(LOG);
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        //Insert log acceso a repo seguridad
        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter AccesoSeg = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
        AccesoSeg.InsertReportes(LogId, username, Fechain, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
        //Actualiza consecutivo
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
    }
}
