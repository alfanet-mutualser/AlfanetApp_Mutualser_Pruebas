using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DSSerieSQLTableAdapters;

/// <summary>
/// Descripción breve de SerieBLL
/// </summary>

[System.ComponentModel.DataObject]
public class SerieBLL
{

    #region Variables
    DAL_Serie ObjSerie = new DAL_Serie();
    DataTable mDataTable;
    #endregion

    private SerieTableAdapter _dependenciaAdapter = null;
    protected SerieTableAdapter AdapterSerie
    {
        get
        {
            if (_dependenciaAdapter == null)
                _dependenciaAdapter = new SerieTableAdapter();

            return _dependenciaAdapter;
        }
    }

    private SerieByTextTableAdapter _dependenciaByTextAdapter = null;
    protected SerieByTextTableAdapter AdapterSerieByText
    {
        get
        {
            if (_dependenciaByTextAdapter == null)
                _dependenciaByTextAdapter = new SerieByTextTableAdapter();

            return _dependenciaByTextAdapter;
        }
    }


    // SELECT METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetSerie()
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
             return AdapterSerie.GetSerie();
            }

                else
                {
                    mDataTable = ObjSerie.ReadSerie();
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
    public DataTable GetSerieByID(string SerieCodigo)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        return AdapterSerie.GetSerieById(SerieCodigo);
            }
            else
            {

                mDataTable = ObjSerie.ReadSerieById(SerieCodigo);
                return mDataTable;
                mDataTable.Dispose();
    }

}

