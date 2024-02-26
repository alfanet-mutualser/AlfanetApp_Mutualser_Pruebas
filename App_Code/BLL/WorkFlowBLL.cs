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
using DSWorkFlowTableAdapters;


/// <summary>
/// Descripción breve de ExpedienteBLL
/// </summary>
//

[System.ComponentModel.DataObject]
public class WorkFlowBLL
{
   
    private WFMovimientoTableAdapter _WFMovDataAdapter = null;
    private int Resultados = 0;
    

    protected WFMovimientoTableAdapter AdapterWFMovConsultas
    {
        get
        {
            if (_WFMovDataAdapter == null)
                _WFMovDataAdapter = new WFMovimientoTableAdapter();

            return _WFMovDataAdapter;
        }
    }


    /*Procedimiento para obtener los resultados paginados en documentos vencidos*/
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSWorkFlow.WFMovimientoDataTable GetDocVenv1(int WFMovimientoTipo1, int WFMovimientoTipo2, string DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, int maximumRows, int startRowIndex, ObjectDataSourceSelectingEventArgs e)
    {
        WFMovimientoTableAdapter _t1 = new WFMovimientoTableAdapter();
        DSWorkFlow.WFMovimientoDataTable _t2 = new DSWorkFlow.WFMovimientoDataTable();
        try
        {
            _t2 = _t1.GetDocVenv3DataBy(WFMovimientoTipo1, WFMovimientoTipo2, DependenciaCodDestino, GrupoCodigo, WFMovimientoFecha, maximumRows, startRowIndex);
            if (_t2.Rows.Count > 0)
            {
                e.Arguments.TotalRowCount = int.Parse(_t2.Rows[0].ItemArray[19].ToString());
            }
            else
            {
                e.Arguments.TotalRowCount = 0;
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error en la capa BLL. " + ex.Message);
        }
        return _t2;
    }

    /*metodo para devolver la cantidad de resultados obtenidos de documentos vencidos*/
    public int GetDocVenv1Rows(Int32 WFMovimientoTipo1, Int32 WFMovimientoTipo2, String DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, ObjectDataSourceSelectingEventArgs e)
    {

        return e.Arguments.TotalRowCount;
        /*
        int res = 0;
        try
        {
            using(WFMovimientoTableAdapter _tempda = new WFMovimientoTableAdapter())
            {
                res = Int32.Parse(_tempda.GetDocVenv3DataBy(WFMovimientoTipo1, WFMovimientoTipo2, DependenciaCodDestino, GrupoCodigo, WFMovimientoFecha, maximumRows, startRowIndex).Rows[0].ItemArray[21].ToString());
                
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error en la capa BLL. " + ex.Message);
        }
        return res;
      */
    }


    /*Procedimiento para obtener los resultados paginados en documentos proximos a vencer*/
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSWorkFlow.WFMovimientoDataTable GetDocProxVenv1(int WFMovimientoTipo, int WFMovimientoTipo2, string DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, int maximumRows, int startRowIndex, ObjectDataSourceSelectingEventArgs e)
    {
        WFMovimientoTableAdapter _t1 = new WFMovimientoTableAdapter();
        DSWorkFlow.WFMovimientoDataTable _t2 = new DSWorkFlow.WFMovimientoDataTable();
        try
        {
            _t2 = _t1.GetDocProxVenv3By(WFMovimientoTipo, WFMovimientoTipo2, DependenciaCodDestino, GrupoCodigo, WFMovimientoFecha, maximumRows, startRowIndex);
            if (_t2.Rows.Count > 0)
            {
                e.Arguments.TotalRowCount = int.Parse(_t2.Rows[0].ItemArray[19].ToString());
            }
            else
            {
                e.Arguments.TotalRowCount = 0;
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error en la capa BLL. " + ex.Message);
        }
        return _t2;
    }

    /*metodo para devolver la cantidad de resultados obtenidos de documentos proximos a vencer*/
    public int GetDocProxVenv1Rows(Int32 WFMovimientoTipo, Int32 WFMovimientoTipo2, String DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, ObjectDataSourceSelectingEventArgs e)
    {
        return e.Arguments.TotalRowCount;
    }

    /*Procedimiento para obtener los resultados paginados en documentos pendientes*/
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSWorkFlow.WFMovimientoDataTable GetDocPendv1(int WFMovimientoTipo, int WFMovimientoTipo2, string DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, int maximumRows, int startRowIndex, ObjectDataSourceSelectingEventArgs e)
    {
        WFMovimientoTableAdapter _t1 = new WFMovimientoTableAdapter();
        DSWorkFlow.WFMovimientoDataTable _t2 = new DSWorkFlow.WFMovimientoDataTable();
        try
        {
            _t2 = _t1.GetDocPenv3By(WFMovimientoTipo, WFMovimientoTipo2, DependenciaCodDestino, GrupoCodigo, WFMovimientoFecha, maximumRows, startRowIndex);
            if (_t2.Rows.Count > 0)
            {
                e.Arguments.TotalRowCount = int.Parse(_t2.Rows[0].ItemArray[19].ToString());
            }
            else
            {
                e.Arguments.TotalRowCount = 0;
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error en la capa BLL. " + ex.Message);
        }
        return _t2;
    }

    /*metodo para devolver la cantidad de resultados obtenidos de documentos pendientes*/
    public int GetDocPendv1Rows(Int32 WFMovimientoTipo, Int32 WFMovimientoTipo2, String DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, ObjectDataSourceSelectingEventArgs e)
    {
        return e.Arguments.TotalRowCount;
    }


    /*Procedimiento para obtener los resultados paginados en documentos copia recibidos*/
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSWorkFlow.WFMovimientoDataTable GetDocCopiav1(int WFMovimientoTipo, int WFMovimientoTipo2, string DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, int maximumRows, int startRowIndex, ObjectDataSourceSelectingEventArgs e)
    {
        WFMovimientoTableAdapter _t1 = new WFMovimientoTableAdapter();
        DSWorkFlow.WFMovimientoDataTable _t2 = new DSWorkFlow.WFMovimientoDataTable();
        try
        {
            _t2 = _t1.GetDocCopiav3By(WFMovimientoTipo, WFMovimientoTipo2, DependenciaCodDestino, GrupoCodigo, WFMovimientoFecha, maximumRows, startRowIndex);
            if (_t2.Rows.Count > 0)
            {
                e.Arguments.TotalRowCount = int.Parse(_t2.Rows[0].ItemArray[17].ToString());
            }
            else
            {
                e.Arguments.TotalRowCount = 0;
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error en la capa BLL. " + ex.Message);
        }
        return _t2;
    }

    /*metodo para devolver la cantidad de resultados obtenidos de documentos  copia recibidos*/
    public int GetDocCopiav1Rows(Int32 WFMovimientoTipo, Int32 WFMovimientoTipo2, String DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, ObjectDataSourceSelectingEventArgs e)
    {
        return e.Arguments.TotalRowCount;
    }


    /*Procedimiento para obtener los resultados paginados en documentos copia enviados*/
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSWorkFlow.WFMovimiento_ReadWFMovimientoCopiaEnviadoDataTable GetDocCopiaEnviadosv1(int WFMovimientoTipo, int WFMovimientoTipo2, string DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, int maximumRows, int startRowIndex, ObjectDataSourceSelectingEventArgs e)
    {
        WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter _t1 = new WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter();
        DSWorkFlow.WFMovimiento_ReadWFMovimientoCopiaEnviadoDataTable _t2 = new DSWorkFlow.WFMovimiento_ReadWFMovimientoCopiaEnviadoDataTable();
        try
        {
            _t2 = _t1.GetDocCopiaEnviadav3By(WFMovimientoTipo, WFMovimientoTipo2, DependenciaCodDestino, GrupoCodigo, WFMovimientoFecha, maximumRows, startRowIndex);
            if (_t2.Rows.Count > 0)
            {
                e.Arguments.TotalRowCount = int.Parse(_t2.Rows[0].ItemArray[15].ToString());
            }
            else
            {
                e.Arguments.TotalRowCount = 0;
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error en la capa BLL. " + ex.Message);
        }
        return _t2;
    }

    /*metodo para devolver la cantidad de resultados obtenidos de documentos  copia enviados*/
    public int GetDocCopiaEnviadosv1Rows(Int32 WFMovimientoTipo, Int32 WFMovimientoTipo2, String DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, ObjectDataSourceSelectingEventArgs e)
    {
        return e.Arguments.TotalRowCount;
    }


    /*Procedimiento para obtener los resultados paginados en documentos  enviados*/
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSWorkFlow.WFMovimiento_ReadWFMovimientoCopiaEnviadoDataTable GetDocEnviadosv1(int WFMovimientoTipo, string DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, Int32 WFControlDias, int maximumRows, int startRowIndex, ObjectDataSourceSelectingEventArgs e)
    {
        WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter _t1 = new WFMovimiento_ReadWFMovimientoCopiaEnviadoTableAdapter();
        DSWorkFlow.WFMovimiento_ReadWFMovimientoCopiaEnviadoDataTable _t2 = new DSWorkFlow.WFMovimiento_ReadWFMovimientoCopiaEnviadoDataTable();
        try
        {
            _t2 = _t1.GetDocEnviadov3By(WFMovimientoTipo, DependenciaCodDestino, GrupoCodigo, WFMovimientoFecha,WFControlDias, maximumRows, startRowIndex);
            if (_t2.Rows.Count > 0)
            {
                e.Arguments.TotalRowCount = int.Parse(_t2.Rows[0].ItemArray[16].ToString());
            }
            else
            {
                e.Arguments.TotalRowCount = 0;
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error en la capa BLL. " + ex.Message);
        }
        return _t2;
    }

    /*metodo para devolver la cantidad de resultados obtenidos de documentos  enviados*/
    public int GetDocEnviadosv1Rows(int WFMovimientoTipo, string DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha, Int32 WFControlDias, ObjectDataSourceSelectingEventArgs e)
    {
        return e.Arguments.TotalRowCount;
    }


    /*metodo de prueba*/

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSWorkFlow.WFMovimientoDataTable GetDocVenv(Int32 WFMovimientoTipo1, Int32 WFMovimientoTipo2, String DependenciaCodDestino, String GrupoCodigo, DateTime WFMovimientoFecha)
    {
        WFMovimientoTableAdapter _t1 = new WFMovimientoTableAdapter();
        try
        {

            return _t1.GetDocVenv3DataBy(WFMovimientoTipo1, WFMovimientoTipo2, DependenciaCodDestino, GrupoCodigo, WFMovimientoFecha, 100, 0);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }


  
}
