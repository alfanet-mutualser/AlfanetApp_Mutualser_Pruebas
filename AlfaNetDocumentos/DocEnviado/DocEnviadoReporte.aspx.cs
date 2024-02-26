
using System;
using ASP;
using Microsoft;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSRadicadoTableAdapters;
using DSGrupoSQLTableAdapters;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;
using System.Collections.Generic;
using AjaxControlToolkit;
using System.Text;

public partial class _DocEnviadoReporte : System.Web.UI.Page 
{
    //string GrpDocRad = "1";
    

    protected void Page_Load(object sender, EventArgs e)
    {  
    try
    {
        string Admon = Request["Admon"];
        if (Admon == "S")
        {
            //((MainMaster)this.Master).hidemenu();
        }
        else
        {
           // ((MainMaster)this.Master).showmenu();
        }
        String RptaImg = Request["RptaImg"];
        if (RptaImg == "S")
        {
            ImgBtnRpta.Visible = true;
        }
                             
                string codImagen = Request["RadicadoCodigo"];
                HFGrupo.Value = Request["GrupoCodigo"];
                HFTipoDB.Value = Request["TipoCodigo"];
                HFControlDias.Value = Request["ControlDias"];
                HFDepenOrig.Value = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
                HFWFMovFecha.Value = Convert.ToString(DateTime.Now);
                string senrodoc;
                if (codImagen != null)
                {
                    senrodoc = codImagen;
                    Session["NroDoc"] = codImagen;
                }

                senrodoc = (string)(Session["NroDoc"]);
                if (Session["NroDoc"] != null)
                {
                    senrodoc = Session["NroDoc"].ToString();
                    string Tipo = senrodoc.Substring(0, 1);
                    string nrodoc = senrodoc.Substring(1);
                    this.HFNroRad.Value = nrodoc;
                             
                }
        }
        catch (Exception Error)
        {
         this.ExceptionDetails.Text = "Problema" + Error;
        }
    }   
    
    
    
    
   
   
    
    //protected void cmdAceptar_Click(object sender, EventArgs e)
    //{  
    //    //IDbConnection ObjConn = null;
    //    //IDbTransaction ObjTran = null;
    //    //ObjConn = new SqlConnection(@"server=JUANRG-PC\SQLEXPRESS;Trusted_Connection=true;DATABASE=AlfaNet");
    //    //ObjConn.Open();
    //    try
    //    {
    //        string RadicadoCodigo;
    //        RadicadoBLL Obj = new RadicadoBLL();


    //        //ObjTran = ObjConn.BeginTransaction();

    //        if (this.LblSearchCargar.Text == "Archivar En")
    //            {
    //               RadicadoCodigo = Obj.AddRadicado(GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToDateTime(SelDateFechaProcedencia.Text.ToString()), TxtProcedencia.Text.ToString(), null, TxtNumeroExterno.Text.ToString(), TxtNaturaleza.Text.ToString().Trim(), Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), TxtDetalle.Text.ToString(), TxtAnexo.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(),this.TxtSerieD.Text.ToString(), TxtAccion.Text.ToString(), "0", "1", Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 3, TxtDetalle.Text.ToString(), this.TxtSerieD.Text.ToString(), "0");
    //        //DSRadicadoTableAdapters.Radicado1TableAdapter TARadicado = new Radicado1TableAdapter();
    //            if (RBEnterarA.SelectedValue == "T")
    //                    {
    //                        string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[0].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 4, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), "0");

    //                    }    
    //            else
    //                {
    //                for (int i=0; i< ListBoxEnterar.Items.Count; i++)
    //                 {
                        
    //                    string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[i].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()),2, TxtDetalle.Text.ToString(), null,RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()),"0");
    //                 }
    //                }
    //            }
    //            else if ( this.LblSearchCargar.Text == "Proceso")
    //            {
    //                RadicadoCodigo = Obj.AddRadicado(GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToDateTime(SelDateFechaProcedencia.Text.ToString()), TxtProcedencia.Text.ToString(),this.TxtSerieD.Text.ToString(), TxtNumeroExterno.Text.ToString(), TxtNaturaleza.Text.ToString().Trim(), Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), TxtDetalle.Text.ToString(), TxtAnexo.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), this.TxtSerieD.Text.ToString(), TxtAccion.Text.ToString(), "1", "0", Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 3, TxtDetalle.Text.ToString(), null, "0");
    //                //DSRadicadoTableAdapters.Radicado1TableAdapter TARadicado = new Radicado1TableAdapter();
    //                if (RBEnterarA.SelectedValue == "T")
    //                    {
    //                        string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[0].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 4, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), "0");

