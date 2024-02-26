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
/// Descripción breve de DAL_Naturaleza
/// </summary>
public class DAL_Naturaleza
{
	public DAL_Naturaleza()
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


    public bool CrearNaturaleza(string mNaturalezaCodigo, string mNaturalezaNombre, string mNaturalezaCodigoPadre, int mNaturalezaDiasVence, string mNaturalezaHabilitar, string mNaturalezaPermiso, string mNaturalezaPQR, string mNaturalezaDependenciaPQR)
    {
        //OracleParameter[] Parametros = new OracleParameter[9];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturalezaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_NaturalezaNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mNaturalezaNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_NaturalezaCodigoPadre", OracleDbType.Varchar2);
        //Parametros[2].Value = mNaturalezaCodigoPadre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_NaturalezaDiasVence", OracleDbType.Varchar2);
        //Parametros[3].Value = mNaturalezaDiasVence;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_NaturalezaHabilitar", OracleDbType.Varchar2);
        //Parametros[4].Value = mNaturalezaHabilitar;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_Naturalezapermiso", OracleDbType.Varchar2);
        //Parametros[5].Value = mNaturalezaPermiso;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_NaturalezaPQR", OracleDbType.Varchar2);
        //Parametros[6].Value = mNaturalezaPQR;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@v_NaturalezaDependenciaPQR", OracleDbType.Varchar2);
        //Parametros[7].Value = mNaturalezaDependenciaPQR;
        //Parametros[7].Direction = ParameterDirection.Input;

        //Parametros[8] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[8].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_NATURALEZA.NATURALEZA_CREATENATURALEZA", Parametros);

        return true;
    }

    public bool DeleteNaturaleza(string mNaturalezaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturalezaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_NATURALEZA.NATURALEZA_DELETENATURALEZA", Parametros);

        return true;
    }

    public DataTable GetNaturaleza()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_4", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_NATURALEZA.NATURALEZA_READNATURALEZA", Parametros, true);

        return DataSet.Tables[0];
    }


    public DataTable GetNaturalezaById(string mNaturalezaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturalezaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_NATURALEZA.NATURALEZA_READNATURALEZABYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetNaturalezaByPQR()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[1] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_NATURALEZA.NATURALEZA_READNATURALEZABYPQR", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetNaturalezaByTextPQR(string mNaturalezaNombre, string mNaturalezaHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_NaturalezaNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturalezaNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_NaturalezaHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mNaturalezaHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_NATURALEZA.NATURALEZA_READNATURABYTEXTPQR", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetNaturalezaTextById(string mNaturaleza, string mNaturalezaHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_Naturaleza", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturaleza;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_NaturalezaHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mNaturalezaHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_NATURALEZA.NATURALEZA_READNATURATEXTBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool UpdateNaturaleza(string mNaturalezaNombre, string mNaturalezaCodigoPadre, int mNaturalezaDiasVence, string mNaturalezaHabilitar, string mNaturalezaPermiso, string mNaturalezaPQR, string mNaturalezaDependenciaPQR, string mOriginalNaturalezaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[9];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_NaturalezaNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturalezaNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_NaturalezaCodigoPadre", OracleDbType.Varchar2);
        //Parametros[1].Value = mNaturalezaCodigoPadre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_NaturalezaDiasVence", OracleDbType.Varchar2);
        //Parametros[2].Value = mNaturalezaDiasVence;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_NaturalezaHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mNaturalezaHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_NaturalezaPermiso", OracleDbType.Varchar2);
        //Parametros[4].Value = mNaturalezaPermiso;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_NaturalezaPQR", OracleDbType.Varchar2);
        //Parametros[5].Value = mNaturalezaPQR;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_NaturalezaDependenciaPQR", OracleDbType.Varchar2);
        //Parametros[6].Value = mNaturalezaDependenciaPQR;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@v_Original_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[7].Value = mOriginalNaturalezaCodigo;
        //Parametros[7].Direction = ParameterDirection.Input;

        //Parametros[8] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[8].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_NATURALEZA.NATURALEZA_UPDATENATURALEZA", Parametros);

        return true;
    }

    public bool CrearPermisoNaturaleza(string mNaturalezaCodigo, string mDependenciaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturalezaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_NATURALEZA.NATURAPERM_CREATENATURAPERM", Parametros);

        return true;
    }

    public bool DeleteNaturalezaPerm(string mOriginalNaturalezaCodigo, string mOriginalDependenciaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mOriginalNaturalezaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[0] = new OracleParameter("@v_Original_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mOriginalDependenciaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_NATURALEZA.NATURAPERM_DELETENATURAPERM", Parametros);

        return true;
    }

    public DataTable GetNaturalezaPermiso()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_3", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_NATURALEZA.NATURAPERM_READNATURALPERM", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetNaturalezaPermisoById(string mNaturalezaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturalezaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_4", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_NATURALEZA.NATURAPERM_READNATURAPERMBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool UpdateNaturalezaPermiso(string mNaturalezaCodigo, string mDependenciaCodigo, string mOriginalNaturalezaCodigo, string mOriginalDependenciaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[5];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturalezaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_Original_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[2].Value = mOriginalNaturalezaCodigo;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_Original_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[3].Value = mOriginalDependenciaCodigo;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@cv_5", OracleDbType.RefCursor);
        //Parametros[4].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_NATURALEZA.NATURAPERM_UPDATENATURAPERM", Parametros);

        return true;
    }
    
    public DataTable GetNaturalezaByTextNombre(string mNaturalezaNombre, string mNaturalezaHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_NaturalezaNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturalezaNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_NaturalezaHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mNaturalezaHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_NATURALEZA.NATURALEZA_READNATURABYTEXT", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ExisteNaturaleza(string mNaturalezaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturalezaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_3", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_NATURALEZA.NATURALEZA_READEXISTEPNATURALE", Parametros, true);

        return DataSet.Tables[0];
    }

    #endregion
    

}
