<%@ Page Language="C#" Debug="true" %>

<%@ import NameSpace = "csNetUploadTrial" %>
<%@ Import NameSpace = "System.Data" %>
<%@ Import NameSpace = "System.Data.SqlClient" %>
<%@ Import NameSpace = "System.IO" %>
<%@ Import NameSpace = "System.Diagnostics" %>


<html>
<head>
<title>Saving the Upload</title>
</head>
<body>
<%

        try
        {
            UploadClass Upload = new UploadClass();
            Upload.ReadUpload();
            if (Upload.FileCount > 0)
            {

                String NumeroDocumento = Session["CodRegistro"].ToString();
                
                 /*cONSTRUCTOR DEl archivo*/
                DateTime D1 = DateTime.Now;

                String radFile = NumeroDocumento + "_" + D1.Year.ToString() +
                                 D1.Month.ToString() + D1.Day.ToString() + "" +
                                 D1.Hour.ToString() + D1.Minute.ToString() + D1.Second.ToString()+".TIF";
                    
                    
                //Radicado
                //if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 1)
                //{
                DSImagenTableAdapters.RegistroImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();
                DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

                Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
                int codigoR = Convert.ToInt32(CodigoRuta);
                String Grupo = "Registros";
                String Ano = DateTime.Today.Year.ToString();
                String Mes = DateTime.Today.Month.ToString();

                String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");

                if (CodigoRuta == null)
                {
                    TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 2, PathVirtual);

                }
                if (!Directory.Exists(PathVirtual))
                {
                    Directory.CreateDirectory(PathVirtual);

                }
                TARadicadoImagen.InsertRegistroImagen("2", Convert.ToInt32(NumeroDocumento), radFile, codigoR);
                Upload.SaveFile(0, PathVirtual + radFile);


            }

        }
        catch (Exception ex)
        {
           
        }
    
//   Change the NameSpace to "csNetUpload" if used with the full version

    //Request.Form("file");
    //UploadClass Upload = new UploadClass();
    //Upload.ReadUpload(); 
    /*
    try
    {

    if (Upload.FileCount > 0)
    {
        String NumeroDocumento = "16114";
        //Radicado
                //if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 1)
                //{
                    DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
                    DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                    DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

                    Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                    int codigoR = Convert.ToInt32(CodigoRuta);
                    String Grupo = "Radicados";
                    String Ano = DateTime.Today.Year.ToString();
                    String Mes = DateTime.Today.Month.ToString();

                    String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");

                    if (CodigoRuta == null)
                    {
                        TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 1, PathVirtual);
                        
                    }                         
                    if (!Directory.Exists(PathVirtual))                                             
                    {
                      Directory.CreateDirectory(PathVirtual);
                            
                           
                    }
                        TARadicadoImagen.InsertRadicadoImagen("1", Convert.ToInt32(NumeroDocumento), Upload.FileName(0), codigoR);
                        Upload.SaveFile(0, PathVirtual + Upload.FileName(0));             
                    
   
    }
        
    }
        catch(Exception ex)
    {
        throw new Exception(ex.Message);
    }
    */
%>
   

</body>
