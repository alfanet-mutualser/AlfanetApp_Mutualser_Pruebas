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
    
    // SELECT Dependencia METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSDependenciaSQL.DependenciaByTextDataTable GetDependenciaTree(String parentid)
    {
        return AdapterDependenciaByText.GettreedependenciaDataBy(Convert.ToString(parentid));
    }
}
