using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSGrupoSQLTableAdapters;

/// <summary>
/// Descripción breve de GrupoBLL
/// </summary>

[System.ComponentModel.DataObject]
public class GrupoBLL
{

    #region Variables Instancias Oracle
    DAL_Grupo ObjGrupo = new DAL_Grupo();
    DataTable mDataTable;
    #endregion

    private GrupoTableAdapter _grupoAdapter = null;
    protected GrupoTableAdapter AdapterGrupo
    {
        get
        {
            if (_grupoAdapter == null)
                _grupoAdapter = new GrupoTableAdapter();

            return _grupoAdapter;
        }
    }

    private GrupoByTextTableAdapter _grupoByTextAdapter = null;
    protected GrupoByTextTableAdapter AdapterGrupoByText
    {
        get
        {
            if (_grupoByTextAdapter == null)
                _grupoByTextAdapter = new GrupoByTextTableAdapter();

            return _grupoByTextAdapter;
        }
    }


    // SELECT METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetGrupo()
    {
        try
        {
        string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

        if (strbase == "SqlServer")
        {
            return AdapterGrupo.GetGrupo();
        }
        else
        {
            mDataTable = ObjGrupo.GetGrupo();
            return mDataTable;
        }
            }
    catch (Exception e)
    {
        throw new ApplicationException("Error en la capa BLL de GetGrupo. " + e.Message);
    }


    }              
    

    // SELECT METHOD ById
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DataTable GetGrupoByID(string GrupoCodigo)
    {
        try
        {

        string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

        if (strbase == "SqlServer")
        {
            return AdapterGrupo.GetGroupById(GrupoCodigo);
            
        }
        else
        {
            //DataTable mDataTable;
            //DAL_Grupo ObjGrupo = new DAL_Grupo();
            mDataTable = ObjGrupo.GetGrupoById(GrupoCodigo);
            return mDataTable;
            mDataTable.Dispose();
        }
    }
    catch (Exception e)
    {
        throw new ApplicationException("Error en la capa BLL de GetGrupoByID. " + e.Message);
    }


    }

    // SELECT METHOD ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSGrupoSQL.GrupoByTextDataTable GetGrupoByText(string GrupoNombre,string GrupoHabilitar)
    {
        try
        {

        string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

        if (strbase == "SqlServer")
        {
        return AdapterGrupoByText.GetGrupoByText(GrupoNombre, GrupoHabilitar);
            }
        else
        {
            DataTable mDataTable;
            mDataTable = ObjGrupo.GetGrupoByText(GrupoNombre, GrupoHabilitar);
            DSGrupoSQL.GrupoByTextDataTable Instancia = new DSGrupoSQL.GrupoByTextDataTable();
            
            foreach (DataRow row in mDataTable.Rows)
            {
                DSGrupoSQL.GrupoByTextRow Fila = Instancia.NewGrupoByTextRow();
                
                Fila.GrupoCodigo = row.ItemArray[0].ToString();
                Fila.GrupoNombre = row.ItemArray[1].ToString();
                Instancia.Rows.Add(Fila);
            }
            //Prueba.Rows
            //return ObjDepartamento.GetDepartamentoByTextNombre(DepartamentoNombre, DepartamentoHabilitar);
            //return mDataTable;
            //mDataTable.Dispose();
            return Instancia;
            Instancia.Dispose();
            mDataTable.Dispose();
        }
    }
    catch (Exception e)
    {
        throw new ApplicationException("Error en la capa BLL de GetGrupoByText. " + e.Message);
    }


    }
    
