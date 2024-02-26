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
/// Descripción breve de DAL_Dependencia
/// </summary>
public class DAL_Dependencia
{
	
		public DAL_Dependencia()
	    {
        }

    #region Variables
    //OraDataClass oraDataClass = new OraDataClass();
    DataSet DataSet;
    #endregion

    #region Metodos


    public bool DependenCreateDependen(string mDependenciaCodigo, string mDependenciaNombre, string mDependenciaCodigoPadre, string mDependenciaHabilitar, string mDependenciaPermiso)
    {
        //OracleParameter[] Parametros = new OracleParameter[6];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDependenciaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_DependenciaCodigoPadre", OracleDbType.Varchar2);
        //Parametros[2].Value = mDependenciaCodigoPadre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_DependenciaHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mDependenciaHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_DependenciaPermiso", OracleDbType.Varchar2);
        //Parametros[4].Value = mDependenciaPermiso;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[5].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDEN_CREATEDEPENDEN", Parametros);

        return true;
    }

    public bool DeleteDependencia(string mDependenciaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDependenciaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDEN_DELETEDEPENDEN", Parametros);

        return true;
    }

    public DataTable GetDependencia()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;
        
        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDEN_READDEPENDEN", Parametros, true);

        return DataSet.Tables[0];
    }


    public DataTable GetDependenciaById(string mDependenciaCodigo)
    {
       // OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDependenciaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDEN_READDEPENDENBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable GetDependenciaBynaturaleza(string mNaturalezaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_NaturalezaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mNaturalezaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDEN.DEPENDEN_READDEPENDENBYNATURAL", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadDependenciaPermisos()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDEN_READDEPENDENPERMISOS", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadExisteDependencia(string mDependenciaCodigo)
    {
       // OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDependenciaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDEN_READEXISTEDEPENDEN", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool UpdateDependencia(string mDependenciaNombre, string mDependenciaCodigoPadre, string mDependenciaHabilitar, string mDependenciaPermiso,  string mOriginalDependenciaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[6];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_DependenciaNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mDependenciaNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaCodigoPadre", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaCodigoPadre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_DependenciaHabilitar", OracleDbType.Varchar2);
        //Parametros[2].Value = mDependenciaHabilitar;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_DependenciaPermiso", OracleDbType.Varchar2);
        //Parametros[3].Value = mDependenciaPermiso;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_Original_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[4].Value = mOriginalDependenciaCodigo;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[5].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDEN_UPDATEDEPENDEN", Parametros);

        return true;
    }

    public bool UpdateDependenciaPermiso(string mDependenciaCodigo, string mDependenciaPermiso)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDependenciaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaPermiso", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaPermiso;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDEN_UPDATEDEPENDENPERMISO", Parametros);

        return true;
    }

    public bool InsertDependenciaPermiso(string mDependenciaPermisoCodigo, string mDependenciaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_DependenciaPermisoCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDependenciaPermisoCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDEN_INSERTPERMISO", Parametros);

        return true;
    }

    public bool DeleteDependenciaPermisos(string mOriginalDependenciaCodigo, string mOriginalDependenciaPermisoC)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mOriginalDependenciaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_Original_DependenciaPermisoC", OracleDbType.Varchar2);
        //Parametros[1].Value = mOriginalDependenciaPermisoC;
        //Parametros[1].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDEN_DELETEPERMISOS", Parametros);

        return true;
    }

    
    public DataTable ReadDependenciaPermisoById(string mDependenciaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDependenciaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDEN_READPERMISOBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadDependenciaByText(string mDependenciaNombre, string mDependenciaHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_DependenciaNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mDependenciaNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDENCIA_READDEPENBYTEXT", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadDependenciaByTextId(string mDependenciaCodigo, string mDependenciaHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mDependenciaCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDENCIAS.DEPENDENCIA_READDEPENBYTEXTID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable DepenPerm_ReadDepenPerm()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDENCIAS.DEPENPERM_READDEPENPERM", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable UserxDependencia()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_12", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDENCIAS.USERXDEPENDENCIA", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable UserxDependencia_ReadUserByApellido(string mApellidosUsuario)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ApellidosUsuario", OracleDbType.Varchar2);
        //Parametros[0].Value = mApellidosUsuario;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDENCIAS.USERXDEPENDENCIA_READUSERBYAPE", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable UserxDependencia_ReadUserByNombre(string mNombresUsuario)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_NombresUsuario", OracleDbType.Varchar2);
        //Parametros[0].Value = mNombresUsuario;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_DEPENDENCIAS.USERXDEPENDENCIA_READUSERBYNOM", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool UsuaxDepen_UpdateUsuaxDependencia(string mUserId, string mDependenciaCodigo, string mNombresUsuario, string mApellidosUsuario)
    {
        //OracleParameter[] Parametros = new OracleParameter[4];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_UserId", OracleDbType.Varchar2);
        //Parametros[0].Value = mUserId;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_NombresUsuario", OracleDbType.Varchar2);
        //Parametros[2].Value = mNombresUsuario;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_ApellidosUsuario", OracleDbType.Varchar2);
        //Parametros[3].Value = mApellidosUsuario;
        //Parametros[3].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_DEPENDENCIAS.USUAXDEPEN_UPDATEUSUAXDEPEN", Parametros);

        return true;
    }

    #endregion

    }


	

