using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.NetworkInformation;
public partial class _PasswordCambiar : System.Web.UI.Page 
{
    string ConsecutivoCodigo = "5";
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
        string ActLogCod = "ACCESO";
        DateTime WFMovimientoFechaIn = DateTime.Now;
        DateTime WFMovimientoFecha = Convert.ToDateTime(WFMovimientoFechaIn.ToString("yyyy/MMM/dd HH:mm:ss"));
        //OBTENER CONSECUTIVO DE LOGS
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
        DataRow[] fila = Conse.Select();
        string x = fila[0].ItemArray[0].ToString();
        string LOG = Convert.ToString(x);
        Int64 LogId = Convert.ToInt64(LOG);
        string nombreuser = Profile.GetProfile(Profile.UserName).UserName.ToString();
        Session["UserName"] = nombreuser;
        string UserName = Session["UserName"].ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UserId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
        DateTime WFMovimientoFechaFin = DateTime.Now;
        string Datos = "Acceso a modulo de cambio de password.";
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter LoginInicio = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
        LoginInicio.InsertarInicio(LogId, UserId, WFMovimientoFecha, ActLogCod, Datos, WFMovimientoFechaFin, IP, NombreEquipo, Navegador);

        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
    }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        string ActLogCod = "ACCESO";
        DateTime WFMovimientoFechaIn = DateTime.Now;
        DateTime WFMovimientoFecha = Convert.ToDateTime(WFMovimientoFechaIn.ToString("yyyy/MMM/dd HH:mm:ss"));
        //OBTENER CONSECUTIVO DE LOGS
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();

        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
        DataRow[] fila = Conse.Select();
        string x = fila[0].ItemArray[0].ToString();
        string LOG = Convert.ToString(x);
        Int64 LogId = Convert.ToInt64(LOG);
        string nombreuser = Profile.GetProfile(Profile.UserName).UserName.ToString();
        Session["UserName"] = nombreuser;
        string UserName = Session["UserName"].ToString();//AHORA OBTENER USERID
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UserId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();//FIN USERID
        DateTime WFMovimientoFechaFin = DateTime.Now;
        string Datos = "La nueva contraseña es: " + ChangePassword1.NewPassword.ToString();//Nueva contraseña
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();

        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter LoginInicio = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
        LoginInicio.InsertarInicio(LogId, UserId, WFMovimientoFecha, ActLogCod, Datos, WFMovimientoFechaFin, IP, NombreEquipo, Navegador);

        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
    }
}
