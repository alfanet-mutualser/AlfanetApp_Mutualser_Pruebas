using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DSNaturalezaSQLTableAdapters;

/// <summary>
/// Descripción breve de NaturalezaBLL
/// </summary>

[System.ComponentModel.DataObject]
public class NaturalezaBLL
{

    #region Variables
    DAL_Naturaleza ObjNaturaleza = new DAL_Naturaleza();
    DataTable mDataTable;
    #endregion

    private NaturalezaTableAdapter _naturalezaAdapter = null;
    protected NaturalezaTableAdapter AdapterNaturaleza
    {
        get
        {
            if (_naturalezaAdapter == null)
                _naturalezaAdapter = new NaturalezaTableAdapter();

            return _naturalezaAdapter;
        }
    }

    private Dependencia_ReadDependenciaByNaturalezaTableAdapter _DependenciaByNaturalezaAdapter = null;
    protected Dependencia_ReadDependenciaByNaturalezaTableAdapter AdapterDependenciaByNaturaleza
    {
        get
        {
            if (_DependenciaByNaturalezaAdapter == null)
                _DependenciaByNaturalezaAdapter = new Dependencia_ReadDependenciaByNaturalezaTableAdapter();

            return _DependenciaByNaturalezaAdapter;
        }
    }

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

    // SELECT METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSNaturalezaSQL.Dependencia_ReadDependenciaByNaturalezaDataTable GetDependenciaByNaturaleza(string NaturalezaCodigo)
    {
        return AdapterDependenciaByNaturaleza.GetDependenciaByNaturaleza(NaturalezaCodigo);
    }

