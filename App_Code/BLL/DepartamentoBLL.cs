using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSDepartamentoSQLTableAdapters;

/// <summary>
/// Descripción breve de DepartamentoBLL
/// </summary>

[System.ComponentModel.DataObject]
public class DepartamentoBLL
{
    #region Variables
    DAL_Departamento ObjDepartamento = new DAL_Departamento();
    DataTable mDataTable;
    #endregion

    private DepartamentoTableAdapter _departamentoAdapter = null;
    protected DepartamentoTableAdapter AdapterDepartamento
    {
        get
        {
            if (_departamentoAdapter == null)
                _departamentoAdapter = new DepartamentoTableAdapter();

            return _departamentoAdapter;
        }
    }

    private DepartamentoByTextTableAdapter _departamentoByTextAdapter = null;
    protected DepartamentoByTextTableAdapter AdapterDepartamentoByText
    {
        get
        {
            if (_departamentoByTextAdapter == null)
                _departamentoByTextAdapter = new DepartamentoByTextTableAdapter();

            return _departamentoByTextAdapter;
        }
    }

    private DepartamentoByPaisTableAdapter _departamentoByPaisAdpater = null;
    protected DepartamentoByPaisTableAdapter AdapterDepartamentoByPais
    {

        get
        {
            if (_departamentoByPaisAdpater == null)
                _departamentoByPaisAdpater = new DepartamentoByPaisTableAdapter();

            return _departamentoByPaisAdpater;
        }
    }


