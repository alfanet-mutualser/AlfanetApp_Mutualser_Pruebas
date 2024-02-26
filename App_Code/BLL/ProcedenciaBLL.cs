using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DSProcedenciaSQLTableAdapters;

/// <summary>
/// Descripción breve de ProcedenciaBLL
/// </summary>

[System.ComponentModel.DataObject]
public class ProcedenciaBLL
{
    private ProcedenciaTableAdapter _procedenciaAdapter = null;
    protected ProcedenciaTableAdapter AdapterProcedencia
    {
        get
        {
            if (_procedenciaAdapter == null)
                _procedenciaAdapter = new ProcedenciaTableAdapter();

            return _procedenciaAdapter;
        }
    }

    private ProcedenciaByTextTableAdapter _procedenciaByTextAdapter = null;
    protected ProcedenciaByTextTableAdapter AdapterProcedenciaByText
    {
        get
        {
            if (_procedenciaByTextAdapter == null)
                _procedenciaByTextAdapter = new ProcedenciaByTextTableAdapter();

            return _procedenciaByTextAdapter;
        }
    }


    // SELECT METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSProcedenciaSQL.ProcedenciaDataTable GetProcedencia()
    {
        return AdapterProcedencia.GetProcedencia();
    }

    // SELECT METHOD ById
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSProcedenciaSQL.ProcedenciaDataTable GetProcedenciaByID(string ProcedenciaCodigo)
    {
        return AdapterProcedencia.GetProcedenciaById(ProcedenciaCodigo);
    }

    // SELECT METHOD ByTextNombre
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSProcedenciaSQL.ProcedenciaByTextDataTable GetProcedenciaByTextNombre(string ProcedenciaNombre,String ProcedenciaHabilitar)
    {
        return AdapterProcedenciaByText.GetProcedenciaByTextNombre(ProcedenciaNombre,ProcedenciaHabilitar);
    }

    // SELECT METHOD ByTextId
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSProcedenciaSQL.ProcedenciaByTextDataTable GetProcedenciaByTextId(string ProcedenciaCodigo,String ProcedenciaHabilitar)
    {
        return AdapterProcedenciaByText.GetProcedenciaByTextId(ProcedenciaCodigo, ProcedenciaHabilitar);
    }

    // CREATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool AddProcedencia(string ProcedenciaNUI, string ProcedenciaCodigo, string ProcedenciaNombre, string ProcedenciaNUIPadre, string ProcedenciaDireccion, string ProcedenciaTelefono1, string ProcedenciaTelefono2, string ProcedenciaFax, string ProcedenciaMail1, string ProcedenciaMail2, string ProcedenciaPaginaWeb, string CiudadCodigo, string ProcedenciaHabilitar, string ProcedenciaPermiso)
    {
        // Create a new ExpedienteRow instance
        DSProcedenciaSQL.ProcedenciaDataTable procedencias = new DSProcedenciaSQL.ProcedenciaDataTable();
        DSProcedenciaSQL.ProcedenciaRow procedencia = procedencias.NewProcedenciaRow();

        if (ProcedenciaNUIPadre != null)
        {
            if (ProcedenciaNUIPadre.Contains(" | "))
            {
                ProcedenciaNUIPadre = ProcedenciaNUIPadre.Remove(ProcedenciaNUIPadre.IndexOf(" | "));
            }
        }
        if (CiudadCodigo != null)
        {
            if (CiudadCodigo.Contains(" | "))
            {
                CiudadCodigo = CiudadCodigo.Remove(CiudadCodigo.IndexOf(" | "));
            }
        }

        procedencia.ProcedenciaNUI = ProcedenciaNUI;
        procedencia.ProcedenciaCodigo = ProcedenciaCodigo;
        procedencia.ProcedenciaNombre = ProcedenciaNombre;
        if (ProcedenciaNUIPadre == null)
            procedencia.SetProcedenciaNUIPadreNull();
        else 
            procedencia.ProcedenciaNUIPadre = ProcedenciaNUIPadre;
        procedencia.ProcedenciaDireccion = ProcedenciaDireccion;
        procedencia.ProcedenciaTelefono1 = ProcedenciaTelefono1;
        if (ProcedenciaTelefono2 == null)
            procedencia.SetProcedenciaTelefono2Null();
        else 
            procedencia.ProcedenciaTelefono2 = ProcedenciaTelefono2;
        if (ProcedenciaFax == null)
            procedencia.SetProcedenciaFaxNull();
        else 
            procedencia.ProcedenciaFax = ProcedenciaFax;
        procedencia.ProcedenciaMail1 = ProcedenciaMail1;
        if (ProcedenciaMail2 == null)
            procedencia.SetProcedenciaMail2Null();
        else 
            procedencia.ProcedenciaMail2 = ProcedenciaMail2;
        if (ProcedenciaPaginaWeb == null)
            procedencia.SetProcedenciaPaginaWebNull();
        else 
            procedencia.ProcedenciaPaginaWeb = ProcedenciaPaginaWeb;
        procedencia.CiudadCodigo = CiudadCodigo;
        procedencia.ProcedenciaHabilitar = ProcedenciaHabilitar;
        procedencia.ProcedenciaPermiso = ProcedenciaPermiso;
        
        // Add the new expediente
        procedencias.AddProcedenciaRow(procedencia);
        int rowsAffected = AdapterProcedencia.Update(procedencias);

        // Return true if precesely one row was inserted, otherwise false
        return rowsAffected == 1;

    }

