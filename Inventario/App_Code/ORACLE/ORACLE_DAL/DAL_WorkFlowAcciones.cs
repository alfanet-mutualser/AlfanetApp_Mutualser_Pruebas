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
/// Descripción breve de DAL_WorkFlowAcciones
/// </summary>
public class DAL_WorkFlowAcciones
{
	public DAL_WorkFlowAcciones()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}


    #region Variables
    //OraDataClass oraDataClass = new OraDataClass();
    DataSet DataSet;
    #endregion

    #region Metodos

    public bool WFAccion_CreateWFAccion(string mWFAccionCodigo, string mWFAccionNombre, string mWFAccionHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[4];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_WFAccionCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mWFAccionCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_WFAccionNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mWFAccionNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_WFAccionHabilitar", OracleDbType.Varchar2);
        //Parametros[2].Value = mWFAccionHabilitar;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@cv_4", OracleDbType.RefCursor);
        //Parametros[3].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_WORKFLOW.WFACCION_CREATEWFACCION", Parametros);

        return true;
    }

    public bool WFAccion_DeleteWFAccion(string mOriginalWFAccionCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_Original_WFAccionCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mOriginalWFAccionCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;



        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_WORKFLOW.WFACCION_DELETEWFACCION", Parametros);

        return true;
    }

    public DataTable WFAccion_ReadExisteWFAccion(string mWFAccionCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();


        //Parametros[0] = new OracleParameter("@v_WFAccionCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mWFAccionCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_5", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_WORKFLOW.WFACCION_READEXISTEWFACCION", Parametros, true);

        return DataSet.Tables[0];

    }

     
    public DataTable ReadWFAccion()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_6", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_WORKFLOW.WFACCION_READWFACCION", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadWFAccionById(string mWFAccionCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_WFAccionCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mWFAccionCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_7", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_WORKFLOW.WFACCION_READWFACCIONBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadWFAccion_SelectById(string mWFAccionCodigo, string mWFAccionHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[4];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_WFAccionCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mWFAccionCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_WFAccionHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mWFAccionHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //Parametros[3] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[3].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_WORKFLOW.WFACCION_SELECTBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadWFAccion_SelectByText(string mWFAccionNombre, string mWFAccionHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[4];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_WFAccionNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mWFAccionNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_WFAccionHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mWFAccionHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //Parametros[3] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[3].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_WORKFLOW.WFACCION_SELECTBYTEXT", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool WFAccion_UpdateWFAccion(string mWFAccionNombre, string mWFAccionHabilitar, string mOriginalWFAccionCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[4];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_WFAccionNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mWFAccionNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_WFAccionHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mWFAccionHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_Original_WFAccionCodigo", OracleDbType.Varchar2);
        //Parametros[2].Value = mOriginalWFAccionCodigo;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[3].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_WORKFLOW.WFACCION_UPDATEWFACCION", Parametros);

        return true;
    }

    

    
    #endregion

}