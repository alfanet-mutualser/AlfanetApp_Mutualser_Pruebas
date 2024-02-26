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
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;

public partial class Imagen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
          //Recuperamos el paramento con el id de imagen
            if (!IsPostBack)
            {
                string codImagen = Request["codImagen"];

                string senrodoc = Session["NroDoc"].ToString();
                string Tipo = senrodoc.Substring(0, 1);


                // Tipo radicado o registro
                this.HFImagen.Value = codImagen;


                byte[] imagen = (byte[])ODSImagen.Select();
                MemoryStream imageStream = new MemoryStream(imagen);
                Response.Clear();

                this.LblTipo.Text = imageStream.GetType().ToString();
                Response.ContentType = "image/jpeg";

                //Response.ContentType = "application/bmp";
                //Response.ContentType = "application/msword";
                //Response.ContentType = "application/vnd.ms-excel";

                //Mostramos la imagen en la página directamente
                //imageStream.WriteTo(Response.OutputStream);
                
                //MemoryStream imageStr = new MemoryStream();
                //imageStr = ConvertStreamTifTo(imageStream, codImagen, ImageFormat.Jpeg);
                //System.Web.UI.WebControls.Image
                //imageStr.WriteTo(Response.OutputStream);

                /*
                   if (Session["NroDoc"] != null) 
                   {
                   
                      senrodoc = Session["NroDoc"].ToString();
                      string Tipo = senrodoc.Substring(0, 1);
                      //string nrodoc = senrodoc.Substring(1);
                      this.HFImagen.Value = codImagen;
                
                            
                      if(Tipo == "1")
                      {
                          byte[] imagen = (byte[])ODSImagen.Select();
                          MemoryStream imageStream = new MemoryStream(imagen);
                          Response.Clear();
                          Response.ContentType = "image/tif";
                    
                          //Mostramos la imagen en la página directamente
                          imageStream.WriteTo(Response.OutputStream);
                          MemoryStream imageStr = new MemoryStream();
                          imageStr = ConvertStreamTifTo(imageStream, codImagen, ImageFormat.Jpeg);
                          // System.Web.UI.WebControls.Image
                          imageStr.WriteTo(Response.OutputStream);
                   
                          //System.Drawing.Image Imagen1;

                          //Imagen1 = System.Drawing.Image.FromStream(imageStream);
                          //FrameDimension dimension;
                          //dimension = new FrameDimension(Imagen1.FrameDimensionsList[0]);
                          ////String ArchivoTIF;
                          //String ArchivoIMG1 ;
                                                                    
                          // //Se activa la imagen del multitif en Image
                          //    Imagen1.SelectActiveFrame(dimension,0);
                          //    // Se Graba la imagen con el mismo nombre del multitiff 
                          //    //    más correlativo más la extensión del documento

                          //    string archivo = "hola" + "_" + "0" + "." + System.Drawing.Imaging.ImageFormat.Jpeg.ToString();
                          //    //string archivo = ArchivoIMG + "_" + Item + "." + Tipo.ToString;
                        
                          //    //imageStream.WriteTo(Response.OutputStream);
                          //    MemoryStream ms = new MemoryStream();
                          //    Imagen1.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                          //    ms.Seek(0, SeekOrigin.Begin);
                          //    ms.WriteTo(Response.OutputStream);
                          //    Imagen1.Dispose();
                          //    //Imagen1.Save(archivo, Tipo1);
                          //
                     
                       }                      
                 }
                 else
                 {
                      byte[] imagen = (byte[])ODSRegImagen.Select();
                      MemoryStream imageStream = new MemoryStream(imagen);
                      Response.Clear();
                      Response.ContentType = "image/jpeg";
                      //Mostramos la imagen en la página directamente
                      imageStream.WriteTo(Response.OutputStream);
                 }
              */
            }
          }
        catch (SqlException err)
        {
            Response.Clear();
            Response.Write("Error:" + err.Message.ToString());

        }
    }

    public static MemoryStream ConvertStreamTifTo(Stream ArchivoTIF, String ArchivoIMG, ImageFormat Tipo)
    {
        FrameDimension dimension;
        System.Drawing.Image Imagenes;
        MemoryStream ms = new MemoryStream();
        
        try
        {
            //Se carga el archivo TIF a un Image
            
            Imagenes = System.Drawing.Image.FromStream(ArchivoTIF);
            dimension = new FrameDimension(Imagenes.FrameDimensionsList[0]);
            //Se realiza un ciclo para ver todas las imagenes que contiene la dimensión
            for (int Item = 0; Item <= Imagenes.GetFrameCount(dimension) - 1; Item++)
            {
                //Se activa la imagen del multitif en Image
                Imagenes.SelectActiveFrame(dimension, Item);
                
                // Se Graba la imagen con el mismo nombre del multitiff 
                //    más correlativo más la extensión del documento
                string archivo = ArchivoIMG.ToString() + "_" + Item + "." + Tipo.ToString();
                //string archivo = ArchivoIMG + "_" + Item + "." + Tipo.ToString;
                
                Imagenes.Save(ms, Tipo);
                //ms.Seek(0, SeekOrigin.Begin);
                //ms.WriteTo(Response.OutputStream);
                //Imagenes.Dispose();Image.Save(@"c:\mis imagenes\imagen.jpg", 
                Imagenes.Save(archivo, Tipo);
               

            }
            //Se liberan los recursos
            Imagenes.Dispose();
            Imagenes = null;
            return ms;
        }
        catch (Exception ex)
        {
            return ms;
        }

    }

    public String ConvertTifTo(String ArchivoTIF, String ArchivoIMG,ImageFormat Tipo) 
        {
            FrameDimension dimension;
            System.Drawing.Image Imagenes;  
        try
           {
             //Se carga el archivo TIF a un Image
                
                Imagenes = System.Drawing.Image.FromFile(ArchivoTIF);
                dimension = new FrameDimension(Imagenes.FrameDimensionsList[0]);
             //Se realiza un ciclo para ver todas las imagenes que contiene la dimensión
            for (int Item = 0; Item <= Imagenes.GetFrameCount(dimension)-1; Item++)
                {
                     //Se activa la imagen del multitif en Image
                        Imagenes.SelectActiveFrame(dimension,Item);
                     // Se Graba la imagen con el mismo nombre del multitiff 
                     //    más correlativo más la extensión del documento
                        string archivo = ArchivoIMG + "_" + Item + "." + Tipo.ToString();
                    //string archivo = ArchivoIMG + "_" + Item + "." + Tipo.ToString;
                        Imagenes.Save(archivo, Tipo);
                }
            //Se liberan los recursos
            Imagenes.Dispose();
            Imagenes = null; 
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        }

}
