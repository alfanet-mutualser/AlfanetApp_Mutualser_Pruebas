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
/// Descripción breve de DAL_Medio
/// </summary>
public class DAL_Medio
{
	public DAL_Medio()
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


    public bool CrearMedio(string mMedioCodigo, string mMedioNombre, string mMedioCodigoPadre, string mMedioHabilitar, string mMedioPermiso)
    {
        //OracleParameter[] Parametros = new OracleParameter[6];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_MedioCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mMedioCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_MedioNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mMedioNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_MedioCodigoPadre", OracleDbType.Varchar2);
        //Parametros[2].Value = mMedioCodigoPadre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_MedioHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mMedioHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_MedioPermiso", OracleDbType.Varchar2);
        //Parametros[4].Value = mMedioPermiso;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[5].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_MEDIO.MEDIO_CREATEMEDIO", Parametros);

        return true;
    }

    public bool DeleteMedio(string mMedioCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_MedioCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mMedioCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_MEDIO.MEDIO_DELETEMEDIO", Parametros);

        return true;
    }

    public DataTable ReadExisteMedio(string mMedioCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_MedioCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mMedioCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_MEDIO.MEDIO_READEXISTEMEDIO", Parametros, true);

        return DataSet.Tables[0];

    }

    public DataTable ReadMedio()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_MEDIO.MEDIO_READMEDIO", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadMedioById(string mMedioCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_MedioCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mMedioCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_MEDIO.MEDIO_READMEDIOBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool UpdateMedio(string mMedioCodigo, string mMedioNombre, string mMedioCodigoPadre, string mMedioHabilitar, string mMedioPermiso, string mMedioFactor, string mOriginalMedioCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[8];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_MedioCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mMedioCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_MedioNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mMedioNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_MedioCodigoPadre", OracleDbType.Varchar2);
        //Parametros[2].Value = mMedioCodigoPadre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_MedioHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mMedioHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_MedioPermiso", OracleDbType.Varchar2);
        //Parametros[4].Value = mMedioPermiso;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_MedioFactor", OracleDbType.Varchar2);
        //Parametros[5].Value = mMedioFactor;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_Original_MedioCodigo", OracleDbType.Varchar2);
        //Parametros[6].Value = mOriginalMedioCodigo;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[7].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_MEDIO.MEDIO_UPDATEMEDIO", Parametros);

        return true;
    }

    public DataTable ReadMedioByText(string mMedioNombre, string mMedioHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_MedioNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mMedioNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_MedioHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mMedioHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_MEDIO.MEDIO_READMEDIOBYTEXT", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable MedioByTextId(string mMedioCodigo, string mMedioHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_MedioCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mMedioCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_MedioHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mMedioHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_MEDIO.MEDIO_READMEDIOBYTEXTID", Parametros, true);

        return DataSet.Tables[0];
    }
  

    #endregion



}
