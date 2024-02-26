using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace uploadFiles
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        protected void BtnSubir_Click(object sender, EventArgs e)
        {
            FileUpload fileup = FindControl("FileUpload1") as FileUpload;
            Label label = FindControl("Label1") as Label;
            Label1.Text = "";
            String Grupo = Session["Grupo"].ToString();

            if (FileUpload1.HasFile || FileUpload2.HasFile)
            {
                if(Convert.ToInt32(Grupo) == 1)

                {
                    Grupo = "1";

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

                        if (cantidad == 0)

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

                        Label1.Text += (Path.GetFileName(objFile.FileName));
                        Label1.Text +=((strPath + "\r\n" + "<br/>"));

                        //Response.Write(strPath + "\r\n" + "<br/>");

                    }

                }

                //Registro

                else if (Convert.ToInt32(Grupo) == 2)

                {
                    Grupo = "2";
                    DSImagenTableAdapters.RegistroImagenTableAdapter TARegistroImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();

                    DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();

                    DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();



                    Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");

                    int codigoR = Convert.ToInt32(CodigoRuta);

                    String GrupoStr = "Registros";

                    String Ano = DateTime.Today.Year.ToString();

                    String Mes = DateTime.Today.Month.ToString();



                    String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + GrupoStr + "/" + Ano + "/" + Mes);



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

                                strPath = " -> No Corresponde a un registro";

                            }

                        }

                        else

                        {

                            strPath = " -> Ya existe una imagen asociada al registro";

                        }

                        Label1.Text += (Path.GetFileName(objFile.FileName));
                        Label1.Text += ((strPath + "\r\n" + "<br/>"));
                        // Response.Write(strPath + "\r\n" + "<br/>");

                    }

                }

                Session.RemoveAll();

                Session.Clear();


                //string carpeta = Server.MapPath("~/Archivos/");

                //for (int i = 0; i < Request.Files.Count; i++)
                //{
                //    fileup.SaveAs(carpeta + Request.Files[i].FileName);
                //}

                //Label1.Text = "Archivo(s) seleccionado(s) y guardado(s) en el servidor.";
            }
            else
            {
                Label1.Text += ("Debe seleccionar un Archivo." + "\r\n" + "<br/>");
            }

        formMigracionMasiva.Attributes.Add("style","display:none;");

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
                FileUpload1.Dispose();
            if (FileUpload2.HasFile)
                FileUpload2.Dispose();
        }

    }
}