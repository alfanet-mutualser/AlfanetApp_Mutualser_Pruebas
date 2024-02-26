<%@ Page Language="C#" Debug="true" %>
<%@ import Namespace="System.IO" %>



<script runat="server" language="C#">



    void Page_Load(Object sender, EventArgs e)

    {        

       if (Request.ContentType.IndexOf("multipart/form-data") < 0)

                return;



             Response.Write( "Resultados Finales:\r\n\r\n" + "<br/><br/>" + Request.Files.Count.ToString() +  " Archivo(s):" + "<br/><br/>");



            String Grupo = Session["Grupo"].ToString();



            if (Convert.ToInt32(Grupo) == 1)

            {

                DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();

                DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();

                DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();



                Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");

                int codigoR = Convert.ToInt32(CodigoRuta);



                String GrupoStr = "Radicados";

                String Ano = DateTime.Today.Year.ToString();

                String Mes = DateTime.Today.Month.ToString();



                String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + GrupoStr + "/" + Ano + "/" + Mes);



                if (CodigoRuta == null)

                {

                    TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 1, PathVirtual);

                    CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");

                    codigoR = Convert.ToInt32(CodigoRuta);

                }



                if (!Directory.Exists(PathVirtual))

                {

                    Directory.CreateDirectory(PathVirtual);

                }



                for (int i = 0; i < Request.Files.Count; i++)

                {

                    HttpPostedFile objFile = Request.Files[i];

                    

                    String strPath = PathVirtual + "\\" + Path.GetFileName(objFile.FileName);

                    String[] Extension = Path.GetFileName(objFile.FileName).Split('.');

                    String NroRadicado = Extension[0].Trim();

                    int cantidad = 0;

                    try

                    {

                        DSImagenTableAdapters.RadicadoImagenTableAdapter DSRadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();

                        DSImagen.RadicadoImagenDataTable DTImagen = new DSImagen.RadicadoImagenDataTable();

                        DTImagen = DSRadicadoImagen.GetRadicadoImagenById(Grupo, Convert.ToInt32(NroRadicado));

                    

                    

                        foreach (System.Data.DataRow var in DTImagen.Rows)

                        {

                            string imagen = var["RadicadoImagenNombre"].ToString();

                            

                            if (Path.GetFileName(objFile.FileName) == imagen)

                            {

                                cantidad++;

                            }

                        }

                    }

                    catch (Exception)

                    {

                        strPath = "";

                    }

                    if (cantidad==0)

                    {

                        try

                        {

                            int Prueba = Convert.ToInt32(NroRadicado);

                            TARadicadoImagen.InsertRadicadoImagen(Grupo, Convert.ToInt32(NroRadicado), Path.GetFileName(objFile.FileName), codigoR);

                            objFile.SaveAs(strPath);
							strPath = " -> Imagen Cargada ";
							



                        }

                        catch (Exception ex)

                        {

                            strPath = " -> No Corresponde a un radicado ";

                        }

                    }

                    else

                    {

                        strPath = " -> Ya existe una imagen asociada al radicado ";

                    }

               Response.Write( Path.GetFileName( objFile.FileName ));     
               Response.Write(( strPath + "\r\n" + "<br/>") );
		
                    //Response.Write(strPath + "\r\n" + "<br/>");

                }

            }

            //Registro

            if (Convert.ToInt32(Grupo) == 2)

            {

                DSImagenTableAdapters.RegistroImagenTableAdapter TARegistroImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();

                DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();

                DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();



                Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");

                int codigoR = Convert.ToInt32(CodigoRuta);

                String GrupoStr = "Registros";

                String Ano = DateTime.Today.Year.ToString();

                String Mes = DateTime.Today.Month.ToString();



                String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + GrupoStr + "/" + Ano + "/" + Mes );



                if (CodigoRuta == null)

                {

                    TAImgRuta.Insert(2, "", DateTime.Today.Year, DateTime.Today.Month, 2, PathVirtual);

                    CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");

                    codigoR = Convert.ToInt32(CodigoRuta);

                }



                if (!Directory.Exists(PathVirtual))

                {

                    Directory.CreateDirectory(PathVirtual);

                }



                for (int i = 0; i < Request.Files.Count; i++)

                {

                    HttpPostedFile objFile = Request.Files[i];

                    String strPath = PathVirtual + "\\" + Path.GetFileName(objFile.FileName);

                    String[] Extension = Path.GetFileName(objFile.FileName).Split('.');

                    String NroRegistro = Extension[0].Trim();



                    int cantidad = 0;

                    try

                    {

                        DSImagenTableAdapters.RegistroImagenTableAdapter DSRegistroImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();

                        DSImagen.RegistroImagenDataTable DTImagen = new DSImagen.RegistroImagenDataTable();

                        DTImagen = DSRegistroImagen.GetRegistroImagenById(Grupo, Convert.ToInt32(NroRegistro));





                        foreach (System.Data.DataRow var in DTImagen.Rows)

                        {

                            string imagen = var["RegistroImagenNombre"].ToString();



                            if (Path.GetFileName(objFile.FileName) == imagen)

                            {

                                cantidad++;

                            }

                        }

                    }

                    catch (Exception)

                    {

                        strPath = "";

                    }

                    if (cantidad == 0)

                    {

                        try

                        {

                            int Prueba = Convert.ToInt32(NroRegistro);

                            TARegistroImagen.InsertRegistroImagen(Grupo, Convert.ToInt32(NroRegistro), Path.GetFileName(objFile.FileName), codigoR);

                            objFile.SaveAs(strPath);
							strPath = " -> Imagen Cargada  ";



                        }

                        catch (Exception ex)

                        {

                             strPath = " -> No Corresponde a un registro \r\n\r\n";

                        }

                    }

                    else

                    {

                        strPath = " -> Ya existe una imagen asociada al registro \r\n\r\n";

                    }

               Response.Write( Path.GetFileName( objFile.FileName ));     
               Response.Write(( strPath ) );
                   // Response.Write(strPath + "\r\n" + "<br/>");

                }

            }

            Session.RemoveAll();

            Session.Clear();

                 

    }

</script>

