using System;
using ASP;
using Microsoft;
using Microsoft.Reporting.WebForms;
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
using System.IO;
using DevExpress.Web;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxCallbackPanel;
// Referencias SpreadsheetLigth y DocumentFormat.openXML
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;


public partial class AlfaNetConsultas_Gestion_ConsSeriesLimite : System.Web.UI.Page
{
    string ModuloLog = "Consultas Series Limite";
    string ConsecutivoCodigo = "1";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "ERROR";

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

            if (!IsPostBack)
            {
             // this.DDLOtros.SelectedValue = null;
                ASPxGridView1.Visible = false;
                this.AccordionPane2.Visible = true;
                this.ODSBuscar.SelectParameters["SerieNombre"].DefaultValue = null;
                this.ODSBuscar.SelectParameters["SerieCodigo"].DefaultValue = null;
                ASPxGVExpediente.DataBind();
				ASPxGVExpediente.Columns[5].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                ASPxGVExpediente.Columns[7].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                //string Expediente = Request["ExpedienteCodigo"];
                //if (Expediente != null)
                //{
                //    this.MyAccordion.SelectedIndex = 1;
                //    this.ODSWFExpediente.SelectParameters["ExpedienteCodigo"].DefaultValue = Expediente;
                //    //this.GVExpediente.DataBind();
                //}

                //string ActLogCod = "ACCESO";
                //DateTime FechaInicio = DateTime.Now;
                ////OBTENER CONSECUTIVO DE LOGS
                //DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                //DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                //Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                //DataRow[] fila = Conse.Select();
                //string x = fila[0].ItemArray[0].ToString();
                //string LOG = Convert.ToString(x);
                ////Se Realiza el Log
                ////int NumeroDocumento = Convert.ToInt32("0");
                //string GrupoCod = "0";
                ////string Datosini = "";
                //string Datosfin1 = "Acceso a modulo de Consulta Series.";
                //string usernam = Profile.GetProfile(Profile.UserName).UserName.ToString();
                //DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                //string UserId = objUsr.Aspnet_UserIDByUserName(usernam).ToString();
                //DateTime FechaFin = DateTime.Now;
                //Int64 LogId = Convert.ToInt64(LOG);
                //string IP = Session["IP"].ToString();
                //string NombreEquipo = Session["Nombrepc"].ToString();
                //System.Web.HttpBrowserCapabilities nav = Request.Browser;
                //string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();

                //DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                ////Insert de Log Acceso
                //Accediendo.InsertConsulta(LogId, UserId, FechaInicio, ActLogCod, GrupoCod, ModuloLog,
                //                            Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                ////Actualiza el consecutivo de Logs
                //DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                //ConseLogs.GetConsecutivos(ConsecutivoCodigo);
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
        if (ChBFechaReg.Checked == true)
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
    protected void ChBNroSerie_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBNroSerie.Checked == true)
        {
            ASPxGridView1.Visible = true;

        }
        else
        {

            ASPxGridView1.Visible = false;
        }
    }
    //protected void ChBDestino_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChBDestino.Checked == true)
    //    {
    //        this.LblDestino.Visible = true;
    //        this.TxtBDestino.Visible = true;
    //        this.RadioButtonList1.Visible = true;
    //        //this.RadioButtonList1.SelectedValue = null;
    //    }
    //    else
    //    {
    //        this.LblDestino.Visible = false;
    //        this.TxtBDestino.Visible = false;
    //        this.RadioButtonList1.Visible = false;
    //        this.RadioButtonList1.SelectedValue = null;
    //        this.TxtBDestino.Text = "";
    //    }
    //}
    //protected void cbxPorImagen_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (cbxPorImagen.Checked == true)
    //    {
    //        RblVencido.Visible = true;
    //    }
    //    else
    //    {
    //        RblVencido.Visible = false;
    //    }
    //}

    protected void ChkTiempoSerie_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkTiempoSerie.Checked == true)
        {
            this.LblTiempoSerie.Visible = true;
            this.TxtTiempoSerie.Visible = true;
        }
        else
        {
            this.LblTiempoSerie.Visible = false;
            this.TxtTiempoSerie.Visible = false;
            this.TxtTiempoSerie.Text = "";
        }
    }

    //protected void ChBExpediente_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChBExpediente.Checked == true)
    //    {
    //        this.LblExpediente.Visible = true;
    //        this.TxtBExpediente.Visible = true;
    //    }
    //    else
    //    {
    //        this.LblExpediente.Visible = false;
    //        this.TxtBExpediente.Visible = false;
    //        this.TxtBExpediente.Text = "";
    //    }
    //}
    //protected void ChBMedio_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChBMedio.Checked == true)
    //    {
    //        this.LblMedio.Visible = true;
    //        this.TxtBMedio.Visible = true;
    //    }
    //    else
    //    {
    //        this.LblMedio.Visible = false;
    //        this.TxtBMedio.Visible = false;
    //        this.TxtBMedio.Text = "";
    //    }
    //}
    //protected void ChBNaturaleza_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChBNaturaleza.Checked == true)
    //    {
    //        this.LblNaturaleza.Visible = true;
    //        this.TxtBNaturaleza.Visible = true;
    //    }
    //    else
    //    {
    //        this.LblNaturaleza.Visible = false;
    //        this.TxtBNaturaleza.Visible = false;
    //        this.TxtBNaturaleza.Text = "";
    //    }
    //}
    //protected void ChBRemite_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChBRemite.Checked == true)
    //    {
    //        this.LblRemite.Visible = true;
    //        this.TxtBRemite.Visible = true;
    //    }
    //    else
    //    {
    //        this.LblRemite.Visible = false;
    //        this.TxtBRemite.Visible = false;
    //        this.TxtBRemite.Text = "";
    //    }
    //}
    //protected void ChBOtros_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChBOtros.Checked == true)
    //    {
    //        this.LblBuscarPor.Visible = true;
    //        this.TxtBOtros.Visible = true;
    //        this.DDLOtros.Visible = true;
    //    }
    //    else
    //    {
    //        this.LblBuscarPor.Visible = false;
    //        this.TxtBOtros.Visible = false;
    //        this.TxtBOtros.Text = "";
    //        this.DDLOtros.Visible = false;
    //    }
    //}
    //protected void TreeVExpediente_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    if ((String.IsNullOrEmpty(this.TreeVExpediente.SelectedNode.Text)) == false)
    //    {
    //        // Popup result is the selected task}
    //        PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVExpediente.SelectedNode.Text);
    //        //this.TreeVExpediente.CollapseAll();
    //        //this.TreeVExpediente.Dispose();
    //    }
    //}
    //protected void TreeVExpediente_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    //{
    //    if (TreeVExpediente.SelectedNode == null)
    //    {
    //        ArbolesBLL ObjArbolExp = new ArbolesBLL();
    //        DSExpedienteSQL.ExpedienteByTextDataTable DTExpediente = new DSExpedienteSQL.ExpedienteByTextDataTable();
    //        DTExpediente = ObjArbolExp.GetExpedienteTree(e.Node.Value);
    //        PopulateNodes(DTExpediente, e.Node.ChildNodes, "ExpedienteCodigo", "ExpedienteNombre");
    //    }
    //}


    //protected void TreeVMedio_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    if ((String.IsNullOrEmpty(this.TreeVMedio.SelectedNode.Text)) == false)
    //    {
    //        // Popup result is the selected task}
    //        PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVMedio.SelectedNode.Text);
    //        //this.TreeVExpediente.CollapseAll();
    //        //this.TreeVExpediente.Dispose();
    //    }
    //}
    //protected void TreeVMedio_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    //{
    //    if (TreeVMedio.SelectedNode == null)
    //    {
    //        ArbolesBLL ObjArbolMed = new ArbolesBLL();
    //        DSMedioSQL.MedioByTextDataTable DTMedio = new DSMedioSQL.MedioByTextDataTable();
    //        DTMedio = ObjArbolMed.GetMedioTree(Int32.Parse(e.Node.Value));
    //        PopulateNodes(DTMedio, e.Node.ChildNodes, "MedioCodigo", "MedioNombre");
    //    }
    //}
    //protected void TreeVNaturaleza_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    if ((String.IsNullOrEmpty(this.TreeVNaturaleza.SelectedNode.Text)) == false)
    //    {
    //        // Popup result is the selected task}
    //        PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVNaturaleza.SelectedNode.Text);
    //        //this.TreeVExpediente.CollapseAll();
    //        //this.TreeVExpediente.Dispose();
    //    }
    //}
    //protected void TreeVNaturaleza_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    //{
    //    if (TreeVNaturaleza.SelectedNode == null)
    //    {
    //        ArbolesBLL ObjArbolNat = new ArbolesBLL();
    //        DSNaturalezaSQL.NaturalezaByTextDataTable DTNaturaleza = new DSNaturalezaSQL.NaturalezaByTextDataTable();
    //        DTNaturaleza = ObjArbolNat.GetNaturalezaTree(e.Node.Value);
    //        PopulateNodes(DTNaturaleza, e.Node.ChildNodes, "NaturalezaCodigo", "NaturalezaNombre");
    //    }
    //}
    //protected void TreeVRemite_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    if ((String.IsNullOrEmpty(this.TreeVRemite.SelectedNode.Text)) == false)
    //    {
    //        // Popup result is the selected task}
    //        PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVRemite.SelectedNode.Text);
    //        //this.TreeVExpediente.CollapseAll();
    //        //this.TreeVExpediente.Dispose();
    //    }
    //}
    //protected void TreeVRemite_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    //{
    //    if (TreeVRemite.SelectedNode == null)
    //    {
    //        //ArbolesBLL ObjArbolNat = new ArbolesBLL();
    //        //DSNaturalezaSQL.NaturalezaByTextDataTable DTNaturaleza = new DSNaturalezaSQL.NaturalezaByTextDataTable();
    //        //DTNaturaleza = ObjArbolNat.GetNaturalezaTree(Int32.Parse(e.Node.Value));
    //        //PopulateNodes(DTNaturaleza, e.Node.ChildNodes, "NaturalezaCodigo", "NaturalezaNombre");

    //        ArbolesBLL ObjArbolDep = new ArbolesBLL();
    //        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
    //        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
    //        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    //    }
    //}
    //protected void TreeVDependencia_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    if ((String.IsNullOrEmpty(this.TreeVDependencia.SelectedNode.Text)) == false)
    //    {
    //        // Popup result is the selected task}
    //        PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVDependencia.SelectedNode.Text);
    //        //this.TreeVExpediente.CollapseAll();
    //        //this.TreeVExpediente.Dispose();
    //    }

    //}
    //protected void TreeVDependencia_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    //{
    //    ArbolesBLL ObjArbolDep = new ArbolesBLL();
    //    DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
    //    DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
    //    PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    //}
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

    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        buscar();
    }

    protected void buscar()
    {
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////
		/////    aqui se necesita el table adapter DSWorkFlowTableAdapters.WFMov_ConsultaSeriesTableAdapter en el DaTasEt DSWorkflow.xsd

        string lotros = "";
        string dt_qw = "";


        try
        {
			
			if (TxtFechaInicial.Text.ToString() == null || TxtFechaInicial.Text.ToString() == "" || TxtFechaInicial.Text.ToString() =="")
            {
                this.ODSWFExpediente.SelectParameters["WFMovimientoFecha"].DefaultValue = TxtFechaInicial.Text;
            }
            else
            { 
                DateTime Fecha = Convert.ToDateTime(TxtFechaInicial.Text);
                string fechacorreIni = Fecha.Year.ToString() + "/" + Fecha.Month.ToString() + "/" + Fecha.Day.ToString();
                this.ODSWFExpediente.SelectParameters["WFMovimientoFecha"].DefaultValue = fechacorreIni;
            }

            if (TxtFechaFinal.Text.ToString() == null || TxtFechaFinal.Text.ToString() == "" || TxtFechaFinal.Text.ToString() == "")
            {
                this.ODSWFExpediente.SelectParameters["WFMovimientoFecha1"].DefaultValue = TxtFechaFinal.Text; 
            }
            else
            {
                DateTime Fecha2 = Convert.ToDateTime(TxtFechaFinal.Text);
                string fechacorreFin = Fecha2.Year.ToString() + "/" + Fecha2.Month.ToString() + "/" + Fecha2.Day.ToString();
                this.ODSWFExpediente.SelectParameters["WFMovimientoFecha1"].DefaultValue = fechacorreFin;
            }
			
            this.ODSWFExpediente.SelectParameters["TiempoSerie"].DefaultValue = this.TxtTiempoSerie.Text;


            DataTable dt = new DataTable();

            if (this.RBLTblRpt.SelectedValue == "1")
            {
                // this.AccordionPane2.Visible = true;
                // this.AccordionPane2.Visible = false;

                this.ASPxGVExpediente.DataSourceID = "ODSWFExpediente";
                this.ASPxGVExpediente.DataBind();
                // Siguiente codigo para duplicar la información del Datasource  -- JUAN FIGUEREDO 31-AGO-2020
                List<string> dataColumnNames = new List<string>();
                foreach (GridViewColumn item in ASPxGVExpediente.Columns)
                {
                    GridViewEditDataColumn dataColumn = item as GridViewEditDataColumn;
                    if (dataColumn != null)
                    {
                        dt.Columns.Add(dataColumn.FieldName);
                        dataColumnNames.Add(dataColumn.FieldName);
                    }
                }
                for (int i = 0; i < ASPxGVExpediente.VisibleRowCount; i++)
                {
                    object[] rowValues = ASPxGVExpediente.GetRowValues(i, dataColumnNames.ToArray()) as object[];
                    dt.Rows.Add(rowValues);
                }
                Session["DatosGrid"] = dt;
                //Fin duplicado de informacion datasource, se utilizará posteriormente para Generar Excel en .Xlsx
            }
            else
            {
                this.ASPxGVExpediente.DataSourceID = "";

            }


            this.MyAccordion.SelectedIndex = 1;

            /*Registrar el evento de busqueda*/
            String Ip_cliente = Context.Request.UserHostAddress;
            //String Uri_OrigRef = Context.Request.UrlReferrer.OriginalString;

            String Log = Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + " | " + Profile.UserName.ToString() + " | " + this.TxtFechaInicial.Text + "-" + this.TxtFechaFinal.Text + " | " + TxtTiempoSerie.Text + " | ";

            //OBTENER CONSECUTIVO LOG
            DateTime FechaIni = DateTime.Now;
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            string Datosfin = Log;
            DateTime FechaFin = DateTime.Now;
            string ActLogCod = "CONSULTAR";
            Int64 LogId = Convert.ToInt64(LOG);
            string username = Profile.UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            string GrupoCod = "0";
            //Insert de log Consultas series limite
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter ConsultaFactura = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            ConsultaFactura.InsertConsulta(LogId, username, FechaIni, ActLogCod, GrupoCod, ModuloLog, Datosfin, FechaFin, IP, NombreEquipo, Navegador);
            //Se hace el consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
    protected void LBtnExpediente_Click(object sender, EventArgs e)
    {

        /*Aqui se muestra los documentos relacionados al expediente*/

        this.MyAccordion.SelectedIndex = 1;
        this.AccordionPane1.Visible = true;
        this.AccordionPane2.Visible = true;
        
        DataTable dt = new DataTable();
        try
        {
			if (TxtFechaInicial.Text.ToString() == null || TxtFechaInicial.Text.ToString() == "" || TxtFechaInicial.Text.ToString() =="")
            {
                this.ODSWFExpediente.SelectParameters["WFMovimientoFecha"].DefaultValue = TxtFechaInicial.Text;
            }
            else
            { 
                DateTime Fecha = Convert.ToDateTime(TxtFechaInicial.Text);
                string fechacorreIni = Fecha.Year.ToString() + "/" + Fecha.Month.ToString() + "/" + Fecha.Day.ToString();
                this.ODSWFExpediente.SelectParameters["WFMovimientoFecha"].DefaultValue = fechacorreIni;
            }

            if (TxtFechaFinal.Text.ToString() == null || TxtFechaFinal.Text.ToString() == "" || TxtFechaFinal.Text.ToString() == "")
            {
                this.ODSWFExpediente.SelectParameters["WFMovimientoFecha1"].DefaultValue = TxtFechaFinal.Text; 
            }
            else
            {
                DateTime Fecha2 = Convert.ToDateTime(TxtFechaFinal.Text);
                string fechacorreFin = Fecha2.Year.ToString() + "/" + Fecha2.Month.ToString() + "/" + Fecha2.Day.ToString();
                this.ODSWFExpediente.SelectParameters["WFMovimientoFecha1"].DefaultValue = fechacorreFin;
            }
			
            this.ODSWFExpediente.SelectParameters["SerieCodigo"].DefaultValue = ((LinkButton)sender).Text;
            this.ODSWFExpediente.SelectParameters["TiempoSerie"].DefaultValue = this.TxtTiempoSerie.Text;
          //  this.ODSWFExpediente.SelectParameters["Vencidos"].DefaultValue = this.RblVencido.SelectedValue.ToString();//
            this.ASPxGVExpediente.DataSourceID = "ODSWFExpediente";
            this.ASPxGVExpediente.DataBind();
            // Siguiente codigo para duplicar la información del Datasource -- JUAN FIGUEREDO 31-AGO-2020
            List<string> dataColumnNames = new List<string>();
            foreach (GridViewColumn item in ASPxGVExpediente.Columns) // Al colocar " ASPxGridView1 " Toma el listado de Series
            {
                GridViewEditDataColumn dataColumn = item as GridViewEditDataColumn;
                if (dataColumn != null)
                {
                    dt.Columns.Add(dataColumn.FieldName);
                    dataColumnNames.Add(dataColumn.FieldName);
                }
            }
            for (int i = 0; i < ASPxGVExpediente.VisibleRowCount; i++)
            {
                object[] rowValues = ASPxGVExpediente.GetRowValues(i, dataColumnNames.ToArray()) as object[];
                dt.Rows.Add(rowValues);
            }
            Session["DatosGrid"] = dt;
            // Fin duplicado de informacion datasource, se utilizará posteriormente para Generar Excel en .Xlsx
            //this.MyAccordion.SelectedIndex = 1  ;

            String Log = Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + " | " + Profile.UserName.ToString() + " | " + this.TxtFechaInicial.Text + "-" + this.TxtFechaFinal.Text + " | " + TxtTiempoSerie.Text + " | " + ((LinkButton)sender).Text ;

            //OBTENER CONSECUTIVO LOG
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();

            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            string Datosfin = Log;
            DateTime FechaFin = DateTime.Now;
            string ActLogCod = "CONSULTAR";
            Int64 LogId = Convert.ToInt64(LOG);
            string username = Profile.UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            string GrupoCod = "0";
            //Insert de log Consultas Facturas
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter ConsultaFactura = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            ConsultaFactura.InsertConsulta(LogId, username, DateTime.Now, ActLogCod, GrupoCod, ModuloLog, Datosfin, FechaFin, IP, NombreEquipo, Navegador);
            //Se hace el consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
			//Variables de LOG ERROR
            string grupoo = "0";
            //OBTENER CONSECUTIVO DE LOGS
            DateTime FechaInicio = DateTime.Now;
            string DatosFinales = "Error al Consultar Serie " + ExceptionDetails.Text;
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
        //RegistroBLL ObjConsultaReg = new RegistroBLL();
        //DSRegistro.Registro_ConsultasRegistroDataTable ConsultaRegistro = new DSRegistro.Registro_ConsultasRegistroDataTable();
        //    if (DDLOtros.SelectedValue == "")
        //        ConsultaRegistro = ObjConsultaReg.GetConsultasRegistro(this.RadioButtonList1.SelectedValue.ToString(), this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRegInicial.Text, this.TxtNroRegFinal.Text, null, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, null, null, this.TxtBNaturaleza.Text, this.TxtBRemite.Text.ToString(), this.TxtBSerie.Text.ToString());
        //    else if (DDLOtros.SelectedValue == "Detalle")
        //        ConsultaRegistro = ObjConsultaReg.GetConsultasRegistro(this.RadioButtonList1.SelectedValue.ToString(), this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRegInicial.Text, this.TxtNroRegFinal.Text, null, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, this.TxtBOtros.Text.ToString(), null, this.TxtBNaturaleza.Text, this.TxtBRemite.Text.ToString(), this.TxtBSerie.Text.ToString());
        //    else if (DDLOtros.SelectedValue == "Radicado")
        //        ConsultaRegistro = ObjConsultaReg.GetConsultasRegistro(this.RadioButtonList1.SelectedValue.ToString(), this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRegInicial.Text, this.TxtNroRegFinal.Text, this.TxtBOtros.Text.ToString(), this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, null, null, this.TxtBNaturaleza.Text, this.TxtBRemite.Text.ToString(), this.TxtBSerie.Text.ToString());
        //    else if (DDLOtros.SelectedValue == "Anexo")
        //        ConsultaRegistro = ObjConsultaReg.GetConsultasRegistro(this.RadioButtonList1.SelectedValue.ToString(), this.TxtFechaInicial.Text, this.TxtFechaFinal.Text, this.TxtNroRegInicial.Text, this.TxtNroRegFinal.Text, null, this.TxtBExpediente.Text, this.TxtBProcedencia.Text, this.TxtBMedio.Text, this.TxtBDestino.Text, null, this.TxtBOtros.Text.ToString(), this.TxtBNaturaleza.Text, this.TxtBRemite.Text.ToString(), this.TxtBSerie.Text.ToString());       
        //GVBuscar.DataSource = ConsultaRegistro;
        //this.GVBuscar.PageIndex = e.NewPageIndex;
        //this.GVBuscar.DataBind();
    }
    protected void GVBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int dato1 = GVBuscar.SelectedIndex;
        //String dato = GVBuscar.SelectedRow.Cells[0].Text;
        ////String dato = GVBuscar.Rows[dato1].Cells[0].Text;
        //Session["NroDoc"] = "1" + dato;
        //Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //String RadicadoCodigo = GVBuscar.DataKeys[dato1].Value.ToString();
        ////String RadicadoCodigo = GVBuscar.SelectedDataKey.Value.ToString();
        ////String RadicadoCodigo = this.GVBuscar.SelectedValue.ToString();
        //Session["NroDoc"] = "1" + RadicadoCodigo;
        //Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx");
    }
    //protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (RadioButtonList1.SelectedValue == "1")
    //    {
    //        //    //this.LblSearchDestino.Text = "Busqueda Destino";
    //        //    this.LinkButton2.Text = "Codigo";
    //        //    this.WatermarkDestino.WatermarkText = "Busqueda Dependencia Destino";
    //        this.AutoCompleteDestino.ServiceMethod = "GetDependenciaByTextnull";
    //        //    //this.AutoCompleteNatulezaDoc.ServiceMethod = "GetDependenciaByText";
    //        this.TxtBDestino.Text = "";
    //        this.PopupControlDestino.Enabled = true;
    //        //    this.PopCDestino.Enabled = true;
    //    }
    //    if (RadioButtonList1.SelectedValue == "0")
    //    {
    //        //    //this.LblSearchDestino.Text = "Busqueda Destino";
    //        //    LinkButton2.Text = "NUI";
    //        //    WatermarkDestino.WatermarkText = "Busqueda Procedencia Destino";
    //        this.AutoCompleteDestino.ServiceMethod = "GetProcedenciaByTextNombrenull";

    //       // this.TxtBDestino.Text = "";
    //        this.PopupControlDestino.Enabled = false;
    //        //    this.PopCDestino.Enabled = false;
    //    }
    //    //RadioButtonList1.Focus();
    //    //this.SetFocus(RadioButtonList1);              
    //}

    //protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    //{
    //    if (TreeVSerie.SelectedNode == null)
    //    {
    //        ArbolesBLL ObjArbolSer = new ArbolesBLL();
    //        DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();

    //        //DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
    //        DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
    //        PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
    //    }
    //}
    //protected void TreeVSerie_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    if ((String.IsNullOrEmpty(this.TreeVSerie.SelectedNode.Text)) == false)
    //    {
    //        // Popup result is the selected task}
    //        PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVSerie.SelectedNode.Text);
    //        //this.TreeVExpediente.CollapseAll();
    //        //this.TreeVExpediente.Dispose();
    //    }
    //}
    //protected void ChBSerie_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChBSerie.Checked == true)
    //    {
    //        this.LblSerie.Visible = true;
    //        this.TxtBSerie.Visible = true;
    //    }
    //    else
    //    {
    //        this.LblSerie.Visible = false;
    //        this.TxtBSerie.Visible = false;
    //        this.TxtBSerie.Text = "";
    //    }
    //}
    protected void GVBuscar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink NroDoc = ((HyperLink)e.Row.FindControl("HyperLink1"));

            NroDoc.Attributes.Add("onClick", "urlInt(event,2);");
            ((HyperLink)e.Row.FindControl("HyperLinkVisor")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",2);");
            ((HyperLink)e.Row.FindControl("HprLnkHisExtven")).Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + ",2);");

            //NroDoc.Attributes.Add("onClick", "urlInt(event);");
            //((HyperLink)e.Row.FindControl("HyperLinkVisor")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ");");

        }
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
                        contentType = "application/pdf";
                        fileName = "PivotGrid.pdf";
                        this.ASPxGridViewExporter1.WritePdf(stream);
                        break;
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
                if (listExportFormat.SelectedIndex != -1)
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
            else //  Generar Excel en formato .xlsx  -- JUAN FIGUEREDO 31-AGO-2020
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
                    if (ic == 2)
                    {//osldocument.SetCellValue("B1", "FechaRegistro");
                        column.ColumnName = "FechaRegistro";
                    }
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
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        //this.ConsultaRegistros.OptionsChartDataSource.ChartDataVertical = !CheckBox1.Checked;
    }

    protected void ASPxGVExpediente_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        //if (e.RowType == GridViewRowType.Filter) 
        //{ 

        //}
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            String NroDoc1 = (String)e.GetValue("NroDoc");
            String NGrupoNombre = (String)e.GetValue("GrupoNombre");

            GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["NroDoc"] as GridViewDataColumn;
            GridViewDataColumn colOps =
                ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;

            GridViewDataColumn colGrupo =
               ((ASPxGridView)sender).Columns["GrupoNombre"] as GridViewDataColumn;


            HyperLink NroDoc =
                  (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRad, "HyperLink1");


            HyperLink HprVisor =
            (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkImgExtVen");

            if (NGrupoNombre == "Registros")
            {
                NroDoc.Attributes.Add("onClick", "urlInt(event,2);");
                HprVisor.Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",2);");
            }
            else
            {
                NroDoc.Attributes.Add("onClick", "url(event,1);");
                HprVisor.Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",1);");

            }
        }
    }
}