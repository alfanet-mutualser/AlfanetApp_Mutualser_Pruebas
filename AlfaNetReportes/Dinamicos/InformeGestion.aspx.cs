using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DevExpress.Utils;

public partial class AlfanetReportes_Dinamicos_InformeGestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager EstablecerTimeOut = new ScriptManager();
        EstablecerTimeOut.AsyncPostBackTimeout = 36000;

        if (!IsPostBack)
        {
            this.telkFechaInicial.SelectedDate = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            this.telkFechaFinal.SelectedDate = DateTime.Now;
        }
    }

    protected void ButtonOpen_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            ExportRadicado(false);
        }
        if (RadioButtonList1.SelectedValue == "2")
        {
            ExportRegistro(false);
        }
    }
    protected void ButtonSaveAs_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            ExportRadicado(false);
        }
        if (RadioButtonList1.SelectedValue == "2")
        {
            ExportRegistro(false);
        }
    }
    protected void ExportRadicado(Boolean saveAs)
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

    protected void ExportRegistro(Boolean saveAs)
    {
        DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint();
        MemoryStream stream = new MemoryStream();
        this.ASPxPivotGridExporter2.OptionsPrint.PrintHeadersOnEveryPage = true;
        this.ASPxPivotGridExporter2.OptionsPrint.PrintFilterHeaders = DefaultBoolean.True;
        this.ASPxPivotGridExporter2.OptionsPrint.PrintColumnHeaders = DefaultBoolean.True;
        this.ASPxPivotGridExporter2.OptionsPrint.PrintRowHeaders = DefaultBoolean.True;
        this.ASPxPivotGridExporter2.OptionsPrint.PrintDataHeaders = DefaultBoolean.True;

        String contentType = "";
        String fileName = "";

        switch (this.listExportFormat.SelectedIndex)
        {
            case 0:
                contentType = "application/pdf";
                fileName = "PivotGrid.pdf";
                this.ASPxPivotGridExporter2.ExportToPdf(stream);
                break;
            case 1:
                contentType = "application/ms-excel";
                fileName = "PivotGrid.xls";
                this.ASPxPivotGridExporter2.ExportToXls(stream);
                break;
            case 2:
                contentType = "multipart/related";
                fileName = "PivotGrid.mht";
                this.ASPxPivotGridExporter2.ExportToMht(stream, "utf-8", "ASPxPivotGrid Printing Sample", true);
                break;
            case 3:
                contentType = "text/enriched";
                fileName = "PivotGrid.rtf";
                this.ASPxPivotGridExporter2.ExportToRtf(stream);
                break;
            case 4:
                contentType = "text/plain";
                fileName = "PivotGrid.txt";
                this.ASPxPivotGridExporter2.ExportToText(stream);
                break;
            case 5:
                contentType = "text/html";
                fileName = "PivotGrid.htm";
                ASPxPivotGridExporter2.ExportToHtml(stream, "utf-8", "ASPxPivotGrid Printing Sample", true);
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

    protected void AlfaWeb_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 120;
    }

    protected void imgBtBuscar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string FechaInicial = null, FechaFinal = null;

            if (null != this.telkFechaInicial.SelectedDate && null != this.telkFechaFinal.SelectedDate)
            {
                FechaInicial = this.telkFechaInicial.SelectedDate.ToString();
                FechaFinal = this.telkFechaFinal.SelectedDate.ToString();
            }
            else
            {
                this.ConsultaRegistros.DataSource = null;
                this.ConsultaRegistros.DataBind();
            }

            if (!String.IsNullOrEmpty(FechaInicial) && !String.IsNullOrEmpty(FechaFinal))
            {
                if (RadioButtonList1.SelectedValue == "1")
                {
                    this.AlfaWeb.SelectParameters["WFMovimientoFecha"].DefaultValue = FechaInicial;
                    this.AlfaWeb.SelectParameters["WFMovimientoFecha1"].DefaultValue = FechaFinal;
                    this.ConsultaRegistros.DataBind();
                    AlfaWeb.Dispose();
                    ConsultaRegistros.Dispose();
                }
                if (RadioButtonList1.SelectedValue == "2")
                {
                    this.Alfaweb1.SelectParameters["WFMovimientoFecha"].DefaultValue = FechaInicial;
                    this.Alfaweb1.SelectParameters["WFMovimientoFecha1"].DefaultValue = FechaFinal;
                    this.ASPxPivotGrid1.DataBind();
                    Alfaweb1.Dispose();
                    ASPxPivotGrid1.Dispose();
                }
            }
            else
            {
                this.ConsultaRegistros.DataSource = null;
                this.ConsultaRegistros.DataBind();
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
        }
    }

    protected void RadioButtonList1_event(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "2")
        {
            PanelConsultaRadicados.Visible = false;
            PanelConsultaRegistro.Visible = true;
            this.telkFechaInicial.SelectedDate = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            this.telkFechaFinal.SelectedDate = DateTime.Now;
        }
        if (RadioButtonList1.SelectedValue == "1")
        {
            PanelConsultaRadicados.Visible = true;
            PanelConsultaRegistro.Visible = false;
            this.telkFechaInicial.SelectedDate = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            this.telkFechaFinal.SelectedDate = DateTime.Now;
        }
    }
}