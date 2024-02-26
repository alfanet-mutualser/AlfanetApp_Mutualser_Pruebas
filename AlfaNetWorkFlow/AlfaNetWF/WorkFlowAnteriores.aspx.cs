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
using System.Data;
using System.Net;
using System.Net.NetworkInformation;


public partial class _WorkFlowAnteriores : System.Web.UI.Page
{
    string ModuloLog = "Workflow Anteriores";
    string ConsecutivoCodigo = "9";
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
                localIP = ip.ToString();
                Session["IP"] = localIP;
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

            LblDocEnvExtCopia.Text = ((DataView)(ODSDocEnvExtCopia.Select())).Table.Rows.Count.ToString();
            LblDocEnvExt.Text = ((DataView)(ODSDocEnvExtCopia.Select())).Table.Rows.Count.ToString();
            
            LblDocEnvIntVen.Text = ((DataView)(ODSDocEnvIntVen.Select())).Table.Rows.Count.ToString();
            LblDocEnvInt.Text = LblDocEnvIntVen.Text;

            //LOG ACCESO
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
            int NumeroDocumento = 0;
            string GrupoCodigo = "";
            string Datosini = "Acceso a modulo de WORKFLOW ANTERIORES";
            string Datosfin1 = "";
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UserId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            Session["Navega"] = Navegador;
            //SE HACE INSERT DE LOG ACCESO WFANTERIORES
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            Accediendo.GetInsertLogWF(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCodigo, ModuloLog,
                                Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
            //SE ACTUALIZA CONSECUTIVO LOG
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
    
    protected void BtnTerminarCopEnvExt_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            TerminarCopia(GVDocEnvExtCopia, ODSDocEnvExtCopia, LblDocEnvExtCopia);
            LblDocEnvExt.Text = LblDocEnvExtCopia.Text;
            
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
    protected void BtnTerminarIntEnvVen_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            Terminartarea(GVDocEnvIntVen, ODSDocEnvIntVen, LblDocEnvIntVen);
            LblDocEnvInt.Text = Convert.ToInt16(LblDocEnvIntVen.Text).ToString();          
           
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
        ////////////////////////////////////////////////
    MembershipUser user = Membership.GetUser();
    Object CodigoRuta = user.ProviderUserKey;
    String UserId = Convert.ToString(CodigoRuta);
    ////////////////////////////////////////////////
        bool atLeastOneRowSelected = false;
        // Iterate through the Products.Rows property
        foreach (GridViewRow row in GV.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");

            Label Lb10 = (Label)row.FindControl("Label10");
            if (cb != null && cb.Checked)
            {
                //// Delete row! (Well, not really...)
                atLeastOneRowSelected = true;

                if (GV.DataKeys[row.RowIndex].Values[3].ToString() == "1")
                {
                   
                    //// First, get the DocumentID for the selected row
                    int mNumeroDocumento = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[0]);
                    //// por definir ...
                    TextBox TxtDepDesitno = (TextBox)row.Cells[8].FindControl("TxtCargarDocVen");

                    HiddenField mHFCarga = (HiddenField)row.Cells[8].FindControl("HFCargar");
                    if (TxtDepDesitno.Text != "")
                    {
                        if (TxtDepDesitno.Text.Contains(" | "))
                        {
                            TxtDepDesitno.Text = TxtDepDesitno.Text.Remove(TxtDepDesitno.Text.IndexOf(" | "));
                        }
                    }

                    string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();

                    TextBox TxtNewAccion = (TextBox)row.Cells[9].FindControl("TxtAccionDocExtVen");
                    string mWFAccionCodigo = TxtNewAccion.Text;
                    if (mWFAccionCodigo != "")
                    {
                        if (mWFAccionCodigo.Contains(" | "))
                        {
                            mWFAccionCodigo = mWFAccionCodigo.Remove(mWFAccionCodigo.IndexOf(" | "));
                        }
                    }
                    else
                    {
                        mWFAccionCodigo = null;
                    }

                    int mWFMovimientoPaso = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[2]);
                    int mWFMovimientoPasoActual = 1;
                    int mWFMovimientoPasoFinal = 0;


                    int mWFMovimientoTipoini = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[3]);

                    TextBox TxtNewNotas = (TextBox)row.Cells[6].FindControl("TextBox4");
                    string mWFMovimientoNotas = TxtNewNotas.Text;
                    string mGrupoCodigo = GV.DataKeys[row.RowIndex].Values[4].ToString();

                    // por definir ...
                    DateTime mWFMovimientoFecha = DateTime.Now;
                    DateTime mWFMovimientoFechaEst = DateTime.Now;
                    DateTime mWFFechaMovimientoFin = DateTime.Now;
                    // por definir ...
                    string mWFProcesoCodigo = null;

                    string mSerieCodigo;
                    string mDependenciaCodDestino;
                    string mWFMovimientoMultitarea;
                    int mWFMovimientoTipo;

                    if (mHFCarga.Value == "Dependencia" || mHFCarga.Value == "")
                    {
                        mDependenciaCodDestino = TxtDepDesitno.Text;
                        if (TxtDepDesitno.Text == "")
                            mDependenciaCodDestino = null;
                        mSerieCodigo = null;
                        mWFMovimientoMultitarea = "0";
                        mWFMovimientoTipo = 1;

                        DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                        TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                           mDependenciaCodDestino,
                                                           mWFMovimientoPaso,
                                                           mWFMovimientoPasoActual,
                                                           mWFMovimientoPasoFinal,
                                                           mWFFechaMovimientoFin,
                                                           mWFMovimientoTipo,
                                                           mWFMovimientoTipoini,
                                                           mWFMovimientoNotas,
                                                           mGrupoCodigo,
                                                           mDependenciaCodOrigen,
                                                           mWFProcesoCodigo,
                                                           mWFAccionCodigo,
                                                           mWFMovimientoFecha,
                                                           mWFMovimientoFechaEst,
                                                           mSerieCodigo,
                                                           mWFMovimientoMultitarea,
                                                           UserId);

                        MailBLL Correo = new MailBLL();
                        MembershipUser usuario;
                        DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuarioxDependencia = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                        DSUsuario.UsuariosxdependenciaDataTable DTUsuariosxDependencia = new DSUsuario.UsuariosxdependenciaDataTable();
            
                        DTUsuariosxDependencia = ObjTaUsuarioxDependencia.GetUsuariosxDependenciaByDependencia(mDependenciaCodDestino);
                        if (DTUsuariosxDependencia.Count > 0)
                        {
                            DataRow[] rows = DTUsuariosxDependencia.Select();
                            System.Guid a = new Guid(rows[0].ItemArray[0].ToString().Trim());
                            usuario = Membership.GetUser(a);
                            string Body = "Tiene una nueva Tarea Nro " + mNumeroDocumento + "<BR>" + " Fecha de Radicacion: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + " Accion: " + mWFAccionCodigo + "<BR>";
                            Correo.EnvioCorreo("soporte.archivar@gmail.com", usuario.Email, "Radicado Nro" + " " + mNumeroDocumento, Body, true, "1");
                        }
                        //LOG WORKFLOW ANTERIORES GESTIONAR A DEPENDENCIAS-13/06/2019 Juan Figueredo
                        string ActLogCod = "Gestionar a Dependencia";
                        DateTime WFMovimientoFecha = DateTime.Now;
                        //OBTENER CONSECUTIVO DE LOGS
                        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                        DataRow[] fila = Conse.Select();
                        string x = fila[0].ItemArray[0].ToString();
                        string LOG = Convert.ToString(x);
                        //Se Realiza el Log
                        int NumeroDocumento = mNumeroDocumento;
                        string GrupoCodigo = mGrupoCodigo;
                        string Datosini = "Gestion de documento";
                        /* Dependencia Destino+ Cargar a + PostIt+ Accion */
                        string Datosfin1 = mDependenciaCodDestino + " | " + TxtDepDesitno.Text + " | " + mWFMovimientoNotas + " | " + mWFAccionCodigo;
                        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                        string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                        DateTime FechaFin = DateTime.Now;
                        Int64 LogId = Convert.ToInt64(LOG);
                        string IP = Session["IP"].ToString();
                        string NombreEquipo = Session["Nombrepc"].ToString();
                        System.Web.HttpBrowserCapabilities nav = Request.Browser;
                        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                        //SE HACE INSERT DE LOG CONSULTAR
                        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                        Accediendo.GetInsertLogWF(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCodigo, ModuloLog,
                                            Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                        //SE ACTUALIZA CONSECUTIVO LOG
                        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                    }


                 
                    else if (mHFCarga.Value == "Serie")
                    {
                        if (TxtDepDesitno.Text == "")
                        {
                            mSerieCodigo = null;
                            mDependenciaCodDestino = null;

                        }
                        else
                        {
                            mSerieCodigo = TxtDepDesitno.Text;
                            mDependenciaCodDestino = mDependenciaCodOrigen;
                        }
                        mWFMovimientoMultitarea = "0";
                        mWFMovimientoTipo = 3;

                        DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                        TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                           mDependenciaCodDestino,
                                                           mWFMovimientoPaso,
                                                           mWFMovimientoPasoActual,
                                                           mWFMovimientoPasoFinal,
                                                           mWFFechaMovimientoFin,
                                                           mWFMovimientoTipo,
                                                           mWFMovimientoTipoini,
                                                           mWFMovimientoNotas,
                                                           mGrupoCodigo,
                                                           mDependenciaCodOrigen,
                                                           mWFProcesoCodigo,
                                                           mWFAccionCodigo,
                                                           mWFMovimientoFecha,
                                                           mWFMovimientoFechaEst,
                                                           mSerieCodigo,
                                                           mWFMovimientoMultitarea,
                                                           UserId);
                    }
                    else if (mHFCarga.Value == "Multitarea")
                    {
                        mWFMovimientoMultitarea = "1";
                        mSerieCodigo = null;
                        mDependenciaCodDestino = null;
                        mWFAccionCodigo = "2";
                        mWFMovimientoTipo = 2;

                        TreeView TreeMulti = (TreeView)row.Cells[8].FindControl("TreeVMultitarea");

                        foreach (TreeNode myNode in TreeMulti.CheckedNodes)
                        {
                            mDependenciaCodDestino = myNode.Value;

                            DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                            TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                               mDependenciaCodDestino,
                                                               mWFMovimientoPaso,
                                                               mWFMovimientoPasoActual,
                                                               mWFMovimientoPasoFinal,
                                                               mWFFechaMovimientoFin,
                                                               mWFMovimientoTipo,
                                                               mWFMovimientoTipoini,
                                                               mWFMovimientoNotas,
                                                               mGrupoCodigo,
                                                               mDependenciaCodOrigen,
                                                               mWFProcesoCodigo,
                                                               mWFAccionCodigo,
                                                               mWFMovimientoFecha,
                                                               mWFMovimientoFechaEst,
                                                               mSerieCodigo,
                                                               mWFMovimientoMultitarea,
                                                               UserId);
                        }
                    }

                    this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                    this.LblMessageBox.Text += " de su escritorio<br />";
                }
                else if (GV.DataKeys[row.RowIndex].Values[3].ToString() == "4")
                {
                    LinkButton LnkNro = (LinkButton)row.FindControl("LinkButton5");
                    int mNumeroDocumento = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[0]);
                    // por definir ...
                    //string mDependenciaCodDestino = "694";
                    int mWFMovimientoPaso = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[2]);
                    DateTime mWFFechaMovimientoFin = DateTime.Now;
                    int mWFMovimientoTipoini = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[3]);
                    // por definir ...
                    TextBox TxtNewNotas = (TextBox)row.Cells[6].FindControl("TextBox4");
                    string mWFMovimientoNotas = TxtNewNotas.Text;
                    string mGrupoCodigo = GV.DataKeys[row.RowIndex].Values[4].ToString();
                    string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                    string mWFProcesoCodigo = GV.DataKeys[row.RowIndex].Values[5].ToString();
                    // por definir ...
                    //string mWFAccionCodigo = "1";
                    DateTime mWFMovimientoFecha = DateTime.Now;
                    DateTime mWFMovimientoFechaEst = DateTime.Now;
                    // por definir ...
                    //string mSerieCodigo = null;
                    string mWFMovimientoMultitarea = "0";

                    DSWorkFlowTableAdapters.WFMovimientos_CreateRadicadoProcesosTableAdapter TAWFMovPro = new DSWorkFlowTableAdapters.WFMovimientos_CreateRadicadoProcesosTableAdapter();

                    TAWFMovPro.WFMovimientos_CreateRadicadoProcesos(mNumeroDocumento,
                                                                    mWFMovimientoPaso,
                                                                    1,
                                                                    0,
                                                                    mWFFechaMovimientoFin,
                                                                    mWFMovimientoTipoini,
                                                                    mWFMovimientoTipoini,
                                                                    mWFMovimientoNotas,
                                                                    mGrupoCodigo,
                                                                    mDependenciaCodOrigen,
                                                                    mWFProcesoCodigo,
                                                                    mWFMovimientoFecha,
                                                                    mWFMovimientoFechaEst,
                                                                    mWFMovimientoMultitarea);
                    this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                    this.LblMessageBox.Text += " de su escritorio<br />";
                }
                

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

    protected void TerminarCopia(GridView GV, ObjectDataSource ODS, Label LblLocal)
    {
        bool atLeastOneRowSelected = false;

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in GV.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectorDocumento");
                
                if (cb != null && cb.Checked)
                {
                    //if (GV.DataKeys[row.RowIndex].Values[3].ToString() == "2")
                    //{
                        // Delete row! (Well, not really...)
                        atLeastOneRowSelected = true;

                        // First, get the DocumentID for the selected row
                        int mNumeroDocumento = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[0]);
                       
                        int mWFMovimientoPaso = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[2]);
                        DateTime mWFFechaMovimientoFin = DateTime.Now;
                        int mWFMovimientoTipoini = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[3]);
                       
                        TextBox TxtNewNotas = (TextBox)row.Cells[6].FindControl("TextBox4");
                        string mWFMovimientoNotas = TxtNewNotas.Text;
                        string mGrupoCodigo = GV.DataKeys[row.RowIndex].Values[4].ToString();
                        string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                        
                     
                        DateTime mWFMovimientoFecha = DateTime.Now;
                        DateTime mWFMovimientoFechaEst = DateTime.Now;
                        
                        string mWFMovimientoMultitarea = "1";

                        DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                        TAWFMovimiento.WFMovimiento_UpdateWFMovimientoCopia(mNumeroDocumento,
                                                           mWFMovimientoPaso,
                                                           mWFFechaMovimientoFin,
                                                           mWFMovimientoTipoini,
                                                           mWFMovimientoNotas,
                                                           mGrupoCodigo,
                                                           mDependenciaCodOrigen,
                                                           mWFMovimientoMultitarea);

                        this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                        this.LblMessageBox.Text += " de su escritorio<br />";
                    //}
                    
                }
            }
            if (atLeastOneRowSelected == true)
                {
                    GV.DataBind();
                    ODS.DataBind();
                    LblLocal.Text = ((DataView)(ODS.Select())).Table.Rows.Count.ToString();
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
   
    protected void LnkBtnSelNingunoDocEnvExtCopia_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false, GVDocEnvExtCopia);
    }
    protected void LnkBtnSelTodosDocEnvExtCopia_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true, GVDocEnvExtCopia);
    }
    protected void LnkBtnSelNingunoDocEnvIntVen_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false, GVDocEnvIntVen);
    }
    protected void LnkBtnSelTodosDocEnvIntVen_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true, GVDocEnvIntVen);
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
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ODSDocRecExtVen.FilterExpression = null;

        if (RadioButtonList1.SelectedValue == "1")
        {
            this.AutoCompleteExtender2.ServiceMethod = "GetRadicadoByCodigo";
            this.TxtProcedencia.Text = "";
        }
        else if (RadioButtonList1.SelectedValue == "0")
        {
            this.AutoCompleteExtender2.ServiceMethod = "GetProcedenciaByTextNombre";
            this.TxtProcedencia.Text = "";
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            this.AutoCompleteExtender2.ServiceMethod = "GetNaturalezaByText";
            this.TxtProcedencia.Text = "";

        }
        this.TxtProcedencia.Focus();
            
    }
    protected void ODSDocRecExtVen_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
    {
        String CodProcedencia = TxtProcedencia.Text;
        if (TxtProcedencia.Text != "")
        {

            if (CodProcedencia != null)
            {
                if (CodProcedencia.Contains(" | "))
                {
                    CodProcedencia = CodProcedencia.Remove(CodProcedencia.IndexOf(" | "));
                }
            }
            e.ParameterValues.Clear();
            if (RadioButtonList1.SelectedValue == "0")
            {
                //ObjectDataSource1.FilterExpression = "ProcedenciaCodigo='{0}'";
                ODSDocRecExtVen.FilterExpression = "ProcedenciaCodigo='{0}'";
                e.ParameterValues.Add("ProcedenciaCodigo", CodProcedencia);

            }
            else if (RadioButtonList1.SelectedValue == "1")
            {
                //ObjectDataSource1.FilterExpression = "NumeroDocumento='{0}'";
                ODSDocRecExtVen.FilterExpression = "NumeroDocumento='{0}'";
                e.ParameterValues.Add("NumeroDocumento", CodProcedencia);
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                //e.ParameterValues.Clear();
                ODSDocRecExtVen.FilterExpression = "NaturalezaCodigo='{0}'";                
                e.ParameterValues.Add("NaturalezaCodigo", CodProcedencia);
            }
            //ODSDocRecExtVen_Filtering(sender,e);
            //this.ObjectDataSource1.FilterParameters["CodProcedencia"].DefaultValue = "11111111";
        }
        else
        {
            ODSDocRecExtVen.FilterExpression = null;
        }
    }
    protected void ImgBtnFindDependenciaExt_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtDependenciaExt.Text == "")
        {
            this.ODSDocEnvExtCopia.DataBind();
        }   
    }
    protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList3.SelectedValue == "1")
        {
            this.AutoCompleteExtender4.ServiceMethod = "GetRadicadoByCodigo";
            this.TxtDependenciaExt.Text = "";
        }
        else if (RadioButtonList3.SelectedValue == "0")
        {
            this.AutoCompleteExtender4.ServiceMethod = "GetDependenciaByText";
            this.TxtDependenciaExt.Text = "";

        }
        else if (RadioButtonList3.SelectedValue == "2")
        {
            this.AutoCompleteExtender4.ServiceMethod = "GetNaturalezaByText";
            this.TxtDependenciaExt.Text = "";

        }
    }    
    protected void ODSDocEnvExtCopia_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
    {
        String CodProcedencia = TxtDependenciaExt.Text;
        if (TxtDependenciaExt.Text != "")
        {

            if (CodProcedencia != null)
            {
                if (CodProcedencia.Contains(" | "))
                {
                    CodProcedencia = CodProcedencia.Remove(CodProcedencia.IndexOf(" | "));
                }
            }
            e.ParameterValues.Clear();
            if (RadioButtonList3.SelectedValue == "0")
            {
                ODSDocEnvExtCopia.FilterExpression = "DependenciaCodDestino='{0}'";
                e.ParameterValues.Add("DependenciaCodDestino", CodProcedencia);
            }
            else if (RadioButtonList3.SelectedValue == "1")
            {

                ODSDocEnvExtCopia.FilterExpression = "NumeroDocumento='{0}'";
                e.ParameterValues.Add("NumeroDocumento", CodProcedencia);
            }
            else if (RadioButtonList3.SelectedValue == "2")
            {

                ODSDocEnvExtCopia.FilterExpression = "NaturalezaCodigo='{0}'";
                e.ParameterValues.Add("NaturalezaCodigo", CodProcedencia);
            }
        }
        else
        {
            this.ODSDocEnvExtCopia.FilterExpression = null;

        }
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "1")
        {
            this.AutoCompleteExtender3.ServiceMethod = "GetRadicadoByCodigo";
            this.TxtDependencia.Text = "";
        }
        else if (RadioButtonList2.SelectedValue == "0")
        {
            this.AutoCompleteExtender3.ServiceMethod = "GetDependenciaByText";
            this.TxtDependencia.Text = "";

        }
        else if (RadioButtonList2.SelectedValue == "2")
        {
            this.AutoCompleteExtender3.ServiceMethod = "GetNaturalezaByText";
            this.TxtDependencia.Text = "";

        }
    }
    
    protected void ODSDocEnvIntCopia_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
    {
        String CodProcedencia = TxtDependencia.Text;
        if (TxtDependencia.Text != "")
        {

            if (CodProcedencia != null)
            {
                if (CodProcedencia.Contains(" | "))
                {
                    CodProcedencia = CodProcedencia.Remove(CodProcedencia.IndexOf(" | "));
                }
            }
            e.ParameterValues.Clear();
            if (RadioButtonList2.SelectedValue == "0")
            {
                ODSDocEnvIntVen.FilterExpression = "DependenciaCodOrigen='{0}'";

                e.ParameterValues.Add("DependenciaCodOrigen", CodProcedencia);
            }
            else if (RadioButtonList2.SelectedValue == "1")
            {

                ODSDocEnvIntVen.FilterExpression = "NumeroDocumento='{0}'";
              

                e.ParameterValues.Add("NumeroDocumento", CodProcedencia);
            }
            else if (RadioButtonList2.SelectedValue == "2")
            {

                ODSDocEnvIntVen.FilterExpression = "NaturalezaCodigo='{0}'";
             

                e.ParameterValues.Add("NaturalezaCodigo", CodProcedencia);
            }
        }
        else
        {
            this.ODSDocEnvIntVen.FilterExpression = null;
            //this.ODSDocEnvIntCopia.FilterExpression = null;
        }
    }
   
    protected void ImgBtnFindDependencia_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtDependencia.Text == "")
        {
            this.ODSDocEnvIntVen.DataBind();
        } 
    }
    protected void GVDocRecExtVen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink NroDoc = ((HyperLink)e.Row.FindControl("HyperLink1"));
            NroDoc.Attributes.Add("onClick", "url(event);");

            HyperLink Expediente = new HyperLink();

            Expediente.Text = GVDocRecExtVen.DataKeys[e.Row.RowIndex].Values[5].ToString();
            if (Expediente.Text == "")
            {
                Expediente.Text = "30001";
            }

            HiddenField Grupo = ((HiddenField)e.Row.FindControl("HFGrupo"));
            ((HyperLink)e.Row.FindControl("HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + "," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "Historico(event," + NroDoc.Text + "," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Text + "'," + Grupo.Value + ");");
        }        
    }
    protected void GVDocEnvExtCopia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink NroDoc = ((HyperLink)e.Row.FindControl("HyperLink1"));

            HyperLink Expediente = new HyperLink();
            String ID = e.Row.NamingContainer.ID;

            if (ID == "GVDocEnvExtCopia")
                Expediente.Text = GVDocEnvExtCopia.DataKeys[e.Row.RowIndex].Values[5].ToString();
            else
                Expediente.Text = GVDocEnvIntVen.DataKeys[e.Row.RowIndex].Values[5].ToString();
            if (Expediente.Text == "")
            {
                Expediente.Text = "30001";
            }
            
            HiddenField Grupo = ((HiddenField)e.Row.FindControl("HFGrupo"));
             NroDoc.Attributes.Add("onClick", "urlInt(event," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Text + "'," + Grupo.Value + ");");
        }
    }
}
