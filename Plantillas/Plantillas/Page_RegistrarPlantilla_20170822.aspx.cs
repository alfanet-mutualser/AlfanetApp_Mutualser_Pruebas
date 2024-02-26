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
//using Entity;

//namespace Plantillas
//{
    public partial class Page_RegistrarPlantilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string radicado = Request.QueryString["RadicadoCodigo"];
            RBLDestino.Visible = false;
            //RBLDestino.Visible = false;
            cargarDatos(radicado);
        }

        private void cargarDatos(string radicado)
        {
            if (Session["OpcPlantilla"].ToString() == "1")
            {
                RBLDestino.Visible = true;
                //RBLDestino.Visible = true;
                TxtDestino.Enabled = true;
                TxtRadicadoFuente.Enabled = true;
                TxtNaturaleza.Enabled = true;
                TxtExpediente.Enabled = true;
                TxtMedio.Enabled = true;
                TxtSerie.Enabled = true;
                //TxtAccion.Enabled = true;
            }
            else
            {
                Business intelligence = new Business();
                DataSet ds = new DataSet();
                ds = intelligence.cargarDatos(radicado);
                TxtDestino.Text = ds.Tables[0].Rows[0]["procedenciacodigo"].ToString().Trim() + " | " + ds.Tables[0].Rows[0]["procedencianombre"].ToString().Trim() + " | " + ds.Tables[0].Rows[0]["ciudadnombre"].ToString().Trim();
                TxtDestino.Enabled = false;
                TxtRadicadoFuente.Text = radicado;
                TxtRadicadoFuente.Enabled = false;
                TxtNaturaleza.Text = ds.Tables[0].Rows[0]["naturalezacodigo"].ToString().Trim() + " | " + ds.Tables[0].Rows[0]["naturalezanombre"].ToString().Trim();
                TxtNaturaleza.Enabled = false;
                TxtExpediente.Text = ds.Tables[0].Rows[0]["expedientecodigo"].ToString().Trim() + " | " + ds.Tables[0].Rows[0]["expedientenombre"].ToString().Trim();
                TxtExpediente.Enabled = false;
                TxtMedio.Text = ds.Tables[0].Rows[0]["mediocodigo"].ToString().Trim() + " | " + ds.Tables[0].Rows[0]["medionombre"].ToString().Trim();
                TxtMedio.Enabled = false;
            }
        }        
        
        protected void RBLDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBLDestino.SelectedValue == "1")
            {
                this.ACEDestino.ServiceMethod = "GetProcedenciaByTextNombre";
                TxtDestino.Text = string.Empty;
                //this.PopCDestino.Enabled = true;
                //this.ImageButton12.Visible = false;
            }
            else if (RBLDestino.SelectedValue == "0")
            {
                this.ACEDestino.ServiceMethod = "GetDependenciaByText";
                TxtDestino.Text = string.Empty;
                //this.PopCDestino.Enabled = false;
                //this.ImageButton12.Visible = true;
            }
        }
        protected void IBAceptar_Click(object sender, ImageClickEventArgs e)
        {
            if (TxtDestino.Text.Equals("") || TxtNaturaleza.Text.Equals("") || TxtExpediente.Text.Equals("") || TxtMedio.Text.Equals("") || TxtSerie.Text.Equals(""))
            {
                //LMessagePlantilla.Text = "Por favor llenar todos los datos requeridos.";
                message();
            }
            else
            {
                //int registro = crearRegistro();
                DatosRegistro datos = new DatosRegistro();
                datos=llenarDatosRegistro();
                Session["datos"] = datos;

                //LMessagePlantilla.Text = "Se Registro el documento con el número: " + registro;
                //crearRadicadoFuente(registro);
                //insertarPlantilla(Request.QueryString["codPlantilla"], Request.QueryString["depUsuario"], Session["texto"].ToString());
                string procedencia = TxtDestino.Text.Remove(TxtDestino.Text.IndexOf(" | "));
                if (RBLDestino.SelectedValue == "1")
                {
                    procedencia += ".1";
                }
                else
                {
                    procedencia += ".2";
                }
                if (TxtRadicadoFuente.Text.Trim() != "")
                {
                    string rad = string.Empty;
                    if (TxtRadicadoFuente.Text.Contains(" | "))
                    {
                        rad = TxtRadicadoFuente.Text.Remove(TxtRadicadoFuente.Text.IndexOf(" | ")).Trim();
                    }
                    else
	                {
                        rad = TxtRadicadoFuente.Text.Trim();
	                }
                    string html = remplazarValores(Session["textoPlantilla"].ToString(), rad);
                    Session["textoPlantilla"] = html;
                }
                else
                {
                    string html = remplazarValores2(Session["textoPlantilla"].ToString());
                    Session["textoPlantilla"] = html;
                }
                //message();
                Response.Redirect("Page_FinalizarPlantilla.aspx?radicado=" + TxtRadicadoFuente.Text.Trim() + "&plantilla=" + Request.QueryString["codPlantilla"] + "&depusuario=" + Request.QueryString["depUsuario"] + "&procedencia=" + procedencia);
            }
        }
        private DatosRegistro llenarDatosRegistro()
        {
            try
            {
                Business  intelligence = new Business ();
				string procedenciaCodDestino;
                string dependenciaCodDestino;
                int radicadoCodigo = 0;
                string grupoCodigo = "2";
                DateTime wFMovimientoFecha = System.DateTime.Now;
				if (RBLDestino.SelectedValue == "1")
                {
                    procedenciaCodDestino = TxtDestino.Text.Remove(TxtDestino.Text.IndexOf(" | "));
                    dependenciaCodDestino = null;
                }
                else
                {
                    procedenciaCodDestino = null;
                    dependenciaCodDestino = TxtDestino.Text.Remove(TxtDestino.Text.IndexOf(" | "));
                }
                //string procedenciaCodDestino = TxtDestino.Text.Remove(TxtDestino.Text.IndexOf(" | "));
                //string dependenciaCodDestino = null;
                string dependenciaCodigo = Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();// Request.QueryString["depUsuario"];// Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();
                string naturalezaCodigo = "";
                string registroDetalle = "Registro Automatico con Plantilla";
                string registroGuia = null;
                string registroEmpGuia = null;
                string anexoExtRegistro = null;
                string logDigitador = Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();// Request.QueryString["depUsuario"];// Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();
                string expedienteCodigo = "";
                string medioCodigo = "";
                string serieCodigo = "";
                string regPesoEnvio = null;
                string regValorEnvio = null;
				string registroTipo; 
                if (RBLDestino.SelectedValue == "1")
                {
                    registroTipo = "0";
                }
                else
                {
                    registroTipo = "1";
                }
                //string registroTipo = "0";
                string wFAccionCodigo = "13";
                DateTime wFMovimientoFechaEst = System.DateTime.Now;
                DateTime wFMovimientoFechaFin = System.DateTime.Now;
                int wFMovimientoTipo = 0;
                string wFMovimientoNotas = null;
                string wFMovimientoMultitarea = "0";
                string userId = "";

                //MembershipUser user = Membership.GetUser();

                if (TxtRadicadoFuente.Text.Contains(" | "))
                {
                    radicadoCodigo = Convert.ToInt32(TxtRadicadoFuente.Text.Remove(TxtRadicadoFuente.Text.IndexOf(" | ")));
                }
                else if (TxtRadicadoFuente.Text.Trim() == "")
                {
                    radicadoCodigo = 0;
                }
                else
                {
                    radicadoCodigo = Convert.ToInt32(TxtRadicadoFuente.Text.Trim());
                }
                if (Request.QueryString["depUsuario"].ToString() == "" || Request.QueryString["depUsuario"].ToString() == null)
                {
                    string username = "TLINEA";
                    string dep = intelligence.ReadUsersByUserName(username);
                    //Object CodigoRuta = user.ProviderUserKey;
                    //userId = Convert.ToString(CodigoRuta);
                }
                else
                {
                    userId = intelligence.obtenerUserId(Request.QueryString["depUsuario"]);
                    //userId = logDigitador;
                }

                if (TxtNaturaleza.Text.Contains(" | "))
                {
                    naturalezaCodigo = TxtNaturaleza.Text.Remove(TxtNaturaleza.Text.IndexOf(" | "));
                }

                if (TxtExpediente.Text.Contains(" | "))
                {
                    expedienteCodigo = TxtExpediente.Text.Remove(TxtExpediente.Text.IndexOf(" | "));
                }

                if (TxtMedio.Text.Contains(" | "))
                {
                    medioCodigo = TxtMedio.Text.Remove(TxtMedio.Text.IndexOf(" | "));
                }

                if (TxtSerie.Text.Contains(" | "))
                {
                    serieCodigo = TxtSerie.Text.Remove(TxtSerie.Text.IndexOf(" | "));
                }             

                if (dependenciaCodigo == "")
                {
                    dependenciaCodigo = "100"; //OJO ESTO DEBE CAMBIAR EN PRODUCCION.
                }

                if (RBLDestino.SelectedValue == "0")
                {
                    if (dependenciaCodDestino == "" || dependenciaCodDestino == null)
                    {
                        dependenciaCodDestino = Request.QueryString["depUsuario"];// Profile.GetProfile(Profile.UserName).CodigoDepUsuario.ToString();

                    }
                    if (Session["Plantilla_Opcion"] != null && Session["Plantilla_Opcion"].ToString() == "1")//no esta aun
                    {
                        procedenciaCodDestino = TxtDestino.Text.Remove(TxtDestino.Text.IndexOf(" | "));
                    }
                    else
                    {
                        procedenciaCodDestino = null;
                        wFMovimientoTipo = 1;
                    }
                }
                else
                {
                    if (TxtDestino.Text.Contains(" | "))
                    {
                        procedenciaCodDestino = TxtDestino.Text.Remove(TxtDestino.Text.IndexOf(" | "));
                    }
                }

                DatosRegistro datosRegistro = new DatosRegistro();
                datosRegistro.grupoCodigo= grupoCodigo;
                datosRegistro.wFMovimientoFecha=wFMovimientoFecha;
                datosRegistro.procedenciaCodDestino=procedenciaCodDestino;
                datosRegistro.dependenciaCodDestino=dependenciaCodDestino;
                datosRegistro.dependenciaCodigo=dependenciaCodigo;
                datosRegistro.naturalezaCodigo=naturalezaCodigo;
                datosRegistro.radicadoCodigo=radicadoCodigo;
                datosRegistro.registroDetalle=registroDetalle;
                datosRegistro.registroGuia=registroGuia;
                datosRegistro.registroEmpGuia=registroEmpGuia;
                datosRegistro.anexoExtRegistro=anexoExtRegistro;
                datosRegistro.logDigitador=logDigitador;
                datosRegistro.expedienteCodigo=expedienteCodigo;
                datosRegistro.medioCodigo=medioCodigo;
                datosRegistro.serieCodigo=serieCodigo;
                datosRegistro.regPesoEnvio=regPesoEnvio;
                datosRegistro.regValorEnvio=regValorEnvio;
                datosRegistro.registroTipo=registroTipo;
                datosRegistro.wFAccionCodigo=wFAccionCodigo;
                datosRegistro.wFMovimientoFechaEst=wFMovimientoFechaEst;
                datosRegistro.wFMovimientoFechaFin=wFMovimientoFechaFin;
                datosRegistro.wFMovimientoTipo=wFMovimientoTipo;
                datosRegistro.wFMovimientoNotas=wFMovimientoNotas;
                datosRegistro.wFMovimientoMultitarea=wFMovimientoMultitarea;
                datosRegistro.userId = userId;
                return datosRegistro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void insertarPlantilla(string codPlantilla, string dependenciaCodigo, string html)
        {
            try
            {
                Business intelligence = new Business();
                intelligence.insertarPlantilla(codPlantilla, dependenciaCodigo, html);
            }
            catch (Exception ex)
            {
                throw ex;
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
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            string radicado = Request.QueryString["RadicadoCodigo"];
            Response.Redirect("Default.aspx?RadicadoCodigo=" + radicado);
        }
        protected void TxtRadicadoFuente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtRadicadoFuente.Text.Trim() != "")
                {
                    cargarDatos2(TxtRadicadoFuente.Text.Remove(TxtRadicadoFuente.Text.IndexOf(" | ")));
                }
                else
                {
                    TxtDestino.Text = string.Empty;
                    TxtDestino.Enabled = true;
                    TxtNaturaleza.Text = string.Empty;
                    TxtNaturaleza.Enabled = true;
                    TxtExpediente.Text = string.Empty;
                    TxtExpediente.Enabled = true;
                    TxtMedio.Text = string.Empty;
                    TxtMedio.Enabled = true;
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }
        private void cargarDatos2(string radicado)
        {
            Business intelligence = new Business();
            DataSet ds = new DataSet();
            ds = intelligence.cargarDatos(radicado);
            TxtDestino.Text = ds.Tables[0].Rows[0]["procedenciacodigo"].ToString().Trim() + " | " + ds.Tables[0].Rows[0]["procedencianombre"].ToString().Trim() + " | " + ds.Tables[0].Rows[0]["ciudadnombre"].ToString().Trim();
            TxtDestino.Enabled = false;
            //TxtRadicadoFuente.Text = radicado;
            //TxtRadicadoFuente.Enabled = false;
            TxtNaturaleza.Text = ds.Tables[0].Rows[0]["naturalezacodigo"].ToString().Trim() + " | " + ds.Tables[0].Rows[0]["naturalezanombre"].ToString().Trim();
            TxtNaturaleza.Enabled = false;
            TxtExpediente.Text = ds.Tables[0].Rows[0]["expedientecodigo"].ToString().Trim() + " | " + ds.Tables[0].Rows[0]["expedientenombre"].ToString().Trim();
            TxtExpediente.Enabled = false;
            TxtMedio.Text = ds.Tables[0].Rows[0]["mediocodigo"].ToString().Trim() + " | " + ds.Tables[0].Rows[0]["medionombre"].ToString().Trim();
            TxtMedio.Enabled = false;
        }
        private string remplazarValores(string codHtml, string radicadoCodigo)
        {
            try
            {
                if (radicadoCodigo != "")
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
                    }
                }                
                return codHtml;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string remplazarValores2(string codHtml)
        {
            try
            {                
                while (codHtml.IndexOf("##") >= 0)
                {
                    Int32 vFrom = codHtml.IndexOf("##");
                    Int32 vTo = codHtml.IndexOf("##", vFrom + 1);
                    string TxtReplace = codHtml.Substring(vFrom + 2, vTo - vFrom - 2);
                    codHtml = codHtml.Replace("##" + TxtReplace + "##", " ");
                    codHtml = codHtml.Replace("##" + TxtReplace + "##", " ");
                    
                }
                
                return codHtml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
}
//}
