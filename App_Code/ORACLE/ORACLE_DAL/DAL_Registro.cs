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
/// Descripción breve de DAL_Registro
/// </summary>
public class DAL_Registro
{
	public DAL_Registro()
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


    public DataTable RegistroConsultaHistorico(string mRegistroCodigo, string mGrupoCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[4];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mRegistroCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mGrupoCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //Parametros[3] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[3].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_REGISTRO.REGISTRO_CONSULTASHISTORICO", Parametros, true);

        return DataSet.Tables[0];
    }


    public bool RegistroconsultasRegistro(string mRegistroTipo, string mWFMovimientoFecha, 
        string mWFMovimientoFecha1, string mRegistroCodigo, 
        string mRegistroCodigo1, string mExpedienteCodigo, string mProcedenciaCodigo, 
        string mMedioCodigo, string mDependenciaCodigo, string mRemiteNombre, 
        string mDependenciaCodDestino, string mDestinoNombre, string mRegistroDetalle,
        string mAnexoExtRegistro, string mNaturalezaCodigo, string mNaturalezaNombre,
        string mSerieCodigo, string mDependenciaConsulta)
    {
        //OracleParameter[] Parametros = new OracleParameter[19];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_RegistroTipo", OracleDbType.Varchar2);
        //Parametros[0].Value = mRegistroTipo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_WFMovimientoFecha", OracleDbType.Varchar2);
        //Parametros[1].Value = mWFMovimientoFecha;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_WFMovimientoFecha1", OracleDbType.Varchar2);
        //Parametros[2].Value = mWFMovimientoFecha1;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[3].Value = mRegistroCodigo;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_RegistroCodigo1", OracleDbType.Varchar2);
        //Parametros[4].Value = mRegistroCodigo1;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[5].Value = mExpedienteCodigo;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_ProcedenciaCodigo", OracleDbType.Varchar2);
        //Parametros[6].Value = mProcedenciaCodigo;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@v_MedioCodigo", OracleDbType.Varchar2);
        //Parametros[7].Value = mMedioCodigo;
        //Parametros[7].Direction = ParameterDirection.Input;

        //Parametros[8] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[8].Value = mDependenciaCodigo;
        //Parametros[8].Direction = ParameterDirection.Input;

        //Parametros[9] = new OracleParameter("@v_RemiteNombre", OracleDbType.Varchar2);
        //Parametros[9].Value = mRemiteNombre;
        //Parametros[9].Direction = ParameterDirection.Input;

        //Parametros[10] = new OracleParameter("@v_DependenciaCodDestino", OracleDbType.Varchar2);
        //Parametros[10].Value = mDependenciaCodDestino;
        //Parametros[10].Direction = ParameterDirection.Input;

        //Parametros[11] = new OracleParameter("@v_DestinoNombre", OracleDbType.Varchar2);
        //Parametros[11].Value = mDestinoNombre;
        //Parametros[11].Direction = ParameterDirection.Input;

        //Parametros[12] = new OracleParameter("@v_RegistroDetalle", OracleDbType.Varchar2);
        //Parametros[12].Value = mRegistroDetalle;
        //Parametros[12].Direction = ParameterDirection.Input;

        //Parametros[13] = new OracleParameter("@v_AnexoExtRegistro", OracleDbType.Varchar2);
        //Parametros[13].Value = mAnexoExtRegistro;
        //Parametros[13].Direction = ParameterDirection.Input;

        //Parametros[14] = new OracleParameter("@v_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[14].Value = mNaturalezaCodigo;
        //Parametros[14].Direction = ParameterDirection.Input;

        //Parametros[15] = new OracleParameter("@v_NaturalezaNombre", OracleDbType.Varchar2);
        //Parametros[15].Value = mNaturalezaNombre;
        //Parametros[15].Direction = ParameterDirection.Input;

        //Parametros[16] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
        //Parametros[16].Value = mSerieCodigo;
        //Parametros[16].Direction = ParameterDirection.Input;

        //Parametros[17] = new OracleParameter("@v_DependenciaConsulta", OracleDbType.Varchar2);
        //Parametros[17].Value = mDependenciaConsulta;
        //Parametros[17].Direction = ParameterDirection.Input;

        //Parametros[18] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[18].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_REGISTRO.REGISTRO_CONSULTASREGISTRO", Parametros);

        return true;
    }

