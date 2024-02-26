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
using DSExpedienteSQLTableAdapters;
using DSMedioSQLTableAdapters;
using DSNaturalezaSQLTableAdapters;
using DSDependenciaSQLTableAdapters; 
using DSSerieSQLTableAdapters;
//using DSRadicadoTableAdapters;
//using DSGrupoSQLTableAdapters;


/// <summary>
/// Descripción breve de ExpedienteBLL
/// </summary>
//

[System.ComponentModel.DataObject]
public class ArbolesBLL
{
    // Constructor Serie Adapter
    private SerieByTextTableAdapter _SerieAdapter = null; 
    protected SerieByTextTableAdapter AdapterSerie
    {
        get
        {
            if (_SerieAdapter == null)
                _SerieAdapter = new SerieByTextTableAdapter();

            return _SerieAdapter;
        }
    }
   // Constructor Expediente Adapter
    private ExpedienteByTextTableAdapter _ExpedienteAdapter = null;
    protected ExpedienteByTextTableAdapter AdapterExpediente
    {
        get
        {
            if (_ExpedienteAdapter == null)
                _ExpedienteAdapter = new ExpedienteByTextTableAdapter();

            return _ExpedienteAdapter;
        }
    }
    //Constructor Medio Adapter
    private MedioByTextTableAdapter _medioByTextAdapter = null;
    protected MedioByTextTableAdapter AdapterMedioByText
    {
        get
        {
            if (_medioByTextAdapter == null)
                _medioByTextAdapter = new MedioByTextTableAdapter();

            return _medioByTextAdapter;
        }
    }
    //Constructor Naturaleza Adapter
    private NaturalezaByTextTableAdapter _naturalezaByTextAdapter = null;
    protected NaturalezaByTextTableAdapter AdapterNaturalezaByText
    {
        get
        {
            if (_naturalezaByTextAdapter == null)
                _naturalezaByTextAdapter = new NaturalezaByTextTableAdapter();

            return _naturalezaByTextAdapter;
        }
    }
    //Constructor Dependencia Adapter
    private DependenciaByTextTableAdapter _dependenciaByTextAdapter = null;
    protected DependenciaByTextTableAdapter AdapterDependenciaByText
    {
        get
        {
            if (_dependenciaByTextAdapter == null)
                _dependenciaByTextAdapter = new DependenciaByTextTableAdapter();

            return _dependenciaByTextAdapter;
        }
    }
    // SELECT Serie METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSSerieSQL.SerieByTextDataTable GetSerieTree(String parentid)
    {
        return AdapterSerie.GetSerieTreeDataBy(Convert.ToString(parentid));
    }
    // SELECT Expediente METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSExpedienteSQL.ExpedienteByTextDataTable GetExpedienteTree(String parentid)
    {
        return AdapterExpediente.GetExpedienteTreeDataBy(Convert.ToString(parentid));
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    // SELECT Medio METHOD
    public DSMedioSQL.MedioByTextDataTable GetMedioTree(int parentid)
    {
        return AdapterMedioByText.GetMedioTreeDataBy(Convert.ToString(parentid));
    }
    // SELECT Naturaleza METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSNaturalezaSQL.NaturalezaByTextDataTable GetNaturalezaTree(String parentid)
    {
        return AdapterNaturalezaByText.GetNaturalezaTreeDataBy(Convert.ToString(parentid));
    }
    // SELECT Dependencia METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSDependenciaSQL.DependenciaByTextDataTable GetDependenciaTree(String parentid)
    {
        return AdapterDependenciaByText.GettreedependenciaDataBy(Convert.ToString(parentid));
    }
}