    // SELECT METHOD ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSGrupoSQL.GrupoByTextDataTable GetGrupoTextById(string GrupoNombre, string GrupoHabilitar)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterGrupoByText.GetGrupoTextById(GrupoNombre, GrupoHabilitar);
            }
            else
            {
                DataTable mDataTable;
                mDataTable = ObjGrupo.GetGrupoByTextId(GrupoNombre, GrupoHabilitar);
                DSGrupoSQL.GrupoByTextDataTable Instancia = new DSGrupoSQL.GrupoByTextDataTable();

                foreach (DataRow row in mDataTable.Rows)
                {
                    DSGrupoSQL.GrupoByTextRow Fila = Instancia.NewGrupoByTextRow();

                    Fila.GrupoCodigo = row.ItemArray[0].ToString();
                    Fila.GrupoNombre = row.ItemArray[1].ToString();
                    Instancia.Rows.Add(Fila);
                }
                //Prueba.Rows
                //return ObjDepartamento.GetDepartamentoByTextNombre(DepartamentoNombre, DepartamentoHabilitar);
                //return mDataTable;
                //mDataTable.Dispose();
                return Instancia;
                Instancia.Dispose();
                mDataTable.Dispose();
            }
        }
     
    catch (Exception e)
    {
        throw new ApplicationException("Error en la capa BLL de GetGrupoByText. " + e.Message);
    }


    }

    // CREATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool AddGrupo(string GrupoCodigo, string GrupoNombre, string GrupoCodigoPadre, int GrupoConsecutivo ,string GrupoHabilitar, string GrupoPermiso)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        // Create a new ExpedienteRow instance
        DSGrupoSQL.GrupoDataTable grupos = new DSGrupoSQL.GrupoDataTable();
        DSGrupoSQL.GrupoRow grupo = grupos.NewGrupoRow();
        if (GrupoCodigoPadre != null)
        {
        if (GrupoCodigoPadre.Contains(" | "))
        {
            GrupoCodigoPadre = GrupoCodigoPadre.Remove(GrupoCodigoPadre.IndexOf(" | "));
        }
        }
        
        grupo.GrupoCodigo = GrupoCodigo;
        grupo.GrupoNombre = GrupoNombre;
        grupo.GrupoCodigoPadre = GrupoCodigoPadre;
        grupo.GrupoNombrePadre = "";
        grupo.GrupoConsecutivo = GrupoConsecutivo;
        grupo.GrupoHabilitar = GrupoHabilitar;
        grupo.GrupoPermiso = GrupoPermiso;
        grupo.Original_GrupoCodigo = GrupoCodigo;

        // Add the new expediente
        grupos.AddGrupoRow(grupo);
        int rowsAffected = AdapterGrupo.Update(grupos);

        // Return true if precesely one row was inserted, otherwise false
        return rowsAffected == 1;
            }
                else
            {
                bool rowsAffected = ObjGrupo.CrearGrupo(GrupoCodigo, GrupoNombre, GrupoCodigoPadre, GrupoConsecutivo, GrupoHabilitar, GrupoPermiso);
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
    public bool UpdateGrupo(string GrupoNombre, string GrupoCodigoPadre, int GrupoConsecutivo, string GrupoHabilitar, string GrupoPermiso,String Original_GrupoCodigo)
    {
        string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

        if (strbase == "SqlServer")
        {

            DSGrupoSQL.GrupoDataTable grupos = AdapterGrupo.GetGroupById(Original_GrupoCodigo);
            if (grupos.Count == 0)
                // no matching record found, return false
                return false;

            if (GrupoCodigoPadre != null)
            {
                if (GrupoCodigoPadre.Contains(" | "))
                {
                    GrupoCodigoPadre = GrupoCodigoPadre.Remove(GrupoCodigoPadre.IndexOf(" | "));
                }
            }

            DSGrupoSQL.GrupoRow grupo = grupos[0];

            grupo.GrupoCodigo = Original_GrupoCodigo;
            grupo.GrupoNombre = GrupoNombre;
            grupo.GrupoCodigoPadre = GrupoCodigoPadre;
            grupo.GrupoConsecutivo = GrupoConsecutivo;
            grupo.GrupoHabilitar = GrupoHabilitar;
            grupo.GrupoPermiso = GrupoPermiso;
            grupo.Original_GrupoCodigo = Original_GrupoCodigo;

            // Update the product record
            int rowsAffected = AdapterGrupo.Update(grupos);

            // Return true if precesely one row was updated, otherwise false
            return rowsAffected == 1;

        }
        else
        {
            bool rowsAffected = ObjGrupo.UpdateGrupo(GrupoNombre, GrupoCodigoPadre, Convert.ToString(GrupoConsecutivo), GrupoHabilitar, GrupoPermiso, Original_GrupoCodigo);
            return rowsAffected;
        }

    }
    // DELETE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteGrupo(string Original_GrupoCodigo)
    {
        string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

        if (strbase == "SqlServer")
        {
            int rowsAffected = AdapterGrupo.Delete(Original_GrupoCodigo);

            // Return true if precesely one row was updated, otherwise fals
            return rowsAffected == 1;
        }
        else
        {
            bool rowsAffected = ObjGrupo.DeleteGrupo(Original_GrupoCodigo);
            return rowsAffected;
        }
        
    }

}

