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
/// Descripción breve de DalWorkflow
/// </summary>
public class DalWorkflow
{

    Database DB;

	public DalWorkflow()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public Boolean ValidarExistenciaBD(String codigo,String tabla)
    {
        String resultado = "false";
        try
        {
            DB = DatabaseFactory.CreateDatabase("ConnStrSQLServer");
            using (DbCommand dbCommand = DB.GetStoredProcCommand("WFMovimiento_ReadWFMovimientoValidarExistenciaRegistro"))
            {
               
                DB.AddInParameter(dbCommand, "codigo", DbType.String, codigo);
                DB.AddInParameter(dbCommand, "nombreTabla", DbType.String, tabla);
                DB.AddOutParameter(dbCommand, "resultadoBoolean", DbType.String, 5);
                DB.ExecuteDataSet(dbCommand);
                resultado = DB.GetParameterValue(dbCommand, "@resultadoBoolean").ToString();
            return Convert.ToBoolean(resultado);

            }
        }
        catch (Exception ex)
         {
             throw ex;
         }
    }
}
