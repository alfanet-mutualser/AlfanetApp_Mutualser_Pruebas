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
using System.Net;
using System.Net.NetworkInformation;

public partial class MainMaster : System.Web.UI.MasterPage
{
    string ConsecutivoCodigoErr = "4";
    DateTime WFMovimientoFecha = DateTime.Now;
    string ConsecutivoCodigo = "5";
    public void showmenu()
    {
        this.WebPanel2.Visible = true;
        this.SiteMapPath1.Visible = true;
        this.LoginViewAlfaNet.Visible = true;
        this.btnCerrar.Visible = false;
        this.LnkCerrar.Visible = false;
    }

    public void hidemenu()
    {
        this.WebPanel2.Visible = false;
        this.SiteMapPath1.Visible = false;
        this.LoginViewAlfaNet.Visible = false;
        this.btnCerrar.Visible = true;
        this.LnkCerrar.Visible = true;
    }

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
                //localIP = ip.ToString();
                //Session["IP"] = localIP;
            }
        }
        Session["Nombrepc"] = host.HostName.ToString();
        //if (!IsPostBack)
        //{
        
        //Page.Form.Attributes.Add("onload", "javascript:(window.close())");
        //}
        //else
        //{

        //}
        
        //UltraWebMenu1.Items[0].TargetUrl = "_blank";

        string Admon = Request["Admon"];
        if (Admon == "S")
        {
            Session["Admon"] = "S";
            hidemenu();
        }
        else if (WebPanel2.Visible = false)
        {
            //Session["Admon"] = "S";
            hidemenu();
        }
        else
        {
            showmenu();
           
        }
        Label m_label = (Label)this.LoginViewAlfaNet.FindControl("LblDependencia");
        if (m_label != null)
            m_label.Text = Profile.GetProfile(Profile.UserName).NombreDepUsuario.ToString() + " | ";
        
        if (SessionTimeOut.IsSessionTimedOut() == true)
            {
                IPHostEntry host1;
                string localIP1 = "";
                host1 = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host1.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP1 = ip.ToString();
                        HttpContext.Current.Session["IP"] = localIP1;
                    }
                }
                HttpContext.Current.Session["Nombrepc"] = host.HostName.ToString();

                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter LoginInicio = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();

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
                DateTime WFMovimientoFechaFin = DateTime.Now;
                string Datos = "LA SESION HA CADUCADO";
                string IP = HttpContext.Current.Session["IP"].ToString();
                string NombreEquipo = HttpContext.Current.Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = HttpContext.Current.Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                HttpContext.Current.Session["Navega"] = Navegador;
                string ActLogCod = "Cierre de Sesion";
                string UserId = Convert.ToString(LoginInicio.GetIdByDesconexion(ActLogCod, NombreEquipo, Navegador)); 
                LoginInicio.InsertarInicio(LogId,
                                            UserId,
                                            WFMovimientoFecha,
                                            ActLogCod,
                                            Datos,
                                            WFMovimientoFechaFin,
                                            IP,
                                            NombreEquipo,
                                            Navegador);

                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
               // m_label.Text = "El Tiempo de session ha caducado";
                //Response.Redirect("~", true);
				Session["UserName"] = null;
            } 
    }
    //CREAR METODO LoginStatus1_LoggingOut para cierre de sesión --Creado por Juan Figueredo 08-AGO-2019
    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        DateTime WFMovimientoFechaIn = DateTime.Now;
        DateTime WFMovimientoFecha = Convert.ToDateTime(WFMovimientoFechaIn.ToString("yyyy/MMM/dd HH:mm:ss"));
        string ActLogCod = "Cierre de Sesion";
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
        //AHORA OBTENER USERID
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UserId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
        DateTime WFMovimientoFechaFin = DateTime.Now;
        string Datos = "La sesión se ha finalizado satisfactoriamente";
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        Session["Navega"] = Navegador;
        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter LoginInicio = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
        LoginInicio.InsertarInicio(LogId, UserName, WFMovimientoFecha, ActLogCod, Datos, WFMovimientoFechaFin, IP, NombreEquipo, Navegador);

        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
		Session["UserName"] = null;
    }   
   
}
