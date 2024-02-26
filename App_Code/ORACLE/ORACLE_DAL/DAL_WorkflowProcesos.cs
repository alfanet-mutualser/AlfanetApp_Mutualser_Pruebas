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
/// Descripción breve de DAL_WorkflowProcesos
/// </summary>
public class DAL_WorkflowProcesos
{
	public DAL_WorkflowProcesos()
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


    public bool CrearProceso(string mProcesoCodigo, string mProcesoDescripcion, string mProcesoHabilitar, string mProcesoCodigoPadre)
    {
        //OracleParameter[] Parametros = new OracleParameter[5];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_WFProcesoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mProcesoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_WFProcesoDescripcion", OracleDbType.Varchar2);
        //Parametros[1].Value = mProcesoDescripcion;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_WFProcesoHabilitar", OracleDbType.Varchar2);
        //Parametros[2].Value = mProcesoHabilitar;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_WFProcesoCodigoPadre", OracleDbType.Varchar2);
        //Parametros[3].Value = mProcesoCodigoPadre;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[4].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_PROCESO.CREATEPROCESO", Parametros);

        return true;
    }

    public bool CrearProcesoDetalle(string mWFProcesoCodigo, string mWFDependenciaCodigo, string mWFProcesoDetallePaso, string mSerieCodigo, string mWFSubProcesoCodigo, string mWFProcesoDetalleTiempo, string mWFAccionCodigo, string mWFActividadCodigo, string mWFPlantillaCodigo, string mWFProcesoDetalleHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[11];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_WFProcesoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mWFProcesoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mWFDependenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_WFProcesoDetallePaso", OracleDbType.Varchar2);
        //Parametros[2].Value = mWFProcesoDetallePaso;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
        //Parametros[3].Value = mSerieCodigo;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_WFSubProcesoCodigo", OracleDbType.Varchar2);
        //Parametros[4].Value = mWFSubProcesoCodigo;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_WFProcesoDetalleTiempo", OracleDbType.Varchar2);
        //Parametros[5].Value = mWFProcesoDetalleTiempo;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_WFAccionCodigo", OracleDbType.Varchar2);
        //Parametros[6].Value = mWFAccionCodigo;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@v_WFActividadCodigo", OracleDbType.Varchar2);
        //Parametros[7].Value = mWFActividadCodigo;
        //Parametros[7].Direction = ParameterDirection.Input;

        //Parametros[8] = new OracleParameter("@v_PlantillaCodigo", OracleDbType.Varchar2);
        //Parametros[8].Value = mWFPlantillaCodigo;
        //Parametros[8].Direction = ParameterDirection.Input;

        //Parametros[9] = new OracleParameter("@v_WFProcesoDetalleHabilitar", OracleDbType.Varchar2);
        //Parametros[9].Value = mWFProcesoDetalleHabilitar;
        //Parametros[9].Direction = ParameterDirection.Input;

        //Parametros[10] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[10].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_PROCESO.CREATEPROCESODETALLE", Parametros);

        return true;
    }


    public bool DeleteProceso(string mOriginalProcesoCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_ProcesoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mOriginalProcesoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_PROCESO.DELETEPROCESO", Parametros);

        return true;
    }

    public bool DeleteProcesoDetalle(string mOriginalProcesoCodigo, string mOriginalProcesoDetallePaso)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_ProcesoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mOriginalProcesoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_Original_WFProcesoDetallePas", OracleDbType.Varchar2);
        //Parametros[1].Value = mOriginalProcesoDetallePaso;
        //Parametros[1].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_PROCESO.DELETEPROCESODETALLE", Parametros);

        return true;
    }

    #endregion
}
