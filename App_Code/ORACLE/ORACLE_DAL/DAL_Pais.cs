using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using Oracle.DataAccess.Client;

/// <summary>
/// Descripción breve de DAL
/// </summary>
public class DAL_Pais
{
    public DAL_Pais()
    {
    }

    #region Variables
    //OraDataClass oraDataClass = new OraDataClass();
    DataSet DataSet;
    #endregion

    #region Metodos


    public bool CreatePais(string mPaisCodigo, string mPaisNombre, string mPaisHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[4];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_PaisCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mPaisCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_PaisNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mPaisNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_PaisHabilitar", OracleDbType.Varchar2);
        //Parametros[2].Value = mPaisHabilitar;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[3].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_PAIS.PAIS_CREATEPAIS", Parametros);

        return true;
    }

    public bool DeletePais(string mPaisCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_PaisCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mPaisCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_PAIS.PAIS_DELETEPAIS", Parametros);

        return true;
    }

    public bool UpdatePais(string mPaisCodigo, string mPaisNombre, string mPaisHabilitar, string mOriginalPaisCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[5];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_PaisCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mPaisCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_PaisNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mPaisNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_PaisHabilitar", OracleDbType.Varchar2);
        //Parametros[2].Value = mPaisHabilitar;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_Original_PaisCodigo", OracleDbType.Varchar2);
        //Parametros[3].Value = mOriginalPaisCodigo;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[4].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_PAIS.PAIS_UPDATEPAIS", Parametros);

        return true;
    }

    public DataTable GetPais()
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@sys_refcursor", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.Varchar2);
        //Parametros[1].Direction = ParameterDirection.Output;
        //Parametros[1].Size = 4000;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_PAIS.PAIS_READPAIS", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetPaisById(string mPaisCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_PaisCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mPaisCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_PAIS.PAIS_READPAISBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetPaisByLevel()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.Varchar2);
        //Parametros[1].Direction = ParameterDirection.Output;
        //Parametros[1].Size = 4000;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_PAIS.PAIS_READPAISBYLEVEL", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetPaisByTextId(string mPaisCodigo, string mPaisHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_PaisCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mPaisCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_PaisHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mPaisHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_PAIS.PAIS_READPAISBYTEXTID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetPaisByTextNombre(string mPaisNombre, string mPaisHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_PaisNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mPaisNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_PaisHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mPaisHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_PAIS.PAIS_READPAISBYTEXTNOMBRE", Parametros, true);

        return DataSet.Tables[0];
    }

   
    #endregion
}
