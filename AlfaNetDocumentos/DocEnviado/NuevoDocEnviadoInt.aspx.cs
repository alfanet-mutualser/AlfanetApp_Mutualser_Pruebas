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
using AjaxControlToolkit;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Drawing;


public partial class _NuevoDocEnviadoInt : System.Web.UI.Page
{
    string WFAccion = "2";
    string GrpDocReg = "2";
    rutinas ejecutar = new rutinas();
    DataTable tabla = new DataTable();
    string MotDevolucionAnterior;
    string ModuloLog = "Documentos";
    string ConsecutivoCodigo = "3";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "Error";

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tabla = new DataTable();
        this.Label10.Visible = false;
        this.Label11.Visible = false;
        this.Label12.Visible = false;
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
            //Solo los administradores pueden añadir naturalezas desde esta parte
            if (Roles.RoleExists("Administrador") && !Roles.IsUserInRole("Administrador"))
            {
                this.ImageButton7.Visible = false;//Naturaleza
                this.ImageButton9.Visible = false;//Expediente
            }
            

            if (!IsPostBack)
            {
                // llena el cuadro de lista grupo
                string codigodelgruporadicados = "";
                string codigodelgruporegistros = "";
                this.Label10.Visible = false;
                this.Label11.Visible = false;


                tabla = ejecutar.rtn_traer_tbtablas_por_Id("GRUPOREG");
                codigodelgruporegistros = tabla.Rows[0][0].ToString().Trim();
                tabla = ejecutar.rtn_traer_grupos_por_codigopadre(codigodelgruporegistros);
                if (tabla.Rows.Count == 0)
                {
                    tabla = ejecutar.rtn_traer_grupos_por_Id(codigodelgruporegistros);
                }
                this.DropDownListGrupo.DataTextField = "gruponombre";
                this.DropDownListGrupo.DataValueField = "grupocodigo";
                this.DropDownListGrupo.DataSource = tabla;
                this.DropDownListGrupo.DataBind();
                this.DropDownListGrupo.SelectedIndex = 0;

                // lista llena con gel grupo de radicacoines
                tabla = ejecutar.rtn_traer_tbtablas_por_Id("GRUPORAD");
                codigodelgruporadicados = tabla.Rows[0][0].ToString().Trim();
                tabla = ejecutar.rtn_traer_grupos_por_codigopadre(codigodelgruporadicados);
                if (tabla.Rows.Count == 0)
                {
                    tabla = ejecutar.rtn_traer_grupos_por_Id(codigodelgruporadicados);
                }
                this.DropDownListGrupoFuente.DataTextField = "gruponombre";
                this.DropDownListGrupoFuente.DataValueField = "grupocodigo";
                this.DropDownListGrupoFuente.DataSource = tabla;
                this.DropDownListGrupoFuente.DataBind();
                this.DropDownListGrupoFuente.SelectedIndex = 0;


                Application["grupo"] = this.DropDownListGrupoFuente.SelectedValue.ToString();
                Application["gruporegistro"] = this.DropDownListGrupo.SelectedValue.ToString();
                string Admon = Request["Admon"];
                if (Admon == "S")
                {
                    ((MainMaster)this.Master).hidemenu();
                }
                else
                {
                   // ((MainMaster)this.Master).showmenu();
                }

                this.TreeVRemite.Attributes["onClick"] = "return OnTreeClick(event);";
                this.TreeVDestino.Attributes["onClick"] = "return OnTreeDestinoClick(event);";
                this.TreeVExpediente.Attributes["OnClick"] = "return OnTreeExpedienteClick(event)";
                this.TreeVMedio.Attributes["onClick"] = "return OnTreeMedioClick(event);";
                this.TreeVNaturaleza.Attributes["onClick"] = "return OnTreeNaturalezaClick(event);";
                this.TreeVSerie.Attributes["onClick"] = "return OnTreeSerieClick(event);";

                String Fecha = DateTime.Today.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                String Mayuscula = Fecha.Substring(0, 1).ToUpper();
                string minuscula = Fecha.Substring(1);
                this.DateFechaRad.Text = Mayuscula + minuscula;

                this.TextBox1.Enabled = true;
                this.cmdActualizar.Enabled = false;
                this.cmdAceptar.Enabled = true;
                this.RadioButtonList1.SelectedValue = "1";
                String RegistroCodigo = Request["RegistroCodigo"];
                String RadicadoCodigo = Request["RadicadoCodigo"];
                String GrupoRegistroCodigo = Request["GrupoRegistroCodigo"];

                if (RegistroCodigo != null)
                {

                    string Grupo = GrupoRegistroCodigo;
                    string nrodoc = RegistroCodigo;
                                        
                    tabla = ejecutar.rtn_traer_registros_por_grupo_por_id(Grupo, nrodoc);
                    DataRow[] rows = tabla.Select();

                    this.mostrar(rows);

                    this.TextBox1.Visible = true;
                    this.cmdActualizar.Enabled = true;
                    this.cmdAceptar.Enabled = false;
                    this.Label12.Visible = true;
                    this.Label6.Text = nrodoc;
                    //this.ExceptionDetails.Text = "Registro Nro " + " " + nrodoc;
                    this.NavDocEnviado1.HFGrupoCodigoValor(this.DropDownListGrupo.SelectedValue);
                    this.NavDocEnviado1.HFRegistroCodigoValor(nrodoc);
                    this.NavDocEnviado1.HFGrupoPadreCodigoValor(codigodelgruporegistros);

                    this.TxtBuscarRadicado.Text = nrodoc;
                }
                if (Request.Cookies.Get("DependenciaEnv") != null || Request.Cookies.Get("DestinoEnv") != null || Request.Cookies.Get("TipoEnv") != null || Request.Cookies.Get("NaturalezaEnv") != null || Request.Cookies.Get("MedioEnv") != null || Request.Cookies.Get("ExpedienteEnv") != null || Request.Cookies.Get("SerieEnv") != null)
                    {
                        // Recogemos la cookie que nos interese                        
                        HttpCookie DependenciaEnvCookie = Request.Cookies.Get("DependenciaEnv");
                        HttpCookie DestinoEnvCookie = Request.Cookies.Get("DestinoEnv");
                        HttpCookie TipoEnvCookie = Request.Cookies.Get("TipoEnv");
                        HttpCookie NaturalezaEnvCookie = Request.Cookies.Get("NaturalezaEnv");
                        HttpCookie MedioEnvCookie = Request.Cookies.Get("MedioEnv");
                        HttpCookie ExpedienteEnvCookie = Request.Cookies.Get("ExpedienteEnv");
                        HttpCookie SerieEnvCookie = Request.Cookies.Get("SerieEnv");

                        //Asignar valores de cookies a formulario
                        this.TxtDependencia.Text = DependenciaEnvCookie.Value;
                        this.TxtDestino.Text = DestinoEnvCookie.Value;
                        this.RadioButtonList1.SelectedValue = TipoEnvCookie.Value;
                        if (this.RadioButtonList1.SelectedValue == "0")
                            {
                                this.AutoCompleteDestino.ServiceMethod = "GetProcedenciaByTextNombre";
                                this.PopCDestino.Enabled = false;
                                this.ImageButton12.Visible = true;
                            }

                        this.TxtNaturaleza.Text = NaturalezaEnvCookie.Value;
                        this.TxtMedioRecibo.Text = MedioEnvCookie.Value;
                        this.TxtExpediente.Text = ExpedienteEnvCookie.Value;
                        this.TextBox1.Text = SerieEnvCookie.Value;
                    }
                    else if (Request.Cookies.Get("DependenciaEnv") == null || Request.Cookies.Get("DestinoEnv") == null || Request.Cookies.Get("TipoEnv") == null || Request.Cookies.Get("NaturalezaEnv") == null || Request.Cookies.Get("MedioEnv") == null || Request.Cookies.Get("ExpedienteEnv") == null || Request.Cookies.Get("SerieEnv") == null)
                    {
                        HttpCookie DependenciaEnvCookie = new HttpCookie("DependenciaEnv", this.TxtDependencia.Text.ToString());
                        HttpCookie DestinoEnvCookie = new HttpCookie("DestinoEnv", this.TxtDestino.Text.ToString());
                        HttpCookie TipoEnvCookie = new HttpCookie("TipoEnv", this.RadioButtonList1.SelectedValue.ToString());
                        HttpCookie NaturalezaEnvCookie = new HttpCookie("NaturalezaEnv", this.TxtNaturaleza.Text.ToString());
                        HttpCookie MedioEnvCookie = new HttpCookie("MedioEnv", this.TxtMedioRecibo.Text.ToString());
                        HttpCookie ExpedienteEnvCookie = new HttpCookie("ExpedienteEnv", this.TxtExpediente.Text.ToString());
                        HttpCookie SerieEnvCookie = new HttpCookie("SerieEnv", this.TextBox1.Text.ToString());

                        // Si queremos le asignamos un fecha de expiración: mañana
                        DependenciaEnvCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
                        DestinoEnvCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
                        TipoEnvCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
                        NaturalezaEnvCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
                        MedioEnvCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
                        ExpedienteEnvCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
                        SerieEnvCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);

                        // Y finalmente ñadimos la cookie a nuestro usuario
                        Response.Cookies.Add(DependenciaEnvCookie);
                        Response.Cookies.Add(DestinoEnvCookie);
                        Response.Cookies.Add(TipoEnvCookie);
                        Response.Cookies.Add(NaturalezaEnvCookie);
                        Response.Cookies.Add(MedioEnvCookie);
                        Response.Cookies.Add(ExpedienteEnvCookie);
                        Response.Cookies.Add(SerieEnvCookie);
                    }
                    if (RadicadoCodigo != null)
                    { 
                        // codigo para respuesta automatica de radicado.
                        ListBoxFuente.Items.Add(RadicadoCodigo + " | ");
                        DataTable tablaRad = new DataTable();
                        tablaRad = ejecutar.rtn_traer_radicados_por_grupo_por_id("1", RadicadoCodigo);
                        DataRow[] rows = tablaRad.Select();

                        this.TxtDependencia.Text = Profile.CodigoDepUsuario + " | " + Profile.NombreDepUsuario; 
                        this.RadioButtonList1.SelectedValue = "0";
                        this.TxtDestino.Text = rows[0]["procedenciacodigo"].ToString().Trim() + " | " + rows[0]["procedencianombre"].ToString().Trim() + " | " + rows[0]["ciudadnombre"].ToString().Trim();
                        //this.TxtDetalle.Text = rows[0]["radicadodetalle"].ToString();
                        this.TxtNaturaleza.Text = rows[0]["naturalezacodigo"].ToString() + " | " + rows[0]["naturalezanombre"].ToString().Trim();
                        this.TxtMedioRecibo.Text = rows[0]["mediocodigo"].ToString() + " | " + rows[0]["medionombre"].ToString().Trim();
                        this.TxtExpediente.Text = rows[0]["expedientecodigo"].ToString() + " | " + rows[0]["expedientenombre"].ToString().Trim();



                    }
                    string ActLogCod = "ACCESO";
                    DateTime FechaInicio = DateTime.Now;
                    //OBTENER CONSECUTIVO DE LOGS
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                    Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                    DataRow[] fila = Conse.Select();
                    string x = fila[0].ItemArray[0].ToString();
                    string LOG = Convert.ToString(x);
                    //Se Realiza el Log
                    int NumeroDocumento = Convert.ToInt32("0");
                    string GrupoCod = "2";
                    string Datosini = "";
                    string Datosfin1 = "Acceso a modulo de Documentos Enviados.";
                    string usernam = Profile.GetProfile(Profile.UserName).UserName.ToString();
                    DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                    string UserId = objUsr.Aspnet_UserIDByUserName(usernam).ToString();
                    DateTime FechaFin = DateTime.Now;
                    Int64 LogId = Convert.ToInt64(LOG);
                    string IP = Session["IP"].ToString();
                    string NombreEquipo = Session["Nombrepc"].ToString();
                    System.Web.HttpBrowserCapabilities nav = Request.Browser;
                    string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();

