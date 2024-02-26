using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSDependenciaSQLTableAdapters;

/// <summary>
/// Descripción breve de DependenciaBLL
/// </summary>

[System.ComponentModel.DataObject]
public class DependenciaBLL
{
    #region Variables Instancias Oracle
    DAL_Dependencia ObjDependencia = new DAL_Dependencia();
    DataTable mDataTable;
    #endregion


    private DependenciaTableAdapter _dependenciaAdapter = null;
    protected DependenciaTableAdapter AdapterDependencia
    {
        get
        {
            if (_dependenciaAdapter == null)
                _dependenciaAdapter = new DependenciaTableAdapter();

            return _dependenciaAdapter;
        }
    }

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


    // SELECT METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetDependencia()
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterDependencia.GetDependencia();

            }
            else
            {
                mDataTable = ObjDependencia.GetDependencia();
                return mDataTable;

            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }


    }

    // SELECT METHOD ById
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DataTable GetDependenciaByID(string DependenciaCodigo)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterDependencia.GetDependenciaById(DependenciaCodigo);
            }
            else
            {
                mDataTable = ObjDependencia.GetDependenciaById(DependenciaCodigo);
                return mDataTable;
            }
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }

    // SELECT METHOD ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSDependenciaSQL.DependenciaByTextDataTable GetDependenciaByText(string DependenciaNombre, string DependenciaHabilitar)
    {
        try
        {
            
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterDependenciaByText.GetDependenciaByText(DependenciaNombre, DependenciaHabilitar);
            }
            else
            {
                mDataTable = ObjDependencia.ReadDependenciaByText(DependenciaNombre, DependenciaHabilitar);
                //return mDataTable;
                DSDependenciaSQL.DependenciaByTextDataTable Datos = new DSDependenciaSQL.DependenciaByTextDataTable();

                foreach (DataRow row in mDataTable.Rows)
                {
                    DSDependenciaSQL.DependenciaByTextRow Fila = Datos.NewDependenciaByTextRow();
                    Fila.DependenciaCodigo = row.ItemArray[0].ToString();
                    Fila.DependenciaNombre = row.ItemArray[1].ToString();
                    Datos.Rows.Add(Fila);
                }

                return Datos;
                Datos.Dispose();

            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }

    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSDependenciaSQL.DependenciaByTextDataTable GetDependenciaTextById(string DependenciaCodigo, string DependenciaHabilitar)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterDependenciaByText.GetDependenciaTextById(DependenciaCodigo, DependenciaHabilitar);
            }
            else
            {
                mDataTable = ObjDependencia.ReadDependenciaByTextId(DependenciaCodigo, DependenciaHabilitar);
                //return mDataTable;
                DSDependenciaSQL.DependenciaByTextDataTable Datos = new DSDependenciaSQL.DependenciaByTextDataTable();

                foreach (DataRow row in mDataTable.Rows)
                {
                    DSDependenciaSQL.DependenciaByTextRow Fila = Datos.NewDependenciaByTextRow();
                    Fila.DependenciaCodigo = row.ItemArray[0].ToString();
                    Fila.DependenciaNombre = row.ItemArray[1].ToString();
                    Datos.Rows.Add(Fila);
                }

                return Datos;
                Datos.Dispose();


            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }

    }

    // CREATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool AddDependencia(string DependenciaCodigo, string DependenciaNombre, string DependenciaCodigoPadre, String DependenciaHabilitar, String DependenciaPermiso, String DistriTareas)
    {
        // Create a new DependenciaRow instance
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {

                DSDependenciaSQL.DependenciaDataTable dependencias = new DSDependenciaSQL.DependenciaDataTable();
                DSDependenciaSQL.DependenciaRow dependencia = dependencias.NewDependenciaRow();
                if (DependenciaCodigoPadre != null)
                {
                    if (DependenciaCodigoPadre.Contains(" | "))
                    {
                        DependenciaCodigoPadre = DependenciaCodigoPadre.Remove(DependenciaCodigoPadre.IndexOf(" | "));
                    }
                }
                dependencia.DependenciaCodigo = DependenciaCodigo;
                dependencia.DependenciaNombre = DependenciaNombre;
                dependencia.DependenciaCodigoPadre = DependenciaCodigoPadre;
                dependencia.DependenciaHabilitar = DependenciaHabilitar;
                dependencia.DependenciaPermiso = DependenciaPermiso;
                dependencia.DistriTareas = DistriTareas;

                // Add the new Dependencia
                dependencias.AddDependenciaRow(dependencia);
                int rowsAffected = AdapterDependencia.Update(dependencias);

                // Return true if precesely one row was inserted, otherwise false
                return rowsAffected == 1;

            }
            else
            {
                //mDataTable = ObjDependencia.DependenCreateDependen(DependenciaCodigo, DependenciaNombre, DependenciaCodigoPadre, DependenciaHabilitar, DependenciaPermiso);
                bool rowsAffected = ObjDependencia.DependenCreateDependen(DependenciaCodigo, DependenciaNombre, DependenciaCodigoPadre, DependenciaHabilitar, DependenciaPermiso);
                return rowsAffected;
            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }


    }

    // UPDATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool UpdateDependencia(string DependenciaNombre, string DependenciaCodigoPadre, String DependenciaHabilitar, String DependenciaPermiso, String Original_DependenciaCodigo, String DistriTareas)
    {

        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                DSDependenciaSQL.DependenciaDataTable dependencias = AdapterDependencia.GetDependenciaById(Original_DependenciaCodigo);
                if (dependencias.Count == 0)
                    // no matching record found, return false
                    return false;

                DSDependenciaSQL.DependenciaRow dependencia = dependencias[0];

                if (DependenciaCodigoPadre != null)
                {
                    if (DependenciaCodigoPadre.Contains(" | "))
                    {
                        DependenciaCodigoPadre = DependenciaCodigoPadre.Remove(DependenciaCodigoPadre.IndexOf(" | "));
                    }
                }

                dependencia.DependenciaCodigo = Original_DependenciaCodigo;
                dependencia.DependenciaNombre = DependenciaNombre;
                dependencia.DependenciaCodigoPadre = DependenciaCodigoPadre;
                dependencia.DependenciaHabilitar = DependenciaHabilitar;
                dependencia.DependenciaPermiso = DependenciaPermiso;
                dependencia.DistriTareas = DistriTareas;
                dependencia.Original_DependenciaCodigo = Original_DependenciaCodigo;

                // Update the product record
                int rowsAffected = AdapterDependencia.Update(dependencias);

                // Return true if precesely one row was updated, otherwise false
                return rowsAffected == 1;
            }
            else
            {
                bool rowsAffected = ObjDependencia.UpdateDependencia(DependenciaNombre, DependenciaCodigoPadre, DependenciaHabilitar, DependenciaPermiso, Original_DependenciaCodigo);
                return rowsAffected;
            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }


    }
    // DELETE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteDependencia(string Original_DependenciaCodigo)
    {

        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                int rowsAffected = AdapterDependencia.Delete(Original_DependenciaCodigo);

                // Return true if precesely one row was updated, otherwise fals
                return rowsAffected == 1;

            }
            else
            {
                bool rowsAffected = ObjDependencia.DeleteDependencia(Original_DependenciaCodigo);
                return rowsAffected;
            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }




    }

    public bool DependenciaExiste(String mDependenciaCodigo)
    {

        if (Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos")) == "SqlServer")
        {
            DSDependenciaSQLTableAdapters.Dependencia_ReadExisteDependenciaTableAdapter TADependenciaExiste = new DSDependenciaSQLTableAdapters.Dependencia_ReadExisteDependenciaTableAdapter();
            DSDependenciaSQL.Dependencia_ReadExisteDependenciaDataTable DTDependenciaciaExiste = new DSDependenciaSQL.Dependencia_ReadExisteDependenciaDataTable();
            DTDependenciaciaExiste = TADependenciaExiste.GetDependencia_ReadExisteDependencia(mDependenciaCodigo);

            if (DTDependenciaciaExiste.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            mDataTable = ObjDependencia.ReadExisteDependencia(mDependenciaCodigo);

            return false;
        }
    }
}
