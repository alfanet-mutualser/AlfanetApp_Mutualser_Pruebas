
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

public partial class _Expediente : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
        {  
            
         try
            {
                ACExpediente.ContextKey = Profile.GetProfile(Profile.UserName).CodigoDepUsuario;
                HFDependenciaConsulta.Value = Profile.GetProfile(Profile.UserName).CodigoDepUsuario;
                this.ODSBuscar.SelectParameters["DependenciaConsulta"].DefaultValue = Profile.GetProfile(Profile.UserName).CodigoDepUsuario;
                if (!IsPostBack)
                    {
                        
                        string Expediente = Request["ExpedienteCodigo"];
                        if (Expediente != null)
                        {
                            this.MyAccordion.SelectedIndex = 1;

                            this.ODSWFExpediente.SelectParameters["ExpedienteCodigo"].DefaultValue = Expediente;

                            //this.GVExpediente.DataBind();
                        }
                     
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
    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        String ExpedienteCodigo;
        ExpedienteCodigo = TxtExpediente.Text;
        if (ExpedienteCodigo != null)
        {
            if (ExpedienteCodigo.Contains(" | "))
            {
                ExpedienteCodigo = ExpedienteCodigo.Remove(ExpedienteCodigo.IndexOf(" | "));
            }
        }
        String HF = HFCodigoSeleccionado.Value;
        this.ODSBuscar.SelectParameters["ExpedienteNombre"].DefaultValue = null;
        this.ODSBuscar.SelectParameters["ExpedienteCodigo"].DefaultValue = ExpedienteCodigo;
        //this.ASPxGridView1.gr
        this.ASPxGridView1.DataBind();

    }
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
            this.ACExpediente.ServiceMethod = "GetExpedienteByTextNombre";
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
            this.ACExpediente.ServiceMethod = "GetExpedienteByTextId";
    }
    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.TxtExpediente.Text = "";
        this.ODSBuscar.SelectParameters["ExpedienteNombre"].DefaultValue = null;
        this.ODSBuscar.SelectParameters["ExpedienteCodigo"].DefaultValue = null;
        ASPxGridView1.DataBind();
    }
    protected void LBtnExpediente_Click(object sender, EventArgs e)
    {
        /*Aqui se muestra los documentos relacionados al expediente*/
        this.MyAccordion.SelectedIndex = 1;
               
        this.ODSWFExpediente.SelectParameters["ExpedienteCodigo"].DefaultValue = ((LinkButton)sender).Text;
        this.ASPxGVExpediente.DataSourceID = "ODSWFExpediente";
        this.ASPxGVExpediente.DataBind();
                
    }       
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        this.HFCodigoSeleccionado.Value = "NroDoc";
    }   
    
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        this.HFCodigoSeleccionado.Value = "Imagenes";
    }
    
    protected void ASPxGVExpediente_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            String NroDoc1 = (String)e.GetValue("NumeroDocumento");
            String CodArchivo = (String)e.GetValue("CZ");
           
            GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["NumeroDocumento"] as GridViewDataColumn;
            GridViewDataColumn colOps =
                ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
            
            //HyperLink NroDoc = ((HyperLink)e.Row.FindControl("HyperLink1"));

                HyperLink NroDoc =
                    (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRad, "HyperLink1");
                
                

                HyperLink HprVisor =
               (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkImgExtVen");
                

            //   // HyperLink HprHisto =
            //   //(HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkHisExtven");
            //   // HprHisto.Attributes.Add("onClick", "Historico(event," + NroDoc.Text + ",1);");
                String[] Ext = e.KeyValue.ToString().Split('|');

                if (Ext[2] == "1")
                {
                    NroDoc.Attributes.Add("onClick", "url(event,1);");
                    HprVisor.Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",1);");
                }
                else if (Ext[2] == "2")
                {
                    NroDoc.Attributes.Add("onClick", "urlInt(event,1);");
                    HprVisor.Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",2);");
                }
                else if (Ext[2] == "Archivo")
                {
                    if (Ext[1] != "")
                    {
                        NroDoc.Attributes.Add("onClick", "urlInt(event,1);");
                    }else
                        if (NroDoc.Text == "")
                        {
                            NroDoc.Text = "undefined";
                        }
                    HprVisor.Attributes.Add("onClick", "VImagenesArc(event," + NroDoc.Text + "," + CodArchivo + ",1);");

                }
                else if (Ext[2] == "")
                {
                    if (Ext[0] == "1")
                    {
                        NroDoc.Attributes.Add("onClick", "url(event,1);");
                        HprVisor.Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",1);");
                    }
                    else if (Ext[0] == "2")
                    {
                        NroDoc.Attributes.Add("onClick", "urlInt(event,1);");
                        HprVisor.Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",1);");
                    }
                }
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
}
      
