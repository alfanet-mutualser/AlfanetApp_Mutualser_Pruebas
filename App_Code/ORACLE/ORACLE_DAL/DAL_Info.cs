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
/// Descripción breve de DAL
/// </summary>
public class DAL_Info
{
    public DAL_Info()
    {
    }

    #region Variables
   // OraDataClass oraDataClass = new OraDataClass();
    DataSet DataSet;
    #endregion

    #region Metodos


    public bool CrearInfo(string mEmpresa, string mDireccion, string mTelefono, string mFax, string mEMail, string mCiudadCodigo)
    {
        //OracleParameter[] Parametros = new OracleParameter[6];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_Empresa", OracleDbType.Varchar2);
        //Parametros[0].Value = mEmpresa;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_Direccion", OracleDbType.Varchar2);
        //Parametros[1].Value = mDireccion;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_Telefono", OracleDbType.Varchar2);
        //Parametros[2].Value = mTelefono;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_Fax", OracleDbType.Varchar2);
        //Parametros[3].Value = mFax;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_EMail", OracleDbType.Varchar2);
        //Parametros[4].Value = mEMail;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_CiudadCodigo", OracleDbType.Varchar2);
        //Parametros[5].Value = mCiudadCodigo;
        //Parametros[5].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.PKG_OTROS.INFO_CREATEINFO", Parametros);

        return true;
    }


   
    #endregion
}
