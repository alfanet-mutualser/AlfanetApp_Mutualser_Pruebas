using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Neodynamic.WebControls.ImageDraw;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


/// <summary>
/// Descripción breve de GuardarImg
/// </summary>
public class GuardarImg
{
    public GuardarImg()
    {
    }
    public void GuardarImgs(String email, String fullname,String Type, String FileName, String RegistroCodigo,String Grupo)
	{
        try
        {
            //Get the info to create the travel card

            //Create an instance of ImageDraw
            ImageDraw imgDraw = new ImageDraw();
            //Basic settings
            imgDraw.Canvas.AutoSize = true;
            imgDraw.ImageFormat = ImageDrawFormat.Jpeg;
            imgDraw.JpegCompressionLevel = 90;

            //Create an ImageElement to wrap the business card design
            ImageElement imgElemCard = new ImageElement();
            imgElemCard.Source = ImageSource.File;
            imgElemCard.SourceFile = "~/images/card1.jpg";
            //Add element to output image
            imgDraw.Elements.Add(imgElemCard);


            //Create TextElement objects for each fields

            TextElement txtCiudadFecha = new TextElement();
            txtCiudadFecha.AutoSize = true;
            txtCiudadFecha.Font.Name = "CiudadFecha";
            txtCiudadFecha.Font.Size = 10f;
            //txtCiudadFecha.Font.Unit = FontUnit.Point;
            txtCiudadFecha.ForeColor = System.Drawing.Color.Black;
            txtCiudadFecha.Text = DateTime.Today.ToLongDateString();
            txtCiudadFecha.TextQuality = System.Drawing.Text.TextRenderingHint.AntiAlias;
            txtCiudadFecha.X = 100;
            txtCiudadFecha.Y = 230;
            //Add element to output image
            imgDraw.Elements.Add(txtCiudadFecha);

            //Full Name TextElement
            if (fullname.Length > 0)
            {
                TextElement txtElemName = new TextElement();
                txtElemName.AutoSize = true;
                txtElemName.Font.Name = "Arial";
                txtElemName.Font.Size = 14f;
                //txtElemName.Font.Unit = FontUnit.Point;
                txtElemName.Font.Bold = true;
                txtElemName.ForeColor = System.Drawing.Color.Black;
                txtElemName.Text = fullname;
                txtElemName.TextQuality = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                txtElemName.X = 100;
                txtElemName.Y = 340;
                //Add element to output image
                imgDraw.Elements.Add(txtElemName);
            }


            //Email TextElement
            if (email.Length > 0)
            {
                TextElement txtElemEmail = new TextElement();
                txtElemEmail.AutoSize = true;
                txtElemEmail.Font.Name = "Georgia";
                txtElemEmail.Font.Size = 11f;
                //txtElemEmail.Font.Unit = FontUnit.Point;
                txtElemEmail.ForeColor = System.Drawing.Color.Black;
                txtElemEmail.Text = email;
                txtElemEmail.TextQuality = System.Drawing.Text.TextRenderingHint.AntiAlias;
                txtElemEmail.X = 100;
                txtElemEmail.Y = 300;
                //Add element to output image
                imgDraw.Elements.Add(txtElemEmail);
            }

            String Tipo = "";
            String Mes = "";
            String Ano = "";


            if (Type == "0")
            {
                Tipo = "Registros";
            }
            else
            {
                Tipo = "Registros";
            }
            Ano = DateTime.Today.Year.ToString();
            Mes = DateTime.Today.Month.ToString();
            //imgDraw.Save("~/AlfaNetRepositorioImagenes/Registros/2009/Mayo/prueba.png");
            String Separador = @"\";
            String PathFolder = @"F:\AlfaNet\AlfaNetRepositorioImagenes" + Separador + Tipo + Separador + Ano + Separador + Mes + Separador;

            String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Tipo + "/" + Ano + "/" + Mes + "/");
            String PathString = PathVirtual + FileName;
            if (Directory.Exists(PathVirtual))
            {
                //imgDraw.Save(@PathString);
                imgDraw.Save(PathString);
            }
            else
            {
                Directory.CreateDirectory(PathVirtual);
                imgDraw.Save(@PathString);
            }

            DSImagenTableAdapters.ImagenRutaTableAdapter TAImagenRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();

            Object CodigoRuta = TAImagenRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
            int codigoR = Convert.ToInt32(CodigoRuta);
            DSImagenTableAdapters.RegistroImagenTableAdapter ObjRegImg = new DSImagenTableAdapters.RegistroImagenTableAdapter();

            ObjRegImg.InsertRegistroImagen(Grupo, Convert.ToInt32(RegistroCodigo), FileName, codigoR);
        }
        catch (Exception Error)
        {
            throw new ApplicationException("Error en clase GuardarImg. " + Error.Message);
        }
        
	}
}
