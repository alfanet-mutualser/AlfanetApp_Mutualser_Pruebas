using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Oracle.DataAccess.Client;

/// <summary>
/// Descripción breve de OraConnectionClass
/// </summary>
public class OraConnectionClass
{
    public OraConnectionClass()
    {
    }

    #region Variables

        OracleConnection oraConn = new OracleConnection();

    #endregion

        
    #region Metodos

    public OracleConnection CrearConexion(){

        try
        {

            //string mVariable = "";
            //mVariable = System.Configuration.ConfigurationManager.ConnectionStrings["OraAspNetConString"].ConnectionString;
            oraConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OraAspNetConString1"].ConnectionString;
            //mVariable = mVariable + " Prueba";
            //oraConn.ConnectionString = System.Configuration.ConnectionStringSettingsConfigurationManager.AppSettings.Get("OraAspNetConString").ToString();
            //oraConn.Close();

            return oraConn;
        }

        catch (Exception e)
        {
            throw new ApplicationException("Error al intentar conexion con Oracle. " + e.Message);
        }
    }

    #endregion 

}
