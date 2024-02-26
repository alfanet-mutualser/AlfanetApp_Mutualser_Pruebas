using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class _ReporteProcesos : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<ReportParameter> parametros = new List<ReportParameter>();
            // Añado los parámetros necesarios.
            parametros.Add(new ReportParameter("Fecha", DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString()));
            // Añado el/los parámetro/s al ReportViewer.
            this.SerieReportViewer.LocalReport.SetParameters(parametros);

            // Creo uno o varios parámetros de tipo ReportParameter con sus valores.
            ReportParameter parametro = new ReportParameter("Fecha", DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
            // Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            this.SerieReportViewer.LocalReport.SetParameters(new ReportParameter[] { parametro });
        }
    }
}
