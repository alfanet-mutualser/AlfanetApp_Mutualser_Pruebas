using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.NetworkInformation;
public partial class AlfaNetDocumentos_DocRecibido_StickerImpresion : System.Web.UI.Page
{
    StickerBLL Sticker = new StickerBLL();
    DateTime Fecha;
    DateTime Hora;
    string ModuloLog = "STICKER";
    string ConsecutivoCodigo = "12";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "ERROR";
    //string TramiteDependencia = new string[64];
    //string TramiteProcedencia = new string[64];

    protected void Page_Load(object sender, EventArgs e)
    {
        try
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

        string nrodoc = Request["RadicadoCodigo"];
        string Grupo = Request["GrupoCodigo"];
        String CodBar = Request["CodBar"];
        string GrupoPadre = Request["GrupoPadreCodigo"];

        if (CodBar == "1")
        {
            this.LblCodigoBarras.Visible = true;
        }
        else
        {
            this.LblCodigoBarras.Visible = false;
        }      
        
        if (nrodoc != null)
        {           
            this.HFSticker.Value = nrodoc;
            this.LblCodigoBarras.Text = HFSticker.Value;
            this.LblCodigoBarras.Text = HFSticker.Value;

            if (GrupoPadre == "1")
            {
                DataTable DTRadSticker;
                DTRadSticker = Sticker.GetRadicadoSticker(Grupo, Convert.ToInt32(nrodoc));
                Fecha = Convert.ToDateTime(DTRadSticker.Rows[0]["WFMovimientoFecha"]);
                //this.LblCliente.Text = DTRadSticker.Rows[0]["Empresa"].ToString();
                this.LblCliente.Text = "Mutual SER EPS-S";
                this.LblStickercargarA.Text = "  " + DTRadSticker.Rows[0]["DependenciaNombre"].ToString();
                //this.LblStickerFecRad.Text = " " + DTRadSticker.Rows[0]["WFMovimientoFecha"].ToString();
                this.LblStickerFecRad.Text = " " + Fecha.Day + "/" + Fecha.Month + "/" + Fecha.Year;
                this.Label17.Text = " " + Fecha.TimeOfDay;
                //TramiteDependencia = "  " + DTRadSticker.Rows[0]["DependenciaNombre"].ToString();
                //TramiteProcedencia = " " + DTRadSticker.Rows[0]["ProcedenciaNombre"].ToString();
                //this.LblStickercargarA.Text = TramiteDependencia;
                //this.LabelProcedencia.Text = TramiteProcedencia;
                this.Label18.Text = " " + DTRadSticker.Rows[0]["ProcedenciaNombre"].ToString();
                this.LblStickerNroRad.Text = DTRadSticker.Rows[0]["RadicadoCodigo"].ToString();
                this.LblStickerUsr.Text = DTRadSticker.Rows[0]["NombresUsuario"].ToString();
                this.Label19.Text = " " + DTRadSticker.Rows[0]["RadicadoAnexo"].ToString(); 
                this.Label2.Visible = false;
                this.Label4.Visible = false;
                this.Label5.Visible = false;
                this.LblDireccion.Visible = false;
                this.Label8.Text = "Radicado No: ";
                this.Label1.Text = "Fecha: ";
                this.Label6.Text = "Hora: ";
                this.LabelProcedencia.Text = "Origen: ";

                //LOG ACCESO
                string ActLogCod = "ACCESO";
                DateTime Fechain = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                string Datosini = "STICKER RAD";
                string Datosfin1 = " Cliente:" + LblCliente.Text + " | " + " Fecha:" + LblStickerFecRad.Text + " | " + " Hora:" + Label17.Text + " | " + " Folios:" + Label19.Text + " | " + " Radicado:" + LblStickerNroRad.Text + " | " + " Procedencia:" + Label18.Text + " | " + " Cargar A:" + LblStickercargarA.Text;
                string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                DateTime FechaFin = DateTime.Now;
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Insert log Acceso a sticker
                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Acceso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                Acceso.InsertStickerLog(LogId, username, Fechain, ActLogCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
                //Actualiza Consecutivo
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
               
            }
            else if (GrupoPadre == "2")
            {
                DataTable DTRegSticker;
                DTRegSticker = Sticker.GetRegistroSticker(Grupo, Convert.ToInt32(nrodoc));
                            
                this.Label8.Text = "Registro No: ";
                this.Label1.Text = "Fecha: ";
                this.Label6.Text = "Hora: ";
                this.LabelProcedencia.Visible = false;
                this.Label18.Visible = false;
                this.pnlProcedencia.Visible = false;

                if (DTRegSticker.Rows.Count!=0)
                {
                    if (DTRegSticker.Rows[0]["RegistroTipo"].ToString() == "0")
                    {
                        this.LblStickercargarA.Text = DTRegSticker.Rows[0]["ProcedenciaNombre"].ToString();
                        this.LblDireccion.Text = DTRegSticker.Rows[0]["ProcedenciaDireccion"].ToString();
                        this.Label5.Text = DTRegSticker.Rows[0]["CiudadNombre"].ToString().ToUpper() + "-" + DTRegSticker.Rows[0]["DepartamentoNombre"].ToString();
                        // 
                    }
                    else if (DTRegSticker.Rows[0]["RegistroTipo"].ToString() == "1")
                    {
                        this.Label2.Visible = false;
                        this.LblDireccion.Visible = false;
                        this.Label4.Visible = false;
                        this.Label5.Visible = false;
                        this.LblStickercargarA.Text = DTRegSticker.Rows[0]["DependenciaNombre"].ToString();

                    }
                    this.LblCliente.Text = DTRegSticker.Rows[0]["Empresa"].ToString();
                    this.Label19.Text = " " + DTRegSticker.Rows[0]["AnexoExtRegistro"].ToString();
                    Fecha = Convert.ToDateTime(DTRegSticker.Rows[0]["WFMovimientoFecha"].ToString().ToUpper());
                    //this.LblStickerFecRad.Text =" " + DTRegSticker.Rows[0]["WFMovimientoFecha"].ToString();
                    this.LblStickerFecRad.Text = " " + Fecha.Day + "/" + Fecha.Month + "/" + Fecha.Year;
                    this.Label17.Text = " " + Fecha.TimeOfDay;
                    this.LblStickerNroRad.Text = DTRegSticker.Rows[0]["RegistroCodigo"].ToString();

                    this.LblStickerUsr.Text = DTRegSticker.Rows[0]["NombresUsuario"].ToString();
                    if (this.LblStickerUsr.Text == "")
                    {
                        this.LblStickerUsr.Text = User.Identity.Name;
                    }
                    //LOG PARA STICKER REG EXTERNO
                    string ActLogCod = "ACCESO";
                    DateTime Fechain = DateTime.Now;
                    //OBTENER CONSECUTIVO DE LOGS
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                    Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                    DataRow[] fila = Conse.Select();
                    string x = fila[0].ItemArray[0].ToString();
                    string LOG = Convert.ToString(x);
                    string Datosiniciales = "STICKER REG ";
                    string Datosfin1 = " Cliente:" + LblCliente.Text + " | " + " Fecha:" + LblStickerFecRad.Text + " | " + " Hora:" + Label17.Text + " | " + " Folios:" + Label19.Text + " | " + " Radicado:" + LblStickerNroRad.Text + " | " + " Destino:" + LblStickercargarA.Text + " | " + " Ciudad:" + Label5.Text;
                    string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                    DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                    string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                    DateTime FechaFin = DateTime.Now;
                    Int64 LogId = Convert.ToInt64(LOG);
                    string IP = Session["IP"].ToString();
                    string NombreEquipo = Session["Nombrepc"].ToString();
                    System.Web.HttpBrowserCapabilities nav = Request.Browser;
                    string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                    //Insert log Acceso a sticker reg externo
                    DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Acceso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                    Acceso.InsertStickerLog(LogId, username, Fechain, ActLogCod, ModuloLog, Datosiniciales, Datosfin1, IP, NombreEquipo, Navegador);
                    //Actualiza consecutivo
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                }
                else
                {

                }

            }
        }
        }
        catch (Exception error)
        {
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al acceder sticker  " + error;
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
