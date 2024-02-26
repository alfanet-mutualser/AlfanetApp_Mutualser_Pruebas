
using System;
using ASP;
using Microsoft;
using Microsoft.Reporting.WebForms;
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
using System.IO;
using DevExpress.Web;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxCallbackPanel;

public partial class _DocEnviado : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
        {  
         try
            {    
                if (!IsPostBack)
                    {
                        this.DDLOtros.SelectedValue = null;
                        this.AccordionPane3.Visible = false;
                        this.AccordionPane2.Visible = true;
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
          if (ChBFechaReg.Checked == true)
               {
              this.LblFechaFinal.Visible = true;
              this.LblFechaInicial.Visible = true;
              this.TxtFechaFinal.Visible = true;
              this.TxtFechaInicial.Visible = true;
              this.ImgCalendarFinal.Visible = true;
              this.ImgCalendarInicial.Visible = true;
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
               }
    }
    protected void ChBNroReg_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBNroReg.Checked == true)
        {
            this.LblNroRegFinal.Visible = true;
            this.LblNroRegInicial.Visible = true;
            this.TxtNroRegFinal.Visible = true;
            this.TxtNroRegInicial.Visible = true;
            
        }
        else
        {
            this.LblNroRegFinal.Visible = false;
            this.LblNroRegInicial.Visible = false;
            this.TxtNroRegFinal.Visible = false;
            this.TxtNroRegInicial.Visible = false;
            this.TxtNroRegFinal.Text = "";
            this.TxtNroRegInicial.Text = "";
        }
    }
    protected void ChBDestino_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBDestino.Checked == true)
        {
            this.LblDestino.Visible = true;
            this.TxtBDestino.Visible = true;
            this.RadioButtonList1.Visible = true;
            //this.RadioButtonList1.SelectedValue = null;
        }
        else
        {      
            this.LblDestino.Visible= false;
            this.TxtBDestino.Visible = false;
            this.RadioButtonList1.Visible = false;
            this.RadioButtonList1.SelectedValue = null;
            this.TxtBDestino.Text =""; 
        }
    }
    protected void ChBProcedencia_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBProcedencia.Checked == true)
        {
            this.LblProcedencia.Visible = true;
            this.TxtBProcedencia.Visible = true;
        }
        else
        {
            this.LblProcedencia.Visible = false;
            this.TxtBProcedencia.Visible = false;
            this.TxtBProcedencia.Text = "";
        }
    }
    protected void ChBExpediente_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBExpediente.Checked == true)
        {
            this.LblExpediente.Visible = true;
            this.TxtBExpediente.Visible = true;
        }
        else
        {
            this.LblExpediente.Visible = false;
            this.TxtBExpediente.Visible = false;
            this.TxtBExpediente.Text = "";
        }
    }
    protected void ChBMedio_CheckedChanged(object sender, EventArgs e)
    {
         if (ChBMedio.Checked == true)
        {
            this.LblMedio.Visible = true;
            this.TxtBMedio.Visible = true;
        }
        else
        {
            this.LblMedio.Visible = false;
            this.TxtBMedio.Visible = false;
            this.TxtBMedio.Text = "";
        }
    }
    protected void ChBNaturaleza_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBNaturaleza.Checked == true)
        {
            this.LblNaturaleza.Visible = true;
            this.TxtBNaturaleza.Visible = true;
        }
        else
        {
            this.LblNaturaleza.Visible = false;
            this.TxtBNaturaleza.Visible = false;
            this.TxtBNaturaleza.Text = "";
        }
    }
    protected void ChBRemite_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBRemite.Checked == true)
        {
            this.LblRemite.Visible = true;
            this.TxtBRemite.Visible = true;
        }
        else
        {
            this.LblRemite.Visible = false;
            this.TxtBRemite.Visible = false;
            this.TxtBRemite.Text = "";
        }
    }
    protected void ChBOtros_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBOtros.Checked == true)
        {
            this.LblBuscarPor.Visible = true;
            this.TxtBOtros.Visible = true;
            this.DDLOtros.Visible = true;
        }
        else
        {
            this.LblBuscarPor.Visible = false;
            this.TxtBOtros.Visible = false;
            this.TxtBOtros.Text = "";
            this.DDLOtros.Visible = false;
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
    protected void TreeVExpediente_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVExpediente.SelectedNode == null)
        {
            ArbolesBLL ObjArbolExp = new ArbolesBLL();
            DSExpedienteSQL.ExpedienteByTextDataTable DTExpediente = new DSExpedienteSQL.ExpedienteByTextDataTable();
            DTExpediente = ObjArbolExp.GetExpedienteTree(e.Node.Value);
            PopulateNodes(DTExpediente, e.Node.ChildNodes,"ExpedienteCodigo","ExpedienteNombre");
        }
    }

    
   protected void TreeVMedio_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVMedio.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVMedio.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void TreeVMedio_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVMedio.SelectedNode == null)
        {
            ArbolesBLL ObjArbolMed = new ArbolesBLL();
            DSMedioSQL.MedioByTextDataTable DTMedio = new DSMedioSQL.MedioByTextDataTable();
            DTMedio = ObjArbolMed.GetMedioTree(Int32.Parse(e.Node.Value));
            PopulateNodes(DTMedio, e.Node.ChildNodes, "MedioCodigo", "MedioNombre");
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
    protected void TreeVRemite_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVRemite.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVRemite.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void TreeVRemite_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVRemite.SelectedNode == null)
        {
            //ArbolesBLL ObjArbolNat = new ArbolesBLL();
            //DSNaturalezaSQL.NaturalezaByTextDataTable DTNaturaleza = new DSNaturalezaSQL.NaturalezaByTextDataTable();
            //DTNaturaleza = ObjArbolNat.GetNaturalezaTree(Int32.Parse(e.Node.Value));
            //PopulateNodes(DTNaturaleza, e.Node.ChildNodes, "NaturalezaCodigo", "NaturalezaNombre");

            ArbolesBLL ObjArbolDep = new ArbolesBLL();
            DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
            DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
            PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
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
            //RegistroBLL ObjConsultaReg = new RegistroBLL();
            //DSRegistro.Registro_ConsultasRegistroDataTable ConsultaRegistro = new DSRegistro.Registro_ConsultasRegistroDataTable();
            //
           //
            if (DDLOtros.SelectedValue == "Detalle")
            {
                this.ODSBuscar.SelectParameters["RegistroDetalle"].DefaultValue = this.TxtBOtros.Text;
                lotros += "Detalle:" + TxtBOtros.Text;
            }
             
            else if (DDLOtros.SelectedValue == "Radicado")
            {
                this.ODSBuscar.SelectParameters["RadicadoCodigo"].DefaultValue = this.TxtBOtros.Text;
                lotros += "RadicadoCodigo:" + TxtBOtros.Text;
            }
            else if (DDLOtros.SelectedValue == "Anexo")
            {
                this.ODSBuscar.SelectParameters["AnexoExtRegistro"].DefaultValue = this.TxtBOtros.Text;
                lotros += "AnexoExtRegistro:" + TxtBOtros.Text;
            }
            else if (DDLOtros.SelectedValue == "NumerodeGuia")
            {
                this.ODSBuscar.SelectParameters["RegistroGuia"].DefaultValue = this.TxtBOtros.Text;
                lotros += "RegistroGuia:" + TxtBOtros.Text;
                //this.ODSBuscarGraph.SelectParameters["RegistroGuia"].DefaultValue = this.TxtBOtros.Text;
            }
            

            this.ODSBuscar.SelectParameters["RegistroTipo"].DefaultValue = this.RadioButtonList1.SelectedValue.ToString();
            this.ODSBuscar.SelectParameters["WFMovimientoFecha"].DefaultValue = this.TxtFechaInicial.Text;
            this.ODSBuscar.SelectParameters["WFMovimientoFecha1"].DefaultValue = this.TxtFechaFinal.Text;
            this.ODSBuscar.SelectParameters["RegistroCodigo"].DefaultValue = this.TxtNroRegInicial.Text;
            this.ODSBuscar.SelectParameters["RegistroCodigo1"].DefaultValue = this.TxtNroRegFinal.Text;
            this.ODSBuscar.SelectParameters["ExpedienteCodigo"].DefaultValue = this.TxtBExpediente.Text;
            this.ODSBuscar.SelectParameters["ProcedenciaCodigo"].DefaultValue = this.TxtBProcedencia.Text;
            this.ODSBuscar.SelectParameters["MedioCodigo"].DefaultValue = this.TxtBMedio.Text;
            //if (this.RadioButtonList1.SelectedValue=="0")
            this.ODSBuscar.SelectParameters["ProcedenciaCodigo"].DefaultValue = this.TxtBDestino.Text;
            //else if (this.RadioButtonList1.SelectedValue == "1")             
            this.ODSBuscar.SelectParameters["DependenciaCodDestino"].DefaultValue = this.TxtBDestino.Text;
            this.ODSBuscar.SelectParameters["NaturalezaCodigo"].DefaultValue = this.TxtBNaturaleza.Text;
            this.ODSBuscar.SelectParameters["NaturalezaNombre"].DefaultValue = this.TxtBNaturaleza.Text;
            this.ODSBuscar.SelectParameters["DependenciaCodigo"].DefaultValue = this.TxtBRemite.Text;
            this.ODSBuscar.SelectParameters["SerieCodigo"].DefaultValue = this.TxtBSerie.Text;
            this.ODSBuscar.SelectParameters["RemiteNombre"].DefaultValue = this.TxtBRemite.Text;
            this.ODSBuscar.SelectParameters["DestinoNombre"].DefaultValue = this.TxtBDestino.Text;
            this.ODSBuscar.SelectParameters["DependenciaConsulta"].DefaultValue = Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();


            if (this.RBLTblRpt.SelectedValue == "1")
            {
                this.AccordionPane2.Visible = true;
                this.AccordionPane3.Visible = false;

                this.ASPxGridView1.DataSourceID = "ODSBuscar";
                this.ReportViewer1.LocalReport.DataSources[0].DataSourceId = "";
                this.ASPxGridView1.DataBind();
            }
            else
            {
                this.ASPxGridView1.DataSourceID = "";
                this.AccordionPane3.Visible = true;
                this.AccordionPane2.Visible = false;

                this.ReportViewer1.LocalReport.DataSources[0].DataSourceId = "ODSBuscar";
                //Microsoft.Reporting.WebForms.ReportDataSource RDS = new Microsoft.Reporting.WebForms.ReportDataSource();
                //RDS.Name = ODSBuscar.ToString();
                //RDS.Value = ODSBuscar.Select();
                //this.ReportViewer1.LocalReport.DataSources.Add(RDS);
                this.ReportViewer1.DataBind();
            }

            /*Registrar el evento de busqueda
             
             */
            /*
            rutinas r1 = new rutinas();
            DataTable t1 = r1.rtn_registrar_log("0", UserId, "6",
                this.TxtFechaInicial.Text + "?" + this.TxtFechaFinal.Text + "?" + this.TxtNroRegInicial.Text + "?" +
                this.TxtNroRegFinal.Text + "?" + this.TxtNroRegFinal.Text + "?" + value_pipe(this.TxtBExpediente.Text) + "?" +
                value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" + value_pipe(TxtBMedio.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" + value_pipe(TxtBRemite.Text) + "?" +
                value_pipe(TxtBSerie.Text) + "?" + Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + "?" + value_pipe(TxtBNaturaleza.Text) + "?" + lotros
                , "2");*/

            //GVBuscar.DataSource = ConsultaRegistro;
            //GVBuscar.Visible = true;
            //GVBuscar.DataBind();
            this.MyAccordion.SelectedIndex = 1;
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {

    }
    protected void GVBuscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //RegistroBLL ObjConsultaReg = new RegistroBLL();
        //DSRegistro.Registro_ConsultasRegistroDataTable ConsultaRegistro = new DSRegistro.Registro_ConsultasRegistroDataTable();
        //    if (DDLOtros.SelectedValue == "")
        //        ConsultaRegistro = ObjConsultaReg.GetConsultasRegistro(this.RadioButtonList1.SelectedValue.ToString(), this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRegInicial.Text, this.TxtNroRegFinal.Text, null, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, null, null, this.TxtBNaturaleza.Text, this.TxtBRemite.Text.ToString(), this.TxtBSerie.Text.ToString());
        //    else if (DDLOtros.SelectedValue == "Detalle")
        //        ConsultaRegistro = ObjConsultaReg.GetConsultasRegistro(this.RadioButtonList1.SelectedValue.ToString(), this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRegInicial.Text, this.TxtNroRegFinal.Text, null, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, this.TxtBOtros.Text.ToString(), null, this.TxtBNaturaleza.Text, this.TxtBRemite.Text.ToString(), this.TxtBSerie.Text.ToString());
        //    else if (DDLOtros.SelectedValue == "Radicado")
        //        ConsultaRegistro = ObjConsultaReg.GetConsultasRegistro(this.RadioButtonList1.SelectedValue.ToString(), this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRegInicial.Text, this.TxtNroRegFinal.Text, this.TxtBOtros.Text.ToString(), this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, null, null, this.TxtBNaturaleza.Text, this.TxtBRemite.Text.ToString(), this.TxtBSerie.Text.ToString());
        //    else if (DDLOtros.SelectedValue == "Anexo")
        //        ConsultaRegistro = ObjConsultaReg.GetConsultasRegistro(this.RadioButtonList1.SelectedValue.ToString(), this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRegInicial.Text, this.TxtNroRegFinal.Text, null, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, null, this.TxtBOtros.Text.ToString(), this.TxtBNaturaleza.Text, this.TxtBRemite.Text.ToString(), this.TxtBSerie.Text.ToString());       
        //GVBuscar.DataSource = ConsultaRegistro;
        //this.GVBuscar.PageIndex = e.NewPageIndex;
        //this.GVBuscar.DataBind();
    }
    protected void GVBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int dato1 = GVBuscar.SelectedIndex;
        //String dato = GVBuscar.SelectedRow.Cells[0].Text;
        ////String dato = GVBuscar.Rows[dato1].Cells[0].Text;
        //Session["NroDoc"] = "1" + dato;
        //Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //String RadicadoCodigo = GVBuscar.DataKeys[dato1].Value.ToString();
        ////String RadicadoCodigo = GVBuscar.SelectedDataKey.Value.ToString();
        ////String RadicadoCodigo = this.GVBuscar.SelectedValue.ToString();
        //Session["NroDoc"] = "1" + RadicadoCodigo;
        //Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx");
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
        //    //this.LblSearchDestino.Text = "Busqueda Destino";
        //    this.LinkButton2.Text = "Codigo";
        //    this.WatermarkDestino.WatermarkText = "Busqueda Dependencia Destino";
            this.AutoCompleteDestino.ServiceMethod = "GetDependenciaByTextnull";
        //    //this.AutoCompleteNatulezaDoc.ServiceMethod = "GetDependenciaByText";
            this.TxtBDestino.Text = "";
            this.PopupControlDestino.Enabled = true;
        //    this.PopCDestino.Enabled = true;
        }
        if (RadioButtonList1.SelectedValue == "0")
        {
        //    //this.LblSearchDestino.Text = "Busqueda Destino";
        //    LinkButton2.Text = "NUI";
        //    WatermarkDestino.WatermarkText = "Busqueda Procedencia Destino";
            this.AutoCompleteDestino.ServiceMethod = "GetProcedenciaByTextNombre";
            
            this.TxtBDestino.Text = "";
            this.PopupControlDestino.Enabled = false;
        //    this.PopCDestino.Enabled = false;
        }
        //RadioButtonList1.Focus();
        //this.SetFocus(RadioButtonList1);              
    }
    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVSerie.SelectedNode == null)
        {
            ArbolesBLL ObjArbolSer = new ArbolesBLL();
            DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();

            //DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
            DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
            PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
        }
    }
    protected void TreeVSerie_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVSerie.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVSerie.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void ChBSerie_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBSerie.Checked == true)
        {
            this.LblSerie.Visible = true;
            this.TxtBSerie.Visible = true;
        }
        else
        {
            this.LblSerie.Visible = false;
            this.TxtBSerie.Visible = false;
            this.TxtBSerie.Text = "";
        }
    }
    protected void GVBuscar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink NroDoc = ((HyperLink)e.Row.FindControl("HyperLink1"));

            NroDoc.Attributes.Add("onClick", "urlInt(event,2);");
            ((HyperLink)e.Row.FindControl("HyperLinkVisor")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",2);");
            ((HyperLink)e.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + ",2);");

            //NroDoc.Attributes.Add("onClick", "urlInt(event);");
            //((HyperLink)e.Row.FindControl("HyperLinkVisor")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ");");

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
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        //this.ConsultaRegistros.OptionsChartDataSource.ChartDataVertical = !CheckBox1.Checked;
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
                ((ASPxGridView)sender).Columns["RegistroCodigo"] as GridViewDataColumn;
            GridViewDataColumn colOps =
                ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
            GridViewDataColumn colRpta =
                ((ASPxGridView)sender).Columns["Rpta"] as GridViewDataColumn;

            HyperLink NroDoc =
                (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRad, "HyperLink1");
            NroDoc.Attributes.Add("onClick", "urlInt(event,2);");

            HyperLink HprVisor =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HyperLinkVisor");
            HprVisor.Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",2);");

            HyperLink HprHisto =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkHisExtven");
            HprHisto.Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + ",2);");

            HyperLink HprExp =
         (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkExp");
            HprExp.Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + ExpedienteCodigo + "'," + GrupoCodigo + ");");

          }
    }
}
      
