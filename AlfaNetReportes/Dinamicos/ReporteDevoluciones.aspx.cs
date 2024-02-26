using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class AlfanetReportes_Dinamicos_ReporteDevoluciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
    }
}