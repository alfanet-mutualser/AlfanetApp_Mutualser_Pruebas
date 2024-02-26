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

public partial class _ReporteCiudad : System.Web.UI.Page 
{
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "ERROR";
    string ModuloLog = "REPORTES";
    string ConsecutivoCodigo = "10";
    DateTime WFMovimientoFechaFin = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
            // Creo una colección de parámetros de tipo ReportParameter 
            // para añadirlos al control ReportViewer.

            List<ReportParameter> parametros = new List<ReportParameter>();
            // Añado los parámetros necesarios.
            parametros.Add(new ReportParameter("Fecha", DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString()));
            // Añado el/los parámetro/s al ReportViewer.
            this.ReportViewer1.LocalReport.SetParameters(parametros);

            // Creo uno o varios parámetros de tipo ReportParameter con sus valores.
            ReportParameter parametro = new ReportParameter("Fecha", DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
            // Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

            //this.ReportViewer1.AsyncRendering = false;
            //this.ReportViewer1.LocalReport.Refresh();
        }
        else
        {
            //this.ReportViewer1.AsyncRendering = true;
            //this.ReportViewer1.LocalReport.Refresh();
            return;
        }
        //LOG ACCESO
        string ActLogCod = "ACCESO";
        DateTime Fecha = DateTime.Now;
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
        string Datosfin1 = " Reportes Ciudad.";
        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
        DateTime FechaFin = DateTime.Now;
        Int64 LogId = Convert.ToInt64(LOG);
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        //Insert log acceso a reporte ciudad
        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter AccesoRepCiudad = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
        AccesoRepCiudad.InsertReportes(LogId, username, Fecha, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
        //Actualiza consecutivo
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception error)
        {
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al abrir reporte ciudad " + error;
            DateTime WFMovimientoFechaFin = DateTime.Now;
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConsecutivosErr = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable ConseErr = new DSGrupoSQL.ConsecutivoLogsDataTable();
            ConseErr = ConsecutivosErr.GetConseError(ConsecutivoCodigoErr);
            DataRow[] fila2 = ConseErr.Select();
            string z = fila2[0].ItemArray[0].ToString();
            string LOGERROR = Convert.ToString(z);
            Int64 LogIdErr = Convert.ToInt64(LOGERROR);
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            string IP = HttpContext.Current.Session["IP"].ToString();
            string NombreEquipo = HttpContext.Current.Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = HttpContext.Current.Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Se hace el insert de Log error
            DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter Errores = new DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter();
            Errores.GetError(LogIdErr, UsrId, FechaInicio, ActividadLogCodigoErr, grupoo, ModuloLog, DatosFinales, WFMovimientoFechaFin, IP, NombreEquipo, Navegador);
            //Se hace el update consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
        }
        
    }
   
}
