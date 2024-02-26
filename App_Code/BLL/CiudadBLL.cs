using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSCiudadSQLTableAdapters;

/// <summary>
/// Descripción breve de CiudadBLL
/// </summary>

[System.ComponentModel.DataObject]
public class CiudadBLL
{
    #region Variables Instancias Oracle
    DAL_Ciudad ObjCiudad = new DAL_Ciudad();
    DataTable mDataTable;
    #endregion
   
    private CiudadTableAdapter _ciudadAdapter = null;
    protected CiudadTableAdapter AdapterCiudad
    {
        get
        {
            if (_ciudadAdapter == null)
                _ciudadAdapter = new CiudadTableAdapter();

            return _ciudadAdapter;
        }
    }

    private CiudadByTextTableAdapter _ciudadByTextAdapter = null;
    protected CiudadByTextTableAdapter AdapterCiudadByText
    {
        get
        {
            if (_ciudadByTextAdapter == null)
                _ciudadByTextAdapter = new CiudadByTextTableAdapter();

            return _ciudadByTextAdapter;
        }
    }

    private Ciudad_ReadCiudadByDepartamentoTableAdapter _ciudadByDepartamentoAdpater = null;
    protected Ciudad_ReadCiudadByDepartamentoTableAdapter AdapterCiudadByDepartamento
    {

        get
        {
            if (_ciudadByDepartamentoAdpater == null)
                _ciudadByDepartamentoAdpater = new Ciudad_ReadCiudadByDepartamentoTableAdapter();

            return _ciudadByDepartamentoAdpater;
        }
    }
    // SELECT METHOD ByCiudadId
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSCiudadSQL.Ciudad_ReadCiudadByDepartamentoDataTable GetCiudadByDepartamento(string DepartamentoCodigo)
    {
        return AdapterCiudadByDepartamento.GetCiudadByDepartamento(DepartamentoCodigo);
    }


    // SELECT METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetCiudad()
    {

        string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

        if (strbase == "SqlServer")
        {
            return AdapterCiudad.GetCiudad();
        }
        else
        {
            mDataTable = ObjCiudad.GetCiudad();
            return mDataTable;
        }
    }

    // SELECT METHOD ById
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DataTable GetCiudadByID(string CiudadCodigo)
    {
        string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

        if (strbase == "SqlServer")
        {
            return AdapterCiudad.GetCiudadById(CiudadCodigo);
        }
        else
        {
            DataTable mDataTable;
            DAL_Ciudad ObjCiudad = new DAL_Ciudad();
            mDataTable = ObjCiudad.GetCiudadById(CiudadCodigo);
            return mDataTable;
            mDataTable.Dispose();
        }
        
    }

