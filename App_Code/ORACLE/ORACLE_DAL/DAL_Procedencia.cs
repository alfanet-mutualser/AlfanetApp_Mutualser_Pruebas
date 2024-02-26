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
/// Descripción breve de DAL_Procedencia
/// </summary>
public class DAL_Procedencia
{
	public DAL_Procedencia()
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


    public bool ProcedenCreateProceden(string mProcedenciaNUI, string mProcedenciaCodigo, string mProcedenciaNombre, string mProcedenciaNUIPadre, string mProcedenciaDireccion, string mProcedenciaTelefono1, string mProcedenciaTelefono2, string mProcedenciaFax, string mProcedenciaMail1, string mProcedenciaMail2, string mProcedenciaPaginaWeb, string mCiudadCodigo, string mProcedenciaHabilitar, string mProcedenciaPermiso)
    {
        //OracleParameter[] Parametros = new OracleParameter[15];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_ProcedenciaNUI", OracleDbType.Varchar2);
        //Parametros[0].Value = mProcedenciaNUI;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ProcedenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mProcedenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_ProcedenciaNombre", OracleDbType.Varchar2);
        //Parametros[2].Value = mProcedenciaNombre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_ProcedenciaNUIPadre", OracleDbType.Varchar2);
        //Parametros[3].Value = mProcedenciaNUIPadre;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_ProcedenciaDireccion", OracleDbType.Varchar2);
        //Parametros[4].Value = mProcedenciaDireccion;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_ProcedenciaTelefono1", OracleDbType.Varchar2);
        //Parametros[5].Value = mProcedenciaTelefono1;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_ProcedenciaTelefono2", OracleDbType.Varchar2);
        //Parametros[6].Value = mProcedenciaTelefono2;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@v_ProcedenciaFax", OracleDbType.Varchar2);
        //Parametros[7].Value = mProcedenciaFax;
        //Parametros[7].Direction = ParameterDirection.Input;

        //Parametros[8] = new OracleParameter("@v_ProcedenciaMail1", OracleDbType.Varchar2);
        //Parametros[8].Value = mProcedenciaMail1;
        //Parametros[8].Direction = ParameterDirection.Input;

        //Parametros[9] = new OracleParameter("@v_ProcedenciaMail2", OracleDbType.Varchar2);
        //Parametros[9].Value = mProcedenciaMail2;
        //Parametros[9].Direction = ParameterDirection.Input;

        //Parametros[10] = new OracleParameter("@v_ProcedenciaPaginaWeb", OracleDbType.Varchar2);
        //Parametros[10].Value = mProcedenciaPaginaWeb;
        //Parametros[10].Direction = ParameterDirection.Input;

        //Parametros[11] = new OracleParameter("@v_CiudadCodigo", OracleDbType.Varchar2);
        //Parametros[11].Value = mCiudadCodigo;
        //Parametros[11].Direction = ParameterDirection.Input;

        //Parametros[12] = new OracleParameter("@v_ProcedenciaHabilitar", OracleDbType.Varchar2);
        //Parametros[12].Value = mProcedenciaHabilitar;
        //Parametros[12].Direction = ParameterDirection.Input;

        //Parametros[13] = new OracleParameter("@v_ProcedenciaPermiso", OracleDbType.Varchar2);
        //Parametros[13].Value = mProcedenciaPermiso;
        //Parametros[13].Direction = ParameterDirection.Input;
        
        //Parametros[14] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[14].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_PROCEDENCIA.PROCEDENCIA_CREATEPROCEDENCIA", Parametros);

        return true;
    }

    public bool DeleteProcedencia(string mOriginalProcedenciaNUI)
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_ProcedenciaNUI", OracleDbType.Varchar2);
        //Parametros[0].Value = mOriginalProcedenciaNUI;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_PROCEDENCIA.PROCEDENCIA_DELETEPROCEDENCIA", Parametros);

