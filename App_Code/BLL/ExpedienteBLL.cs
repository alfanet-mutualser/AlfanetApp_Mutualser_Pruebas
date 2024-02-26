using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSExpedienteSQLTableAdapters;

/// <summary>
/// Descripción breve de ExpedienteBLL
/// </summary>
//

[System.ComponentModel.DataObject]
public class ExpedienteBLL
{
    private ExpedienteTableAdapter _expedienteAdapter = null;
    protected ExpedienteTableAdapter AdapterExpediente
    {
        get
        {
            if (_expedienteAdapter == null)
                _expedienteAdapter = new ExpedienteTableAdapter();

            return _expedienteAdapter;
        }
    }

    private ExpedienteByTextTableAdapter _expedienteByTextAdapter = null;
    protected ExpedienteByTextTableAdapter AdapterExpedienteByText
    {
        get
        {
            if (_expedienteByTextAdapter == null)
                _expedienteByTextAdapter = new ExpedienteByTextTableAdapter();

            return _expedienteByTextAdapter;
        }
    }

    private ExpedientePermisoTableAdapter _expedientePermisoAdapter = null;
    protected ExpedientePermisoTableAdapter AdapterExpedientePermiso
    {
        get
        {
            if (_expedientePermisoAdapter == null)
                _expedientePermisoAdapter = new ExpedientePermisoTableAdapter();

            return _expedientePermisoAdapter;
        }
    }

    // SELECT EXPEDIENTE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSExpedienteSQL.ExpedienteDataTable GetExpediente()
    {
        return AdapterExpediente.GetExpediente();
    }

    // SELECT EXPEDIENTE METHOD ById
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSExpedienteSQL.ExpedienteDataTable GetExpedienteById(string ExpedienteCodigo)
    {
        return AdapterExpediente.GetExpedienteById(ExpedienteCodigo);
    }

    // SELECT EXPEDIENTE METHOD ByTextNombre
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSExpedienteSQL.ExpedienteByTextDataTable GetExpedienteByTextNombre(string ExpedienteNombre,bool ExpedienteHabilitar)
    {
        return AdapterExpedienteByText.GetExpedienteByTextNombre(ExpedienteNombre, ExpedienteHabilitar);
    }

    // SELECT EXPEDIENTE METHOD ByTextNombre1
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSExpedienteSQL.ExpedienteByTextDataTable GetExpedienteByTextNombre1(string ExpedienteNombre, bool ExpedienteHabilitar, string DependenciaConsulta)
    {
        return AdapterExpedienteByText.GetExpedienteByTextNombre1(ExpedienteNombre, ExpedienteHabilitar,DependenciaConsulta);
    }


    // SELECT EXPEDIENTE METHOD ByTextId
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public DSExpedienteSQL.ExpedienteByTextDataTable GetExpedienteByTextId(string ExpedienteNombre, bool ExpedienteHabilitar)
    {
        return AdapterExpedienteByText.GetExpedienteByTextId(ExpedienteNombre, ExpedienteHabilitar);
    }

