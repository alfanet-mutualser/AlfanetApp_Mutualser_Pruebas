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
/// Descripción breve de OraDataClass
/// </summary>
public class OraDataClass
{
	public OraDataClass()
	{
	}

    #region "Variables"

    OracleDataAdapter Adaptador;
    OracleCommand Comando;

    #endregion

    public DataSet GetDataSet(string NombreSp, OracleParameter[] Parametros, bool SP)
    {
        DataSet ds = new DataSet();
        OraConnectionClass ConnClass = new OraConnectionClass();
        OracleConnection oraConn = new OracleConnection();
        try
        {
            oraConn = ConnClass.CrearConexion();
            oraConn.Open();

            Comando = new OracleCommand(NombreSp, oraConn);
            if (SP == true)
                AddCmdParameters(Parametros);
            Adaptador = new OracleDataAdapter(Comando);
            Adaptador.Fill(ds);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            oraConn.Close();
            oraConn.Dispose();
        }
        return ds;
    }

    void AddCmdParameters(OracleParameter[] Parametros)
    {
        Comando.Parameters.Clear();
        for (int i = 0; i < Parametros.Length; i++)
            Comando.Parameters.Add(Parametros[i]);
        Comando.CommandType = CommandType.StoredProcedure;
    }

    public OracleCommand ExecuteProcedureOutput(string NombreSP, OracleParameter[] parametros)
    {
        OracleConnection oraConn = new OracleConnection();
        OraConnectionClass ConnClass = new OraConnectionClass();
        try
        {
            oraConn = ConnClass.CrearConexion();
            oraConn.Open();
            OracleCommand Comando = new OracleCommand(NombreSP, oraConn);
            for (int i = 0; i < parametros.Length; i++)
                Comando.Parameters.Add(parametros[i]);

            Comando.CommandType = CommandType.StoredProcedure;
            Comando.ExecuteNonQuery();
            return Comando;
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            oraConn.Close();
            oraConn.Dispose();
        }
    }
}
