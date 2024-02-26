using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

public partial class AlfanetPlantilla_PermisosPlantillas : System.Web.UI.Page
{
    string ModuloLog = "Plantillas Permiso";
    string ConsecutivoCodigo = "8";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "Error";

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
            string result = string.Empty;
            try
            {
                string plantillaCodigo = Request.QueryString["cod"];
                LoadPlantillaList();                
                if (plantillaCodigo != null)
                {
                    ddlPlantillas.SelectedValue = plantillaCodigo;                    
                    GetDependenciasByPlantillaCodigo(plantillaCodigo);
                }

                // LOG ACCESO
				string codigoPlantilla = "";
				string dependencia = "";
                string ActLogCod = "ACCESO";
                DateTime Fecha = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
                DateTime FechaFin = DateTime.Now;
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //INSERT DE LOG ACCESO PLANTILLA
                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter InsertaLogPermiso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                InsertaLogPermiso.InsertPlantillaPermiso(LogId, Fecha, UserName, ActLogCod, ModuloLog, codigoPlantilla, dependencia,
                                                IP, NombreEquipo, Navegador);
                //Actualiza consecutivo log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
            catch (Exception)
            {                
                lblMessage.Text = "Ocurrió un inconveniente al cargar los datos de inicio. Por favor intente nuevamente.";
                //Variables de LOG ERROR
                DateTime FechaInicio = DateTime.Now;
                string grupoo = "";
                //OBTENER CONSECUTIVO DE LOGS
                string DatosFinales = "Error log insertar " + lblMessage.Text;
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

    private void GetDependenciasByPlantillaCodigo(string plantillaCodigo)
    {
        BLLPlantillas bll = null;
        List<string> resultList = null;
        try
        {
            ClearList();
            bll = new BLLPlantillas();
            resultList = new List<string>();
            resultList = bll.GetDependenciasByPlantillaCodigo(plantillaCodigo);
            if (resultList.Count > 0)
            {
                foreach (string item in resultList)
                {
                    ltbDependencias.Items.Add(item);
                }
            }
        }
        catch (Exception ex)
        {            
            throw ex;
        }
    }

    private void cargarDependencias()
    {        
        List<ObjDependencia> dependencias = null;
        BLLPlantillas bll = null;
        string resultSave;
        try
        {
            bll = new BLLPlantillas();            
            dependencias = new List<ObjDependencia>();
            dependencias = bll.GetDependencias();
            bll.SaveObjectInCache("Dependencias", dependencias, out resultSave);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void LoadPlantillaList()
    {
        BLLPlantillas bll = null;
        DataSet data = null;
        try
        {
            bll = new BLLPlantillas();
            data = new DataSet();
            data = bll.LoadPlantillaList();
            ddlPlantillas.DataSource = data;
            ddlPlantillas.DataValueField = "Codigo";
            ddlPlantillas.DataTextField = "Descripcion";
            ddlPlantillas.DataBind();
            ddlPlantillas.Items.Insert(0,new ListItem("Seleccione...", string.Empty));
        }
        catch (Exception ex)
        {            
            throw ex;
        }
    }
    protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "INSERTAR";
        lblMessage.Text = string.Empty;
        BLLPlantillas bll = null;
        string codigoPlantilla = ddlPlantillas.SelectedValue;
        if (codigoPlantilla != "")
        {
            string dependencia = string.Empty;
            try
            {
                if (txtDependencias.Text.Trim() != "")
                {
                    if (ValidarDependencia(txtDependencias.Text.Trim()))
                    {
                        if (!ValidarRepetido(txtDependencias.Text.Trim()))
                        {
                            //
                            bll = new BLLPlantillas();
                            dependencia = txtDependencias.Text.Trim();
                            if (dependencia.ToString().Contains(" | "))
                            {
                                dependencia = dependencia.Remove(dependencia.IndexOf(" | "));
                            }
                            string guardo = bll.GuardarPermisosGeneral(codigoPlantilla, dependencia);
                            lblMessage.Text = guardo;

                            if (guardo == "Proceso finalizado correctamente.")
                            {
                                ltbDependencias.Items.Add(txtDependencias.Text.Trim());

                                //LOG INSERTAR PERMISO PLANTILLA
                                DateTime Fecha = DateTime.Now;
                                //OBTENER CONSECUTIVO DE LOGS
                                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                                DataRow[] fila = Conse.Select();
                                string x = fila[0].ItemArray[0].ToString();
                                string LOG = Convert.ToString(x);
                                string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
                                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                                string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
                                DateTime FechaFin = DateTime.Now;
                                Int64 LogId = Convert.ToInt64(LOG);
                                string IP = Session["IP"].ToString();
                                string NombreEquipo = Session["Nombrepc"].ToString();
                                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                                //INSERT DE LOG AÑADIR PERMISO PLANTILLA
                                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter InsertaLogPermiso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                                InsertaLogPermiso.InsertPlantillaPermiso(LogId, Fecha, UserName, ActLogCod, ModuloLog, codigoPlantilla, dependencia,
                                                                IP, NombreEquipo, Navegador);
                                //Actualiza consecutivo log
                                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                            }
                            txtDependencias.Text = string.Empty;
                        }
                        else
                        {
                            lblMessage.Text = "El dato que intenga ingresar ya existe en el listado.";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "La dependenciaque intenta ingresar no existe.";
                        txtDependencias.Text = string.Empty;
                    }
                }
                else
                {
                    lblMessage.Text = "Debe ingresar una dependencia válida.";
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "Ocurrió un error durante el proceso. Por favor intente nuevamente.";

                //Variables de LOG ERROR
                DateTime FechaInicio = DateTime.Now;
                string grupoo = "";
                //OBTENER CONSECUTIVO DE LOGS
                string DatosFinales = "Error log insertar " + lblMessage.Text;
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
        else
        {
            lblMessage.Text = "Debe seleccionar una plantilla.";
        }
    }

    private bool ValidarRepetido(string p)
    {
        try
        {
            if (p.Contains(" | "))
            {
                p = p.Remove(p.IndexOf(" | "));
            }
            foreach (ListItem item in ltbDependencias.Items)
            {
                if (item.ToString().Contains(" | "))
                {
                    string aux = item.ToString().Remove(item.ToString().IndexOf(" | "));
                    if (aux == p)
                    {
                        return true;
                    }
                }
                else
                {
                    if (item.ToString() == p)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private bool ValidarDependencia(string depCodigo)
    {
        BLLPlantillas bll = null;        
        try
        {
            bll = new BLLPlantillas();
            int i = bll.ValidarDependencia(depCodigo);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
        catch (Exception)
        {
            return false;
        }
    }
    protected void ibtnQuitarItem_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "ELIMINAR";
        lblMessage.Text = string.Empty;
        BLLPlantillas bll = null;
        string codigoPlantilla = ddlPlantillas.SelectedValue;
        if (codigoPlantilla != "")
        {
            string dependencia = string.Empty;
            try
            {
                dependencia = ltbDependencias.SelectedItem.ToString();
                if (dependencia.ToString().Contains(" | "))
                {
                    dependencia = dependencia.Remove(dependencia.IndexOf(" | "));
                }
                bll = new BLLPlantillas();
                string elimino = bll.EliminarPermisosGeneral(codigoPlantilla, dependencia);
                lblMessage.Text = elimino;
                if (elimino == "Proceso finalizado correctamente.")
                {
                    ltbDependencias.Items.Remove(ltbDependencias.SelectedItem);

                    //LOG ELIMINAR PERMISO PLANTILLAS
                    DateTime Fecha = DateTime.Now;
                    //OBTENER CONSECUTIVO DE LOGS
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                    Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                    DataRow[] fila = Conse.Select();
                    string x = fila[0].ItemArray[0].ToString();
                    string LOG = Convert.ToString(x);
                    string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
                    DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                    string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
                    DateTime FechaFin = DateTime.Now;
                    Int64 LogId = Convert.ToInt64(LOG);
                    string IP = Session["IP"].ToString();
                    string NombreEquipo = Session["Nombrepc"].ToString();
                    System.Web.HttpBrowserCapabilities nav = Request.Browser;
                    string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                    //insert de log elimianr permiso plantilla
                    DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter InsertaLogPermiso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                    InsertaLogPermiso.InsertPlantillaPermiso(LogId, Fecha, UserName, ActLogCod, ModuloLog, codigoPlantilla,
                                                    dependencia, IP, NombreEquipo, Navegador);
                    //Actualiza consecutivo Log
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "Ocurrió un error durante el proceso. Por favor intente nuevamente.";
                //Variables de LOG ERROR
                DateTime FechaInicio = DateTime.Now;
                string grupoo = "";
                //OBTENER CONSECUTIVO DE LOGS
                string DatosFinales = "Error log eliminar " + lblMessage.Text;
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
        else
        {
            lblMessage.Text = "Debe seleccionar una plantilla.";
        }
    }
    protected void ddlPlantillas_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        string plantillaCodigo = ddlPlantillas.SelectedValue;
        if (plantillaCodigo != "")
        {
            try
            {
                GetDependenciasByPlantillaCodigo(plantillaCodigo);
            }
            catch (Exception)
            {
                lblMessage.Text = "Ocurrió un error al cargar los permisos para la plantilla seleccionada.";
            }
        }
        else
        {
            ClearList();
        }
    }
    private void ClearList()
    {
        ltbDependencias.Items.Clear();
    }
}
