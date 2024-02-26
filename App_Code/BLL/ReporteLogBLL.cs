using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSReporteLogTableAdapters;

/// <summary>
/// Descripción breve de ReporteLogBLL
/// </summary>
/// 

[System.ComponentModel.DataObject]
public class ReporteLogBLL
{

    /*Adaptadores de tabla */
    private ReporteLog1TableAdapter ReportLogAdapter = null;
    protected ReporteLog1TableAdapter AdapterReporteLog
    {
        get
        {
            if (ReportLogAdapter == null)
                ReportLogAdapter = new ReporteLog1TableAdapter();

            return ReportLogAdapter;
        }
    }
        private ReporteLog2TableAdapter ReportLogAdapter2 = null;
        protected ReporteLog2TableAdapter AdapterReporteLog2
        {
            get
            {
                if (ReportLogAdapter2 == null)
                    ReportLogAdapter2 = new ReporteLog2TableAdapter();

                return ReportLogAdapter2;
            }
        }

    private ReporteLog3TableAdapter ReportLogAdapter3 = null;
    protected ReporteLog3TableAdapter AdapterReporteLog3
    {
        get
        {
            if (ReportLogAdapter3 == null)
                ReportLogAdapter3 = new ReporteLog3TableAdapter();

            return ReportLogAdapter3;
        }
    }

    private ReporteLog4TableAdapter ReportLogAdapter4 = null;
    protected ReporteLog4TableAdapter AdapterReporteLog4
    {
        get
        {
            if (ReportLogAdapter4 == null)
                ReportLogAdapter4 = new ReporteLog4TableAdapter();

            return ReportLogAdapter4;
        }
    }

    private ReporteLog5TableAdapter ReportLogAdapter5 = null;
    protected ReporteLog5TableAdapter AdapterReporteLog5
    {
        get
        {
            if (ReportLogAdapter5 == null)
                ReportLogAdapter5 = new ReporteLog5TableAdapter();

            return ReportLogAdapter5;
        }
    }
    private ReporteLog6TableAdapter ReportLogAdapter6 = null;
    protected ReporteLog6TableAdapter AdapterReporteLog6
    {
        get
        {
            if (ReportLogAdapter6 == null)
                ReportLogAdapter6 = new ReporteLog6TableAdapter();

            return ReportLogAdapter6;
        }
    }
    private ReporteLog7TableAdapter ReportLogAdapter7 = null;
    protected ReporteLog7TableAdapter AdapterReporteLog7
    {
        get
        {
            if (ReportLogAdapter7 == null)
                ReportLogAdapter7 = new ReporteLog7TableAdapter();

            return ReportLogAdapter7;
        }
    }
    private ReporteLog8TableAdapter ReportLogAdapter8 = null;
    protected ReporteLog8TableAdapter AdapterReporteLog8
    {
        get
        {
            if (ReportLogAdapter8 == null)
                ReportLogAdapter8 = new ReporteLog8TableAdapter();

            return ReportLogAdapter8;
        }
    }
    private ReporteLog9TableAdapter ReportLogAdapter9 = null;
    protected ReporteLog9TableAdapter AdapterReporteLog9
    {
        get
        {
            if (ReportLogAdapter9 == null)
                ReportLogAdapter9 = new ReporteLog9TableAdapter();

            return ReportLogAdapter9;
        }
    }
    private ReporteLog10TableAdapter ReportLogAdapter10 = null;
    protected ReporteLog10TableAdapter AdapterReporteLog10
    {
        get
        {
            if (ReportLogAdapter10 == null)
                ReportLogAdapter10 = new ReporteLog10TableAdapter();

            return ReportLogAdapter10;
        }
    }

    private ReporteLogCorreoTableAdapter ReportLogAdapterCorreo = null;
    protected ReporteLogCorreoTableAdapter AdapterReporteLogCorreo
    {
        get
        {
            if (ReportLogAdapterCorreo == null)
                ReportLogAdapterCorreo = new ReporteLogCorreoTableAdapter();

            return ReportLogAdapterCorreo;
        }
    }

