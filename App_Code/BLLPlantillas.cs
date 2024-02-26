using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

/// <summary>
/// Descripción breve de BLLPlantillas
/// </summary>
public class BLLPlantillas
{
	public BLLPlantillas()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}


    public DataSet LoadPlantillaList()
    {
        DataSet data = null;
        DalPlantillas dal = null;
        try
        {
            dal = new DalPlantillas();
            data = new DataSet();
            data = dal.LoadPlantillaList();
            return data;
        }
        catch (Exception ex)
        {            
            throw ex;
        }
    }

    public string GuardarPermisosGeneral(string codigoPlantilla, string dependencia)
    {        
        string result = string.Empty;
        List<string> errorList = null;
        DalPlantillas dal = null;
        try
        {
            dal = new DalPlantillas();
            errorList = new List<string>();
            bool guardo = GuardarPermisos(codigoPlantilla, dependencia);
            if (!guardo)
            {
                errorList.Add(dependencia);
            }
            
            if (errorList.Count > 0)
            {
                string resultAux = "";
                foreach (string dep in errorList)
	            {
                    resultAux = resultAux + dep + " - ";	 
	            }
                result = "La siguiente dependencia no se almacenó: " + resultAux + ". Proceso finalizado con errores.";
            }
            else
            {
                result = "Proceso finalizado correctamente.";
            }
            return result;
        }
        catch (Exception)
        {            
            return "Ocurrió un error al realizar el proceso.";
        }
    }

    private bool GuardarPermisos(string codigoPlantilla, string depCodigo)
    {
        DalPlantillas dal = null;
        try
        {
            if (codigoPlantilla == "")
            {
                codigoPlantilla = null;
            }
            dal = new DalPlantillas();
            int guardo = dal.GuardarPermiso(codigoPlantilla, depCodigo);
            if (guardo > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {            
            return false;
        }        
    }

    public int ValidarDependencia(string depCodigo)
    {
        DalPlantillas dal = null;
        try
        {
            dal = new DalPlantillas();
            if (depCodigo.Contains(" | "))
            {
                depCodigo = depCodigo.Remove(depCodigo.IndexOf(" | "));
            }
            int i = dal.ValidarDependencia(depCodigo);
            return i;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    internal List<ObjDependencia> FindDependenciasInCache(string name, out string result)
    {
        List<ObjDependencia> resultList = null;
        try
        {
            resultList = new List<ObjDependencia>();
            ICacheManager objectCache = CacheFactory.GetCacheManager();
            if (objectCache.Contains(name))
            {
                resultList = (List<ObjDependencia>)objectCache[name];
                result = string.Empty;
                return resultList;
            }
            else
            {
                result = "No se encontraron resultados en cache";
                return null;
            }
        }
        catch (Exception)
        {
            result = "Error";
            return null;
        }
    }

    public bool FindAnyObjInCache(string name, out string result)
    {
        try
        {
            ICacheManager objectCache = CacheFactory.GetCacheManager();
            if (objectCache.Contains(name))
            {
                result = "Objeto encontrado";
                return true;
            }
            else
            {
                result = "Objeto no encontrado";
                return false;
            }
        }
        catch (Exception)
        {
            result = "Error";
            return false;
        }
    }

    public List<ObjDependencia> GetDependencias()
    {
        DalPlantillas dal = null;
        ObjDependencia dependencia = null;        
        List<ObjDependencia> dependencias = null;
        DataSet data = null;
        try
        {
            dal = new DalPlantillas();            
            dependencias = new List<ObjDependencia>();
            data = new DataSet();
            data = dal.GetDependencias();
            foreach (DataRow item in data.Tables[0].Rows)
            {
                dependencia = new ObjDependencia();
                dependencia.DependenciaCodigo = item.ItemArray[0].ToString();
                dependencia.DependenciaNombre = item.ItemArray[1].ToString();
                dependencias.Add(dependencia);
            }
            return dependencias;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool SaveObjectInCache(string name, List<ObjDependencia> obj, out string result)
    {
        AbsoluteTime Expiration = new AbsoluteTime(new TimeSpan(1, 0, 0));
        try
        {
            ICacheManager objectCache = CacheFactory.GetCacheManager();
            objectCache.Add(name, obj, CacheItemPriority.High, null, new ICacheItemExpiration[] { Expiration });
            result = "Objeto Agregado al cache correctamente";
            return true;
        }
        catch (Exception ex)
        {
            result = "Error al agregar el objeto al cache " + ex.Message;
            return false;
        }
    }

    public List<string> GetDependenciasByPlantillaCodigo(string plantillaCodigo)
    {
        DalPlantillas dal = null;
        DataSet data = null;
        List<string> resultList = null;
        try
        {
            dal = new DalPlantillas();
            data = new DataSet();
            data = dal.GetDependenciasByPlantillaCodigo(plantillaCodigo);
            resultList = new List<string>();
            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    resultList.Add(item.ItemArray[0].ToString());
                }
            }
            return resultList;
        }
        catch (Exception ex)
        {            
            throw ex;
        }
    }

    public string EliminarPermisosGeneral(string codigoPlantilla, string dependencia)
    {
        string result = string.Empty;
        List<string> errorList = null;
        DalPlantillas dal = null;
        try
        {
            dal = new DalPlantillas();
            errorList = new List<string>();
            bool elimino = EliminarPermisos(codigoPlantilla, dependencia);
            if (!elimino)
            {
                errorList.Add(dependencia);
            }
            
            if (errorList.Count > 0)
            {
                string resultAux = "";
                foreach (string dep in errorList)
	            {
                    resultAux = resultAux + dep + " - ";	 
	            }
                result = "La siguiente dependencia no se eliminó: " + resultAux + ". Proceso finalizado con errores.";
            }
            else
            {
                result = "Proceso finalizado correctamente.";
            }
            return result;
        }
        catch (Exception)
        {
            return "Ocurrió un error al realizar el proceso.";
        }
    }
    private bool EliminarPermisos(string codigoPlantilla, string depCodigo)
    {
        DalPlantillas dal = null;
        try
        {
            if (codigoPlantilla == "")
            {
                codigoPlantilla = null;
            }
            dal = new DalPlantillas();
            int elimino = dal.EliminarPermiso(codigoPlantilla, depCodigo);
            if (elimino > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
}
