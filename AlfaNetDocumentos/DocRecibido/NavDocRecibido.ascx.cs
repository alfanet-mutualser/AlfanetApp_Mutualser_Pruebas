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

public partial class AlfaNetDocumentos_NavDocRecibido : System.Web.UI.UserControl
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
        // atrributos Navegacion de Documentos javascript
        if (HFRadicadoCodigo.Value == null)
        {
            HFRadicadoCodigo.Value = "";            
            
        }       
        
    }
    public void HFRadicadoCodigoValor(String Texto)
    {
        HFRadicadoCodigo.Value = Texto.ToString();
        if (HFRadicadoCodigo.Value == "")
        {
            this.Image1.Attributes.Remove("onClick");
            this.Image3.Attributes.Remove("onClick");
            //this.Image2.Attributes.Remove("onClick");
        }
        else
        {
            this.Image1.Attributes.Add("onClick", "VImagenes(event," + HFRadicadoCodigo.Value + "," + HFGrupoCodigo.Value + ");");            
            this.Image3.Attributes.Add("onClick", "ImpresionSticker(event," + HFRadicadoCodigo.Value + ");");
            this.CheckBox1.Attributes.Add("onClick", "url(" + CheckBox1.ClientID + "," + HFGrupoCodigo.Value + ");");
            //this.Image2.Attributes.Add("onClick", "RegresarRadicado(event," + HFRadicadoCodigo.Value + ");");
            if (Session["HFRadicado"] != "")
            {
                if (Session["HFRadicado"] != "-1")
                {
                    Image2.Visible = true;
                    LbScanner.Visible = true;
                }
                
            }

            
        }
        
    }
    public void HFGrupoCodigoValor(String Texto)
    {
        HFGrupoCodigo.Value = Texto.ToString();
        //this.Image1.Attributes.Add("onClick", "VImagenes(event," + HFRadicadoCodigo.Value + ");");
    }
    public void HFGrupoPadreCodigoValor(String Texto)
    {
        HFGrupoPadreCodigo.Value = Texto.ToString();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/AlfaNetDocumentos/DocRecibido/DocRecibidoWF.aspx?TipoCodigo=1&RadicadoCodigo=1" + ((LinkButton)sender).Text + "&GrupoCodigo=1&ControlDias=1000");
        if (HFRadicadoCodigo.Value == "")
        {
            Response.Redirect("~/AlfaNetDocumentos/DocRecibido/NuevoDocRecibido1.aspx");
        }
        else
        {
            Response.Redirect("~/AlfaNetDocumentos/DocRecibido/NuevoDocRecibido1.aspx?RadicadoCodigo=" + HFRadicadoCodigo.Value);

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
            Response.Redirect("~/AlfaNetDocumentos/DocRecibido/Sticker.aspx?RadicadoCodigo=" + HFRadicadoCodigo.Value + "&GrupoCodigo=" + HFGrupoCodigo.Value);

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
            Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + HFRadicadoCodigo.Value + "&GrupoCodigo=" + HFGrupoCodigo.Value + "&ImagenFolio=1");

        }
    }
   
}
