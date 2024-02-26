using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSMedioSQLTableAdapters;

/// <summary>
/// Descripción breve de MedioBLL
/// </summary>

[System.ComponentModel.DataObject]
public class MedioBLL
{
    #region Variables
    DAL_Medio ObjMedio = new DAL_Medio();
    DataTable mDataTable;
    #endregion

    private MedioTableAdapter _medioAdapter = null;
    protected MedioTableAdapter AdapterMedio
    {
        get
        {
            if (_medioAdapter == null)
                _medioAdapter = new MedioTableAdapter();

            return _medioAdapter;
        }
    }

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
    
    // SELECT METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetMedio()
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterMedio.GetMedio();
            }

            else
            {

                mDataTable = ObjMedio.ReadMedio();
                return mDataTable;
               
            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL Nedio.GetMedio(). " + e.Message);
        }
    }

    // SELECT METHOD ById
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DataTable GetMedioByID(string MedioCodigo)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterMedio.GetMedioById(MedioCodigo);
            }
            else
            {
                mDataTable = ObjMedio.ReadMedioById(MedioCodigo);
                return mDataTable;
                
            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL Nedio.GetMedioById(). " + e.Message);
        }
    }

    // SELECT METHOD ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSMedioSQL.MedioByTextDataTable GetMedioByText(string MedioNombre, String MedioHabilitar)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterMedioByText.GetMedioByText(MedioNombre, MedioHabilitar);
            }

            else
            {
                mDataTable= ObjMedio.ReadMedioByText(MedioNombre,MedioHabilitar);
                DSMedioSQL.MedioByTextDataTable Instanciando = new DSMedioSQL.MedioByTextDataTable();

                foreach (DataRow row in mDataTable.Rows)
                {
                    DSMedioSQL.MedioByTextRow Fila = Instanciando.NewMedioByTextRow();
                    Fila.MedioCodigo = row.ItemArray[0].ToString();
                    Fila.MedioNombre = row.ItemArray[1].ToString();
                    Instanciando.Rows.Add(Fila);
                    
                }
                return Instanciando;
                Instanciando.Dispose();
                mDataTable.Dispose();
            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL Nedio.GetMedioByText(). " + e.Message);
        }
    }

    // SELECT METHOD ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSMedioSQL.MedioByTextDataTable GetMedioByTextId(string MedioNombre, String MedioHabilitar)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                return AdapterMedioByText.GetMedioByTextId(MedioNombre, MedioHabilitar);
            }

            else
            {
                mDataTable = ObjMedio.MedioByTextId(MedioNombre, MedioHabilitar);
                DSMedioSQL.MedioByTextDataTable Instanciando = new DSMedioSQL.MedioByTextDataTable();

                foreach (DataRow Row in mDataTable.Rows)
                {
                    DSMedioSQL.MedioByTextRow Fila = Instanciando.NewMedioByTextRow();
                    Fila.MedioCodigo = Row.ItemArray[0].ToString();
                    Fila.MedioNombre = Row.ItemArray[1].ToString();
                    Instanciando.Rows.Add(Fila);
                }

                return Instanciando;
                Instanciando.Dispose();
                mDataTable.Dispose();

            }

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL Nedio.GetMedioByText(). " + e.Message);
        }
    }

    // CREATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool AddMedio(string MedioCodigo, string MedioNombre, string MedioCodigoPadre, string MedioHabilitar, string MedioPermiso)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                // Create a new ExpedienteRow instance
                DSMedioSQL.MedioDataTable medios = new DSMedioSQL.MedioDataTable();
                DSMedioSQL.MedioRow medio = medios.NewMedioRow();

                if (MedioCodigoPadre != null)
                {
                    if (MedioCodigoPadre.Contains(" | "))
                    {
                        MedioCodigoPadre = MedioCodigoPadre.Remove(MedioCodigoPadre.IndexOf(" | "));
                    }
                }

                medio.MedioCodigo = MedioCodigo;
                medio.MedioNombre = MedioNombre;
                medio.MedioCodigoPadre = MedioCodigoPadre;
                medio.MedioHabilitar = MedioHabilitar;
                medio.MedioPermiso = MedioPermiso;

                // Add the new expediente
                medios.AddMedioRow(medio);
                int rowsAffected = AdapterMedio.Update(medios);

                // Return true if precesely one row was inserted, otherwise false
                return rowsAffected == 1;

            }

            else
            {
                bool rowsAffected = ObjMedio.CrearMedio(MedioCodigo, MedioNombre, MedioCodigoPadre, MedioHabilitar, MedioPermiso);
                return rowsAffected;
            }
        }

        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL Medio.CreateMedio(). " + e.Message);
        }

    }

    // UPDATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool UpdateMedio(string MedioNombre, string MedioCodigoPadre, string MedioHabilitar, string MedioPermiso, String Original_MedioCodigo, String MedioFactor)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                DSMedioSQL.MedioDataTable medios = AdapterMedio.GetMedioById(Original_MedioCodigo);
                if (medios.Count == 0)
                    // no matching record found, return false
                    return false;

                DSMedioSQL.MedioRow medio = medios[0];

                if (MedioCodigoPadre != null)
                {
                    if (MedioCodigoPadre.Contains(" | "))
                    {
                        MedioCodigoPadre = MedioCodigoPadre.Remove(MedioCodigoPadre.IndexOf(" | "));
                    }
                }

                medio.MedioCodigo = Original_MedioCodigo;
                medio.MedioNombre = MedioNombre;
                medio.MedioCodigoPadre = MedioCodigoPadre;
                medio.MedioHabilitar = MedioHabilitar;
                medio.MedioPermiso = MedioPermiso;
                medio.Original_MedioCodigo = Original_MedioCodigo;
                if (MedioFactor == "")
                {
                    MedioFactor = null;
                    medio.MedioFactor = MedioFactor;
                }
                else
                    medio.MedioFactor = MedioFactor;

                // Update the product record
                int rowsAffected = AdapterMedio.Update(medios);

                // Return true if precesely one row was updated, otherwise false
                return rowsAffected == 1;

            }

            else
            {
                bool rowsAffected = ObjMedio.UpdateMedio(Original_MedioCodigo, MedioNombre, MedioCodigoPadre, MedioHabilitar, MedioPermiso, MedioFactor, Original_MedioCodigo);
                return rowsAffected;
            }
        }

        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL Medio.UpdateMedio(). " + e.Message);
        }

    }
    // DELETE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteMedio(string Original_MedioCodigo)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
                int rowsAffected = AdapterMedio.Delete(Original_MedioCodigo);

                // Return true if precesely one row was updated, otherwise fals
                return rowsAffected == 1;
            }

            else
            {
                bool rowsAffected = ObjMedio.DeleteMedio(Original_MedioCodigo);
                return rowsAffected;
            }
        }

        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL Medio.DeleteMedio(). " + e.Message);
        }

    }
    
    // DELETE METHOD
    public bool MedioExiste (String MedioCodigo)
    {

        if (Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos")) == "SqlServer")
        {
            DSMedioSQLTableAdapters.Medio_ReadExisteMedioTableAdapter TAMedioExiste = new DSMedioSQLTableAdapters.Medio_ReadExisteMedioTableAdapter();
            DSMedioSQL.Medio_ReadExisteMedioDataTable DTMedioExiste = new DSMedioSQL.Medio_ReadExisteMedioDataTable();
            DTMedioExiste = TAMedioExiste.GetMedio_ReadExisteMedio(MedioCodigo);

            if (DTMedioExiste.Count == 0)
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
            mDataTable = ObjMedio.ReadExisteMedio(MedioCodigo);

            return false;
        }
    }
}
