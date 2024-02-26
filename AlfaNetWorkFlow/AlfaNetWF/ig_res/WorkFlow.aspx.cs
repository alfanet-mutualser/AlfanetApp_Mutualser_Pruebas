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


public partial class _WorkFlow_old : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ////////////////////////////////////////////////
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserId = Convert.ToString(CodigoRuta);
            ////////////////////////////////////////////////
           // Label5.Visible = false;
           // Panel21.Visible = false;
            this.HFmGrupo.Value = "1";
            this.HFmTipo.Value = "1";
            this.HFmDepCod.Value = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
            this.HFmFecha.Value = DateTime.Now.ToString();         

            DataView dv = (DataView)SqlDSMultitarea.Select(DataSourceSelectArguments.Empty);
            string reorderedProducts = (string)dv.Table.Rows[0][0];
            if (reorderedProducts != null)
            {
                this.HFMultiTarea.Value = reorderedProducts;
            }
            else
            {
                this.HFMultiTarea.Value = "0";
            }


            //Recibidos
            //LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
            LblDocRecExtVen.Text = get_WFDowsCount((DataView)(ODSDocRecExtVen.Select()));
            //LblDocRecExtProxVen.Text = ((DataView)(ODSDocRecExtProxVen.Select())).Table.Rows.Count.ToString();
            LblDocRecExtProxVen.Text = get_WFDowsCount((DataView)(ODSDocRecExtProxVen.Select()));
            //LblDocRecExtPen.Text = ((DataView)(ODSDocRecExtPen.Select())).Table.Rows.Count.ToString();
            LblDocRecExtPen.Text = get_WFDowsCount((DataView)(ODSDocRecExtPen.Select()));
            //LblDocRecCopia.Text = ((DataView)(ODSDocRecCopia.Select())).Table.Rows.Count.ToString();
            LblDocRecCopia.Text = get_WFDowsCount((DataView)(ODSDocRecCopia.Select()));

            //Enviados
            //LblDocEnvExtCopia.Text = ((DataView)(ODSDocEnvExtCopia.Select())).Table.Rows.Count.ToString();
            LblDocEnvExtCopia.Text = get_WFDowsCount((DataView)(ODSDocEnvExtCopia.Select()));
            //LblDocEnvExt.Text = ((DataView)(ODSDocEnvExtCopia.Select())).Table.Rows.Count.ToString();
            LblDocEnvExt.Text = get_WFDowsCount((DataView)(ODSDocEnvExtCopia.Select()));
            //LblDocCopiaInt.Text = ((DataView)(ODSDocEnvIntCopia.Select())).Table.Rows.Count.ToString();
            LblDocCopiaInt.Text = get_WFDowsCount((DataView)(ODSDocEnvIntCopia.Select()));
            //LblDocEnvIntVen.Text = ((DataView)(ODSDocEnvIntVen.Select())).Table.Rows.Count.ToString();
            LblDocEnvIntVen.Text = get_WFDowsCount((DataView)(ODSDocEnvIntVen.Select()));
            LblDocEnvInt.Text = (Convert.ToInt16(LblDocCopiaInt.Text) + Convert.ToInt16(LblDocEnvIntVen.Text)).ToString();

            //Total Recibidos
            LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text) + Convert.ToInt16(LblDocRecExtProxVen.Text) + Convert.ToInt16(LblDocRecExtPen.Text) + Convert.ToInt16(LblDocRecCopia.Text)).ToString();
                        
        }
        else
        {

        }
        

    }

    /*Metodo para obtener el total de resultados por objectdatasource*/
    protected string get_WFDowsCount(DataView v1)
    {
        int res = 0;
        if(v1.Table.Rows.Count > 0)
        {
            int columnas = v1.Table.Columns.Count;
            res = int.Parse(v1.Table.Rows[0].ItemArray[columnas - 1].ToString());
        }
        return res.ToString();
    }


    /*metodo para insertar el número máximo de elementos por página*/
    protected void ODSDocRecExtVen_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (!e.ExecutingSelectCount)
        {
            e.Arguments.MaximumRows = 10;
            e.InputParameters.Add("e", e);
        }
    }

    protected void ODSDocRecExtVen_Selecting2(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (!e.ExecutingSelectCount)
        {
            e.Arguments.MaximumRows = 10;
            e.InputParameters.Add("e", e);
        }
    }
    //---

    protected void TreeVDependencia_SelectedNodeChanged(object sender, EventArgs e)
    {
        //TreeNode Vencidos;
        //if ((String.IsNullOrEmpty(this.tree
        //Vencidos = GVDocRecExtVen.Rows[0].ToString;
        //TreeView TreeVDependencia;
        //TreeView TreeMulti = (TreeView)GVR.Row.FindControl("TreeVMultitarea");
        TreeView TreeVDependencia = (TreeView)GVDocRecExtVen.FindControl("TreeVDependencia");
        
        if ((String.IsNullOrEmpty(TreeVDependencia.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVDependencia.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    //protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    //{
    //    ArbolesBLL ObjArbolDep = new ArbolesBLL();
    //    DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
    //    DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
    //    PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    //}
  
    //---

    
    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre","0");
    }
       
    protected void TreeVAccion_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter TADSWFA = new DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter();
        DSAccion.WFAccion_SelectByTextDataTable DTWFAccion = new DSAccion.WFAccion_SelectByTextDataTable();
        DTWFAccion = TADSWFA.GetWFAccionTreeDataBy(e.Node.Value);
        PopulateNodes(DTWFAccion, e.Node.ChildNodes, "WFAccionCodigo", "WFAccionNombre","0");
    }
    protected void BtnTerminarCop_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            TerminarCopia(GVDocRecExtCopia,ODSDocRecCopia,LblDocRecCopia);
            LblDocRecExt.Text = LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text) + Convert.ToInt16(LblDocRecExtProxVen.Text) + Convert.ToInt16(LblDocRecExtPen.Text) + Convert.ToInt16(LblDocRecCopia.Text)).ToString();          
                      
                      
        }
        catch (Exception Error)
        {
            //Display a user-friendly message
            this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento.<br/>";
            Exception inner = Error.InnerException;
            this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            this.LblMessageBox.Text += Error.Message.ToString();
            this.MPEMensaje.Show();
        }
        finally
        {

        }
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
            LblDocEnvInt.Text = (Convert.ToInt16(LblDocCopiaInt.Text) + Convert.ToInt16(LblDocEnvIntVen.Text)).ToString();          
           
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
    protected void BtnTerminarEnvIntCop_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            TerminarCopia(GVDocEnvIntCopia, ODSDocEnvIntCopia, LblDocCopiaInt);
            LblDocEnvInt.Text = (Convert.ToInt16(LblDocCopiaInt.Text) + Convert.ToInt16(LblDocEnvIntVen.Text)).ToString();          

            
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
        PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre", "1");
              
    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre, string SeleccionarNodo)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            //dr["title"].ToString();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(0);";

            if (SeleccionarNodo == "1")
            {
                if (Convert.ToInt32(dr["childnodecount"]) > 0)
                {
                    tn.SelectAction = TreeNodeSelectAction.None;
                    
                }
                else
                {
                }
            }
            else
            {
                //tn.NavigateUrl = "javascript:void(0);";
                tn.SelectAction = TreeNodeSelectAction.Select;
            }
                                
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
    protected void BtnTerminarDocRecProx_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            Terminartarea(GVDocRecExtProxVen, ODSDocRecExtProxVen, LblDocRecExtProxVen);

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
    protected void BtnTerminarDocRecPen_Click(object sender, EventArgs e)
    {
        try
        {

            this.LblMessageBox.Text = "";
            Terminartarea(GVDocRecExtPen, ODSDocRecExtPen, LblDocRecExtPen);
            

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
        try
        {        
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
                        else
                        {
                            TxtDepDesitno.Text = null;
                        }
                    }
                    else
                    {
                        TxtDepDesitno.Text = null;
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
                        else 
                        {
                            mWFAccionCodigo = null;
                            TxtNewAccion.Text = null;
                        }                       
                    }
                    else
                    {
                        mWFAccionCodigo = null;
                        TxtNewAccion.Text = null;
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

                    if ((mHFCarga.Value == "Dependencia" || mHFCarga.Value == "") && TxtDepDesitno.Text != "" && TxtNewAccion.Text != "")
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
                                                           UserId
                                                           );

                        this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                        this.LblMessageBox.Text += " de su escritorio<br />";
                        this.MPEMensaje.Show();                        
                        TreeView TreeMulti = (TreeView)row.Cells[8].FindControl("TreeVMultitarea");
                        
                            foreach (TreeNode myNode in TreeMulti.CheckedNodes)
                            {
                                mWFMovimientoMultitarea = "1";
                                mSerieCodigo = null;
                                mDependenciaCodDestino = null;
                                mWFAccionCodigo = "2";
                                if (mGrupoCodigo == "1")
                                {
                                    mWFMovimientoTipo = 2;
                                }
                                else if (mGrupoCodigo == "2")
                                {
                                    mWFMovimientoTipo = 6;
                                }

                                mDependenciaCodDestino = myNode.Value;

                                //DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
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
                                                                   UserId
                                                                   );
                            }


                            //MailBLL Correo = new MailBLL();
                            //MembershipUser usuario;
                            //DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuarioxDependencia = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                            //DSUsuario.UsuariosxdependenciaDataTable DTUsuariosxDependencia = new DSUsuario.UsuariosxdependenciaDataTable();

                            //DTUsuariosxDependencia = ObjTaUsuarioxDependencia.GetUsuariosxDependenciaByDependencia(mDependenciaCodDestino);
                            //if (DTUsuariosxDependencia.Count > 0)
                            //{
                            //    DataRow[] rows = DTUsuariosxDependencia.Select();
                            //    System.Guid a = new Guid(rows[0].ItemArray[0].ToString().Trim());
                            //    usuario = Membership.GetUser(a);
                            //    string Body = "Tiene una nueva Tarea Nro " + mNumeroDocumento + "<BR>" + " Fecha de Radicacion: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + " Accion: " + mWFAccionCodigo + "<BR>";
                            //    Correo.EnvioCorreo("soporte.archivar@gmail.com", usuario.Email, "Tarea Nro" + " " + mNumeroDocumento, Body, true, "1");
                            //}
                    }

                    else if (mHFCarga.Value == "Serie" && TxtDepDesitno.Text != "")
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
                        if (mWFAccionCodigo== null)
                        mWFAccionCodigo = "2";
                        DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                        TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                           mDependenciaCodDestino,
                                                           mWFMovimientoPaso,
                                                           0,
                                                           1,
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
                                                           UserId
                                                           );
                        this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                        this.LblMessageBox.Text += " de su escritorio<br />";
                        this.MPEMensaje.Show();
                    }
                    else if (mHFCarga.Value == "Finalizar")
                    {
                        mWFMovimientoMultitarea = "0";
                        //mWFAccionCodigo = "2";
                        DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

                        TAWFMovimiento.WFMovimiento_UpdateWFMovimientoCopia(mNumeroDocumento,
                                                           mWFMovimientoPaso,
                                                           mWFFechaMovimientoFin,
                                                           mWFMovimientoTipoini,
                                                           mWFMovimientoNotas,
                                                           mGrupoCodigo,
                                                           mDependenciaCodOrigen,
                                                           mWFMovimientoMultitarea);

                        this.LblMessageBox.Text += string.Format("Se descargó el documento {0}", mNumeroDocumento);
                        this.LblMessageBox.Text += " de su escritorio<br />";
                        this.MPEMensaje.Show();

                    }
                    else
                    {
                        this.LblMessageBox.Text += string.Format("Falta uno o mas parámetros para descargar el documento {0}.<br/>", mNumeroDocumento);
                        this.MPEMensaje.Show();
                    }

                    
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

                    this.LblMessageBox.Text += string.Format("Se descargó el documento {0}", mNumeroDocumento);
                    this.LblMessageBox.Text += " de su escritorio<br />";
                }
                

            }
        }
        if (atLeastOneRowSelected == true)
        {
            ODS.DataBind();
            GV.DataBind();
            //LblLocal.Text = ((DataView)(ODS.Select())).Table.Rows.Count.ToString();
            LblLocal.Text = get_WFDowsCount((DataView)(ODS.Select()));
            LblDocRecExt.Text = LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text) + Convert.ToInt16(LblDocRecExtProxVen.Text) + Convert.ToInt16(LblDocRecExtPen.Text) + Convert.ToInt16(LblDocRecCopia.Text)).ToString();
            this.MPEMensaje.Show();
        }
        else
        {
            this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
            this.MPEMensaje.Show();
        }
    }
    catch (Exception Error)
    {
        ODS.DataBind();
        GV.DataBind();
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

                        this.LblMessageBox.Text += string.Format("Se descargó el documento {0}", mNumeroDocumento);
                        this.LblMessageBox.Text += " de su escritorio<br />";
                    //}
                    
                }
            }
            if (atLeastOneRowSelected == true)
                {
                    GV.DataBind();
                    ODS.DataBind();
                    //LblLocal.Text = ((DataView)(ODS.Select())).Table.Rows.Count.ToString();
                    LblLocal.Text = get_WFDowsCount((DataView)(ODS.Select()));
                    this.MPEMensaje.Show();
                    
                }
            else
            {
                    this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
                    this.MPEMensaje.Show();
            }
    }
    protected void RowBound(GridView GV,GridViewRowEventArgs GVR)
    {
        // FORMATEA ROWS
            ((ImageButton)GVR.Row.FindControl("ImageButton3")).Attributes.Add("onClick", "urlRpta(event,1);");
            ((LinkButton)GVR.Row.FindControl("linkButton5")).Attributes.Add("onClick", "url(event,1);");
            //((HyperLink)GVR.Row.FindControl("HyperLink1")).Attributes.Add("onClick", "url(event);");

            //RequiredFieldValidator RFVCargar = ((RequiredFieldValidator)GVR.Row.FindControl("RFVCargar"));
            ((CheckBox)GVR.Row.FindControl("SelectorDocumento")).Attributes.Add("onClick", "ColorRow(this);");

            TextBox mCargar = ((TextBox)GVR.Row.FindControl("TxtCargarDocVen"));
            HiddenField mHFCarga = (HiddenField)GVR.Row.FindControl("HFCargar");

            ((TreeView)GVR.Row.FindControl("TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
            ((TreeView)GVR.Row.FindControl("TreeVSerie")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
            ((TreeView)GVR.Row.FindControl("TreeVMultitarea")).Attributes.Add("onClick", "return OnTreeClickMultitarea(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");

            TextBox LblNot = (TextBox)GVR.Row.Cells[5].FindControl("TxtDocNotasextven");
            Image ImgNot = (Image)GVR.Row.Cells[5].FindControl("ImgDocNotasExtVen");
            if (LblNot.Text == "")
            {
                ImgNot.Visible = false;
            }

            if (GV.DataKeys[GVR.Row.RowIndex].Values[3].ToString() == "1")
            {

            }
            else if (GV.DataKeys[GVR.Row.RowIndex].Values[3].ToString() == "4")
            {
                TextBox TCar = (TextBox)GVR.Row.Cells[8].FindControl("TxtCargarDocVen");
                TextBox TAcc = (TextBox)GVR.Row.Cells[9].FindControl("TxtAccionDocExtVen");
                TCar.Text = "Definido Por Proceso";
                TCar.Enabled = false;
                TAcc.Text = "Definido Por Proceso";
                TAcc.Enabled = false;
            }

        
    }
    protected void RowBoundVen(GridView GV, GridViewRowEventArgs GVR)
    {
        // FORMATEA ROWS
        ((ImageButton)GVR.Row.FindControl("ImageButton3")).Attributes.Add("onClick", "urlRpta(event);");
                
            HiddenField Grupo = ((HiddenField)GVR.Row.FindControl("HFGrupo"));
            HyperLink NroDoc = ((HyperLink)GVR.Row.FindControl("HyperLink1"));
            HyperLink Expediente =  new HyperLink();
            
            Expediente.Text = GV.DataKeys[GVR.Row.RowIndex].Values[6].ToString();
            if (Expediente.Text == "")
            {
                Expediente.Text = "30001";
            }            
            NroDoc.Attributes.Add("onClick", "url(event," + Grupo.Value + ");");
            ((LinkButton)GVR.Row.FindControl("linkButton5")).Attributes.Add("onClick", "url(event," + Grupo.Value + ");");
            ((HyperLink)GVR.Row.FindControl("HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + "," + Grupo.Value + ");");
            ((HyperLink)GVR.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "Historico(event," + NroDoc.Text + "," + Grupo.Value + ");");
            ((HyperLink)GVR.Row.FindControl("HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Text + "',"+ Grupo.Value + ");");
        
        TextBox mCargar = ((TextBox)GVR.Row.FindControl("TxtCargarDocVen"));
        HiddenField mHFCarga = (HiddenField)GVR.Row.FindControl("HFCargar");
        TextBox TAcc = (TextBox)GVR.Row.Cells[9].FindControl("TxtAccionDocExtVen");

        RequiredFieldValidator RFVCargar = ((RequiredFieldValidator)GVR.Row.FindControl("RFVCargar"));
        ((CheckBox)GVR.Row.FindControl("SelectorDocumento")).Attributes.Add("onClick", "ColorRowVen(this," + mCargar.ClientID + ","+TAcc.ClientID+");");

        ((TreeView)GVR.Row.FindControl("TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        ((TreeView)GVR.Row.FindControl("TreeVSerie")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");       

        TextBox LblNot = (TextBox)GVR.Row.Cells[5].FindControl("TxtDocNotasextven");
        Image ImgNot = (Image)GVR.Row.Cells[5].FindControl("ImgDocNotasExtVen");
        if (LblNot.Text == "")
        {
            ImgNot.Visible = false;
        }

        if (GV.DataKeys[GVR.Row.RowIndex].Values[3].ToString() == "1")
        {

        }
        else if (GV.DataKeys[GVR.Row.RowIndex].Values[3].ToString() == "4")
        {
            TextBox TCar = (TextBox)GVR.Row.Cells[8].FindControl("TxtCargarDocVen");
            
            TCar.Text = "Definido Por Proceso";
            TCar.Enabled = false;
            TAcc.Text = "Definido Por Proceso";
            TAcc.Enabled = false;
        }      
            Label LabelResuesta = ((Label)GVR.Row.FindControl("Label60"));
            Image Image1 = (Image)GVR.Row.FindControl("Image1");
            LinkButton LnkBtnGTRecibidas = ((LinkButton)GVR.Row.FindControl("LinkButton5"));
            //ListBox LstRpta = (ListBox)GVR.Row.FindControl("ListBox1");
            HyperLink HyperLink1 = (HyperLink)GVR.Row.FindControl("HyperLink1");
            HyperLink1.Attributes.Add("onClick", "url(event," + Grupo.Value + ");");
       
        if (LabelResuesta.Text == "0")
        {
            LabelResuesta.Text = "Sin Respuesta";
            Image1.Visible = false;
        }
        else if (Convert.ToInt32(LabelResuesta.Text) > 0)
        {
            Image1.Visible = true;
            Panel PnlRpta = ((Panel)GVR.Row.FindControl("PnlRpta"));
            DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
            DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
            DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(LnkBtnGTRecibidas.Text), Grupo.Value);

            int i = 1;
            foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
            {
                
                HyperLink HprRpta = new HyperLink();
                HprRpta.ID = "HprRpta" + i.ToString();
                HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();               
                HprRpta.Target = "_Blank";
                HprRpta.ForeColor = System.Drawing.Color.Blue;
                HprRpta.Font.Underline = true;
                HprRpta.Attributes.Add("onClick", "urlInt(event,"+DRRadFuenteReg.GrupoRegistroCodigo+");");   
                PnlRpta.Controls.Add(HprRpta);                
                PnlRpta.Controls.Add(new LiteralControl("<br />"));
                i += 1;
           }
            LabelResuesta.Text = "Con Respuesta";
        }
        if (HFMultiTarea.Value != "1")
        {
           TreeView TreeMulti = (TreeView)GVR.Row.FindControl("TreeVMultitarea");
           TreeMulti.Visible = false;
          
        }
               
        
    }
    protected void RowBoundCopia(GridViewRowEventArgs GVR)
    {
        
        HiddenField Grupo = ((HiddenField)GVR.Row.FindControl("HFGrupo"));
        ((LinkButton)GVR.Row.FindControl("linkButton5")).Attributes.Add("onClick", "url(event,"+Grupo.Value+");");
        HyperLink NroDoc = ((HyperLink)GVR.Row.FindControl("HyperLink1"));

        HyperLink Expediente = new HyperLink();

        Expediente.Text = GVDocRecExtCopia.DataKeys[GVR.Row.RowIndex].Values[6].ToString();
        if (Expediente.Text == "")
        {
            Expediente.Text = "30001";
        }          

        NroDoc.Attributes.Add("onClick", "url(event," + Grupo.Value + ");");
        ((HyperLink)GVR.Row.FindControl("HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)GVR.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "Historico(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)GVR.Row.FindControl("HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Text + "'," + Grupo.Value + ");");
        //((HyperLink)GVR.Row.FindControl("HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ");");
        CheckBox Chk = ((CheckBox)GVR.Row.FindControl("SelectorDocumento"));
        Chk.Attributes.Add("onClick", "ColorRow(this);");

        TextBox LblNot = (TextBox)GVR.Row.Cells[5].FindControl("TxtDocNotasextven");
        Image ImgNot = (Image)GVR.Row.Cells[5].FindControl("ImgDocNotasExtVen");
        if (LblNot.Text == "")
        {
            ImgNot.Visible = false;
        }

        Label LabelResuesta = ((Label)GVR.Row.FindControl("Label60"));
        Image Image1 = (Image)GVR.Row.FindControl("Image1");
        LinkButton LnkBtnGTRecibidas = ((LinkButton)GVR.Row.FindControl("LinkButton5"));
        //ListBox LstRpta = (ListBox)GVR.Row.FindControl("ListBox1");
        HyperLink HyperLink1 = (HyperLink)GVR.Row.FindControl("HyperLink1");
        HyperLink1.Attributes.Add("onClick", "url(event," + Grupo.Value + ");");

        if (LabelResuesta.Text == "0")
        {
            LabelResuesta.Text = "Sin Respuesta";
            Image1.Visible = false;
        }
        else if (Convert.ToInt32(LabelResuesta.Text) > 0)
        {
            Image1.Visible = true;
            Panel PnlRpta = ((Panel)GVR.Row.FindControl("PnlRpta"));
            DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
            DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
            DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(LnkBtnGTRecibidas.Text),Grupo.Value);

            int i = 1;
            foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
            {
                HyperLink HprRpta = new HyperLink();
                HprRpta.ID = "HprRpta" + i.ToString();
                HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
                HprRpta.Target = "_Blank";
                HprRpta.ForeColor = System.Drawing.Color.Blue;
                HprRpta.Font.Underline = true;
                HprRpta.Attributes.Add("onClick", "urlInt(event," + DRRadFuenteReg.GrupoRegistroCodigo + ");");
                PnlRpta.Controls.Add(HprRpta);
                PnlRpta.Controls.Add(new LiteralControl("<br />"));
                i += 1;
            }
            LabelResuesta.Text = "Con Respuesta";
        }

    }
    protected void RowBoundCopiaEnv(GridViewRowEventArgs GVR)
    {
        ((LinkButton)GVR.Row.FindControl("linkButton5")).Attributes.Add("onClick", "urlInt(event);");
        HyperLink NroDoc = ((HyperLink)GVR.Row.FindControl("HyperLink1"));

        HyperLink Expediente = new HyperLink();
        String ID = GVR.Row.NamingContainer.ID;

        if (ID == "GVDocEnvExtCopia")
        Expediente.Text = GVDocEnvExtCopia.DataKeys[GVR.Row.RowIndex].Values[5].ToString();
        else
        Expediente.Text = GVDocEnvIntCopia.DataKeys[GVR.Row.RowIndex].Values[5].ToString();
        if (Expediente.Text == "")
        {
            Expediente.Text = "30001";
        }       

        HiddenField Grupo = ((HiddenField)GVR.Row.FindControl("HFGrupo"));
        NroDoc.Attributes.Add("onClick", "urlInt(event," + Grupo.Value + ");");
        ((HyperLink)GVR.Row.FindControl("HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)GVR.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)GVR.Row.FindControl("HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Text + "'," + Grupo.Value + ");");
        CheckBox Chk = ((CheckBox)GVR.Row.FindControl("SelectorDocumento"));
        Chk.Attributes.Add("onClick", "ColorRow(this);");

        TextBox LblNot = (TextBox)GVR.Row.Cells[5].FindControl("TxtDocNotasextven");
        Image ImgNot = (Image)GVR.Row.Cells[5].FindControl("ImgDocNotasExtVen");
        if (LblNot.Text == "")
        {
            ImgNot.Visible = false;
        }
    }
    protected void GVDocRecExtProxVen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RowBoundVen(GVDocRecExtProxVen, e);
        }
    }
    protected void GVDocRecExtPen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RowBoundVen(GVDocRecExtPen, e);

        }
    }
    protected void GVDocRecExtVen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RowBoundVen(GVDocRecExtVen, e);
        }
    }
    protected void GVDocRecExtCopia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RowBoundCopia(e);
        }
    }
    protected void GVDocEnvIntVen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox mCargar = ((TextBox)e.Row.FindControl("TxtCargarDocVen"));
            TextBox TAcc = (TextBox)e.Row.FindControl("TxtAccionDocExtVen");
            // FORMATEA ROWS
            ((ImageButton)e.Row.FindControl("ImageButton3")).Attributes.Add("onClick", "urlRpta(event);");
            ((LinkButton)e.Row.FindControl("linkButton5")).Attributes.Add("onClick", "urlInt(event);");
            HyperLink NroDoc = ((HyperLink)e.Row.FindControl("HyperLink1"));

            HyperLink Expediente = new HyperLink();
            
            Expediente.Text = GVDocEnvIntVen.DataKeys[e.Row.RowIndex].Values[5].ToString();
          
            if (Expediente.Text == "")
            {
                Expediente.Text = "30001";
            }     

            HiddenField Grupo = ((HiddenField)e.Row.FindControl("HFGrupo"));
            NroDoc.Attributes.Add("onClick", "urlInt(event," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
            CheckBox Chk = ((CheckBox)e.Row.FindControl("SelectorDocumento"));
            Chk.Attributes.Add("onClick", "ColorRowVen(this," + mCargar.ClientID + "," + TAcc.ClientID + ");");
            ((HyperLink)e.Row.FindControl("HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Text + "'," + Grupo.Value + ");");
            
            HiddenField mHFCarga = (HiddenField)e.Row.FindControl("HFCargar");

            ((TreeView)e.Row.FindControl("TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
            //((TreeView)e.Row.FindControl("TreeVMultitarea")).Attributes.Add("onClick", "return OnTreeClickMultitarea(event," + mCargar.ClientID + "," + mHFCarga.ClientID + ");");
            ((TreeView)e.Row.FindControl("TreeVFinalizar")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
            TextBox LblNot = (TextBox)e.Row.Cells[5].FindControl("TxtDocNotasextven");
            Image ImgNot = (Image)e.Row.Cells[5].FindControl("ImgDocNotasExtVen");
            if (LblNot.Text == "")
            {
                ImgNot.Visible = false;
            }
            if (HFMultiTarea.Value != "1")
            {
                TreeView TreeMulti = (TreeView)e.Row.FindControl("TreeVMultitarea");
                TreeMulti.Visible = false;

            }
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
    protected void LnkBtnSelNingunoDocRecExtProxVen_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false, GVDocRecExtProxVen);
    }
    protected void LnkBtnSelTodosDocRecExtProxVen_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true, GVDocRecExtProxVen);
    }
    protected void LnkBtnSelNingunoDocRecExtPen_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false, GVDocRecExtPen);
    }
    protected void LnkBtnSelTodosDocRecExtPen_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true, GVDocRecExtPen);
    }
    protected void LnkBtnSelNingunoDocRecExtCopia_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false, GVDocRecExtCopia);
    }
    protected void LnkBtnSelTodosDocRecExtCopia_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true, GVDocRecExtCopia);
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
    protected void LnkBtnSelNingunoDocEnvIntCopia_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false, GVDocEnvIntCopia);
    }
    protected void LnkBtnSelTodosDocEnvIntCopia_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true, GVDocEnvIntCopia);
    }
    protected void GVDocEnvExtCopia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RowBoundCopiaEnv(e);
        }
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
    protected void ImgBtnFindDependencia_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtDependencia.Text == "")
        {
            this.ODSDocEnvIntVen.DataBind();
        }        
    }
    protected void ODSDocEnvIntVen_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
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
                //ODSDocEnvIntCopia.FilterExpression = "DependenciaCodOrigen='{0}'";                
                e.ParameterValues.Add("DependenciaCodOrigen", CodProcedencia);
            }
            else if (RadioButtonList2.SelectedValue == "1")
            {

                ODSDocEnvIntVen.FilterExpression = "NumeroDocumento='{0}'";
                //ODSDocEnvIntCopia.FilterExpression = "NumeroDocumento='{0}'";

                e.ParameterValues.Add("NumeroDocumento", CodProcedencia);
            }
            else if (RadioButtonList2.SelectedValue == "2")
            {

                ODSDocEnvIntVen.FilterExpression = "NaturalezaCodigo='{0}'";
                //ODSDocEnvIntCopia.FilterExpression = "NaturalezaCodigo='{0}'";

                e.ParameterValues.Add("NaturalezaCodigo", CodProcedencia);
            }
        }
        else
        {
            this.ODSDocEnvIntVen.FilterExpression = null;
            //this.ODSDocEnvIntCopia.FilterExpression = null;
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
                ODSDocEnvExtCopia.FilterExpression = "DependenciaCodOrigen='{0}'";
                e.ParameterValues.Add("DependenciaCodOrigen", CodProcedencia);
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
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        
       
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ObjectDataSource ODSDoc = ((ObjectDataSource)e.Row.FindControl("ObjectDataReadDocumentos"));
            Label mDato = ((Label)e.Row.FindControl("Label10"));
           
                ODSDoc.SelectParameters["DependenciaCodigo"].DefaultValue = mDato.Text;
                if (mDato.Text == "")
                {
                    Label5.Visible = false;
                    Panel21.Visible = false;
                    
                }
                else
                {
                    Label5.Visible = true;
                    Panel21.Visible = true;
                }
    
        }
    }
    protected void Label5_Init(object sender, EventArgs e)
    {
        
        //DSWorkFlow.WFMovimientos_ReadAllDependenciasDataTable Datos = new DSWorkFlow.WFMovimientos_ReadAllDependenciasDataTable();
        //DSWorkFlowTableAdapters.WFMovimientos_ReadAllDependenciasTableAdapter Tabla = new DSWorkFlowTableAdapters.WFMovimientos_ReadAllDependenciasTableAdapter();
        //Datos = Tabla.GetData(HFmDepCod);
    
       
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HiddenField Grupo;
        Grupo = HFmGrupo;
        HyperLink Expediente;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            //Expediente.Text = e.Row.
            //Expediente.Text = GV.DataKeys[GVR.Row.RowIndex].Values[6].ToString();
            //if (Expediente.Text == "")
            //{
            //    Expediente.Text = "30001";
            //}
            //HyperLink Expediente = ((HyperLink)e.Row.FindControl
            Label NroDoc = ((Label)e.Row.FindControl("Label18"));
            NroDoc.Attributes.Add("onClick", "url(event," + Grupo.Value + ");");
            ((HyperLink)e.Row.FindControl("HprLnkHisExtven1")).Attributes.Add("onClick", "Historico(event," + NroDoc.Text + "," + Grupo.Value + ");");
            //((HyperLink)e.Row.FindControl("HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Text + "'," + Grupo.Value + ");");
        }
    }
    
}
