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

public partial class AlfaNetImagen_VisorImagenes_ImagenUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DSImagenTableAdapters.ImagenRutaTableAdapter TAImagenRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
            DSImagen.ImagenRutaDataTable DTImagenRuta = TAImagenRuta.GetImagenRutaById(1);
            this.LblRuta.Text = DTImagenRuta[0].ImagenRutaPath.ToString();
            this.HFPath.Value = DTImagenRuta[0].ImagenRutaPath.ToString();
            this.HFNroDoc.Value = "9999";
        }
    }
  
    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            //Dim strFileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)

            if (this.FileUpload1.HasFile)
            {
               //Radicado
               if (Convert.ToInt32(this.HFTipoDoc.Value) == 1)
               {
                  this.FileUpload1.SaveAs(this.HFPath.Value.ToString() + this.FileUpload1.FileName);

            //    DSImagenTableAdapters.Radicado_MaxImagenFolioTableAdapter TARadicado_MaxImagenFolio = new DSImagenTableAdapters.Radicado_MaxImagenFolioTableAdapter();
            //    DSImagen.Radicado_MaxImagenFolioDataTable DTRadicadoMaxImagenFolio = TARadicado_MaxImagenFolio.GetMaxImagenFolio(Convert.ToInt32(this.HFNroDoc.Value));

                  DSImagenTableAdapters.Radicado_SelectImagenMaxFolioByIdTableAdapter TAPRUEBA = new DSImagenTableAdapters.Radicado_SelectImagenMaxFolioByIdTableAdapter();
                  DSImagen.Radicado_SelectImagenMaxFolioByIdDataTable DTPRUEBA = TAPRUEBA.GetMaxFolioById(Convert.ToInt32(this.TextBox1.Text));

                  this.ExceptionDetails.Visible = true;
                  this.ExceptionDetails.Text = DTPRUEBA.Count.ToString();

                   //    //    //int mvalor = Convert.ToInt32());
            //    //    if (Convert.DBNull(TAPRUEBA.GetMaxFolioById(Convert.ToInt32(this.HFNroDoc.Value))

            //    //    //if (Convert.IsDBNull(DTRadicadoMaxImagenFolio[0].MaxRadicadoImagenFolio))
            //    //    //{
            //    //        //int mvar = 1;
            //    //    //}

            //    //    //DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
            //    //    //TARadicadoImagen.Insert(Convert.ToInt32(this.HFNroDoc.Value), 1, Convert.ToInt32(DTRadicadoMaxImagenFolio[0].MaxRadicadoImagenFolio));
               }

              //Registro
              if (Convert.ToInt32(this.HFTipoDoc.Value) == 2)
              {
                   
              }
            }
            else
            {
                this.ExceptionDetails.Visible = true;
                this.ExceptionDetails.Text = "No ha especificado un archivo";
            }
            
        }
        catch (Exception ex)
        {
            this.ExceptionDetails.Visible = true;
            this.ExceptionDetails.Text = "Error: " + ex.Message.ToString();
        }
    }
}