    //                    }    
    //            else
    //                {
    //                for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
    //                {

    //                    string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[i].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 2, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), "0");
    //                }
    //                }
    //            }
    //            else
    //            {
    //                RadicadoCodigo = Obj.AddRadicado(GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToDateTime(SelDateFechaProcedencia.Text.ToString()), TxtProcedencia.Text.ToString(),null, TxtNumeroExterno.Text.ToString(), TxtNaturaleza.Text.ToString().Trim(), Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), TxtDetalle.Text.ToString(), TxtAnexo.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), this.TxtSerieD.Text.ToString(), TxtAccion.Text.ToString(),"1","0", Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 1, TxtDetalle.Text.ToString(),null, "0");
    //                //DSRadicadoTableAdapters.Radicado1TableAdapter TARadicado = new Radicado1TableAdapter();
    //                 if (RBEnterarA.SelectedValue == "T")
    //                    {
    //                        string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[0].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 4, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), "0");

    //                    }    
    //            else
    //                {
    //                for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
    //                {

    //                    string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), this.ListBoxEnterar.Items[i].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), 2, TxtDetalle.Text.ToString(),null, RadicadoCodigo, GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), "0");
    //                }
    //                }
    //            }
    //        //ObjTran.Commit();
    //        //ObjTran = null;
            
    //        this.Label22.Text = "Radicado Nro" + " " + RadicadoCodigo;
    //        Session["NroDoc"] = "1" + RadicadoCodigo;
    //        //this.Label14.Text = "1" + RadicadoCodigo;
    //        this.LblMessageBox.Text = "Radicado Nro" + " " + RadicadoCodigo;     
    //        this.ModalPopupExtender1.Show();
    //        MailBLL Correo = new MailBLL();
    //        MembershipUser usuario;
    //        usuario = Membership.GetUser(Profile.GetProfile(User.Identity.Name.ToString()).UserName.ToString());
    //        string Body = "Tiene un nuevo Radicado Nro " + RadicadoCodigo + "<BR>" + " Fecha de Radicacion: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "<BR>" + "Procedencia: " + TxtProcedencia.Text.ToString() + "<BR>" + "Naturaleza: " + TxtNaturaleza.Text.ToString().Trim() + "<BR>";
    //        Correo.EnvioCorreo("soporte.archivar@gmail.com", usuario.Email, "Radicado Nro" + " " + RadicadoCodigo, Body, true, "1");
            
    //    }
    //    catch (Exception Error)
    //    {
    //        //ObjTran.Rollback();
    //        //ObjTran = null;
    //        this.ExceptionDetails.Text = "Problema" + Error;
    //    }