    // SELECT METHOD ByTextNombre
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSCiudadSQL.CiudadByTextDataTable GetCiudadByTextNombre(string CiudadNombre, string CiudadHabilitar)
    {
        

        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterCiudadByText.GetCiudadByTextNombre(CiudadNombre, CiudadHabilitar);

            }
            else
            {
                DataTable mDataTable;
                mDataTable = ObjCiudad.GetCiudadByTextNombre(CiudadNombre, CiudadHabilitar);
                DSCiudadSQL.CiudadByTextDataTable Prueba = new DSCiudadSQL.CiudadByTextDataTable();
                
                foreach (DataRow row in mDataTable.Rows)
                {
                    
                    DSCiudadSQL.CiudadByTextRow Fila = Prueba.NewCiudadByTextRow();
                    Fila.CiudadCodigo = row.ItemArray[0].ToString();    
                    Fila.CiudadNombre = row.ItemArray[1].ToString();
                    Prueba.Rows.Add(Fila);
                }
                return Prueba;
                Prueba.Dispose();
               
            }
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    
    
    }


    // SELECT METHOD ByTextId
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSCiudadSQL.CiudadByTextDataTable GetCiudadByTextId(string CiudadCodigo, string CiudadHabilitar)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterCiudadByText.GetCiudadByTextId(CiudadCodigo, CiudadHabilitar);

            }
            else
            {
                DataTable mDataTable;
                mDataTable = ObjCiudad.GetCiudadByTextId(CiudadCodigo, CiudadHabilitar);
                DSCiudadSQL.CiudadByTextDataTable Prueba = new DSCiudadSQL.CiudadByTextDataTable();

                foreach (DataRow row in mDataTable.Rows)
                {

                    DSCiudadSQL.CiudadByTextRow Fila = Prueba.NewCiudadByTextRow();
                    Fila.CiudadCodigo = row.ItemArray[0].ToString();
                    Fila.CiudadNombre = row.ItemArray[1].ToString();
                    Prueba.Rows.Add(Fila);
                }
                return Prueba;
                Prueba.Dispose();

            }
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    
    }

    // CREATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool AddCiudad(string CiudadCodigo, string CiudadNombre, string DepartamentoCodigo, string CiudadHabilitar)
    {
        // Create a new ExpedienteRow instance
        DSCiudadSQL.CiudadDataTable ciudades = new DSCiudadSQL.CiudadDataTable();
        DSCiudadSQL.CiudadRow ciudad = ciudades.NewCiudadRow();

        if (DepartamentoCodigo.Contains(" | "))
        {
            DepartamentoCodigo = DepartamentoCodigo.Remove(DepartamentoCodigo.IndexOf(" | "));
        }

        ciudad.CiudadCodigo = CiudadCodigo;
        ciudad.CiudadNombre = CiudadNombre;
        ciudad.DepartamentoCodigo = DepartamentoCodigo;
        ciudad.DepartamentoNombre = null;
        ciudad.CiudadHabilitar = CiudadHabilitar;

        // Add the new expediente
        ciudades.AddCiudadRow(ciudad);
        int rowsAffected = AdapterCiudad.Update(ciudades);

        // Return true if precesely one row was inserted, otherwise false
        return rowsAffected == 1;

    }

    // UPDATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool UpdateCiudad(string CiudadNombre, string DepartamentoCodigo, string CiudadHabilitar, string Original_CiudadCodigo)
    {
        string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

        if (strbase == "SqlServer")
        {

            DSCiudadSQL.CiudadDataTable ciudades = AdapterCiudad.GetCiudadById(Original_CiudadCodigo);
            if (ciudades.Count == 0)
                // no matching record found, return false
                return false;

            DSCiudadSQL.CiudadRow ciudad = ciudades[0];
            if (DepartamentoCodigo != null)
            {

                if (DepartamentoCodigo.Contains(" | "))
                {
                    DepartamentoCodigo = DepartamentoCodigo.Remove(DepartamentoCodigo.IndexOf(" | "));
                }
            }

            ciudad.CiudadCodigo = Original_CiudadCodigo;
            ciudad.CiudadNombre = CiudadNombre;
            ciudad.DepartamentoCodigo = DepartamentoCodigo;
            ciudad.CiudadHabilitar = CiudadHabilitar;
            ciudad.Original_CiudadCodigo = Original_CiudadCodigo;

            // Update the product record
            int rowsAffected = AdapterCiudad.Update(ciudades);

            // Return true if precesely one row was updated, otherwise false
            return rowsAffected == 1;

        }
        else
        {
            bool rowsAffected = ObjCiudad.UpdateCiudad(Original_CiudadCodigo,CiudadNombre,DepartamentoCodigo,CiudadHabilitar,Original_CiudadCodigo);
            return rowsAffected;
        }

    }
    // DELETE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteCiudad(string Original_CiudadCodigo)
    {
        string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

        if (strbase == "SqlServer")
        {
            int rowsAffected = AdapterCiudad.Delete(Original_CiudadCodigo);

            // Return true if precesely one row was updated, otherwise fals
            return rowsAffected == 1;
        }
        else
        {
            bool rowsAffected = ObjCiudad.DeleteCiudad(Original_CiudadCodigo);
            return rowsAffected;
        }
    }

}
