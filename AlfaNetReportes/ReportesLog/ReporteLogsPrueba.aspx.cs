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
// Referencias SpreadsheetLigth y DocumentFormat.openXML
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.ComponentModel;

public partial class AlfaNetReportes_ReportesLog_ReporteLogs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void ChBFechaReport_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBFechaReport.Checked == true)
        {
            this.LblFechaInicial.Visible = true;
            this.LblFechaFinal.Visible = true;
            this.TxtFechaIni.Visible = true;
            this.TxtFechaFinal.Visible = true;
            this.ImgCalendarInicial.Visible = true;
            this.ImgCalendarFinal.Visible = true;

            
        }

        else
        {
            this.LblFechaInicial.Visible = false;
            this.LblFechaFinal.Visible = false;
            this.TxtFechaIni.Visible = false;
            this.TxtFechaFinal.Visible = false;
            this.TxtFechaIni.Text = "";
            this.TxtFechaFinal.Text = "";
            this.ImgCalendarInicial.Visible = false;
            this.ImgCalendarFinal.Visible = false;

        } 
        }

    protected void ChbUsuario_CheckedChanged(object sender, EventArgs e)
    {

        if (ChbUsuario.Checked == true)
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

    protected void ChbActividad_CheckedChanged(object sender, EventArgs e)
    {
        if (ChbActividad.Checked == true)
        {
            this.LblActividad.Visible = true;
            this.TxtActividad.Visible = true;
        }
        else
        {
            this.LblActividad.Visible = false;
            this.TxtActividad.Visible = false;
            this.TxtActividad.Text = "";
        }
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        filtrar();
    }

    private void filtrar()
    {


        GridView1.Visible = true;

        DataTable dt = new DataTable();

        this.ODSReporteLog.SelectParameters["fechaini"].DefaultValue = this.TxtFechaIni.Text;
        this.ODSReporteLog.SelectParameters["fechafin"].DefaultValue = this.TxtFechaFinal.Text;
        this.ODSReporteLog.SelectParameters["username"].DefaultValue = this.TxtUsername.Text;
        this.ODSReporteLog.SelectParameters["ActividadLogica"].DefaultValue = this.TxtActividad.Text;
        this.ODSReporteLog.SelectParameters["GrupoCodigo"].DefaultValue = this.DropDownListGrupoCodigo.SelectedValue.ToString();

        this.GridView1.DataSourceID = "ODSReporteLog";
        /*try
        {
            DateTime? fechaini = Convert.ToDateTime(TxtFechaIni.Text);
            DateTime? fechafin = Convert.ToDateTime(TxtFechaFinal.Text);
            string Username = TxtUsername.Text;
            string ActividadLogica = TxtActividad.Text;
            int GrupoCodigo = Convert.ToInt32(DropDownListGrupoCodigo.SelectedValue);

            if (TxtUsername.Text == "")
            {
                Username = null;
            }
            if (TxtFechaIni.Text == "")
            {
                fechaini = null;
            }
            if (TxtFechaFinal.Text == "")
            {
                fechafin = null;
            }
            if (TxtActividad.Text == "")
            {
                ActividadLogica = null;
            }
            
            DSReporteLogTableAdapters.ReporteLog1TableAdapter OBJReport = new DSReporteLogTableAdapters.ReporteLog1TableAdapter();
            //OBJReport.GetData(FechaInicial,FechaFinal);


            GridView1.DataSource = OBJReport.GetData(fechaini, fechafin, Username, ActividadLogica, GrupoCodigo);
            Session["datasourcegu1"] = GridView1.DataSource;
            GridView1.DataBind();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {


                int id = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
                string name = GridView1.Rows[i].Cells[1].Text;


            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
            Lblerror.Text = ex.Message;

        } */
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = Session["datasourcegu1"];
        GridView1.DataBind();

    }

    
}
