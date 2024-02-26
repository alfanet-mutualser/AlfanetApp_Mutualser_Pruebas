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
using DevExpress.Web;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxCallbackPanel;
using System.Collections.Generic;

public partial class _WorkFlow : System.Web.UI.Page
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
            LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
            LblDocRecExtProxVen.Text = ((DataView)(ODSDocRecExtProxVen.Select())).Table.Rows.Count.ToString();
            LblDocRecExtPen.Text = ((DataView)(ODSDocRecExtPen.Select())).Table.Rows.Count.ToString();
            LblDocRecCopia.Text = ((DataView)(ODSDocRecCopia.Select())).Table.Rows.Count.ToString();
            //Enviados
            LblDocEnvExtCopia.Text = ((DataView)(ODSDocEnvExtCopia.Select())).Table.Rows.Count.ToString();
            LblDocEnvExt.Text = ((DataView)(ODSDocEnvExtCopia.Select())).Table.Rows.Count.ToString();
            LblDocCopiaInt.Text = ((DataView)(ODSDocEnvIntCopia.Select())).Table.Rows.Count.ToString();
            LblDocEnvIntVen.Text = ((DataView)(ODSDocEnvIntVen.Select())).Table.Rows.Count.ToString();
            LblDocEnvInt.Text = (Convert.ToInt16(LblDocCopiaInt.Text) + Convert.ToInt16(LblDocEnvIntVen.Text)).ToString();

            //Total Recibidos
            LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text) + Convert.ToInt16(LblDocRecExtProxVen.Text) + Convert.ToInt16(LblDocRecExtPen.Text) + Convert.ToInt16(LblDocRecCopia.Text)).ToString();
                        
        }
        else
        {

        }
        

    }


    //---


    //protected void TreeVDependencia_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    //TreeNode Vencidos;
    //    //if ((String.IsNullOrEmpty(this.tree
    //    //Vencidos = GVDocRecExtVen.Rows[0].ToString;
    //    //TreeView TreeVDependencia;
    //    //TreeView TreeMulti = (TreeView)GVR.Row.FindControl("TreeVMultitarea");
    //    TreeView TreeVDependencia = (TreeView)GVDocRecExtVen.FindControl("TreeVDependencia");
        
    //    if ((String.IsNullOrEmpty(TreeVDependencia.SelectedNode.Text)) == false)
    //    {
    //        // Popup result is the selected task}
    //        PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVDependencia.SelectedNode.Text);
    //        //this.TreeVExpediente.CollapseAll();
    //        //this.TreeVExpediente.Dispose();
    //    }
    //}

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
            //TerminarCopia(GVDocRecExtCopia,ODSDocRecCopia,LblDocRecCopia);
            TerminarCopia(ASPxGVDocRecExtCopia, ODSDocRecCopia, LblDocRecCopia);
            LblDocRecExt.Text = LblDocRecExt.Text = (Convert.ToInt16(LblDocRecExtVen.Text) + Convert.ToInt16(LblDocRecExtProxVen.Text) + Convert.ToInt16(LblDocRecExtPen.Text) + Convert.ToInt16(LblDocRecCopia.Text)).ToString();          
                      
                      
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
    protected void BtnTerminarCopEnvExt_Click(object sender, EventArgs e)
    {
        try
        {
            this.LblMessageBox.Text = "";
            //TerminarCopia(GVDocEnvExtCopia, ODSDocEnvExtCopia, LblDocEnvExtCopia);
            TerminarCopia(ASPxGVDocEnvExtCopia, ODSDocEnvExtCopia, LblDocEnvExtCopia);
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
            //Terminartarea(GVDocEnvIntVen, ODSDocEnvIntVen, LblDocEnvIntVen);
            Terminartarea(ASPxGVDocEnvIntVen, ODSDocEnvIntVen, LblDocEnvIntVen);
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
            //ASPxGVDocEnvIntCopia TerminarCopia(GVDocEnvIntCopia, ODSDocEnvIntCopia, LblDocCopiaInt);
            TerminarCopia(ASPxGVDocEnvIntCopia, ODSDocEnvIntCopia, LblDocCopiaInt);
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
            //Terminartarea(GVDocRecExtVen, ODSDocRecExtVen, LblDocRecExtVen);
            Terminartarea(ASPxGVDocRecExtVen, ODSDocRecExtVen, LblDocRecExtVen);
           
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
            //Terminartarea(GVDocRecExtProxVen, ODSDocRecExtProxVen, LblDocRecExtProxVen);
            Terminartarea(ASPxGVDocRecExtProxVen,ODSDocRecExtProxVen, LblDocRecExtProxVen);

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
            //Terminartarea(GVDocRecExtPen, ODSDocRecExtPen, LblDocRecExtPen);
            Terminartarea(ASPxGVDocRecExtPen, ODSDocRecExtPen, LblDocRecExtPen);
            

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
                            //    Correo.EnvioCorreo("alfanetpruebas@gmail.com", "alfanetpruebas@gmail.com", "Tarea Nro" + " " + mNumeroDocumento, Body, true, "1");
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

                    }
                    else
                    {
                        this.LblMessageBox.Text += "Falta uno o mas parametros pàra descargar la tarea. ";
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

    protected void ASPxGVDocRecExtVen_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            ASPxRowBoundVen(ASPxGVDocRecExtProxVen, e, sender);
        }       
    }

    protected void ASPxGVDocRecExtCopia_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            
            ASPxRowBoundCopia(ASPxGVDocRecExtProxVen, e, sender);
        }
    }

    protected void ASPxRowBoundCopiaEnv_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {

            ASPxRowBoundCopiaEnv(ASPxGVDocRecExtProxVen, e, sender);
        }
    }

    protected void ASPxRowBoundEnvIntVen_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {

            ASPxRowBoundEnvIntVen(ASPxGVDocRecExtProxVen, e, sender);
        }
    }


   
    /*Modificacion con control nuevo*/


    /*Llenar los campos para documentos recibidos*/
    protected void ASPxRowBoundVen(ASPxGridView GV, ASPxGridViewTableRowEventArgs GVR,Object sender)
    {

        /*Editar funcionalidades de columna Rpta*/     

        GridViewDataColumn colRPostIt =
               ((ASPxGridView)sender).Columns["Rpta"] as GridViewDataColumn;

        ((ImageButton)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRPostIt, "ImageButton3")).Attributes.Add("onClick", "urlRpta(event);");



        /*Editar funcionalidades del columa Ver Post It*/

        GridViewDataColumn colCPostIt =
              ((ASPxGridView)sender).Columns["Ver Post It"] as GridViewDataColumn;

        Image ImgNot =
        ((Image)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCPostIt, "ImgDocNotasExtVen"));

        TextBox TxtCnPosIt =
            ((TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCPostIt, "TxtDocNotasExtVen"));

        if (TxtCnPosIt.Text != "")
        {
            ImgNot.Visible = true;
        }


        /*Buscar datos ocultos en la columna opciones*/

         GridViewDataColumn colOpc =
                ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;

        HiddenField Grupo =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFGrupo");
        HiddenField Expediente =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFExpediente");


        /*Editar funcionalidades de columna Radicado Codigo*/     

        GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["RadicadoCodigo"] as GridViewDataColumn;
        
        HyperLink NroDoc =
            (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "HyperLink1");
        NroDoc.Attributes.Add("onClick", "url(event,1);");




        /*Editar funcionalidades de columna Opciones*/
        if (Expediente.Value == "")
        {
            Expediente.Value = "30001";
        }
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkHisExtven")).Attributes.Add("onClick", "Historico(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Value + "'," + Grupo.Value + ");");


        /*Editar funcionalidades de columna Cargar a: , Accion y V.B.*/
        GridViewDataColumn colCargar =
               ((ASPxGridView)sender).Columns["Cargar a:"] as GridViewDataColumn;

        GridViewDataColumn colAccion =
               ((ASPxGridView)sender).Columns["Acci&#243;n:"] as GridViewDataColumn;

        GridViewDataColumn colVB =
               ((ASPxGridView)sender).Columns["V.B"] as GridViewDataColumn;
        
        TextBox mCargar =
             (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TxtCargarDocVen");
            

        HiddenField mHFCarga =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "HFCargar");

        TextBox TAcc =
            (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TxtAccionDocExtVen");
            

        mCargar.Attributes.Add("onkeydown", "return Disable_Attr(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");


        ((CheckBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colVB, "SelectorDocumento")).Attributes.Add("onClick", "ColorRowVen(this," + mCargar.ClientID + "," + TAcc.ClientID + ");");
        //((CheckBox)GVR.Row.FindControl("SelectorDocumento")).Attributes.Add("onClick", "ColorRowVen(this," + mCargar.ClientID + "," + TAcc.ClientID + ");");
        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TreeVSerie")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");   
        
        //((TreeView)GVR.Row.FindControl("TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        //((TreeView)GVR.Row.FindControl("TreeVSerie")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");       





        /*Editar funcionalidades de columna RadicadoCodigo*/

        HiddenField LabelResuesta = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "Label60");//GVR.Row.FindControl("Label60"));
        Image Image1 = (Image)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "Image1");//GVR.Row.FindControl("Image1");

       
        if (LabelResuesta.Value == "0")
        {
            LabelResuesta.Value = "Sin Respuesta";
            Image1.Visible = false;
        }
        else 
        {
            HtmlControl c1 = (HtmlControl)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "LnkRpta");
            c1.Attributes.Add("onclick", "OnMoreInfoClick(this,'" + NroDoc.Text + "|" + Grupo.Value.ToString() + "'" + ")"); 
           
        }


    }

    /*Llenar los campos referentes a copia de recibidos*/

    protected void ASPxRowBoundCopia(ASPxGridView GV, ASPxGridViewTableRowEventArgs GVR, Object sender)
    {

        /*Editar funcionalidades de columna Rpta*/

        GridViewDataColumn colRPostIt =
               ((ASPxGridView)sender).Columns["Rpta"] as GridViewDataColumn;

        ((ImageButton)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRPostIt, "ImageButton3")).Attributes.Add("onClick", "urlRpta(event);");



        /*Editar funcionalidades del columa Ver Post It*/

        GridViewDataColumn colCPostIt =
              ((ASPxGridView)sender).Columns["Ver Post It"] as GridViewDataColumn;

        Image ImgNot =
        ((Image)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCPostIt, "ImgDocNotasExtVen"));

        TextBox TxtCnPosIt =
            ((TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCPostIt, "TxtDocNotasExtVen"));

        if (TxtCnPosIt.Text != "")
        {
            ImgNot.Visible = true;
        }


        /*Buscar datos ocultos en la columna opciones*/

        GridViewDataColumn colOpc =
               ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;

        HiddenField Grupo =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFGrupo");
        HiddenField Expediente =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFExpediente");


        /*Editar funcionalidades de columna Radicado Codigo*/

        GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["RadicadoCodigo"] as GridViewDataColumn;

        HyperLink NroDoc =
            (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "HyperLink1");
        NroDoc.Attributes.Add("onClick", "url(event,1);");




        /*Editar funcionalidades de columna Opciones*/
        if (Expediente.Value == "")
        {
            Expediente.Value = "30001";
        }
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkHisExtven")).Attributes.Add("onClick", "Historico(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Value + "'," + Grupo.Value + ");");


        /*Editar funcionalidades de columna Cargar a: , Accion y V.B.*/
        /*
        GridViewDataColumn colCargar =
               ((ASPxGridView)sender).Columns["Cargar a:"] as GridViewDataColumn;

        GridViewDataColumn colAccion =
               ((ASPxGridView)sender).Columns["Acci&#243;n:"] as GridViewDataColumn;
        */
        GridViewDataColumn colVB =
               ((ASPxGridView)sender).Columns["V.B"] as GridViewDataColumn;

        /*
        TextBox mCargar =
             (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TxtCargarDocVen");
        

        HiddenField mHFCarga =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "HFCargar");

     
        TextBox TAcc =
            (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TxtAccionDocExtVen");
        */

        //mCargar.Attributes.Add("onkeydown", "return Disable_Attr(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");


        ((CheckBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colVB, "SelectorDocumento")).Attributes.Add("onClick", "ColorRow(this);");
        //((CheckBox)GVR.Row.FindControl("SelectorDocumento")).Attributes.Add("onClick", "ColorRowVen(this," + mCargar.ClientID + "," + TAcc.ClientID + ");");
        //((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        //((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TreeVSerie")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");

        //((TreeView)GVR.Row.FindControl("TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        //((TreeView)GVR.Row.FindControl("TreeVSerie")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");       





        /*Editar funcionalidades de columna RadicadoCodigo*/

        HiddenField LabelResuesta = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "Label60");//GVR.Row.FindControl("Label60"));
        Image Image1 = (Image)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "Image1");//GVR.Row.FindControl("Image1");


        if (LabelResuesta.Value == "0")
        {
            LabelResuesta.Value = "Sin Respuesta";
            Image1.Visible = false;
        }
        else
        {
            HtmlControl c1 = (HtmlControl)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colRad, "LnkRpta");
            c1.Attributes.Add("onclick", "OnMoreInfoClick(this,'" + NroDoc.Text + "|" + Grupo.Value.ToString() + "'" + ")");

        }

    
    }


    /*Llenar los campos referentes a documentos copia enviados*/

    protected void ASPxRowBoundCopiaEnv(ASPxGridView GV, ASPxGridViewTableRowEventArgs GVR, Object sender)
    {
        GridViewDataColumn colReg =
                ((ASPxGridView)sender).Columns["Registro&lt;br/&gt;No."] as GridViewDataColumn;
        GridViewDataColumn colVB =
               ((ASPxGridView)sender).Columns["V.B"] as GridViewDataColumn;
        GridViewDataColumn colOpc =
               ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
        

        /*Obtiene los valores de los hiddenfield en opciones*/

        HiddenField Grupo =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFGrupo");
        HiddenField Expediente =
            (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFExpediente");
        if (Expediente.Value == "")
        {
            Expediente.Value = "30001";
        }
        
        /*Insertar el metodo para el checkbox de visto bueno*/
        
        ((CheckBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colVB, "SelectorDocumento")).Attributes.Add("onClick", "ColorRow(this);");

        /*Insertar el método del hiperlink del numero de registro*/
        
        HyperLink NroDoc =
            (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colReg, "HyperLink1");
        NroDoc.Attributes.Add("onClick", "urlInt(event," + Grupo.Value + ");");

        /*Añadir las funciones en los hyperlinks de la columna opciones*/
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Value + "'," + Grupo.Value + ");");
        

        /*
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
        }*/


    }

    /*Lllena los campos referentes a documentos recibidos pendientes*/
    protected void ASPxRowBoundEnvIntVen(ASPxGridView GV, ASPxGridViewTableRowEventArgs GVR, Object sender)
    {
        /*Busca las columnas a editar*/
        GridViewDataColumn colReg =
                ((ASPxGridView)sender).Columns["Registro&lt;br/&gt;No."] as GridViewDataColumn;
        GridViewDataColumn colVB =
               ((ASPxGridView)sender).Columns["V.B"] as GridViewDataColumn;
        GridViewDataColumn colOpc =
               ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
        GridViewDataColumn colCargar =
               ((ASPxGridView)sender).Columns["Cargar a:"] as GridViewDataColumn;
        GridViewDataColumn colAccion =
               ((ASPxGridView)sender).Columns[11] as GridViewDataColumn;
        GridViewDataColumn colpit =
               ((ASPxGridView)sender).Columns[6] as GridViewDataColumn;
        GridViewDataColumn colvpit =
               ((ASPxGridView)sender).Columns[5] as GridViewDataColumn;


        TextBox mCargar = (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TxtCargarDocVen");
        TextBox TAcc = (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colAccion, "TxtAccionDocExtVen");

        HyperLink NroDoc = (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colReg, "HyperLink1");

        HiddenField Expediente = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFExpediente");
        HiddenField Grupo = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HFGrupo");

        HiddenField mHFCarga = (HiddenField)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "HFCargar");
        
        if (Expediente.Value == "")
        {
            Expediente.Value = "30001";
        }

        /*Adicionar las funciones al hyperlink del numero de registro*/
        NroDoc.Attributes.Add("onClick", "urlInt(event," + Grupo.Value + ");");

        /*Adicionar las funciones a los hyperlinks de la columna de opciones*/
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkImgExtVen")).Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + "," + Grupo.Value + ");");
        ((HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colOpc, "HprLnkExp")).Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + Expediente.Value + "'," + Grupo.Value + ");");

        /*Insertar el metodo para el checkbox de visto bueno*/

        ((CheckBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colVB, "SelectorDocumento")).Attributes.Add("onClick", "ColorRowVen(this," + mCargar.ClientID + "," + TAcc.ClientID + ");");

        /*Inserta las funcionalidades a los treeview*/

        mCargar.Attributes.Add("onkeydown", "return Disable_Attr(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");

        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVFinalizar")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
        ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVMultitarea")).Attributes.Add("onClick", "OnTreeClickMultitarea(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
            

        /*Controlar la visualizacion de la opcion de ver post it*/

        TextBox LblNot = (TextBox)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colvpit, "TxtDocNotasextven");
        Image ImgNot = (Image)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colvpit, "ImgDocNotasExtVen");
            
        if (LblNot.Text == "")
        {
            ImgNot.Visible = false;
        }


        if (HFMultiTarea.Value != "1")
        {
            ((TreeView)((ASPxGridView)sender).FindRowCellTemplateControl(GVR.VisibleIndex, colCargar, "TreeVMultitarea")).Visible = false;
        }

        /*
         if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox mCargar = ((TextBox)e.Row.FindControl("TxtCargarDocVen"));
            //mCargar.Attributes.Add("onkeypress", "return Disable_Attr(event)");

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


            mCargar.Attributes.Add("onkeydown", "return Disable_Attr(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");

            ((TreeView)e.Row.FindControl("TreeVDependencia")).Attributes.Add("onClick", "return OnTreeClick2(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
            ((TreeView)e.Row.FindControl("TreeVFinalizar")).Attributes.Add("onClick", "return OnTreeClickSerie(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
            ((TreeView)e.Row.FindControl("TreeVMultitarea")).Attributes.Add("onClick", "OnTreeClickMultitarea(event,getElementById('" + mCargar.ClientID + "'),getElementById('" + mHFCarga.ClientID + "'));");
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
        */

    }



    /*Visualizar los registros asociados al radicado*/
    protected void callbackPanel_Callback(object source, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {

        Label LbTitulo = new Label();
        LbTitulo.Text = "Registro Nro.:";
        PnlContent.Controls.Add(LbTitulo);
        PnlContent.Controls.Add(new LiteralControl("<br />"));
        /*Separar los datos de documento y grupo*/
        String s1 = e.Parameter.ToString();
        char[] seps = {'|'};
        String[] Parametros = s1.Split(seps);

        String listDocs = ""; 

        double Num;

        bool isNum = double.TryParse(Parametros[0].ToString().Trim(), out Num);
        
        /*Isertar el link referente al registro registro*/

        if (isNum && (Parametros.Length == 2))
        {
            DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
            DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
            DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(Parametros[0].ToString()), Parametros[1].ToString());

            int i = 1;
            PnlContent.Controls.Add(new LiteralControl("<table valign=\"middle\">"));
            foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
            {
                PnlContent.Controls.Add(new LiteralControl("<tr><td>"));
                HyperLink HprRpta = new HyperLink();
                HprRpta.ID = "HprRpta" + i.ToString();
                HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
                HprRpta.Target = "_Blank";
                HprRpta.ForeColor = System.Drawing.Color.Blue;
                HprRpta.Font.Underline = true;
                HprRpta.Attributes.Add("onClick", "urlInt(event," + DRRadFuenteReg.GrupoRegistroCodigo + ");");
                PnlContent.Controls.Add(HprRpta);
                PnlContent.Controls.Add(new LiteralControl("</td><td>"));
                System.Web.UI.WebControls.Image ImgRpta = new System.Web.UI.WebControls.Image();
                ImgRpta.ID = "ImgRpta" + i.ToString();
                ImgRpta.Width = new Unit("20px");
                ImgRpta.Height = new Unit("20px");
                ImgRpta.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.JPG";
                ImgRpta.Attributes.Add("onClick", "VImagenesReg(event," + DRRadFuenteReg.RegistroCodigo + "," + DRRadFuenteReg.GrupoRegistroCodigo + ");");
                PnlContent.Controls.Add(ImgRpta);
                PnlContent.Controls.Add(new LiteralControl("</td></tr>"));
                
                i += 1;
            }
            PnlContent.Controls.Add(new LiteralControl("</table>"));
          
        }

       
   
        
    }

    /*Sobrescritura del método de terminar tarea*/
    protected void Terminartarea(ASPxGridView GV, ObjectDataSource ODS, Label LblLocal)
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

            // The visible index of the fist row within the current page. 
            int startVisibleIndex = GV.VisibleStartIndex;
            // The number of visible rows displayed within the current page. 
            int visibleRowCount = GV.GetCurrentPageRowValues("V.B").Count;
            // The visible index of the last row within the current page. 
            int endVisibleIndex = startVisibleIndex + visibleRowCount - 1;


            for (int i = startVisibleIndex; i <= endVisibleIndex; i++)
            {
               
                 GridViewDataColumn colVB = GV.Columns["V.B"] as GridViewDataColumn;

                 GridViewDataColumn colOpc = GV.Columns["Opciones"] as GridViewDataColumn;

                    
                 /*Revisa el checkBox*/
                 CheckBox ch1 = (CheckBox)GV.FindRowCellTemplateControl(i, colVB, "SelectorDocumento");

                 HiddenField hdWfMovTipo = (HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimiento");
              
                
                //Label Lb10 = (Label)row.FindControl("Label10");
                 if (ch1 != null && ch1.Checked)
                {
                    //// Delete row! (Well, not really...)
                    atLeastOneRowSelected = true;


                    /*Si se va el radicado normal (1)*/
                    if (hdWfMovTipo.Value == "1")
                    {
                        //// First, get the DocumentID for the selected row
                        GridViewDataColumn colDoc = GV.Columns[1] as GridViewDataColumn;
                        int mNumeroDocumento = Convert.ToInt32(((HyperLink)GV.FindRowCellTemplateControl(i, colDoc, "HyperLink1")).Text.ToString());

                        //// por definir ...

                        GridViewDataColumn colCarga = GV.Columns["Cargar a:"] as GridViewDataColumn;
                        TextBox TxtDepDesitno = ((TextBox)GV.FindRowCellTemplateControl(i, colCarga, "TxtCargarDocVen"));

   
                        HiddenField mHFCarga = ((HiddenField)GV.FindRowCellTemplateControl(i, colCarga, "HFCargar"));

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
                        GridViewDataColumn colAccion = GV.Columns["Acci&#243;n:"] as GridViewDataColumn;
                        TextBox TxtNewAccion = ((TextBox)GV.FindRowCellTemplateControl(i, colAccion, "TxtAccionDocExtVen"));
                        
                        //TextBox TxtNewAccion = (TextBox)row.Cells[9].FindControl("TxtAccionDocExtVen");


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


                     
                        int mWFMovimientoPaso = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimientoPaso")).Value.ToString());
                        int mWFMovimientoPasoActual = 1;
                        int mWFMovimientoPasoFinal = 0;


                        int mWFMovimientoTipoini = Convert.ToInt32(hdWfMovTipo.Value.ToString());
                        //int mWFMovimientoTipoini = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[3]);

                        GridViewDataColumn colPit = GV.Columns["Post<br/>It"] as GridViewDataColumn;

                        TextBox TxtNewNotas = ((TextBox)GV.FindRowCellTemplateControl(i, colPit, "TextBox4"));
                         


                        //TextBox TxtNewNotas = (TextBox)row.Cells[6].FindControl("TextBox4");


                        string mWFMovimientoNotas = TxtNewNotas.Text;

                        //string mGrupoCodigo = GV.DataKeys[row.RowIndex].Values[4].ToString();
                        
                        
                        string mGrupoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFGrupo")).Value.ToString();
                         
                        

                        

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


                            //TreeView TreeMulti = (TreeView)row.Cells[8].FindControl("TreeVMultitarea");


                            TreeView TreeMulti = ((TreeView)(GV.FindRowCellTemplateControl(i, colCarga, "TreeVMultitarea")));
                      

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
                            //    Correo.EnvioCorreo("alfanetpruebas@gmail.com", "alfanetpruebas@gmail.com", "Tarea Nro" + " " + mNumeroDocumento, Body, true, "1");
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
                            if (mWFAccionCodigo == null)
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

                        }
                        else
                        {
                            this.LblMessageBox.Text += "Falta uno o mas parametros pàra descargar la tarea. ";
                        }

                        this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
                        this.LblMessageBox.Text += " de su escritorio<br />";
                    }
                    else if (hdWfMovTipo.Value == "4") /*Si se va el radicado por proceso (4)*/
                    {
                        GridViewDataColumn colDoc = GV.Columns[1] as GridViewDataColumn;
                        
                        GridViewDataColumn colPit = GV.Columns["Post<br/>It"] as GridViewDataColumn;

                       
                        

                        //TextBox TxtNewAccion = ((TextBox)GV.FindRowCellTemplateControl(i, colAccion, "TxtAccionDocExtVen")).Text.ToString();
                         

                        //LinkButton LnkNro = (LinkButton)row.FindControl("LinkButton5");
                        int mNumeroDocumento = Convert.ToInt32(((HyperLink)GV.FindRowCellTemplateControl(i, colDoc, "HyperLink1")).Text.ToString());

                        
                        //int mNumeroDocumento = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[0]);
                        // por definir ...
                        //string mDependenciaCodDestino = "694";

                        int mWFMovimientoPaso = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimientoPaso")).Value.ToString());

                        //int mWFMovimientoPaso = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[2]);

                        DateTime mWFFechaMovimientoFin = DateTime.Now;

                        int mWFMovimientoTipoini = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimiento")).Value.ToString());

                        
                        //int mWFMovimientoTipoini = Convert.ToInt32(GV.DataKeys[row.RowIndex].Values[3]);

                        // por definir ...


                        TextBox TxtNewNotas = ((TextBox)GV.FindRowCellTemplateControl(i, colPit, "TextBox4"));

                        //TextBox TxtNewNotas = (TextBox)row.Cells[6].FindControl("TextBox4");
                        


                        string mWFMovimientoNotas = TxtNewNotas.Text;


                        string mGrupoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFGrupo")).Value.ToString();

                        //string mGrupoCodigo = GV.DataKeys[row.RowIndex].Values[4].ToString();

                        string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();


                        string mWFProcesoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFProceso")).Value.ToString();
                        //string mWFProcesoCodigo = GV.DataKeys[row.RowIndex].Values[5].ToString();

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

    /*Sobreescritura del método de terminar copia */
    protected void TerminarCopia(ASPxGridView GV, ObjectDataSource ODS, Label LblLocal)
    {

        // Iterate through the Products.Rows property

        // The visible index of the fist row within the current page. 
        int startVisibleIndex = GV.VisibleStartIndex;
        // The number of visible rows displayed within the current page. 
        int visibleRowCount = GV.GetCurrentPageRowValues("V.B").Count;
        // The visible index of the last row within the current page. 
        int endVisibleIndex = startVisibleIndex + visibleRowCount - 1;

        bool atLeastOneRowSelected = false;

        for (int i = startVisibleIndex; i <= endVisibleIndex; i++)
        {

            GridViewDataColumn colVB = GV.Columns["V.B"] as GridViewDataColumn;
            GridViewDataColumn colOpc = GV.Columns["Opciones"] as GridViewDataColumn;
            GridViewDataColumn colPit = GV.Columns["Post<br/>It"] as GridViewDataColumn;
            
            /*Revisa el checkBox*/
            CheckBox ch1 = (CheckBox)GV.FindRowCellTemplateControl(i, colVB, "SelectorDocumento");

            HiddenField hdWfMovTipo = (HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimiento");

            if (ch1 != null && ch1.Checked)
            {

                atLeastOneRowSelected = true;

                // First, get the DocumentID for the selected row
                GridViewDataColumn colDoc = GV.Columns["NumeroDocumento"] as GridViewDataColumn;
                int mNumeroDocumento = Convert.ToInt32(((HyperLink)GV.FindRowCellTemplateControl(i, colDoc, "HyperLink1")).Text.ToString());

                int mWFMovimientoPaso = Convert.ToInt32(((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFWFMovimientoPaso")).Value.ToString());
                DateTime mWFFechaMovimientoFin = DateTime.Now;

                int mWFMovimientoTipoini = Convert.ToInt32(hdWfMovTipo.Value.ToString());


                TextBox TxtNewNotas = ((TextBox)GV.FindRowCellTemplateControl(i, colPit, "TextBox4"));
                string mWFMovimientoNotas = TxtNewNotas.Text;
                string mGrupoCodigo = ((HiddenField)GV.FindRowCellTemplateControl(i, colOpc, "HFGrupo")).Value.ToString();
                string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();



                /*
                    
                TextBox TxtNewNotas = (TextBox)row.Cells[6].FindControl("TextBox4");
                string mWFMovimientoNotas = TxtNewNotas.Text;
                string mGrupoCodigo = GV.DataKeys[row.RowIndex].Values[4].ToString();
                string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                */

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
}
