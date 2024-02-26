using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ProcesoTableAdapters;

/// <summary>
/// Descripción breve de MedioBLL
/// </summary>

[System.ComponentModel.DataObject]
public class WFProcesoBLL
{
    //private MedioTableAdapter _medioAdapter = null;
    //protected MedioTableAdapter AdapterMedio
    //{
    //    get
    //    {
    //        if (_medioAdapter == null)
    //            _medioAdapter = new MedioTableAdapter();

    //        return _medioAdapter;
    //    }
    //}
    private WFProcesoTableAdapter _WFProcesoTableAdapter = null;
    protected WFProcesoTableAdapter AdapterWFProcesoByText
    {
        get
        {
            if (_WFProcesoTableAdapter == null)
                _WFProcesoTableAdapter = new WFProcesoTableAdapter();

            return _WFProcesoTableAdapter;
        }
    }


    //// SELECT METHOD
    //[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    //public DSMedioSQL.MedioDataTable GetMedio()
    //{
    //    return AdapterMedio.GetMedio();
    //}

    //// SELECT METHOD ById
    //[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    //public DSMedioSQL.MedioDataTable GetMedioByID(string MedioCodigo)
    //{
    //    return AdapterMedio.GetMedioById(MedioCodigo);
    //}

    //// SELECT METHOD ByText
    //[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    //public DSMedioSQL.MedioByTextDataTable GetMedioByText(string MedioNombre)
    //{
    //    return AdapterMedioByText.GetMedioByText(MedioNombre);
    //}

    // SELECT METHOD ByText
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Proceso.WFProcesoDataTable GetWFProcesoTextByText(String WFProcesoDescripcion, String WFProcesoHabilitar)
    {
        return AdapterWFProcesoByText.GetProcesoTextByText(WFProcesoDescripcion,WFProcesoHabilitar);
    }
    // SELECT METHOD ByTextId
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Proceso.WFProcesoDataTable GetWFProcesoTextById(String WFProcesoCodigo, String WFProcesoHabilitar)
    {
        return AdapterWFProcesoByText.GetProcesoTextById(WFProcesoCodigo, WFProcesoHabilitar);
    }

    //// CREATE METHOD
    //[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    //public bool AddMedio(string MedioCodigo, string MedioNombre, string MedioCodigoPadre, bool MedioHabilitar, bool MedioPermiso)
    //{
    //    // Create a new ExpedienteRow instance
    //    DSMedioSQL.MedioDataTable medios = new DSMedioSQL.MedioDataTable();
    //    DSMedioSQL.MedioRow medio = medios.NewMedioRow();

    //    medio.MedioCodigo = MedioCodigo;
    //    medio.MedioNombre = MedioNombre;
    //    medio.MedioCodigoPadre = MedioCodigoPadre;
    //    medio.MedioHabilitar = MedioHabilitar;
    //    medio.MedioPermiso = MedioPermiso;

    //    // Add the new expediente
    //    medios.AddMedioRow(medio);
    //    int rowsAffected = AdapterMedio.Update(medios);

    //    // Return true if precesely one row was inserted, otherwise false
    //    return rowsAffected == 1;

    //}

    //// UPDATE METHOD
    //[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    //public bool UpdateMedio(string MedioCodigo, string MedioNombre, string MedioCodigoPadre, bool MedioHabilitar, bool MedioPermiso)
    //{
    //    DSMedioSQL.MedioDataTable medios = AdapterMedio.GetMedioById(MedioCodigo);
    //    if (medios.Count == 0)
    //        // no matching record found, return false
    //        return false;

    //    DSMedioSQL.MedioRow medio = medios[0];

    //    medio.MedioCodigo = MedioCodigo;
    //    medio.MedioNombre = MedioNombre;
    //    medio.MedioCodigoPadre = MedioCodigoPadre;
    //    medio.MedioHabilitar = MedioHabilitar;
    //    medio.MedioPermiso = MedioPermiso;

    //    // Update the product record
    //    int rowsAffected = AdapterMedio.Update(medios);

    //    // Return true if precesely one row was updated, otherwise false
    //    return rowsAffected == 1;

    //}
    // DELETE METHOD
    //[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    //public bool DeleteMedio(string MedioCodigo)
    //{
    //    WFProcesoTableAdapter ProcesoDelete = new WFProcesoTableAdapter();
    //    //int rowsAffected = ProcesoDelete.

    //    // Return true if precesely one row was updated, otherwise fals
    //    return rowsAffected == 1;
    //}

}
