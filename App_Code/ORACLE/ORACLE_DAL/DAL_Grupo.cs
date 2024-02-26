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
/// Descripción breve de DAL_Grupo
/// </summary>
public class DAL_Grupo
{
	public DAL_Grupo()
	{
	}

    #region Variables
    //OraDataClass oraDataClass = new OraDataClass();
    DataSet DataSet;
    #endregion

    #region Metodos

    public DataTable GetGrupo()
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@sys_refcursor", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.Varchar2);
        //Parametros[1].Direction = ParameterDirection.Output;
        //Parametros[1].Size = 4000;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_GRUPO.GRUPO_CONSULTA.", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GrupoByCodigoPadre(string mGrupoCodigo)
    {
       // OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_Grupocodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_GRUPO.GRUPO_CONSULTABYCODIGOPADRE", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool CrearGrupo(string mGrupoCodigo, string mGrupoNombre, string mGrupoCodigoPadre, int mGrupoConsecutivo, string mGrupoHabilitar, string mGrupoPermiso)
    {
        //OracleParameter[] Parametros = new OracleParameter[7];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_GrupoNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mGrupoNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_GrupoCodigoPadre", OracleDbType.Varchar2);
        //Parametros[2].Value = mGrupoCodigoPadre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_GrupoConsecutivo", OracleDbType.Decimal);
        //Parametros[3].Value = mGrupoConsecutivo;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_GrupoHabilitar", OracleDbType.Varchar2);
        //Parametros[4].Value = mGrupoHabilitar;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_GrupoPermiso", OracleDbType.Varchar2);
        //Parametros[5].Value = mGrupoPermiso;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[6].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_GRUPO.GRUPO_CREATEGRUPO", Parametros);

        return true;
    }

    public bool DeleteGrupo(string mGrupoCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_GRUPO.GRUPO_DELETEGRUPO", Parametros);

        return true;
    }

    public DataTable LeerGrupo()
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.Varchar2);
        //Parametros[1].Direction = ParameterDirection.Output;
        //Parametros[1].Size = 4000;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_GRUPO.GRUPO_READGRUPO.", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetGrupoById(string mGrupoCodigo)
    {
       // OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;
        ////Parametros[1].Size = 4000;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_GRUPO.GRUPO_READGRUPOBYID", Parametros, true);

        return DataSet.Tables[0];
     
    }

    public DataTable GetGrupoByText(string mGrupoNombre, string mGrupoHabilitar)
    {
       // OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_GrupoNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupoNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_GrupoHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mGrupoHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;
        //Parametros[2].Size = 4000;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_GRUPO.GRUPO_READGRUPOBYTEXT", Parametros, true);
        return DataSet.Tables[0];
    }

    public DataTable GetGrupoByTextId(string mGrupoCodigo, string mGrupoHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[0] = new OracleParameter("@v_GrupoHabilitar", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupoHabilitar;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;
        //Parametros[1].Size = 4000;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_GRUPO.GRUPO_READGRUPOBYTEXTID", Parametros, true);
        return DataSet.Tables[0];
    }

    public bool UpdateGrupo(string mGrupoNombre, string mGrupoCodigoPadre, string mGrupoConsecutivo, string mGrupoHabilitar, string mGrupoPermiso, string mGrupoCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[7];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        

        //Parametros[0] = new OracleParameter("@v_GrupoNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mGrupoNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_GrupoCodigoPadre", OracleDbType.Varchar2);
        //Parametros[1].Value = mGrupoCodigoPadre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_GrupoConsecutivo", OracleDbType.Varchar2);
        //Parametros[2].Value = mGrupoConsecutivo;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_GrupoHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mGrupoHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_GrupoPermiso", OracleDbType.Varchar2);
        //Parametros[4].Value = mGrupoPermiso;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_Original_GrupoCodigo", OracleDbType.Varchar2);
        //Parametros[5].Value = mGrupoCodigo;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[6].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_GRUPO.GRUPO_UPDATEGRUPO", Parametros);

        return true;
    }

    

    #endregion
}
