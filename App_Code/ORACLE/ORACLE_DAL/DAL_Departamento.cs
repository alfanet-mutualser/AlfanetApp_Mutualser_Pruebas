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
/// Descripción breve de DAL_Departamento
/// </summary>
public class DAL_Departamento
{
	public DAL_Departamento()
	{
    }

    #region Variables
    //OraDataClass oraDataClass = new OraDataClass();
    DataSet DataSet;
    #endregion

    #region Metodos


    public bool CrearDepartamento(string mDepartamentoCodigo, string mDepartamentoNombre, string mPaisCodigo, string mDepartamentoHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[5];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_DepartamentoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDepartamentoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DepartamentoNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mDepartamentoNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_PaisCodigo", OracleDbType.Varchar2);
        //Parametros[2].Value = mPaisCodigo;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_DepartamentoHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mDepartamentoHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[4].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_DEPARTAMENTOS.DEPTO_CREATEDEPTO", Parametros);

        return true;
    }

    public bool DeleteDepartamento(string mDepartamentoCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_DepartamentoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDepartamentoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_DEPARTAMENTOS.DEPTO_DELETEDEPTO", Parametros);

        return true;
    }

    public DataTable GetDepartamento()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;
        
        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPARTAMENTOS.DEPTO_READDEPTO", Parametros, true);

        return DataSet.Tables[0];
    }


    public DataTable GetDepartamentoById(string mDepartamentoCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_DepartamentoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDepartamentoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPARTAMENTOS.DEPTO_READDEPTOBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetDepartamentoByPais(string mPaisCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
       DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_PaisCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mPaisCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPARTAMENTOS.DEPTO_READDEPTOBYPAIS", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool UpdateDepartamento(string mDepartamentoCodigo, string mDepartamentoNombre, string mPaisCodigo, string mDepartamentoHabilitar, string mOriginalDepartamentoCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[6];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_DepartamentoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDepartamentoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DepartamentoNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mDepartamentoNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_PaisCodigo", OracleDbType.Varchar2);
        //Parametros[2].Value = mPaisCodigo;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_DepartamentoHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mDepartamentoHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_Original_DepartamentoCodigo", OracleDbType.Varchar2);
        //Parametros[4].Value = mOriginalDepartamentoCodigo;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[5].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_DEPARTAMENTOS.DEPTO_UPDATEDEPTO", Parametros);

        return true;
    }

    public DataTable GetDepartamentoByLevel()
    {
       // OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPARTAMENTOS.DEPTO_READDEPTOBYLEVEL", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetDepartamentoByTextId(string mDepartamentoCodigo, string mDepartamentoHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_DepartamentoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDepartamentoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DepartamentoHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mDepartamentoHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPARTAMENTOS.DEPTO_READDEPTOBYTEXTID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetDepartamentoByTextNombre(string mDepartamentoNombre, string mDepartamentoHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_DepartamentoNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mDepartamentoNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DepartamentoHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mDepartamentoHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPARTAMENTOS.DEPTO_READDEPTOBYTEXTNOMBRE", Parametros, true);

        return DataSet.Tables[0];
    }

    #endregion
}


