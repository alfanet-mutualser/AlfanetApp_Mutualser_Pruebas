using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using AjaxControlToolKit;
using System.Net;
using System.Net.NetworkInformation;


public partial class _Prestamos : System.Web.UI.Page 
{
    PrestamosBLL Prestamos = new PrestamosBLL();
    DSPrestamos.PrestamosDataTable DTPrestamos = new DSPrestamos.PrestamosDataTable();
    string ModuloLog = "PRESTAMOS";
    string ConsecutivoCodigo = "11";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "ERROR";

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
                this.RFVPrestamo.ValidationGroup = "Buscar";
                this.cmdActualizar.Enabled = false;
                this.cmdAceptar.Enabled = true;
                this.TreeVSerie.Attributes["onClick"] = "return OnTreeClick(event);";
                this.TreeVDependencia.Attributes["onClick"] = "return OnTreeDependenciaClick(event);";

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
                string Datosini = "Acceso a modulo";
                string Datosfin1 = " Prestamos ";
                string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                DateTime FechaFin = DateTime.Now;
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Insert log acceso prestamos
                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Acceso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                Acceso.InsertPrestamosLog(LogId, username, Fechain, ActLogCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
                //Actualiza consecutivo
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
            else
            {

            }

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al acceder a prestamos  " + Error;
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
            Errores.GetError(LogIdErr, username, FechaInicio, ActividadLogCodigoErr, grupoo, ModuloLog, DatosFinales, WFMovimientoFechaFin, IP, NombreEquipo, Navegador);
            //Se hace el update consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
        }
        
    }
    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolSer = new ArbolesBLL();
        DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();
        DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
        PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(  0 );";
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    }
    protected void cmdAceptar_Click(object sender, EventArgs e)
    {
        this.cmdAceptar.Enabled = false;
        try
        {
            //DSPrestamos.PrestamosDataTable DTPrestamos = new DSPrestamos.PrestamosDataTable();
            String PrestamoCodigo = Prestamos.Create_Prestamos(null, "3", DateTime.Now, this.TxtBDependencia.Text, this.TxtBSerie.Text, TxtBCarpeta.Text);
            TxtBDependencia.Text = "";
            TxtBSerie.Text = "";
            //this.ODSPrestamos.InsertParameters["PrestamoCodigo"].DefaultValue = null;
            //this.ODSPrestamos.InsertParameters["GrupoCodigo"].DefaultValue = "3";
            //this.ODSPrestamos.InsertParameters["SerieCodigo"].DefaultValue = this.TxtBSerie.Text;
            //this.ODSPrestamos.InsertParameters["DependenciaCodigo"].DefaultValue = this.TxtBDependencia.Text;
            //this.ODSPrestamos.InsertParameters["WFMovimientoFecha"].DefaultValue = DateTime.Now.ToString();
            //this.ODSPrestamos.InsertParameters["PrestamoCarpeta"].DefaultValue = this.TxtBCarpeta.Text;

            //int PrestamoCodigo = this.ODSPrestamos.Insert();
            this.Label22.Text = "Prestamo Creado Número" + " " + PrestamoCodigo + " Hora de Prestamo: " + DateTime.Now.ToString();
            this.LblMessageBox.Text = "Prestamo Creado Número" + " " + PrestamoCodigo;
            this.ModalPopupExtender1.Show();

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema: No se puede Generar el prestamo, uno de los Datos ingresados no es correcto." + Error;
        }
        finally
        {
            this.cmdAceptar.Enabled = true;
        }
    }
   
    protected void cmdActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            String PrestamoCodigo = Prestamos.Update_Prestamos(this.TextBox1.Text, "3", Convert.ToDateTime(HFWFMovimientoFecha.Value), this.TxtBDependencia.Text, this.TxtBSerie.Text, TxtBCarpeta.Text, "1");

            this.LblMessageBox.Text = "Prestamo Actualizado Nro" + " " + PrestamoCodigo;
            this.ModalPopupExtender1.Show();
            //LOG ACTUALIZAR
            string ActLogCod = "ACTUALIZAR";
            DateTime Fechain = DateTime.Now;
            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            int NumeroDocumento = Convert.ToInt32("0");
            string Datosini = Session["InfoPrestamo"].ToString();
            //Serie para Prestamo + Carpeta + Dependencia para prestamo
            string Datosfin1 = TxtBSerie.Text + " | " + TxtBCarpeta.Text + " | " + TxtBDependencia.Text;
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            Session["Navega"] = Navegador;
            //Insert de log actualizar prestamo
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Update = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            Update.InsertPrestamosLog(LogId, username, Fechain, ActLogCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
            //Actualiza consecutivo
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al Actualizar prestamos  " + Error;
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
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/AlfaNetControlPrestamos/AlfaNetPrestamos/Prestamos.aspx");
        }
        catch (Exception err)
        {
            this.ExceptionDetails.Text = "Error: " + err.Message.ToString();
        }
    }


    protected void ImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            this.RFVPrestamo.ValidationGroup = "";
            this.cmdActualizar.Enabled = true;
            this.cmdAceptar.Enabled = false;
   
            if (TextBox1.Text != "")
            {
                if (TextBox1.Text.Contains(" | "))
                {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.IndexOf(" | "));
                }

            }
            DTPrestamos = Prestamos.GetPrestamosById(Convert.ToInt32(TextBox1.Text));
            
            DataRow[] rows = DTPrestamos.Select();

            this.TxtBSerie.Text = DTPrestamos.Rows[0].ItemArray[4].ToString().Trim()+" | "+ DTPrestamos.Rows[0].ItemArray[6].ToString().Trim();
            this.TxtBDependencia.Text = DTPrestamos.Rows[0].ItemArray[3].ToString().Trim() + " | " + DTPrestamos.Rows[0].ItemArray[7].ToString().Trim();
            this.TxtBCarpeta.Text = DTPrestamos.Rows[0].ItemArray[5].ToString().Trim();
            this.HFWFMovimientoFecha.Value = DTPrestamos.Rows[0].ItemArray[2].ToString().Trim();

            //LOG BUSCAR
            string ActLogCod = "BUSCAR";
            DateTime Fechain = DateTime.Now;
            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            int NumeroDocumento = Convert.ToInt32("0");
            string Datosini = "Busqueda: ";
            //Serie Prestamo + Carpeta + Dependencia prestamo
            string Datosfin1 = TxtBSerie.Text + " | " + TxtBCarpeta.Text + " | " + TxtBDependencia.Text;
            Session["InfoPrestamo"] = Datosfin1;
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Insert log buscar prestamos
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Find = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            Find.InsertPrestamosLog(LogId, username, Fechain, ActLogCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
            //Actualiza consecutivo
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

        }
        catch (Exception err)
        {
            this.ExceptionDetails.Text = "Error: " + err.Message.ToString();
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al buscar prestamos  " + err;
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
            Errores.GetError(LogIdErr, username, FechaInicio, ActividadLogCodigoErr, grupoo, ModuloLog, DatosFinales, WFMovimientoFechaFin, IP, NombreEquipo, Navegador);
            //Se hace el update consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
        }
    }
}
