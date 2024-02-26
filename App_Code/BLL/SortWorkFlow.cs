using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSWorkFlowTableAdapters;

namespace Samples.AspNet.CS
{
    public class SortingData
    {
        public SortingData()
        {
        }
        //[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public DataTable SelectMethod(string sortExpression, int WFMoviMientoTipo, int WFMoviMientoTipo2, String DependenciaCodDestino, String GrupoCodigo)
        {
           
            WFMovimientoTableAdapter DSWORKFLOW = new WFMovimientoTableAdapter();
            DSWorkFlow.WFMovimientoDataTable DTWORKFLOW = new DSWorkFlow.WFMovimientoDataTable();
            DTWORKFLOW = DSWORKFLOW.GetWFDocVen(WFMoviMientoTipo, WFMoviMientoTipo2, DependenciaCodDestino, GrupoCodigo, DateTime.Now);
            DataView dvworkflow = new DataView(DTWORKFLOW);
            dvworkflow.Sort = sortExpression;

            DataTable DTWF = dvworkflow.ToTable();

            return DTWF;
            
        }

    }
}

