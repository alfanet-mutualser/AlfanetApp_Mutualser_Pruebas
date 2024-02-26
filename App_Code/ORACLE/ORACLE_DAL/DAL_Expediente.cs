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
/// Descripción breve de DAL_Expediente
/// </summary>
public class DAL_Expediente
{
    public DAL_Expediente()
    {
    }

    #region Variables
    //OraDataClass oraDataClass = new OraDataClass();
    DataSet DataSet;
    #endregion

    #region Metodos

        public DataTable ConsultaExpediente(string mExpedienteNombre, string mExpedienteCodigo)
        {
       // OracleParameter[] Parametros = new OracleParameter[6];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ExpedienteNombre", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mExpedienteCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@sys_refcursor", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //Parametros[3] = new OracleParameter("@cv_1", OracleDbType.Varchar2);
        //Parametros[3].Direction = ParameterDirection.Output;
        //Parametros[3].Size = 4000;

        //Parametros[4] = new OracleParameter("@sys_refcursor", OracleDbType.RefCursor);
        //Parametros[4].Direction = ParameterDirection.Output;

        //Parametros[5] = new OracleParameter("@cv_2", OracleDbType.Varchar2);
        //Parametros[5].Direction = ParameterDirection.Output;
        //Parametros[5].Size = 4000;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_EXPEDIENTE.EXPEDIENTE_CONSULTASEXPEDIENTE", Parametros, true);

        return DataSet.Tables[0];
        }

        public int ExpedienteCreateExpediente(string mExpedienteCodigo, string mExpedienteNombre,
             string mExpedienteCodigoPadre, string mExpedienteHabilitar, string mExpedienteDireccion,
             string mExpedienteTelefono1, string mExpedienteTelefono2, string mExpedienteFax,
             string mExpedienteMail1, string mExpedienteMail2, string mExpedientePaginaWeb,
             string mExpedientePermiso)
    {

        //OracleParameter[] Parametros = new OracleParameter[13];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ExpedienteNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mExpedienteNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_ExpedienteCodigoPadre", OracleDbType.Varchar2);
        //Parametros[2].Value = mExpedienteCodigoPadre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_ExpedienteHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mExpedienteHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_ExpedienteDireccion", OracleDbType.Varchar2);
        //Parametros[4].Value = mExpedienteDireccion;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_ExpedienteTelefono1", OracleDbType.Varchar2);
        //Parametros[5].Value = mExpedienteTelefono1;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_ExpedienteTelefono2", OracleDbType.Varchar2);
        //Parametros[6].Value = mExpedienteTelefono2;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@v_ExpedienteFax", OracleDbType.Varchar2);
        //Parametros[7].Value = mExpedienteFax;
        //Parametros[7].Direction = ParameterDirection.Input;

        //Parametros[8] = new OracleParameter("@v_ExpedienteMail1", OracleDbType.Varchar2);
        //Parametros[8].Value = mExpedienteMail1;
        //Parametros[8].Direction = ParameterDirection.Input;

        //Parametros[9] = new OracleParameter("@v_ExpedienteMail2", OracleDbType.Varchar2);
        //Parametros[9].Value = mExpedienteMail2;
        //Parametros[9].Direction = ParameterDirection.Input;

        //Parametros[10] = new OracleParameter("@v_ExpedientePaginaWeb", OracleDbType.Varchar2);
        //Parametros[10].Value = mExpedientePaginaWeb;
        //Parametros[10].Direction = ParameterDirection.Input;

        //Parametros[11] = new OracleParameter("@v_ExpedientePermiso", OracleDbType.Varchar2);
        //Parametros[11].Value = mExpedientePermiso;
        //Parametros[11].Direction = ParameterDirection.Input;

        //Parametros[12] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[12].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_EXPEDIENTE.EXPEDIENTE_CREATEEXPEDIENTE", Parametros);

        return 1;
    }

