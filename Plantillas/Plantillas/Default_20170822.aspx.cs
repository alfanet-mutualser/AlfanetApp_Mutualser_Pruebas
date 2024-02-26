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

//namespace Plantillas
//{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDLPlantilla.Items.Clear();
                DDLPlantilla.Items.Add(new ListItem("Seleccione", "-1"));
                DDLPlantilla.DataValueField = "Codigo";
                DDLPlantilla.DataTextField = "Descripcion";
                cargarPlantillas();
                if (Session["textoPlantilla"] != null)
                {                    
                    Editor.Text = Session["textoPlantilla"].ToString();
                    Session.Remove("textoPlantilla");
                    //DDLPlantilla.SelectedValue = Session["Plantilla_CodPlantilla"].ToString();
                }
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