    private ReporteLogReportesTableAdapter ReportLogAdapterReportes = null;
    protected ReporteLogReportesTableAdapter AdapterReporteLogReportes
    {
        get
        {
            if (ReportLogAdapterReportes == null)
                ReportLogAdapterReportes = new ReporteLogReportesTableAdapter();

            return ReportLogAdapterReportes;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]


    /*Metodos para el objectdatasource */
    //DATASET

    public DSReporteLog.ReporteLog1DataTable GetReporteLogs(string GrupoCodigo, string fechaini , string fechafin, string username, string ActividadLogica, string NumeroDocumento)
    {
        try
        {

            if (GrupoCodigo == "")
            {
                GrupoCodigo = null;
            }
            if (NumeroDocumento == "")
            {
                NumeroDocumento = null;
            }

            if (username == "")
            {
                username = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLog.GetDataReporteLogData(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime,username, ActividadLogica, GrupoCodigo, NumeroDocumento);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }
    }


    public DSReporteLog.ReporteLog2DataTable GetReporteLogs2(string GrupoCodigo, string fechaini, string fechafin, string username, string ActividadLogica, string NumeroDocumento)
    {
        try
        {
            
            if (GrupoCodigo == "")
            {
                GrupoCodigo = null;
            }

            if (username == "")
            {
                username = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLog2.GetDataReporteLog2(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime, username, ActividadLogica, GrupoCodigo, NumeroDocumento);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }
    }
    public DSReporteLog.ReporteLog3DataTable GetReporteLogs3(string fechaini, string fechafin, string username, string ActividadLogica)
    {
        try
        {

            if (username == "")
            {
                username = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLog3.GetDataReporteLog3(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime, username, ActividadLogica);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }
    }

    public DSReporteLog.ReporteLog4DataTable GetReporteLogs4(string fechaini, string fechafin, string username, string ActividadLogica)
    {
        try
        {

            if (username == "")
            {
                username = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLog4.GetDataReporteLog4(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime, username, ActividadLogica);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }
    }
    public DSReporteLog.ReporteLog5DataTable GetReporteLogs5(string fechaini, string fechafin, string username, string ActividadLogica)
    {
        try
        {

            if (username == "")
            {
                username = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLog5.GetDataReporteLog5(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime, username, ActividadLogica);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }
    }

    public DSReporteLog.ReporteLog6DataTable GetReporteLogs6(string fechaini, string fechafin, string username, string ActividadLogica)
    {
        try
        {

            if (username == "")
            {
                username = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLog6.GetDataReporteLog6(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime, username, ActividadLogica);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }
    }
    public DSReporteLog.ReporteLog7DataTable GetReporteLogs7(string fechaini, string fechafin, string username, string ActividadLogica)
    {
        try
        {

            if (username == "")
            {
                username = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLog7.GetDataReporteLog7(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime, username, ActividadLogica);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }
    }
    public DSReporteLog.ReporteLog8DataTable GetReporteLogs8(string fechaini, string fechafin, string username, string ActividadLogica)
    {
        try
        {

            if (username == "")
            {
                username = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLog8.GetDataReporteLog8(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime, username, ActividadLogica);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }
    }
    public DSReporteLog.ReporteLog9DataTable GetReporteLogs9(string fechaini, string fechafin, string username, string ActividadLogica)
    {
        try
        {

            if (username == "")
            {
                username = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLog9.GetDataReporteLog9(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime, username, ActividadLogica);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }
    }
    public DSReporteLog.ReporteLog10DataTable GetReporteLogs10(string fechaini, string fechafin, string username, string ActividadLogica)
    {
        try
        {

            if (username == "")
            {
                username = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLog10.GetDataReporteLog10(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime, username, ActividadLogica);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }
    }

    public DSReporteLog.ReporteLogCorreoDataTable GetReporteLogCorreo(string fechaini, string fechafin, string username, string ActividadLogica, string NumeroDocumento)
    {
        try
        {

            if (username == "")
            {
                username = null;
            }

            if (NumeroDocumento == "")
            {
                NumeroDocumento = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLogCorreo.GetDataReporteLogCorreo(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime, username, ActividadLogica, NumeroDocumento);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }

    }

    public DSReporteLog.ReporteLogReportesDataTable GetReporteLogReportes(string fechaini, string fechafin, string username, string ActividadLogica, string NumeroDocumento)
    {
        try
        {

            if (username == "")
            {
                username = null;
            }

            if (NumeroDocumento == "")
            {
                NumeroDocumento = null;
            }

            if (ActividadLogica == "")
            {
                ActividadLogica = null;
            }
            DateTime WFMovimientoFechainiDateTime;
            if (fechaini == "" || fechaini == null)
            {

                WFMovimientoFechainiDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechainiDateTime = Convert.ToDateTime(fechaini);
            }
            DateTime WFMovimientoFechafinDateTime;
            if (fechafin == "" || fechafin == null)
            {
                WFMovimientoFechafinDateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFechafinDateTime = Convert.ToDateTime(fechafin + " " + "23:59:59");
            }
            return AdapterReporteLogReportes.GetDataReporteLogReportes(WFMovimientoFechainiDateTime, WFMovimientoFechafinDateTime, username, ActividadLogica,NumeroDocumento);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la clase BLL. " + e.Message);
        }
    }
}