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
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.Net;
using System.Net.NetworkInformation;
// Para que el JS consultas.js funcionara en el envio de datos hacia ASP.NET, se creo txtdatosRow en aspx
// y funciona con la clase de mismo nombre en display:none  Juan Figueredo 21 - sept - 2020

public partial class AlfaNetConsultas_Gestion_ConsultaFactura : System.Web.UI.Page
{
    string ModuloLog = "Consultas Facturas";
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
                    //localIP = ip.ToString();

                }
            }
				Session["Nombrepc"] = host.HostName.ToString();
            // //host = Dns.GetHostEntry(Session["IP"].ToString());
            // System.Net.IPHostEntry hostEntry = Dns.GetHostEntry(Session["IP"].ToString());
            // Dns.BeginGetHostEntry(Request.UserHostAddress, new AsyncCallback(GetHostNameCallBack), Request.UserHostAddress);

            if (!IsPostBack)
            {
                //this.DDLOtros.SelectedValue = null;
                this.AccordionPane3.Visible = false;
                this.AccordionPane2.Visible = true;

                // string ActLogCod = "ACCESO";
                // DateTime FechaInicio = DateTime.Now;
                // //OBTENER CONSECUTIVO DE LOGS
                // DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                // DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                // Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                // DataRow[] fila = Conse.Select();
                // string x = fila[0].ItemArray[0].ToString();
                // string LOG = Convert.ToString(x);
                // //Se Realiza el Log
                // //int NumeroDocumento = Convert.ToInt32("0");
                // string GrupoCod = "4";
                // //string Datosini = "";
                // string Datosfin1 = "Acceso a modulo de Consulta Facturas.";
                // string usernam = Profile.GetProfile(Profile.UserName).UserName.ToString();
                // DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                // string UserId = objUsr.Aspnet_UserIDByUserName(usernam).ToString();
                // DateTime FechaFin = DateTime.Now;
                // Int64 LogId = Convert.ToInt64(LOG);
                // string IP = Session["IP"].ToString();
                // string NombreEquipo = Session["Nombrepc"].ToString();
                // System.Web.HttpBrowserCapabilities nav = Request.Browser;
                // string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();

                // DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                // //Insert de Log Acceso
                // Accediendo.InsertConsulta(LogId, UserId, FechaInicio, ActLogCod, GrupoCod, ModuloLog,
                                            // Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                // //Actualiza el consecutivo de Logs
                // DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                // ConseLogs.GetConsecutivos(ConsecutivoCodigo);
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
    protected void ChBNroReg_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBNroReg.Checked == true)
        {
            this.LblNroRegFinal.Visible = true;
            this.LblNroRegInicial.Visible = true;
            this.TxtNroRegFinal.Visible = true;
            this.TxtNroRegInicial.Visible = true;

        }
        else
        {
            this.LblNroRegFinal.Visible = false;
            this.LblNroRegInicial.Visible = false;
            this.TxtNroRegFinal.Visible = false;
            this.TxtNroRegInicial.Visible = false;
            this.TxtNroRegFinal.Text = "";
            this.TxtNroRegInicial.Text = "";
        }
    }

    protected void ChBProcedencia_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBProcedencia.Checked == true)
        {
            this.LblProcedencia.Visible = true;
            this.TxtBProcedencia.Visible = true;
            this.RadioButtonList1.Visible = true;
        }
        else
        {
            this.LblProcedencia.Visible = false;
            this.TxtBProcedencia.Visible = false;
            this.RadioButtonList1.Visible = false;
            this.TxtBProcedencia.Text = "";
        }
    }
    protected void cbxExpediente_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxExpediente.Checked == true)
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
    protected void ChBRemite_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBRemite.Checked == true)
        {
            this.LblRemite.Visible = true;
            this.TxtBRemite.Visible = true;
        }
        else
        {
            this.LblRemite.Visible = false;
            this.TxtBRemite.Visible = false;
            this.TxtBRemite.Text = "";
        }
    }

    protected void ChkRemision_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkRemision.Checked == true)
        {
            this.LblRemiIni.Visible = true;
            this.TxtRemiIni.Visible = true;
            this.LblRemiFin.Visible = true;
            this.TxtRemiFin.Visible = true;

        }
        else
        {
            this.LblRemiIni.Visible = false;
            this.TxtRemiIni.Visible = false;
            this.LblRemiFin.Visible = false;
            this.TxtRemiFin.Visible = false;
        }
    }
    protected void ChkNumFactura_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkNumFactura.Checked == true)
        {
            this.LblFactIni.Visible = true;
            this.TxtFactIini.Visible = true;
            this.LblFactFin.Visible = true;
            this.TxtFactFIn.Visible = true;
        }
        else
        {
            this.LblFactIni.Visible = false;
            this.TxtFactIini.Visible = false;
            this.LblFactFin.Visible = false;
            this.TxtFactFIn.Visible = false;
        }
    }
    protected void ChkComprobantes_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkComprobantes.Checked == true)
        {
            this.LblComprobIni.Visible = true;
            this.TxtCOmprobIni.Visible = true;
            this.LblComprobFin.Visible = true;
            this.TxtCOmprobFin.Visible = true;
        }
        else
        {
            this.LblComprobIni.Visible = false;
            this.TxtCOmprobIni.Visible = false;
            this.LblComprobFin.Visible = false;
            this.TxtCOmprobFin.Visible = false;
        }
    }
    protected void ChkValFacturas_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkValFacturas.Checked == true)
        {
            this.LblValFactIni.Visible = true;
            this.TxtValFactIni.Visible = true;
            this.LblValFactFin.Visible = true;
            this.TxtValFactFin.Visible = true;
        }
        else
        {
            this.LblValFactIni.Visible = false;
            this.TxtValFactIni.Visible = false;
            this.LblValFactFin.Visible = false;
            this.TxtValFactFin.Visible = false;
        }
    }
    protected void ChkUbic_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkUbic.Checked == true)
        {
            this.LblUbic.Visible = true;
            this.TxtUbic.Visible = true;

        }
        else
        {
            this.LblUbic.Visible = false;
            this.TxtUbic.Visible = false;
        }
    } // ChkUbic_CheckedChanged
    protected void ChkCodCiudades_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkCodCiudades.Checked == true)
        {
            this.LblCodIni.Visible = true;
            this.TxtCodIni.Visible = true;
            this.LblCodFin.Visible = true;
            this.TxtCodFin.Visible = true;
        }
        else
        {
            this.LblCodIni.Visible = false;
            this.TxtCodIni.Visible = false;
            this.LblCodFin.Visible = false;
            this.TxtCodFin.Visible = false;
        }
    }
    protected void ChkDetalle_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkDetalle.Checked == true)
        {
            this.LblDetalle.Visible = true;
            this.TxtDetalle.Visible = true;

        }
        else
        {
            this.LblDetalle.Visible = false;
            this.TxtDetalle.Visible = false;
        }
    }
    protected void cbxUnidad_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxUnidad.Checked == true)
        {
            this.LblUndAlmac.Visible = true;
            this.txtUnidad.Visible = true;

        }
        else
        {
            this.LblUndAlmac.Visible = false;
            this.txtUnidad.Visible = false;
        }
    }
    protected void cbxModalidad_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxModalidad.Checked == true)
        {
            this.LblModalidad.Visible = true;
            this.txtModalidad.Visible = true;

        }
        else
        {
            this.LblModalidad.Visible = false;
            this.txtModalidad.Visible = false;
        }
    }
    protected void cbxPorImagen_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxPorImagen.Checked == true)
        {
            LblImg.Visible = true;
            RblImagen.Visible = true;
        }
        else
        {
            LblImg.Visible = false;
            RblImagen.Visible = false;
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
            PopulateNodes(DTExpediente, e.Node.ChildNodes, "ExpedienteCodigo", "ExpedienteNombre");
        }
    }

    protected void TreeVRemite_SelectedNodeChanged(object sender, EventArgs e)
    {
        if ((String.IsNullOrEmpty(this.TreeVRemite.SelectedNode.Text)) == false)
        {
            // Popup result is the selected task}
            PopupControlExtender.GetProxyForCurrentPopup(this.Page).Commit(TreeVRemite.SelectedNode.Text);
            //this.TreeVExpediente.CollapseAll();
            //this.TreeVExpediente.Dispose();
        }
    }
    protected void TreeVRemite_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (TreeVRemite.SelectedNode == null)
        {
            //ArbolesBLL ObjArbolNat = new ArbolesBLL();
            //DSNaturalezaSQL.NaturalezaByTextDataTable DTNaturaleza = new DSNaturalezaSQL.NaturalezaByTextDataTable();
            //DTNaturaleza = ObjArbolNat.GetNaturalezaTree(Int32.Parse(e.Node.Value));
            //PopulateNodes(DTNaturaleza, e.Node.ChildNodes, "NaturalezaCodigo", "NaturalezaNombre");

            ArbolesBLL ObjArbolDep = new ArbolesBLL();
            DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
            DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
            PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
        }
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
        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////

        lblMessage.Text = "";
        ExceptionDetails.Text = "";
        string lotros = "";
        string dt_qw = "";

        try
        {
            DateTime FechaInicio = DateTime.Now;
            string ActLogCod = "CONSULTAR";

            this.ODSBuscar.SelectParameters["Radicador"].DefaultValue = TxtBRemite.Text;
            this.ODSBuscar.SelectParameters["porImagen"].DefaultValue = this.RblImagen.SelectedValue.ToString();
            this.ODSBuscar.SelectParameters["radInicial"].DefaultValue = this.TxtNroRegInicial.Text;
            this.ODSBuscar.SelectParameters["radFinal"].DefaultValue = this.TxtNroRegFinal.Text;
            this.ODSBuscar.SelectParameters["fechaInicial"].DefaultValue = this.TxtFechaInicial.Text;
            this.ODSBuscar.SelectParameters["fechaFinal"].DefaultValue = this.TxtFechaFinal.Text;
            this.ODSBuscar.SelectParameters["FacnReciboIni"].DefaultValue = this.TxtRemiIni.Text;
            this.ODSBuscar.SelectParameters["FacnReciboFin"].DefaultValue = this.TxtRemiFin.Text;
            this.ODSBuscar.SelectParameters["facValorMenor"].DefaultValue = this.TxtValFactIni.Text;
            this.ODSBuscar.SelectParameters["facValorMayor"].DefaultValue = this.TxtValFactFin.Text;
            this.ODSBuscar.SelectParameters["detalle"].DefaultValue = this.TxtDetalle.Text;
            this.ODSBuscar.SelectParameters["nombreNit"].DefaultValue = this.TxtBProcedencia.Text;
            this.ODSBuscar.SelectParameters["unidad"].DefaultValue = this.txtUnidad.Text;
            this.ODSBuscar.SelectParameters["ubicacion"].DefaultValue = this.TxtUbic.Text;
            this.ODSBuscar.SelectParameters["modalidad"].DefaultValue = this.txtModalidad.Text;
            this.ODSBuscar.SelectParameters["expediente"].DefaultValue = this.TxtBExpediente.Text;
            this.ODSBuscar.SelectParameters["numFacIni"].DefaultValue = this.TxtFactIini.Text;
            this.ODSBuscar.SelectParameters["comEgresoIni"].DefaultValue = this.TxtCOmprobIni.Text;
            this.ODSBuscar.SelectParameters["comEgresoFin"].DefaultValue = this.TxtCOmprobFin.Text;
            this.ODSBuscar.SelectParameters["numFacFinal"].DefaultValue = this.TxtFactFIn.Text;
            this.ODSBuscar.SelectParameters["ciudadInicial"].DefaultValue = this.TxtCodIni.Text;
            this.ODSBuscar.SelectParameters["ciudadFinal"].DefaultValue = this.TxtCodFin.Text;

            DataTable dt = new DataTable();

            if (this.RBLTblRpt.SelectedValue == "1")
            {
                this.AccordionPane2.Visible = true;
                this.AccordionPane3.Visible = false;

                this.ASPxGridView1.DataSourceID = "ODSBuscar";
                this.ReportViewer1.LocalReport.DataSources[0].DataSourceId = "";
                this.ASPxGridView1.DataBind();
                // Siguiente codigo para duplicar la información del Datasource_ JUAN FIGUEREDO 22-SEP-2020
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
                if(dt.Rows.Count < 1)
                {
                    ExceptionDetails.Text = "No se encuentran Registros para la consulta, Si esta seguro de los datos ingresados, intente nuevamente.";
                }
                Session["DatosGrid"] = dt;
                //Fin duplicado de informacion datasource, se utilizará posteriormente para Generar Excel en .Xlsx


            }
            else
            {
                this.ASPxGridView1.DataSourceID = "";
                this.AccordionPane3.Visible = true;
                this.AccordionPane2.Visible = false;

                this.ReportViewer1.LocalReport.DataSources[0].DataSourceId = "ODSBuscar";
                //Microsoft.Reporting.WebForms.ReportDataSource RDS = new Microsoft.Reporting.WebForms.ReportDataSource();
                //RDS.Name = ODSBuscar.ToString();
                //RDS.Value = ODSBuscar.Select();
                //this.ReportViewer1.LocalReport.DataSources.Add(RDS);
                this.ReportViewer1.DataBind();
            }

            /*Registrar el evento de busqueda
             
             */
            /*
            rutinas r1 = new rutinas();
            DataTable t1 = r1.rtn_registrar_log("0", UserId, "6",
                this.TxtFechaInicial.Text + "?" + this.TxtFechaFinal.Text + "?" + this.TxtNroRegInicial.Text + "?" +
                this.TxtNroRegFinal.Text + "?" + this.TxtNroRegFinal.Text + "?" + value_pipe(this.TxtBExpediente.Text) + "?" +
                value_pipe(TxtBProcedencia.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" + value_pipe(TxtBMedio.Text) + "?" + value_pipe(TxtBDestino.Text) + "?" + value_pipe(TxtBRemite.Text) + "?" +
                value_pipe(TxtBSerie.Text) + "?" + Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + "?" + value_pipe(TxtBNaturaleza.Text) + "?" + lotros
                , "2");*/

            //GVBuscar.DataSource = ConsultaRegistro;
            //GVBuscar.Visible = true;
            //GVBuscar.DataBind();
            this.MyAccordion.SelectedIndex = 1;

            /*Registrar el evento de busqueda*/
            String Ip_cliente = Context.Request.UserHostAddress;
            //String Uri_OrigRef = Context.Request.UrlReferrer.OriginalString;

            //log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

			string img;
            if (RblImagen.SelectedValue.ToString() == "")
            {
                img = "null";
            }
            else { img = RblImagen.SelectedValue.ToString(); }

            String Log = Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + " | " + Profile.UserName.ToString() + " | " + this.TxtFechaInicial.Text + "-" + this.TxtFechaFinal.Text + " | " + this.TxtNroRegInicial.Text + "-" + this.TxtNroRegFinal.Text + " | " + this.TxtRemiIni.Text + "-" + this.TxtRemiFin.Text + " | " + this.TxtFactIini.Text + "-" + this.TxtFactFIn.Text + " | " + this.TxtCOmprobIni.Text + "-" + this.TxtCOmprobFin.Text + " | " + this.TxtValFactIni.Text + "-" + this.TxtValFactFin.Text + " | " + value_pipe(TxtBProcedencia.Text) + " | " + value_pipe(this.TxtUbic.Text) + " | " + this.TxtCodIni.Text + "-" + this.TxtCodFin.Text + " | " + this.TxtDetalle.Text + " | " + this.txtUnidad.Text + " | " + this.txtModalidad.Text + " | " + value_pipe(this.TxtUbic.Text) + value_pipe(TxtBExpediente.Text) + " | Imagen:" + img +" | " + value_pipe(TxtBRemite.Text);
          

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
            string GrupoCod = "4";
            //Insert de log Consultas Facturas
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter ConsultaFactura = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            ConsultaFactura.InsertConsulta(LogId, username, FechaInicio, ActLogCod, GrupoCod, ModuloLog, Datosfin, FechaFin, IP, NombreEquipo, Navegador);
            //Se hace el consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Ha ocurrido un error, verifique los datos e intente nuevamente.  ";
            //Variables de LOG ERROR
            string grupoo = "4";
            //OBTENER CONSECUTIVO DE LOGS
            DateTime FechaInicio = DateTime.Now;
            string DatosFinales = "Error al Consultar Facturas " + ExceptionDetails.Text;
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
       // Limpiar DATOS DE FILTRO
        TxtBRemite.Text = "";
        RblImagen.ClearSelection();
        TxtNroRegInicial.Text = "";
        TxtNroRegFinal.Text = "";
        TxtFechaInicial.Text = "";
        TxtFechaFinal.Text = "";
        TxtRemiIni.Text = "";
        TxtRemiFin.Text = "";
        TxtValFactIni.Text = "";
        TxtValFactFin.Text = "";
        TxtDetalle.Text = "";
        TxtBProcedencia.Text = "";
        txtUnidad.Text = "";
        TxtUbic.Text = "";
        txtModalidad.Text = "";
        TxtBExpediente.Text = "";
        TxtFactIini.Text = "";
        TxtCOmprobIni.Text = "";
        TxtCOmprobFin.Text = "";
        TxtFactFIn.Text = "";
        TxtCodIni.Text = "";
        TxtCodFin.Text = "";
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
    protected void RblImagen_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RblImagen.SelectedValue == "1")
        {
            

        }
        if (RblImagen.SelectedValue == "0")
        {

        }
    }

    protected void GVBuscar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink NroDoc = ((HyperLink)e.Row.FindControl("HyperLink1"));

            NroDoc.Attributes.Add("onClick", "urlInt(event,2);");
            ((HyperLink)e.Row.FindControl("HyperLinkVisor")).Attributes.Add("onClick", "VImagenesReg(event," + NroDoc.Text + ",4);");
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
                        this.ASPxGridViewExporter1.LeftMargin = 20;
                        this.ASPxGridViewExporter1.PageHeader.Center = "Informe Facturas " + DateTime.Now.ToString();
                        this.ASPxGridViewExporter1.RightMargin = 5;
                        this.ASPxGridViewExporter1.MaxColumnWidth = 65;
                        this.ASPxGridViewExporter1.TopMargin = 20;
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
            else //   Generar Excel en formato .xlsx  -- JUAN FIGUEREDO 22-SEP-2020
            {
                string NombreArchivo = "ReporteFacturas"+DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") +".xlsx";
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
                    if (ic == 2) { column.ColumnName = "Registro Oasis"; }
                    if (ic == 3) { column.ColumnName = "Nro.Remisión"; }

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

    protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        //if (e.RowType == GridViewRowType.Filter) 
        //{ 

        //} 
        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data)
        {
            String ExpedienteCodigo = (String)e.GetValue("ExpedienteCodigo");
            //String GrupoCodigo = (String)e.GetValue("GrupoCodigo");

            GridViewDataColumn colRad =
                ((ASPxGridView)sender).Columns["RadicadoCodigo"] as GridViewDataColumn;
            GridViewDataColumn colOps =
                ((ASPxGridView)sender).Columns["Opciones"] as GridViewDataColumn;
            GridViewDataColumn colRpta =
                ((ASPxGridView)sender).Columns["Rpta"] as GridViewDataColumn;

            HyperLink NroDoc =
                (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colRad, "HyperLink1");
            NroDoc.Attributes.Add("onClick", "urlInt(event,2);");

            HyperLink HprVisor =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HyperLinkVisor");
            HprVisor.Attributes.Add("onClick", "VImagenes(event," + NroDoc.Text + ",4);");

            HyperLink HprHisto =
           (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkHisExtven");
            HprHisto.Attributes.Add("onClick", "HistoricoReg(event," + NroDoc.Text + ",2);");

            HyperLink HprExp =
         (HyperLink)((ASPxGridView)sender).FindRowCellTemplateControl(e.VisibleIndex, colOps, "HprLnkExp");
            HprExp.Attributes.Add("onClick", "Expediente(event," + NroDoc.Text + ",'" + ExpedienteCodigo + "',1);");

        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string codigo = txtRadicadoCodigo.Text.Trim();
        string detalle = TextBoxAreaDetalle.Text.Trim();
        string UnidadAlmacenamiento = txtFacc_almacenamiento.Text.Trim();
        string datosini = txtdatosRow.Text.Trim();

        List<string> compEgresoList = null;
        DSFacturaTableAdapters.consultas_radicacionmasiva_av2TableAdapter objadapapter = new DSFacturaTableAdapters.consultas_radicacionmasiva_av2TableAdapter();
        DSFactura.consultas_radicacionmasiva_av2DataTable tablaUpdate = new DSFactura.consultas_radicacionmasiva_av2DataTable();
        try
        {
            compEgresoList = new List<string>();
            foreach (System.Web.UI.WebControls.ListItem item in lbxCompEgreso.Items)
            {
                string tempItem = item.Value.ToString();
                compEgresoList.Add(tempItem);
            }

            FacturaBLL fact = new FacturaBLL();
            string actualizo = fact.UpdateRadicado(codigo, detalle,UnidadAlmacenamiento ,compEgresoList);
            lbxCompEgreso.Items.Clear();
            
            lblMessage.Text = actualizo;
           
            //OBTENER CONSECUTIVO LOG
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            string ActLogCod = "Actualizar";
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string username = Profile.UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            string GrupoCod = "4";

            string Datosfin1 = txtRadicadoCodigo.Text+ " | " +spm_fecharadicacion.Text+ " | " + txtProcNui.Text + " | " + spm_procedencia.Text + " | " + TextBoxAreaDetalle.Text + " | " + txt_compEgreso.Text + " | " + txtRegistroOasis.Text + " | " + txtRemision.Text + " | " + txtFacPrestador.Text + " | " + txtExpediente2.Text + " | " + txtFacn_empresa.Text + " | " + txtFacc_documento.Text + " | " + txtFacn_ubicacion.Text + " | " + txtFacv_total.Text + " | " + txtFacc_estado.Text + " | " + txtFacc_prefijo.Text+ " | " + txtFacn_factura2.Text+ " | " + txtFacc_alto_costo.Text + " | " +txtFacf_confirmacion.Text +" | "+ txtFacv_copago.Text +" | "+ txtFacv_responsable.Text  +" | "+ txtFacc_conciliado.Text +" | "+ txtFacv_imputable.Text  +" | "+ txtFacf_radicado.Text +" | "+ txtFacf_final.Text +" | "+txtFacc_digitalizado.Text  +" | "+ txtFacc_almacenamiento.Text +" | "+ txtCntc_concepto.Text +" | "+ txtConc_nombre.Text  +" | "+ txtFacn_recibo.Text;

            //Se hace el insert de Log Update Factura (DATOS INICIALES)
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter ConsultaFacturaIni = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            ConsultaFacturaIni.InsertConsulta(LogId, username, DateTime.Now, ActLogCod+"(DatosIni)", GrupoCod, ModuloLog, datosini, FechaFin, IP, NombreEquipo, Navegador);
            //Se hace el update consecutivo de Logs -  datos iniciales
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);


            //Se hace el insert de Log Update Factura (DATOS ACTUALIZADOS)
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter ConsultaFacturaFin = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            ConsultaFacturaFin.InsertConsulta(LogId+1, username, DateTime.Now, ActLogCod+"(DatosFin)", GrupoCod, ModuloLog, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
            //Se hace el update consecutivo de Logs  -  datos finales
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogsFin = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogsFin.GetConsecutivos(ConsecutivoCodigo);

        }
        catch (Exception)
        {
            lblMessage.Text = "Ocurrió un problema al realizar el proceso de actualización. Por favor intente mas tarde nuevamente.";
        }
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (txtCompEgreso.Text.Trim() != "")
            {
                System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
                item.Value = txtCompEgreso.Text.Trim();
                lbxCompEgreso.Items.Add(item);
            }
            txtCompEgreso.Text = string.Empty;
        }
        catch
        {

        }
    }
    // RADIO BUTTON PROCEDENCIA POR NOMBRE O CODIGO
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            this.AutoCompleteProcedencia.ServiceMethod = "GetProcedenciaByTextNombrenull";

        }
        if (RadioButtonList1.SelectedValue == "0")
        {
            this.AutoCompleteProcedencia.ServiceMethod = "GetProcedenciaByTextIdnull";

        }
        //RadioButtonList1.Focus();
        //this.SetFocus(RadioButtonList1);              
    }

}