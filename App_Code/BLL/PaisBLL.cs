using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DSPaisSQLTableAdapters;

/// <summary>
/// Descripción breve de PaisBLL
/// </summary>

[System.ComponentModel.DataObject]
public class PaisBLL
{
    DAL_Pais ObjPais = new DAL_Pais();

    private PaisTableAdapter _paisAdapter = null;
    protected PaisTableAdapter AdapterPais
    {
        get
        {
            if (_paisAdapter == null)
                _paisAdapter = new PaisTableAdapter();

            return _paisAdapter;
        }
    }

    private PaisByTextTableAdapter _paisByTextAdapter = null;
    protected PaisByTextTableAdapter AdapterPaisByText
    {
        get
        {
            if (_paisByTextAdapter == null)
                _paisByTextAdapter = new PaisByTextTableAdapter();

            return _paisByTextAdapter;
        }
    }


    // SELECT METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSPaisSQL.PaisDataTable GetPais()
    {
        //DSPaisSQL.Pais
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterPais.GetPais();

            }

            else
            {
                DataTable mDataTable;
                mDataTable = ObjPais.GetPais();
                DSPaisSQL.PaisDataTable Prueba = new DSPaisSQL.PaisDataTable();
                
                foreach (DataRow row in mDataTable.Rows)
                {
                    DSPaisSQL.PaisRow Fila = Prueba.NewPaisRow();
                    Fila.PaisCodigo = row.ItemArray[0].ToString();
                    Fila.PaisCodigo = row.ItemArray[0].ToString();
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

    // SELECT METHOD ById
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSPaisSQL.PaisDataTable GetPaisByID(string PaisCodigo)
    {
        
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterPais.GetPaisById(PaisCodigo);
            }
            else
            {
                
                
                DataTable mDataTable;
                mDataTable = ObjPais.GetPaisById(PaisCodigo);
                DSPaisSQL.PaisDataTable Prueba = new DSPaisSQL.PaisDataTable();
                //DataRowCollection rows = mDataTable.Rows;

                foreach (DataRow row in mDataTable.Rows)
                {
                    DSPaisSQL.PaisRow Fila = Prueba.NewPaisRow();
                    Fila.PaisCodigo = row.ItemArray[0].ToString();
                    Fila.PaisNombre = row.ItemArray[1].ToString();
                    Fila.PaisHabilitar = row.ItemArray[2].ToString();
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

    // SELECT METHOD ByTextId
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSPaisSQL.PaisByTextDataTable GetPaisByTextId(string PaisCodigo, string PaisHabilitar)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterPaisByText.GetPaisByTextId(PaisCodigo, PaisHabilitar);

            }
            else
            {
                DataTable mDataTable;
                mDataTable = ObjPais.GetPaisByTextId(PaisCodigo, PaisHabilitar);
                DSPaisSQL.PaisByTextDataTable Prueba = new DSPaisSQL.PaisByTextDataTable();
                
                foreach (DataRow row in mDataTable.Rows)
                {
                    DSPaisSQL.PaisByTextRow Fila = Prueba.NewPaisByTextRow();
                    Fila.PaisCodigo = row.ItemArray[0].ToString();
                    Fila.PaisNombre = row.ItemArray[1].ToString();
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

    // SELECT METHOD ByTextNombre
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSPaisSQL.PaisByTextDataTable GetPaisByTextNombre(string PaisNombre,string PaisHabilitar)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterPaisByText.GetPaisByTextNombre(PaisNombre, PaisHabilitar);
            }
            else
            {
                DataTable mDataTable;
                mDataTable = ObjPais.GetPaisByTextNombre(PaisNombre, PaisHabilitar);
                DSPaisSQL.PaisByTextDataTable Prueba = new DSPaisSQL.PaisByTextDataTable();
                //DataRowCollection rows = mDataTable.Rows;

                foreach (DataRow row in mDataTable.Rows)
                {
                    DSPaisSQL.PaisByTextRow Fila = Prueba.NewPaisByTextRow();
                    Fila.PaisCodigo = row.ItemArray[0].ToString();
                    Fila.PaisNombre = row.ItemArray[1].ToString();
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
    public bool AddPais(string PaisCodigo, string PaisNombre, String PaisHabilitar)
    {
        
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {

                // Create a new ExpedienteRow instance
                DSPaisSQL.PaisDataTable paises = new DSPaisSQL.PaisDataTable();
                DSPaisSQL.PaisRow pais = paises.NewPaisRow();

                pais.PaisCodigo = PaisCodigo;
                pais.PaisNombre = PaisNombre;
                pais.PaisHabilitar = PaisHabilitar;

                // Add the new expediente
                paises.AddPaisRow(pais);
                int rowsAffected = AdapterPais.Update(paises);

                // Return true if precesely one row was inserted, otherwise false
                return rowsAffected == 1;


            }

            else
            {
                bool rowsAffected = ObjPais.CreatePais(PaisCodigo, PaisNombre, PaisHabilitar);
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
    public bool UpdatePais(string PaisNombre, String PaisHabilitar, string Original_PaisCodigo)
    {

        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                DSPaisSQL.PaisDataTable paises = AdapterPais.GetPaisById(Original_PaisCodigo);
                if (paises.Count == 0)
                    // no matching record found, return false
                    return false;

                DSPaisSQL.PaisRow pais = paises[0];

                pais.PaisCodigo = Original_PaisCodigo;
                pais.PaisNombre = PaisNombre;
                pais.PaisHabilitar = PaisHabilitar;
                pais.Original_PaisCodigo = Original_PaisCodigo;

                // Update the product record
                int rowsAffected = AdapterPais.Update(pais);

                // Return true if precesely one row was updated, otherwise false
                return rowsAffected == 1;
            }
                
            else
            {
                bool rowsAffected = ObjPais.UpdatePais(Original_PaisCodigo, PaisNombre, PaisHabilitar, Original_PaisCodigo);
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
    public bool DeletePais(string Original_PaisCodigo)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                int rowsAffected = AdapterPais.Delete(Original_PaisCodigo);

                // Return true if precesely one row was updated, otherwise fals
                return rowsAffected == 1;
            }
            else
            {
                bool rowsAffected = ObjPais.DeletePais(Original_PaisCodigo);
                return rowsAffected;
            }

        }

        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }

    }

}