    public bool RegistroconsultasRegistroDina()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_REGISTRO.REGISTRO_CONSULTASREGISTRODINA", Parametros);

        return true;
    }

    public bool RegistroCopiasRegistro(string mRegistroCodigo, string mGrupoCodigo, 
        string mWFMovimientoFecha, string mProcedenciaCodDestino, string mDependenciaCodDestino,
        string mDependenciaCodigo, string mSerieCodigo, string mWFAccionCodigo,
        string mWFMovimientoFechaEst, string mWFMovimientoFechaFin, string mWFMovimientoTipo,
        string mWFMovimientoNotas, string mWFMovimientoMultitarea)
    {
        //OracleParameter[] Parametros = new OracleParameter[14];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mRegistroCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mGrupoCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_WFMovimientoFecha", OracleDbType.Varchar2);
        //Parametros[2].Value = mWFMovimientoFecha;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_ProcedenciaCodDestino", OracleDbType.Varchar2);
        //Parametros[3].Value = mProcedenciaCodDestino;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_DependenciaCodDestino", OracleDbType.Varchar2);
        //Parametros[4].Value = mDependenciaCodDestino;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[5].Value = mDependenciaCodigo;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
        //Parametros[6].Value = mSerieCodigo;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@v_WFAccionCodigo", OracleDbType.Varchar2);
        //Parametros[7].Value = mWFAccionCodigo;
        //Parametros[7].Direction = ParameterDirection.Input;

        //Parametros[8] = new OracleParameter("@v_WFMovimientoFechaEst", OracleDbType.Varchar2);
        //Parametros[8].Value = mWFMovimientoFechaEst;
        //Parametros[8].Direction = ParameterDirection.Input;

        //Parametros[9] = new OracleParameter("@v_WFMovimientoFechaFin", OracleDbType.Varchar2);
        //Parametros[9].Value = mWFMovimientoFechaFin;
        //Parametros[9].Direction = ParameterDirection.Input;

        //Parametros[10] = new OracleParameter("@v_WFMovimientoTipo", OracleDbType.Varchar2);
        //Parametros[10].Value = mWFMovimientoTipo;
        //Parametros[10].Direction = ParameterDirection.Input;

        //Parametros[11] = new OracleParameter("@v_WFMovimientoNotas", OracleDbType.Varchar2);
        //Parametros[11].Value = mWFMovimientoNotas;
        //Parametros[11].Direction = ParameterDirection.Input;

        //Parametros[12] = new OracleParameter("@v_WFMovimientoMultitarea", OracleDbType.Varchar2);
        //Parametros[12].Value = mWFMovimientoMultitarea;
        //Parametros[12].Direction = ParameterDirection.Input;

        //Parametros[13] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[13].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_REGISTRO.REGISTRO_COPIASREGISTRO", Parametros);

        return true;
    }


    public string RegistroCreateRegistro(string mRegistroCodigo, string mGrupoCodigo,
        DateTime mWFMovimientoFecha, string mProcedenciaCodDestino, string mDependenciaCodDestino,
        string mDependenciaCodigo, string mNaturalezaCodigo, int mRadicadoCodigo,
        string mRegistroDetalle, string mRegistroGuia, string mRegistroEmpGuia, string mAnexoExtRegistro,
        string mLogDigitador, string mExpedienteCodigo, string mMedioCodigo, string mSerieCodigo,
        string mRegPesoEnvio, string mRegValorEnvio, string mRegistroTipo, string mWFAccionCodigo,
        DateTime mWFMovimientoFechaEst, DateTime mWFMovimientoFechaFin, int mWFMovimientoTipo,
        string mWFMovimientoNotas, string mWFMovimientoMultitarea)
    {
  
        //OracleParameter[] Parametros = new OracleParameter[26];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mRegistroCodigo;
        //Parametros[0].Direction = ParameterDirection.Output;

        //Parametros[1] = new OracleParameter("@v_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mGrupoCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_WFMovimientoFecha", OracleDbType.Date);
        //Parametros[2].Value = mWFMovimientoFecha;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_ProcedenciaCodDestino", OracleDbType.Varchar2);
        //Parametros[3].Value = mProcedenciaCodDestino;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_DependenciaCodDestino", OracleDbType.Varchar2);
        //Parametros[4].Value = mDependenciaCodDestino;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[5].Value = mDependenciaCodigo;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[6].Value = mNaturalezaCodigo;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@v_RadicadoCodigo", OracleDbType.Varchar2);
        //Parametros[7].Value = mRadicadoCodigo;
        //Parametros[7].Direction = ParameterDirection.Input;

        //Parametros[8] = new OracleParameter("@v_RegistroDetalle", OracleDbType.Varchar2);
        //Parametros[8].Value = mRegistroDetalle;
        //Parametros[8].Direction = ParameterDirection.Input;

        //Parametros[9] = new OracleParameter("@v_RegistroGuia", OracleDbType.Varchar2);
        //Parametros[9].Value = mRegistroGuia;
        //Parametros[9].Direction = ParameterDirection.Input;

        //Parametros[10] = new OracleParameter("@v_RegistroEmpGuia", OracleDbType.Varchar2);
        //Parametros[10].Value = mRegistroEmpGuia;
        //Parametros[10].Direction = ParameterDirection.Input;

        //Parametros[11] = new OracleParameter("@v_AnexoExtRegistro", OracleDbType.Varchar2);
        //Parametros[11].Value = mAnexoExtRegistro;
        //Parametros[11].Direction = ParameterDirection.Input;

        //Parametros[12] = new OracleParameter("@v_LogDigitador", OracleDbType.Varchar2);
        //Parametros[12].Value = mLogDigitador;
        //Parametros[12].Direction = ParameterDirection.Input;

        //Parametros[13] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[13].Value = mExpedienteCodigo;
        //Parametros[13].Direction = ParameterDirection.Input;

        //Parametros[14] = new OracleParameter("@v_MedioCodigo", OracleDbType.Varchar2);
        //Parametros[14].Value = mMedioCodigo;
        //Parametros[14].Direction = ParameterDirection.Input;

        //Parametros[15] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
        //Parametros[15].Value = mSerieCodigo;
        //Parametros[15].Direction = ParameterDirection.Input;

        //Parametros[16] = new OracleParameter("@v_RegPesoEnvio", OracleDbType.Varchar2);
        //Parametros[16].Value = mRegPesoEnvio;
        //Parametros[16].Direction = ParameterDirection.Input;

        //Parametros[17] = new OracleParameter("@v_RegValorEnvio", OracleDbType.Varchar2);
        //Parametros[17].Value = mRegValorEnvio;
        //Parametros[17].Direction = ParameterDirection.Input;

        //Parametros[18] = new OracleParameter("@v_RegistroTipo", OracleDbType.Varchar2);
        //Parametros[18].Value = mRegistroTipo;
        //Parametros[18].Direction = ParameterDirection.Input;

        //Parametros[19] = new OracleParameter("@v_WFAccionCodigo", OracleDbType.Varchar2);
        //Parametros[19].Value = mWFAccionCodigo;
        //Parametros[19].Direction = ParameterDirection.Input;

        //Parametros[20] = new OracleParameter("@v_WFMovimientoFechaEst", OracleDbType.Date);
        //Parametros[20].Value = mWFMovimientoFechaEst;
        //Parametros[20].Direction = ParameterDirection.Input;

        //Parametros[21] = new OracleParameter("@v_WFMovimientoFechaFin", OracleDbType.Date);
        //Parametros[21].Value = mWFMovimientoFechaFin;
        //Parametros[21].Direction = ParameterDirection.Input;

        //Parametros[22] = new OracleParameter("@v_WFMovimientoTipo", OracleDbType.Varchar2);
        //Parametros[22].Value = mWFMovimientoTipo;
        //Parametros[22].Direction = ParameterDirection.Input;

        //Parametros[23] = new OracleParameter("@v_WFMovimientoNotas", OracleDbType.Varchar2);
        //Parametros[23].Value = mWFMovimientoNotas;
        //Parametros[23].Direction = ParameterDirection.Input;

        //Parametros[24] = new OracleParameter("@v_WFMovimientoMultitarea", OracleDbType.Varchar2);
        //Parametros[24].Value = mWFMovimientoMultitarea;
        //Parametros[24].Direction = ParameterDirection.Input;

        //Parametros[25] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[25].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_REGISTRO.REGISTRO_CREATEREGISTRO", Parametros);

        return null;
    }

    public DataTable RegistroReadReg(string mGrupo, string mRegistroCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[4];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_grupo", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mRegistroCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;
        
        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //Parametros[3] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[3].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_REGISTRO.REGISTRO_READREG", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable RegistroReadRegistroByGrupo(string mGrupo)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_grupo", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //Parametros[2] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_REGISTRO.REGISTRO_READREG", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable RegistroReadRegistro(string mGrupo, string mRegistroCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[4];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_grupo", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mRegistroCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //Parametros[3] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[3].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_REGISTRO.REGISTRO_READREGISTRO", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable RegistroSelectImMaxFolioById(string mRegistroCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[4];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mRegistroCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_REGISTRO.REGISTRO_SELECTIMMAXFOLIOBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool RegistroUpdateRegistro(string mRegistroCodigo, string mWFMovimientoFecha, 
        string mProcedenciaCodDestino, string mDependenciaCodDestino,
        string mDependenciaCodigo, string mNaturalezaCodigo, string mRadicadoCodigo,
        string mRegistroDetalle, string mRegistroGuia, string mRegistroEmpGuia, string mAnexoExtRegistro,
        string mLogDigitador, string mExpedienteCodigo, string mMedioCodigo, string mSerieCodigo,
        string mRegPesoEnvio, string mRegValorEnvio, string mRegistroTipo, string mOriginalRegistroCodigo,
        string mOriginalGrupoCodigo, string mGrupoCodigo, string mCodigoMotDevolucion,
        string mFechaMotDevolucion)
    {

        //OracleParameter[] Parametros = new OracleParameter[25];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mRegistroCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_WFMovimientoFecha", OracleDbType.Varchar2);
        //Parametros[1].Value = mWFMovimientoFecha;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_ProcedenciaCodDestino", OracleDbType.Varchar2);
        //Parametros[2].Value = mProcedenciaCodDestino;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_DependenciaCodDestino", OracleDbType.Varchar2);
        //Parametros[3].Value = mDependenciaCodDestino;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[4].Value = mDependenciaCodigo;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[5].Value = mNaturalezaCodigo;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_RadicadoCodigo", OracleDbType.Varchar2);
        //Parametros[6].Value = mRadicadoCodigo;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@v_RegistroDetalle", OracleDbType.Varchar2);
        //Parametros[7].Value = mRegistroDetalle;
        //Parametros[7].Direction = ParameterDirection.Input;

        //Parametros[8] = new OracleParameter("@v_RegistroGuia", OracleDbType.Varchar2);
        //Parametros[8].Value = mRegistroGuia;
        //Parametros[8].Direction = ParameterDirection.Input;

        //Parametros[9] = new OracleParameter("@v_RegistroEmpGuia", OracleDbType.Varchar2);
        //Parametros[9].Value = mRegistroEmpGuia;
        //Parametros[9].Direction = ParameterDirection.Input;

        //Parametros[10] = new OracleParameter("@v_AnexoExtRegistro", OracleDbType.Varchar2);
        //Parametros[10].Value = mAnexoExtRegistro;
        //Parametros[10].Direction = ParameterDirection.Input;

        //Parametros[11] = new OracleParameter("@v_LogDigitador", OracleDbType.Varchar2);
        //Parametros[11].Value = mLogDigitador;
        //Parametros[11].Direction = ParameterDirection.Input;

        //Parametros[12] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[12].Value = mExpedienteCodigo;
        //Parametros[12].Direction = ParameterDirection.Input;

        //Parametros[13] = new OracleParameter("@v_MedioCodigo", OracleDbType.Varchar2);
        //Parametros[13].Value = mMedioCodigo;
        //Parametros[13].Direction = ParameterDirection.Input;

        //Parametros[14] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
        //Parametros[14].Value = mSerieCodigo;
        //Parametros[14].Direction = ParameterDirection.Input;

        //Parametros[15] = new OracleParameter("@v_RegPesoEnvio", OracleDbType.Varchar2);
        //Parametros[15].Value = mRegPesoEnvio;
        //Parametros[15].Direction = ParameterDirection.Input;

        //Parametros[16] = new OracleParameter("@v_RegValorEnvio", OracleDbType.Varchar2);
        //Parametros[16].Value = mRegValorEnvio;
        //Parametros[16].Direction = ParameterDirection.Input;

        //Parametros[17] = new OracleParameter("@v_RegistroTipo", OracleDbType.Varchar2);
        //Parametros[17].Value = mRegistroTipo;
        //Parametros[17].Direction = ParameterDirection.Input;

        //Parametros[18] = new OracleParameter("@v_Original_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[18].Value = mOriginalRegistroCodigo;
        //Parametros[18].Direction = ParameterDirection.Input;

        //Parametros[19] = new OracleParameter("@v_Original_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[19].Value = mOriginalGrupoCodigo;
        //Parametros[19].Direction = ParameterDirection.Input;

        //Parametros[20] = new OracleParameter("@v_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[20].Value = mGrupoCodigo;
        //Parametros[20].Direction = ParameterDirection.Input;

        //Parametros[21] = new OracleParameter("@v_CodigoMotDevolucion", OracleDbType.Varchar2);
        //Parametros[21].Value = mCodigoMotDevolucion;
        //Parametros[21].Direction = ParameterDirection.Input;

        //Parametros[22] = new OracleParameter("@v_FechaMotDevolucion", OracleDbType.Varchar2);
        //Parametros[22].Value = mFechaMotDevolucion;
        //Parametros[22].Direction = ParameterDirection.Input;

        //Parametros[23] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[23].Direction = ParameterDirection.Output;
        
        //Parametros[24] = new OracleParameter("@cv_3", OracleDbType.RefCursor);
        //Parametros[24].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_REGISTRO.REGISTRO_UPDATEREGISTRO", Parametros);

        return true;
    }

    public bool RegistroImagenDelete(string mOriginalGrupoCodigo, string mOriginalRegistroCodigo,
                                     string mOriginalRegistroImagenFolio)
    {

        //OracleParameter[] Parametros = new OracleParameter[25];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mOriginalGrupoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_Original_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mOriginalRegistroCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_Original_RegistroImagenFolio", OracleDbType.Varchar2);
        //Parametros[2].Value = mOriginalRegistroImagenFolio;
        //Parametros[2].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_REGISTRO.REGISTROIMAGEN_DELETE", Parametros);

        return true;
    }


    public bool RegistroImagenInsert(string mGrupoCodigo, string mRegistroCodigo, string mRegistroImagenNombre,
                                     string mImagenRutaCodigo)
    {

        //OracleParameter[] Parametros = new OracleParameter[5];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mRegistroCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_RegistroImagenNombre", OracleDbType.Varchar2);
        //Parametros[2].Value = mRegistroImagenNombre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_ImagenRutaCodigo", OracleDbType.Varchar2);
        //Parametros[3].Value = mImagenRutaCodigo;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[4].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_REGISTRO.REGISTROIMAGEN_INSERT", Parametros);

        return true;
    }

    public bool RegistroImagenSelect()
    {

        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_REGISTRO.REGISTROIMAGEN_SELECT", Parametros);

        return true;
    }

    public bool RegistroImagenSelect(string mGrupoRegistroCodigo, string mRegistroCodigo)
    {

        //OracleParameter[] Parametros = new OracleParameter[3];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_GrupoRegistroCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupoRegistroCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mRegistroCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_3", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_REGISTRO.REGISTROIMAGEN_SELECTBYID", Parametros);

        return true;
    }

    public bool RegistroImagenUpdate(string mRegistroCodigo, string mRegistroImagenNombre,
        string mImagenRutaCodigo, string mRegistroImagenFolio, string mOriginalRegistroCodigo,
        string mOriginalRegistroImagenFolio)
    {

        //OracleParameter[] Parametros = new OracleParameter[7];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mRegistroCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_RegistroImagenNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mRegistroImagenNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_ImagenRutaCodigo", OracleDbType.Varchar2);
        //Parametros[2].Value = mImagenRutaCodigo;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_RegistroImagenFolio", OracleDbType.Varchar2);
        //Parametros[3].Value = mRegistroImagenFolio;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_Original_RegistroCodigo", OracleDbType.Varchar2);
        //Parametros[4].Value = mOriginalRegistroCodigo;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_Original_RegistroImagenFolio", OracleDbType.Varchar2);
        //Parametros[5].Value = mOriginalRegistroImagenFolio;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@cv_4", OracleDbType.RefCursor);
        //Parametros[6].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_REGISTRO.REGISTROIMAGEN_UPDATE", Parametros);

        return true;
    }

    #endregion

}