    // UPDATE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool UpdateProcedencia(string ProcedenciaCodigo, string ProcedenciaNombre, string ProcedenciaNUIPadre, string ProcedenciaDireccion, string ProcedenciaTelefono1, string ProcedenciaTelefono2, string ProcedenciaFax, string ProcedenciaMail1, string ProcedenciaMail2, string ProcedenciaPaginaWeb, string CiudadCodigo, string ProcedenciaHabilitar, string ProcedenciaPermiso,string Original_ProcedenciaNUI)
    {
        DSProcedenciaSQL.ProcedenciaDataTable procedencias = AdapterProcedencia.GetProcedenciaById(Original_ProcedenciaNUI);
        if (procedencias.Count == 0)
            // no matching record found, return false
            return false;

        DSProcedenciaSQL.ProcedenciaRow procedencia = procedencias[0];

        if (ProcedenciaNUIPadre != null)
        {
            if (ProcedenciaNUIPadre.Contains(" | "))
            {
                ProcedenciaNUIPadre = ProcedenciaNUIPadre.Remove(ProcedenciaNUIPadre.IndexOf(" | "));
            }
        }
        if (CiudadCodigo != null)
        {
            if (CiudadCodigo.Contains(" | "))
            {
                CiudadCodigo = CiudadCodigo.Remove(CiudadCodigo.IndexOf(" | "));
            }
        }

        procedencia.ProcedenciaNUI = Original_ProcedenciaNUI;
        procedencia.ProcedenciaCodigo = ProcedenciaCodigo;
        procedencia.ProcedenciaNombre = ProcedenciaNombre;
        if (ProcedenciaNUIPadre == null)
            procedencia.SetProcedenciaNUIPadreNull();
        else 
            procedencia.ProcedenciaNUIPadre = ProcedenciaNUIPadre;
        procedencia.ProcedenciaDireccion = ProcedenciaDireccion;
        procedencia.ProcedenciaTelefono1 = ProcedenciaTelefono1;
        if (ProcedenciaTelefono2 == null)
            procedencia.SetProcedenciaTelefono2Null();
        else 
            procedencia.ProcedenciaTelefono2 = ProcedenciaTelefono2;
        if (ProcedenciaFax == null)
            procedencia.SetProcedenciaFaxNull();
        else
            procedencia.ProcedenciaFax = ProcedenciaFax;
        procedencia.ProcedenciaMail1 = ProcedenciaMail1;
        if (ProcedenciaMail2 == null)
            procedencia.SetProcedenciaMail2Null();
        else
            procedencia.ProcedenciaMail2 = ProcedenciaMail2;
        if (ProcedenciaPaginaWeb == null)
            procedencia.SetProcedenciaPaginaWebNull();
        else 
            procedencia.ProcedenciaPaginaWeb = ProcedenciaPaginaWeb;
        procedencia.CiudadCodigo = CiudadCodigo;
        procedencia.ProcedenciaHabilitar = ProcedenciaHabilitar;
        procedencia.ProcedenciaPermiso = ProcedenciaPermiso;
        procedencia.Original_ProcedenciaNUI = Original_ProcedenciaNUI;

        // Update the product record
        int rowsAffected = AdapterProcedencia.Update(procedencias);

        // Return true if precesely one row was updated, otherwise false
        return rowsAffected == 1;

    }
    // DELETE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteProcedencia(string Original_ProcedenciaNUI)
    {
        int rowsAffected = AdapterProcedencia.Delete(Original_ProcedenciaNUI);

        // Return true if precesely one row was updated, otherwise fals
        return rowsAffected == 1;
    }

}
