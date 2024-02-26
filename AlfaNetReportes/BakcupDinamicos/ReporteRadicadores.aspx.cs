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
using DevExpress.XtraExport;
using System.Drawing;


public partial class AlfaNetReportes_Dinamicos_InformeGestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //WebChartControl1.SeriesDataMember = "Series";
        //WebChartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
        //WebChartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
        if (!IsPostBack)
        {
			this.RadDatePicker1.SelectedDate = Convert.ToDateTime("01/" + "01/" + DateTime.Now.Year.ToString()); 
            this.RadDatePicker2.SelectedDate = DateTime.Now;
            // Create chart titles.
            //ChartTitle chartTitle1 = new ChartTitle();

            // Define the text for the titles.
            //chartTitle1.Text = "<color=blue>Grafico Dinamico Gestion de Tareas Correspondencia Enviada</color>";

            // Customize a title's appearance.


            // Add the titles to the chart.
           // WebChartControl1.Titles.AddRange(new ChartTitle[] {
           //     chartTitle1});
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
        //this.ASPxGridViewExporter1.op
        //this.ASPxGridViewExporter1.OptionsPrint.PrintHeadersOnEveryPage = true;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintFilterHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintColumnHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintRowHeaders = DefaultBoolean.True;
        //this.ASPxGridViewExporter1.OptionsPrint.PrintDataHeaders = DefaultBoolean.True;

        String contentType = "";
        String fileName = "";

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

        Response.Clear();
        Response.Buffer = false;
        Response.AppendHeader("Content-Type", contentType);
        Response.AppendHeader("Content-Transfer-Encoding", "binary");
        Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
        Response.BinaryWrite(buffer);
        Response.End();
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        //this.ConsultaRegistros.OptionsChartDataSource.ChartDataVertical = !CheckBox1.Checked;
    }
}
