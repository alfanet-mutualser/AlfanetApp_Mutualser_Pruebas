using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Descripción breve de AutoComplete
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService {

    public AutoComplete() 
    {
         
    }       
 
    [WebMethod]
    public string[] GetDependenciaByTextnull(string prefixText)
    {
        List<string> DependenciaList = new List<string>(20);
        DependenciaBLL dependencias = new DependenciaBLL();
        foreach (DataRow DataRowCurrent in dependencias.GetDependenciaByText(prefixText,null))
        {
            DependenciaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
        }
        return (DependenciaList.ToArray());
    }

 
    [WebMethod]
    public string[] GetNombreUnidadByTextnull(string prefixText)
    {
        List<string> NombreUnidadList = new List<string>(20);
        CamposUniDocBLL NombreUnidad = new CamposUniDocBLL();
        foreach (DataRow DataRowCurrent in NombreUnidad.GetData(prefixText))
        {
            NombreUnidadList.Add(DataRowCurrent[0].ToString() );
        }
        return (NombreUnidadList.ToArray());
    }

    [WebMethod]
    public string[] GetUbicacionByTextnull(string prefixText)
    {
        List<string> UbicacionList = new List<string>(20);
        CamposUniDocBLL Ubicacion = new CamposUniDocBLL();
        foreach (DataRow DataRowCurrent in Ubicacion.GetUbicacionByText(prefixText, null))
        {
            UbicacionList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
        }
        return (UbicacionList.ToArray());
    }

    [WebMethod]
    public string[] GetFormaByTextnull(string prefixText)
    {
        List<string> FormaList = new List<string>(20);
        CamposUniDocBLL Forma = new CamposUniDocBLL();
        foreach (DataRow DataRowCurrent in Forma.GetFormaByText(prefixText, null))
        {
            FormaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
        }
        return (FormaList.ToArray());
    }

    [WebMethod]
    public string[] GetTipologiaByTextnull(string prefixText)
    {
        List<string> TipologiaList = new List<string>(20);
        CamposUniDocBLL Tipologia = new CamposUniDocBLL();
        foreach (DataRow DataRowCurrent in Tipologia.GetTipologiaByText(prefixText, null))
        {
            TipologiaList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString());
        }
        return (TipologiaList.ToArray());
    }

    [WebMethod]
    public string[] GetSerieByText(string prefixText)
    {
        List<String> SerieList = new List<string>(20);
        SerieBLL Series = new SerieBLL();
        foreach (DataRow DataRowCurrent in Series.GetSerieByText(prefixText,"1"))
        {
            SerieList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
        }
        return (SerieList.ToArray());
    }

    [WebMethod]
    public string[] GetSerieTextById(string prefixText)
    {
        List<String> SerieList = new List<string>(20);
        SerieBLL Series = new SerieBLL();
        foreach (DataRow DataRowCurrent in Series.GetSerieTextById(prefixText,"1"))
        {
            SerieList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
        }
        return (SerieList.ToArray());
    }

    [WebMethod]
    public string[] GetSerieByTextnull(string prefixText)
    {
        List<String> SerieList = new List<string>(20);
        SerieBLL Series = new SerieBLL();
        foreach (DataRow DataRowCurrent in Series.GetSerieByText(prefixText, null))
        {
            SerieList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
        }
        return (SerieList.ToArray());
    }

    [WebMethod]
    public string[] GetSerieTextByIdnull(string prefixText)
    {
        List<String> SerieList = new List<string>(20);
        SerieBLL Series = new SerieBLL();
        foreach (DataRow DataRowCurrent in Series.GetSerieTextById(prefixText,null))
        {
            SerieList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
        }
        return (SerieList.ToArray());
    }

    [WebMethod]
    public string[] GetWFAccionTextByText(string prefixText)
    {
        List<string> WFAccionList = new List<string>(20);
        WFAccionBLL WFAcciones = new WFAccionBLL();

        foreach (DataRow DataRowCurrent in WFAcciones.GetWFAccionTextByText (prefixText, "1"))
        {
            WFAccionList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
           
        }
        return (WFAccionList.ToArray());
    }

    [WebMethod]
    public string[] GetWFAccionTextById(string prefixText)
    {
        List<string> WFAccionList = new List<string>(20);
        WFAccionBLL WFAcciones = new WFAccionBLL();
        foreach (DataRow DataRowCurrent in WFAcciones.GetWFAccionTextById(prefixText,"1"))
        {
            WFAccionList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
        }
        return (WFAccionList.ToArray());
    }
    
    [WebMethod]
    public string[] GetWFAccionTextByIdnull(string prefixText)
    {
        List<string> WFAccionList = new List<string>(20);
        WFAccionBLL WFAcciones = new WFAccionBLL();
        foreach (DataRow DataRowCurrent in WFAcciones.GetWFAccionTextById(prefixText, null))
        {
            WFAccionList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
        }
        return (WFAccionList.ToArray());
    }

    [WebMethod]
    public string[] GetWFAccionTextByTextnull(string prefixText)
    {
        List<string> WFAccionList = new List<string>(20);
        WFAccionBLL WFAcciones = new WFAccionBLL();
        foreach (DataRow DataRowCurrent in WFAcciones.GetWFAccionTextByText(prefixText,null))
        {
            WFAccionList.Add(DataRowCurrent[0].ToString() + " | " + DataRowCurrent[1].ToString().ToUpper());
        }
        return (WFAccionList.ToArray());
    }

}