using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using AjaxControlToolkit;
using System.Collections.Specialized;


/// <summary>
/// Descripción breve de CascadinDropDown
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService()]

public class CascadinDropDown : System.Web.Services.WebService {


    public CascadinDropDown () {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetPais(
        string knownCategoryValues, 
        string category)
    {

        List<CascadingDropDownNameValue> values = 
            new List<CascadingDropDownNameValue>();
        PaisBLL ObjPaises = new PaisBLL();

        foreach (DataRow dr in ObjPaises.GetPais())
        {
            string mPaisNombre = (string)dr["PaisNombre"];
            string mPaisCodigo = (string)dr["paisCodigo"];
            values.Add(new CascadingDropDownNameValue(
              mPaisNombre, mPaisCodigo));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetDepartamentoByPais(
      string knownCategoryValues,
      string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(
              knownCategoryValues);
        int mPaisCodigo;
        if (!kv.ContainsKey("Pais") ||
        !Int32.TryParse(kv["Pais"], out mPaisCodigo))
        {
            return null;
        }

        List<CascadingDropDownNameValue> values =
           new List<CascadingDropDownNameValue>();
        DepartamentoBLL ObjDepartamento = new DepartamentoBLL();


        foreach (DataRow dr in ObjDepartamento.GetDepartamentoByPais(mPaisCodigo.ToString()))
        {
            string mDepartamentoNombre = (string)dr["DepartamentoNombre"];
            string mDepartamentoCodigo = (string)dr["DepartamentoCodigo"];
            values.Add(new CascadingDropDownNameValue(
              mDepartamentoNombre, mDepartamentoCodigo));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetCiudadByDepartamento(
      string knownCategoryValues,
      string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //int mDepartamentoCodigo;
        string mDepartamentoCodigo = kv["Departamento"].ToString();
          
        //if (!kv.ContainsKey("Departamento") ||
        //!Int32.TryParse(kv["Departamento"], out mDepartamentoCodigo))
        //{
        //    return null;
        //}

        List<CascadingDropDownNameValue> values =
           new List<CascadingDropDownNameValue>();
        CiudadBLL ObjCiudad = new CiudadBLL();


        foreach (DataRow dr in ObjCiudad.GetCiudadByDepartamento(mDepartamentoCodigo.ToString()))
        {
            string mCiudadNombre = (string)dr["CiudadNombre"];
            string mCiudadCodigo = (string)dr["CiudadCodigo"];
            values.Add(new CascadingDropDownNameValue(
              mCiudadNombre, mCiudadCodigo));
        }
        return values.ToArray();
    }
   
/////////////////////////////PQR NAturaleza
    [WebMethod]
    public CascadingDropDownNameValue[] GetNaturalezaByPQR(
        string knownCategoryValues,
        string category)
    {

        List<CascadingDropDownNameValue> values =
            new List<CascadingDropDownNameValue>();
        NaturalezaBLL ObjNaturalezas = new NaturalezaBLL();

        foreach (DataRow dr in ObjNaturalezas.GetNaturalezaByPQR())
        {
            string mNaturalezaNombre = (string)dr["NaturalezaNombre"];
            string mNaturalezaCodigo = (string)dr["NaturalezaCodigo"];
            values.Add(new CascadingDropDownNameValue(
              mNaturalezaNombre, mNaturalezaCodigo));
        }
        return values.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetDependenciaByNaturaleza(
      string knownCategoryValues,
      string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(
              knownCategoryValues);
        string mNaturalezaCodigo;
        //mNaturalezaCodigo= kv.Values[0];
        mNaturalezaCodigo = kv["naturaleza"].ToString();
        //mNaturalezaCodigo = "091";
        //int mNaturalezaCodigo;
        //if (!kv.ContainsKey("Naturaleza") ||
        //!Int32.TryParse(kv["Naturaleza"], out mNaturalezaCodigo))
        //{
        //    return null;
        //}

        List<CascadingDropDownNameValue> values =
           new List<CascadingDropDownNameValue>();

        NaturalezaBLL ObjNaturaleza = new NaturalezaBLL();


        foreach (DataRow dr in ObjNaturaleza.GetDependenciaByNaturaleza(mNaturalezaCodigo.ToString()))
        {
            string mDependenciaNombre = (string)dr["DependenciaNombre"];
            string mDependenciaCodigo = (string)dr["NaturalezaDependenciaPQR"];
            values.Add(new CascadingDropDownNameValue(
              mDependenciaNombre, mDependenciaCodigo));
        }
        return values.ToArray();
    }

 //////////////////////////////////////////////////////////////
    /*

    [WebMethod]
    public CascadingDropDownNameValue[] GetMakes(
      string knownCategoryValues,
      string category)
    {
        CarsTableAdapters.MakeTableAdapter makeAdapter =
          new CarsTableAdapters.MakeTableAdapter();
        Cars.MakeDataTable makes = makeAdapter.GetMakes();
        List<CascadingDropDownNameValue> values =
          new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in makes)
        {
            string make = (string)dr["Make"];
            int makeId = (int)dr["MakeID"];
            values.Add(new CascadingDropDownNameValue(
              make, makeId.ToString()));
        }
        return values.ToArray();
    }




    [WebMethod]
    public CascadingDropDownNameValue[] GetModelsForMake(
      string knownCategoryValues,
      string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(
          knownCategoryValues);
        int makeId;
        if (!kv.ContainsKey("Make") ||
            !Int32.TryParse(kv["Make"], out makeId))
        {
            return null;
        }
        CarsTableAdapters.ModelTableAdapter makeAdapter =
          new CarsTableAdapters.ModelTableAdapter();
        Cars.ModelDataTable models =
          makeAdapter.GetModelsForMake(makeId);
        List<CascadingDropDownNameValue> values =
          new List<CascadingDropDownNameValue>();
        foreach (DataRow dr in models)
        {
            values.Add(new CascadingDropDownNameValue(
              (string)dr["Model"], dr["ModelID"].ToString()));
        }
        return values.ToArray();
    }

    */

}






