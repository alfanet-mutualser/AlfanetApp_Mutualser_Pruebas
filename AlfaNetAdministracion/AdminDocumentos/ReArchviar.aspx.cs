using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;
using ASP;
using Microsoft;
using Infragistics.Shared;
using Infragistics.WebUI.UltraWebGrid;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
public partial class _ReArchviar : System.Web.UI.Page
{
    DateTime FechaIni = DateTime.Now;
    string ConsecutivoCodigo = "2";
    string ModuloLog = "Rearchivar";
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
    protected void ImgBtnFind_Click(object sender, ImageClickEventArgs e)
    {
        string ActLogCod = "BUSCAR";
        try
        {
        this.CiudadByIdDataSource.SelectParameters["GrupoCodigo"].DefaultValue = this.RadBtnLstFindby.SelectedValue;
        if (TxtDocumento.Text != "")
        {
            if (TxtDocumento.Text.Contains(" | "))
            {
                TxtDocumento.Text = TxtDocumento.Text.Remove(TxtDocumento.Text.IndexOf(" | "));
            }
        }
        else
        {
            TxtDocumento.Text = null;
        }
        this.CiudadByIdDataSource.SelectParameters["NumeroDocumento"].DefaultValue = this.TxtDocumento.Text;
        this.DVDocumento.DataBind();
        int _campos = this.DVDocumento.Rows.Count;
        if (_campos > 0)
        {
            this.DVDocumento.ChangeMode(DetailsViewMode.ReadOnly);
            this.Label3.Visible = true;
            this.TextBox3.Visible = true;
            this.TextBox3.Text = "";
            this.LinkButton1.Visible = true;
        }
        else
        {
            //this.DVDocumento.ChangeMode(DetailsViewMode.ReadOnly);
            this.Label3.Visible = false;
            this.TextBox3.Visible = false;
            this.LinkButton1.Visible = false;

            this.LblMessageBox.Text = "El documento no existe o no está archivado. Por favor verifique ";
      
            this.MPEMensaje.Show();
        }
        DateTime WFMovimientoFecha = DateTime.Now;
        //OBTENER CONSECUTIVO DE LOGS
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
        DataRow[] fila = Conse.Select();
        string x = fila[0].ItemArray[0].ToString();
        string LOG = Convert.ToString(x);
        int NumeroDocumento = Convert.ToInt32(TxtDocumento.Text);
        string GrupoCod = "1";
        string Datosini = "";
        Label DepCodigo = (Label)DVDocumento.FindControl("Label1");
        //DSWFMOVIMIENTOS
        DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadoTableAdapter archi = new DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadoTableAdapter();
        DSWorkFlow.WFMovimiento_ReadWFMovimientoArchivadoDataTable tabl = new DSWorkFlow.WFMovimiento_ReadWFMovimientoArchivadoDataTable();
        tabl = archi.GetMovimientoArchivado(GrupoCod, TxtDocumento.Text);
        DataRow[] rows = tabl.Select();
        string DepNombre = rows[0].ItemArray[6].ToString();
        string Accion = rows[0].ItemArray[9].ToString();
        string Detalle = rows[0].ItemArray[10].ToString();
        string SerieCod = rows[0].ItemArray[11].ToString();
        string SerieNombre = rows[0].ItemArray[12].ToString();
        //Num Doc+ DependenciaCod + DependenciaNombre+ Accion +Detalle + SerieCod +SerieNombre
        string Datosfin1 = TxtDocumento.Text + " | " + DepCodigo.Text + " | " + DepNombre + " | " + Accion + " | " + Detalle + " | " + SerieCod + " | " + SerieNombre;
        Session["Archi"] = Datosfin1;
        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
        DateTime FechaFin = DateTime.Now;
        Int64 LogId = Convert.ToInt64(LOG);
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
        Accediendo.GetData(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception error)
        {
            this.LblMessageBox.Text = "El documento no existe o no está archivado. Por favor verifique ";
            this.MPEMensaje.Show();
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string ModuloLog = "RE-ARCHIVAR";
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al Re-archivar " + error;
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
    protected void ImgBtnInsert_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnUpdateActualizar_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnNew_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void DVDocumento_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {

    }
    protected void DVDocumento_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {

    }
    protected void DVDocumento_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {

    }
    protected void DVDocumento_DataBound(object sender, EventArgs e)
    {

    }
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "1")
        {
            this.DVDocumento.Visible = false;
            this.Label3.Visible = false;
            this.TextBox3.Visible = false;
            this.LinkButton1.Visible = false;
            this.ACDocumento.ServiceMethod = "GetDocArchivadosRecibidos";
        }
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "2")
        {
            this.DVDocumento.Visible = false;
            this.Label3.Visible = false;
            this.TextBox3.Visible = false;
            this.LinkButton1.Visible = false;
            this.ACDocumento.ServiceMethod = "GetDocArchivadosEnviados";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string ActLogCod = "ACTUALIZAR";
        if(RadBtnLstFindby.SelectedValue=="1")
        {
        int mNumeroDocumento = Convert.ToInt32(this.DVDocumento.DataKey[0].ToString());
        int mWFMovimientoPaso = Convert.ToInt32(this.DVDocumento.DataKey[1].ToString());
        String mDependenciaCodDestino = this.DVDocumento.DataKey[2].ToString();
        String mDependenciaCodOrigen = this.DVDocumento.DataKey[2].ToString();

        String mWFMovimientoMultitarea = "0";

        int mWFMovimientoTipoini = Convert.ToInt32(this.DVDocumento.DataKey[3].ToString());
        int mWFMovimientoTipo = 7;

        DateTime mWFFechaMovimientoFin= DateTime.Now;
        String mWFMovimientoNotas = this.DVDocumento.DataKey[5].ToString();
        if (mWFMovimientoNotas == "")
            mWFMovimientoNotas = null;
        String mGrupoCodigo = this.DVDocumento.DataKey[4].ToString();
        String mWFProcesoCodigo = null;
        String mWFAccionCodigo = "1";
        DateTime mWFMovimientoFecha = DateTime.Now;
        DateTime mWFMovimientoFechaEst = DateTime.Now;
        String mSerieCodigo = null;
        mSerieCodigo = this.TextBox3.Text;
        if (mSerieCodigo != "")
        {
            if (mSerieCodigo.Contains(" | "))
            {
                mSerieCodigo = mSerieCodigo.Remove(mSerieCodigo.IndexOf(" | "));
            }
            else
            {
                mSerieCodigo = null;
            }
        }
        else
        {
            mSerieCodigo = null;
        }
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////
        DSWorkFlowTableAdapters.WFMovimientoTableAdapter TAWFMovimiento = new DSWorkFlowTableAdapters.WFMovimientoTableAdapter();
        Object ErrorMessage = TAWFMovimiento.InsertaWFMovimiento(mNumeroDocumento,
                                                           mDependenciaCodDestino,
                                                           mWFMovimientoPaso,
                                                           0,
                                                           1,
                                                           mWFFechaMovimientoFin,
                                                           mWFMovimientoTipo,
                                                           mWFMovimientoTipoini,
                                                           mWFMovimientoNotas,
                                                           mGrupoCodigo,
                                                           mDependenciaCodOrigen,
                                                           mWFProcesoCodigo,
                                                           mWFAccionCodigo,
                                                           mWFMovimientoFecha,
                                                           mWFMovimientoFechaEst,
                                                           mSerieCodigo,
                                                           mWFMovimientoMultitarea,
                                                           UserId);

  this.TxtDocumento.Text = null;
  string MensajeError = Convert.ToString(ErrorMessage);
  if (MensajeError == "")
  {
      this.Label3.Visible = false;
      this.TextBox3.Visible = false;
      this.LinkButton1.Visible = false;
      //this.TextBox3.Text = "";
      this.LblMessageBox.Text = "Documento Nro. " + mNumeroDocumento + " Archivado en Serie " + this.TextBox3.Text;
      this.MPEMensaje.Show();
  }
  else
  {
          this.SetFocus(this.TxtDocumento);
          //Display a user-friendly message
          this.LblMessageBox.Text = "Ocurrio un problema al tratar de archivar el Documento. ";
          Exception inner = new Exception(MensajeError);           
          this.LblMessageBox.Text += ErrorHandled.FindError(inner);
          this.MPEMensaje.Show();
          
  }
  
  //throw new Exception(MensajeError);
  DateTime WFMovimientoFecha = DateTime.Now;
  //OBTENER CONSECUTIVO DE LOGS
  DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
  DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
  Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
  DataRow[] fila = Conse.Select();
  string x = fila[0].ItemArray[0].ToString();
  string LOG = Convert.ToString(x);
  //Se Realiza el Log
  int NumeroDocumento = Convert.ToInt32(mNumeroDocumento);
  string GrupoCod = "1";
  string Datosini = Session["Archi"].ToString();
  Label DepCodigo = (Label)DVDocumento.FindControl("Label1");
  DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadoTableAdapter archi = new DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadoTableAdapter();
  DSWorkFlow.WFMovimiento_ReadWFMovimientoArchivadoDataTable tabl = new DSWorkFlow.WFMovimiento_ReadWFMovimientoArchivadoDataTable();
  tabl = archi.GetMovimientoArchivado(GrupoCod, Convert.ToString(NumeroDocumento));
  DataRow[] rows = tabl.Select();
  string DepNombre = rows[0].ItemArray[6].ToString();
  string Accion = rows[0].ItemArray[9].ToString();
  string Detalle = rows[0].ItemArray[10].ToString();
  string SerieCod = rows[0].ItemArray[11].ToString();
  string SerieNombre = rows[0].ItemArray[12].ToString();
  //Num Doc+ DependenciaCod + DependenciaNombre+ Accion +Detalle + SerieCod +SerieNomnbrw
  string Datosfin1 = TxtDocumento.Text + " | " + DepCodigo.Text + " | " + DepNombre + " | " + Accion + " | " + Detalle + " | " + SerieCod + " | " + SerieNombre;
  string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
  DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
  string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
  DateTime FechaFin = DateTime.Now;
  Int64 LogId = Convert.ToInt64(LOG);
  string IP = Session["IP"].ToString();
  string NombreEquipo = Session["Nombrepc"].ToString();
  System.Web.HttpBrowserCapabilities nav = Request.Browser;
  string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
  //Se hace log de actualizar documento rearchivar
  DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
  Accediendo.GetData(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
  DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
  ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }   
    }
}