                    DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                    //Insert de Log Acceso
                    Accediendo.InsertEnviados(LogId, usernam, FechaInicio, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog,
                                                Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                    //Actualiza el consecutivo de Logs
                    DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                    ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
            else
            {
            }
            this.hlinkCarta.Visible = false;
            this.lbCartaPlantilla.Visible = false;
        }
        catch (Exception Error)
        {
            this.Label6.Text = "";
            this.LblMessageBox.Text = "Problema" + Error;
            this.ModalPopupExtender1.Show();
        }
    }
    private int CInt(object p)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    protected void ImgBtnFindRad_Click(object sender, ImageClickEventArgs e)
    {
        string usernam = Profile.GetProfile(Profile.UserName).UserName.ToString();
        Session["CodRegistro"] = "";
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UserId = objUsr.Aspnet_UserIDByUserName(usernam).ToString();
        this.ExceptionDetails.Text = "";
        this.Label6.Text = "";

        this.Label10.Visible = true;
        this.Label11.Visible = true;

        try
        {
            string Grupo = this.DropDownListGrupo.SelectedValue;

            String NroReg;
            NroReg = TxtBuscarRadicado.Text;
            if (NroReg != null)
            {
                if (NroReg.Contains(" | "))
                {
                    NroReg = NroReg.Remove(NroReg.IndexOf(" | "));
                }
            }
            //RegistroBLL ObjReg = new RegistroBLL();
            //DSRegistro.Registro_ReadRegistroDataTable registros = new DSRegistro.Registro_ReadRegistroDataTable(); 
            //registros = ObjReg.GetRegistroById(NroReg);
            //DataRow[] rows = registros.Select();

            //this.DateFechaRad.Text = rows[0].ItemArray[1].ToString().Trim() ;
            //this.TxtDependencia.Text = rows[0].ItemArray[4].ToString().Trim() + " | " + rows[0].ItemArray[19].ToString().Trim();
            //this.RadioButtonList1.SelectedValue = rows[0].ItemArray[17].ToString().Trim();
            //if (RadioButtonList1.SelectedValue == "1")
            //{
            //    this.TxtDestino.Text = rows[0].ItemArray[3].ToString().Trim() + " | " + rows[0].ItemArray[20].ToString().Trim();
            //    this.AutoCompleteDestino.ServiceMethod = "GetDependenciaByText";
            //}
            // if (RadioButtonList1.SelectedValue == "0")
            //{
            //    this.TxtDestino.Text = rows[0].ItemArray[2].ToString().Trim() + " | " + rows[0].ItemArray[24].ToString().Trim() + " | " + rows[0].ItemArray[25].ToString().Trim();
            //    this.AutoCompleteDestino.ServiceMethod = "GetProcedenciaByTextNombre";
            //}
            //this.TxtRadFuente.Text = rows[0].ItemArray[6].ToString().Trim();
            //this.TxtDetalle.Text = rows[0].ItemArray[7].ToString().Trim();
            //this.TxtNaturaleza.Text = rows[0].ItemArray[5].ToString() + " | " + rows[0].ItemArray[21].ToString().Trim();
            //this.TxtMedioRecibo.Text = rows[0].ItemArray[13].ToString() + " | " + rows[0].ItemArray[22].ToString().Trim();
            //this.TxtPesoEnvio.Text = rows[0].ItemArray[15].ToString();
            //this.TxtGuia.Text = rows[0].ItemArray[9].ToString();
            //this.TxtValor.Text = rows[0].ItemArray[16].ToString();
            //this.TxtExpediente.Text = rows[0].ItemArray[12].ToString() + " | " + rows[0].ItemArray[23].ToString().Trim();
            //this.TextBox1.Text = rows[0].ItemArray[14].ToString() + " | " + rows[0].ItemArray[26].ToString().Trim();
            //this.TxtAnexo.Text = rows[0].ItemArray[10].ToString();
            //if (rows[0].ItemArray[27].ToString() == "")
            //{
            //    this.DropDownList1.SelectedValue = "01";
            //}
            //else
            //{
            //    this.DropDownList1.SelectedValue = rows[0].ItemArray[27].ToString();
            //}
            //this.TxtFecMotDev.Visible = true;
            //this.TxtFecMotDev.Text = null;
            //this.ImgFecDev.Visible = true;
            //this.LblFecDev.Visible = true;


            //this.TextBox1.Visible = true;               
            //this.cmdActualizar.Enabled = true;
            //this.cmdAceptar.Enabled = false;
            //this.ExceptionDetails.Text = "Registro Nro"+ NroReg;
            //this.NavDocEnviado1.HFGrupoCodigoValor("2");
            //this.NavDocEnviado1.HFRegistroCodigoValor(NroReg);

            //DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter TARadFuente = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter();
            //DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteDataTable DTRadFuente = new DSRadicadoFuenteSQL.RadicadoFuente_ReadRadicadoFuenteDataTable();
            //DTRadFuente = TARadFuente.GetRadFuente(Convert.ToInt32(NroReg));
            //if (DTRadFuente.Count > 0)
            //{
            //    ListBoxFuente.DataSource = DTRadFuente;
            //    ListBoxFuente.DataBind();
            //}

            //this.DropDownList1.Visible = true;
            //this.LblMotDev.Visible = true;
            DataTable tabla = ejecutar.rtn_traer_registros_por_grupo_por_id(Grupo, NroReg);
            DataRow[] rows = tabla.Select();

            if (tabla.Rows.Count > 0)
            {
                this.mostrar(rows);

                if (RadioButtonList1.SelectedValue == "1") //interno
                {
                    this.AutoCompleteDestino.ServiceMethod = "GetDependenciaByText";
                }
                if (RadioButtonList1.SelectedValue == "0") //externo
                {
                    this.AutoCompleteDestino.ServiceMethod = "GetProcedenciaByTextNombre";
                    // this.TxtDestino.Text = rows[0]["procedenciacoddestino"].ToString().Trim() + " | " + rows[0]["expedientenombre"].ToString().Trim() + " | " + rows[0]["serienombre"].ToString().Trim();
                }

                if (rows[0]["codigomotdevolucion"].ToString() == "")
                {
                    this.DropDownList1.SelectedValue = "101";
                }
                else
                {
                    this.DropDownList1.SelectedValue = rows[0]["codigomotdevolucion"].ToString();
                }

                this.TextBox1.Visible = true;

                this.cmdActualizar.Enabled = true;
                this.RadioButtonList1.Enabled = false;
                this.cmdAceptar.Enabled = false;
                //this.ExceptionDetails.Text = "Registro Nro " + NroReg;
                this.Label6.Text = NroReg;
                this.Label12.Visible = true;

                tabla = ejecutar.rtn_traer_tbtablas_por_Id("GRUPOREG");
                string codigodelgruporegistros = tabla.Rows[0][0].ToString().Trim();
                this.NavDocEnviado1.HFGrupoCodigoValor(this.DropDownListGrupo.SelectedValue);
                this.NavDocEnviado1.HFRegistroCodigoValor(NroReg);
                this.NavDocEnviado1.HFGrupoPadreCodigoValor(codigodelgruporegistros);




                DataTable DTRadFuente = ejecutar.rtn_traer_radicadofuente_por_grupo_por_id(Grupo, Convert.ToInt32(NroReg));
                ListBoxFuente.Items.Clear();
                foreach (DataRow dr in DTRadFuente.Rows)
                {
                    ListBoxFuente.Items.Add(dr["gruporadicadocodigofuente"].ToString() + "--" + dr["radicadocodigofuente"].ToString() + " | " + dr["ProcedenciaNombre"].ToString());
                    this.DropDownListGrupoFuente.SelectedValue = dr["gruporadicadocodigofuente"].ToString().Trim();
                }


                this.DropDownList1.Visible = true;
                this.LblMotDev.Visible = true;
                this.LblFecDev.Visible = true;
                this.TxtFecMotDev.Visible = true;
                this.ImgFecDev.Visible = true;
                this.lbCartaPlantilla.Visible = true;
                this.hlinkCarta.Visible = true;
                this.hlinkCarta.NavigateUrl = "DocEnviadoDevPorNoCompetencia.aspx?RegistroCodigo=" + Convert.ToString(NroReg);

                Session["DatosActualReg"] = this.DateFechaRad.Text + "|" + TxtDestino.Text.ToString() + "|" + TxtDetalle.Text.ToString() + "|" + TxtNaturaleza.Text.ToString().Trim() + "|" + TxtMedioRecibo.Text.ToString() + "|" + TxtGuia.Text.ToString() + "|" + TxtPesoEnvio.Text.ToString() + " " + "|" + TxtValor.Text.ToString() + TxtExpediente.Text.ToString() + "|" + this.TextBox1.Text.ToString() + "|" + TxtAnexo.Text.ToString() + ListBoxEnterar.Text.ToString();
                /*FechaRad+ DependenciaDestinoCod y nombre+ Detalle + NaturaCod y nombre + MedioCodyNombre + Guia + peso envio +  Valor + ExpedienteCodyNombre + Archivar en + Anexo + enterar a:
                */

                string ActLogCod = "BUSCAR";
                DateTime FechaInicio = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                //Se Realiza el Log
                //int NumeroDocumento = Convert.ToInt32(TxtBuscarRadicado.Text);
                string GrupoCod = "2";
                string Datosini = "Buscar por Numero Registro";
                string Datosfin1 = TxtBuscarRadicado.Text;//NUM REG
                DateTime FechaFin = DateTime.Now;
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();

                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Accediendo = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                //Se hace el insert de Log Enviados
                Accediendo.InsertEnviados(LogId, usernam, FechaInicio, ActLogCod, Convert.ToInt32(NroReg), GrupoCod, ModuloLog,
                                            Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                //Se hace el update consecutivo de Logs
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
            }
            else
            {
                this.ExceptionDetails.Text = "No Numero de Registro no fue Encontrado o No Existe Verifique en intente de nuevo";
            }      

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.SetFocus(TextBox1);
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            this.AutoCompleteDestino.ServiceMethod = "GetDependenciaByText";            
            this.PopCDestino.Enabled = true;
            this.ImageButton12.Visible = false;
        }
        else if (RadioButtonList1.SelectedValue == "0")
        {
            this.AutoCompleteDestino.ServiceMethod = "GetProcedenciaByTextNombre";            
            this.PopCDestino.Enabled = false;
            this.ImageButton12.Visible = true;
        }        

    }

    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "1")
        {
            
            this.TxtDependencia1.Text = "";
            this.AutoCompleteExtender3.ServiceMethod = "GetDependenciaByText";
            
            // this.PopCDestino.Enabled = true;
            // //this.TxtDestino.Text = "";

              this.ImageButton12.Visible = false;

        }
        if (RadioButtonList2.SelectedValue == "0")
        {
            
            this.TxtDependencia1.Text = "";
            this.AutoCompleteExtender3.ServiceMethod = "GetProcedenciaByTextNombre";

            //  this.RadioButtonList1.Focus();
            //  this.PopCDestino.Enabled = false;
            //   //this.TxtDestino.Text = "";

              this.ImageButton12.Visible = true;
        }
        // RadioButtonList1.Focus();
        // this.SetFocus(RadioButtonList1);


    }

    protected void ImgBtnAdd_Click(object sender, EventArgs e)
    {
        this.ListBoxEnterar.Items.Add(this.TxtDependencia1.Text.ToString());
        this.TxtDependencia1.Text = "";
    }

    protected void ImgBtnDelete_Click(object sender, EventArgs e)
    {
        this.ListBoxEnterar.Items.Remove(this.ListBoxEnterar.SelectedItem);

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

    protected void TreeVDestino_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        try
        {
            ArbolesBLL ObjArbolDep = new ArbolesBLL();
            DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
            DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
            PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
    protected void RBEnterarA_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBEnterarA.SelectedValue == "T")
        {
            this.ListBoxEnterar.Items.Clear();
            this.TxtDependencia1.Text = "";
            this.TxtDependencia1.ReadOnly = true;

            this.ImgBtnAdd.Enabled = false;
            this.ImgBtnDelete.Enabled = false;
            this.ListBoxEnterar.Items.Add("Todas | Todas");
        }
        else
        {
            this.ListBoxEnterar.Items.Clear();
            this.TxtDependencia1.Text = "";
            this.TxtDependencia1.ReadOnly = false;

            this.ImgBtnAdd.Enabled = true;
            this.ImgBtnDelete.Enabled = true;
        }
    }
    protected void RBFuente_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBFuente.SelectedValue == "T")
        {
            this.ListBoxFuente.Items.Clear();
            this.TxtRadFuente.Text = "";
            this.TxtRadFuente.ReadOnly = true;
            this.ImgBtnAddFuente.Enabled = false;
            this.ImgBtnDeleteFuente.Enabled = false;
            this.ListBoxFuente.Items.Add("Todas | Todas");
        }
        else
        {
            this.ListBoxFuente.Items.Clear();
            this.TxtRadFuente.Text = "";
            this.TxtRadFuente.ReadOnly = false;
            this.ImgBtnAddFuente.Enabled = true;
            this.ImgBtnDeleteFuente.Enabled = true;
        }
    }
    protected void ImgBtnAddFuente_Click(object sender, ImageClickEventArgs e)
    {
        if (!TxtRadFuente.Text.Contains(" | "))
        {
            this.TxtRadFuente.Text += " | ";
        }
        this.ListBoxFuente.Items.Add(this.DropDownListGrupoFuente.SelectedValue.Trim() + "--" + this.TxtRadFuente.Text.Trim());
        //this.ListBoxFuente.Items.Add(this.TxtRadFuente.Text.ToString());
        this.TxtRadFuente.Text = "";
        this.TxtRadFuente.Focus();
    }
    protected void ImgBtnDeleteFuente_Click(object sender, ImageClickEventArgs e)
    {
        this.ListBoxFuente.Items.Remove(this.ListBoxFuente.SelectedItem);
        this.ListBoxFuente.Focus();
    }
    protected void TxtPesoEnvio_TextChanged(object sender, EventArgs e)
    {
        String Var;
        Var = this.TxtMedioRecibo.Text;
        if (Var != "")
        {
            if (Var.Contains(" | "))
            {
                Var = Var.Remove(Var.IndexOf(" | "));
            }
            DSMedioSQLTableAdapters.MedioTableAdapter ObjTaMedio = new DSMedioSQLTableAdapters.MedioTableAdapter();
            DSMedioSQL.MedioDataTable DTMedio = new DSMedioSQL.MedioDataTable();
            DTMedio = ObjTaMedio.GetMedioById(Var);
            this.TxtValor.Text = Convert.ToString(Convert.ToDouble(DTMedio[0].MedioFactor) * Convert.ToDouble(this.TxtPesoEnvio.Text));

        }
        else
        {
            this.ExceptionDetails.Text = "Debe seleccionar previamente un medio de envio";
        }


    }
    protected void TreeVRemite_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        try
        {
            ArbolesBLL ObjArbolDep = new ArbolesBLL();
            DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
            DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
            PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }

    }
    protected void TreeVMedio_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolMed = new ArbolesBLL();
        DSMedioSQL.MedioByTextDataTable DTMedio = new DSMedioSQL.MedioByTextDataTable();
        DTMedio = ObjArbolMed.GetMedioTree(Int32.Parse(e.Node.Value));
        PopulateNodes(DTMedio, e.Node.ChildNodes, "MedioCodigo", "MedioNombre");
    }
    protected void TreeVNaturaleza_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolNat = new ArbolesBLL();
        DSNaturalezaSQL.NaturalezaByTextDataTable DTNaturaleza = new DSNaturalezaSQL.NaturalezaByTextDataTable();
        DTNaturaleza = ObjArbolNat.GetNaturalezaTree(e.Node.Value);
        PopulateNodes(DTNaturaleza, e.Node.ChildNodes, "NaturalezaCodigo", "NaturalezaNombre");
    }
    public void TreeVExpediente_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolExp = new ArbolesBLL();
        DSExpedienteSQL.ExpedienteByTextDataTable DTExpediente = new DSExpedienteSQL.ExpedienteByTextDataTable();
        DTExpediente = ObjArbolExp.GetExpedienteTree(e.Node.Value);
        PopulateNodes(DTExpediente, e.Node.ChildNodes, "ExpedienteCodigo", "ExpedienteNombre");
    }
    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolSer = new ArbolesBLL();
        DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();
        DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
        PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
    }
    //protected void OnSelect(object sender, EventArgs e)
    //{
    //    lblSelection.Text = "You selected <b>" + ((LinkButton)sender).Text + "</b>.";
    //}
    protected void TxtNaturaleza_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmdAceptar_Click(object sender, ImageClickEventArgs e)
    {
        this.ExceptionDetails.Text = "";
        string RegistroCodigo = "1";
        string TipoDocEnviado;
        int WFMovTipo;
        string ActLogCod = "ADICIONAR";
        DateTime FechaInicio = DateTime.Now;
        //OBTENER CONSECUTIVO LOGS
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
        DataRow[] fila = Conse.Select();
        string x = fila[0].ItemArray[0].ToString();
        string LOG = Convert.ToString(x);
        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UserId = objUsr.Aspnet_UserIDByUserName(username).ToString();
        try
        {

            String RadCodString;
            RadCodString = TxtRadFuente.Text;
            if (RadCodString == "")
                RadCodString = null;

            if (RadCodString != null)
            {
                if (RadCodString.Contains(" | "))
                {
                    RadCodString = RadCodString.Remove(RadCodString.IndexOf(" | "));
                }
            }

            if (RadioButtonList1.SelectedValue == "1")
            {
                GrpDocReg = this.DropDownListGrupo.SelectedValue;
                RegistroBLL ObjReg = new RegistroBLL();
                RegistroCodigo = ObjReg.AddRegistro(GrpDocReg, DateTime.Now, null, TxtDestino.Text.ToString(), TxtDependencia.Text.ToString(), TxtNaturaleza.Text.ToString(), Convert.ToInt32(RadCodString), TxtDetalle.Text.ToString(), TxtGuia.Text.ToString(), TxtPesoEnvio.Text.ToString(), TxtGuia.Text, TxtAnexo.Text.ToString(), Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString(), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), TextBox1.Text.ToString(), TxtValor.Text.ToString(), RadioButtonList1.Text.ToString(), WFAccion, DateTime.Now, DateTime.Now, Convert.ToInt32(RadioButtonList1.Text.ToString()), TxtDetalle.Text.ToString(), "0");
                TipoDocEnviado = "1";

                string Datosfin = GrpDocReg + "|" + Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString() + "|" + username + "|" + this.DateFechaRad.Text + "|" + TxtDependencia.Text.ToString() + "|" + TxtDestino.Text.ToString() + "|" + TxtDetalle.Text.ToString() + "|" + TxtNaturaleza.Text.ToString().Trim() + "|" + TxtMedioRecibo.Text.ToString() + "|" + TxtGuia.Text.ToString() + "|" + TxtPesoEnvio.Text.ToString() + " " + "|" + TxtValor.Text.ToString() + TxtExpediente.Text.ToString() + "|" + this.TextBox1.Text.ToString() + "|" + TxtAnexo.Text.ToString();
                //Variable de session para almacenar datos de busqueda y utilizar posteriormente
                Session["DatosfinReg"] = Datosfin;
                //foreach (ListItem Item in ListBoxFuente.Items)
                //{
                //    if (Item.Text != null)
                //    {
                //        if (Item.Text.Contains(" | "))
                //        {
                //            Item.Text = Item.Text.Remove(Item.Text.IndexOf(" | "));
                //        }
                //    }
                //    DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter TARadFuente = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter();
                //    TARadFuente.Insert(Convert.ToInt32(RegistroCodigo), Convert.ToInt32(Item.Text));
                //}
          
                this.insertarradicadosfuente(RegistroCodigo);

                
            }
            else
            {
                GrpDocReg = this.DropDownListGrupo.SelectedValue;
                RegistroBLL ObjReg = new RegistroBLL();
                RegistroCodigo = ObjReg.AddRegistro(GrpDocReg, DateTime.Now, TxtDestino.Text.ToString(), null, TxtDependencia.Text.ToString(), TxtNaturaleza.Text.ToString(), Convert.ToInt32(RadCodString), TxtDetalle.Text.ToString(), TxtGuia.Text.ToString(), TxtPesoEnvio.Text.ToString(), TxtGuia.Text, TxtAnexo.Text.ToString(), Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString(), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), TextBox1.Text.ToString(), TxtValor.Text.ToString(), RadioButtonList1.Text.ToString(), WFAccion, DateTime.Now, DateTime.Now, Convert.ToInt32(RadioButtonList1.Text.ToString()), TxtDetalle.Text.ToString(), "0");
                this.insertarradicadosfuente(RegistroCodigo);
                TipoDocEnviado = "0";

                string Datosfin = GrpDocReg + "|" + Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString() + "|" + username + "|" + this.DateFechaRad.Text + "|" + TxtDependencia.Text.ToString() + "|" + TxtDestino.Text.ToString() + "|" + TxtDetalle.Text.ToString() + "|" + TxtNaturaleza.Text.ToString().Trim() + "|" + TxtMedioRecibo.Text.ToString() + "|" + TxtGuia.Text.ToString() + "|" + TxtPesoEnvio.Text.ToString() + " " + "|" + TxtValor.Text.ToString() + TxtExpediente.Text.ToString() + "|" + this.TextBox1.Text.ToString() + "|" + TxtAnexo.Text.ToString();
                //Variable de session para almacenar datos de busqueda y utilizar posteriormente
                Session["DatosfinReg"] = Datosfin;
                
                //foreach (ListItem Item in ListBoxFuente.Items)
                //{
                //    if (Item.Text != null)
                //    {
                //        if (Item.Text.Contains(" | "))
                //        {
                //            Item.Text = Item.Text.Remove(Item.Text.IndexOf(" | "));
                //        }
                //    }
                //    DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter TARadFuente = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter();
                //    TARadFuente.Insert(Convert.ToInt32(RegistroCodigo), Convert.ToInt32(Item.Text));
                //}
                //if (RBEnterarA.SelectedValue == "T")
                //{
                //    String Correcto = ObjReg.CopiasRegistro(TxtDependencia.Text.ToString(), DateTime.Now, null, this.ListBoxEnterar.Items[0].Value, WFAccion, DateTime.Now, DateTime.Now, 5, null, null, RegistroCodigo, GrpDocReg, DateTime.Now, "0");

                //}
                //else
                //{
                //    for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
                //    {
                //        String Correcto = ObjReg.CopiasRegistro(TxtDependencia.Text.ToString(), DateTime.Now, null, this.ListBoxEnterar.Items[i].Value, WFAccion, DateTime.Now, DateTime.Now, 5, null, null, RegistroCodigo, GrpDocReg, DateTime.Now, "0");
                //    }
                //}
            }

            if (TipoDocEnviado == "1")
            {
                WFMovTipo = 6;
            }
            else
            {
                WFMovTipo = 5;
            }

            if (RadioButtonList2.SelectedValue == "1")
            {
                RegistroBLL ObjReg = new RegistroBLL();
                if (RBEnterarA.SelectedValue == "T")
                {
                    String Correcto = ObjReg.CopiaTodosRegistro(TxtDependencia.Text.ToString(), this.ListBoxEnterar.Items[0].Value, WFAccion, DateTime.Now, DateTime.Now, WFMovTipo, TxtDetalle.Text.ToString(), null, RegistroCodigo, GrpDocReg, DateTime.Now, "0");
            
                    //String Correcto = ObjReg.CopiasRegistro(TxtDependencia.Text.ToString(), DateTime.Now, this.ListBoxEnterar.Items[0].Value, null, WFAccion, DateTime.Now, DateTime.Now, WFMovTipo, null, null, RegistroCodigo, GrpDocReg, DateTime.Now, "0");

                }
                else
                {
                    for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
                    {
                        String Correcto = ObjReg.CopiasRegistro(TxtDependencia.Text.ToString(), DateTime.Now, this.ListBoxEnterar.Items[i].Value, null, WFAccion, DateTime.Now, DateTime.Now, WFMovTipo, null, null, RegistroCodigo, GrpDocReg, DateTime.Now, "0");
                    }
                }
            }
            else
            {
                RegistroBLL ObjReg = new RegistroBLL();
                if (RBEnterarA.SelectedValue == "1")
                {
                    String Correcto = ObjReg.CopiasRegistro(TxtDependencia.Text.ToString(), DateTime.Now, null, this.ListBoxEnterar.Items[0].Value, WFAccion, DateTime.Now, DateTime.Now, 6, null, null, RegistroCodigo, GrpDocReg, DateTime.Now, "0");
                }
                else
                {
                    for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
                    {
                        String Correcto = ObjReg.CopiasRegistro(TxtDependencia.Text.ToString(), DateTime.Now, null, this.ListBoxEnterar.Items[i].Value, WFAccion, DateTime.Now, DateTime.Now, 6, null, null, RegistroCodigo, GrpDocReg, DateTime.Now, "0");
                    }
                }
            }

            //Modificar Cookies
            HttpCookie DependenciaEnvCookie = Request.Cookies.Get("DependenciaEnv");
            DependenciaEnvCookie.Value = this.TxtDependencia.Text.ToString();
            Response.Cookies.Set(DependenciaEnvCookie);

            HttpCookie DestinoEnvCookie = Request.Cookies.Get("DestinoEnv");
            DestinoEnvCookie.Value = this.TxtDestino.Text.ToString();
            Response.Cookies.Set(DestinoEnvCookie);

            HttpCookie TipoEnvCookie = Request.Cookies.Get("TipoEnv");
            TipoEnvCookie.Value = this.RadioButtonList1.SelectedValue.ToString();
            Response.Cookies.Set(TipoEnvCookie);

            HttpCookie NaturalezaEnvCookie = Request.Cookies.Get("NaturalezaEnv");
            NaturalezaEnvCookie.Value = this.TxtNaturaleza.Text.ToString();
            Response.Cookies.Set(NaturalezaEnvCookie);

            HttpCookie MedioEnvCookie = Request.Cookies.Get("MedioEnv");
            MedioEnvCookie.Value = this.TxtMedioRecibo.Text.ToString();
            Response.Cookies.Set(MedioEnvCookie);

            HttpCookie ExpedienteEnvCookie = Request.Cookies.Get("ExpedienteEnv");
            ExpedienteEnvCookie.Value = this.TxtExpediente.Text.ToString();
            Response.Cookies.Set(ExpedienteEnvCookie);

            HttpCookie SerieEnvCookie = Request.Cookies.Get("SerieEnv");
            SerieEnvCookie.Value = this.TextBox1.Text.ToString();
            Response.Cookies.Set(SerieEnvCookie);
            
            //mostrar etiqueta de consecutivo documento
            tabla = ejecutar.rtn_traer_tbtablas_por_Id("GRUPOREG");
            string codigodelgruporegistros = tabla.Rows[0][0].ToString().Trim();
            this.NavDocEnviado1.HFGrupoCodigoValor(this.DropDownListGrupo.SelectedValue);
            this.NavDocEnviado1.HFRegistroCodigoValor(RegistroCodigo);
            this.NavDocEnviado1.HFGrupoPadreCodigoValor(codigodelgruporegistros);
            //this.NavDocEnviado1.HFGrupoCodigoValor("2");
            //this.NavDocEnviado1.HFRegistroCodigoValor(RegistroCodigo);
            //this.ExceptionDetails.Text = "Registro Nro" + " " + RegistroCodigo;
            this.Label6.Text = RegistroCodigo;
            this.Label12.Visible = true;

            this.hlinkCarta.Visible = true;
            this.lbCartaPlantilla.Visible = true;
            this.hlinkCarta.NavigateUrl = "DocEnviadoDevPorNoCompetencia.aspx?RegistroCodigo=" + Convert.ToString(RegistroCodigo);

            this.LblMessageBox.Text = "Registro Nro" + " " + RegistroCodigo;
            Session["CodRegistro"] = RegistroCodigo;
            this.ModalPopupExtender1.Show();
            this.ListBoxFuente.Items.Clear();
            this.TxtAnexo.Text = "";
            this.ListBoxEnterar.Items.Clear();
            if (RadioButtonList1.SelectedValue == "1")
            {
                
                MailBLL Correo = new MailBLL();
                MembershipUser usuario;
                DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuarioxDependencia = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
                DSUsuario.UsuariosxdependenciaDataTable DTUsuariosxDependencia = new DSUsuario.UsuariosxdependenciaDataTable();
                DTUsuariosxDependencia = ObjTaUsuarioxDependencia.GetUsuariosxDependenciaByDependencia(this.TxtDestino.Text.Remove(TxtDestino.Text.IndexOf(" | ")).ToString().Trim());
                if (DTUsuariosxDependencia.Count > 0)
                {
                    DataRow[] rows = DTUsuariosxDependencia.Select();
                    System.Guid a = new Guid(rows[0].ItemArray[0].ToString().Trim());
                    DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter objReadUser = new DSaspnet_UsersTableAdapters.Aspnet_Users_ReadUsersByUserNameTableAdapter();
                    DSaspnet_Users.Aspnet_Users_ReadUsersByUserNameDataTable TablaRead = new DSaspnet_Users.Aspnet_Users_ReadUsersByUserNameDataTable();
                    TablaRead = objReadUser.GetDataByUserId(a.ToString());
                    DataRow[] rowsUser = TablaRead.Select();
                    string Usrname = rowsUser[0].ItemArray[1].ToString();
                    usuario = Membership.GetUser(Usrname);
                    string Body = "Tiene un nuevo Registro Nro " + RegistroCodigo + "<BR>" + " Fecha de Tramite: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "<BR>" + "Dependencia: " + this.TxtDependencia.Text.ToString() + "<BR>" + "Naturaleza: " + this.TxtNaturaleza.Text.ToString().Trim() + "<BR>";
                    Correo.EnvioCorreo("alfanet@mutualser.org", usuario.Email, "Registro Nro" + " " + RegistroCodigo, Body, true, "1");
                }
            }
            DateTime FechaFin = DateTime.Now;
            int NumeroDocumento = Convert.ToInt32(this.Label6.Text);
            string GrupoCod = GrpDocReg;
            string Datosini = "";
            /*DATOS FIN:   GrupoDoc+ CodDepUsuario+ username+ FechaRad+ DependenciaCod y nombre + DependenciaDestinoCod y nombre+ Detalle + NaturaCod y nombre + MedioCodyNombre + Guia + peso envio +  Valor + ExpedienteCodyNombre + Archivar en + Anexo
             */

            string Datosfin1 = Session["DatosfinReg"].ToString();
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();

            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter DocInsertEnv = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            //Se hace el insert de Log Enviados Adicionar
            DocInsertEnv.InsertEnviados(LogId, username, FechaInicio, ActLogCod, NumeroDocumento, GrupoCod, ModuloLog,
                                        Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
            //Se actualiza el consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

            /*Registrar el evento de busqueda*/
            String Ip_cliente = Context.Request.UserHostAddress;
            //String Uri_OrigRef = Context.Request.UrlReferrer.OriginalString;

            log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


            String Log = "1" + " " + RegistroCodigo + " " + this.DropDownListGrupo.SelectedValue + "?" + value_pipe(this.TxtDependencia.Text) + "?" + value_pipe(this.TxtDestino.Text) + "?" + this.TxtDetalle.Text + "?" +
                value_pipe(this.TxtNaturaleza.Text) + "?" + value_pipe(this.TxtMedioRecibo.Text) + "?" + this.TxtGuia.Text + "?" +
                this.TxtPesoEnvio.Text + "?" + this.DropDownList1.SelectedValue + "?" + this.TxtFecMotDev.Text + "?" + value_pipe(TxtExpediente.Text) + "?" + value_pipe(this.TextBox1.Text) + "?" +
                Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + "?" + TxtAnexo.Text;


            //ILog logger = LogManager.GetLogger("primerEjemplo");
            logger.Fatal(Ip_cliente + " " + Log); 
            


        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = this.ExceptionDetails.Text;
            DateTime WFMovimientoFechaFin = DateTime.Now;

            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConsecutivosErr = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable ConseErr = new DSGrupoSQL.ConsecutivoLogsDataTable();
            ConseErr = ConsecutivosErr.GetConseError(ConsecutivoCodigoErr);
            DataRow[] fila2 = ConseErr.Select();
            string z = fila2[0].ItemArray[0].ToString();
            string LOGERROR = Convert.ToString(z);
            Int64 LogIdErr = Convert.ToInt64(LOGERROR);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();

            DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter Errores = new DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter();
            Errores.GetError(LogIdErr, username, FechaInicio, ActividadLogCodigoErr, GrpDocReg, ModuloLog,
                             DatosFinales, WFMovimientoFechaFin, IP, NombreEquipo,
                             Navegador);
            //ACTUALIZA el consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
        }
    }
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
    protected void cmdCancel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("~/AlfaNetWorkFlow/AlfaNetWF/WorkFlow.aspx", true);
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
    protected void BtnNuevoRad_Click(object sender, ImageClickEventArgs e)
    {
        this.TxtBuscarRadicado.Text = null;
        this.TxtDependencia.Text = null;
        this.TxtDestino.Text = null;
        this.TxtRadFuente.Text = null;
        this.ListBoxFuente.Items.Clear();
        this.TxtDetalle.Text = null;
        this.TxtNaturaleza.Text = null;
        this.TxtMedioRecibo.Text = null;
        this.TxtGuia.Text = null;
        this.TxtPesoEnvio.Text = null;
        this.TxtValor.Text = null;
        this.TxtExpediente.Text = null;
        this.TextBox1.Text = null;
        this.TxtAnexo.Text = null;
        this.TxtDependencia1.Text = null;
        this.ExceptionDetails.Text = null;
        this.TxtFecMotDev.Text = null;

        this.cmdActualizar.Enabled = false;
        this.cmdAceptar.Enabled = true;

        this.DropDownList1.Visible = false;
        this.LblMotDev.Visible = false;
        this.RadioButtonList1.Enabled = true;

        this.ListBoxEnterar.Items.Clear();
        this.RadioButtonList1.SelectedValue = "1";
        this.AutoCompleteDestino.ServiceMethod = "GetDependenciaByText";


    }
    protected void cmdActualizar_Click(object sender, ImageClickEventArgs e)
    {
        Session["CodRegistro"] = "";
        this.ExceptionDetails.Text = "";
        GrpDocReg = this.DropDownListGrupo.SelectedValue;
        DataTable DTRadFuente = new DataTable();
        string grupofuente = "";
        string RegistroCodigo = "";
        string FechaActMotDevolucion;

        string ActLogCod = "ACTUALIZAR";
        DateTime FechaInicio = DateTime.Now;
        //OBTENER CONSECUTIVO LOGS
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
        DataRow[] fila = Conse.Select();
        string x = fila[0].ItemArray[0].ToString();
        string LOG = Convert.ToString(x);
        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UserId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                
        try
        {

            String MotDev;
            if (DropDownList1.SelectedValue == "01")
            {
                MotDev = "01";
                FechaActMotDevolucion = Convert.ToString(DateTime.Today);
            }
            else
            {
                MotDev = DropDownList1.SelectedValue;
                
                FechaActMotDevolucion = Convert.ToString(DateTime.Today);
                
            }
            String NroReg = null;

            if (TxtBuscarRadicado.Text.ToString().Contains(" | "))
            {
                NroReg = TxtBuscarRadicado.Text.Remove(TxtBuscarRadicado.Text.ToString().IndexOf(" | "));
                TxtBuscarRadicado.Text = TxtBuscarRadicado.Text.Remove(TxtBuscarRadicado.Text.IndexOf(" | "));
            }
			//Datos Actualizados
            Session["DatosUpdateReg"] = this.DateFechaRad.Text + "|" + TxtDestino.Text.ToString() + "|" + TxtDetalle.Text.ToString() + "|" + TxtNaturaleza.Text.ToString().Trim() + "|" + TxtMedioRecibo.Text.ToString() + "|" + TxtGuia.Text.ToString() + "|" + TxtPesoEnvio.Text.ToString() + " " + "|" + TxtValor.Text.ToString() + TxtExpediente.Text.ToString() + "|" + this.TextBox1.Text.ToString() + "|" + TxtAnexo.Text.ToString() + ListBoxEnterar.Text.ToString();

            if (RadioButtonList1.SelectedValue == "1")
            {
                string RadFuente = TxtRadFuente.Text;
                if (TxtRadFuente.Text == "")
                    RadFuente = null;
                
                    RegistroBLL ObjUpdate = new RegistroBLL();
                    ObjUpdate.UpdateRegistro(TxtBuscarRadicado.Text.ToString(), Convert.ToDateTime(DateFechaRad.Text.ToString()), null, TxtDestino.Text.ToString(), TxtDependencia.Text.ToString(), TxtNaturaleza.Text.ToString(), Convert.ToInt32(RadFuente), TxtDetalle.Text.ToString(), TxtGuia.Text.ToString(), TxtPesoEnvio.Text.ToString(), TxtGuia.Text.ToString(), TxtAnexo.Text.ToString(), TxtRadFuente.Text.ToString(), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), TextBox1.Text.ToString(), TxtValor.Text.ToString(), RadioButtonList1.Text.ToString(), TxtBuscarRadicado.Text.ToString(), GrpDocReg, GrpDocReg, MotDev, this.TxtFecMotDev.Text.ToString(), FechaActMotDevolucion);
                
                if (RBEnterarA.SelectedValue == "T")
                {
                    String Correcto = ObjUpdate.CopiasRegistro(TxtDependencia.Text.ToString(), DateTime.Now, this.ListBoxEnterar.Items[0].Value, null, WFAccion, DateTime.Now, DateTime.Now, 6, null, null, NroReg, GrpDocReg, DateTime.Now, "0");
                }
                else
                {
                    for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
                    {
                        String Correcto = ObjUpdate.CopiasRegistro(TxtDependencia.Text.ToString(), DateTime.Now, this.ListBoxEnterar.Items[i].Value, null, WFAccion, DateTime.Now, DateTime.Now, 6, null, null, NroReg, GrpDocReg, DateTime.Now, "0");
                    }
                }

                //DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter TARadFuente = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter();
                //if (TxtBuscarRadicado.Text != null)
                //{
                //    if (TxtBuscarRadicado.Text.Contains(" | "))
                //    {
                //        TxtBuscarRadicado.Text = TxtBuscarRadicado.Text.Remove(TxtBuscarRadicado.Text.IndexOf(" | "));
                //    }
                //}

                //TARadFuente.Delete(Convert.ToInt32(TxtBuscarRadicado.Text));
                //foreach (ListItem Item in ListBoxFuente.Items)
                //{
                //    if (Item.Text != null)
                //    {
                //        if (Item.Text.Contains(" | "))
                //        {
                //            Item.Text = Item.Text.Remove(Item.Text.IndexOf(" | "));
                //        }
                //    }

                //    TARadFuente.Insert(Convert.ToInt32(TxtBuscarRadicado.Text), Convert.ToInt32(Item.Text));
                //}
                DTRadFuente = ejecutar.rtn_borrar_radicadofuente_por_grupo_por_id(GrpDocReg, Convert.ToInt32(TxtBuscarRadicado.Text));

                RegistroCodigo = this.TxtBuscarRadicado.Text;
                this.insertarradicadosfuente(RegistroCodigo);
            }
            else if (RadioButtonList1.SelectedValue == "0")
            {
                RegistroBLL ObjUpdate = new RegistroBLL();
                ObjUpdate.UpdateRegistro(TxtBuscarRadicado.Text.ToString(), Convert.ToDateTime(DateFechaRad.Text.ToString()), TxtDestino.Text.ToString(), null, TxtDependencia.Text.ToString(), TxtNaturaleza.Text.ToString(), Convert.ToInt32("0"), TxtDetalle.Text.ToString(), TxtGuia.Text.ToString(), TxtPesoEnvio.Text.ToString(), TxtGuia.Text.ToString(), TxtAnexo.Text.ToString(), TxtRadFuente.Text.ToString(), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), TextBox1.Text.ToString(), TxtValor.Text.ToString(), RadioButtonList1.Text.ToString(), TxtBuscarRadicado.Text.ToString(), GrpDocReg, GrpDocReg, MotDev, this.TxtFecMotDev.Text.ToString(), FechaActMotDevolucion);
                if (RBEnterarA.SelectedValue == "T")
                {
                    String Correcto = ObjUpdate.CopiasRegistro(TxtDependencia.Text.ToString(), DateTime.Now, this.ListBoxEnterar.Items[0].Value, null, WFAccion, DateTime.Now, DateTime.Now, 5, null, null, NroReg, GrpDocReg, DateTime.Now, "0");

                }
                else
                {
                    for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
                    {
                        String Correcto = ObjUpdate.CopiasRegistro(TxtDependencia.Text.ToString(), DateTime.Now, this.ListBoxEnterar.Items[i].Value, null, WFAccion, DateTime.Now, DateTime.Now, 5, null, null, NroReg, GrpDocReg, DateTime.Now, "0");
                    }
                }

                DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter TARadFuente = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter();
                //if (TxtBuscarRadicado.Text != null)
                //{
                //    if (TxtBuscarRadicado.Text.Contains(" | "))
                //    {
                //        TxtBuscarRadicado.Text = TxtBuscarRadicado.Text.Remove(TxtBuscarRadicado.Text.IndexOf(" | "));
                //    }
                //}

                //TARadFuente.Delete(Convert.ToInt32(TxtBuscarRadicado.Text));
                //foreach (ListItem Item in ListBoxFuente.Items)
                //{
                //    if (Item.Text != null)
                //    {
                //        if (Item.Text.Contains(" | "))
                //        {
                //            Item.Text = Item.Text.Remove(Item.Text.IndexOf(" | "));
                //        }
                //    }

                //    TARadFuente.Insert(Convert.ToInt32(TxtBuscarRadicado.Text), Convert.ToInt32(Item.Text));
                //}
                DTRadFuente = ejecutar.rtn_borrar_radicadofuente_por_grupo_por_id(GrpDocReg, Convert.ToInt32(TxtBuscarRadicado.Text));
                // insertar radicados fuente
                RegistroCodigo = this.TxtBuscarRadicado.Text;

                this.insertarradicadosfuente(RegistroCodigo);


            }
            RegistroCodigo = TxtBuscarRadicado.Text;

            tabla = ejecutar.rtn_traer_tbtablas_por_Id("GRUPOREG");
            string codigodelgruporegistros = tabla.Rows[0][0].ToString().Trim();

            this.NavDocEnviado1.HFGrupoCodigoValor(this.DropDownListGrupo.SelectedValue);
            this.NavDocEnviado1.HFRegistroCodigoValor(RegistroCodigo);
            this.NavDocEnviado1.HFGrupoPadreCodigoValor(codigodelgruporegistros);
            this.LblMessageBox.Text = "Registro Actualizado Nro" + " " + RegistroCodigo;
            this.ModalPopupExtender1.Show();

            // LOG 
            int NumeroDocumento = Convert.ToInt32(Session["NumDocReg"]);
            string Datosini = Session["DatosActualReg"].ToString();
            string Datosfin1 = Session["DatosUpdateReg"].ToString();
            DateTime FechaFin = DateTime.Now;
            Int64 LogId = Convert.ToInt64(LOG);
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();

            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter DocupdateReg = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
            //Se inserta el Log de actualizar
            DocupdateReg.InsertEnviados(LogId, username, FechaInicio, ActLogCod, NumeroDocumento, GrpDocReg,
                                        ModuloLog, Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
            //Se hace el consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigo);

            /*Registrar el evento de busqueda*/
            String Ip_cliente = Context.Request.UserHostAddress;
            //String Uri_OrigRef = Context.Request.UrlReferrer.OriginalString;

            log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


            String Log = "1" + " " + RegistroCodigo + " " + this.DropDownListGrupo.SelectedValue + "?" + value_pipe(this.TxtDependencia.Text) + "?" + value_pipe(this.TxtDestino.Text) + "?" + this.TxtDetalle.Text + "?" +
                value_pipe(this.TxtNaturaleza.Text) + "?" + value_pipe(this.TxtMedioRecibo.Text) + "?" + this.TxtGuia.Text + "?" +
                this.TxtPesoEnvio.Text + "?" + this.DropDownList1.SelectedValue + "?" + this.TxtFecMotDev.Text + "?" + value_pipe(TxtExpediente.Text) + "?" + value_pipe(this.TextBox1.Text) + "?" +
                Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString() + "?" + TxtAnexo.Text;


            //ILog logger = LogManager.GetLogger("primerEjemplo");
            logger.Fatal(Ip_cliente + " " + Log); 

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = this.ExceptionDetails.Text;
            DateTime WFMovimientoFechaFin = DateTime.Now;
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConsecutivosErr = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable ConseErr = new DSGrupoSQL.ConsecutivoLogsDataTable();
            ConseErr = ConsecutivosErr.GetConseError(ConsecutivoCodigoErr);
            DataRow[] fila2 = ConseErr.Select();
            string z = fila2[0].ItemArray[0].ToString();
            string LOGERROR = Convert.ToString(z);
            Int64 LogIdErr = Convert.ToInt64(LOGERROR);
            System.Web.HttpBrowserCapabilities nav = Request.Browser;
            string IP = Session["IP"].ToString();
            string NombreEquipo = Session["Nombrepc"].ToString();
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Se hace el insert de Log error
            DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter Errores = new DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter();
            Errores.GetError(LogIdErr, username, FechaInicio, ActividadLogCodigoErr, GrpDocReg, ModuloLog, DatosFinales,
            WFMovimientoFechaFin, IP, NombreEquipo, Navegador);
            //Se hace el update consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
        }
    }
    protected void DropDownListGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Application["gruporegistro"] = this.DropDownListGrupo.SelectedValue.ToString();
        TxtBuscarRadicado.Text = null;
    }
    protected void DropDownListGrupoFuente_SelectedIndexChanged(object sender, EventArgs e)
    {
        Application["grupo"] = this.DropDownListGrupoFuente.SelectedValue.ToString();
    }
    protected void mostrar(DataRow[] rows)
    {
        this.DateFechaRad.Text = rows[0]["wfmovimientofecha"].ToString().Trim();
        this.TxtDependencia.Text = rows[0]["dependenciacodigo"].ToString().Trim() + " | " + rows[0]["dependencianombre"].ToString().Trim();
        this.RadioButtonList1.SelectedValue = rows[0]["registrotipo"].ToString().Trim();

        if (RadioButtonList1.SelectedValue == "1") //interno
        {
            this.TxtDestino.Text = rows[0]["dependenciacoddestino"].ToString().Trim() + " | " + rows[0]["dependencianombre1"].ToString().Trim();
        }
        if (RadioButtonList1.SelectedValue == "0") //externo
        {
            this.TxtDestino.Text = rows[0]["procedenciacoddestino"].ToString().Trim() + " | " + rows[0]["procedencianombre"].ToString().Trim() + " | " + rows[0]["ciudadnombre"].ToString().Trim();
        }
        this.TxtRadFuente.Text = rows[0]["radicadocodigo"].ToString().Trim();
        this.TxtDetalle.Text = rows[0]["registrodetalle"].ToString().Trim();
        this.TxtNaturaleza.Text = rows[0]["naturalezacodigo"].ToString() + " | " + rows[0]["naturalezanombre"].ToString().Trim();
        this.TxtMedioRecibo.Text = rows[0]["mediocodigo"].ToString() + " | " + rows[0]["medionombre"].ToString().Trim();
        this.TxtPesoEnvio.Text = rows[0]["regpesoenvio"].ToString();
        this.TxtGuia.Text = rows[0]["registroempguia"].ToString();
        this.TxtValor.Text = rows[0]["regvalorenvio"].ToString();
        this.TxtExpediente.Text = rows[0]["expedientecodigo"].ToString() + " | " + rows[0]["expedientenombre"].ToString().Trim();
        this.TextBox1.Text = rows[0]["seriecodigo"].ToString() + " | " + rows[0]["serienombre"].ToString().Trim();
        this.TxtAnexo.Text = rows[0]["anexoextregistro"].ToString();
        this.Label11.Text = rows[0]["logdigitador"].ToString().Trim() + " | " + rows[0]["NombreRadicador"].ToString().Trim();

       // MotDevolucionAnterior = rows[0]["MotivoDevolucion"].ToString();

        if (rows[0]["FechaMotDevolucion"].ToString() == "01/01/1900 12:00:00 a.m.")
        {
            this.TxtFecMotDev.Text = null;
        }
        else{
            this.TxtFecMotDev.Text =rows[0]["FechaMotDevolucion"].ToString();
            }
         



    }
    protected void insertarradicadosfuente(string RegistroCodigo)
    {
        string grupofuente = "";
        foreach (System.Web.UI.WebControls.ListItem Item in ListBoxFuente.Items)
        {
            string xcodigo = "";
            if (Item.Text != null)
            {
                if (Item.Text.Contains("|"))
                {
                    if (Item.Text.Contains("--"))
                    {
                        int correr = 0;
                        correr = Item.Text.IndexOf("|") - (Item.Text.IndexOf("--") + 2);
                        grupofuente = Item.Text.Substring(0, Item.Text.IndexOf("--"));
                        xcodigo = Item.Text.Substring(Item.Text.IndexOf("--") + 2, correr);
                    }
                    else
                    {
                        xcodigo = Item.Text.Remove(Item.Text.IndexOf("|"));
                    }

                }
                else
                //{

                //    grupofuente = DropDownListGrupoFuente.SelectedValue;
                //    xcodigo = Item.Text.Substring(Item.Text.IndexOf("--") + 2, correr);
                    xcodigo = Item.Text;
                //}

                //}
                //if (Item.Text != null)
                //        {
                //           if (Item.Text.Contains(" | "))
                //            {
                //                Item.Text = Item.Text.Remove(Item.Text.IndexOf(" | "));

                //            }
                //        }
                DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter TARadFuente = new DSRadicadoFuenteSQLTableAdapters.RadicadoFuente_ReadRadicadoFuenteTableAdapter();
                TARadFuente.Insert(GrpDocReg, Convert.ToInt32(RegistroCodigo), this.DropDownListGrupoFuente.SelectedValue, Convert.ToInt32(xcodigo));
                //                           DataTable DTRadFuente = ejecutar.rtn_insertar_radicadofuente_por_grupo_por_id(GrpDocReg, Convert.ToInt32(RegistroCodigo), grupofuente, Convert.ToInt32(xcodigo));

            }
        }

        }

    protected void RadioButtonList1_Load(object sender, EventArgs e)
    {
        try
        {
            //if (!IsPostBack)
            //{
                foreach (ListItem RBLI in RadioButtonList1.Items)
                {
                    RBLI.Attributes.Add("onclick", "checkControl('" + TxtDestino.ClientID + "')");
                }

            //}

        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
}

        
           
      
