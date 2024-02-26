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

public partial class _NuevoDocRecibido1 : System.Web.UI.Page 
{
    string GrpDocRad = "1";
    rutinas ejecutar = new rutinas();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        this.TxtSerieD.Attributes.Add("onkeydown", "return Disable_Attr(event,getElementById('" + this.TxtSerieD.ClientID + "'),getElementById('" + this.HFCargar.ClientID + "'));");
        System.Data.DataTable tabla = new DataTable();
    try
    {
        String Fecha = DateTime.Today.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        String Mayuscula = Fecha.Substring(0, 1).ToUpper();
        string minuscula = Fecha.Substring(1);


        
        this.Label10.Visible = false;
        this.Label11.Visible = false;
        
        if (!IsPostBack)
            {
                this.Label10.Visible = false;
                this.Label11.Visible = false;
                this.Label7.Visible = false;
                // llena el cuadro de lista grupo
                string codigodelgruporadicados = "";
                tabla = ejecutar.rtn_traer_tbtablas_por_Id("GRUPORAD");
                codigodelgruporadicados = tabla.Rows[0][0].ToString().Trim();

                tabla = ejecutar.rtn_traer_grupos_por_codigopadre(codigodelgruporadicados);

                if (tabla.Rows.Count == 0)
                {
                    tabla = ejecutar.rtn_traer_grupos_por_Id(codigodelgruporadicados);
                }

                this.DropDownListGrupo.DataTextField = "gruponombre";
                this.DropDownListGrupo.DataValueField = "grupocodigo";
                this.DropDownListGrupo.DataSource = tabla;
                this.DropDownListGrupo.DataBind();
                this.DropDownListGrupo.SelectedIndex = 0;
                Application["grupo"] = this.DropDownListGrupo.SelectedValue.ToString();

            
            // atrributos arboles de parametros javascript
                this.TreeView1.Attributes["onClick"] = "return OnTreeClick(event);";
                this.TreeVProceso.Attributes["onClick"] = "return OnTreeProcesoClick(event);";
                this.TreeVSerie.Attributes["onClick"] = "return OnTreeSerieClick(event);";
                this.TreeVAccion.Attributes["onClick"] = "return OnTreeAccionClick(event);";
                this.TreeVExpediente.Attributes["OnClick"] = "return OnTreeExpedienteClick(event)";
                this.TreeVMedio.Attributes["onClick"] = "return OnTreeMedioClick(event);";
                this.TreeVNaturaleza.Attributes["onClick"] = "return OnTreeNaturalezaClick(event," + this.TxtNaturaleza.ClientID +");";
                
            //Fecha Radicado                
                this.TxtSerieD.Enabled = true;
                this.TxtAccion.Enabled = true;
                this.cmdActualizar.Enabled = false;
                this.cmdAceptar.Enabled = true;
                
            // Validacion de FechaVencimiento respecto a fecha de procedencia
                this.RangeVFecVen.MinimumValue = (DateTime.Today.Day)+"/"+DateTime.Today.Month+"/"+DateTime.Today.Year;
                this.RangeVFecVen0.MaximumValue = (DateTime.Today.Day) + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
            //Leer O Escribir Cookies
            if (Request.Cookies.Get("FechaPro") != null || Request.Cookies.Get("FechaVen") != null || Request.Cookies.Get("Procedencia") != null || Request.Cookies.Get("Naturaleza") != null || Request.Cookies.Get("Medio") != null || Request.Cookies.Get("Expediente") != null || Request.Cookies.Get("Accion") != null)
                        {
                            // Recogemos la cookie que nos interese                        
                            HttpCookie FechaProCookie = Request.Cookies.Get("FechaPro");
                            HttpCookie FechaVenCookie = Request.Cookies.Get("FechaVen");
                            HttpCookie ProcedenciaCookie = Request.Cookies.Get("Procedencia");
                            HttpCookie NaturalezaCookie = Request.Cookies.Get("Naturaleza");
                            HttpCookie MedioCookie = Request.Cookies.Get("Medio");
                            HttpCookie ExpedienteCookie = Request.Cookies.Get("Expediente");
                            HttpCookie AccionCookie = Request.Cookies.Get("Accion");
                            //Asignar valores de cookies a formulario
                            this.SelDateFechaVencimiento.Text = FechaVenCookie.Value;
                            this.SelDateFechaProcedencia.Text = FechaProCookie.Value;
                            this.TxtProcedencia.Text = ProcedenciaCookie.Value;
                            this.TxtNaturaleza.Text = NaturalezaCookie.Value;
                            this.TxtMedioRecibo.Text = MedioCookie.Value;
                            this.TxtExpediente.Text = ExpedienteCookie.Value;
                            this.TxtAccion.Text = AccionCookie.Value;

                        }
                        else if (Request.Cookies.Get("FechaPro") == null || Request.Cookies.Get("FechaVen") == null || Request.Cookies.Get("Procedencia") == null || Request.Cookies.Get("Naturaleza") == null || Request.Cookies.Get("Medio") == null || Request.Cookies.Get("Expediente") == null || Request.Cookies.Get("Accion") == null)
                        {
                            HttpCookie FechaVenCookie = new HttpCookie("FechaVen", this.SelDateFechaVencimiento.Text.ToString());
                            HttpCookie FechaProCookie = new HttpCookie("FechaPro", this.SelDateFechaProcedencia.Text.ToString());
                            HttpCookie ProcedenciaCookie = new HttpCookie("Procedencia", this.TxtProcedencia.Text.ToString());
                            HttpCookie NaturalezaCookie = new HttpCookie("Naturaleza", this.TxtNaturaleza.Text.ToString());
                            HttpCookie MedioCookie = new HttpCookie("Medio", this.TxtMedioRecibo.Text.ToString());
                            HttpCookie ExpedienteCookie = new HttpCookie("Expediente", this.TxtExpediente.Text.ToString());
                            HttpCookie AccionCookie = new HttpCookie("Accion", this.TxtAccion.Text.ToString());

                            // Si queremos le asignamos un fecha de expiración: mañana
                            //string mañana = Convert.ToString(DateTime.Today.AddDays(1));
                            FechaVenCookie.Expires = DateTime.Today.AddDays(7).AddSeconds(-1);
                            FechaProCookie.Expires = DateTime.Today.AddDays(7).AddSeconds(-1);
                            ProcedenciaCookie.Expires = DateTime.Today.AddDays(7).AddSeconds(-1);
                            NaturalezaCookie.Expires = DateTime.Today.AddDays(7).AddSeconds(-1);
                            MedioCookie.Expires = DateTime.Today.AddDays(7).AddSeconds(-1);
                            ExpedienteCookie.Expires = DateTime.Today.AddDays(7).AddSeconds(-1);
                            AccionCookie.Expires = DateTime.Today.AddDays(7).AddSeconds(-1);

                            // Y finalmente ñadimos la cookie a nuestro usuario
                            Response.Cookies.Add(FechaVenCookie);
                            Response.Cookies.Add(FechaProCookie);
                            Response.Cookies.Add(ProcedenciaCookie);
                            Response.Cookies.Add(NaturalezaCookie);
                            Response.Cookies.Add(MedioCookie);
                            Response.Cookies.Add(ExpedienteCookie);
                            Response.Cookies.Add(AccionCookie);
                        }
                                         
            }
        else
            {
                
            }
        //if (LblCargarA.Visible == true)
        //{
            this.DateFechaRad.Text = Mayuscula + minuscula;
        //}
        //else
        //{

        //}
        }
        catch (Exception Error)
        {
            //Manejo de exepciones presentadas en pantalla
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }           
    protected void ImgBtnFindRad_Click(object sender, ImageClickEventArgs e)
    {
        Session["HFRadicado"] = "";
        this.ExceptionDetails.Text = "";
        this.LbRadicado.Text = "";
        this.Label7.Visible = false;

        ////////////////////////////////////////////////
        MembershipUser user = Membership.GetUser();
        Object CodigoRuta = user.ProviderUserKey;
        String UserId = Convert.ToString(CodigoRuta);
        ////////////////////////////////////////////////

        String NroRad = "";
        string Grupo = "";
        try
        {
            //parametros de Busqueda Radicado
            Grupo = this.DropDownListGrupo.SelectedValue;
            
            NroRad = TxtBuscarRadicado.Text;
            this.Label10.Visible = true;
            this.Label11.Visible = true;
            if (NroRad != null)
            {
                if (NroRad.Contains(" | "))
                {
                    NroRad = NroRad.Remove(NroRad.IndexOf(" | "));
                }
            }

            string codigodelgruporadicados = this.DropDownListGrupo.SelectedValue;
            //Busqueda de Documento Radicado
            DataTable tabla = new DataTable();
            tabla = ejecutar.rtn_traer_radicados_por_grupo_por_id(Grupo, NroRad);
            DataRow[] rows = tabla.Select();

            this.DateFechaRad.Text = rows[0]["wfmovimientofecha"].ToString().Trim();
            this.HFDate.Value = DateFechaRad.Text;
            this.SelDateFechaProcedencia.Text = rows[0]["radicadofechaprocedencia"].ToString().Trim().Substring(0, 10);
            this.SelDateFechaVencimiento.Text = rows[0]["radicadofechavencimiento"].ToString().Trim().Substring(0, 10);
            this.TxtNumeroExterno.Text = rows[0]["radicadonumeroexterno"].ToString().Trim();
            this.TxtProcedencia.Text = rows[0]["procedenciacodigo"].ToString().Trim() + " | " + rows[0]["procedencianombre"].ToString().Trim() + " | " + rows[0]["ciudadnombre"].ToString().Trim();
            this.TxtDetalle.Text = rows[0]["radicadodetalle"].ToString();
            this.TxtNaturaleza.Text = rows[0]["naturalezacodigo"].ToString() + " | " + rows[0]["naturalezanombre"].ToString().Trim();
            this.TxtMedioRecibo.Text = rows[0]["mediocodigo"].ToString() + " | " + rows[0]["medionombre"].ToString().Trim();
            this.TxtExpediente.Text = rows[0]["expedientecodigo"].ToString() + " | " + rows[0]["expedientenombre"].ToString().Trim();
            this.TxtAnexo.Text = rows[0]["radicadoanexo"].ToString();
            this.TxtNumeroGuia.Text = rows[0]["radicadoguia"].ToString();
            this.Label11.Text = rows[0]["NombreUsuario"].ToString();
            this.Label7.Visible = true;
            //Configuracion de funciones de pantalla para busqueda.
            this.cmdActualizar.Enabled = true;
            this.cmdAceptar.Enabled = false;
               
            this.TxtSerieD.Visible = false;
            this.TxtAccion.Visible = false;
            this.ImgFindCargar.Visible = false;
            this.ImgTreeAccion.Visible = false;
               
            this.LblCargarA.Visible = false;
            this.LblAccion.Visible = false;
             
            this.ImageButton10.Visible = false;
            this.LbRadicado.Text =  NroRad;
            //this.ExceptionDetails.Text = "Radicado Nro" + " " + NroRad;
            
            this.NavDocRecibido1.HFGrupoPadreCodigoValor("1");
            this.NavDocRecibido1.HFGrupoCodigoValor(Grupo);
            this.NavDocRecibido1.HFRadicadoCodigoValor(NroRad);

            string DateMin = SelDateFechaProcedencia.Text;
            DateMin = DateMin.Substring(0, 10);
              
            this.RangeVFecVen.MinimumValue = DateMin;
            this.RequiredFieldValidator4.Enabled = false;
            this.RequiredFieldValidator5.Enabled = false;
                        
           }
           catch (Exception Error)
           {
               this.Label11.Visible = false;
               this.Label10.Visible = false;
               this.ExceptionDetails.Text = "Ocurrio un problema al Buscar el Radicado. ";
               //Exception inner = Error.InnerException;
               this.ExceptionDetails.Text += ErrorHandled.FindError(Error);
    
           }
               
         }
    //se puede hacer a nivel de script
    protected void ImgBtnAdd_Click(object sender, EventArgs e)
    {
        this.ListBoxEnterar.Items.Add(this.TxtDependencia1.Text.ToString());
        this.TxtDependencia1.Text = "";
    }
    //se puede hacer a nivel de script
    protected void ImgBtnDelete_Click(object sender, EventArgs e)
    {
        this.ListBoxEnterar.Items.Remove(this.ListBoxEnterar.SelectedItem); 
    }  
    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolDep = new ArbolesBLL();
        DSDependenciaSQL.DependenciaByTextDataTable DTDependencia = new DSDependenciaSQL.DependenciaByTextDataTable();
        DTDependencia = ObjArbolDep.GetDependenciaTree(e.Node.Value);
        PopulateNodes(DTDependencia, e.Node.ChildNodes, "DependenciaCodigo", "DependenciaNombre");
    } 
    protected void TreeVSerie_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolSer = new ArbolesBLL();
        DSSerieSQL.SerieByTextDataTable DTSerie = new DSSerieSQL.SerieByTextDataTable();
        DTSerie = ObjArbolSer.GetSerieTree(e.Node.Value);
        PopulateNodes(DTSerie, e.Node.ChildNodes, "SerieCodigo", "SerieNombre");
    }    
    protected void TreeVProceso_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ProcesoTableAdapters.WFProcesoTableAdapter TAPRO = new ProcesoTableAdapters.WFProcesoTableAdapter();
        Proceso.WFProcesoDataTable DTProceso = new Proceso.WFProcesoDataTable();
        DTProceso = TAPRO.GetProcesoTreeVDataBy(e.Node.Value);
        PopulateNodes(DTProceso, e.Node.ChildNodes, "WFProcesoCodigo", "WFProcesoDescripcion");
    }
    protected void TreeVAccion_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter TADSWFA = new DSAccionTableAdapters.WFAccion_SelectByTextTableAdapter();
        DSAccion.WFAccion_SelectByTextDataTable DTWFAccion = new DSAccion.WFAccion_SelectByTextDataTable();
        DTWFAccion = TADSWFA.GetWFAccionTreeDataBy(e.Node.Value);
        PopulateNodes(DTWFAccion, e.Node.ChildNodes, "WFAccionCodigo", "WFAccionNombre");
    }
    protected void TreeVExpediente_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        ArbolesBLL ObjArbolExp = new ArbolesBLL();
        DSExpedienteSQL.ExpedienteByTextDataTable DTExpediente = new DSExpedienteSQL.ExpedienteByTextDataTable();
        DTExpediente = ObjArbolExp.GetExpedienteTree(e.Node.Value);
        PopulateNodes(DTExpediente, e.Node.ChildNodes, "ExpedienteCodigo", "ExpedienteNombre");
    }
    //se puede hacer a nivel de script
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
    //se puede hacer a nivel de script
    protected void RadBtnLstFindby_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadBtnLstFindby.SelectedValue == "1")
            {
                this.AutoCompleteExtender2.ServiceMethod = "GetProcedenciaByTextNombre";
                this.TxtProcedencia.Text = "";        
            }
        else if (RadBtnLstFindby.SelectedValue == "2")
           {
               this.AutoCompleteExtender2.ServiceMethod = "GetProcedenciaByTextId";
               this.TxtProcedencia.Text = "";  
           }
    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(  0 );";
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
        }
    }
    private void PopulateNodesNaturaleza(DataTable dt, TreeNodeCollection nodes, String Codigo, String Nombre)
    {
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            tn.Text = dr[Codigo].ToString() + " | " + dr[Nombre].ToString() + " | " + dr["NaturalezaDiasVence"].ToString();
            tn.Value = dr[Codigo].ToString();
            tn.NavigateUrl = "javascript:void(  0 );";
            nodes.Add(tn);

            //If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
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
        PopulateNodesNaturaleza(DTNaturaleza, e.Node.ChildNodes, "NaturalezaCodigo", "NaturalezaNombre");
    }
    protected void ImgBtnFindProcedencia_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.SetFocus(TxtProcedencia);
        this.TxtProcedencia.Text = "";
    }
    protected void ButtonOk_Click(object sender, EventArgs e)
    {
       Radicar();
    }   
    protected void Radicar()
    {
        try
        {
        string RadicadoCodigo = "1";
        RadicadoBLL Obj = new RadicadoBLL();
        GrpDocRad = this.DropDownListGrupo.SelectedValue;
        //DateTime fechavencimiento = Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " +DateTime.Now.ToShortTimeString());

        if (this.HFCargar.Value == "Dependencia" || this.HFCargar.Value == "")
        {
            RadicadoCodigo = Obj.AddRadicado(GrpDocRad, DateTime.Now, Convert.ToDateTime(SelDateFechaProcedencia.Text.ToString()), TxtProcedencia.Text.ToString(), null, TxtNumeroExterno.Text.ToString(), TxtNaturaleza.Text.ToString().Trim(), Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), TxtDetalle.Text.ToString(), TxtAnexo.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), this.TxtSerieD.Text.ToString(), TxtAccion.Text.ToString(), "1", "0", Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), 1, TxtDetalle.Text.ToString(), null, "0", TxtNumeroGuia.Text);
            if (RBEnterarA.SelectedValue == "T")
            {
                String Correcto = Obj.CopiaTodosRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), this.ListBoxEnterar.Items[0].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), 2, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, DateTime.Now, "0");
            }
            else
            {
                for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
                {
                    string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), this.ListBoxEnterar.Items[i].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), 2, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, DateTime.Now, "0");
                }
            }
        }
        else if (this.HFCargar.Value == "Serie")
        {
            RadicadoCodigo = Obj.AddRadicado(GrpDocRad, DateTime.Now, Convert.ToDateTime(SelDateFechaProcedencia.Text.ToString()), TxtProcedencia.Text.ToString(),null, TxtNumeroExterno.Text.ToString(), TxtNaturaleza.Text.ToString().Trim(), Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), TxtDetalle.Text.ToString(), TxtAnexo.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), TxtAccion.Text.ToString(), "0", "1", Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), 3, TxtDetalle.Text.ToString(), this.TxtSerieD.Text.ToString(), "0", TxtNumeroGuia.Text);
            if (RBEnterarA.SelectedValue == "T")
            {
                String Correcto = Obj.CopiaTodosRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), this.ListBoxEnterar.Items[0].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + DateTime.Now.ToShortTimeString()), 2, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, DateTime.Now, "0");
            }
            else
            {
                for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
                {
                    string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), this.ListBoxEnterar.Items[i].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), 2, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, DateTime.Now, "0");
                }
            }
        }
        else if (this.HFCargar.Value == "Proceso")
        {
            if (this.TxtSerieD.Text != null)
            {
                if (TxtSerieD.Text.Contains(" | "))
                {
                    TxtSerieD.Text = TxtSerieD.Text.Remove(TxtSerieD.Text.IndexOf(" | "));
                }
            }
            if (this.TxtProcedencia.Text != null)
            {
                if (TxtProcedencia.Text.Contains(" | "))
                {
                    TxtProcedencia.Text = TxtProcedencia.Text.Remove(TxtProcedencia.Text.IndexOf(" | "));
                }
            }
            if (this.TxtNaturaleza.Text != null)
            {
                if (TxtNaturaleza.Text.Contains(" | "))
                {
                    TxtNaturaleza.Text = TxtNaturaleza.Text.Remove(TxtNaturaleza.Text.IndexOf(" | "));
                }
            }
            if (this.TxtExpediente.Text != null)
            {
                if (TxtExpediente.Text.Contains(" | "))
                {
                    TxtExpediente.Text = TxtExpediente.Text.Remove(TxtExpediente.Text.IndexOf(" | "));
                }
            }
            if (this.TxtMedioRecibo.Text != null)
            {
                if (TxtMedioRecibo.Text.Contains(" | "))
                {
                    TxtMedioRecibo.Text = TxtMedioRecibo.Text.Remove(TxtMedioRecibo.Text.IndexOf(" | "));
                }
            }
            ////////////////////////////////////////////////
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserId = Convert.ToString(CodigoRuta);
            ////////////////////////////////////////////////
            
            int? Result = 1;
            DSRadicadoTableAdapters.Radicado_CreateRadicadoProcesosTableAdapter OBJTAProcesos = new Radicado_CreateRadicadoProcesosTableAdapter();
            OBJTAProcesos.CreateRadicadoProcesos(GrpDocRad, DateTime.Now, Convert.ToDateTime(SelDateFechaProcedencia.Text.ToString()), TxtProcedencia.Text.ToString(), this.TxtSerieD.Text, TxtNumeroExterno.Text.ToString(), TxtNaturaleza.Text.ToString().Trim(), Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), TxtDetalle.Text.ToString(), TxtAnexo.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), "1", "0", Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), 4, null, ref Result, "0",UserId);
            RadicadoCodigo = Convert.ToString(Result);

            if (RBEnterarA.SelectedValue == "T")
            {
                String Correcto = Obj.CopiaTodosRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), this.ListBoxEnterar.Items[0].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), 2, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, DateTime.Now, "0");
            }
            else
            {
                for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
                {
                    string Correcto = Obj.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), this.ListBoxEnterar.Items[i].Value, this.TxtAccion.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), 2, TxtDetalle.Text.ToString(), null, RadicadoCodigo, GrpDocRad, DateTime.Now, "0");
                }
            }
        }
        //Modificar Cookies
        HttpCookie FechaVenCookie = Request.Cookies.Get("FechaVen");
        //FechaVenCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
        FechaVenCookie.Value = this.SelDateFechaVencimiento.Text.ToString();
        Response.Cookies.Set(FechaVenCookie);

        HttpCookie FechaProCookie = Request.Cookies.Get("FechaPro");
        //FechaProCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
        FechaProCookie.Value = this.SelDateFechaProcedencia.Text.ToString();
        Response.Cookies.Set(FechaProCookie);

        HttpCookie ProcedenciaCookie = Request.Cookies.Get("Procedencia");
        //ProcedenciaCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
        ProcedenciaCookie.Value = this.TxtProcedencia.Text.ToString();
        Response.Cookies.Set(ProcedenciaCookie);

        HttpCookie NaturalezaCookie = Request.Cookies.Get("Naturaleza");
        //NaturalezaCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
        NaturalezaCookie.Value = this.TxtNaturaleza.Text.ToString();
        Response.Cookies.Set(NaturalezaCookie);

        HttpCookie MedioCookie = Request.Cookies.Get("Medio");
        // MedioCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
        MedioCookie.Value = this.TxtMedioRecibo.Text.ToString();
        Response.Cookies.Set(MedioCookie);

        HttpCookie ExpedienteCookie = Request.Cookies.Get("Expediente");
        //ExpedienteCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
        ExpedienteCookie.Value = this.TxtExpediente.Text.ToString();
        Response.Cookies.Set(ExpedienteCookie);

        HttpCookie AccionCookie = Request.Cookies.Get("Accion");
        //AccionCookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);
        AccionCookie.Value = this.TxtAccion.Text.ToString();
        Response.Cookies.Set(AccionCookie);

        //mostrar Documento creado
        this.Label7.Visible = true;
        this.LbRadicado.Text = RadicadoCodigo;
        this.Label10.Visible = false;
        this.Label11.Visible = false;
        //this.ExceptionDetails.Text = "Radicado Nro" + " " + RadicadoCodigo;

        Session["HFRadicado"] = RadicadoCodigo;
                      
        this.NavDocRecibido1.HFGrupoCodigoValor(GrpDocRad);
        this.NavDocRecibido1.HFGrupoPadreCodigoValor("1");
        this.NavDocRecibido1.HFRadicadoCodigoValor(RadicadoCodigo);

        this.LblMessageBox.Text = "Radicado Nro" + " " + RadicadoCodigo;
        this.ModalPopupExtender1.Show();
        this.TxtAnexo.Text = "";
        this.ListBoxEnterar.Items.Clear();
        


        if (this.HFCargar.Value == "Dependencia" || this.HFCargar.Value == "")
        {
            MailBLL Correo = new MailBLL();
            MembershipUser usuario;
            DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter ObjTaUsuarioxDependencia = new DSUsuarioTableAdapters.UsuariosxdependenciaTableAdapter();
            DSUsuario.UsuariosxdependenciaDataTable DTUsuariosxDependencia = new DSUsuario.UsuariosxdependenciaDataTable();

            DTUsuariosxDependencia = ObjTaUsuarioxDependencia.GetUsuariosxDependenciaByDependencia(this.TxtSerieD.Text.Remove(TxtSerieD.Text.IndexOf(" | ")).ToString().Trim());
            if (DTUsuariosxDependencia.Count > 0)
            {
                DataRow[] rows = DTUsuariosxDependencia.Select();
                System.Guid a = new Guid(rows[0].ItemArray[0].ToString().Trim());
                usuario = Membership.GetUser(a);
                string Body = "Tiene un nuevo Radicado Nro " + RadicadoCodigo + "<BR>" + " Fecha de Radicacion: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "<BR>" + "Procedencia: " + TxtProcedencia.Text.ToString() + "<BR>" + "Naturaleza: " + TxtNaturaleza.Text.ToString().Trim() + "<BR>";
                Correo.EnvioCorreo("alfanet@mutualser.org", usuario.Email, "Radicado Nro" + " " + RadicadoCodigo, Body, true, "1");
            }
        }

        this.TxtSerieD.Text = "";
            }
            catch (Exception Error)
            {
                // if (Error.InnerException != null)
                // {
                //Display a user-friendly message
                this.ExceptionDetails.Text = "Ocurrio un problema al tratar de Radicar. ";
                //Exception inner = Error.InnerException;
                this.ExceptionDetails.Text += ErrorHandled.FindError(Error) + Error.Message.ToString();
                //}     
            }
    }
    //se puede hacer a nivel de script
    protected void TxtNaturaleza_TextChanged(object sender, EventArgs e)
    {
         if (TxtNaturaleza.Text.Contains(" | "))
         {
            String[] Extension = TxtNaturaleza.Text.Split('|');
            String DiasVence = Extension[Extension.Length - 1];           
                
                Double DiasVenceFloat = Convert.ToDouble(DiasVence);
                if (DiasVence != " 0")
                {
                    DateTime FVencimiento = DateTime.Today.AddDays(DiasVenceFloat);
                    this.SelDateFechaVencimiento.Text = Convert.ToString(FVencimiento.Date.Day + "/" + FVencimiento.Date.Month + "/" + FVencimiento.Date.Year);
                }            
         }
    }
    protected void cmdAceptarImg_Click(object sender, ImageClickEventArgs e)
    {
        this.ExceptionDetails.Text = "";
        try
        {
            RadicadoTableAdapter TARadicado = new RadicadoTableAdapter();
            DSRadicado.RadicadoDataTable DTRadicadoExiste = new DSRadicado.RadicadoDataTable();
            String ProCod = this.TxtProcedencia.Text;
            if (ProCod != "" && ProCod != null)
            {
                if (ProCod.Contains(" | "))
                {
                    ProCod = ProCod.Remove(ProCod.IndexOf(" | "));
                }
            }
            else
            {
                ProCod = null;
            }
            DTRadicadoExiste = TARadicado.GetRadicadoExistente(Convert.ToDateTime(this.SelDateFechaProcedencia.Text.ToString()), ProCod, this.TxtNumeroExterno.Text.ToString());
            //String prueba = null;
            if (DTRadicadoExiste.Count != 0)
            {
                MPE2.Show();
            }
            else
            {
                Radicar();
            }


        }
        catch (Exception Error)
        {
            this.Label11.Visible = false;
            this.Label7.Visible = false;
            // if (Error.InnerException != null)
            // {
            //Display a user-friendly message
            this.ExceptionDetails.Text = "Ocurrio un problema al tratar de Radicar. ";
            //Exception inner = Error.InnerException;
            this.ExceptionDetails.Text += ErrorHandled.FindError(Error);
            //}     
        }
    }
    protected void BtnNuevoRad_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["HFRadicado"] = "";
            this.TxtNumeroExterno.Text = null;
            this.SelDateFechaVencimiento.Text = null;
            this.SelDateFechaProcedencia.Text = null;
            this.TxtProcedencia.Text = null;
            this.TxtDetalle.Text = null;
            this.TxtNaturaleza.Text = null;
            this.TxtMedioRecibo.Text = null;
            this.TxtExpediente.Text = null;
            this.TxtSerieD.Text = null;
            this.TxtAccion.Text = null;
            this.TxtAnexo.Text = null;
            this.TxtBuscarRadicado.Text = null;
            this.TxtDependencia1.Text = null;
            this.ExceptionDetails.Text = null;
            this.TxtNumeroGuia.Text = null;
            this.ListBoxEnterar.Items.Clear();
            this.LbRadicado.Text = "";

            this.cmdActualizar.Enabled = false;
            this.cmdAceptar.Enabled = true;

            this.TxtSerieD.Visible = true;
            this.TxtAccion.Visible = true;
            this.ImgFindCargar.Visible = true;
            this.ImgTreeAccion.Visible = true;

            this.LblCargarA.Visible = true;
            this.LblAccion.Visible = true;

            this.ImageButton10.Visible = true;
            this.NavDocRecibido1.HFRadicadoCodigoValor("");
            this.Label7.Visible = false;

        }
        catch (SqlException err)
        {
            this.Label11.Visible = false;
            this.LblAccion.Text = "Error: " + err.Message.ToString();
        }
    }
    protected void cmdActualizar_Click(object sender, ImageClickEventArgs e)
    {
        Session["HFRadicado"] = "";
        this.ExceptionDetails.Text = "";
        this.LbRadicado.Text = "";
        this.Label11.Visible = false;
        try
        {
            //Parametros Actualizardatos Radicado
            GrpDocRad = this.DropDownListGrupo.SelectedValue;

            String NroRad;
            NroRad = TxtBuscarRadicado.Text;
            if (NroRad != null)
            {
                if (NroRad.Contains(" | "))
                {
                    NroRad = NroRad.Remove(NroRad.IndexOf(" | "));
                }
            }
            //Actulizar radicado
            RadicadoBLL ObjUpdate = new RadicadoBLL();
            ObjUpdate.UpdateRadicado(TxtBuscarRadicado.Text.ToString(), GrpDocRad, Convert.ToDateTime(DateFechaRad.Text.ToString()), Convert.ToDateTime(SelDateFechaProcedencia.Text.ToString()), TxtProcedencia.Text.ToString(), TxtNumeroExterno.Text.ToString(), TxtNaturaleza.Text.ToString().Trim(), "1", TxtDetalle.Text.ToString(), TxtAnexo.Text.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString()), TxtExpediente.Text.ToString(), TxtMedioRecibo.Text.ToString(), "1", TxtBuscarRadicado.Text.ToString(), GrpDocRad, TxtNumeroGuia.Text);
            if (RBEnterarA.SelectedValue == "T")
            {
                String Correcto = ObjUpdate.CopiaTodosRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), this.ListBoxEnterar.Items[0].Value, "2", Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), 2, TxtDetalle.Text.ToString(), null, NroRad, GrpDocRad, DateTime.Now, "0");
            }
            else
            {
                for (int i = 0; i < ListBoxEnterar.Items.Count; i++)
                {
                    string Correcto = ObjUpdate.CopiaRadicado(Profile.GetProfile(User.Identity.Name.ToString()).CodigoDepUsuario.ToString(), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), this.ListBoxEnterar.Items[i].Value, "2", Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), Convert.ToDateTime(SelDateFechaVencimiento.Text.ToString() + " " + DateTime.Now.ToShortTimeString()), 2, TxtDetalle.Text.ToString(), null, NroRad, GrpDocRad, DateTime.Now, "0");
                }
            }
            //Configuracion despues de actulizar radicado           
            this.NavDocRecibido1.HFGrupoCodigoValor(GrpDocRad);
            this.NavDocRecibido1.HFGrupoPadreCodigoValor("1");
            this.NavDocRecibido1.HFRadicadoCodigoValor(NroRad);

            this.DateFechaRad.Text = HFDate.Value;
            this.LblMessageBox.Text = "Radicado Actualizado Nro" + " " + NroRad;
            this.ModalPopupExtender1.Show();
        }
        catch (Exception Error)
        {
            this.Label11.Visible = false;
            if (Error.InnerException != null)
            {
               
                //Display a user-friendly message
                this.ExceptionDetails.Text = "Ocurrio un problema al tratar de adicionar el registro. ";
                //Exception inner = Error.InnerException;
                this.ExceptionDetails.Text += ErrorHandled.FindError(Error);
                this.LbRadicado.Text = "";
            }
        }
    }
    protected void cmdCancel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("~/AlfaNetWorkFlow/AlfaNetWF/WorkFlow.aspx");
        }
        catch (Exception Error)
        {
            this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
    //se puede hacer a nivel de script
    protected void DropDownListGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {  
       Application["grupo"] = this.DropDownListGrupo.SelectedValue.ToString();
       this.TxtBuscarRadicado.Text = null;
    }
}