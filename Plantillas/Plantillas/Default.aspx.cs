using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using AjaxControlToolkit;
using System.Net;
using System.Net.NetworkInformation;

//namespace Plantillas
//{
    public partial class _Default : System.Web.UI.Page
    {
        string ModuloLog = "Registro Plantillas";
        string ConsecutivoCodigo = "7";
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

            if (!IsPostBack)
            {
                ////////////////////////////////////////////////
                MembershipUser user = Membership.GetUser();
                if (user == null)
                {
                    Response.Redirect("~/AlfaNetInicio/InicioLogin/LoginIniciar.aspx");
                }
                ////////////////////////////////////////////////
                DDLPlantilla.Items.Clear();
                DDLPlantilla.Items.Add(new System.Web.UI.WebControls.ListItem("Seleccione", "-1"));
                DDLPlantilla.DataValueField = "Codigo";
                DDLPlantilla.DataTextField = "Descripcion";
                cargarPlantillas();
                if (Session["textoPlantilla"] != null)
                {                    
                    Editor.Text = Session["textoPlantilla"].ToString();
                    Session.Remove("textoPlantilla");
                    //DDLPlantilla.SelectedValue = Session["Plantilla_CodPlantilla"].ToString();
                }
				
			//LOG ACCESO
            string ActLogCod = "ACCESO";
            DateTime Fecha = DateTime.Now;
            //OBTENER CONSECUTIVO DE LOGS
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
            Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
            DataRow[] fila = Conse.Select();
            string x = fila[0].ItemArray[0].ToString();
            string LOG = Convert.ToString(x);
            string HTML = Editor.Text;
            string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Insert de Log Consulta plantilla
            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter ConsultaLog = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            ConsultaLog.InsertLogPlantilla(LogId, Fecha, UserName, ActLogCod, ModuloLog, "", "",
                                            0, true, "", IP, NombreEquipo, Navegador);
            //Actualiza consecutivo log
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

            }
        }

        private void cargarPlantillas()
        {
            try
            {
                Business intelligence = new Business();
                DataSet ds = new DataSet();
                DataSet DSPlantilla = new DataSet();
                string dependenciaCodigo = Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();
                ds = intelligence.cargarPlantillas(dependenciaCodigo);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    if (item["estado"].ToString() == "True")
                    {
                        DDLPlantilla.Items.Add(new ListItem(item.ItemArray[1].ToString(), item.ItemArray[0].ToString()));
                    }
                }
                DDLPlantilla.DataBind();
                if (Session["Plantilla_CodPlantilla"] != null)
                {
                    DDLPlantilla.SelectedValue = Session["Plantilla_CodPlantilla"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLPlantilla_SelectedIndexChanged(object sender, EventArgs e)
         {
            try
            {
                if (DDLPlantilla.SelectedItem.ToString() != "Seleccione")
                {
                    string codPlantilla = DDLPlantilla.SelectedValue.ToString();
                    Business intelligence = new Business();
                    DataSet ds = new DataSet();
                    ds = intelligence.TraerHTMLPlantilla(codPlantilla);
                    string codHtml = ds.Tables[0].Rows[0]["HTML"].ToString();
                    string radicadoCodigo = Request.QueryString["RadicadoCodigo"];
                    //int OpcPlantilla = 1;
                    if (radicadoCodigo == null)
                    {
                        radicadoCodigo = "-1";
                        //radicadoCodigo = "0";
                    }
                    remplazarValores(codHtml, radicadoCodigo);
                    LMessagePlantilla.Text = "";
                }
                else
                {
                    Editor.Text = "";
                    LMessagePlantilla.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void remplazarValores(string codHtml, string radicadoCodigo)
        {
            try
            {
                if (radicadoCodigo != "-1")
                {
                    Business intelligence = new Business();
                    DataSet ds = new DataSet();
                    Session.Add("TablaRelacion", "Radicado");
                    //Editor.Text = codHtml;
                    //int valor = Editor.Text.IndexOf("##");
                    while (codHtml.IndexOf("##") >= 0)
                    {
                        Int32 vFrom = codHtml.IndexOf("##");
                        Int32 vTo = codHtml.IndexOf("##", vFrom + 1);
                        string TxtReplace = codHtml.Substring(vFrom + 2, vTo - vFrom - 2);

                        Int32 mSeparador = TxtReplace.IndexOf("/");
                        string mTablaSecundaria = TxtReplace.Substring(0, mSeparador);
                        string mCampo = TxtReplace.Substring(mSeparador + 1);

                        string Tabla = "Radicado";


                        ds = intelligence.CombinaCampos(Tabla, mCampo, mTablaSecundaria, radicadoCodigo);
                        if (ds.Tables[0].Rows.Count >= 0)
                        {
                            try
                            {
                                codHtml = codHtml.Replace("##" + TxtReplace + "##", ds.Tables[0].Rows[0][1].ToString());

                            }
                            catch (Exception)
                            {

                                codHtml = codHtml.Replace("##" + TxtReplace + "##", " ");
                            }

                        }
                        //Editor.Text = "hola";
                    }
                }                
                Editor.Text = codHtml;
                //Session["texto"] = Editor.Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnCerrar_Click(object sender, ImageClickEventArgs e)
        {
            this.MPEMessage.Enabled = false;
        }
        protected void IBARegistrar_Click(object sender, ImageClickEventArgs e)
        {
            string ActLogCod = "INSERTAR";
            string radicadoCodigo = Request.QueryString["RadicadoCodigo"];
            if (DDLPlantilla.SelectedValue == "-1")
            {
                upmessagealfa.Update();
                this.LblMessageBox.Text = "Debe Seleccionar una Plantilla";

                this.MPEMessage.Enabled = true;
                this.MPEMessage.Show();
                //
                //LMessagePlantilla.Text = "Debe Seleccionar una Plantilla";
                //message();
            }
            else
            {
                string plantilla = Editor.Text;
                Session["textoPlantilla"] = plantilla;
                //string codPlantilla = DDLPlantilla.SelectedValue.ToString();
                string radicado = "";
                if (radicadoCodigo == null || radicadoCodigo == "")
                {
                    Session["OpcPlantilla"] = "1";
                }
                else
                {
                    Session["OpcPlantilla"] = "0";
                    radicado = Request.QueryString["RadicadoCodigo"];
                }
                string depUsuario = Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();
                Session["Plantilla_CodPlantilla"] = DDLPlantilla.SelectedValue.ToString();
                Response.Redirect("Page_RegistrarPlantilla.aspx?RadicadoCodigo=" + radicado + "&depUsuario=" + depUsuario);

                //LOG INSERTAR 
                string Descr = DDLPlantilla.SelectedItem.Text;
                DateTime Fecha = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                int Tipo = 2;
                bool ChkEstado = true;
                string UserName = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(UserName).ToString();
                DateTime FechaFin = DateTime.Now;
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                //Insert de Log registrar plantilla workflow
                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter InsertaLog = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                InsertaLog.InsertLogPlantilla(LogId, Fecha, UserName, ActLogCod, ModuloLog, Session["Plantilla_CodPlantilla"].ToString(), Descr, Tipo, ChkEstado, plantilla, IP, NombreEquipo, Navegador);
                //Actualiza consecutivo
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }  
        }

        protected void message()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(@"$(document).ready(function () {");
            //sb.Append(@"$('#IBPlantillaSalir').click(function() {");
            sb.Append(@"$('#dialog').dialog();");
            sb.Append(@"return false;");
            //sb.Append(@"});");
            sb.Append(@"});");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "JScript", sb.ToString(), false);
        }
    }
//}