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
using DevExpress.Utils;
using System.IO;
using DevExpress.XtraCharts;
using DevExpress.XtraExport;
using System.Drawing;
using DevExpress.Web;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxCallbackPanel;
using System.Net;
using System.Net.NetworkInformation;
using DSReporteLogTableAdapters;
// Referencias SpreadsheetLigth y DocumentFormat.openXML
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.ComponentModel;

public partial class _DocRecibido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

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
    protected void ChBFechaFechas_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBFechaFechas.Checked == true)
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
    protected void ChBUsername_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBUsername.Checked == true)
        {

            this.LblUsername.Visible = true;

            this.TxtUsername.Visible = true;

        }
        else
        {

            this.LblUsername.Visible = false;

            this.TxtUsername.Visible = false;

            this.TxtUsername.Text = "";
        }
    }
    protected void ChBGrupocodigo_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBGrupocodigo.Checked == true)
        {
            this.RadBtnLstNumeroDocumento.Visible = true;
            this.TxtNumeroDocumento.Visible = true;
            this.LblNumeroDocumento.Visible = true;

        }
        else
        {
            this.RadBtnLstNumeroDocumento.Visible = false;
            this.RadBtnLstNumeroDocumento.SelectedValue = null;
            this.TxtNumeroDocumento.Visible = false;
            this.TxtNumeroDocumento.Text = "";
            this.LblNumeroDocumento.Visible = false;
            this.AutoCompleteNumeroDocumento.ServiceMethod = "GetDataReportlogImagenesAllRadNumeroDocumento";
        }
    }
    protected void ChBActividadLogica_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBActividadLogica.Checked == true)
        {
            this.LblActividadLogica.Visible = true;
            this.TxtActividadlogica.Visible = true;
        }
        else
        {
            this.LblActividadLogica.Visible = false;
            this.TxtActividadlogica.Visible = false;
            this.TxtActividadlogica.Text = "";
        }
    }
    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            /*Eliminar caracter separador de la busqueda numero de documento*/

            if (TxtNumeroDocumento.Text != "")
            {
                if (TxtNumeroDocumento.Text.Contains(" | "))
                {
                    TxtNumeroDocumento.Text = TxtNumeroDocumento.Text.Remove(TxtNumeroDocumento.Text.IndexOf(" | "));
                }
            }
            else
            {
                TxtNumeroDocumento.Text = null;
            }

            DataTable dt = new DataTable();

            //Parametros del objectdatasource, mismos del procedimiento.
            this.ODSReporteLog2.SelectParameters["fechaini"].DefaultValue = this.TxtFechaInicial.Text;
            this.ODSReporteLog2.SelectParameters["fechafin"].DefaultValue = this.TxtFechaFinal.Text;
            this.ODSReporteLog2.SelectParameters["username"].DefaultValue = this.TxtUsername.Text;
            this.ODSReporteLog2.SelectParameters["ActividadLogica"].DefaultValue = this.TxtActividadlogica.Text;
            this.ODSReporteLog2.SelectParameters["GrupoCodigo"].DefaultValue = this.RadBtnLstNumeroDocumento.SelectedValue.ToString();



            /*  if (this.RBLTblRpt.SelectedValue == "1")
          {*/
            this.AccordionPane2.Visible = true;
            this.AccordionPane3.Visible = false;

            ASPxGridView1.DataSourceID = "ODSReporteLog2";
            //ReportViewer1.LocalReport.DataSources[0].DataSourceId = "";
            ASPxGridView1.DataBind();

            // Siguiente codigo para duplicar la información del Datasource  -- JUAN FIGUEREDO 31-AGO-2020
            List<string> dataColumnNames = new List<string>();
            foreach (GridViewColumn item in ASPxGridView1.Columns)
            {
                GridViewEditDataColumn dataColumn = item as GridViewEditDataColumn;
                if (dataColumn != null)
                {
                    dt.Columns.Add(dataColumn.FieldName);
                    dataColumnNames.Add(dataColumn.FieldName);
                }
            }
            for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
            {
                object[] rowValues = ASPxGridView1.GetRowValues(i, dataColumnNames.ToArray()) as object[];
                dt.Rows.Add(rowValues);
            }
            Session["DatosGrid"] = dt;
            //Fin duplicado de informacion datasource, se utilizará posteriormente para Generar Excel en .Xlsx
            /*}
            else
            {
                ASPxGridView1.DataSourceID = "";
                this.AccordionPane3.Visible = true;
                this.AccordionPane2.Visible = false;

            }*/

            this.MyAccordion.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
            LblError.Text = ex.Message;
        }
    }


    /*Prodecimiento para devolver el id de un campo si este contiene separadores*/
    protected void RadBtnLstNumeroDocumento_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Condicion del Radiobutton Para elegir el metodo a utilizar

        if (RadBtnLstNumeroDocumento.SelectedValue == "1")
        {
            this.AutoCompleteNumeroDocumento.ServiceMethod = "GetDataReportlogImagenesRadNumeroDocumento";
            //this.TxtNumeroDocumento.Text = "";
        }
        else if (RadBtnLstNumeroDocumento.SelectedValue == "2")
        {
            this.AutoCompleteNumeroDocumento.ServiceMethod = "GetDataReportlogImagenesRadNumeroDocumento2";
            // this.TxtNumeroDocumento.Text = "";
        }

    }

    protected void BtnNuevo_Click(object sender, EventArgs e)
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

        try
        {
            
        int caseSwitch = 1;
        if (this.listExportFormat.SelectedIndex != 1)
        {
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
        else //  Generar Excel en formato .xlsx  -- JUAN FIGUEREDO 09-Sep-2020
        {
            string NombreArchivo = "Reporte" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".xlsx";
            string name = AppDomain.CurrentDomain.BaseDirectory + "Excel.xlsx";
            SLDocument osldocument = new SLDocument();

            SLStyle style = new SLStyle();
            style.Font.FontSize = 12;
            style.Font.Bold = true;
            SLStyle styleCOL = new SLStyle();

            DataTable dt = new DataTable();
            dt = (DataTable)Session["DatosGrid"];

            int ic = 1;
            foreach (DataColumn column in dt.Columns)
            {
                osldocument.SetCellStyle(1, ic, style);
                osldocument.SetColumnWidth(ic, 20);
                if (ic == 2) { column.ColumnName = "Fecha Inicial"; }
                if (ic == 3) { column.ColumnName = "Fecha Final"; }
                if (ic == 4) { column.ColumnName = "Actividad"; }
                if (ic == 5) { column.ColumnName = "Grupo"; }
                if (ic == 6) { column.ColumnName = "Modulo"; }
                ic++;
            }

            osldocument.ImportDataTable(1, 1, dt, true);
            //osldocument.SaveAs(pathfile);
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //this.ASPxGridViewExporter1.WriteXls(stream);
            Response.AddHeader("Content-Disposition", "attachment; filename=" + NombreArchivo);
            osldocument.SaveAs(Response.OutputStream);
            Response.End();
            Session["DatosGrid"] = null;
        }
        }
        catch (Exception error)
        {
            
             this.ExceptionDetails.Text = "Se ha presentado un problema, por favor intente nuevamente o en su defecto realice una consulta con menor cantidad de registros.  " + error;

        }


    }



}