        public bool DeleteExpediente(string mExpedienteCodigo)
        {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

        //Parametros[0] = new OracleParameter("@v_Original_ExpedienteCodigo", OracleDbType.NVarchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_EXPEDIENTE.EXPEDIENTE_DELETEEXPEDIENTE", Parametros);

        return true;
        }

        public DataTable GetExisteExpediente(string mExpedienteCodigo)
        {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_EXPEDIENTE.EXPEDIENTE_READEXISTEEXPEDIENT", Parametros, true);

        return DataSet.Tables[0];
        
        }

        public DataTable GetExpediente()
        {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_EXPEDIENTE.EXPEDIENTE_READEXPEDIENTE", Parametros, true);

        return DataSet.Tables[0];
        }

        public DataTable GetExpedienteById(string mExpedienteCodigo)
        {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.NVarchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_EXPEDIENTE.EXPEDIENTE_READEXPEDIENTEBYID", Parametros, true);

        return DataSet.Tables[0];
        }

        public DataTable GetExpedienteByTextId(string mExpedienteCodigo, string mExpedienteHabilitar)
        {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.NVarchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ExpedienteHabilitar", OracleDbType.Decimal);
        //Parametros[1].Value = mExpedienteHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_EXPEDIENTE.EXPEDIENTE_READEXPEDBYTEXTID", Parametros, true);

        return DataSet.Tables[0];
        }

        public DataTable GetExpedienteByTextNom(string mExpedienteNombre, string mExpedienteHabilitar)
        {
        //OracleParameter[] Parametros = new OracleParameter[3];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ExpedienteNombre", OracleDbType.NVarchar2);
        //Parametros[0].Value = mExpedienteNombre;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ExpedienteHabilitar", OracleDbType.Decimal);
        //Parametros[1].Value = mExpedienteHabilitar;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_EXPEDIENTE.EXPEDIENTE_READEXPEDBYTEXTNOM", Parametros, true);

        return DataSet.Tables[0];
        
        }

        public bool UpdateExpediente(string mExpedienteCodigo, string mExpedienteNombre, string mExpedienteCodigoPadre, string mExpedienteHabilitar,
        string mExpedientePermiso, string mExpedienteDireccion, string mExpedienteTelefono1, string mExpedienteTelefono2, string mExpedienteFax, string mExpedienteMail1,
        string mExpedienteMail2, string mExpedientePaginaWeb, string mExpedienteCodigoOriginal)

        {
        //OracleParameter[] Parametros = new OracleParameter[14];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

    
        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ExpedienteNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mExpedienteNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_ExpedienteCodigoPadre", OracleDbType.Varchar2);
        //Parametros[2].Value = mExpedienteCodigoPadre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_ExpedienteHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mExpedienteHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_ExpedientePermiso", OracleDbType.Varchar2);
        //Parametros[4].Value = mExpedientePermiso;
        //Parametros[4].Direction = ParameterDirection.Input;
        
        //Parametros[5] = new OracleParameter("@v_ExpedienteDireccion", OracleDbType.Varchar2);
        //Parametros[5].Value = mExpedienteDireccion;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@v_ExpedienteTelefono1", OracleDbType.Varchar2);
        //Parametros[6].Value = mExpedienteTelefono1;
        //Parametros[6].Direction = ParameterDirection.Input;

        //Parametros[7] = new OracleParameter("@v_ExpedienteTelefono2", OracleDbType.Varchar2);
        //Parametros[7].Value = mExpedienteTelefono2;
        //Parametros[7].Direction = ParameterDirection.Input;

        //Parametros[8] = new OracleParameter("@v_ExpedienteFax", OracleDbType.Varchar2);
        //Parametros[8].Value = mExpedienteFax;
        //Parametros[8].Direction = ParameterDirection.Input;

        //Parametros[9] = new OracleParameter("@v_ExpedienteMail1", OracleDbType.Varchar2);
        //Parametros[9].Value = mExpedienteMail1;
        //Parametros[9].Direction = ParameterDirection.Input;

        //Parametros[10] = new OracleParameter("@v_ExpedienteMail2", OracleDbType.Varchar2);
        //Parametros[10].Value = mExpedienteMail2;
        //Parametros[10].Direction = ParameterDirection.Input;

        //Parametros[11] = new OracleParameter("@v_ExpedientePaginaWeb", OracleDbType.Varchar2);
        //Parametros[11].Value = mExpedientePaginaWeb;
        //Parametros[11].Direction = ParameterDirection.Input;

        //Parametros[12] = new OracleParameter("@v_Original_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[12].Value = mExpedienteCodigoOriginal;
        //Parametros[12].Direction = ParameterDirection.Input;

        //Parametros[13] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[13].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_EXPEDIENTE.EXPEDIENTE_UPDATEEXPEDIENTE", Parametros);

        return true;

        }

