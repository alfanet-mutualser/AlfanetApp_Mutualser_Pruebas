using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class AlfaNetDocumentos_NavDocEnviado : System.Web.UI.UserControl
{
    protected override void OnLoad(EventArgs e)
    {

        // do something here

        base.OnLoad(e);
        CheckBox1.Checked = false;

        // or should I do something here?

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HFRegistroCodigo.Value == null)
        {
            HFRegistroCodigo.Value = "";
            //this.Image1.Attributes.Add("onClick", "VImagenes(event," + HFRadicadoCodigo.Value + ");");
        }   
    }
    public void HFRegistroCodigoValor(String Texto)
    {
        HFRegistroCodigo.Value = Texto.ToString();
        if (HFRegistroCodigo.Value == "")
        {
            this.Image1.Attributes.Remove("onClick");
            this.Image3.Attributes.Remove("onClick");
            //this.Image2.Attributes.Remove("onClick");
        }
        else
        {
            this.Image1.Attributes.Add("onClick", "VImagenes(event," + HFRegistroCodigo.Value + "," + HFGrupoCodigo.Value + ");");
            this.Image3.Attributes.Add("onClick", "ImpresionSticker(event," + HFRegistroCodigo.Value + ");");
            this.CheckBox1.Attributes.Add("onClick", "url(" + CheckBox1.ClientID + "," + HFGrupoCodigo.Value + ");");

            
            
            //this.Image2.Attributes.Add("onClick", "RegresarRadicado(event," + HFRadicadoCodigo.Value + ");");
        }
        this.HFRegistroCodigo.Value = Texto.ToString();

        if (Session["CodRegistro"] != "")
        {
            
            Image2.Visible = true;
            LbScanner.Visible = true;

        }
        
    

    }
    public void HFGrupoCodigoValor(String Texto)
    {
        HFGrupoCodigo.Value = Texto.ToString();
    }
    public void HFGrupoPadreCodigoValor(String Texto)
    {
        HFGrupoPadreCodigo.Value = Texto.ToString();

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/AlfaNetDocumentos/DocRecibido/DocRecibidoWF.aspx?TipoCodigo=1&RadicadoCodigo=1" + ((LinkButton)sender).Text + "&GrupoCodigo=1&ControlDias=1000");
        if (HFRegistroCodigo.Value == "")
        {
            Response.Redirect("~/AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx");
        }
        else
        {
            Response.Redirect("~/AlfaNetDocumentos/DocEnviado/NuevoDocEnviadoInt.aspx?RegistroCodigo=" + HFRegistroCodigo.Value);

        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (HFGrupoCodigo.Value == "")
        {
            Response.Redirect("~/AlfaNetDocumentos/DocRecibido/Sticker.aspx");
        }
        else
        {
            Response.Redirect("~/AlfaNetDocumentos/DocRecibido/Sticker.aspx?RadicadoCodigo=" + HFRegistroCodigo.Value + "&GrupoCodigo=" + HFGrupoCodigo.Value);

        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (HFGrupoCodigo.Value == "")
        {
            Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx");
        }
        else
        {
            Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + HFRegistroCodigo.Value + "&GrupoCodigo=" + HFGrupoCodigo.Value + "&ImagenFolio=1");

        }
        //if (HFGrupoCodigo.Value == "")
        //{
        //    Response.Redirect("~/AlfaNetDocumentos/DocRecibido/Sticker.aspx");
        //}
        //else
        //{
        //    Response.Redirect("~/AlfaNetDocumentos/DocRecibido/Sticker.aspx?RadicadoCodigo=" + HFRegistroCodigo.Value + "&GrupoCodigo=" + HFGrupoCodigo.Value);

        //}
    }
   
}
