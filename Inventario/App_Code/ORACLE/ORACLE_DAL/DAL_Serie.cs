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
/// Descripción breve de DAL_Serie
/// </summary>
public class DAL_Serie
{
	public DAL_Serie()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    //OracleParameter[] Parametros = new OracleParameter[7];
    //OraDataClass oraDataClass = new OraDataClass();
   // OracleCommand dtComando = new OracleCommand();
    DataSet DataSet=null;


    public bool CrearSerie(string mSerieCodigo, string mSerieNombre, string mSerieCodigoPadre, int mSerieTiempo, string mSerieHabilitar, string mSeriePermiso)
    {
       // OracleParameter[] Parametros = new OracleParameter[7];
       // OraDataClass DataClass = new OraDataClass();
       // OracleCommand dtComando = new OracleCommand();
        DataSet DataSet;



      //  Parametros[0] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
      //  Parametros[0].Value = mSerieCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_SerieNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mSerieNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_SerieCodigoPadre", OracleDbType.Varchar2);
        //Parametros[2].Value = mSerieCodigoPadre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_SerieTiempo", OracleDbType.Varchar2);
        //Parametros[3].Value = mSerieTiempo;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_SerieHabilitar", OracleDbType.Varchar2);
        //Parametros[4].Value = mSerieHabilitar;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_SeriePermiso", OracleDbType.Varchar2);
        //Parametros[5].Value = mSeriePermiso;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@cv_13", OracleDbType.RefCursor);
        //Parametros[6].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_SERIE.SERIE_CREATESERIE", Parametros);

        return true;
    }

    public bool DeleteSerie(string mSerieCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_SerieCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mSerieCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_SERIE.SERIE_DELETESERIE", Parametros);

        return true;
    }

    public DataTable ExisteSerie(string mSerieCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

       // Parametros[0] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
       // Parametros[0].Value = mSerieCodigo;
       // Parametros[0].Direction = ParameterDirection.Input;

       // Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
       // Parametros[1].Direction = ParameterDirection.Output;

       // DataSet = oraDataClass.GetDataSet("ALFANET.PKG_SERIE.SERIE_READEXISTESERIE", Parametros, true);

        return DataSet.Tables[0];
        
    }

    public DataTable ReadSerie()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

       // Parametros[0] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
       // Parametros[0].Direction = ParameterDirection.Output;

       // DataSet = oraDataClass.GetDataSet("ALFANET.PKG_SERIE.SERIE_READSERIE", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadSerieById(string mSerieCodigo)
    {
       // OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mSerieCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_3", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_SERIE.SERIE_READSERIEBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadSerieByTextNombre(string mSerieNombre, string mSerieHabilitar)
    {
       // OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_SerieNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mSerieNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_SerieHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mSerieHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_SERIE.SERIE_READSERIEBYTEXT", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadSerieByTextId(string mSerieCodigo, string mSerieHabilitar)
    {
       // OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();
        

        //Parametros[0] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mSerieCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_SerieHabilitar", OracleDbType.Varchar2);
        //Parametros[1].Value = mSerieHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.PKG_SERIE.SERIE_READSERIEBYTEXTID", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool UpdateSerie(string mSerieNombre, string mSerieCodigoPadre, int mSerieTiempo, string mSerieHabilitar, string mSeriePermiso, string mOriginalSerieCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[7];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();



        //Parametros[0] = new OracleParameter("@v_SerieNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mSerieNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_SerieCodigoPadre", OracleDbType.Varchar2);
        //Parametros[1].Value = mSerieCodigoPadre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_SerieTiempo", OracleDbType.Varchar2);
        //Parametros[2].Value = mSerieTiempo;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_SerieHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mSerieHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_SeriePermiso", OracleDbType.Varchar2);
        //Parametros[4].Value = mSeriePermiso;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_Original_SerieCodigo", OracleDbType.Varchar2);
        //Parametros[5].Value = mOriginalSerieCodigo;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[6].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_SERIE.SERIE_UPDATESERIE", Parametros);

        return true;
    }

    public bool SerieCrearPermiso(string mSerieCodigo, string mDependenciaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[3];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mSerieCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_2", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_SERIE.SERIEPERM_CREATESERIEPERM", Parametros);

        return true;
    }

    public bool SerieDeletePer(string mSerieCodigo, string mDependenciaCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[2];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_Original_SerieCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mSerieCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_Original_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_SERIE.SERIEPERMISO_DELETESERIEPERMISO", Parametros);

        return true;

    }

    public DataTable ReadSeriePermiso()
    {
        //OracleParameter[] Parametros = new OracleParameter[1];
       // DataSet = new DataSet();

       // Parametros[0] = new OracleParameter("@cv_3", OracleDbType.RefCursor);
       // Parametros[0].Direction = ParameterDirection.Output;

       // DataSet = oraDataClass.GetDataSet("ALFANET.PKG_SERIE.SERIEPERMISO_READSERIEPERMISO", Parametros, true);

        return DataSet.Tables[0];
    }

    public DataTable ReadSeriePermisoById(string mSerieCodigo)
    {
       // OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

       // Parametros[0] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
       // Parametros[0].Value = mSerieCodigo;
       // Parametros[0].Direction = ParameterDirection.Input;

       // Parametros[1] = new OracleParameter("@cv_4", OracleDbType.RefCursor);
       // Parametros[1].Direction = ParameterDirection.Output;

      //  DataSet = oraDataClass.GetDataSet("ALFANET.PKG_SERIE.SERIEPERM_READSERIEPERMBYID", Parametros, true);

        return DataSet.Tables[0];
    }

    public bool SerieUpdatePer(string mSerieCodigo, string mDependenciaCodigo, string mSerieCodigoOriginal, string mDependenciaCodigoOriginal)
    {
        //OracleParameter[] Parametros = new OracleParameter[5];
       // OraDataClass DataClass = new OraDataClass();
       // OracleCommand dtComando = new OracleCommand();


       // Parametros[0] = new OracleParameter("@v_SerieCodigo", OracleDbType.Varchar2);
       // Parametros[0].Value = mSerieCodigo;
       // Parametros[0].Direction = ParameterDirection.Input;

       // Parametros[1] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
       // Parametros[1].Value = mDependenciaCodigo;
       // Parametros[1].Direction = ParameterDirection.Input;

       // Parametros[2] = new OracleParameter("@v_Original_SerieCodigo", OracleDbType.Varchar2);
       // Parametros[2].Value = mSerieCodigoOriginal;
       // Parametros[2].Direction = ParameterDirection.Input;

       // Parametros[3] = new OracleParameter("@v_Original_DependenciaCodigo", OracleDbType.Varchar2);
       // Parametros[3].Value = mDependenciaCodigoOriginal;
       // Parametros[3].Direction = ParameterDirection.Input;

      //  Parametros[4] = new OracleParameter("@cv_5", OracleDbType.RefCursor);
      //  Parametros[4].Direction = ParameterDirection.Output;

      //  dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_SERIE.SERIEPERMISO_UPDATESERIEPERM", Parametros);

        return true;

    }
}
