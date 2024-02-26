using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

class DAL_UnidadDocumental
{
    #region Variables
    //OraDataClass oraDataClass = new OraDataClass();
    DataSet DataSet;
    #endregion

    public DataTable ReadUnidadNombreByText(string mUnidadNombre)
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
    public DataTable ReadUbicacionByText(string mUbicacionNombre, string mUbicacionHabilitar)
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
    public DataTable ReadFormaByText(string mFormaNombre, string mFormaHabilitar)
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
    public DataTable ReadTipologiaByText(string mTipologiaNombre, string mTipologiaHabilitar)
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
}