    // CREATE EXPEDIENTE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]
    public bool AddExpediente(string ExpedienteCodigo, string ExpedienteNombre, string ExpedienteCodigoPadre, bool ExpedienteHabilitar, bool ExpedientePermiso, string ExpedienteDireccion, string ExpedienteTelefono1, string ExpedienteTelefono2, string ExpedienteFax, string ExpedienteMail1, String ExpedienteMail2, string ExpedientePaginaWeb)
    {
        try
        {
            // Create a new ExpedienteRow instance
            DSExpedienteSQL.ExpedienteDataTable expedientes = new DSExpedienteSQL.ExpedienteDataTable();
            DSExpedienteSQL.ExpedienteRow expediente = expedientes.NewExpedienteRow();

            if (ExpedienteCodigoPadre != null)
            {
                if (ExpedienteCodigoPadre.Contains(" | "))
                {
                    ExpedienteCodigoPadre = ExpedienteCodigoPadre.Remove(ExpedienteCodigoPadre.IndexOf(" | "));
                }
                
            }

            expediente.ExpedienteCodigo = ExpedienteCodigo;
            if (ExpedienteCodigoPadre == null) expediente.SetExpedienteCodigoPadreNull();
            else expediente.ExpedienteCodigoPadre = ExpedienteCodigoPadre;
            expediente.ExpedienteHabilitar = ExpedienteHabilitar;
            expediente.ExpedienteNombre = ExpedienteNombre;
            expediente.ExpedientePermiso = ExpedientePermiso;
            expediente.ExpedienteDireccion = ExpedienteDireccion;
            expediente.ExpedienteTelefono1 = ExpedienteTelefono1;
            expediente.ExpedienteTelefono2 = ExpedienteTelefono2;
            expediente.ExpedienteFax = ExpedienteFax;
            expediente.ExpedienteMail1 = ExpedienteMail1;
            expediente.ExpedienteMail2 = ExpedienteMail2;
            expediente.ExpedientePaginaWeb = ExpedientePaginaWeb;

            // Add the new expediente
            expedientes.AddExpedienteRow(expediente);
            int rowsAffected = AdapterExpediente.Update(expedientes);

            // Return true if precesely one row was inserted, otherwise false
            return rowsAffected == 1;

        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }
    
    // UPDATE EXPEDIENTE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
    public bool UpdateExpediente(string ExpedienteCodigo, string ExpedienteNombre, string ExpedienteCodigoPadre, bool ExpedienteHabilitar, bool ExpedientePermiso, string Original_ExpedienteCodigo, string ExpedienteDireccion, string ExpedienteTelefono1, string ExpedienteTelefono2, string ExpedienteFax, string ExpedienteMail1, string ExpedienteMail2, string ExpedientePaginaWeb)
    {
        try
        {
            DSExpedienteSQL.ExpedienteDataTable expedientes = AdapterExpediente.GetExpedienteById(Original_ExpedienteCodigo);
            if (expedientes.Count == 0)
                // no matching record found, return false
                return false;

            DSExpedienteSQL.ExpedienteRow expediente = expedientes[0];

            if (ExpedienteCodigoPadre != null)
            {
                if (ExpedienteCodigoPadre.Contains(" | "))
                {
                    ExpedienteCodigoPadre = ExpedienteCodigoPadre.Remove(ExpedienteCodigoPadre.IndexOf(" | "));
                }
            }

            expediente.ExpedienteCodigo = ExpedienteCodigo;
            if (ExpedienteCodigoPadre == null) expediente.SetExpedienteCodigoPadreNull();
            else expediente.ExpedienteCodigoPadre = ExpedienteCodigoPadre;
            expediente.ExpedienteHabilitar = ExpedienteHabilitar;
            expediente.ExpedienteNombre = ExpedienteNombre;
            expediente.ExpedientePermiso = ExpedientePermiso;
            expediente.ExpedienteDireccion = ExpedienteDireccion;
            expediente.ExpedienteTelefono1 = ExpedienteTelefono1;
            expediente.ExpedienteTelefono2 = ExpedienteTelefono2;
            expediente.ExpedienteFax = ExpedienteFax;
            expediente.ExpedienteMail1 = ExpedienteMail1;
            expediente.ExpedienteMail2 = ExpedienteMail2;
            expediente.ExpedientePaginaWeb = ExpedientePaginaWeb;

            // Update the product record
            int rowsAffected = AdapterExpediente.Update(expedientes);

            // Return true if precesely one row was updated, otherwise false
            return rowsAffected == 1;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }

    // DELETE EXPEDIENTE METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, false)]
    public bool DeleteExpediente(string Original_ExpedienteCodigo)
    {
        int rowsAffected = AdapterExpediente.Delete(Original_ExpedienteCodigo);

        // Return true if precesely one row was updated, otherwise false
        return rowsAffected == 1;
    }

    // SELECT EXPEDIENTEPERMISO METHOD ById
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSExpedienteSQL.ExpedientePermisoDataTable GetExpedientePermisoById(string ExpedienteCodigo)
    {
        return AdapterExpedientePermiso.GetExpedientePermisoById(ExpedienteCodigo);
    }

    // CREATE EXPEDIENTEPERMISO METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]
    public bool AddExpedientePermiso(string ExpedienteCodigo, string DependenciaCodigo)
    {
        // Create a new ExpedientePermisoRow instance
        DSExpedienteSQL.ExpedientePermisoDataTable expedientepermisos = new DSExpedienteSQL.ExpedientePermisoDataTable();
        DSExpedienteSQL.ExpedientePermisoRow permiso = expedientepermisos.NewExpedientePermisoRow();
        if (DependenciaCodigo != null)
        {
            if (DependenciaCodigo.Contains(" | "))
            {
                DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
            }
        }

       permiso.ExpedienteCodigo = ExpedienteCodigo;
       permiso.DependenciaCodigo = DependenciaCodigo;

        // Add the new ExpedientePermiso
       expedientepermisos.AddExpedientePermisoRow(permiso);
       int rowsAffected = AdapterExpedientePermiso.Update(expedientepermisos);

        // Return true if precesely one row was inserted, otherwise false
        return rowsAffected == 1;
    }


}
