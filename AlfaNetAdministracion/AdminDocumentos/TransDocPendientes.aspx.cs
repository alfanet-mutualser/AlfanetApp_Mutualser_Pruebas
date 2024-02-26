using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;


public partial class _TransDocPendientes : System.Web.UI.Page
{
    string ModuloLog = "Transf. Docs Pendientes";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "Error";
    protected void Page_Load(object sender, EventArgs e)
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork")
            {
                localIP = ip.ToString();
                Session["IP"] = localIP;
            }
        }
        Session["Nombrepc"] = host.HostName.ToString();
        if (!IsPostBack)
        {
           
        }
        else
        {

        }
    }
      
    //protected void LinkButton1_Click(object sender, EventArgs e)

    //{
  //      if(RadBtnLstFindby.SelectedValue=="1")
  //      {
  //      int mNumeroDocumento = Convert.ToInt32(this.DVDocumento.DataKey[0].ToString());
  //      int mWFMovimientoPaso = Convert.ToInt32(this.DVDocumento.DataKey[1].ToString());
  //      String mDependenciaCodDestino = this.DVDocumento.DataKey[2].ToString();
  //      String mDependenciaCodOrigen = this.DVDocumento.DataKey[2].ToString();

  //      String mWFMovimientoMultitarea = "0";

  //      int mWFMovimientoTipoini = Convert.ToInt32(this.DVDocumento.DataKey[3].ToString());
  //      int mWFMovimientoTipo = 7;

  //      DateTime mWFFechaMovimientoFin= DateTime.Now;
  //      String mWFMovimientoNotas = this.DVDocumento.DataKey[5].ToString();
  //      if (mWFMovimientoNotas == "")
  //          mWFMovimientoNotas = null;
  //      String mGrupoCodigo = this.DVDocumento.DataKey[4].ToString();
  //      String mWFProcesoCodigo = null;
  //      String mWFAccionCodigo = "1";
  //      DateTime mWFMovimientoFecha = DateTime.Now;
  //      DateTime mWFMovimientoFechaEst = DateTime.Now;
  //      String mSerieCodigo = null;
  //      mSerieCodigo = this.TextBox3.Text;
  //      if (mSerieCodigo != "")
  //      {
  //          if (mSerieCodigo.Contains(" | "))
  //          {
  //              mSerieCodigo = mSerieCodigo.Remove(mSerieCodigo.IndexOf(" | "));
  //          }
  //          else
  //          {
  //              mSerieCodigo = null;
  //          }
  //      }
  //      else
  //      {
  //          mSerieCodigo = null;
  //      }
  //      DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
  //      Object ErrorMessage = TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
  //                                                         mDependenciaCodDestino,
  //                                                         mWFMovimientoPaso,
  //                                                         0,
  //                                                         1,
  //                                                         mWFFechaMovimientoFin,
  //                                                         mWFMovimientoTipo,
  //                                                         mWFMovimientoTipoini,
  //                                                         mWFMovimientoNotas,
  //                                                         mGrupoCodigo,
  //                                                         mDependenciaCodOrigen,
  //                                                         mWFProcesoCodigo,
  //                                                         mWFAccionCodigo,
  //                                                         mWFMovimientoFecha,
  //                                                         mWFMovimientoFechaEst,
  //                                                         mSerieCodigo,
  //                                                         mWFMovimientoMultitarea);

  //this.TxtDocumento.Text = null;
  //string MensajeError = Convert.ToString(ErrorMessage);
  //if (MensajeError == "")
  //{
  //    this.LblMessageBox.Text = "Documento Nro. " + mNumeroDocumento + " Archivado en Serie " + this.TextBox3.Text;
  //}
  //else
  //{
  //        this.SetFocus(this.TxtDocumento);
  //        //Display a user-friendly message
  //        this.LblMessageBox.Text = "Ocurrio un problema al tratar de archivar el Documento. ";
  //        Exception inner = new Exception(MensajeError);           
  //        this.LblMessageBox.Text += ErrorHandled.FindError(inner);
  //        this.MPEMensaje.Show();
          
  //}
  //      }   
    //}
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        String DependenciaOrigen;
        String DependenciaDestino;
        DependenciaOrigen = this.TxtDocumento.Text;
        DependenciaDestino = this.TxtDepFinal.Text;
        string ActLogCod = "ACTUALIZAR";

        if (DependenciaOrigen.Contains(" | "))
        {
            DependenciaOrigen = DependenciaOrigen.Remove(DependenciaOrigen.IndexOf(" | "));            
        }
        else
        {
            DependenciaOrigen = null;
        }
        if (DependenciaDestino.Contains(" | "))
        {
            DependenciaDestino = DependenciaDestino.Remove(DependenciaDestino.IndexOf(" | "));
        }
        else
        {
            DependenciaDestino = null;
        }

        if (this.ChBoxLst.Items[0].Selected)
        {
            if (this.TxtDocumento.Text != "")
            {
                try
                {
                ////////////////////////////////////////////////
                MembershipUser user = Membership.GetUser();
                Object CodigoRuta = user.ProviderUserKey;
                String UserId = Convert.ToString(CodigoRuta);
                ////////////////////////////////////////////////
                DSWorkFlowTableAdapters.TRANSferenciaDOCSTableAdapter TATransferencia = new DSWorkFlowTableAdapters.TRANSferenciaDOCSTableAdapter();
                DSWorkFlow.TRANSferenciaDOCSDataTable DTTranferencia = new DSWorkFlow.TRANSferenciaDOCSDataTable();
                DTTranferencia = TATransferencia.GetDocRECIBIDO(DependenciaOrigen);

                foreach (DSWorkFlow.TRANSferenciaDOCSRow row in DTTranferencia.Rows)
                {
                    DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                    TAWFMovimiento.InsertaWFMovimiento(row.NumeroDocumento,
                                                       DependenciaDestino,
                                                       row.WFMovimientoPaso,
                                                       1,
                                                       0,
                                                       DateTime.Now,
                                                       row.WFMovimientoTipo,
                                                       row.WFMovimientoTipo,
                                                       row.WFMovimientoNotas,
                                                       row.GrupoCodigo,
                                                       row.DependenciaCodDestino,
                                                       null,
                                                       row.WFAccionCodigo,
                                                       DateTime.Now,
                                                       DateTime.Now,
                                                       null,
                                                       "0",
                                                       UserId);
                    //Recibidos                      
                    string ConsecutivoCodigo = "2";
                    DateTime WFMovimientoFecha = DateTime.Now;
                    //OBTENER CONSECUTIVO DE LOGS
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                    Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                    DataRow[] fila = Conse.Select();
                    string x = fila[0].ItemArray[0].ToString();
                    string LOG = Convert.ToString(x);
                    int NumeroDocumento = row.NumeroDocumento;
                    string GrupoCod = "1";
                    //DSWFMOVIMIENTOS
                    DataRow[] rows = DTTranferencia.Select();
                    string DepCodigoOrigen = rows[0].ItemArray[1].ToString();
                    //NUM DOC + Dependencia CodOrigen
                    string Datosini = NumeroDocumento + " | " + DepCodigoOrigen;
                    //NUM DOC + Dependencia CodDestino
                    string Datosfin1 = NumeroDocumento + " | " + DependenciaDestino;
                    string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                    DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                    string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                    DateTime FechaFin = DateTime.Now;
                    Int64 LogId = Convert.ToInt64(LOG);
                    string IP = Session["IP"].ToString();
                    string NombreEquipo = Session["Nombrepc"].ToString();
                    System.Web.HttpBrowserCapabilities nav = Request.Browser;
                    string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                    //Insert log actualizar trans docs pendientes enviados
                    DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accede = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                    Accede.GetData(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                    //Actualiza consecutivo log
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                }
                }
                catch (Exception error)
                {
                    this.LblMessageBox.Text = "Se ha presentado un error al transferir los documentos a: " + DependenciaDestino + "  Error:" + error;
                    this.MPEMensaje.Show();
                    //Variables de LOG ERROR
                    DateTime FechaInicio = DateTime.Now;
                    string grupoo = "";
                    //OBTENER CONSECUTIVO DE LOGS
                    string DatosFinales = "Error al Transferir docs " + error;
                    DateTime WFMovimientoFechaFin = DateTime.Now;
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConsecutivosErr = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    DSGrupoSQL.ConsecutivoLogsDataTable ConseErr = new DSGrupoSQL.ConsecutivoLogsDataTable();
                    ConseErr = ConsecutivosErr.GetConseError(ConsecutivoCodigoErr);
                    DataRow[] fila2 = ConseErr.Select();
                    string z = fila2[0].ItemArray[0].ToString();
                    string LOGERROR = Convert.ToString(z);
                    Int64 LogIdErr = Convert.ToInt64(LOGERROR);
                    string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                    DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                    string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                    string IP = HttpContext.Current.Session["IP"].ToString();
                    string NombreEquipo = HttpContext.Current.Session["Nombrepc"].ToString();
                    System.Web.HttpBrowserCapabilities nav = HttpContext.Current.Request.Browser;
                    string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                    //Se hace el insert de Log error
                    DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter Errores = new DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter();
                    Errores.GetError(LogIdErr, username, FechaInicio, ActividadLogCodigoErr, grupoo, ModuloLog, DatosFinales, WFMovimientoFechaFin, IP, NombreEquipo, Navegador);
                    //Se hace el update consecutivo de Logs
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
                }
            }
        }
        if (this.ChBoxLst.Items[1].Selected)
        {
            try
            {
            DSWorkFlowTableAdapters.TranferenciaEnviadaTableAdapter TATransferencia = new DSWorkFlowTableAdapters.TranferenciaEnviadaTableAdapter();
            DSWorkFlow.TranferenciaEnviadaDataTable DTTranferencia = new DSWorkFlow.TranferenciaEnviadaDataTable();
            DTTranferencia = TATransferencia.GetEnviada(DependenciaOrigen);
            ////////////////////////////////////////////////
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserId = Convert.ToString(CodigoRuta);
            ////////////////////////////////////////////////
            foreach (DSWorkFlow.TranferenciaEnviadaRow row in DTTranferencia.Rows)
            {
                DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
                TAWFMovimiento.InsertaWFMovimiento(row.NumeroDocumento,
                                                   DependenciaDestino,
                                                   row.WFMovimientoPaso,
                                                   1,
                                                   0,
                                                   DateTime.Now,
                                                   row.WFMovimientoTipo,
                                                   row.WFMovimientoTipo,
                                                   row.WFMovimientoNotas,
                                                   row.GrupoCodigo,
                                                   row.DependenciaCodDestino,
                                                   null,
                                                   row.WFAccionCodigo,
                                                   DateTime.Now,
                                                   DateTime.Now,
                                                   null,
                                                   "0",
                                                   UserId);
                //enviados
                string ConsecutivoCodigo = "3";
                DateTime WFMovimientoFecha = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                int NumeroDocumento = row.NumeroDocumento;
                string GrupoCod = "2";
                //DSWFMOVIMIENTOS
                DataRow[] rows = DTTranferencia.Select();
                string DepCodigoOrigen = rows[0].ItemArray[1].ToString();
                //NUM DOC + Dependencia CodOrigen
                string Datosini = NumeroDocumento + " | " + DepCodigoOrigen;
                //NUM DOC + Dependencia CodDestino
                string Datosfin1 = NumeroDocumento + " | " + DependenciaDestino;
                string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                DateTime FechaFin = DateTime.Now;
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Insert log actualizar trans docs pendientes enviados
                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accede = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                Accede.InsertEnviados(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                //Actualiza consecutivo
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
            }
            catch (Exception error)
            {
                this.LblMessageBox.Text = "Se ha presentado un error al transferir los documentos a: " + DependenciaDestino + "  Error:" + error;
                this.MPEMensaje.Show();
                //Variables de LOG ERROR
                DateTime FechaInicio = DateTime.Now;
                string grupoo = "";
                //OBTENER CONSECUTIVO DE LOGS
                string DatosFinales = "Error al Transferir docs " + error;
                DateTime WFMovimientoFechaFin = DateTime.Now;
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConsecutivosErr = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable ConseErr = new DSGrupoSQL.ConsecutivoLogsDataTable();
                ConseErr = ConsecutivosErr.GetConseError(ConsecutivoCodigoErr);
                DataRow[] fila2 = ConseErr.Select();
                string z = fila2[0].ItemArray[0].ToString();
                string LOGERROR = Convert.ToString(z);
                Int64 LogIdErr = Convert.ToInt64(LOGERROR);
                string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                string IP = HttpContext.Current.Session["IP"].ToString();
                string NombreEquipo = HttpContext.Current.Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = HttpContext.Current.Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Se hace el insert de Log error
                DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter Errores = new DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter();
                Errores.GetError(LogIdErr, username, FechaInicio, ActividadLogCodigoErr, grupoo, ModuloLog, DatosFinales, WFMovimientoFechaFin, IP, NombreEquipo, Navegador);
                //Se hace el update consecutivo de Logs
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
            }
        }

    }
}