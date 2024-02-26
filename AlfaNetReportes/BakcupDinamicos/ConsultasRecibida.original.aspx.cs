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
using DevExpress.Web.ASPxPivotGrid;
using System.Collections.Generic;


//using System.Windows.Forms;

public partial class AlfaNetReportes_Dinamicos_ConsultasRecibida : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebChartControl1.SeriesDataMember = "Series";
        WebChartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
        WebChartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
        if (!IsPostBack)
        {
            // Create chart titles.
            ChartTitle chartTitle1 = new ChartTitle();            

            // Define the text for the titles.
            chartTitle1.Text = "<color=blue>Grafico Dinamico Correspondencia Recibida</color>";
                  
            
          

            // Customize a title's appearance.
            

            // Add the titles to the chart.
            WebChartControl1.Titles.AddRange(new ChartTitle[] {
                chartTitle1});
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
        //End Using

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        this.ConsultaRadicados.OptionsChartDataSource.ChartDataVertical = !CheckBox1.Checked;
    }
    protected void ConsultaRadicados_PreRender(object sender, EventArgs e)
    {
        if(!IsPostBack) {
             SetFilterESP(fieldNaturalezaNombre,ASPxComboBox1.SelectedItem.Value.ToString());
             SetFilterESP(fieldYearRadicado, "2010");
         }
     
    }
    void SetFilter(PivotGridField field, int selectNumber)
    {
        object[] values = field.GetUniqueValues();
        List<object> includedValues = new List<object>(values.Length / selectNumber);
        for (int i = 0; i < values.Length; i++)
            if (i % selectNumber == 0)
                includedValues.Add(values[i]);
        field.FilterValues.ValuesIncluded = includedValues.ToArray();
    }
    void SetFilterESP(PivotGridField field, String select)
    {
        object[] values = field.GetUniqueValues();
        List<object> includedValues = new List<object>(values.Length / 4);
        if (select != "TODAS")
        {
            for (int i = 0; i < values.Length; i++)
                if (values[i].ToString().Contains(select))
                {
                    includedValues.Add(values[i]);
                }
            field.FilterValues.ValuesIncluded = includedValues.ToArray();
        }
        else
        {
            for (int i = 0; i < values.Length; i++)
             includedValues.Add(values[i]);
               
            field.FilterValues.ValuesIncluded = includedValues.ToArray();
        }
    }

    protected void ASPxComboBox1_DataBound(object sender, EventArgs e)
    {
        ASPxComboBox1.SelectedIndex = 0;
    }
    protected void ASPxComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ASPxComboBox1.SelectedItem.Value.ToString() == "TRA")
        //{
        //    SetFilterESP(fieldNaturalezaNombre, ASPxComboBox1.SelectedItem.Value.ToString());
        //}
        SetFilterESP(fieldNaturalezaNombre, ASPxComboBox1.SelectedItem.Value.ToString());
        SetFilterESP(fieldYearRadicado, ASPxComboBox2.SelectedItem.Text);
    }
    protected void ASPxComboBox2_DataBound(object sender, EventArgs e)
    {
        ASPxComboBox2.SelectedIndex = ASPxComboBox2.Items.Count - 1;
    }
    protected void ASPxComboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.AlfaWeb.SelectParameters["WFMovimientoFecha"].DefaultValue = "01/01/" + ASPxComboBox2.SelectedItem.Text;
        this.AlfaWeb.SelectParameters["WFMovimientoFecha1"].DefaultValue = "31/12/" + ASPxComboBox2.SelectedItem.Text;
        this.ConsultaRadicados.DataBind();
        SetFilterESP(fieldNaturalezaNombre, ASPxComboBox1.SelectedItem.Value.ToString());
        SetFilterESP(fieldYearRadicado, ASPxComboBox2.SelectedItem.Text);
        AlfaWeb.Dispose();
        ConsultaRadicados.Dispose();
    }
}
