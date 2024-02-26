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

public partial class _DesArchivar : System.Web.UI.Page
{
    rutinas ejecutar = new rutinas();
    DateTime FechaIni = DateTime.Now;
    string ModuloLog = "Des-Archivar";
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
            this.DVDocumento.Visible = false;
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
        this.DVDocumento.Visible = true;
        String vGrupoCodigo = this.RadBtnLstFindby.SelectedValue;
		
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

        if (vGrupoCodigo == "0")
        {
            this.CiudadByIdDataSource.SelectParameters["GrupoCodigo"].DefaultValue = "2";
            string ConsecutivoCodigo = "3";
                DateTime WFMovimientoFecha = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                int NumeroDocumento = Convert.ToInt32(TxtDocumento.Text);
                string GrupoCod = "2";
                string Datosini = "";
                //DSWFMOVIMIENTOS
                DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadoTableAdapter archi = new DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadoTableAdapter();
                DSWorkFlow.WFMovimiento_ReadWFMovimientoArchivadoDataTable tabl = new DSWorkFlow.WFMovimiento_ReadWFMovimientoArchivadoDataTable();
                tabl = archi.GetMovimientoArchivado(GrupoCod, TxtDocumento.Text);
                DataRow[] rows = tabl.Select();
                string DepCodigo = rows[0].ItemArray[7].ToString();
                string DepNombre = rows[0].ItemArray[6].ToString();
                string Accion = rows[0].ItemArray[9].ToString();
                string Detalle = rows[0].ItemArray[10].ToString();
                string SerieCod = rows[0].ItemArray[11].ToString();
                string SerieNombre = rows[0].ItemArray[12].ToString();
                //Num Doc+ DependenciaCod + DependenciaNombre+ Accion +Detalle + SerieCod +SerieNomnbrw
                string Datosfin1 = TxtDocumento.Text + " | " + DepCodigo + " | " + DepNombre + " | " + Accion + " | " +Detalle + " | " +SerieCod  +" | " + SerieNombre;
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
                //Se hace insert de log buscar des-archivar
                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Acceder = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                Acceder.InsertEnviados(LogId,username,WFMovimientoFecha,ActLogCod,NumeroDocumento,GrupoCod,ModuloLog,Datosini,Datosfin1,FechaFin,IP,NombreEquipo, Navegador);
                //Actualizar el consecutivo Log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        else 
        {
            this.CiudadByIdDataSource.SelectParameters["GrupoCodigo"].DefaultValue = "1";
            string ConsecutivoCodigo = "2";
                this.CiudadByIdDataSource.SelectParameters["GrupoCodigo"].DefaultValue = "1";
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
                //DSWFMOVIMIENTOS
                DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadoTableAdapter archi = new DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadoTableAdapter();
                DSWorkFlow.WFMovimiento_ReadWFMovimientoArchivadoDataTable tabl = new DSWorkFlow.WFMovimiento_ReadWFMovimientoArchivadoDataTable();
                tabl = archi.GetMovimientoArchivado(GrupoCod, TxtDocumento.Text);
                DataRow[] rows = tabl.Select();
				string DepCodigo = rows[0].ItemArray[7].ToString();
                string DepNombre = rows[0].ItemArray[6].ToString();
                string Accion = rows[0].ItemArray[9].ToString();
                string Detalle = rows[0].ItemArray[10].ToString();
                string SerieCod = rows[0].ItemArray[11].ToString();
                string SerieNombre = rows[0].ItemArray[12].ToString();
                //Num Doc+ DependenciaCod + DependenciaNombre+ Accion +Detalle + SerieCod +SerieNomnbrw
                string Datosfin1 = TxtDocumento.Text + " | " + DepCodigo + " | " + DepNombre + " | " + Accion + " | " + Detalle + " | " + SerieCod + " | " + SerieNombre;
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
                //insert de Log buscar des+archivar Radicados
                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accede = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                Accede.GetData(LogId,username,WFMovimientoFecha,ActLogCod,NumeroDocumento,GrupoCod,ModuloLog,Datosini,Datosfin1,FechaFin,IP,NombreEquipo,Navegador);
                //Se actualiza consecutivo de Log
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }

        this.CiudadByIdDataSource.SelectParameters["NumeroDocumento"].DefaultValue = this.TxtDocumento.Text;
        this.DVDocumento.ChangeMode(DetailsViewMode.ReadOnly);
        //this.Label3.Visible = true;
        //this.TextBox3.Visible = true;
        this.LinkButton1.Visible = true;
        this.Image5.Visible = true;
        this.Image6.Visible = true;
        this.DVDocumento.DataBind();

            }
        catch (Exception error)
        {
            this.LblMessageBox.Text = "El documento no fue encontrado o ya fue desarchivado, Por favor verifique.";
            this.MPEMensaje.Show();
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string ModuloLog = "DES-ARCHIVAR";
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al Des-Archivar " + error;
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
            //this.Label3.Visible = false;
            //this.TextBox3.Visible = false;
            this.LinkButton1.Visible = true;
            this.ACDocumento.ServiceMethod = "GetDocArchivadosRecibidos";
        }
        if (this.RadBtnLstFindby.SelectedValue.ToString() == "0")
        {
            this.DVDocumento.Visible = false;
            //this.Label3.Visible = false;
            //this.TextBox3.Visible = false;
            this.LinkButton1.Visible = true;
            this.ACDocumento.ServiceMethod = "GetDocArchivadosEnviados";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
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
		
        DataTable DesarchivarExito = new DataTable();
        String vDocumentoCodigo = TxtDocumento.Text;
        String vGrupoCodigo = this.RadBtnLstFindby.SelectedValue;
        string ActLogCod = "ACTUALIZAR";

        if (vGrupoCodigo == "0")
        {
            vGrupoCodigo = "2";
        }
		
		if(vGrupoCodigo == "1")
        {
            //LOG
            string ConsecutivoCodigo = "2";
            this.CiudadByIdDataSource.SelectParameters["GrupoCodigo"].DefaultValue = "1";
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
            //Num Doc+ DependenciaCod + DependenciaNombre+ Accion +Detalle + SerieCod +SerieNomnbrw
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
            //Insert de log actualizar des-archivar recibidos
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            Accediendo.GetData(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
            //Actualizar consecutivo log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        else
        {
            //LOG
            string ConsecutivoCodigo = "3";
            DateTime WFMovimientoFecha = DateTime.Now;
            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            int NumeroDocumento = Convert.ToInt32(TxtDocumento.Text);
            string GrupoCod = "2";
            string Datosini = "";
            //DSWFMOVIMIENTOS
            DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadoTableAdapter archi = new DSWorkFlowTableAdapters.WFMovimiento_ReadWFMovimientoArchivadoTableAdapter();
            DSWorkFlow.WFMovimiento_ReadWFMovimientoArchivadoDataTable tabl = new DSWorkFlow.WFMovimiento_ReadWFMovimientoArchivadoDataTable();
            tabl = archi.GetMovimientoArchivado(GrupoCod, TxtDocumento.Text);
            DataRow[] rows = tabl.Select();
            string DepCodigo = rows[0].ItemArray[7].ToString();
            string DepNombre = rows[0].ItemArray[6].ToString();
            string Accion = rows[0].ItemArray[9].ToString();
            string Detalle = rows[0].ItemArray[10].ToString();
            string SerieCod = rows[0].ItemArray[11].ToString();
            string SerieNombre = rows[0].ItemArray[12].ToString();
            //Num Doc+ DependenciaCod + DependenciaNombre+ Accion +Detalle + SerieCod +SerieNomnbrw
            string Datosfin1 = TxtDocumento.Text + " | " + DepCodigo + " | " + DepNombre + " | " + Accion + " | " + Detalle + " | " + SerieCod + " | " + SerieNombre;
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
            //Insert de Log ACTUALIZAR DESARCHIVAR REGISTROS
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accede = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            Accede.InsertEnviados(LogId, username, WFMovimientoFecha, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog, Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
            //Se actualiza consecutivo de Log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }

        DesarchivarExito = ejecutar.rtn_actualizar_DesarchivarDoc(vDocumentoCodigo, vGrupoCodigo);

        if (DesarchivarExito.Rows.Count != 0)
        {
            this.LblMessageBox.Text = "El Documento: " + TxtDocumento.Text + " Ha sido Desarchivado Correctamente";
            this.MPEMensaje.Show();
        }
        else
        {
            this.LblMessageBox.Text = "Ocurrio un Problema al Intentar DesArchivar el Documento: " + TxtDocumento.Text + " Contacte al Administrador";
            this.MPEMensaje.Show();
        }

        // Despues de DesArchivar.
                
        this.TxtDocumento.Text = "";
        this.CiudadByIdDataSource.SelectParameters["NumeroDocumento"].DefaultValue = "";
        this.DVDocumento.DataBind();
        this.LinkButton1.Visible = false;
        this.Image5.Visible = false;
        this.Image6.Visible = false;
    }

  
}