catch (Exception e)
{
    throw new ApplicationException("Error en la capa BLL. " + e.Message);
}
    }

    // SELECT METHOD ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSSerieSQL.SerieByTextDataTable GetSerieByText(string SerieNombre, string SerieHabilitar)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        return AdapterSerieByText.GetSerieByText(SerieNombre,SerieHabilitar);

            }
            else
            {
                mDataTable = ObjSerie.ReadSerieByTextNombre(SerieNombre, SerieHabilitar);
                DSSerieSQL.SerieByTextDataTable Instanciando = new DSSerieSQL.SerieByTextDataTable();
                
            
                foreach (DataRow row in mDataTable.Rows)
            {
                DSSerieSQL.SerieByTextRow Fila = Instanciando.NewSerieByTextRow();
                Fila.SerieCodigo = row.ItemArray[0].ToString();
                Fila.SerieNombre = row.ItemArray[1].ToString();
                Instanciando.Rows.Add(Fila);
                
            }
            return Instanciando;
            Instanciando.Dispose();
            mDataTable.Dispose();
    }
}
catch (Exception e)
{
    throw new ApplicationException("Error en la capa BLL. " + e.Message);
}
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSSerieSQL.SerieByTextDataTable GetSerieTextById(string SerieCodigo, string SerieHabilitar)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        return AdapterSerieByText.GetSerieTextById(SerieCodigo, SerieHabilitar);
    }
    else
    {
        mDataTable = ObjSerie.ReadSerieByTextId(SerieCodigo, SerieHabilitar);
        DSSerieSQL.SerieByTextDataTable Instanciando = new DSSerieSQL.SerieByTextDataTable();
        

        foreach (DataRow row in mDataTable.Rows)
        {
            DSSerieSQL.SerieByTextRow Fila = Instanciando.NewSerieByTextRow();
            Fila.SerieCodigo = row.ItemArray[0].ToString();
            Fila.SerieNombre = row.ItemArray[1].ToString();
            Instanciando.Rows.Add(Fila);
            
        }

        return Instanciando;
        Instanciando.Dispose();
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
    public bool AddSerie(string SerieCodigo, string SerieNombre, string SerieCodigoPadre, int SerieTiempo, string SerieHabilitar, string SeriePermiso)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        // Create a new ExpedienteRow instance
        DSSerieSQL.SerieDataTable series = new DSSerieSQL.SerieDataTable();
        DSSerieSQL.SerieRow dependencia = series.NewSerieRow();
        
        if (SerieCodigoPadre != null)
        {
            if (SerieCodigoPadre.Contains(" | "))
            {
                SerieCodigoPadre = SerieCodigoPadre.Remove(SerieCodigoPadre.IndexOf(" | "));
            }
        }

        dependencia.SerieCodigo = SerieCodigo;
        dependencia.SerieNombre = SerieNombre;
        dependencia.SerieCodigoPadre = SerieCodigoPadre;
        dependencia.SerieTiempo = SerieTiempo;
        dependencia.SerieHabilitar = SerieHabilitar;
        dependencia.SeriePermiso = SeriePermiso;

        // Add the new expediente
        series.AddSerieRow(dependencia);
        int rowsAffected = AdapterSerie.Update(series);

        // Return true if precesely one row was inserted, otherwise false
        return rowsAffected == 1;
    }

    else
    {
        bool rowsAffected = ObjSerie.CrearSerie(SerieCodigo, SerieNombre, SerieCodigoPadre, SerieTiempo, SerieHabilitar, SeriePermiso);
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
    public bool UpdateSerie(string SerieNombre, string SerieCodigoPadre, int SerieTiempo, string SerieHabilitar, string SeriePermiso, string Original_SerieCodigo)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        DSSerieSQL.SerieDataTable series = AdapterSerie.GetSerieById(Original_SerieCodigo);
        if (series.Count == 0)
            // no matching record found, return false
            return false;

        DSSerieSQL.SerieRow dependencia = series[0];

        if (SerieCodigoPadre != null)
        {
            if (SerieCodigoPadre.Contains(" | "))
            {
                SerieCodigoPadre = SerieCodigoPadre.Remove(SerieCodigoPadre.IndexOf(" | "));
            }
        }

        dependencia.SerieCodigo = Original_SerieCodigo;
        dependencia.SerieNombre = SerieNombre;
        dependencia.SerieCodigoPadre = SerieCodigoPadre;
        dependencia.SerieTiempo = SerieTiempo;
        dependencia.SerieHabilitar = SerieHabilitar;
        dependencia.SeriePermiso = SeriePermiso;
        dependencia.Original_SerieCodigo = Original_SerieCodigo;

        // Update the product record
        int rowsAffected = AdapterSerie.Update(series);

        // Return true if precesely one row was updated, otherwise false
        return rowsAffected == 1;

    }



    else
    {
        
        bool rowsAffected = ObjSerie.UpdateSerie(SerieNombre, SerieCodigoPadre, SerieTiempo, SerieHabilitar, SeriePermiso, Original_SerieCodigo);
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
    public bool DeleteSerie(string Original_SerieCodigo)
    {
        try
        {

            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        int rowsAffected = AdapterSerie.Delete(Original_SerieCodigo);

        // Return true if precesely one row was updated, otherwise fals
        return rowsAffected == 1;
    }
    else
    {
        bool rowsAffected = ObjSerie.DeleteSerie(Original_SerieCodigo);
        return rowsAffected;
    }

}

catch (Exception e)
{
    throw new ApplicationException("Error en la capa BLL. " + e.Message);
}
            }

            // DELETE METHOD
            public bool SerieExiste(String SerieCodigo)
            {

                if (Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos")) == "SqlServer")
                {
                    DSSerieSQLTableAdapters.Serie_ReadExisteSerieTableAdapter TASerieExiste = new DSSerieSQLTableAdapters.Serie_ReadExisteSerieTableAdapter();
                    DSSerieSQL.Serie_ReadExisteSerieDataTable DTSerieExiste = new DSSerieSQL.Serie_ReadExisteSerieDataTable();
                    DTSerieExiste = TASerieExiste.GetSerie_ReadExisteSerie(SerieCodigo);

                    if (DTSerieExiste.Count == 0)
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
                    mDataTable = ObjSerie.ExisteSerie(SerieCodigo);

                    return false;
                }
            }

}

