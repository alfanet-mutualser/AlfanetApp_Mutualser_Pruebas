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

public partial class LoginIniciar : System.Web.UI.Page
{
    DateTime WFMovimientoFecha = DateTime.Now;
    string ConsecutivoCodigo = "5";
    string ConsecutivoCodigoErr = "4";
    protected void Page_Load(object sender, EventArgs e)
    {
        DSInfoTableAdapters.Info_ReadInfoTableAdapter TAInfo = new DSInfoTableAdapters.Info_ReadInfoTableAdapter();
        DSInfo.Info_ReadInfoDataTable DTInfo = new DSInfo.Info_ReadInfoDataTable();

        DTInfo = TAInfo.GetInfoAlfaNet();
        this.Label1.Text = "Licenciado a: " + DTInfo[0].empresa.ToString();
        //ARCHIVAR LTDA";

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
                
            }
        }
        Session["Nombrepc"] = host.HostName.ToString();

        if (!IsPostBack)
        {
            //Recordar el usuario de ser necesario
            HttpCookie LaCookie = null;
            LaCookie = this.Request.Cookies["alfaUsuario"];
            if (LaCookie != null)
            {
                TextBox alfaUsuario = (TextBox)Login1.FindControl("UserName");
                alfaUsuario.Text = LaCookie.Value;
            }

            LaCookie = this.Request.Cookies["alfaRecordar"];
            if (LaCookie != null && "true" == LaCookie.Value)
            {
                CheckBox alfaRecordar = (CheckBox)Login1.FindControl("RememberMe");
                alfaRecordar.Checked = true;
                Login1.RememberMeSet = true;
            }
        }
        

    }   
       
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        string ActLogCod = "Login Ingresar";
        try
        {
            HttpCookie LaCookie = null;
            CheckBox Recordarme = (CheckBox)Login1.FindControl("RememberMe");
            TextBox alfaUsuario = (TextBox)Login1.FindControl("UserName");
            TextBox alfaPassword = (TextBox)Login1.FindControl("Password");
            Session["UserName"] = alfaUsuario.Text;

            //COOKIE USERNAME
            HttpCookie Username = new HttpCookie("Username");
            Username.Value = alfaUsuario.Text;
            Response.Cookies.Add(Username);
            Username.Expires = DateTime.Now.AddDays(1);

            if (Recordarme.Checked)
            {
                //Preservar el deseo del usuario de recordar los datos
                LaCookie = new HttpCookie("alfaRecordar", "true");
                LaCookie.Expires = DateTime.Now.AddDays(5);
                this.Response.Cookies.Add(LaCookie);

                //Preservar el usuario
                LaCookie = new HttpCookie("alfaUsuario", alfaUsuario.Text.ToString());
                LaCookie.Expires = DateTime.Now.AddDays(5);
                this.Response.Cookies.Add(LaCookie);

                //Preservar el password
                LaCookie = new HttpCookie("alfaPassword", alfaPassword.Text.ToString());
                LaCookie.Expires = DateTime.Now.AddDays(5);
                this.Response.Cookies.Add(LaCookie);

            }
            else
            {
                LaCookie = new HttpCookie("alfaRecordar");
                LaCookie.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(LaCookie);
            
                LaCookie = new HttpCookie("alfaUsuario");
                LaCookie.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(LaCookie);
            
                LaCookie = new HttpCookie("alfaPassword");
                LaCookie.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(LaCookie);
            }
            string Datosfin = "Inicio Sesión Exitoso";
            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();

            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            Int64 LogId = Convert.ToInt64(LOG);
            string UserName = Session["UserName"].ToString();//AHORA OBTENER USERID
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UserId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
            DateTime WFMovimientoFechaIn = DateTime.Now;
            DateTime WFMovimientoFecha = Convert.ToDateTime(WFMovimientoFechaIn.ToString("yyyy/MMM/dd HH:mm:ss"));
            DateTime WFMovimientoFechaFin = DateTime.Now;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            Session["Navega"] = Navegador;
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter LoginInicio = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            LoginInicio.InsertarInicio(LogId,
                                        UserName,
                                        WFMovimientoFecha,
                                        ActLogCod,
                                        Datosfin,
                                        WFMovimientoFechaFin,
                                        IP,
                                        NombreEquipo,
                                        Navegador);

            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            string problema = "Problema" + Error;
            string Datos = problema;
            //OBTENER CONSECUTIVO DE LOGS ERROR Y REGISTRO DE LOG
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConsecutivosErr = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable ConseErr = new DSGrupoSQL.ConsecutivoLogsDataTable();
            ConseErr = ConsecutivosErr.GetConseError(ConsecutivoCodigoErr);
            DataRow[] fila2 = ConseErr.Select();
            string z = fila2[0].ItemArray[0].ToString();
            string LOGERROR = Convert.ToString(z);
            Int64 LogIdErr = Convert.ToInt64(LOGERROR);
            string UserName = Session["UserName"].ToString();
            DateTime WFMovimientoFechaFin = DateTime.Now;
            string Password = "";
            string IP = HttpContext.Current.Session["IP"].ToString();
            string NombreEquipo = HttpContext.Current.Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = HttpContext.Current.Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            HttpContext.Current.Session["Navega"] = Navegador;
            DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter LoginInicioErr = new DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter();
            LoginInicioErr.InsertLoginError(LogIdErr,
                                                UserName,
                                                Password,
                                                WFMovimientoFecha,
                                                ActLogCod,
                                                Datos,
                                                WFMovimientoFechaFin,
                                                IP,
                                                NombreEquipo,
                                                Navegador);


            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
        }
    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {
        string ActLogCod = "Login Error";
        TextBox alfaUsuario = (TextBox)Login1.FindControl("UserName");
        TextBox alfaPassword = (TextBox)Login1.FindControl("Password");
        MembershipUser Usuario = Membership.GetUser(alfaUsuario.Text);
        Session["UserName"] = alfaUsuario.Text;
        Session["Password"] = alfaPassword.Text;
        
        if(null != Usuario && !Usuario.IsApproved)
        {
            this.Login1.FailureText = "El intento de conexión falló, el usuario \"" + alfaUsuario.Text.ToString() + "\" está inactivo";
        }
        string Datos = "El intento de conexión falló, verifique sus datos e intente de nuevo";
        //OBTENER CONSECUTIVO DE LOGS
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConsecutivosErr = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        DSGrupoSQL.ConsecutivoLogsDataTable ConseErr = new DSGrupoSQL.ConsecutivoLogsDataTable();
        ConseErr = ConsecutivosErr.GetConseError(ConsecutivoCodigoErr);
        DataRow[] fila2 = ConseErr.Select();
        string z = fila2[0].ItemArray[0].ToString();
        string LOGERROR = Convert.ToString(z);
        Int64 LogIdErr = Convert.ToInt64(LOGERROR);
        string UserName = Session["UserName"].ToString();
        DateTime WFMovimientoFechaFin = DateTime.Now;
        string Password = Session["Password"].ToString();
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter LoginInicioErr = new DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter();
        LoginInicioErr.InsertLoginError(LogIdErr, UserName, Password, WFMovimientoFecha, ActLogCod, Datos, WFMovimientoFechaFin, IP, NombreEquipo, Navegador);

        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
    }
}
