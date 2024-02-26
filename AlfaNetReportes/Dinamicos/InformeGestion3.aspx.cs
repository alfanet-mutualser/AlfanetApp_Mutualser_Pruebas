using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Utils;
using System.IO;
using DevExpress.XtraCharts;
using System.Drawing;


public partial class AlfaNetReportes_Dinamicos_InformeGestion3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //WebChartControl1.SeriesDataMember = "Series";
        //WebChartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
        //WebChartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
        ScriptManager EstablecerTimeOut = new ScriptManager();
        EstablecerTimeOut.AsyncPostBackTimeout = 36000;
        //EstablecerTimeOut.
        
        if (!IsPostBack)
        {

            this.telkFechaInicial.SelectedDate = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString()); 
            this.telkFechaFinal.SelectedDate = DateTime.Now;
            // Create chart titles.
            //ChartTitle chartTitle1 = new ChartTitle();

            // Define the text for the titles.
            //chartTitle1.Text = "<color=blue>Grafico Dinamico Gestion de Tareas Correspondencia Enviada</color>";

            // Customize a title's appearance.


            // Add the titles to the chart.
            //WebChartControl1.Titles.AddRange(new ChartTitle[] {
            //    chartTitle1});

           if(RadioButtonList1.SelectedValue.ToString() == "1")
           {
               ConsultaRegistros.Visible = true;
               ConsultaRegistrosExternos.Visible = false;
           }
           else
           {
               ConsultaRegistros.Visible = false;
               ConsultaRegistrosExternos.Visible = true;
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
        if (RadioButtonList1.SelectedValue.ToString() == "1")
        {
            ASPxPivotGridExporter1.ASPxPivotGridID = "ConsultaRegistros";
        }
        else
        {
            ASPxPivotGridExporter1.ASPxPivotGridID = "ConsultaRegistrosExternos";
        }

        DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint();
        MemoryStream stream = new MemoryStream();
        this.ASPxPivotGridExporter1.OptionsPrint.PrintHeadersOnEveryPage = true;
        this.ASPxPivotGridExporter1.OptionsPrint.PrintFilterHeaders = DefaultBoolean.True;
        this.ASPxPivotGridExporter1.OptionsPrint.PrintColumnHeaders = DefaultBoolean.True;
        this.ASPxPivotGridExporter1.OptionsPrint.PrintRowHeaders = DefaultBoolean.True;
        this.ASPxPivotGridExporter1.OptionsPrint.PrintDataHeaders = DefaultBoolean.True;

        String contentType = "";
        String fileName = "";

        int caseSwitch = 1;
        switch (this.listExportFormat.SelectedIndex)
        {
            case 0:
                contentType = "application/pdf";
                fileName = "PivotGrid.pdf";
                this.ASPxPivotGridExporter1.ExportToPdf(stream);
                break;
            case 1:
                contentType = "application/ms-excel";
                fileName = "PivotGrid.xls";
                this.ASPxPivotGridExporter1.ExportToXls(stream);
                break;
            case 2:
                contentType = "multipart/related";
                fileName = "PivotGrid.mht";
                this.ASPxPivotGridExporter1.ExportToMht(stream, "utf-8", "ASPxPivotGrid Printing Sample", true);
                break;
            case 3:
                contentType = "text/enriched";
                fileName = "PivotGrid.rtf";
                this.ASPxPivotGridExporter1.ExportToRtf(stream);
                break;
            case 4:
                contentType = "text/plain";
                fileName = "PivotGrid.txt";
                this.ASPxPivotGridExporter1.ExportToText(stream);
                break;
            case 5:
                contentType = "text/html";
                fileName = "PivotGrid.htm";
                ASPxPivotGridExporter1.ExportToHtml(stream, "utf-8", "ASPxPivotGrid Printing Sample", true);
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

        Response.Clear();
        Response.Buffer = false;
        Response.AppendHeader("Content-Type", contentType);
        Response.AppendHeader("Content-Transfer-Encoding", "binary");
        Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
        Response.BinaryWrite(buffer);
        Response.End();
    }

    
    protected void AlfaWeb_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 120;
    }
    protected void AlfaWebExt_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 120;
    }
    protected void imgBtBuscar_Click(object sender, ImageClickEventArgs e)
    {
        string FechaInicial = null, FechaFinal = null;

        if (null != this.telkFechaInicial.SelectedDate && null != this.telkFechaFinal.SelectedDate) 
        {
            FechaInicial = this.telkFechaInicial.SelectedDate.ToString();
            FechaFinal = this.telkFechaFinal.SelectedDate.ToString();
        }

                
        if (!String.IsNullOrEmpty(FechaInicial) && !String.IsNullOrEmpty(FechaFinal)) 
        {
            this.AlfaWeb.SelectParameters["WFMovimientoFecha"].DefaultValue = FechaInicial;
            this.AlfaWeb.SelectParameters["WFMovimientoFecha1"].DefaultValue = FechaFinal;
            this.ConsultaRegistros.DataBind();
            AlfaWeb.Dispose();
            ConsultaRegistros.Dispose();

        }  
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1") // 1 = Interno
        {
            ConsultaRegistros.Visible = true;
            ConsultaRegistrosExternos.Visible = false;
        }
        else if (RadioButtonList1.SelectedValue == "0") // 2 = Externo
        {
            ConsultaRegistrosExternos.Visible = true;
            ConsultaRegistros.Visible = false;
        }
    }
    protected void RadioButtonList1_Load(object sender, EventArgs e)
    {
        try
        {
            ////if (!IsPostBack)
            ////{
            //foreach (ListItem RBLI in RadioButtonList1.Items)
            //{
            //    RBLI.Attributes.Add("onclick", "checkControl('" + TxtDestino.ClientID + "')");
            //}
            ////}

        }
        catch (Exception Error)
        {
            //this.ExceptionDetails.Text = "Problema" + Error;
        }
    }

}