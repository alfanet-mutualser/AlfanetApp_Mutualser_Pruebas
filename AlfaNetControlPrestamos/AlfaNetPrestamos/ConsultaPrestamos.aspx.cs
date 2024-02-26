
using System;
using ASP;
using Microsoft;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSRadicadoTableAdapters;
using DSGrupoSQLTableAdapters;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;
using System.Collections.Generic;
using AjaxControlToolkit;
using System.Text;
using Microsoft.Reporting.WebForms;
using System.Net;
using System.Net.NetworkInformation;

public partial class _ConsultaPrestamos : System.Web.UI.Page 
{
    string ModuloLog = "Prestamos CONSULTA";
    string ConsecutivoCodigo = "11";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "ERROR";

    protected void Page_Load(object sender, EventArgs e)
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    String IPAdd = string.Empty;
                    IPAdd = Request.ServerVariables["HTTP_X_FORWARDER_FOR"];
                    if (String.IsNullOrEmpty(IPAdd))
                    {
                        IPAdd = Request.ServerVariables["REMOTE_ADDR"];
                        localIP = IPAdd.ToString();
                        Session["IP"] = localIP;
                    }
                }
            }
            Session["Nombrepc"] = host.HostName.ToString();

         try
            {
                if (!IsPostBack)
                    {
                        this.TreeVDependencia.Attributes["onClick"] = "return OnTreeClick(event);";
                        this.TreeVSerie.Attributes["onClick"] = "return OnTreeSerieClick(event);";

                        // Creo una colección de parámetros de tipo ReportParameter 
                        // para añadirlos al control ReportViewer.

                        List<ReportParameter> parametros = new List<ReportParameter>();
                        // Añado los parámetros necesarios.
                        parametros.Add(new ReportParameter("Fecha", DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString()));
                        // Añado el/los parámetro/s al ReportViewer.
                        this.ReportViewer1.LocalReport.SetParameters(parametros);

                        // Creo uno o varios parámetros de tipo ReportParameter con sus valores.
                        ReportParameter parametro = new ReportParameter("Fecha", DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
                        // Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                        this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

                        //this.ReportViewer1.AsyncRendering = false;
                        //this.ReportViewer1.LocalReport.Refresh();

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
                        int NumeroDocumento = Convert.ToInt32("0");
                        string Datosini = "Acceso a modulo";
                        string Datosfin1 = " Consulta de Prestamos ";
                        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                        string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                        DateTime FechaFin = DateTime.Now;
                        Int64 LogId = Convert.ToInt64(LOG);
                        string IP = Session["IP"].ToString();
                        string NombreEquipo = Session["Nombrepc"].ToString();
                        System.Web.HttpBrowserCapabilities nav = Request.Browser;
                        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                        //insert log acceso consulta prestamo
                        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Acceso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                        Acceso.InsertPrestamosLog(LogId, username, Fechain, ActLogCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
                        // Actualiza consecutivo
                        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                        ConseLogs.GetConsecutivos(ConsecutivoCodigo);


                    }
                    else
                    {
                        return;
                    }
                   
            }
         catch (Exception Error)
            {
                this.ExceptionDetails.Text = "Problema" + Error;
                //Variables de LOG ERROR
                DateTime FechaInicio = DateTime.Now;
                string grupoo = "";
                //OBTENER CONSECUTIVO DE LOGS
                string DatosFinales = "Error al acceder a consulta prestamos  " + Error;
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
    protected void ChBFechaRad_CheckedChanged(object sender, EventArgs e)
    {
          if (ChBFechaRad.Checked == true)
               {
              this.LblFechaFinal.Visible = true;
              this.LblFechaInicial.Visible = true;
              this.TxtFechaFinal.Visible = true;
              this.TxtFechaInicial.Visible = true;
              this.ImgCalendarFinal.Visible = true;
              this.ImgCalendarInicial.Visible = true;
                }
          else
               {
                   this.LblFechaFinal.Visible = false;
                   this.LblFechaInicial.Visible = false;
                   this.TxtFechaFinal.Visible = false;
                   this.TxtFechaInicial.Visible = false;
                   this.TxtFechaFinal.Text = "";
                   this.TxtFechaInicial.Text = "";
                   this.ImgCalendarFinal.Visible = false;
                   this.ImgCalendarInicial.Visible = false;
               }
    }
    protected void ChBNroRad_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBNroRad.Checked == true)
        {
            this.LblNroRadFinal.Visible = true;
            this.LblNroRadInicial.Visible = true;
            this.TxtNroRadFinal.Visible = true;
            this.TxtNroRadInicial.Visible = true;
            
        }
        else
        {
            this.LblNroRadFinal.Visible = false;
            this.LblNroRadInicial.Visible = false;
            this.TxtNroRadFinal.Visible = false;
            this.TxtNroRadInicial.Visible = false;
            this.TxtNroRadFinal.Text = "";
            this.TxtNroRadInicial.Text = "";
        }
    }
    protected void ChBDestino_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBDestino.Checked == true)
        {
            this.LblDestino.Visible = true;
            this.TxtBDestino.Visible = true;
        }
        else
        {      
            this.LblDestino.Visible= false;
            this.TxtBDestino.Visible = false;
            this.TxtBDestino.Text =""; 
        }
    }
    protected void ChBProcedencia_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBProcedencia.Checked == true)
        {
            this.LblProcedencia.Visible = true;
            this.TxtBProcedencia.Visible = true;
        }
        else
        {
            this.LblProcedencia.Visible = false;
            this.TxtBProcedencia.Visible = false;
            this.TxtBProcedencia.Text = "";
        }
    }
  
    protected void TreeVDependencia_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVDependencia.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVDependencia.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            //dr["title"].ToString();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(  0 );";
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            //PrestamosBLL ObjConsultaPrestamos = new PrestamosBLL();
            //DSPrestamos.PrestamosDataTable DTPrestamos = new DSPrestamos.PrestamosDataTable();
            
            //DTPrestamos = ObjConsultaPrestamos.GetConsultasPrestamos(this.TxtNroRadInicial.Text, this.TxtNroRadFinal.Text, this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtBDestino.Text, this.TxtBProcedencia.Text);

            this.ODSBuscar.SelectParameters["WFMovimientoFecha"].DefaultValue = this.TxtFechaInicial.Text;
            this.ODSBuscar.SelectParameters["WFMovimientoFecha1"].DefaultValue = this.TxtFechaFinal.Text;
            this.ODSBuscar.SelectParameters["PrestamoCodigo"].DefaultValue = this.TxtNroRadInicial.Text;
            this.ODSBuscar.SelectParameters["PrestamoCodigo1"].DefaultValue = this.TxtNroRadFinal.Text;
            this.ODSBuscar.SelectParameters["SerieCodigo"].DefaultValue = this.TxtBProcedencia.Text;
            this.ODSBuscar.SelectParameters["DependenciaCodigo"].DefaultValue = this.TxtBDestino.Text;
    
            Microsoft.Reporting.WebForms.ReportDataSource RDS = new Microsoft.Reporting.WebForms.ReportDataSource();
            RDS.Name = ODSBuscar.ToString();
            RDS.Value = ODSBuscar.Select();
            this.ReportViewer1.LocalReport.DataSources.Add(RDS);
            this.ReportViewer1.DataBind();
            
            //GVBuscar.DataSource = DTPrestamos;
            GVBuscar.Visible = true;
            GVBuscar.DataBind();
            this.MyAccordion.SelectedIndex = 1;

            //LOG CONSULTA
            string ActLogCod = "CONSULTAR";
            DateTime Fechain = DateTime.Now;
            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            int NumeroDocumento = Convert.ToInt32("0");
            string Datosini = "";
            //Fecha Ini + Fecha Fin + NumRadInicial + NumRadFinal + Dependencia + Serie
            string Datosfin1 = TxtFechaInicial.Text + " | " + TxtFechaFinal.Text + " | " + TxtNroRadInicial.Text + " | " + " | " + TxtNroRadFinal.Text + " | " + TxtBProcedencia.Text + " | " + " | " + TxtBDestino.Text;
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Insert log de consulta  consultaprestamo
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Consulta = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            Consulta.InsertPrestamosLog(LogId, username, Fechain, ActLogCod, ModuloLog, Datosini, Datosfin1, IP, NombreEquipo, Navegador);
            //Actualiaz consecutivo
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al acceder a consulta prestamos  " + Error;
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
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        
    }
    protected void GVBuscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PrestamosBLL ObjConsultaPrestamos = new PrestamosBLL();
        DSPrestamos.PrestamosDataTable DTPrestamos = new DSPrestamos.PrestamosDataTable();

        DTPrestamos = ObjConsultaPrestamos.GetConsultasPrestamos(this.TxtNroRadInicial.Text, this.TxtNroRadFinal.Text, this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtBDestino.Text, this.TxtBProcedencia.Text);
      
        GVBuscar.DataSource = DTPrestamos;
        this.GVBuscar.PageIndex = e.NewPageIndex;
        this.GVBuscar.DataBind();
    }
    protected void GVBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        int indice = GVBuscar.SelectedIndex;
        string value = GVBuscar.SelectedValue.ToString();
        string Datos = GVBuscar.SelectedDataKey.Value.ToString(); 
        Session["NroDoc"] = "1" + value;
        Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {      
       
    }
    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolSer = new ArbolesBLL();
        DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();

        //DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
        PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
    }
}
      