        public bool UpdateExpedientePer(string mExpedienteCodigo,string mExpedientePermiso)

        {
        //OracleParameter[] Parametros = new OracleParameter[3];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

    
        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ExpedientePermiso", OracleDbType.Varchar2);
        //Parametros[1].Value = mExpedientePermiso;
        //Parametros[1].Direction = ParameterDirection.Input;
        
        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_EXPEDIENTE.EXPEDIENTE_UPDATEEXPEDIENTEPER", Parametros);

        return true;

        }
 
        public bool ExpedienteInsertPermiso(string mExpedienteCodigo,string mDependenciaCodigo)

        {
        //OracleParameter[] Parametros = new OracleParameter[2];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

    
        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;
        
        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_EXPEDIENTE.EXPEDIENTE_UPDATEEXPEDIENTEPER", Parametros);

        return true;
        }

        public bool CrearExpedientePer(string mExpedienteCodigo, string mDependenciaCodigo)
        {
        //OracleParameter[] Parametros = new OracleParameter[3];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[2].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_EXPEDIENTE.EXPEDPER_CREATEEXPEDPER", Parametros);

        return true;
        
        }

        public bool ExpedienteDeletePer(string mExpedienteCodigo,string mDependenciaCodigo)

        {
        //OracleParameter[] Parametros = new OracleParameter[2];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();

    
        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;
        
        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_EXPEDIENTE.EXPEDPER_CREATEEXPEDPER", Parametros);

        return true;
    
        }


        public DataTable ExpedienteLeerPer()
        {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_EXPEDIENTE.EXPEDPERM_READEXPEDPERM", Parametros, true);

        return DataSet.Tables[0];

        }

        
        public DataTable ExpedienteLeerPerbyID(string mExpedienteCodigo)
        {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_EXPEDIENTE.EXPEDPERM_READEXPEDPERMBYID", Parametros, true);

        return DataSet.Tables[0];

        }

        
        public bool ExpedienteUpdatePer(string mExpedienteCodigo, string mDependenciaCodigo, string mExpedienteCodigoOriginal,
            string mDependenciaCodigoOriginal)
        {
        //OracleParameter[] Parametros = new OracleParameter[5];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[1].Value = mDependenciaCodigo;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_Original_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[2].Value = mExpedienteCodigoOriginal;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_Original_DependenciaCodigo", OracleDbType.Varchar2);
        //Parametros[3].Value = mDependenciaCodigoOriginal;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[4].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_EXPEDIENTE.EXPEDPER_UPDATEEXPEDPER", Parametros);

        return true;

        }

        public DataTable ExpedienteBorrarCount()
        {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_EXPEDIENTE.BORRARME_COUNTEXPEDIENTE", Parametros, true);

        return DataSet.Tables[0];

        }

        public DataTable ExpedienteBorrarCount2(string mExpedientePermiso)
        {
        //OracleParameter[] Parametros = new OracleParameter[2];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@v_ExpedientePermiso", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedientePermiso;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[1].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_EXPEDIENTE.BORRARME_COUNTEXPEDIENTE2", Parametros, true);

        return DataSet.Tables[0];

        }

