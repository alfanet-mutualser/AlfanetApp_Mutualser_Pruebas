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
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

/// <summary>
/// Descripción breve de DalPlantillas
/// </summary>
public class DalPlantillas
{
    Database DB;	
    internal DataSet LoadPlantillaList()
    {
        DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
        using (DbCommand dbCommand = DB.GetStoredProcCommand("Plantilla_ListaPermisos"))
        {
            try
            {
                DataSet data = DB.ExecuteDataSet(dbCommand);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    internal int GuardarPermiso(string codigoPlantilla, string depCodigo)
    {
        DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
        using (DbCommand dbCommand = DB.GetStoredProcCommand("plantillaPermiso_setPermiso"))
        {
            try
            {
                DB.AddInParameter(dbCommand, "plantilla", DbType.String, codigoPlantilla);
                DB.AddInParameter(dbCommand, "dependencia", DbType.String, depCodigo);
                int result = DB.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    internal int ValidarDependencia(string depCodigo)
    {
        DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
        using (DbCommand dbCommand = DB.GetStoredProcCommand("plantillaPermiso_validarDependencia"))//un select count.
        {
            try
            {
                DB.AddInParameter(dbCommand, "dependencia", DbType.String, depCodigo);
                int result = Convert.ToInt32(DB.ExecuteScalar(dbCommand));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    internal DataSet GetDependencias()
    {
        DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
        using (DbCommand dbCommand = DB.GetStoredProcCommand("dependencia_obtenerdependencias_av2"))
        {
            try
            {
                DataSet ds = new DataSet();
                ds = DB.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    internal DataSet GetDependenciasByPlantillaCodigo(string plantillaCodigo)
    {
        DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
        using (DbCommand dbCommand = DB.GetStoredProcCommand("plantilla_get_permisosbyplantillacodigo"))
        {
            try
            {
                DB.AddInParameter(dbCommand, "plantillaCodigo", DbType.String, plantillaCodigo);
                DataSet ds = new DataSet();
                ds = DB.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    internal int EliminarPermiso(string codigoPlantilla, string depCodigo)
    {
        DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
        using (DbCommand dbCommand = DB.GetStoredProcCommand("plantillaPermiso_deletepermiso"))
        {
            try
            {
                DB.AddInParameter(dbCommand, "plantilla", DbType.String, codigoPlantilla);
                DB.AddInParameter(dbCommand, "dependencia", DbType.String, depCodigo);
                int result = DB.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
