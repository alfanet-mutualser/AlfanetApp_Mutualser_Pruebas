using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Descripción breve de Ajax
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
 [System.Web.Script.Services.ScriptService]
public class Ajax : System.Web.Services.WebService {

    [WebMethod]
    public List<string> GetDependencias(string keyword)
    {
        BLLPlantillas bll = null;
        List<ObjDependencia> dependencias = null;
        try
        {
            dependencias = new List<ObjDependencia>();
            bll = new BLLPlantillas();
            string resultSearch = null;
            dependencias = bll.GetDependencias();
            //dependencias = bll.FindDependenciasInCache("Dependencias", out resultSearch);
            List<string> output = new List<string>();
            dependencias = dependencias.Where(x => x.DependenciaNombre.ToUpper().Contains(keyword.ToUpper()) || x.DependenciaCodigo.ToUpper().Contains(keyword.ToUpper())).ToList();

            foreach (ObjDependencia item in dependencias)
            {
                string anidado = item.DependenciaCodigo + " | " + item.DependenciaNombre;
                output.Add(anidado);
            }
            return output;
        }
        catch (Exception)
        {
            throw;
        }
    }    
}

