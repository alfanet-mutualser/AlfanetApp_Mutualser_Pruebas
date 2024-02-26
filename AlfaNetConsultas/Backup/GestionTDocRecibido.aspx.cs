
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
using DevExpress.Web;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxCallbackPanel;
using System.IO;

public partial class _GestionTDocRecibido : System.Web.UI.Page
{
    //RadicadoBLL ObjGestionTRad = new RadicadoBLL();
    //DSRadicado.Radicado_ConsultasGestionTareasDataTable ConsultaRadicado = new DSRadicado.Radicado_ConsultasGestionTareasDataTable();
   protected void Page_Load(object sender, EventArgs e)
        {  
         try
            {    
                if (!IsPostBack)
                    {
                        this.RadioButtonList1.SelectedValue = null;
                        //DDLOtros.SelectedValue = null;  
                    }
                    else
                    { 
             
                    }
                   
            }
         catch (Exception Error)
            {
            this.ExceptionDetails.Text = "Problema" + Error;
            }
    }
    protected void ChBFechaRad_CheckedChanged(object sender, EventArgs e)
    {
          if (ChBFechaRad.Checked == true)
               {
              this.LblFechaFinal.Visible = true;
              this.LblFechaInicial.Visible = true;
              this.TxtFechaFinal.Visible = true;
              this.TxtFechaInicial.Visible = true;
              this.ImgCalendarFinal.Visible = true;
              this.ImgCalendarInicial.Visible = true;
              //this.RFVFechaRadIni.Enabled = true;
              //this.RFVFecharadFin.Enabled = true;
              }
          else
               {
                   this.LblFechaFinal.Visible = false;
                   this.LblFechaInicial.Visible = false;
                   this.TxtFechaFinal.Visible = false;
                   this.TxtFechaInicial.Visible = false;
                   this.TxtFechaFinal.Text = "";
                   this.TxtFechaInicial.Text = "";
                   this.ImgCalendarFinal.Visible = false;
                   this.ImgCalendarInicial.Visible = false;
                   //this.RFVFechaRadIni.Enabled = false;
                   //this.RFVFecharadFin.Enabled = false;
               }
    }
    
