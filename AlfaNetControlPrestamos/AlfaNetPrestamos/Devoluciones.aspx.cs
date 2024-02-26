using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;
using ASP;
using Microsoft;
using Infragistics.Shared;
using Infragistics.WebUI.UltraWebGrid;
using System.Net;
using System.Net.NetworkInformation;


public partial class _Devoluciones : System.Web.UI.Page
{
    PrestamosBLL Prestamos = new PrestamosBLL();
    DSPrestamos.PrestamosDataTable DTPrestamos = new DSPrestamos.PrestamosDataTable();
    string ModuloLog = "Prestamos DEVOLUCIONES";
    string ConsecutivoCodigo = "11";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "ERROR";

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

        if (!Page.IsPostBack)
        {
                       
            this.HFmGrupo.Value = "1";
            this.HFmTipo.Value = "1";
            this.HFmDepCod.Value = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
            this.HFmFecha.Value = DateTime.Now.ToString();

            LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();

            LblDocRecExt.Text = LblDocRecExtVen.Text;

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
            string Datosfin1 = " Devoluciones ";
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Insert log acceso a devoluciones
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

    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    }
     
   
    protected void TreeVAccion_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter TADSWFA = new DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter();
        DSAccion.WFAccion_SelectByTextDataTable DTWFAccion = new DSAccion.WFAccion_SelectByTextDataTable();
        DTWFAccion = TADSWFA.GetWFAccionTreeDataBy(e.Node.Value);
        PopulateNodes(DTWFAccion, e.Node.ChildNodes, "WFAccionCodigo", "WFAccionNombre");
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
            //dr["title"].ToString();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(0);";
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
 
    protected void BtnTerminarDocrecVen_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            Terminartarea(GVDocRecExtVen, ODSDocRecExtVen, LblDocRecExtVen);
           
        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            this.MPEMensaje.Show();
        }
        finally
        {

        }
    }  
  
    
    protected void Terminartarea(GridView GV,ObjectDataSource ODS,Label LblLocal)
    {
        bool atLeastOneRowSelected = false;
        // Iterate through the Products.Rows property
        foreach (GridViewRow row in GV.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");

          
            if (cb != null && cb.Checked)
            {
                //// Delete row! (Well, not really...)
                atLeastOneRowSelected = true;
              
                    //// First, get the DocumentID for the selected row
                    int mPrestamoCodigo= Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[0]);

                    string mDependenciaCodigo = GV.DataKeys[row.RowIndex].Values[2].ToString();
                    string mGrupoCodigo = GV.DataKeys[row.RowIndex].Values[5].ToString();

                    // por definir ...
                    DateTime mWFMovimientoFecha = Convert.ToDateTime(GV.DataKeys[row.RowIndex].Values[1].ToString());
                    DateTime mWFMovimientoFechaDevolucion = DateTime.Now;
                   
                    string mSerieCodigo =  GV.DataKeys[row.RowIndex].Values[3].ToString();
                    string mPestamoCarpeta = GV.DataKeys[row.RowIndex].Values[4].ToString();

                    String PrestamoCodigo = Prestamos.Terminar_Prestamos(Convert.ToString(mPrestamoCodigo), mGrupoCodigo, mWFMovimientoFechaDevolucion, "0");

                
                        MailBLL Correo = new MailBLL();
                        MembershipUser usuario;
                        DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuarioxDependencia = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                        DSUsuario.UsuariosxdependenciaDataTable DTUsuariosxDependencia = new DSUsuario.UsuariosxdependenciaDataTable();
            
                        DTUsuariosxDependencia = ObjTaUsuarioxDependencia.GetUsuariosxDependenciaByDependencia(mDependenciaCodigo);
                        if (DTUsuariosxDependencia.Count > 0)
                        {
                            try
                            {
                                DataRow[] rows = DTUsuariosxDependencia.Select();
                                System.Guid a = new Guid(rows[0].ItemArray[0].ToString().Trim());
                                usuario = Membership.GetUser(a);
                                string Body = "Realizo la Devolucion del Prestamo Nro " + mPrestamoCodigo + "<BR>" + " Fecha de Prestamo: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                                Correo.EnvioCorreo("alfanet@mutualser.org", usuario.Email, "Radicado Nro" + " " + mPrestamoCodigo, Body, true, "1");

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
                                string Datosini = "Terminar Devoluciones";
                                //Prestamo Codigo + Fecha Prestamo + Fecha Devolucion + Carpeta + Serie + DependenciaCodigo
                                string Datosfin1 = PrestamoCodigo + " | " + mWFMovimientoFecha + " | " + mWFMovimientoFechaDevolucion + " | " + mPestamoCarpeta + " | " + mSerieCodigo + " | " + mDependenciaCodigo;
                                string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                                string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                                DateTime FechaFin = DateTime.Now;
                                Int64 LogId = Convert.ToInt64(LOG);
                                string IP = Session["IP"].ToString();
                                string NombreEquipo = Session["Nombrepc"].ToString();
                                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                                //Insert log Actualizar
                                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Acceso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                                Acceso.InsertPrestamosLog(LogId, username, Fechain, ActLogCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
                                //Actualiza consecutivo
                                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                            }
                            catch (Exception err)
                            {
                                //Variables de LOG ERROR
                                DateTime FechaInicio = DateTime.Now;
                                string grupoo = "";
                                //OBTENER CONSECUTIVO DE LOGS
                                string DatosFinales = "Error al actualizar devoluciones  " + err;
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

                        this.LblMessageBox.Text += string.Format("Se descargo el Prestamo {0}", mPrestamoCodigo);
                    this.LblMessageBox.Text += " de su escritorio<br />";
               
                
            }
        }
        if (atLeastOneRowSelected == true)
        {
            ODS.DataBind();
            GV.DataBind();
            LblLocal.Text = ((DataView)(ODS.Select())).Table.Rows.Count.ToString();
            LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text).ToString());
            this.MPEMensaje.Show();
        }
        else
        {
            this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
            this.MPEMensaje.Show();
        }
        
       
    }

  
 
   
    private void ToggleCheckState(bool checkState, GridView GV)
    {
        // Iterate through the Products.Rows property
        foreach (GridViewRow row in GV.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
            if (cb != null)
                cb.Checked = checkState;
        }
    }
    protected void LnkBtnSelTodosGVDocRecExtVen_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true, GVDocRecExtVen);
    }
    protected void LnkBtnSelNingunoGVDocRecExtVen_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false, GVDocRecExtVen);
    } 
    protected void ImgBtnFindProcedencia_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtProcedencia.Text != "")
        {
            
        }
        else
        {
            this.ODSDocRecExtVen.DataBind();
        }
        
    }
    protected void GVDocRecExtVen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((CheckBox)e.Row.FindControl("SelectorDocumento")).Attributes.Add("onClick", "ColorRow(this);");

        }
    }
    protected void ImgBtnFindDependencia_Click(object sender, ImageClickEventArgs e)
    {
        if (TextBox5.Text != "")
        {

        }
        else
        {
            this.ObjectDataSource1.DataBind();
        }
    }
    
}