        public bool ExpedienteBorrarme(string mExpedienteCodigoOriginal)
        {
        //OracleParameter[] Parametros = new OracleParameter[1];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_Original_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigoOriginal;
        //Parametros[0].Direction = ParameterDirection.Input;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_EXPEDIENTE.BORRARME_DELETEEXPEDIENTE", Parametros);

        return true;

        }

        public bool ExpedienteBorrarmeInsertExpediente(string mExpedienteCodigo, string mExpedienteNombre,
        string mExpedienteCodigoPadre, string mExpedienteHabilitar, string mExpedientePermiso)
        {
        //OracleParameter[] Parametros = new OracleParameter[6];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ExpedienteNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mExpedienteNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_ExpedienteNombreCodigoPadre", OracleDbType.Varchar2);
        //Parametros[2].Value = mExpedienteCodigoPadre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_ExpedienteHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mExpedienteHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_ExpedientePermiso", OracleDbType.Varchar2);
        //Parametros[4].Value = mExpedientePermiso;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[5].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_EXPEDIENTE.BORRARME_INSERTEXPEDIENTE", Parametros);

        return true;

        }

        public DataTable ExpedienteBorrarSelect()
        {
        //OracleParameter[] Parametros = new OracleParameter[1];
        DataSet = new DataSet();

        //Parametros[0] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[0].Direction = ParameterDirection.Output;

        //DataSet = oraDataClass.GetDataSet("ALFANET.MAESTRO_EXPEDIENTE.BORRARME_SELECTEXPEDIENTE", Parametros, true);

        return DataSet.Tables[0];

        }

        public bool ExpedienteBorrarmeUpdateExpediente(string mExpedienteCodigo, string mExpedienteNombre,
        string mExpedienteCodigoPadre, string mExpedienteHabilitar, string mExpedientePermiso, string mExpedienteCodigoOriginal)
        {
        //OracleParameter[] Parametros = new OracleParameter[7];
        //OraDataClass DataClass = new OraDataClass();
        //OracleCommand dtComando = new OracleCommand();


        //Parametros[0] = new OracleParameter("@v_ExpedienteCodigo", OracleDbType.Varchar2);
        //Parametros[0].Value = mExpedienteCodigo;
        //Parametros[0].Direction = ParameterDirection.Input;

        //Parametros[1] = new OracleParameter("@v_ExpedienteNombre", OracleDbType.Varchar2);
        //Parametros[1].Value = mExpedienteNombre;
        //Parametros[1].Direction = ParameterDirection.Input;

        //Parametros[2] = new OracleParameter("@v_ExpedienteNombreCodigoPadre", OracleDbType.Varchar2);
        //Parametros[2].Value = mExpedienteCodigoPadre;
        //Parametros[2].Direction = ParameterDirection.Input;

        //Parametros[3] = new OracleParameter("@v_ExpedienteHabilitar", OracleDbType.Varchar2);
        //Parametros[3].Value = mExpedienteHabilitar;
        //Parametros[3].Direction = ParameterDirection.Input;

        //Parametros[4] = new OracleParameter("@v_ExpedientePermiso", OracleDbType.Varchar2);
        //Parametros[4].Value = mExpedientePermiso;
        //Parametros[4].Direction = ParameterDirection.Input;

        //Parametros[5] = new OracleParameter("@v_ExpedienteCodigoOriginal", OracleDbType.Varchar2);
        //Parametros[5].Value = mExpedientePermiso;
        //Parametros[5].Direction = ParameterDirection.Input;

        //Parametros[6] = new OracleParameter("@cv_1", OracleDbType.RefCursor);
        //Parametros[6].Direction = ParameterDirection.Output;

        //dtComando = DataClass.ExecuteProcedureOutput("ALFANET.MAESTRO_EXPEDIENTE.BORRARME_UPDATEEXPEDIENTE", Parametros);

        return true;

        }

    #endregion
}
