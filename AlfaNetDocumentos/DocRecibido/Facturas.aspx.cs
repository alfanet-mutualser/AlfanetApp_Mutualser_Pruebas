using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;

public partial class AlfaNetDocumentos_DocRecibido_Facturas : System.Web.UI.Page
{
    string GrpDocRad = "4";
    string ModuloLog = "Facturas";
    string ConsecutivoCodigo = "2";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "ERROR";
    string depCod = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    //localIP = ip.ToString();  antes se encontraba asÃ­ y tomaba Ip servidor
                    localIP = Request.UserHostAddress;
                    Session["IP"] = localIP;
                }
            }
            Session["Nombrepc"] = host.HostName.ToString();  //antes se encontraba asÃ­ y tomaba nombre servidor
            //Dns.BeginGetHostEntry(Request.UserHostAddress, new AsyncCallback(GetHostNameCallBack), Request.UserHostAddress);
            ////////////////////////////////////////////////
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserId = Convert.ToString(CodigoRuta);
            ////////////////////////////////////////////////        
            depCod = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
            string ActLogCod = "ACCESO";
            DateTime WFMovimientoFecha = DateTime.Now;
            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            //Se Realiza el Log
            int NumeroDocumento = Convert.ToInt32("0");
            string GrupoCod = "1";
            string Datosini = "";
            string Datosfin1 = "Acceso a modulo de Radicación Masiva de Facturas.";
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            //string UserId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            Session["Navega"] = Navegador;

            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            Accediendo.GetData(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog,
                                Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);

            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            if (Navegador.Contains("Explorer") || Navegador.Contains("explorer") || Navegador.Contains("IE"))
            {
                facturasFrame.Style.Add("display", "none");
                //IR A FUNCION JS A TRAVES DEL LINK
                HyperLink1.Attributes.Add("onClick", "url(" + "'" + depCod + "'" + ");");
                
                string script = "Timer();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, true);
            }
            else
            {
                facturasFrame.Attributes.Remove("class");
                facturasFrame.Attributes.Add("src", "http://192.168.200.34:443/Rad_Mas_Web/RadicacionMasiva/RadicacionMasiva.aspx?dep=" + depCod);
            }

        }
        else
        {
            //Alerta JS
                string jsFunc = "Timer();";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", jsFunc, true);
           
        }
    }


    public void GetHostNameCallBack(IAsyncResult asyncResult)
    {
        string userHostAddress = (string)asyncResult.AsyncState;
        System.Net.IPHostEntry hostEntry = System.Net.Dns.EndGetHostEntry(asyncResult);
        Session["Nombrepc"] = hostEntry.HostName;
        // tenemos el nombre del equipo cliente en hostEntry.HostName
    }


    protected void HyperLink1_Click(object sender, EventArgs e)
    {

    }
}