    //  }
    //protected void cmdCancel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        this.Session.Clear();
    //       // this.Session.Remove(Session.Keys["NroDoc"].ToString());
    //        Response.Redirect("~");
    //    }
    //    catch (Exception Error)
    //    {
    //        this.ExceptionDetails.Text = "Problema" + Error;
    //    }
    //}
//   protected void BtnNuevoRad_Click(object sender, EventArgs e)
//    {
//          try
//            {
//                this.Session.Clear();
//                //this.Session.Remove(Session["NroDoc"].ToString());
//                //this.ExceptionDetails.Text = "";
//                //this.TxtBuscarRadicado.Text = "";
//                //this.SelDateFechaProcedencia.Text = "";
//                //this.TxtNumeroExterno.Text = "";
//                //this.SelDateFechaVencimiento.Text = "";
//                //this.TxtProcedencia.Text = "";
//                //this.TxtDetalle.Text = "";
//                //this.TxtNaturaleza.Text = "";
//                //this.TxtMedioRecibo.Text = "";
//                //this.TxtExpediente.Text = "";
//                //this.TxtSerieD.Text = "";
//                //this.TxtAccion.Text = "";
//                //this.TxtSerieD.Visible = true;
//                //this.TxtAccion.Visible = true;
//                //this.LblSearchAccion.Text = "";
//                //this.LblSearchCargar.Text = "";
//                //this.LblSearchExpediente.Text = "";
//                //this.LblSearchMedio.Text = "";
//                //this.LblSearchNaturaleza.Text = "";
//                //this.LblSearchProcedencia.Text = "";
//                //this.ImgFindCargar.Visible = true;
//                //this.ImgFindAccion.Visible = true;
//                //this.LblSearchCargar.Visible = true;
//                //this.LblSearchAccion.Visible = true;
//                //this.LblCargarA.Visible = true;
//                //this.LblAccion.Visible = true;
//                //this.cmdAceptar.Enabled = true;
//                //this.cmdActualizar.Enabled = false;
//                //this.Label22.Text = "";
//                //this.TxtAnexo.Text = "";
//                //this.TxtDependencia1.Text = "";
//                //this.Label5.Text = "";
//                //this.ListBoxEnterar.Items.Clear();
//                Response.Redirect("~/AlfaNetDocumentos/DocRecibido/NuevoDocRecibido1.aspx");
        
//            }
//    catch (SqlException err)
//    {
//        //cnn.rol
//       this.LblAccion.Text = "Error: " + err.Message.ToString();

//    }
//}
//    protected void ImgBtnAdd_Click(object sender, EventArgs e)
//    {
//        this.ListBoxEnterar.Items.Add(this.TxtDependencia1.Text.ToString());
//        this.TxtDependencia1.Text = "";
//    }
//    protected void ImgBtnDelete_Click(object sender, EventArgs e)
//    {
//        this.ListBoxEnterar.Items.Remove(this.ListBoxEnterar.SelectedItem);
        
//        //this.ListBoxEnterar.Items.Add(this.TxtDependencia.Text.ToString());
//    }
//    protected void RBEnterarA_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        if (RBEnterarA.SelectedValue == "T")
//        {
//            this.ListBoxEnterar.Items.Clear();
//            this.TxtDependencia1.Text = "";
//            this.TxtDependencia1.ReadOnly = true;
//            //this.DropDownExtender3.Enabled = false;
//            this.ImgBtnAdd.Enabled = false;
//            this.ImgBtnDelete.Enabled = false;
//            this.ListBoxEnterar.Items.Add("Todas | Todas");
//        }
//        else
//        {
//            this.ListBoxEnterar.Items.Clear();
//            this.TxtDependencia1.Text = "";
//            this.TxtDependencia1.ReadOnly = false;
//            //this.DropDownExtender3.Enabled = true;
//            this.ImgBtnAdd.Enabled = true;
//            this.ImgBtnDelete.Enabled = true;
//        }
//    }
//    protected void TreeVDependencia_SelectedNodeChanged(object sender, EventArgs e)
//    {

//        if ((String.IsNullOrEmpty(this.TreeVDependencia.SelectedNode.Text)) == false)
//        {
//        // Popup result is the selected task}
//        PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVDependencia.SelectedNode.Text);
//        this.TreeVDependencia.CollapseAll();
//        this.TreeVDependencia.Dispose();
//        }
//    }
//    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
//    {
//        ArbolesBLL ObjArbolDep = new ArbolesBLL();
//        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
//        DTDependencia = ObjArbolDep.GetDependenciaTree(Int32.Parse(e.Node.Value));
//        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
//    }
//    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
//    {
//        foreach (DataRow dr in dt.Rows)
//        {
//            TreeNode tn = new TreeNode();
//            //dr["title"].ToString();
//            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
//            tn.Value = dr[Codigo].ToString();
//            nodes.Add(tn);

//            //If node has child nodes, then enable on-demand populating
//            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
//        }
//    }
//    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        if (RadioButtonList1.SelectedValue == "0")
//        {
//            //this.ImgFindRemite.Visible = true;
//            this.TxtDependencia.Visible = true;
//            this.TxtCtrAccion.Visible = true; 
//            this.LblDep.Visible = true;
//            this.LblCtrAccion.Visible = true;
//            //dimension panel
//            this.PnlDoc.Height = 300;
//            //opciones multitarea
//            this.TxtDependencia1.Visible = false;
//            this.ListBoxEnterar.Visible = false;
//            this.ImgBtnAdd.Visible = false;
//            this.ImgBtnDelete.Visible = false;
//            this.RBEnterarA.Visible = false;
//            this.Label14.Visible = false;
//            //this.LblMultitarea.Visible = true;
//            //this.LstMultitarea.Visible = true;
//            //this.TxtBMultitarea.Visible = false;
            
//            //opciones Archivar
//            this.LblArchivar.Visible = false;
//            this.TxtArchivar.Visible = false;

//            this.LnkBtnTerminar.Visible = true;
//            this.LnkBtnMultitarea.Visible = false; 

          
//        }
//        if (RadioButtonList1.SelectedValue == "1")
//        {
//            //this.ImgFindRemite.Visible = true;
//            this.TxtDependencia.Visible = false;
//            this.TxtCtrAccion.Visible = false; 
//            this.LblDep.Visible = false;
//            this.LblCtrAccion.Visible = false;
//            ////opciones multitarea
//            this.TxtDependencia1.Visible = true;
//            this.ListBoxEnterar.Visible = true;
//            this.ImgBtnAdd.Visible = true;
//            this.ImgBtnDelete.Visible = true;
//            this.RBEnterarA.Visible = true;
//            this.Label14.Visible = true; 
//            //this.LblMultitarea.Visible = true;
//            //this.LstMultitarea.Visible = true;
//            ////this.TxtBMultitarea.Visible = true;

//            //opciones Archivar
//            this.LblArchivar.Visible = false;
//            this.TxtArchivar.Visible = false;
//            //dimensiones Archivar
//            this.PnlDoc.Height = 300;
//            this.LnkBtnTerminar.Visible = true;
//            //this.LnkBtnMultitarea.Visible = true;
//           // this.LnkBtnClearList.Visible = true;
//        }
//        if (RadioButtonList1.SelectedValue == "2")
//        {
//            //this.ImgFindRemite.Visible = true;
//            this.TxtDependencia.Visible = false;
//            this.TxtCtrAccion.Visible = false;
//            this.LblDep.Visible = false;
//            this.LblCtrAccion.Visible = false;
//            //opciones multitarea
//            this.TxtDependencia1.Visible = false;
//            this.ListBoxEnterar.Visible = false;
//            this.ImgBtnAdd.Visible = false;
//            this.ImgBtnDelete.Visible = false;
//            this.RBEnterarA.Visible = false;
//            this.Label14.Visible = false; 
//            //this.LblMultitarea.Visible = true;
//            //this.LstMultitarea.Visible = true;
//            //this.TxtBMultitarea.Visible = false;
//            //opciones Archivar
//            this.LblArchivar.Visible = true;
//            this.TxtArchivar.Visible = true;
//            //dimensiones Archivar
//            this.PnlDoc.Height = 300;
//            this.LnkBtnTerminar.Visible = true;
//            this.LnkBtnMultitarea.Visible = false; 
//        }
//    }
//    protected void TreeVAccion_TreeNodePopulate(object sender, TreeNodeEventArgs e)
//    {
//        DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter TADSWFA = new DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter();
//        DSAccion.WFAccion_SelectByTextDataTable DTWFAccion = new DSAccion.WFAccion_SelectByTextDataTable();
//        DTWFAccion = TADSWFA.GetWFAccionTreeDataBy(e.Node.Value);
//        PopulateNodes(DTWFAccion, e.Node.ChildNodes, "WFAccionCodigo", "WFAccionNombre");
//    }
//    protected void TreeVAccion_SelectedNodeChanged(object sender, EventArgs e)
//    {
//        if ((String.IsNullOrEmpty(this.TreeVAccion.SelectedNode.Text)) == false)
//        {
//            // Popup result is the selected task}
//            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVAccion.SelectedNode.Text);
//            this.TreeVAccion.CollapseAll();
//            this.TreeVAccion.Dispose();
//        }
//    }
//    protected void TreeVDependencia_CheckChanged(object sender, TreeNodeEventArgs e)
//    {
//       // if ((String.IsNullOrEmpty(this.TreeVDependencia.CheckedNodes.Count.ToString())) == 0)
//        //{
//            // Popup result is the selected task}
//        //ander --PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVMultitarea.CheckedNodes.ToString());
//        //ander --PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVDependencia.CheckedNodes.ToString());
//        //ander --this.TreeVMultitarea.CollapseAll();
//        //ander --this.TreeVMultitarea.Dispose();
//        //}

//    }
//    protected void TreeVMultitarea_CheckChanged(object sender, TreeNodeEventArgs e)
//    {
//        //int Nro_Nodos = Tree.CheckedNodes.Count;
//        //string mWFMovimientoMultitarea;
//        //ander --if (TreeVMultitarea.CheckedNodes.Count > 0)
//            //mWFMovimientoMultitarea = "1";
//        //mWFMovimientoMultitarea = "0";
            
//        //for (int Nro_Nodos = 0; Nro_Nodos < TreeVMultitarea.CheckedNodes.Count; Nro_Nodos++)
//        //{
//            //ander -- this.LstMultitarea.Items.Add(TreeVMultitarea.CheckedNodes[TreeVMultitarea.].Text);
//            //String mDependenciaCodDestino = TreeVMultitarea.CheckedNodes[Nro_Nodos].Text;            
//        //}

//        //PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVMultitarea.CheckedNodes.ToString());
//        ////PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVDependencia.CheckedNodes.ToString());
//        //this.TreeVMultitarea.CollapseAll();
//        //this.TreeVMultitarea.Dispose();
//    }
//    protected void TreeVArchivar_SelectedNodeChanged(object sender, EventArgs e)
//    {
//        if ((String.IsNullOrEmpty(this.TreeVArchivar.SelectedNode.Text)) == false)
//        {
//            // Popup result is the selected task}
//            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVArchivar.SelectedNode.Text);
//            this.TreeVArchivar.CollapseAll();
//            this.TreeVArchivar.Dispose();
//        }
       
//    }   
//    protected void TreeVArchivar_TreeNodePopulate(object sender, TreeNodeEventArgs e)
//    {
//        ArbolesBLL ObjArbolSer = new ArbolesBLL();
//        DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();

//        //DTDependencia = ObjArbolDep.GetDependenciaTree(Int32.Parse(e.Node.Value));
//        DTSerie = ObjArbolSer.GetSerieTree(Int32.Parse(e.Node.Value));

//        PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
//    }
//    protected void LnkBtnMultitarea_Click(object sender, EventArgs e)
//    {
//        LstMultitarea.Items.Clear();
//        //int Nro_Nodos = Tree.CheckedNodes.Count;
//        if (TreeVMultitarea.CheckedNodes.Count < 1)
//        {
//            this.ExceptionDetails.Text = "No ha Seleccionado elementos en el Arbol";
//        }
//        else
//        {
//            for (int Nro_Nodos = 0; Nro_Nodos < TreeVMultitarea.CheckedNodes.Count; Nro_Nodos++)
//            {
//                this.LstMultitarea.Items.Add(TreeVMultitarea.CheckedNodes[Nro_Nodos].Text);

//            }
//        }
//        this.TreeVMultitarea.CollapseAll();

//    }
//    protected void LnkBtnLimpiarList_Click(object sender, EventArgs e)
//    {
//        LstMultitarea.Items.Clear();
//    }
//    protected void LnkBtnTerminar_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            DSWorkFlowTableAdapters.WFMovimientoTableAdapter ObjWorkFlow = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
//            DSWorkFlow.WFMovimientoDataTable DTEnviada = new DSWorkFlow.WFMovimientoDataTable();
//            DTEnviada = ObjWorkFlow.GetUnDocExtBy(Convert.ToInt32(HFTipoDB.Value), HFDepenOrig.Value, HFGrupo.Value, Convert.ToDateTime(HFWFMovFecha.Value), Convert.ToInt32(HFControlDias.Value), Convert.ToInt32(HFNroRad.Value));
//            DataRow[] rows = DTEnviada.Select();
           
//            if (RadioButtonList1.SelectedValue == "0")
//            {
//                int mNumeroDocumento =  Convert.ToInt32(this.HFNroRad.Value);
//                //this.HFNroRad.Value;
//                int mWFMovimientoPaso = Convert.ToInt32(rows[0].ItemArray[2].ToString().Trim());
//                    //int mNumeroDocumento = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[0]);
//                    //int mWFMovimientoPaso = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[2]);
//                int mWFMovimientoPasoActual = 1;
//                int mWFMovimientoPasoFinal = 0;
                
//                DateTime mWFFechaMovimientoFin = DateTime.Now;


//                     // por definir ...
//                    int mWFMovimientoTipo= 1;
//                    int mWFMovimientoTipoini = Convert.ToInt32(HFTipoDB.Value); 
//                    //int mWFMovimientoTipo = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[3]);
                    
//                    string mWFMovimientoNotas = "Sin notas";
//                    string mGrupoCodigo=this.HFGrupo.Value;
//                   // string mGrupoCodigo = GVDocRecExtVen.DataKeys[row.RowIndex].Values[4].ToString();
//                    string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
//                    string mWFProcesoCodigo = null;
//                    // por definir ...

//                    string mWFAccionCodigo = this.TxtCtrAccion.Text.ToString().Trim();
//                    DateTime mWFMovimientoFecha = DateTime.Now;
//                    DateTime mWFMovimientoFechaEst = DateTime.Now;
//                    // por definir ...
//                    string mSerieCodigo = null;

//                    //TreeView Tree = (TreeView)row.FindControl("TreeVDepIntVen");

//                    //int Nro_Nodos = Tree.CheckedNodes.Count;
//                    string mWFMovimientoMultitarea = "0";
                    
//                    //for (int Nro_Nodos = 0; Nro_Nodos < Tree.CheckedNodes.Count; Nro_Nodos++)
//                    //{
//                        String mDependenciaCodDestino = this.TxtDependencia.Text.ToString().Trim();
//                        //String mDependenciaCodDestino = Tree.CheckedNodes[Nro_Nodos].Text;
//                        if (mDependenciaCodDestino != "")
//                        {
//                            if (mDependenciaCodDestino.Contains(" | "))
//                            {
//                                mDependenciaCodDestino = mDependenciaCodDestino.Remove(mDependenciaCodDestino.IndexOf(" | "));
//                            }
//                        }
//                        if (mWFAccionCodigo != "")
//                        {
//                            if (mWFAccionCodigo.Contains(" | "))
//                            {
//                                mWFAccionCodigo = mWFAccionCodigo.Remove(mWFAccionCodigo.IndexOf(" | "));
//                            }
//                        }

//                        DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

//                        TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
//                                                           mDependenciaCodDestino,
//                                                           mWFMovimientoPaso,
//                                                           mWFMovimientoPasoActual,
//                                                           mWFMovimientoPasoFinal,
//                                                           mWFFechaMovimientoFin,
//                                                           mWFMovimientoTipo,
//                                                           mWFMovimientoTipoini,
//                                                           mWFMovimientoNotas,
//                                                           mGrupoCodigo,
//                                                           mDependenciaCodOrigen,
//                                                           mWFProcesoCodigo,
//                                                           mWFAccionCodigo,
//                                                           mWFMovimientoFecha,
//                                                           mWFMovimientoFechaEst,
//                                                           mSerieCodigo,
//                                                           mWFMovimientoMultitarea);
//                    //}
//                    // por definir ...
//                    this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
//                    this.LblMessageBox.Text += " de su escritorio<br />";
                    
//                //}
//            //}
//            if (RadioButtonList1.SelectedValue == null)
//            {
//                this.MPEMensaje.Show();
//            //    ODSDocRec.DataBind();
//            //    ODSDocRecExtVen.DataBind();
//            //    GVDocRecExtVen.DataBind();
//            //    LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
//            //    LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
//            //    this.MPEMensaje.Show();
//            }
//            else
//            {
//                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
//                this.MPEMensaje.Show();
//            }

//        }
//        if (RadioButtonList1.SelectedValue == "2")
//        {
//            int mNumeroDocumento = Convert.ToInt32(this.HFNroRad.Value);
//            //this.HFNroRad.Value;
//            int mWFMovimientoPaso = Convert.ToInt32(rows[0].ItemArray[2].ToString().Trim());
//            //int mNumeroDocumento = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[0]);
//            //int mWFMovimientoPaso = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[2]);
//            int mWFMovimientoPasoActual = 0;
//            int mWFMovimientoPasoFinal = 1;
//            DateTime mWFFechaMovimientoFin = DateTime.Now;

//            // por definir ...
//            int mWFMovimientoTipo = 3;
//            int mWFMovimientoTipoini = Convert.ToInt32(HFTipoDB.Value);
//            //int mWFMovimientoTipo = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[3]);

//            string mWFMovimientoNotas = "Sin notas";
//            string mGrupoCodigo = this.HFGrupo.Value;
//            // string mGrupoCodigo = GVDocRecExtVen.DataKeys[row.RowIndex].Values[4].ToString();
//            string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
//            string mWFProcesoCodigo = null;
//            // por definir ...

//            string mWFAccionCodigo = null;
//            DateTime mWFMovimientoFecha = DateTime.Now;
//            DateTime mWFMovimientoFechaEst = DateTime.Now;
//            // por definir ...
//            string mSerieCodigo = this.TxtArchivar.Text.ToString().Trim();

//            //TreeView Tree = (TreeView)row.FindControl("TreeVDepIntVen");

//            //int Nro_Nodos = Tree.CheckedNodes.Count;
//            string mWFMovimientoMultitarea = "0";

//            //for (int Nro_Nodos = 0; Nro_Nodos < Tree.CheckedNodes.Count; Nro_Nodos++)
//            //{
//            String mDependenciaCodDestino = mDependenciaCodOrigen;
//            //String mDependenciaCodDestino = Tree.CheckedNodes[Nro_Nodos].Text;
//            if (mSerieCodigo != "")
//            {
//                if (mSerieCodigo.Contains(" | "))
//                {
//                    mSerieCodigo = mSerieCodigo.Remove(mSerieCodigo.IndexOf(" | "));
//                }
//            }
//            //if (mWFAccionCodigo != "")
//            //{
//            //    if (mWFAccionCodigo.Contains(" | "))
//            //    {
//            //        mWFAccionCodigo = mWFAccionCodigo.Remove(mWFAccionCodigo.IndexOf(" | "));
//            //    }
//            //}

//            DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

//            TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
//                                               mDependenciaCodDestino,
//                                               mWFMovimientoPaso,
//                                               mWFMovimientoPasoActual,
//                                               mWFMovimientoPasoFinal,
//                                               mWFFechaMovimientoFin,
//                                               mWFMovimientoTipo,
//                                               mWFMovimientoTipoini,
//                                               mWFMovimientoNotas,
//                                               mGrupoCodigo,
//                                               mDependenciaCodOrigen,
//                                               mWFProcesoCodigo,
//                                               mWFAccionCodigo,
//                                               mWFMovimientoFecha,
//                                               mWFMovimientoFechaEst,
//                                               mSerieCodigo,
//                                               mWFMovimientoMultitarea);
//            //}
//            // por definir ...
//            this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
//            this.LblMessageBox.Text += " de su escritorio<br />";

//            //}
//            //}
//            if (RadioButtonList1.SelectedValue == null)
//            {
//                this.MPEMensaje.Show();
//                //    ODSDocRec.DataBind();
//                //    ODSDocRecExtVen.DataBind();
//                //    GVDocRecExtVen.DataBind();
//                //    LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
//                //    LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
//                //    this.MPEMensaje.Show();
//            }
//            else
//            {
//                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
//                this.MPEMensaje.Show();
//            }
//        }
//        if (RadioButtonList1.SelectedValue == "1")
//        {
//            int mNumeroDocumento = Convert.ToInt32(this.HFNroRad.Value);
//            //this.HFNroRad.Value;
//            int mWFMovimientoPaso = Convert.ToInt32(rows[0].ItemArray[2].ToString().Trim());
//            //int mNumeroDocumento = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[0]);
//            //int mWFMovimientoPaso = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[2]);
//            int mWFMovimientoPasoActual = 1;
//            int mWFMovimientoPasoFinal = 0;
//            DateTime mWFFechaMovimientoFin = DateTime.Now;

//            // por definir ...
//            int mWFMovimientoTipo = 2;
//            int mWFMovimientoTipoini = mWFMovimientoTipo; ;
//            //int mWFMovimientoTipo = Convert.ToInt32(GVDocRecExtVen.DataKeys[row.RowIndex].Values[3]);

//            string mWFMovimientoNotas = "Sin notas";
//            string mGrupoCodigo = this.HFGrupo.Value;
//            // string mGrupoCodigo = GVDocRecExtVen.DataKeys[row.RowIndex].Values[4].ToString();
//            string mDependenciaCodOrigen = Profile.GetProfile(User.Identity.Name).CodigoDepUsuario.ToString();
//            string mWFProcesoCodigo = null;
//            // por definir ...

//            string mWFAccionCodigo = "2";
//            DateTime mWFMovimientoFecha = DateTime.Now;
//            DateTime mWFMovimientoFechaEst = DateTime.Now;
//            // por definir ...
//            string mSerieCodigo = null;

//            //TreeView Tree = (TreeView)row.FindControl("TreeVDepIntVen");

//            //int Nro_Nodos = Tree.CheckedNodes.Count;
//            string mWFMovimientoMultitarea = "1";

//            for (int Nro_Copias = 0; Nro_Copias < this.ListBoxEnterar.Items.Count; Nro_Copias++)
//            {

//                String mDependenciaCodDestino = ListBoxEnterar.Items[Nro_Copias].Text;
             
//            //String mDependenciaCodDestino = Tree.CheckedNodes[Nro_Nodos].Text;
//            if (mDependenciaCodDestino != "")
//            {
//                if (mDependenciaCodDestino.Contains(" | "))
//                {
//                    mDependenciaCodDestino = mDependenciaCodDestino.Remove(mDependenciaCodDestino.IndexOf(" | "));
//                }
//            }

           

//            DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();

//            TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
//                                               mDependenciaCodDestino,
//                                               mWFMovimientoPaso,
//                                               mWFMovimientoPasoActual,
//                                               mWFMovimientoPasoFinal,
//                                               mWFFechaMovimientoFin,
//                                               mWFMovimientoTipo,
//                                               mWFMovimientoTipoini,
//                                               mWFMovimientoNotas,
//                                               mGrupoCodigo,
//                                               mDependenciaCodOrigen,
//                                               mWFProcesoCodigo,
//                                               mWFAccionCodigo,
//                                               mWFMovimientoFecha,
//                                               mWFMovimientoFechaEst,
//                                               mSerieCodigo,
//                                               mWFMovimientoMultitarea);
//            }
//            //}
//            // por definir ...
//            this.LblMessageBox.Text += string.Format("Se descargo el documento {0}", mNumeroDocumento);
//            this.LblMessageBox.Text += " de su escritorio<br />";

//            //}
//            //}
//            if (RadioButtonList1.SelectedValue == null)
//            {
//                this.MPEMensaje.Show();
//                //    ODSDocRec.DataBind();
//                //    ODSDocRecExtVen.DataBind();
//                //    GVDocRecExtVen.DataBind();
//                //    LblDocRecExt.Text = ((DataView)(ODSDocRec.Select())).Table.Rows.Count.ToString();
//                //    LblDocRecExtVen.Text = ((DataView)(ODSDocRecExtVen.Select())).Table.Rows.Count.ToString();
//                //    this.MPEMensaje.Show();
//            }
//            else
//            {
//                this.LblMessageBox.Text = "No selecciono documentos para descargar de su escritorio.";
//                this.MPEMensaje.Show();
//            }
//        }
//        Response.Redirect("~/AlfaNetWorkFlow/AlfaNetWF/WorkFlow.aspx");
//        }
//        catch (Exception Error)
//        {
//            ////Display a user-friendly message
//            //this.LblMessageBox.Text = "Ocurrio un problema al tratar de descargar el documento. ";
//            Exception inner = Error.InnerException;
//            //this.LblMessageBox.Text += ErrorHandled.FindError(inner);
//            //this.LblMessageBox.Text += Error.Message.ToString();
//            //this.MPEMensaje.Show();
//        }
        
//    }
    protected void ImgBtnRpta_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx" + "?DocumentoCodigo=" + this.HFNroRad.Value + "&Admon=S&ImagenFolio=1&GrupoCodigo=2&GrupoPadreCodigo=2");
    }
}
        
           
      