        return true;
    }

    public DataTable ReadExisteProcedencia(string mProcedenciaNUI)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ProcedenciaNUI", OracleDbType.Varchar2);
        //Parametros[0].Value = mProcedenciaNUI;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_PROCEDENCIA.PROCEDENCIA_READEXISPROCEDEN", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadProcedencia()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_PROCEDENCIA.PROCEDENCIA_READPROCEDENCIA", Parametros, true);

        return DataSet.Tables[0];
    }


    public DataTable ReadProcedenciaById(string mProcedenciaNUI)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ProcedenciaNUI", OracleDbType.Varchar2);
        //Parametros[0].Value = mProcedenciaNUI;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_PROCEDENCIA.PROCEDENCIA_READPROCEDENBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadProcedenciaByText(string mProcedenciaNombre, string mProcedenciaHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ProcedenciaNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mProcedenciaNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ProcedenciaHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mProcedenciaHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_PROCEDENCIA.PROCEDEN_READPROCEDENBYTEXT", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadProcedenciaByTextId(string mProcedenciaNUI, string mProcedenciaHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ProcedenciaNUI", OracleDbType.Varchar2);
        //Parametros[0].Value = mProcedenciaNUI;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ProcedenciaHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mProcedenciaHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_PROCEDENCIA.PROCEDEN_READPROCEDENBYTEXTID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ProcedenciaSelectById(string mProcedenciaNUI)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ProcedenciaNUI", OracleDbType.Varchar2);
        //Parametros[0].Value = mProcedenciaNUI;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_PROCEDENCIA.PROCEDENCIA_SELECTBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ProcedenciaSelectByIdProcedencia(string mProcedenciaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ProcedenciaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mProcedenciaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_PROCEDENCIA.PROCEDENCIA_SELECTBYIDPROCEDEN", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ProcedenciaSelectProcedencia(string mProcedenciaNUI)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ProcedenciaNUI", OracleDbType.Varchar2);
        //Parametros[0].Value = mProcedenciaNUI;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_3", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_PROCEDENCIA.PROCEDENCIA_SELECTPROCED", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool ProcedenUpdateProceden(string mProcedenciaNUI, string mProcedenciaCodigo, string mProcedenciaNombre, string mProcedenciaNUIPadre, string mProcedenciaDireccion, string mProcedenciaTelefono1, string mProcedenciaTelefono2, string mProcedenciaFax, string mProcedenciaMail1, string mProcedenciaMail2, string mProcedenciaPaginaWeb, string mCiudadCodigo, string mProcedenciaHabilitar, string mProcedenciaPermiso, string mOriginalProcedenciaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[16];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_ProcedenciaNUI", OracleDbType.Varchar2);
        //Parametros[0].Value = mProcedenciaNUI;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ProcedenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mProcedenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_ProcedenciaNombre", OracleDbType.Varchar2);
        //Parametros[2].Value = mProcedenciaNombre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_ProcedenciaNUIPadre", OracleDbType.Varchar2);
        //Parametros[3].Value = mProcedenciaNUIPadre;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_ProcedenciaDireccion", OracleDbType.Varchar2);
        //Parametros[4].Value = mProcedenciaDireccion;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_ProcedenciaTelefono1", OracleDbType.Varchar2);
        //Parametros[5].Value = mProcedenciaTelefono1;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_ProcedenciaTelefono2", OracleDbType.Varchar2);
        //Parametros[6].Value = mProcedenciaTelefono2;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@v_ProcedenciaFax", OracleDbType.Varchar2);
        //Parametros[7].Value = mProcedenciaFax;
        //Parametros[7].Direction = ParameterDirection.Input;

        //Parametros[8] = new OracleParameter("@v_ProcedenciaMail1", OracleDbType.Varchar2);
        //Parametros[8].Value = mProcedenciaMail1;
        //Parametros[8].Direction = ParameterDirection.Input;

        //Parametros[9] = new OracleParameter("@v_ProcedenciaMail2", OracleDbType.Varchar2);
        //Parametros[9].Value = mProcedenciaMail2;
        //Parametros[9].Direction = ParameterDirection.Input;

        //Parametros[10] = new OracleParameter("@v_ProcedenciaPaginaWeb", OracleDbType.Varchar2);
        //Parametros[10].Value = mProcedenciaPaginaWeb;
        //Parametros[10].Direction = ParameterDirection.Input;

        //Parametros[11] = new OracleParameter("@v_CiudadCodigo", OracleDbType.Varchar2);
        //Parametros[11].Value = mCiudadCodigo;
        //Parametros[11].Direction = ParameterDirection.Input;

        //Parametros[12] = new OracleParameter("@v_ProcedenciaHabilitar", OracleDbType.Varchar2);
        //Parametros[12].Value = mProcedenciaHabilitar;
        //Parametros[12].Direction = ParameterDirection.Input;

        //Parametros[13] = new OracleParameter("@v_ProcedenciaPermiso", OracleDbType.Varchar2);
        //Parametros[13].Value = mProcedenciaPermiso;
        //Parametros[13].Direction = ParameterDirection.Input;

        //Parametros[14] = new OracleParameter("@v_Original_ProcedenciaCodigo", OracleDbType.Varchar2);
        //Parametros[14].Value = mOriginalProcedenciaCodigo;
        //Parametros[14].Direction = ParameterDirection.Input;

        //Parametros[15] = new OracleParameter("@cv_4", OracleDbType.RefCursor);
        //Parametros[15].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_PROCEDENCIA.PROCEDENCIA_UPDATEPROCEDENCIA", Parametros);

        return true;
    }

    #endregion


}