    // SELECT METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetNaturaleza()
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        return AdapterNaturaleza.GetNaturaleza();
    }

    else
    {

        mDataTable = ObjNaturaleza.GetNaturaleza();
        return mDataTable;

    }

}
catch (Exception e)
{
    throw new ApplicationException("Error en la capa BLL Nedio.GetMedio(). " + e.Message);
}
            }
    // SELECT METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSNaturalezaSQL.NaturalezaDataTable GetNaturalezaByPQR()
    {
        return AdapterNaturaleza.GetNaturalezaByPQR();
    }

    // SELECT METHOD ById
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DataTable GetNaturalezaByID(string NaturalezaCodigo)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        return AdapterNaturaleza.GetNaturalezaById(NaturalezaCodigo);

    }

    else
    {
        //mDataTable = ObjNaturaleza.GetNaturalezaById(NaturalezaCodigo);
        //DSNaturalezaSQL.NaturalezaDataTable Instanciando = new DSNaturalezaSQL.NaturalezaDataTable();

        //foreach (DataRow row in mDataTable.Rows)
        //{
        //    DSNaturalezaSQL.NaturalezaRow Fila = Instanciando.NewNaturalezaRow();
        //    Fila.NaturalezaCodigo = row.ItemArray[0].ToString();
        //    Fila.NaturalezaNombre = row.ItemArray[1].ToString();
        //    Fila.NaturalezaDiasVence = row.ItemArray[2].
        //    Instanciando.Rows.Add(Fila);

        //}
        //return Instanciando;
        //Instanciando.Dispose();
        //mDataTable.Dispose();

        mDataTable = ObjNaturaleza.GetNaturalezaById(NaturalezaCodigo);
        return mDataTable;

    }

}
catch (Exception e)
{
    throw new ApplicationException("Error en la capa BLL Naturaleza.GetNaturalezaById(). " + e.Message);
}
    }

    // SELECT METHOD ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSNaturalezaSQL.NaturalezaByTextDataTable GetNaturalezaByText(string NaturalezaNombre, string NaturalezaHabilitar)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        return AdapterNaturalezaByText.GetNaturalezaByText(NaturalezaNombre, NaturalezaHabilitar);
    }

    else
    {
        mDataTable = ObjNaturaleza.GetNaturalezaByTextNombre(NaturalezaNombre, NaturalezaHabilitar);
        DSNaturalezaSQL.NaturalezaByTextDataTable Instanciando = new DSNaturalezaSQL.NaturalezaByTextDataTable();

        foreach (DataRow row in mDataTable.Rows)
        {
            DSNaturalezaSQL.NaturalezaByTextRow Fila = Instanciando.NewNaturalezaByTextRow();
            Fila.NaturalezaCodigo = row.ItemArray[0].ToString();
            Fila.NaturalezaNombre = row.ItemArray[1].ToString();
           // Fila.NaturalezaDiasVence = row.ItemArray[2].ToString();
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
    public DSNaturalezaSQL.NaturalezaByTextDataTable GetNaturalezaByTextId(string NaturalezaNombre, string NaturalezaHabilitar)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        return AdapterNaturalezaByText.GetNaturalezaByTextId(NaturalezaNombre,NaturalezaHabilitar);
    }

    else
    {
        mDataTable = ObjNaturaleza.GetNaturalezaTextById(NaturalezaNombre, NaturalezaHabilitar);
        DSNaturalezaSQL.NaturalezaByTextDataTable Instanciando = new DSNaturalezaSQL.NaturalezaByTextDataTable();

        foreach (DataRow row in mDataTable.Rows)
        {
            DSNaturalezaSQL.NaturalezaByTextRow Fila = Instanciando.NewNaturalezaByTextRow();
            Fila.NaturalezaCodigo = row.ItemArray[0].ToString();
            Fila.NaturalezaNombre = row.ItemArray[1].ToString();
            //Fila.NaturalezaDiasVence = row.ItemArray[2].ToString();
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
    // SELECT METHOD ByTextPQR
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSNaturalezaSQL.NaturalezaByTextDataTable GetNaturalezaByTextIdPQR(string NaturalezaNombre, string NaturalezaHabilitar)
    {
        return AdapterNaturalezaByText.GetNaturalezasPQRBy(NaturalezaNombre, NaturalezaHabilitar);
    }

    // CREATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool AddNaturaleza(string NaturalezaCodigo, string NaturalezaNombre, string NaturalezaCodigoPadre, int NaturalezaDiasVence, string NaturalezaHabilitar, string NaturalezaPermiso, string NaturalezaPQR, string NaturalezaDependenciaPQR,string DependenciaNombre)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        // Create a new ExpedienteRow instance
        DSNaturalezaSQL.NaturalezaDataTable naturalezas = new DSNaturalezaSQL.NaturalezaDataTable();
        DSNaturalezaSQL.NaturalezaRow naturaleza = naturalezas.NewNaturalezaRow();

        if (NaturalezaDependenciaPQR != null)
        {
            if (NaturalezaDependenciaPQR.Contains(" | "))
            {
                NaturalezaDependenciaPQR = NaturalezaDependenciaPQR.Remove(NaturalezaDependenciaPQR.IndexOf(" | "));
            }
        }
        if (NaturalezaCodigoPadre != null)
        {
            if (NaturalezaCodigoPadre.Contains(" | "))
            {
                NaturalezaCodigoPadre = NaturalezaCodigoPadre.Remove(NaturalezaCodigoPadre.IndexOf(" | "));
            }
        }
        //String StrNaturalezaHabilitar;
        //if (NaturalezaHabilitar == true)
        //{
        //    StrNaturalezaHabilitar = "1";
        //}
        //else
        //{
        //    StrNaturalezaHabilitar = "0";
        //}
        //if (NaturalezaPermiso == true)
        //{
        //    StrNaturalezaPermiso = "1";
        //}
        //else
        //{
        //    StrNaturalezaPermiso = "0";
        //}
        naturaleza.NaturalezaCodigo = NaturalezaCodigo;
        naturaleza.NaturalezaNombre = NaturalezaNombre;
        naturaleza.NaturalezaCodigoPadre = NaturalezaCodigoPadre;
        naturaleza.NaturalezaDiasVence = NaturalezaDiasVence;
        naturaleza.NaturalezaHabilitar = NaturalezaHabilitar;
        naturaleza.NaturalezaPermiso = NaturalezaPermiso;
        naturaleza.NaturalezaPQR = NaturalezaPQR;
        naturaleza.NaturalezaDependenciaPQR = NaturalezaDependenciaPQR;
        //naturaleza.Original_NaturalezaCodigo = Original_NaturalezaCodigo;

        // Add the new expediente
        naturalezas.AddNaturalezaRow(naturaleza);
        int rowsAffected = AdapterNaturaleza.Update(naturalezas);

        // Return true if precesely one row was inserted, otherwise false
        return rowsAffected == 1;
    }

    else
    {

        bool rowsAffected = ObjNaturaleza.CrearNaturaleza(NaturalezaCodigo, NaturalezaNombre, NaturalezaCodigoPadre, NaturalezaDiasVence, NaturalezaHabilitar, NaturalezaPermiso, NaturalezaPQR, NaturalezaDependenciaPQR);
        return rowsAffected;

    }

}
catch (Exception e)
{
    throw new ApplicationException("Error en la capa BLL Naturaleza.CrearNaturaleza(). " + e.Message);
}

    }

    // UPDATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool UpdateNaturaleza(string NaturalezaNombre, string NaturalezaCodigoPadre, int NaturalezaDiasVence, string NaturalezaHabilitar, string NaturalezaPermiso,String NaturalezaPQR,String NaturalezaDependenciaPQR,string DependenciaNombre, string Original_NaturalezaCodigo)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        DSNaturalezaSQL.NaturalezaDataTable naturalezas = AdapterNaturaleza.GetNaturalezaById(Original_NaturalezaCodigo);
        if (naturalezas.Count == 0)
            // no matching record found, return false
            return false;

        DSNaturalezaSQL.NaturalezaRow naturaleza = naturalezas[0];

        if (NaturalezaCodigoPadre != null)
        {
            if (NaturalezaCodigoPadre.Contains(" | "))
            {
                NaturalezaCodigoPadre = NaturalezaCodigoPadre.Remove(NaturalezaCodigoPadre.IndexOf(" | "));
            }
        }
        if (NaturalezaDependenciaPQR != null)
        {
            if (NaturalezaDependenciaPQR.Contains(" | "))
            {
                NaturalezaDependenciaPQR = NaturalezaDependenciaPQR.Remove(NaturalezaDependenciaPQR.IndexOf(" | "));
            }
        }
        naturaleza.NaturalezaCodigo = Original_NaturalezaCodigo;
        naturaleza.NaturalezaNombre = NaturalezaNombre;
        naturaleza.NaturalezaCodigoPadre = NaturalezaCodigoPadre;
        naturaleza.NaturalezaDiasVence = NaturalezaDiasVence;
        naturaleza.NaturalezaHabilitar = NaturalezaHabilitar;
        naturaleza.NaturalezaPermiso = NaturalezaPermiso;
        naturaleza.NaturalezaPQR = NaturalezaPQR;
        naturaleza.NaturalezaDependenciaPQR = NaturalezaDependenciaPQR;
        naturaleza.Original_NaturalezaCodigo = Original_NaturalezaCodigo;        
        
        //naturalezas.AddNaturalezaRow(naturaleza);
        // Update the product record
        int rowsAffected = AdapterNaturaleza.Update(naturalezas);

        // Return true if precesely one row was updated, otherwise false
        return rowsAffected == 1;
    }

    else
    {

        bool rowsAffected = ObjNaturaleza.UpdateNaturaleza(NaturalezaNombre, NaturalezaCodigoPadre, NaturalezaDiasVence, NaturalezaHabilitar, NaturalezaPermiso, NaturalezaPQR, NaturalezaDependenciaPQR, Original_NaturalezaCodigo);
        return rowsAffected;

    }

}
catch (Exception e)
{
    throw new ApplicationException("Error en la capa BLL Naturaleza.CrearNaturaleza(). " + e.Message);
}

            }
    // DELETE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteNaturaleza(string Original_NaturalezaCodigo)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            if (strbase == "SqlServer")
            {
        int rowsAffected = AdapterNaturaleza.Delete(Original_NaturalezaCodigo);

        // Return true if precesely one row was updated, otherwise fals
        return rowsAffected == 1;
    }

    else
    {

        bool rowsAffected = ObjNaturaleza.DeleteNaturaleza(Original_NaturalezaCodigo);
        return rowsAffected;

    }

}
catch (Exception e)
{
    throw new ApplicationException("Error en la capa BLL Naturaleza.CrearNaturaleza(). " + e.Message);
}

            }

    public bool NaturalezaExiste(string NaturalezaCodigo)
    {

        if (Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos")) == "SqlServer")
        {
            DSNaturalezaSQLTableAdapters.Naturaleza_ReadExistePNaturalezaTableAdapter TANaturalezaExiste = new DSNaturalezaSQLTableAdapters.Naturaleza_ReadExistePNaturalezaTableAdapter();
            DSNaturalezaSQL.Naturaleza_ReadExistePNaturalezaDataTable DTNaturalezaExiste = new DSNaturalezaSQL.Naturaleza_ReadExistePNaturalezaDataTable();
            DTNaturalezaExiste = TANaturalezaExiste.GetNaturaleza_ReadExisteNaturaleza(NaturalezaCodigo);


            if (DTNaturalezaExiste.Count == 0)
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
            mDataTable = ObjNaturaleza.ExisteNaturaleza(NaturalezaCodigo);

            return false;
        }
    }

}

