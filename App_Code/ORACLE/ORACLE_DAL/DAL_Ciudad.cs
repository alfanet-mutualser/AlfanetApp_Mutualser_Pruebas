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
/// Descripción breve de DAL_Ciudad
/// </summary>
public class DAL_Ciudad
{
	public DAL_Ciudad()
	{
	}

    #region Variables
        //OraDataClass oraDataClass = new OraDataClass();
        DataSet DataSet;
    #endregion

    #region Metodos

        /// <summary>
        /// Metodos para el maestro de ciudades.
        /// </summary>
        /// <remarks>
        /// Autor: Anderson Ardila
        /// Fecha: 10 Marzo 2010
        /// </remarks>
        /// 

        public bool CrearCiudad(string mCiudadCodigo, string mCiudadNombre, string mDepartamentoCodigo, string mCiudadHabilitar, string mCiudadCodigo1, string mCiudadNombre1)
    {
        //OracleParameter[] Parametros = new OracleParameter[6];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_CiudadCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mCiudadCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_CiudadNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mCiudadNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_DepartamentoCodigo", OracleDbType.Varchar2);
        //Parametros[2].Value = mDepartamentoCodigo;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_CiudadHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mCiudadHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_CiudadCodigo1", OracleDbType.Varchar2);
        //Parametros[4].Value = mCiudadCodigo1;
        //Parametros[4].Direction = ParameterDirection.Output;

        //Parametros[5] = new OracleParameter("@v_CiudadNombre1", OracleDbType.Varchar2);
        //Parametros[5].Value = mCiudadNombre1;
        //Parametros[5].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_CIUDAD.CIUDAD_CREATECIUDAD", Parametros);

        return true;
    }

        public DataTable GetCiudadByTextId(string mCiudadCodigo, string mCiudadHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_CiudadCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mCiudadCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_CiudadHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mCiudadHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_CIUDAD.CIUDAD_CIUDADREADBYTEXTID", Parametros, true);

        return DataSet.Tables[0];
    }

        public DataTable GetCiudadByTextNombre(string mCiudadNombre, string mCiudadHabilitar)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_CiudadNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mCiudadNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_CiudadHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mCiudadHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_CIUDAD.CIUDAD_READCIUDADBYTEXTNOMBRE", Parametros, true);

        return DataSet.Tables[0];
    }


        public DataTable GetCiudad()
        {
           // OracleParameter[] Parametros = new OracleParameter[2];
            DataSet = new DataSet();

            //Parametros[0] = new OracleParameter("@sys_refcursor", OracleDbType.RefCursor);
            //Parametros[0].Direction = ParameterDirection.Output;

            //Parametros[1] = new OracleParameter("@Status", OracleDbType.Varchar2);
            //Parametros[1].Direction = ParameterDirection.Output;
            //Parametros[1].Size = 4000;

            //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_CIUDAD.CIUDAD_READCIUDAD", Parametros, true);

            return DataSet.Tables[0];
        }
    
        public DataTable GetCiudadById(string mCiudadCodigo)
        {
            //OracleParameter[] Parametros = new OracleParameter[2];
            DataSet = new DataSet();

            //Parametros[0] = new OracleParameter("@v_CiudadCodigo", OracleDbType.Varchar2);
            //Parametros[0].Value = mCiudadCodigo;
            //Parametros[0].Direction = ParameterDirection.Input;

            //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
            //Parametros[1].Direction = ParameterDirection.Output;
           
            //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_CIUDAD.CIUDAD_READCIUDADBYID", Parametros, true);

            return DataSet.Tables[0];
        }

        public bool UpdateCiudad(string mCiudadCodigo, string mCiudadNombre, string mDepartamentoCodigo, string mCiudadHabilitar, string mOriginalCiudadCodigo)
        {
            //OracleParameter[] Parametros = new OracleParameter[6];
            //OraDataClass DataClass = new OraDataClass();
            //OracleCommand dtComando = new OracleCommand();

            ////v_CiudadCodigo IN VARCHAR2 DEFAULT NULL ,
            ////v_CiudadNombre IN VARCHAR2 DEFAULT NULL ,
            ////v_DepartamentoCodigo IN VARCHAR2 DEFAULT NULL ,
            ////v_CiudadHabilitar IN VARCHAR2 DEFAULT NULL ,
            ////v_Original_CiudadCodigo IN VARCHAR2 DEFAULT NULL ,
            ////cv_1 OUT SYS_REFCURSOR

            //Parametros[0] = new OracleParameter("@v_CiudadCodigo", OracleDbType.Varchar2);
            //Parametros[0].Value = mCiudadCodigo;
            //Parametros[0].Direction = ParameterDirection.Input;

            //Parametros[1] = new OracleParameter("@v_CiudadNombre", OracleDbType.Varchar2);
            //Parametros[1].Value = mCiudadNombre;
            //Parametros[1].Direction = ParameterDirection.Input;

            //Parametros[2] = new OracleParameter("@v_DepartamentoCodigo", OracleDbType.Varchar2);
            //Parametros[2].Value = mDepartamentoCodigo;
            //Parametros[2].Direction = ParameterDirection.Input;

            //Parametros[3] = new OracleParameter("@v_CiudadHabilitar", OracleDbType.Varchar2);
            //Parametros[3].Value = mCiudadHabilitar;
            //Parametros[3].Direction = ParameterDirection.Input;

            //Parametros[4] = new OracleParameter("@v_Original_CiudadCodigo", OracleDbType.Varchar2);
            //Parametros[4].Value = mOriginalCiudadCodigo;
            //Parametros[4].Direction = ParameterDirection.Input;

            //Parametros[5] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
            //Parametros[5].Direction = ParameterDirection.Output;

            //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_CIUDAD.CIUDAD_UPDATECIUDAD", Parametros);

            return true;
        }

        public bool DeleteCiudad(string mCiudadCodigo)
        {
           //OracleParameter[] Parametros = new OracleParameter[1];
           //OraDataClass DataClass = new OraDataClass();
           //OracleCommand dtComando = new OracleCommand();

           //Parametros[0] = new OracleParameter("@v_Original_CiudadCodigo", OracleDbType.Varchar2);
           //Parametros[0].Value = mCiudadCodigo;
           //Parametros[0].Direction = ParameterDirection.Input;

           //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_CIUDAD.CIUDAD_DELETECIUDAD", Parametros);

           return true;
        }

    #endregion

}