    // SELECT METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetDepartamento()
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterDepartamento.GetDepartamento();

            }

            else
            {
                mDataTable = ObjDepartamento.GetDepartamento();
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
    public DataTable GetDepartamentoByID(string DepartamentoCodigo)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterDepartamento.GetDepartamentoById(DepartamentoCodigo);
            }
            else
            {
                DataTable mDataTable;
                DAL_Ciudad ObjCiudad = new DAL_Ciudad();
                mDataTable = ObjDepartamento.GetDepartamentoById(DepartamentoCodigo);
                return mDataTable;
                mDataTable.Dispose();
            }

        }

        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }

    // SELECT METHOD ByTextId
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSDepartamentoSQL.DepartamentoByTextDataTable GetDepartamentoByTextId(string DepartamentoCodigo,string DepartamentoHabilitar)
    {
       
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterDepartamentoByText.GetDepartamentoByTextId(DepartamentoCodigo, DepartamentoHabilitar);

            }
            else
            {
                DataTable mDataTable;
                mDataTable = ObjDepartamento.GetDepartamentoByTextId(DepartamentoCodigo, DepartamentoHabilitar);
                DSDepartamentoSQL.DepartamentoByTextDataTable Prueba = new DSDepartamentoSQL.DepartamentoByTextDataTable();
                //DataRowCollection rows = mDataTable.Rows;

                foreach (DataRow row in mDataTable.Rows)
                {
                    DSDepartamentoSQL.DepartamentoByTextRow Fila = Prueba.NewDepartamentoByTextRow();
                    //DSDepartamentoSQL.DepartamentoByTextRow Fila = new DSDepartamentoSQL.DepartamentoByTextRow();
                    Fila.DepartamentoCodigo = row.ItemArray[0].ToString();
                    Fila.DepartamentoNombre = row.ItemArray[1].ToString();
                    //Prueba.Clear();
                    Prueba.Rows.Add(Fila);
                }
                //Prueba.Rows
                //return ObjDepartamento.GetDepartamentoByTextNombre(DepartamentoNombre, DepartamentoHabilitar);
                //return mDataTable;
                //mDataTable.Dispose();
                return Prueba;
                Prueba.Dispose();
                mDataTable.Dispose();
            }
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    
    
    }

    // SELECT METHOD ByPaisId
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSDepartamentoSQL.DepartamentoByPaisDataTable GetDepartamentoByPais(string PaisCodigo)
    {
        return AdapterDepartamentoByPais.GetDepartamentoByPais(PaisCodigo);
    }

    // SELECT METHOD ByTextNombre
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSDepartamentoSQL.DepartamentoByTextDataTable GetDepartamentoByTextNombre(string DepartamentoNombre,string DepartamentoHabilitar)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterDepartamentoByText.GetDepartamentoByTextNombre(DepartamentoNombre, DepartamentoHabilitar);

            }
            else
            {
                DataTable mDataTable;
                mDataTable = ObjDepartamento.GetDepartamentoByTextNombre(DepartamentoNombre, DepartamentoHabilitar);
                DSDepartamentoSQL.DepartamentoByTextDataTable Prueba = new DSDepartamentoSQL.DepartamentoByTextDataTable();
                //DataRowCollection rows = mDataTable.Rows;

                foreach (DataRow row in mDataTable.Rows)
                {
                    DSDepartamentoSQL.DepartamentoByTextRow Fila = Prueba.NewDepartamentoByTextRow();
                    Fila.DepartamentoCodigo = row.ItemArray[0].ToString();
                    Fila.DepartamentoNombre = row.ItemArray[1].ToString();
                    Prueba.Rows.Add(Fila);
                }
                return Prueba;
                Prueba.Dispose();
                mDataTable.Dispose();
            }
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    
    }

    // CREATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool AddDepartamento(string DepartamentoCodigo, string DepartamentoNombre, string PaisCodigo, string DepartamentoHabilitar)
    {
        // Create a new ExpedienteRow instance

        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {

                DSDepartamentoSQL.DepartamentoDataTable departamentos = new DSDepartamentoSQL.DepartamentoDataTable();
                DSDepartamentoSQL.DepartamentoRow departamento = departamentos.NewDepartamentoRow();

                if (PaisCodigo.Contains(" | "))
                {
                    PaisCodigo = PaisCodigo.Remove(PaisCodigo.IndexOf(" | "));
                }

                departamento.DepartamentoCodigo = DepartamentoCodigo;
                departamento.DepartamentoNombre = DepartamentoNombre;
                departamento.PaisCodigo = PaisCodigo;
                departamento.DepartamentoHabilitar = DepartamentoHabilitar;


                // Add the new expediente
                departamentos.AddDepartamentoRow(departamento);
                int rowsAffected = AdapterDepartamento.Update(departamentos);

                // Return true if precesely one row was inserted, otherwise false
                return rowsAffected == 1;

            }

            else
            {
                bool rowsAffected = ObjDepartamento.CrearDepartamento(DepartamentoCodigo, DepartamentoNombre, PaisCodigo, DepartamentoHabilitar);
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
    public bool UpdateDepartamento(string DepartamentoNombre, string PaisCodigo, string DepartamentoHabilitar, string Original_DepartamentoCodigo)
    {

        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                DSDepartamentoSQL.DepartamentoDataTable departamentos = AdapterDepartamento.GetDepartamentoById(Original_DepartamentoCodigo);
                if (departamentos.Count == 0)
                    // no matching record found, return false
                    return false;

                DSDepartamentoSQL.DepartamentoRow departamento = departamentos[0];

                if (PaisCodigo.Contains(" | "))
                {
                    PaisCodigo = PaisCodigo.Remove(PaisCodigo.IndexOf(" | "));
                }

                departamento.DepartamentoCodigo = Original_DepartamentoCodigo;
                departamento.DepartamentoNombre = DepartamentoNombre;
                departamento.PaisCodigo = PaisCodigo;
                departamento.DepartamentoHabilitar = DepartamentoHabilitar;
                departamento.Original_DepartamentoCodigo = Original_DepartamentoCodigo;

                // Update the product record
                int rowsAffected = AdapterDepartamento.Update(departamentos);

                // Return true if precesely one row was updated, otherwise false
                return rowsAffected == 1;
            }



            else
            {
                bool rowsAffected = ObjDepartamento.UpdateDepartamento(Original_DepartamentoCodigo, DepartamentoNombre, PaisCodigo, DepartamentoHabilitar, Original_DepartamentoCodigo);
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
    public bool DeleteDepartamento(string Original_DepartamentoCodigo)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                int rowsAffected = AdapterDepartamento.Delete(Original_DepartamentoCodigo);

                // Return true if precesely one row was updated, otherwise fals
                return rowsAffected == 1;
            }
            else
            {
                bool rowsAffected = ObjDepartamento.DeleteDepartamento(Original_DepartamentoCodigo);
                return rowsAffected;
            }

        }

        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }

}



