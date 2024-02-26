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
using DevExpress.Utils;
using System.IO;
using DevExpress.XtraCharts;
using DevExpress.XtraExport;
using System.Drawing;
using DevExpress.Web;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxCallbackPanel;
using log4net;
//using System.Drawing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;


public partial class _DocRecibido : System.Web.UI.Page 
{
	string GrupoCod = "1";
    string ModuloLog = "Consultas";
    string ConsecutivoCodigo = "1";
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
            // System.Net.IPHostEntry hostEntry = Dns.GetHostEntry(Session["IP"].ToString());
            // Dns.BeginGetHostEntry(Request.UserHostAddress, new AsyncCallback(GetHostNameCallBack), Request.UserHostAddress);
			
         try
            {    
                if (!IsPostBack)
                    {
                        DDLOtros.SelectedValue = null;
                        this.AccordionPane3.Visible = false;
                        this.AccordionPane2.Visible = true;
                    }
                    else
                    { 
             
                    }
                   
            }
         catch (Exception Error)
            {
            this.ExceptionDetails.Text = "Problema" + Error;
            }
    }
	// public void GetHostNameCallBack(IAsyncResult asyncResult)
    // {
        // string userHostAddress = (string)asyncResult.AsyncState;
        // System.Net.IPHostEntry hostEntry = System.Net.Dns.EndGetHostEntry(asyncResult);
        // Session["Nombrepc"] = hostEntry.HostName;
        // // tenemos el nombre del equipo cliente en hostEntry.HostName
    // }
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
    protected void ChBExpediente_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBExpediente.Checked == true)
        {
            this.LblExpediente.Visible = true;
            this.TxtBExpediente.Visible = true;
        }
        else
        {
            this.LblExpediente.Visible = false;
            this.TxtBExpediente.Visible = false;
            this.TxtBExpediente.Text = "";
        }
    }
    protected void ChBMedio_CheckedChanged(object sender, EventArgs e)
    {
         if (ChBMedio.Checked == true)
        {
            this.LblMedio.Visible = true;
            this.TxtBMedio.Visible = true;
        }
        else
        {
            this.LblMedio.Visible = false;
            this.TxtBMedio.Visible = false;
            this.TxtBMedio.Text = "";
        }
    }
    protected void ChBNaturaleza_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBNaturaleza.Checked == true)
        {
            this.LblNaturaleza.Visible = true;
            this.TxtBNaturaleza.Visible = true;
        }
        else
        {
            this.LblNaturaleza.Visible = false;
            this.TxtBNaturaleza.Visible = false;
            this.TxtBNaturaleza.Text = "";
        }
    }
    protected void ChBOtros_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBOtros.Checked == true)
        {
            this.LblBuscarPor.Visible = true;
            this.TxtBOtros.Visible = true;
            this.DDLOtros.Visible = true;
        }
        else
        {
            this.LblBuscarPor.Visible = false;
            this.TxtBOtros.Visible = false;
            this.TxtBOtros.Text = "";
            this.DDLOtros.Visible = false;
        }
    }
    protected void TreeVExpediente_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVExpediente.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVExpediente.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void TreeVExpediente_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVExpediente.SelectedNode == null)
        {
            ArbolesBLL ObjArbolExp = new ArbolesBLL();
            DSExpedienteSQL.ExpedienteByTextDataTable DTExpediente = new DSExpedienteSQL.ExpedienteByTextDataTable();
            DTExpediente = ObjArbolExp.GetExpedienteTree(e.Node.Value);
            PopulateNodes(DTExpediente, e.Node.ChildNodes,"ExpedienteCodigo","ExpedienteNombre");
        }
    }
   protected void TreeVMedio_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVMedio.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVMedio.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void TreeVMedio_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVMedio.SelectedNode == null)
        {
            ArbolesBLL ObjArbolMed = new ArbolesBLL();
            DSMedioSQL.MedioByTextDataTable DTMedio = new DSMedioSQL.MedioByTextDataTable();
            DTMedio = ObjArbolMed.GetMedioTree(Int32.Parse(e.Node.Value));
            PopulateNodes(DTMedio, e.Node.ChildNodes, "MedioCodigo", "MedioNombre");
        }
    }
    protected void TreeVNaturaleza_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVNaturaleza.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVNaturaleza.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void TreeVNaturaleza_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVNaturaleza.SelectedNode == null)
        {
            ArbolesBLL ObjArbolNat = new ArbolesBLL();
            DSNaturalezaSQL.NaturalezaByTextDataTable DTNaturaleza = new DSNaturalezaSQL.NaturalezaByTextDataTable();
            DTNaturaleza = ObjArbolNat.GetNaturalezaTree(e.Node.Value);
            PopulateNodes(DTNaturaleza, e.Node.ChildNodes, "NaturalezaCodigo", "NaturalezaNombre");
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
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
		DateTime FechaInicio = DateTime.Now;
        string ActLogCod = "CONSULTAR";
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////

        string lotros = "";
        string dt_qw = "";
        try
        {
            if (DDLOtros.SelectedValue == "Detalle" || DDLOtros.SelectedValue == String.Empty)
        {
            this.ODSBuscarGraph.SelectParameters["RadicadoDetalle"].DefaultValue = this.TxtBOtros.Text;
            lotros += "Detalle:" + TxtBOtros.Text;
        }
        else if (DDLOtros.SelectedValue == "NroExterno")
        {
            this.ODSBuscarGraph.SelectParameters["RadicadoNumeroExterno"].DefaultValue = this.TxtBOtros.Text;
            lotros += "NroExterno:" + TxtBOtros.Text;
        }
        else if (DDLOtros.SelectedValue == "Anexo")
        {
            this.ODSBuscarGraph.SelectParameters["RadicadoAnexo"].DefaultValue = this.TxtBOtros.Text;
            lotros += "Anexo:" + TxtBOtros.Text;
        }
        else if (DDLOtros.SelectedValue == "NúmerodeGuía")
        {
            this.ODSBuscarGraph.SelectParameters["RadicadoGuia"].DefaultValue = this.TxtBOtros.Text;
            lotros += "NúmerodeGuía:" + TxtBOtros.Text;
        }

        this.ODSBuscarGraph.SelectParameters["WFMovimientoFecha"].DefaultValue = this.TxtFechaInicial.Text;
        this.ODSBuscarGraph.SelectParameters["WFMovimientoFecha1"].DefaultValue = this.TxtFechaFinal.Text;
        this.ODSBuscarGraph.SelectParameters["RadicadoCodigo"].DefaultValue = this.TxtNroRadInicial.Text;
        this.ODSBuscarGraph.SelectParameters["RadicadoCodigo1"].DefaultValue = this.TxtNroRadFinal.Text;
        this.ODSBuscarGraph.SelectParameters["ExpedienteCodigo"].DefaultValue = this.TxtBExpediente.Text;
        this.ODSBuscarGraph.SelectParameters["ProcedenciaCodigo"].DefaultValue = this.TxtBProcedencia.Text;
        this.ODSBuscarGraph.SelectParameters["ProcedenciaNombre"].DefaultValue = this.TxtBProcedencia.Text;
        this.ODSBuscarGraph.SelectParameters["MedioCodigo"].DefaultValue = this.TxtBMedio.Text;
        this.ODSBuscarGraph.SelectParameters["DependenciaCodDestino"].DefaultValue = this.TxtBDestino.Text;
        this.ODSBuscarGraph.SelectParameters["DependenciaNomDestino"].DefaultValue = this.TxtBDestino.Text;
        this.ODSBuscarGraph.SelectParameters["DependenciaConsulta"].DefaultValue = Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();
        this.ODSBuscarGraph.SelectParameters["NaturalezaCodigo"].DefaultValue = this.TxtBNaturaleza.Text;
        this.ODSBuscarGraph.SelectParameters["NaturalezaNombre"].DefaultValue = this.TxtBNaturaleza.Text;


        if (this.RBLTblRpt.SelectedValue == "1")
        {
            this.AccordionPane2.Visible = true;
            this.AccordionPane3.Visible = false;

            ASPxGridView1.DataSourceID = "ODSBuscarGraph";
            ReportViewer1.LocalReport.DataSources[0].DataSourceId = "";
            ASPxGridView1.DataBind();
			
			// Siguiente codigo para duplicar la información del Datasource   -- JUAN FIGUEREDO 23-SEP-2020
				DataTable dt = new DataTable();
                List<string> dataColumnNames = new List<string>();
                foreach (GridViewColumn item in ASPxGridView1.Columns)
                {
                    GridViewEditDataColumn dataColumn = item as GridViewEditDataColumn;
                    if (dataColumn != null)
                    {
                        dt.Columns.Add(dataColumn.FieldName);
                        dataColumnNames.Add(dataColumn.FieldName);
                    }
                }
                for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
                {
                    object[] rowValues = ASPxGridView1.GetRowValues(i, dataColumnNames.ToArray()) as object[];
                    dt.Rows.Add(rowValues);
                }
                Session["DatosGrid"] = dt;
			//Fin duplicado de informacion datasource, se utilizará posteriormente para Generar Excel en .Xlsx
        }
        else
        {
            ASPxGridView1.DataSourceID = "";
            this.AccordionPane3.Visible = true;
            this.AccordionPane2.Visible = false;

            ReportViewer1.LocalReport.DataSources[0].DataSourceId = "ODSBuscarGraph";
            //Microsoft.Reporting.WebForms.ReportDataSource RDS = new Microsoft.Reporting.WebForms.ReportDataSource();
            //RDS.Name = ODSBuscarGraph.ToString();
            //RDS.Value = ODSBuscarGraph.Select();
            //this.ReportViewer1.LocalReport.DataSources.Add(RDS);
            this.ReportViewer1.DataBind();
        }
       
        this.MyAccordion.SelectedIndex = 1;
            

            /*Registrar el evento de busqueda*/
        String Ip_cliente = Context.Request.UserHostAddress;
        //String Uri_OrigRef = Context.Request.UrlReferrer.OriginalString;

        log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


         String Log= Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + " | " + Profile.UserName.ToString() + " | "  + this.TxtFechaInicial.Text + " - " + this.TxtFechaFinal.Text + " | " + this.TxtNroRadInicial.Text+ " | "+
                this.TxtNroRadFinal.Text + " - " + this.TxtNroRadFinal.Text + " | " + value_pipe(this.TxtBExpediente.Text) + " | " +
                value_pipe(TxtBProcedencia.Text) + " | " + value_pipe(TxtBMedio.Text) + " | " + value_pipe(TxtBDestino.Text) + " | "  +
                Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + " | " + value_pipe(TxtBNaturaleza.Text) + " | " + lotros;
				
            //OBTENER CONSECUTIVO LOG
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            string Datosfin = Log;
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string username = Profile.UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Insert de log buscar recibidos
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter ConsultaRadicado = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            ConsultaRadicado.InsertConsulta(LogId, username, FechaInicio, ActLogCod, GrupoCod, ModuloLog, Datosfin, FechaFin, IP, NombreEquipo, Navegador);
            //Se hace el consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);


        //ILog logger = LogManager.GetLogger("primerEjemplo");
        logger.Fatal(Ip_cliente +" "+ Log); 
            
        //logger.Debug("Mensaje de nivel DEBUG");
        //logger.Info("Mensaje de nivel INFO");
        //logger.Warn("Mensaje de nivel WARN");
        //logger.Error("Mensaje de nivel ERROR");
        //logger.Fatal("Mwnsaje de nivel FATAL"); 

            //rutinas r1 = new rutinas();
           //// DataTable t1 = r1.rtn_registrar_log("0", UserId, "5",
           //     this.TxtFechaInicial.Text + "?" + this.TxtFechaFinal.Text + "?" + this.TxtNroRadInicial.Text+ "?"+
           //     this.TxtNroRadFinal.Text + "?" + this.TxtNroRadFinal.Text + "?" + value_pipe(this.TxtBExpediente.Text) + "?" +
           //     value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBMedio.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" +
           //     Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + "?" + value_pipe(TxtBNaturaleza.Text) + "?" + lotros
           //     , "1");
            

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
			//Variables de LOG ERROR
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al consultar Doc Recibido " + ExceptionDetails.Text;
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


    /*Prodecimiento para devolver el id de un campo si este contiene separadores*/

    protected string value_pipe(string val_1)
    {
        string res = "";
        if (val_1 != "" && val_1 != null)
        {
            if (val_1.Contains(" | "))
            {
                res = val_1.Remove(val_1.IndexOf(" | "));
            }
            else
            {
                res = val_1;
            }
        }
        return res;
    }

    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        
    }
    protected void GVBuscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //RadicadoBLL ObjConsultaRad = new RadicadoBLL();
        //DSRadicado.Radicado_ConsultasRadicadoDataTable ConsultaRadicado = new DSRadicado.Radicado_ConsultasRadicadoDataTable();
        //if (DDLOtros.SelectedValue == "")
        //    ConsultaRadicado = ObjConsultaRad.GetConsultasRadicado(this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRadInicial.Text, this.TxtNroRadFinal.Text, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, null, null, null, this.TxtBNaturaleza.Text);
        //else if (DDLOtros.SelectedValue == "Detalle")
        //    ConsultaRadicado = ObjConsultaRad.GetConsultasRadicado(this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRadInicial.Text, this.TxtNroRadFinal.Text, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, this.TxtBOtros.Text.ToString(), null, null, this.TxtBNaturaleza.Text);
        //else if (DDLOtros.SelectedValue == "NroExterno")
        //    ConsultaRadicado = ObjConsultaRad.GetConsultasRadicado(this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRadInicial.Text, this.TxtNroRadFinal.Text, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, null, this.TxtBOtros.Text.ToString(), null, this.TxtBNaturaleza.Text);
        //else if (DDLOtros.SelectedValue == "Anexo")
        //    ConsultaRadicado = ObjConsultaRad.GetConsultasRadicado(this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRadInicial.Text, this.TxtNroRadFinal.Text, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, null, null, this.TxtBOtros.Text.ToString(), this.TxtBNaturaleza.Text);
        //GVBuscar.DataSource = ConsultaRadicado;
        //this.GVBuscar.PageIndex = e.NewPageIndex;
        //this.GVBuscar.DataBind();
    }    
   
    protected void LinkButton1_Click(object sender, EventArgs e)
    { 
       
        //String RadicadoCodigo = GVBuscar.DataKeys[dato1].Value.ToString();
        ////String RadicadoCodigo = GVBuscar.SelectedDataKey.Value.ToString();
        ////String RadicadoCodigo = this.GVBuscar.SelectedValue.ToString();
        //Session["NroDoc"] = "1" + RadicadoCodigo;
        //Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx");
    }
    protected void ButtonOpen_Click(object sender, EventArgs e)
    {
        Export(false);
    }
    protected void ButtonSaveAs_Click(object sender, EventArgs e)
    {
        Export(true);
    }
    protected void Export(Boolean saveAs)
    {
        DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint();
        MemoryStream stream = new MemoryStream();
        String contentType = "";
        String fileName = "";

		try
        {

			int caseSwitch = 1;
			if (this.listExportFormat.SelectedIndex != 1)
			{
			switch (this.listExportFormat.SelectedIndex)
			{
				case 0:
					//contentType = "application/ms-excel";
					//fileName = "PivotGrid.xls";
					//this.ASPxGridViewExporter1.WriteXls(stream);
				case 1:
					contentType = "application/ms-excel";
					fileName = "PivotGrid.xls";
					this.ASPxGridViewExporter1.WriteXls(stream);
					break;
				case 2:
					contentType = "text/enriched";
					fileName = "PivotGrid.rtf";
					this.ASPxGridViewExporter1.WriteRtf(stream);
					break;
				case 3:
					contentType = "text/plain";
					fileName = "PivotGrid.txt";
					this.ASPxGridViewExporter1.WriteCsv(stream);
					break;
			}
			Byte[] buffer = stream.GetBuffer();
			// Dim buffer() As Byte = stream.GetBuffer()

			String disposition;
			if (saveAs)
			{
				disposition = "attachment";
			}
			else
			{
				disposition = "inline";
			}
			if(listExportFormat.SelectedIndex!=-1)
			 {  
			Response.Clear();
			Response.Buffer = false;
			Response.AppendHeader("Content-Type", contentType);
			Response.AppendHeader("Content-Transfer-Encoding", "binary");
			Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
			Response.BinaryWrite(buffer);
			Response.End();
			}
			}
			else //   Generar Excel en formato .xlsx  -- JUAN FIGUEREDO 28-AGO-2020
				{
					string NombreArchivo = "Reporte" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".xlsx";
					string name = AppDomain.CurrentDomain.BaseDirectory + "Excel.xlsx";
					SLDocument osldocument = new SLDocument();

					SLStyle style = new SLStyle();
					style.Font.FontSize = 12;
					style.Font.Bold = true;
					SLStyle styleCOL = new SLStyle();

					DataTable dt = new DataTable();
					dt = (DataTable)Session["DatosGrid"];

					int ic = 1;
					foreach (DataColumn column in dt.Columns)
					{
						osldocument.SetCellStyle(1, ic, style);
						osldocument.SetColumnWidth(ic, 20);
						if (ic == 2) { column.ColumnName = "FechaRadicacion"; }
						if (ic == 8){column.ColumnName = "Destino";}
						ic++;
					}

					osldocument.ImportDataTable(1, 1, dt, true);
					//osldocument.SaveAs(pathfile);
					Response.Clear();
					Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
					//this.ASPxGridViewExporter1.WriteXls(stream);
					Response.AddHeader("Content-Disposition", "attachment; filename=" + NombreArchivo);
					osldocument.SaveAs(Response.OutputStream);
					Response.End();
					Session["DatosGrid"] = null;

				}
		}
		catch (Exception error)
        {
            this.ExceptionDetails.Text = "Se ha presentado un problema, por favor intente nuevamente o en su defecto realice una consulta con menor cantidad de registros.  " + error;
        }
    }
        
    protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        //if (e.RowType == GridViewRowType.Filter) 
        //{ 
      
        //}
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
           // Int32 Radicado = (Int32)e.GetValue("RadicadoCodigo");
            String ExpedienteCodigo = (String)e.GetValue("ExpedienteCodigo");
            String GrupoCodigo = (String)e.GetValue("GrupoCodigo");

            GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["RadicadoCodigo"] as GridViewDataColumn;
            GridViewDataColumn colOps =
                ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
            GridViewDataColumn colRpta =
                ((ASPxGridView)sender).Columns["Rpta"] as GridViewDataColumn;

            HyperLink NroDoc = 
                (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRad, "HyperLink1");
            NroDoc.Attributes.Add("onClick", "url(event,1);");

            HyperLink HprVisor =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HyperLinkVisor");
            HprVisor.Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",1);");

            HyperLink HprHisto =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkHisExtven");
            HprHisto.Attributes.Add("onClick", "Historico(event," + NroDoc.Text + ",1);");

            HyperLink HprExp =
          (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkExp");
            HprExp.Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + ExpedienteCodigo + "'," + GrupoCodigo + ");");
            
            System.Web.UI.WebControls.Image ImgRpta =
          (System.Web.UI.WebControls.Image)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRpta, "Image1");

            Label LabelResuesta =
          (Label)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRpta, "Label6");

                       
            if (LabelResuesta.Text == "0")
            {              
                ImgRpta.Visible = false;
            }
            else if (Convert.ToInt32(LabelResuesta.Text) > 0)
            {
                ImgRpta.Visible = true;
               
            }
        }           
    }


    protected void callbackPanel_Callback(object source, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {
        
        litText.Text = GetNotes(e.Parameter).ToString();
    }
    object GetNotes(string id)
    {
        DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter DSRadFuenteReg = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteRegistroTableAdapter();
        DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable DTRadFuenteReg = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroDataTable();
        DTRadFuenteReg = DSRadFuenteReg.GetRegistrosRadicadoFuente(Convert.ToInt32(id), "1");

        int i = 1;
        foreach (DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteRegistroRow DRRadFuenteReg in DTRadFuenteReg.Rows)
        {
            HyperLink HprRpta = new HyperLink();
            HprRpta.ID = "HprRpta" + i.ToString();
            HprRpta.Text = DRRadFuenteReg.RegistroCodigo.ToString();
            HprRpta.Target = "_Blank";
            HprRpta.ForeColor = System.Drawing.Color.Blue;
            HprRpta.Font.Underline = true;
            HprRpta.Visible = true;
            HprRpta.Attributes.Add("onClick", "urlInt(event," + DRRadFuenteReg.GrupoRegistroCodigo + ");");

            callbackPanel.Controls.Add(HprRpta);
            callbackPanel.Controls.Add(new LiteralControl("&nbsp;"));
            System.Web.UI.WebControls.Image ImgRpta = new System.Web.UI.WebControls.Image();
            ImgRpta.ID = "ImgRpta" + i.ToString();
            ImgRpta.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.JPG";
            ImgRpta.Attributes.Add("onClick", "VImagenesReg(event," + DRRadFuenteReg.RegistroCodigo + ","+DRRadFuenteReg.GrupoRegistroCodigo+");");
            callbackPanel.Controls.Add(ImgRpta);
            callbackPanel.Controls.Add(new LiteralControl("<br />"));
            i += 1;
        }
        //Image1.Visible = true;
        //Panel popup = ((Panel)e.Row.FindControl("popup"));
                      
        return "";
    }    

}
      