    protected void ChBNaturaleza_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBNaturaleza.Checked == true)
        {
            this.LblNaturaleza.Visible = true;
            this.TxtBNaturaleza.Visible = true;
          //  this.RFVNaturaleza.Enabled = true;
        }
        else
        {
            this.LblNaturaleza.Visible = false;
            this.TxtBNaturaleza.Visible = false;
            this.TxtBNaturaleza.Text = "";
          //  this.RFVNaturaleza.Enabled = false;
        }
    }
   
    protected void TreeVNaturaleza_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVNaturaleza.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVNaturaleza.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void TreeVNaturaleza_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVNaturaleza.SelectedNode == null)
        {
            ArbolesBLL ObjArbolNat = new ArbolesBLL();
            DSNaturalezaSQL.NaturalezaByTextDataTable DTNaturaleza = new DSNaturalezaSQL.NaturalezaByTextDataTable();
            DTNaturaleza = ObjArbolNat.GetNaturalezaTree(e.Node.Value);
            PopulateNodes(DTNaturaleza, e.Node.ChildNodes, "NaturalezaCodigo", "NaturalezaNombre");
        }
    }
    protected void TreeVDependencia_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVDependencia.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVDependencia.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    }
    protected void TVDepDestino_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TVDepDestino.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TVDepDestino.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void TreeVProceso_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVProceso.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVProceso.SelectedNode.Text);
        }
    }
    protected void TreeVProceso_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVProceso.SelectedNode == null)
        {
            ProcesoTableAdapters.WFProcesoTableAdapter TAPRO = new ProcesoTableAdapters.WFProcesoTableAdapter();
            Proceso.WFProcesoDataTable DTProceso = new Proceso.WFProcesoDataTable();
            DTProceso = TAPRO.GetProcesoTreeVDataBy(Convert.ToString(e.Node.Value));
            PopulateNodes(DTProceso, e.Node.ChildNodes, "WFProcesoCodigo", "WFProcesoDescripcion");
        }
    }
    protected void TreeVAccion_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVAccion.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVAccion.SelectedNode.Text);
        }
    }
    protected void TreeVAccion_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter TADSWFA = new DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter();
        DSAccion.WFAccion_SelectByTextDataTable DTWFAccion = new DSAccion.WFAccion_SelectByTextDataTable();
        DTWFAccion = TADSWFA.GetWFAccionTreeDataBy(Convert.ToString(e.Node.Value));

        PopulateNodes(DTWFAccion, e.Node.ChildNodes, "WFAccionCodigo", "WFAccionNombre");
    }
    //protected void TVDepDestino_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    //{
    //    ArbolesBLL ObjArbolDep = new ArbolesBLL();
    //    DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
    //    DTDependencia = ObjArbolDep.GetDependenciaTree(Int32.Parse(e.Node.Value));
    //    PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    //}
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            //dr["title"].ToString();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////

        string lotros = "";
        string dt_qw = "";
        try
        {                      
            if (DDLSel.SelectedValue == "0")
            {
                this.ODSBuscar.SelectParameters["WFMovimientoTipo"].DefaultValue = "1";
                this.ODSBuscar.SelectParameters["WFMovimientoTipo1"].DefaultValue = "3";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoActual"].DefaultValue = "";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoFinal"].DefaultValue = "";
                lotros = "1?3??";

                //ConsultaRadicado = ObjGestionTRad.GetGTRadicado(this.TxtFechaInicial.Text.ToString(), this.TxtFechaFinal.Text.ToString(), this.TxtFechaFinInicial.Text.ToString(), this.TxtFechaFinFinal.Text.ToString(), this.TxtFechaVenInicial.Text.ToString(), this.TxtFechaVenFinal.Text.ToString(), 1, 3, "", "", TxtBDepOrigen.Text.ToString(), this.TxtBDepDestino.Text.ToString(), this.TxtBFuente.Text.ToString(), this.TxtBProceso.Text.ToString().Trim(), this.TxtBAccion.Text.ToString().Trim(), "", this.TxtBNaturaleza.Text.ToString());
            }
            else if (DDLSel.SelectedValue == "1")
            {
                this.ODSBuscar.SelectParameters["WFMovimientoTipo"].DefaultValue = "3";
                this.ODSBuscar.SelectParameters["WFMovimientoTipo1"].DefaultValue = "3";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoActual"].DefaultValue = "0";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoFinal"].DefaultValue = "1";
                lotros = "3?3?0?1";
                //ConsultaRadicado = ObjGestionTRad.GetGTRadicado(this.TxtFechaInicial.Text.ToString(), this.TxtFechaFinal.Text.ToString(), this.TxtFechaFinInicial.Text.ToString(), this.TxtFechaFinFinal.Text.ToString(), this.TxtFechaVenInicial.Text.ToString(), this.TxtFechaVenFinal.Text.ToString(), 3, 3, "0", "1", TxtBDepOrigen.Text.ToString(), this.TxtBDepDestino.Text.ToString(), this.TxtBFuente.Text.ToString(), this.TxtBProceso.Text.ToString().Trim(), this.TxtBAccion.Text.ToString().Trim(), "", this.TxtBNaturaleza.Text.ToString());
            }
            else if (DDLSel.SelectedValue == "2")
            {
                this.ODSBuscar.SelectParameters["WFMovimientoTipo"].DefaultValue = "1";
                this.ODSBuscar.SelectParameters["WFMovimientoTipo1"].DefaultValue = "1";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoActual"].DefaultValue = "1";
                this.ODSBuscar.SelectParameters["WFMovimientoPasoFinal"].DefaultValue = "0";
                lotros = "1?1?1?0";
               // ConsultaRadicado = ObjGestionTRad.GetGTRadicado(this.TxtFechaInicial.Text.ToString(), this.TxtFechaFinal.Text.ToString(), this.TxtFechaFinInicial.Text.ToString(), this.TxtFechaFinFinal.Text.ToString(), this.TxtFechaVenInicial.Text.ToString(), this.TxtFechaVenFinal.Text.ToString(), 1, 1, "1", "0", TxtBDepOrigen.Text.ToString(), this.TxtBDepDestino.Text.ToString(), this.TxtBFuente.Text.ToString(), this.TxtBProceso.Text.ToString().Trim(), this.TxtBAccion.Text.ToString().Trim(), "", this.TxtBNaturaleza.Text.ToString());
            }          
            //            <asp:Parameter Name="SerieCodigo" Type="String" />
            this.ODSBuscar.SelectParameters["WFMovimientoFecha"].DefaultValue = this.TxtFechaInicial.Text;
            this.ODSBuscar.SelectParameters["WFMovimientoFecha1"].DefaultValue = this.TxtFechaFinal.Text;
            this.ODSBuscar.SelectParameters["WFMovimientoFechaFin"].DefaultValue = this.TxtFechaFinInicial.Text;
            this.ODSBuscar.SelectParameters["WFMovimientoFechaFin1"].DefaultValue = this.TxtFechaFinFinal.Text;
            this.ODSBuscar.SelectParameters["RadicadoFechaVencimiento"].DefaultValue = this.TxtFechaVenInicial.Text;
            this.ODSBuscar.SelectParameters["RadicadoFechaVencimiento1"].DefaultValue = this.TxtFechaVenFinal.Text;
            this.ODSBuscar.SelectParameters["DependenciaCodOrigen"].DefaultValue = this.TxtBDepOrigen.Text;
            this.ODSBuscar.SelectParameters["DependenciaCodDestino"].DefaultValue = this.TxtBDepDestino.Text;
            this.ODSBuscar.SelectParameters["RadicadoCodigoFuente"].DefaultValue = this.RadioButtonList1.SelectedValue;
            this.ODSBuscar.SelectParameters["WFProcesoCodigo"].DefaultValue = this.TxtBProceso.Text;
            this.ODSBuscar.SelectParameters["WFAccionCodigo"].DefaultValue = this.TxtBAccion.Text;
            this.ODSBuscar.SelectParameters["SerieCodigo"].DefaultValue = "";
            this.ODSBuscar.SelectParameters["NaturalezaCodigo"].DefaultValue = this.TxtBNaturaleza.Text;
            this.ODSBuscar.SelectParameters["ProcedenciaCodigo"].DefaultValue = this.TxtBProcedencia.Text;
            this.ODSBuscar.SelectParameters["ExpedienteCodigo"].DefaultValue = this.TxtBExpediente.Text;
            this.ODSBuscar.SelectParameters["Detalle"].DefaultValue = this.TXTDetalle.Text;
            //insertar la dependencia de donde se está haciendo la consulta modif feb 28 2011
            this.ODSBuscar.SelectParameters["DependenciaConsulta"].DefaultValue = Profile.CodigoDepUsuario.ToString();
            

            //Registrar el evento de busqueda
             



            /*
            rutinas r1 = new rutinas();
            DataTable t1 = r1.rtn_registrar_log("0", UserId, "7",
                this.TxtFechaInicial.Text + "?" + this.TxtFechaFinal.Text + "?" + this.TxtFechaFinInicial.Text + "?" + this.TxtFechaFinFinal.Text + "?"
                + this.TxtFechaVenInicial.Text + "?" + this.TxtFechaVenFinal.Text + "?" +  value_pipe(this.TxtBDepOrigen.Text)+ "?"
                + value_pipe(this.TxtBDepDestino.Text) + "?" + value_pipe(this.RadioButtonList1.SelectedValue)+ "?" +
                value_pipe(this.TxtBProceso.Text) + "?" + value_pipe(this.TxtBAccion.Text) + "?" + value_pipe(this.TxtBNaturaleza.Text)+ "?"
                + value_pipe(this.TxtBProcedencia.Text) + "?" + value_pipe(this.TxtBExpediente.Text) + "?" + lotros, "2");
            */
            //GVBuscar.DataSource = ConsultaRadicado;
            //GVBuscar.Visible = true;
            //GVBuscar.DataBind();
            ASPxGridView1.DataSourceID = "ODSBuscar";
            ASPxGridView1.DataBind();

            this.MyAccordion.SelectedIndex = 1;
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }

    /*Prodecimiento para devolver el id de un campo si este contiene separadores*/

    protected string value_pipe(string val_1)
    {
        string res = "";
        if (val_1 != "" && val_1 != null)
        {
            if (val_1.Contains(" | "))
            {
                res = val_1.Remove(val_1.IndexOf(" | "));
            }
            else
            {
                res = val_1;
            }
        }
        return res;
    }
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        
    }
    //protected void GVBuscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    if (DDLSel.SelectedValue == "0")
    //        ConsultaRadicado = ObjGestionTRad.GetGTRadicado(this.TxtFechaInicial.Text.ToString(), this.TxtFechaFinal.Text.ToString(), this.TxtFechaFinInicial.Text.ToString(), this.TxtFechaFinFinal.Text.ToString(), this.TxtFechaVenInicial.Text.ToString(), this.TxtFechaVenFinal.Text.ToString(), 1, 3, "", "", TxtBDepOrigen.Text.ToString(), this.TxtBDepDestino.Text.ToString(), this.TxtBFuente.Text.ToString(), this.TxtBProceso.Text.ToString().Trim(), this.TxtBAccion.Text.ToString().Trim(), "", this.TxtBNaturaleza.Text.ToString());
    //    else if (DDLSel.SelectedValue == "1")
    //        ConsultaRadicado = ObjGestionTRad.GetGTRadicado(this.TxtFechaInicial.Text.ToString(), this.TxtFechaFinal.Text.ToString(), this.TxtFechaFinInicial.Text.ToString(), this.TxtFechaFinFinal.Text.ToString(), this.TxtFechaVenInicial.Text.ToString(), this.TxtFechaVenFinal.Text.ToString(), 3, 3, "0", "1", TxtBDepOrigen.Text.ToString(), this.TxtBDepDestino.Text.ToString(), this.TxtBFuente.Text.ToString(), this.TxtBProceso.Text.ToString().Trim(), this.TxtBAccion.Text.ToString().Trim(), "", this.TxtBNaturaleza.Text.ToString());
    //    else if (DDLSel.SelectedValue == "2")
    //        ConsultaRadicado = ObjGestionTRad.GetGTRadicado(this.TxtFechaInicial.Text.ToString(), this.TxtFechaFinal.Text.ToString(), this.TxtFechaFinInicial.Text.ToString(), this.TxtFechaFinFinal.Text.ToString(), this.TxtFechaVenInicial.Text.ToString(), this.TxtFechaVenFinal.Text.ToString(), 1, 1, "1", "0", TxtBDepOrigen.Text.ToString(), this.TxtBDepDestino.Text.ToString(), this.TxtBFuente.Text.ToString(), this.TxtBProceso.Text.ToString().Trim(), this.TxtBAccion.Text.ToString().Trim(), "", this.TxtBNaturaleza.Text.ToString());
    //    GVBuscar.DataSource = ConsultaRadicado;
    //    this.GVBuscar.PageIndex = e.NewPageIndex;
    //    this.GVBuscar.DataBind();
    //}  
    //protected void GVBuscar_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int indice = GVBuscar.SelectedIndex;
    //    string value = GVBuscar.SelectedValue.ToString();
    //    string Datos = GVBuscar.SelectedDataKey.Value.ToString(); 
    //    Session["NroDoc"] = "1" + value;
    //    Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx");
    //}
    protected void LinkButton1_Click(object sender, EventArgs e)
    { 
        //String RadicadoCodigo = GVBuscar.DataKeys[dato1].Value.ToString();
        ////String RadicadoCodigo = GVBuscar.SelectedDataKey.Value.ToString();
        ////String RadicadoCodigo = this.GVBuscar.SelectedValue.ToString();
        //Session["NroDoc"] = "1" + RadicadoCodigo;
        //Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx");
    }
    protected void LnkBtnGTRecibidas_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AlfaNetDocumentos/DocRecibido/DocRecibidoReporte.aspx?TipoCodigo=1&RadicadoCodigo=1" + ((LinkButton)sender).Text + "&GrupoCodigo=1&ControlDias=2");

    }
   // protected void cmdBuscar_Click(object sender, ImageClickEventArgs e)
   // {
   //     try
   //     {
   //         //DSRadicadoTableAdapters.Radicado_ConsultasGestionTareasTableAdapter OBJTAGT = new Radicado_ConsultasGestionTareasTableAdapter();
   //         //DSRadicado.Radicado_ConsultasGestionTareasDataTable ConsultaRadicado = new DSRadicado.Radicado_ConsultasGestionTareasDataTable();
   //    // ConsultaRadicado = ObjGestionTRad.GetGTRadicado(this.TxtFechaInicial.Text.ToString(), this.TxtFechaFinal.Text.ToString(), this.TxtFechaFinInicial.Text.ToString(), this.TxtFechaFinFinal.Text.ToString(), this.TxtFechaVenInicial.Text.ToString(), this.TxtFechaVenFinal.Text.ToString(),1,"1","0", TxtBDepOrigen.Text.ToString(), this.TxtBDepDestino.Text.ToString(), this.TxtBFuente.Text.ToString(), this.TxtBProceso.Text.ToString().Trim(), this.TxtBAccion.Text.ToString().Trim(), "", this.TxtBNaturaleza.Text.ToString());
   //         //RadicadoBLL ObjGTConsulta = new RadicadoBLL();
   //         //DSRadicadoTableAdapters.Radicado_ConsultasGestionTareasPruebaTableAdapter = new Radicado_ConsultasGestionTareasPruebaTableAdapter();
   //         //RadicadoBLL ObjConsultaRad = new RadicadoBLL();
   //         //DSRadicado.Radicado_ConsultasRadicadoDataTable ConsultaRadicado = new DSRadicado.Radicado_ConsultasRadicadoDataTable();
   //        // if (DDLSel.SelectedValue =="")
   //     /////ConsultaRadicado = ObjGestionTRad.GetGTRadicado(this.TxtFechaInicial.Text.ToString(), this.TxtFechaFinal.Text.ToString(), this.TxtFechaFinInicial.Text.ToString(), this.TxtFechaFinFinal.Text.ToString(), this.TxtFechaVenInicial.Text.ToString(), this.TxtFechaVenFinal.Text.ToString(),1,"1","0", TxtBDepOrigen.Text.ToString(), this.TxtBDepDestino.Text.ToString(), this.TxtBFuente.Text.ToString(), this.TxtBProceso.Text.ToString().Trim(), this.TxtBAccion.Text.ToString().Trim(), "", this.TxtBNaturaleza.Text.ToString());
   // //else
   //// if (DDLSel.SelectedValue == "0")
   //     //ConsultaRadicado = ObjGestionTRad.GetGTRadicado(this.TxtFechaInicial.Text.ToString(), this.TxtFechaFinal.Text.ToString(), this.TxtFechaFinInicial.Text.ToString(), this.TxtFechaFinFinal.Text.ToString(), this.TxtFechaVenInicial.Text.ToString(), this.TxtFechaVenFinal.Text.ToString(),1,3,"","", TxtBDepOrigen.Text.ToString(), this.TxtBDepDestino.Text.ToString(), this.RadioButtonList1.SelectedValue, this.TxtBProceso.Text.ToString().Trim(), this.TxtBAccion.Text.ToString().Trim(), "", this.TxtBNaturaleza.Text.ToString());
   //// else if (DDLSel.SelectedValue == "1")
   //     //ConsultaRadicado = ObjGestionTRad.GetGTRadicado(this.TxtFechaInicial.Text.ToString(), this.TxtFechaFinal.Text.ToString(), this.TxtFechaFinInicial.Text.ToString(), this.TxtFechaFinFinal.Text.ToString(), this.TxtFechaVenInicial.Text.ToString(), this.TxtFechaVenFinal.Text.ToString(), 3, 3, "0", "1", TxtBDepOrigen.Text.ToString(), this.TxtBDepDestino.Text.ToString(), this.RadioButtonList1.SelectedValue, this.TxtBProceso.Text.ToString().Trim(), this.TxtBAccion.Text.ToString().Trim(), "", this.TxtBNaturaleza.Text.ToString());
   // //else if (DDLSel.SelectedValue == "2")
   //     //ConsultaRadicado = ObjGestionTRad.GetGTRadicado(this.TxtFechaInicial.Text.ToString(), this.TxtFechaFinal.Text.ToString(), this.TxtFechaFinInicial.Text.ToString(), this.TxtFechaFinFinal.Text.ToString(), this.TxtFechaVenInicial.Text.ToString(), this.TxtFechaVenFinal.Text.ToString(), 1, 1, "1", "0", TxtBDepOrigen.Text.ToString(), this.TxtBDepDestino.Text.ToString(), this.RadioButtonList1.SelectedValue, this.TxtBProceso.Text.ToString().Trim(), this.TxtBAccion.Text.ToString().Trim(), "", this.TxtBNaturaleza.Text.ToString());
   //         //ConsultaRadicado.Select(
   // //DataRow[] rows = ConsultaRadicado.Select("WfmovimientoTipo <> 0");

   //        // GVBuscar.DataSource = ConsultaRadicado;
   //      //   GVBuscar.Visible = true;
   //       //  GVBuscar.DataBind();
   //      //   this.MyAccordion.SelectedIndex = 1;
   //     }
   //     catch (Exception Error)
   //     {
   //         this.ExceptionDetails.Text = "Problema" + Error;
   //     }
   // }
    protected void ChBFechaFin_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBFechaFin.Checked == true)
        {
            this.LblFechaFinFinal.Visible = true;
            this.LblFechaFinInicial.Visible = true;
            this.TxtFechaFinFinal.Visible = true;
            this.TxtFechaFinInicial.Visible = true;
            this.ImgCalendarFinFinal.Visible = true;
            this.ImgCalendarFinInicial.Visible = true;
            //this.RFVFechaFinIni.Enabled = true;
            //this.RFVFechaFinFin.Enabled = true;

        }
        else
        {
            this.LblFechaFinFinal.Visible = false;
            this.LblFechaFinInicial.Visible = false;
            this.TxtFechaFinFinal.Visible = false;
            this.TxtFechaFinInicial.Visible = false;
            this.TxtFechaFinFinal.Text = "";
            this.TxtFechaFinInicial.Text = "";
            this.ImgCalendarFinFinal.Visible = false;
            this.ImgCalendarFinInicial.Visible = false;
           // this.RFVFechaFinIni.Enabled = false;
           // this.RFVFechaFinFin.Enabled = false;
        }
    }
    protected void ChBFechaVen_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBFechaVen.Checked == true)
        {
            this.LblFechaVenFinal.Visible = true;
            this.LblFechaVenInicial.Visible = true;
            this.TxtFechaVenFinal.Visible = true;
            this.TxtFechaVenInicial.Visible = true;
            this.ImgCalendarVenFinal.Visible = true;
            this.ImgCalendarVenInicial.Visible = true;
           // this.RFVFechaVenIni.Enabled = true;
           // this.RFVFechaVenFin.Enabled = true;

        }
        else
        {
            this.LblFechaVenFinal.Visible = false;
            this.LblFechaVenInicial.Visible = false;
            this.TxtFechaVenFinal.Visible = false;
            this.TxtFechaVenInicial.Visible = false;
            this.TxtFechaVenFinal.Text = "";
            this.TxtFechaVenInicial.Text = "";
            this.ImgCalendarVenFinal.Visible = false;
            this.ImgCalendarVenInicial.Visible = false;
           // this.RFVFechaVenIni.Enabled = false;
           // this.RFVFechaVenFin.Enabled = false;
        }
    }
    protected void ChBDependencias_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBDependencias.Checked == true)
        {
            this.LblDepOrigen.Visible = true;
            this.LblDepDestino.Visible = true;
                        
            this.TxtBDepOrigen.Visible = true;
            this.TxtBDepDestino.Visible = true;
                       
            //this.RFVDepOrigen.Enabled = true;
            //this.RFVDepDestino.Enabled = true;
           
        }
        else
        {
            this.LblDepOrigen.Visible = false;
            this.LblDepDestino.Visible = false;

            this.TxtBDepOrigen.Visible = false;
            this.TxtBDepDestino.Visible = false;

           // this.RFVDepOrigen.Enabled = false;
           // this.RFVDepDestino.Enabled = false;

            this.TxtBDepOrigen.Text = "";
            this.TxtBDepDestino.Text = "";
            
        }
    }
    protected void ChBFuente_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBFuente.Checked == true)
        {
            this.LblFuente.Visible = true;
            this.RadioButtonList1.Visible = true;
            this.RadioButtonList1.SelectedValue = null;
            //this.TxtBFuente.Visible = true;
          //  this.RFVFuente.Enabled = true;
        }
        else
        {
            this.LblFuente.Visible = false;
            this.RadioButtonList1.Visible = false;
            this.RadioButtonList1.SelectedValue = null;
            //this.TxtBFuente.Visible = false;
            //this.TxtBFuente.Text = "";
          //  this.RFVFuente.Enabled = false;
        }
    }
    protected void ChBProceso_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBProceso.Checked == true)
        {
            this.LblProceso.Visible = true;
            this.TxtBProceso.Visible = true;
           // this.RFVProceso.Enabled = true;
        }
        else
        {
            this.LblProceso.Visible = false;
            this.TxtBProceso.Visible = false;
            this.TxtBProceso.Text = "";
           // this.RFVProceso.Enabled = false;
        }
    }
    protected void ChBAccion_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBAccion.Checked == true)
        {
            this.LblAccion.Visible = true;
            this.TxtBAccion.Visible = true;
          //  this.RFVAccion.Enabled = true;
        }
        else
        {
            this.LblAccion.Visible = false;
            this.TxtBAccion.Visible = false;
            this.TxtBAccion.Text = "";
           // this.RFVAccion.Enabled = false;
        }
    }
    //protected void GVBuscar_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        // FORMATEA ROWS
    //        //((ImageButton)e.Row.FindControl("ImageButton3")).Attributes.Add("onClick", "urlRpta(event);");
    //        //((LinkButton)e.Row.FindControl("linkButton5")).Attributes.Add("onClick", "urlInt(event);");
    //        //CheckBox Chk = ((CheckBox)e.Row.FindControl("SelectorDocumento"));
    //        //Chk.Attributes.Add("onClick", "ColorRow(this);");
    //        Label LabelResuesta = ((Label)e.Row.FindControl("Label6"));
    //        Image Image1 = (Image)e.Row.FindControl("Image1");
    //        //TextBox mCargar = ((TextBox)e.Row.FindControl("TxtCargarDocVen"));
    //        LinkButton LnkBtnGTRecibidas = ((LinkButton)e.Row.FindControl("LnkBtnGTRecibidas"));
    //        ListBox LstRpta = (ListBox)e.Row.FindControl("ListBox1");

    //        HyperLink HyperLink1 = (HyperLink)e.Row.FindControl("HyperLink1");

    //        HyperLink1.Attributes.Add("onClick", "url(event,1);");
    //        //((LinkButton)e.Row.FindControl("linkButton5")).Attributes.Add("onClick", "url(event," + Grupo.Value + ");");
    //        ((HyperLink)e.Row.FindControl("HyperLinkVisor")).Attributes.Add("onClick", "VImagenes(event," + HyperLink1.Text + ",1);");
    //        ((HyperLink)e.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "Historico(event," + HyperLink1.Text + ",1);");
    //        //HyperLink1.Attributes.Add("onClick", "url(event);");
    //        //((HyperLink)e.Row.FindControl("HyperLinkVisor")).Attributes.Add("onClick", "VImagenes(event," + HyperLink1.Text + ");");

    //        if (LabelResuesta.Text == "0")
    //        {
    //            LabelResuesta.Text = "Sin Respuesta";
    //            Image1.Visible = false;
    //        }
    //        else if (Convert.ToInt32(LabelResuesta.Text)  > 0)
    //        {
    //            Image1.Visible = true;
    //            Panel PnlRpta = ((Panel)e.Row.FindControl("PnlRpta"));
    //            DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
    //            DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
    //            DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(LnkBtnGTRecibidas.Text),"1");

    //            int i = 1;
    //            foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
    //            {
    //                HyperLink HprRpta = new HyperLink();
    //                HprRpta.ID = "HprRpta" + i.ToString();
    //                HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
    //                //HprRpta.NavigateUrl = "";
    //                HprRpta.Target = "_Blank";
    //                HprRpta.ForeColor = System.Drawing.Color.Blue;
    //                HprRpta.Font.Underline = true;
    //                HprRpta.Attributes.Add("onClick", "urlInt(event," + DRRadFuenteReg.GrupoRegistroCodigo + ");");   

    //                //LinkButton LnkBtnRpta = new LinkButton();                                        
    //                //LnkBtnRpta.ID = "LnkBtnRpta" + i.ToString();
    //                //LnkBtnRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
    //                ////LnkBtnRpta.PostBackUrl = "javascript:void(0);";
    //                //LnkBtnRpta.Attributes.Add("onClick", "urlInt(event);");

    //                //((LinkButton)e.Row.FindControl("LnkBtnRpta")).Attributes.Add("onClick", "urlInt(event);");
    //                //LbPasoPostIt.Width = Unit.Pixel(300);
    //                //LbPasoPostIt.Height = Unit.Pixel(80);
    //                //LbPasoPostIt.Text = DRradHis.WFMovimientoNotas;
    //                //LbPasoPostIt.Font.Bold = true;
    //                //LbPasoPostIt.BackColor = System.Drawing.Color.Transparent;

    //                PnlRpta.Controls.Add(HprRpta);
    //                //PnlRpta.Controls.Add(LnkBtnRpta);
    //                PnlRpta.Controls.Add(new LiteralControl("<br />"));
    //                i+=1;
    //            }
                

    //            LabelResuesta.Text = "Con Respuesta";
    //        }
    //    }
    //}
    protected void ChBExpediente_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBExpediente.Checked == true)
        {
            this.LblExpediente.Visible = true;
            this.TxtBExpediente.Visible = true;
            //  this.RFVNaturaleza.Enabled = true;
        }
        else
        {
            this.LblExpediente.Visible = false;
            this.TxtBExpediente.Visible = false;
            this.TxtBExpediente.Text = "";
            //  this.RFVNaturaleza.Enabled = false;
        }
    }
    protected void ChBProcedencia_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBProcedencia.Checked == true)
        {
            this.LblProcedencia.Visible = true;
            this.TxtBProcedencia.Visible = true;
            //  this.RFVNaturaleza.Enabled = true;
        }
        else
        {
            this.LblProcedencia.Visible = false;
            this.TxtBProcedencia.Visible = false;
            this.TxtBProcedencia.Text = "";
            //  this.RFVNaturaleza.Enabled = false;
        }
    }
    protected void ChBDetalle_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBDetalle.Checked == true)
        {
            this.lbDetalle.Visible = true;
            this.TXTDetalle.Visible = true;
        }
        else
        {
            this.lbDetalle.Visible = false;
            this.TXTDetalle.Visible = false;
            this.TXTDetalle.Text = "";
        }
    }
    protected void TreeVExpediente_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVExpediente.SelectedNode == null)
        {
            ArbolesBLL ObjArbolExp = new ArbolesBLL();
            DSExpedienteSQL.ExpedienteByTextDataTable DTExpediente = new DSExpedienteSQL.ExpedienteByTextDataTable();
            DTExpediente = ObjArbolExp.GetExpedienteTree(e.Node.Value);
            PopulateNodes(DTExpediente, e.Node.ChildNodes, "ExpedienteCodigo", "ExpedienteNombre");
        }
    }
    protected void TreeVExpediente_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVExpediente.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVExpediente.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void ButtonOpen_Click(object sender, EventArgs e)
    {
        Export(false);
    }
    protected void ButtonSaveAs_Click(object sender, EventArgs e)
    {
        Export(true);
    }
    protected void Export(Boolean saveAs)
    {
        DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint();
        MemoryStream stream = new MemoryStream();
        String contentType = "";
        String fileName = "";


        //this.ASPxGridViewExporter1.OptionsPrint.PrintHeadersOnEveryPage = true;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintFilterHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintColumnHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintRowHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintDataHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.ReportHeader.

        int caseSwitch = 1;
        switch (this.listExportFormat.SelectedIndex)
        {
            case 0:
                contentType = "application/pdf";
                fileName = "PivotGrid.pdf";
                this.ASPxGridViewExporter1.WritePdf(stream);
                break;
            case 1:
                contentType = "application/ms-excel";
                fileName = "PivotGrid.xls";
                this.ASPxGridViewExporter1.WriteXls(stream);
                break;
            case 2:
                contentType = "text/enriched";
                fileName = "PivotGrid.rtf";
                this.ASPxGridViewExporter1.WriteRtf(stream);
                break;
            case 3:
                contentType = "text/plain";
                fileName = "PivotGrid.txt";
                this.ASPxGridViewExporter1.WriteCsv(stream);
                break;
        }
        Byte[] buffer = stream.GetBuffer();
        // Dim buffer() As Byte = stream.GetBuffer()

        String disposition;
        if (saveAs)
        {
            disposition = "attachment";
        }
        else
        {
            disposition = "inline";
        }
        if (listExportFormat.SelectedIndex != -1)
        {
            Response.Clear();
            Response.Buffer = false;
            Response.AppendHeader("Content-Type", contentType);
            Response.AppendHeader("Content-Transfer-Encoding", "binary");
            Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
            Response.BinaryWrite(buffer);
            Response.End();
        }
    }
    protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        //if (e.RowType == GridViewRowType.Filter) 
        //{ 

        //}
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            String ExpedienteCodigo = (String)e.GetValue("ExpedienteCodigo");
            String GrupoCodigo = (String)e.GetValue("GrupoCodigo");

            GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["RadicadoCodigo"] as GridViewDataColumn;
            GridViewDataColumn colOps =
                ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
            GridViewDataColumn colRpta =
                ((ASPxGridView)sender).Columns["Rpta"] as GridViewDataColumn;

            HyperLink NroDoc =
                (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRad, "HyperLink1");
            NroDoc.Attributes.Add("onClick", "url(event,1);");

            HyperLink HprVisor =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HyperLinkVisor");
            HprVisor.Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",1);");

            HyperLink HprHisto =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkHisExtven");
            HprHisto.Attributes.Add("onClick", "Historico(event," + NroDoc.Text + ",1);");

            HyperLink HprExp =
          (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkExp");
            HprExp.Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + ExpedienteCodigo + "'," + GrupoCodigo + ");");

            System.Web.UI.WebControls.Image ImgRpta =
          (System.Web.UI.WebControls.Image)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRpta, "Image1");

            Label LabelResuesta =
          (Label)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRpta, "Label6");


            if (LabelResuesta.Text == "0")
            {
                //LabelResuesta.Text = "Sin Respuesta";
                ImgRpta.Visible = false;
            }
            else if (Convert.ToInt32(LabelResuesta.Text) > 0)
            {
                ImgRpta.Visible = true;
                // String Radicade.KeyValue



            }


        }
    }
    protected void callbackPanel_Callback(object source, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {

        litText.Text = GetNotes(e.Parameter).ToString();
    }
    object GetNotes(string id)
    {
        DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
        DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
        DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(id), "1");

        int i = 1;
        foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
        {
            HyperLink HprRpta = new HyperLink();
            HprRpta.ID = "HprRpta" + i.ToString();
            HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
            HprRpta.Target = "_Blank";
            HprRpta.ForeColor = System.Drawing.Color.Blue;
            HprRpta.Font.Underline = true;
            HprRpta.Visible = true;
            HprRpta.Attributes.Add("onClick", "urlInt(event," + DRRadFuenteReg.GrupoRegistroCodigo + ");");

            callbackPanel.Controls.Add(HprRpta);
            callbackPanel.Controls.Add(new LiteralControl("&nbsp;"));
            System.Web.UI.WebControls.Image ImgRpta = new System.Web.UI.WebControls.Image();
            ImgRpta.ID = "ImgRpta" + i.ToString();
            ImgRpta.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.JPG";
            ImgRpta.Attributes.Add("onClick", "VImagenesReg(event," + DRRadFuenteReg.RegistroCodigo + "," + DRRadFuenteReg.GrupoRegistroCodigo + ");");
            callbackPanel.Controls.Add(ImgRpta);
            callbackPanel.Controls.Add(new LiteralControl("<br />"));
            i += 1;
        }
        //Image1.Visible = true;
        //Panel popup = ((Panel)e.Row.FindControl("popup"));

        return "";
    }    
}
      
