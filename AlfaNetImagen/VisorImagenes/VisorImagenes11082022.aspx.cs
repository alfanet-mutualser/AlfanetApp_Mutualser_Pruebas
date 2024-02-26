using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Neodynamic.WebControls.ImageDraw;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using iTextSharp.text;
using iTextSharp.text.pdf;
using zeus;
using System.Net;
using System.Net.NetworkInformation;

public partial class VImagenes : System.Web.UI.Page
{
	string ModuloLog = "VISOR";
    string ConsecutivoCodigo = "13";
    string ConsecutivoCodigoErr = "4";
    string ActividadLogCodigoErr = "ERROR";
	
    protected void Page_Load(object sender, EventArgs e)
    {
		IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    String IPAdd = string.Empty;
                    IPAdd = Request.ServerVariables["HTTP_X_FORWARDER_FOR"];
                    if (String.IsNullOrEmpty(IPAdd))
                    {
                        IPAdd = Request.ServerVariables["REMOTE_ADDR"];
                        localIP = IPAdd.ToString();
                        Session["IP"] = localIP;
                    }
                }
            }
			Session["Nombrepc"] = host.HostName.ToString();
            // System.Net.IPHostEntry hostEntry = Dns.GetHostEntry(Session["IP"].ToString());
            // Dns.BeginGetHostEntry(Request.UserHostAddress, new AsyncCallback(GetHostNameCallBack), Request.UserHostAddress);
		
        MembershipUser user = Membership.GetUser();
        if (user == null)
        {
            this.FileUpload1.Visible = false;
            this.BtnEnviar.Visible = false;
            this.imgclip.Visible = false;
            this.chkWatermark.Visible = false;
            this.ImageButton1.Visible = false;
            this.LinkButton2.Visible = false;
            //this.ImageButton2.Visible = true;

        }
        try
        {
            if (user == null)
            {
                this.Watermark(true);
            }
            string nrodoc = Request["DocumentoCodigo"];
            string Grupo = Request["GrupoCodigo"];
            string Grupopadre = Request["GrupoPadreCodigo"];

            //Numero Documento
            this.HFNroDoc.Value = Request["DocumentoCodigo"];
            String NombreArch = null;

            int j = 1;
            //Trabajo con radicado
            if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 1)
            {
                if (Grupo == "4")
                {
                    //Consulta  de Imagenes por Numero de documento
                    DSImagenTableAdapters.facturaImagen_selectById_av2TableAdapter TAFacturaImagen = new DSImagenTableAdapters.facturaImagen_selectById_av2TableAdapter();
                    DSImagen.facturaImagen_selectById_av2DataTable DTFacturaImagen = TAFacturaImagen.GetFacturaImagenById(Grupo, Convert.ToInt32(Request["DocumentoCodigo"]));

                    if (DTFacturaImagen.Count == 0)
                    {
                        LblDocumentoNro.Text = "No existen imagenes para este Radicado " + Request["DocumentoCodigo"];
                    }
                    else
                    {
                        foreach (DSImagen.facturaImagen_selectById_av2Row drImgRow in DTFacturaImagen.Rows)
                        {
                            DSImagenTableAdapters.ImagenRutaTableAdapter TAImagenRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                            DSImagen.ImagenRutaDataTable DTImagenRuta = TAImagenRuta.GetImagenRutaById(Convert.ToInt32(drImgRow.ImagenRutaCodigo.ToString()));
                            /*Se captura el consecutivo de folio*/
                            int tmFolio = Convert.ToInt32(drImgRow.FacturaImagenFolio.ToString());
                            /*Indagar si encontró el folio*/
                            //if (j == Convert.ToInt32(Request["ImagenFolio"]))
                            if (tmFolio == Convert.ToInt32(Request["ImagenFolio"]))
                            {
                                this.HFPath.Value = DTImagenRuta[0].ImagenRutaPath.ToString();
                                NombreArch = drImgRow.FacturaImagenNombre;
                                this.HFFileName.Value = NombreArch;
                            }

                            this.LblDocumentoNro.Text = "Radicado " + Request["DocumentoCodigo"];

                            HtmlTable Tabla = new HtmlTable();
                            ShowThumbanails(Tabla, j, drImgRow.FacturaImagenNombre, DTImagenRuta[0].ImagenRutaPath.ToString(), Convert.ToString(drImgRow.FacturaImagenFolio), Request["DocumentoCodigo"]);
                            //j = j + 1;
                            this.PlaceHolder1.Controls.Add(Tabla);
							this.LNImagen.Text = drImgRow.FacturaImagenNombre;
                        }
                    }
                }
                else
                {


                    //Consulta  de Imagenes por Numero de documento
                    DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
                    DSImagen.RadicadoImagenDataTable DTRadicadoImagen = TARadicadoImagen.GetRadicadoImagenById(Grupo, Convert.ToInt32(Request["DocumentoCodigo"]));

                    if (DTRadicadoImagen.Count == 0)
                    {
                        LblDocumentoNro.Text = "No existen imagenes para este radicado " + HFNroDoc.Value;
                    }
                    else
                    {
                        foreach (DSImagen.RadicadoImagenRow drImgRow in DTRadicadoImagen.Rows)
                        {
                            DSImagenTableAdapters.ImagenRutaTableAdapter TAImagenRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                            DSImagen.ImagenRutaDataTable DTImagenRuta = TAImagenRuta.GetImagenRutaById(Convert.ToInt32(drImgRow.ImagenRutaCodigo.ToString()));
                            /*Se captura el consecutivo de folio*/
                            int tmFolio = Convert.ToInt32(drImgRow.RadicadoImagenFolio.ToString());
                            /*Indagar si encontró el folio*/
                            //if (j == Convert.ToInt32(Request["ImagenFolio"]))
                            if (tmFolio == Convert.ToInt32(Request["ImagenFolio"]))
                            {
                                this.HFPath.Value = DTImagenRuta[0].ImagenRutaPath.ToString();
                                NombreArch = drImgRow.RadicadoImagenNombre;
                                this.HFFileName.Value = NombreArch;
                            }

                            this.LblDocumentoNro.Text = "Radicado " + Request["DocumentoCodigo"];

                            HtmlTable Tabla = new HtmlTable();
                            ShowThumbanails(Tabla, j, drImgRow.RadicadoImagenNombre, DTImagenRuta[0].ImagenRutaPath.ToString(), Convert.ToString(drImgRow.RadicadoImagenFolio), Request["DocumentoCodigo"]);
                            //j = j + 1;
                            this.PlaceHolder1.Controls.Add(Tabla);
							this.LNImagen.Text = drImgRow.RadicadoImagenNombre;
                        }
                    }
                }
            }
            else if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 2)
            {

                DSImagenTableAdapters.RegistroImagenTableAdapter TARegistroImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();
                DSImagen.RegistroImagenDataTable DTRegistroImagen = TARegistroImagen.GetRegistroImagenById(Grupo, Convert.ToInt32(Request["DocumentoCodigo"]));
                DSImagenTableAdapters.ImagenRutaTableAdapter TAImagenRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();


                if (DTRegistroImagen.Count == 0)
                {
                    LblDocumentoNro.Text = "No existen imagenes para este registro " + Request["DocumentoCodigo"];
                }
                else
                {
                    foreach (DSImagen.RegistroImagenRow drImgRow in DTRegistroImagen.Rows)
                    {
                        DSImagen.ImagenRutaDataTable DTImagenRuta = TAImagenRuta.GetImagenRutaById(Convert.ToInt32(drImgRow.ImagenRutaCodigo.ToString()));
                        /*Se captura el consecutivo de folio*/
                        int tmFolio = Convert.ToInt32(drImgRow.RegistroImagenFolio.ToString());
                        /*Indagar si encontró el folio*/

                        //if (j == Convert.ToInt32(Request["ImagenFolio"]))

                        if (tmFolio == Convert.ToInt32(Request["ImagenFolio"]))
                        {
                            this.HFPath.Value = DTImagenRuta[0].ImagenRutaPath.ToString();
                            NombreArch = drImgRow.RegistroImagenNombre;
                            this.HFFileName.Value = NombreArch;
                        }

                        this.LblDocumentoNro.Text = "Registro " + Request["DocumentoCodigo"];
                        HtmlTable Tabla = new HtmlTable();
                        ShowThumbanails(Tabla, j, drImgRow.RegistroImagenNombre, DTImagenRuta[0].ImagenRutaPath.ToString(), Convert.ToString(drImgRow.RegistroImagenFolio), Request["DocumentoCodigo"]);
                        //j = j + 1;
                        this.PlaceHolder1.Controls.Add(Tabla);
						this.LNImagen.Text = drImgRow.RegistroImagenNombre;
                    }
                }

            }
            else if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 101)
            {
                string[] Ruta = null;
                Int64 DocIdZafiro;

                DocIdZafiro = Convert.ToInt64(Request["CZ"]);
                try
                {

                    ZaffiroIntegrator ConsultaenZafiro = new ZaffiroIntegrator();
                    Ruta = ConsultaenZafiro.getImages(21, DocIdZafiro, "4fea1da0-55da-4ad3-baa6-06f10f4e06ed");

                    //ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;
                    //imgElem.SourceFile = Ruta;
                    String[] Extension = HFFileName.Value.Split('.');
                    String TipoArchivo = Extension[Extension.Length - 1];
                    HFPath.Value = Ruta[0];
                }
                catch (Exception ex)
                {
                    //throw new ApplicationException("No hay una Ruta. " + a.Message);
                }

                //}
            }
            int t = 0;

            if (!this.IsPostBack)
            {
                //Atributo Para Impresion
                //((System.Web.UI.WebControls.Image)PnlPrint.FindControl("ImgPrint")).Attributes.Add("onClick", "ClientSidePrint('currentPage');");
                //   
                ((System.Web.UI.WebControls.Image)PnlPrint.FindControl("ImgPrint")).Attributes.Add("onClick", "ClientSidePrint('currentPage');");
                if (!Roles.IsUserInRole(User.Identity.Name, "Administrador"))
                {
                    this.LinkButton1.Visible = false;
                    this.DeleteButton.Visible = false;
                }
                else
                {
                    this.LinkButton1.Visible = true;
                    this.DeleteButton.Visible = true;
                }

                //Instancia de ImageElement
                ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;
                //ImageElement ImgEle = new ImageElement();


                String[] Extension = HFFileName.Value.Split('.');
                String TipoArchivo = Extension[Extension.Length - 1];
                int indice = 0;
                if (TipoArchivo == "gif" || TipoArchivo == "Gif" || TipoArchivo == "GIF")
                {
                    ImageElement ImgElem = new ImageElement();
                    ImgElem.Source = ImageSource.File;
                    ImgElem.SourceFile = "~/AlfaNetImagen/iconos/icono_Blaco.jpg";
                    ImgElem.Name = "MyJpg";
                    ImageDraw2.Elements.Add(ImgElem);
                    indice = 1;

                }

                if (TipoArchivo == "gif" || TipoArchivo == "Gif" || TipoArchivo == "GIF" || TipoArchivo == "jpg" || TipoArchivo == "JPG" || TipoArchivo == "Jpg" || TipoArchivo == "png" || TipoArchivo == "PNG" || TipoArchivo == "Png" || TipoArchivo == "BMP" || TipoArchivo == "Bmp" || TipoArchivo == "bmp" || TipoArchivo == "TIF" || TipoArchivo == "Tif" || TipoArchivo == "tif")
                {
                    ////Get total pages once                        
                    ////ImgEle.Source = ImageSource.File;
                    ////ImgEle.SourceFile = @"F:\AlfaNet\AlfaNetImagen\iconos\icono_txt.gif";
                    ////ImgEle.SourceFile = HFPath.Value + HFFileName.Value;
                    ////ImgEle.Name = "MyJpg";
                    imgElem.SourceFile = HFPath.Value + HFFileName.Value;
                    if (imgElem.MultiPageCount == 0)
                    {

                        imgElem.SourceFile = "~/AlfaNetImagen/logoalfanetnoimagen.JPG";
                        //    //ImgEle.SourceFile = "~/AlfaNetImagen/logoalfanetnoimagen.JPG";

                    }
                    /////////////////////////////////////////////////////////////////
                    ////Get total pages once
                    t = ((ImageElement)this.ImageDraw2.Elements[indice]).MultiPageCount;
                    ////Store it in the ViewState
                    ViewState["TotalPages"] = t;
                    ////Load drop down list for pages
                    for (int i = 0; i < t; i++)
                    {
                        ddlPages.Items.Add(new System.Web.UI.WebControls.ListItem("Página " + (i + 1).ToString(), i.ToString()));
                    }
                    ddlPages.SelectedIndex = 0;

                    ////Display first page
                    this.DisplayTiffPage(0);

                    //////////////////////////////////////////////////////////
                    //this.SetZoom(int.Parse(this.ddlZoom.SelectedValue));
                    if (user == null)
                    {
                        this.SetZoom(50);
                        this.ddlZoom.SelectedValue = "50";
                        this.HFZoom.Value = this.ddlZoom.SelectedValue;
                    }
                    else
                    {
                        this.SetZoom(120);
                        this.HFZoom.Value = this.ddlZoom.SelectedValue;
                    }



                    this.FramePDF.Visible = false;
                    this.ImageDraw2.Visible = true;

                }
                //if (TipoArchivo == "Txt" || TipoArchivo == "Pdf" || TipoArchivo == "doc" || TipoArchivo == "docx" || TipoArchivo == "xls" || TipoArchivo == "xlsx" || TipoArchivo == "ppt" || TipoArchivo == "pptx" || TipoArchivo == "TXT" || TipoArchivo == "txt" || TipoArchivo == "PDF" || TipoArchivo == "pdf" || TipoArchivo == "xps" || TipoArchivo == "XPS")
                //{


                //    String[] Paths = HFPath.Value.Split('\\');
                //    String VirtualPath = "../../";
                //    int zv = 7;
                //    for (int z = 0; z < Paths.Length - 1; z = z + 1)
                //    {
                //        if (Paths[z] == "AlfaNetRepositorioImagenes")
                //        {
                //            VirtualPath = VirtualPath + Paths[z] + '/';
                //            zv = z;
                //        }
                //        else if (z > zv)
                //        {
                //            VirtualPath = VirtualPath + Paths[z] + '/';
                //        }
                //        //else if (Paths[z] == "AlfaNetApp")
                //        //{
                //        //    VirtualPath = @"http://10.244.1.208/Alfanet/" + Paths[2] + '/' + Paths[3] + '/' + Paths[2] + '/';
                //        //    z = 7;
                //        //}
                //        //else if (Paths[z] == "D:")
                //        //{
                //        //    VirtualPath = @"http://10.244.1.208/alfanet2015atras/" + Paths[3] + '/' + Paths[4] + '/' + Paths[5] + '/' + Paths[6] + '/';
                //        //    z = 7;
                //        //}

                //    }

                //    ImageDraw2.Visible = false;
                //    this.FramePDF.Attributes["Src"] = @VirtualPath + HFFileName.Value;
                //    this.FramePDF.DataBind();
                //    this.FramePDF.Visible = true;

                //}

                if (TipoArchivo == "Txt" || TipoArchivo == "Pdf" || TipoArchivo == "doc" || TipoArchivo == "docx" || TipoArchivo == "xls" || TipoArchivo == "xlsx" || TipoArchivo == "ppt" || TipoArchivo == "pptx" || TipoArchivo == "TXT" || TipoArchivo == "txt" || TipoArchivo == "PDF" || TipoArchivo == "pdf")
                {

                    if (Grupo == "4")
                    {
                        string DirectorioOrigen = HFPath.Value + HFFileName.Value;
                        string DirectorioDestino = AppDomain.CurrentDomain.BaseDirectory + "TemporalVisualisacion\\";
                        if (!Directory.Exists(DirectorioDestino))
                        {
                            Directory.CreateDirectory(DirectorioDestino);
                        }
                        string[] ficherosCarpeta = Directory.GetFiles(DirectorioDestino);
                        foreach (string ficheroActual in ficherosCarpeta)
                        {
                            File.Delete(ficheroActual);
                        }
                        File.Copy(DirectorioOrigen, DirectorioDestino + HFFileName.Value, true);
                        String[] Paths = (DirectorioDestino + HFFileName.Value.ToString()).Split('\\');
                        String VirtualPath = "../../";
                        int zv = 7;
                        for (int z = 0; z < Paths.Length - 1; z = z + 1)
                        {
                            if (Paths[z] == "TemporalVisualisacion")
                            {
								
                                VirtualPath = VirtualPath + Paths[z] + '/';
                                zv = z;
                            }
                            else if (z > zv)
                            {
                                VirtualPath = VirtualPath + Paths[z] + '/';
                            }
                            else if (Paths[z] == "imgregistros")
                            {
                                VirtualPath = @"\\172.23.24.163\alfaweb\Aplicacion\imgregistros\";
                            }
                            else if (Paths[z] == "imgradicados")
                            {
                                VirtualPath = @"\\172.23.24.163\alfaweb\Aplicacion\imgradicados\";
                            }
                        }

                        ImageDraw2.Visible = false;
                        this.FramePDF.Attributes["Src"] = VirtualPath + HFFileName.Value;
                        this.FramePDF.DataBind();
                        this.FramePDF.Visible = true;
                    }
                    else
                    {
                        String[] Paths = HFPath.Value.Split('\\');
                        String VirtualPath = "../../";
                        int zv = 7;
                        for (int z = 0; z < Paths.Length - 1; z = z + 1)
                        {
                            if (Paths[z] == "AlfaNetRepositorioImagenes")
                            {
                                VirtualPath = VirtualPath + Paths[z] + '/';
                                zv = z;
                            }
                            else if (z > zv)
                            {
                                VirtualPath = VirtualPath + Paths[z] + '/';
                            }
                            //else if (Paths[z] == "AlfaNetApp")
                            //{
                            //    VirtualPath = @"http://10.244.1.208/Alfanet/" + Paths[2] + '/' + Paths[3] + '/' + Paths[2] + '/';
                            //    z = 7;
                            //}
                            else if (Paths[2] == "D")
                            {
                                VirtualPath = @"http://192.168.202.192/alfanet2015atras/" + Paths[3] + '/' + Paths[4] + '/' + Paths[5] + '/' + Paths[6] + '/';
                                z = 7;
                            }

                        }

                        ImageDraw2.Visible = false;
                        this.FramePDF.Attributes["Src"] = @VirtualPath + HFFileName.Value;
                        this.FramePDF.DataBind();
                        this.FramePDF.Visible = true;

                    }

                }


                //if (TipoArchivo == "xps")

                //{


                //    String[] Paths = HFPath.Value.Split('\\');
                //    String VirtualPath = "../../";
                //    int zv = 7;
                //    for (int z = 0; z < Paths.Length - 1; z = z + 1)
                //    {
                //        if (Paths[z] == "AlfaNetRepositorioImagenes")
                //        {
                //            VirtualPath = VirtualPath + Paths[z] + '/';
                //            zv = z;
                //        }
                //        else if (z > zv)
                //        {
                //            VirtualPath = VirtualPath + Paths[z] + '/';
                //        }
                //        else if (Paths[z] == "AlfaNetApp")
                //        {
                //            VirtualPath = @"http://10.244.1.208/Alfanet/";
                //        }
                //        else if (Paths[z] == "D:")
                //        {
                //            VirtualPath = @"http://10.244.1.208/alfanet2015atras/";
                //        }

                //    }

                //    ImageDraw2.Visible = false;
                //    this.FramePDF.Attributes["Src"] = @VirtualPath + HFFileName.Value;
                //    this.FramePDF.DataBind();
                //    this.FramePDF.Visible = true;

                //}
				
				//LOG ACCESO
                string ActLogCod = "ACCESO";
                DateTime Fechain = DateTime.Now;
                //OBTENER CONSECUTIVO DE LOGS
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                DataRow[] fila = Conse.Select();
                string x = fila[0].ItemArray[0].ToString();
                string LOG = Convert.ToString(x);
                string Datosini = "Acceso a Visor, Documento: ";//Num Documento
                string Datosfin1 = nrodoc;
                string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                Int64 LogId = Convert.ToInt64(LOG);
                string IP = Session["IP"].ToString();
                string NombreEquipo = Session["Nombrepc"].ToString();
                System.Web.HttpBrowserCapabilities nav = Request.Browser;
                string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                DateTime FechaFin = DateTime.Now.AddMilliseconds(50);
                //Insert log acceso a visor imagenes
                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Acceso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                Acceso.InsertVisor(LogId, username, Fechain, ActLogCod, ModuloLog, Convert.ToInt32(HFNroDoc.Value), Grupo, Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                //Actualiza consecutivo
                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                ConseLogs.GetConsecutivos(ConsecutivoCodigo);
                // if (TipoArchivo == "xps")

                // {

            }
            else
            {
                if (ViewState["TotalPages"] != null)
                    t = (int)ViewState["TotalPages"];
            }

            if (user == null)
            {
                this.Watermark(true);
            }
        }
        catch (Exception ex)
        {
            this.LblMessageBox.Text = "Error: " + ex.Message.ToString();
            this.MPEMensaje.Show();
        }
    }
	// public void GetHostNameCallBack(IAsyncResult asyncResult)
    // {
        // string userHostAddress = (string)asyncResult.AsyncState;
        // System.Net.IPHostEntry hostEntry = System.Net.Dns.EndGetHostEntry(asyncResult);
        // Session["Nombrepc"] = hostEntry.HostName;
        // // tenemos el nombre del equipo cliente en hostEntry.HostName
    // }
    public void ShowThumbanails(HtmlTable Table, int i, String ImagenNombre, String Path, String Folio, String NumeroDocumento)
    {
        try
        {

            HtmlTableRow Row1 = new HtmlTableRow();
            //Row1.Attributes.Add("onClick", ShowFile());
            Table.Rows.Add(Row1);
            HtmlTableCell Cell0 = new HtmlTableCell();
            Row1.Cells.Add(Cell0);
            //Neodynamic.WebControls.ImageDraw.ImageDraw.ProcessImageRequest();
            //ImageDrawButton.ProcessImageRequest();
            //Create an instance of ImageDraw
            //Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
            HyperLink Hpl = new HyperLink();
            Hpl.ID = ImagenNombre;
            //Hpl.                        
            //ImageDraw imgDrawButton = new ImageDraw();
            //imgDrawButton.ID = ImagenNombre;

            //imgButton.ImageUrl = @"F:\AlfaNet\AlfaNetRepositorioImagenes\Radicados\2009\Mayo\icono_txt.gif";
            //ImageDrawButton.
            //Cell0.Controls.Add(imgButton);
            //Create an instance of ImageElement class
            //ImageElement imgElem = new ImageElement();
            ////Set the source property
            //imgElem.Source = ImageSource.File;
            String[] Paths = Path.Split('\\');
            String VirtualPath = "~/";
            int zv = 7;
            for (int z = 0; z < Paths.Length - 1; z = z + 1)
            {
                if (Paths[z] == "AlfaNetRepositorioImagenes")
                {
                    VirtualPath = VirtualPath + Paths[z] + '/';
                    zv = z;
                }
                else if (z > zv)
                {
                    VirtualPath = VirtualPath + Paths[z] + '/';
                }

            }

            String GrupoCodigo = Request["GrupoCodigo"];
            String GrupoPadreCodigo = Request["GrupoPadreCodigo"];

            string[] words = ImagenNombre.Split('.');
            int Ind = words.Length - 1;
            if (words[Ind] == "doc" || words[Ind] == "docx")
            {
                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_doc.gif";
                //Hpl.Target = "_Blank";
                Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                //Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                //Hpl.NavigateUrl = Path + ImagenNombre;

            }
            else if (words[Ind] == "xls" || words[Ind] == "xlsx")
            {
                //imgElem.SourceFile = @"F:\AlfaNet\AlfaNetImagen\iconos\icono_xls.gif";
                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_xls.gif";
                //Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                //Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;

            }
            else if (words[Ind] == "ppt" || words[Ind] == "pptx")
            {
                //imgElem.SourceFile = @"F:\AlfaNet\AlfaNetImagen\iconos\icono_ppt.gif";
                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_ppt.gif";
                Hpl.NavigateUrl = VirtualPath + ImagenNombre;
            }
            else if (words[Ind] == "pdf" || words[Ind] == "PDF")
            {
                //imgElem.SourceFile = @"F:\AlfaNet\AlfaNetImagen\iconos\icono_pdf.gif";
                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_pdf.gif";
                Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                //Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                //HtmlControl frame1 = (HtmlControl)this.Panel1.FindControl("FramePDF");
                //frame1.Visible = true;
                //Hpl.Target = "iframe1";
            }
            else if (words[Ind] == "txt" || words[Ind] == "TXT")
            {
                //Hpl.Target = "_Blank";
                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_txt.gif";
                Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
                //Hpl.NavigateUrl = VirtualPath + ImagenNombre;
            }
            else if (words[Ind] == "tif" || words[Ind] == "TIF")
            {
                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.jpg";
                Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
            }
            else if (words[Ind] == "jpg" || words[Ind] == "JPG")
            {
                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.jpg";
                Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
            }
            else if (words[Ind] == "png" || words[Ind] == "PNG")
            {
                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.jpg";
                Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
            }
            else if (words[Ind] == "xps" || words[Ind] == "XPS")
            {
                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.jpg";
                Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
            }
            else if (words[Ind] == "bmp" || words[Ind] == "BMP")
            {
                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.jpg";
                Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
            }
            else if (words[Ind] == "gif" || words[1] == "Gif" || words[Ind] == "GIF")
            {

                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.jpg";
                Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
            }
            else if (words[Ind] == "zip" || words[1] == "ZIP" || words[Ind] == "Zip")
            {

                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_zip.gif";
                Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                //Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
            }
            else if (words[Ind] == "rar" || words[1] == "RAR" || words[Ind] == "Rar")
            {

                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_zip.gif";
                Hpl.NavigateUrl = VirtualPath + ImagenNombre;
                //Hpl.NavigateUrl = "~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadreCodigo + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=" + Folio;
            }
            else
            {
                Hpl.ImageUrl = "~/AlfaNetImagen/iconos/icono_tif.jpg";
                Hpl.NavigateUrl = VirtualPath + ImagenNombre;
            }

            ////Add uploaded image
            //imgDraw.Elements.Add(imgElem);
            //imgDrawButton.Elements.Add(imgElem);
            //Add the ImageDraw object to the PlaceHolder Controls collection
            //this.PlaceHolder1.Controls.Add(imgDrawButton);
            //this.PnlImg.Controls.Add(Cell0);
            //this.PnlImg.Controls.Add(new LiteralControl("<br />"));
            this.PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
            this.PlaceHolder1.Controls.Add(Hpl);
            //Set the ImageDraw properties and objects now
            //Label LabelDep = new Label();
            //LabelDep.ID = "LabelDepCopia" + Convert.ToString(i);
            //LabelDep.Text = this.HFNroDoc.Value.ToString();
            //LabelDep.Visible = true;
            //LabelDep.Width = 150;
            //Cell0.Controls.Add(LabelDep);
            // }
        }
        catch (Exception ex)
        {
            this.LblMessageBox.Text = "Error: " + ex.Message.ToString();
            this.MPEMensaje.Show();
        }
    }
    public void ShowFile()
    {

    }
    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        string GGrupo = Request["GrupoCodigo"];
        string numdocu = Request["DocumentoCodigo"];
        decimal nrodoc = Convert.ToDecimal(numdocu);

        try
        {
            //Dim strFileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)

            if (this.FileUpload1.HasFile)
            {
                if (!(FileUpload1.FileName.Contains(" ") || FileUpload1.FileName.Trim() == String.Empty))
                {
                    if (FileUpload1.FileName.Contains("."))
                    {
                        //Definimos un nombre unico para guardar el archivo y que no vaya a sobreescribir
                        //algun archivo ya existente
                        string nombreArchivo = Request["GrupoPadreCodigo"].ToString() + "_" + Request["DocumentoCodigo"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + this.FileUpload1.FileName;

						//LOG CONSULTA
                        string ActLogCod = "CONSULTA";
                        string NumeroDocumento = Request["DocumentoCodigo"].ToString();
                        DateTime Fechain = DateTime.Now;
                        //OBTENER CONSECUTIVO DE LOGS
                        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
                        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
                        DataRow[] fila = Conse.Select();
                        string x = fila[0].ItemArray[0].ToString();
                        string LOG = Convert.ToString(x);//NUM DOC
                        string Datosini = "Consulta de Numero Documento";
                        string Datosfin1 = NumeroDocumento;
                        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
                        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
                        string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
                        Int64 LogId = Convert.ToInt64(LOG);
                        string IP = Session["IP"].ToString();
                        string NombreEquipo = Session["Nombrepc"].ToString();
                        System.Web.HttpBrowserCapabilities nav = Request.Browser;
                        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
                        DateTime FechaFin = DateTime.Now.AddMilliseconds(50);
                        //Insert log consultar  rad o reg en visor
                        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Acceso = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                        Acceso.InsertVisor(LogId, username, Fechain, ActLogCod, ModuloLog, Convert.ToInt32(NumeroDocumento), GGrupo, Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
                        //Actualiza consecutivo
                        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
						
                        //Radicado
                        if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 1)
                        {
                            if(GGrupo=="4")
                            {
                                DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
                                DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

                                DSFacturaTableAdapters.facturaimagen_createfacturaimagen_av2TableAdapter TAFactImg = new DSFacturaTableAdapters.facturaimagen_createfacturaimagen_av2TableAdapter();

                                DSFactura.facturaimagen_createfacturaimagen_av2DataTable DTFactImg =   new DSFactura.facturaimagen_createfacturaimagen_av2DataTable();


                                int Anio = DateTime.Today.Year;
                                int Mes = DateTime.Today.Month;
                                string path = System.Configuration.ConfigurationManager.AppSettings["repositoriofacturas"];
                                string pathTotal = path + Anio.ToString() + "\\" + Mes.ToString() + "\\";
                                int? rutacod = 0;

                                DSImagenTableAdapters.imagenruta_getimagenrutacodigo_av2TableAdapter TAFacturaImagen = new DSImagenTableAdapters.imagenruta_getimagenrutacodigo_av2TableAdapter();
                                DSImagen.imagenruta_getimagenrutacodigo_av2DataTable DTFacturaImagen = new DSImagen.imagenruta_getimagenrutacodigo_av2DataTable();
                                TAFacturaImagen.SelectRutaCodigoFacturas(Anio, Mes, path ,ref rutacod);

                                int? rutacodigo = rutacod; 

                                if (rutacodigo == 0 || rutacodigo == null)
                                {
                                    if (Directory.Exists(pathTotal))
                                    {
                                      TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 4, pathTotal);
                                      TAFactImg.InsertFacturaImagen(GGrupo, nrodoc , nombreArchivo, rutacodigo );
                                       this.FileUpload1.SaveAs(pathTotal + nombreArchivo);
                                    }
                                    else
                                    {
                                        Directory.CreateDirectory(pathTotal);
                                        TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 4, pathTotal);
                                        TAFactImg.InsertFacturaImagen(GGrupo, nrodoc, nombreArchivo, rutacodigo);
                                        this.FileUpload1.SaveAs(pathTotal + nombreArchivo);

                                    }
                                }
                                else
                                {
                                    if (Directory.Exists(pathTotal))
                                    {
                                        TAFactImg.InsertFacturaImagen(GGrupo, nrodoc, nombreArchivo, rutacodigo);
                                        this.FileUpload1.SaveAs(pathTotal + nombreArchivo);
                                    }
                                    else
                                    {
                                        Directory.CreateDirectory(pathTotal);
                                        TAFactImg.InsertFacturaImagen(GGrupo, nrodoc, nombreArchivo, rutacodigo);
                                        this.FileUpload1.SaveAs(pathTotal + nombreArchivo);
                                    }

                                }

                                this.LblUploadDetails.Visible = true;
                                this.LblUploadDetails.Text = string.Format(
                                            @"Nombre: {0}<br />
                                Tamaño (en bytes): {1:N0}<br />
                                Tipo: {2}",
                                this.FileUpload1.FileName,
                                this.FileUpload1.FileBytes.Length,
                                this.FileUpload1.PostedFile.ContentType);
                                this.PlaceHolder1.Controls.Clear();
                                Page_Load(null, null);								
								
                                this.LblMessageBox.Text = "Imagen Adicionada";
                                this.MPEMensaje.Show();

                                //LOG INSERTAR
                                string ActLogCod2 = "INSERTAR FACTURAS";
                                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos2 = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                                DSGrupoSQL.ConsecutivoLogsDataTable Conse2 = new DSGrupoSQL.ConsecutivoLogsDataTable();
                                Conse2 = Consecutivos2.GetConseActual(ConsecutivoCodigo);
                                DataRow[] fila2 = Conse2.Select();
                                string x2 = fila2[0].ItemArray[0].ToString();
                                string LOG2 = Convert.ToString(x2);
                                string Datosini2 = "Inserta Archivo:";
                                //Nombre Archivo + Tamaño + Bytes + Tipo +Almacenado en 
                                string Datosfin2 = this.FileUpload1.FileName + " | " + this.FileUpload1.FileBytes.Length + " | " + this.FileUpload1.PostedFile.ContentType + " | " + pathTotal;
                                DateTime FechaFin2 = DateTime.Now;
                                Int64 LogId2 = Convert.ToInt64(LOG2);
                                //Insert log insertar recibidos
                                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter InsertAdjuntar = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                                InsertAdjuntar.InsertVisor(LogId2, username, Fechain, ActLogCod2, ModuloLog, Convert.ToInt32(NumeroDocumento), GGrupo, Datosini2, Datosfin2, FechaFin2, IP, NombreEquipo, Navegador);
                                //Actualiza consecutivo
                                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs2 = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                                ConseLogs2.GetConsecutivos(ConsecutivoCodigo);
                            }
                            else
                            {
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
                                    CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                                    codigoR = Convert.ToInt32(CodigoRuta);
                                    if (Directory.Exists(PathVirtual))
                                    {
                                        TARadicadoImagen.InsertRadicadoImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                                        this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);
                                    }
                                    else
                                    {
                                        Directory.CreateDirectory(PathVirtual);
                                        TARadicadoImagen.InsertRadicadoImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                                        this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);
                                    }
                                }
                                else
                                {
                                    if (Directory.Exists(PathVirtual))
                                    {
                                        TARadicadoImagen.InsertRadicadoImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                                        this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);
                                    }
                                    else
                                    {
                                        Directory.CreateDirectory(PathVirtual);
                                        TARadicadoImagen.InsertRadicadoImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                                        this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);

                                    }
                                }
                                this.LblUploadDetails.Visible = true;
                                this.LblUploadDetails.Text = string.Format(
                                @"Nombre: {0}<br />
                            Tamaño (en bytes): {1:N0}<br />
                            Tipo: {2}",
                                this.FileUpload1.FileName,
                                this.FileUpload1.FileBytes.Length,
                                this.FileUpload1.PostedFile.ContentType);
                                this.PlaceHolder1.Controls.Clear();
                                Page_Load(null, null);
								
                                this.LblMessageBox.Text = "Imagen Adicionada";
                                this.MPEMensaje.Show();

                                //LOG INSERTAR
                                string ActLogCod2 = "INSERTAR RECIBIDOS";
                                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos2 = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                                DSGrupoSQL.ConsecutivoLogsDataTable Conse2 = new DSGrupoSQL.ConsecutivoLogsDataTable();
                                Conse2 = Consecutivos2.GetConseActual(ConsecutivoCodigo);
                                DataRow[] fila2 = Conse2.Select();
                                string x2 = fila2[0].ItemArray[0].ToString();
                                string LOG2 = Convert.ToString(x2);
                                string Datosini2 = "Archivo";
                                //Nombre Archivo + Tamaño + Bytes + Tipo +Almacenado en 
                                string Datosfin2 = this.FileUpload1.FileName + " | " + this.FileUpload1.FileBytes.Length + " | " + this.FileUpload1.PostedFile.ContentType + " | " + PathVirtual;
                                DateTime FechaFin2 = DateTime.Now;
                                Int64 LogId2 = Convert.ToInt64(LOG2);
                                //Insert log insertar recibidos
                                DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter InsertAdjuntar = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                                InsertAdjuntar.InsertVisor(LogId2, username, Fechain, ActLogCod2, ModuloLog, Convert.ToInt32(NumeroDocumento), GGrupo, Datosini2, Datosfin2, FechaFin2, IP, NombreEquipo, Navegador);
                                //Actualiza consecutivo
                                DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs2 = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                                ConseLogs2.GetConsecutivos(ConsecutivoCodigo);
                                
                            }
                        }
                        //Registro
                        else if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 2)
                        {
                            DSImagenTableAdapters.RegistroImagenTableAdapter TARegistroImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();
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
                                CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
                                codigoR = Convert.ToInt32(CodigoRuta);
                                if (Directory.Exists(PathVirtual))
                                {
                                    TARegistroImagen.InsertRegistroImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                                    this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);
                                }
                                else
                                {
                                    Directory.CreateDirectory(PathVirtual);
                                    TARegistroImagen.InsertRegistroImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                                    this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);
                                }
                            }
                            else
                            {
                                if (Directory.Exists(PathVirtual))
                                {
                                    TARegistroImagen.InsertRegistroImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                                    this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);
                                }
                                else
                                {
                                    Directory.CreateDirectory(PathVirtual);
                                    TARegistroImagen.InsertRegistroImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                                    this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);

                                }
                            }
                            this.LblUploadDetails.Visible = true;
                            this.LblUploadDetails.Text = string.Format(
                            @"Nombre: {0}<br />
                            Tamaño (en bytes): {1:N0}<br />
                            Tipo: {2}",
                            this.FileUpload1.FileName,
                            this.FileUpload1.FileBytes.Length,
                            this.FileUpload1.PostedFile.ContentType);
                            this.PlaceHolder1.Controls.Clear();
                            Page_Load(null, null);

                            this.LblMessageBox.Text = "Imagen Adicionada";
                            this.MPEMensaje.Show();

                            //LOG INSERTAR
                            string ActLogCod2 = "INSERTAR ENVIADOS";
                            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos2 = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                            DSGrupoSQL.ConsecutivoLogsDataTable Conse2 = new DSGrupoSQL.ConsecutivoLogsDataTable();
                            Conse2 = Consecutivos2.GetConseActual(ConsecutivoCodigo);
                            DataRow[] fila2 = Conse2.Select();
                            string x2 = fila2[0].ItemArray[0].ToString();
                            string LOG2 = Convert.ToString(x2);
                            string Datosini2 = "Archivo";  //NUMREG + Nombre Archivo + Tamaño + Bytes + Tipo +Almacenado en 
                            string Datosfin2 = NumeroDocumento + " | " + this.FileUpload1.FileName + " | " + this.FileUpload1.FileBytes.Length + " | " + this.FileUpload1.PostedFile.ContentType + " | " + PathVirtual;
                            DateTime FechaFin2 = DateTime.Now;
                            Int64 LogId2 = Convert.ToInt64(LOG2);
                            //Insertar log de insertar enviados
                            DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter InsertAdjuntar = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
                            InsertAdjuntar.InsertVisor(LogId2, username, Fechain, ActLogCod2, ModuloLog, Convert.ToInt32(NumeroDocumento), GGrupo, Datosini2, Datosfin2, FechaFin2, IP, NombreEquipo, Navegador);
                            //Actualiza consecutivo
                            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs2 = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
                            ConseLogs2.GetConsecutivos(ConsecutivoCodigo);
                        }
                    }
                    else
                    {
                        this.LblMessageBox.Text = "Archivo no tiene formato";
                        this.MPEMensaje.Show();
                    }
                }
                else
                {
                    this.LblMessageBox.Text = "El archivo asociado contiene espacios en el nombre y no puede ser adjuntado, Por Favor cambiar el nombre del archivo a adjuntar.";
                    this.MPEMensaje.Show();
                }
            }
            else
            {
                this.LblMessageBox.Text = "No ha especificado un archivo";
                this.MPEMensaje.Show();
            }

        }
        catch (Exception ex)
        {
            this.LblMessageBox.Text = "Error: " + ex.Message.ToString();
            this.MPEMensaje.Show();

            //Variables de LOG ERROR
            DateTime FechaInicio = DateTime.Now;
            string grupoo = "";
            //OBTENER CONSECUTIVO DE LOGS
            string DatosFinales = "Error al insertar en visor  " + ex;
            DateTime WFMovimientoFechaFin = DateTime.Now;
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConsecutivosErr = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            DSGrupoSQL.ConsecutivoLogsDataTable ConseErr = new DSGrupoSQL.ConsecutivoLogsDataTable();
            ConseErr = ConsecutivosErr.GetConseError(ConsecutivoCodigoErr);
            DataRow[] fila2 = ConseErr.Select();
            string z = fila2[0].ItemArray[0].ToString();
            string LOGERROR = Convert.ToString(z);
            Int64 LogIdErr = Convert.ToInt64(LOGERROR);
            string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
            DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
            string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
            string IP = HttpContext.Current.Session["IP"].ToString();
            string NombreEquipo = HttpContext.Current.Session["Nombrepc"].ToString();
            System.Web.HttpBrowserCapabilities nav = HttpContext.Current.Request.Browser;
            string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
            //Se hace el insert de Log error
            DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter Errores = new DSLogAlfaNetTableAdapters.LogAlfaNetErroresTableAdapter();
            Errores.GetError(LogIdErr, username, FechaInicio, ActividadLogCodigoErr, grupoo, ModuloLog, DatosFinales, WFMovimientoFechaFin, IP, NombreEquipo, Navegador);
            //Se hace el update consecutivo de Logs
            DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
            ConseLogs.GetConsecutivos(ConsecutivoCodigoErr);
        }
    }
    protected void ddlZoom_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetZoom(int.Parse(this.ddlZoom.SelectedValue));
    }
    private void SetZoom(int zoom)
    {
        //get ImageElement...
        ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;
        imgElem.Actions.Clear();

        //Create scale action
        Scale scaleAction = new Scale();
        scaleAction.WidthPercentage = zoom;
        scaleAction.HeightPercentage = zoom;

        imgElem.Actions.Add(scaleAction);
        this.HFZoom.Value = zoom.ToString();

        //this.LblMessageBox.Text = zoom.ToString();
        //this.MPEMensaje.Show();

    }
    protected void zoomMasButton_Click(object sender, EventArgs e)
    {
        if (this.ddlZoom.SelectedIndex - 1 >= 0)
        {
            this.SetZoomButtons(int.Parse(this.ddlZoom.Items[this.ddlZoom.SelectedIndex - 1].Value));
            this.ddlZoom.SelectedValue = this.ddlZoom.Items[this.ddlZoom.SelectedIndex - 1].Value;
        }

    }
    protected void zoomMenosButton_Click(object sender, EventArgs e)
    {
        if (this.ddlZoom.SelectedIndex + 1 <= ddlZoom.Items.Count)
        {
            this.SetZoomButtons(int.Parse(this.ddlZoom.Items[this.ddlZoom.SelectedIndex + 1].Value));
            this.ddlZoom.SelectedValue = this.ddlZoom.Items[this.ddlZoom.SelectedIndex + 1].Value;
        }
    }
    private void SetZoomButtons(int zoom)
    {
        //get ImageElement...
        ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;
        imgElem.Actions.Clear();

        if (zoom >= 0)
        {
            //Create scale action
            Scale scaleAction = new Scale();
            scaleAction.WidthPercentage = zoom;
            scaleAction.HeightPercentage = zoom;

            imgElem.Actions.Add(scaleAction);
            this.HFZoom.Value = zoom.ToString();

            //this.LblMessageBox.Text = zoom.ToString();
            //this.MPEMensaje.Show();
        }

    }
    private void Watermark(bool addWatermark)
    {
        if (addWatermark)
        {
            //Create watermark
            RectangleShapeElement rectWatermark = new RectangleShapeElement();
            rectWatermark.Width = 450;
            rectWatermark.Height = 70;
            MembershipUser user2 = Membership.GetUser();
            if (user2 == null)
            {
                rectWatermark.Text = "SOLO PARA CONSULTA";
            }
            else
            {
                rectWatermark.Text = "CONFIDENCIAL";
            }

            rectWatermark.Font.Bold = true;
            rectWatermark.Font.Name = "Arial Narrow";
            rectWatermark.Font.Size = 30f;
            rectWatermark.Fill.BackgroundColor = System.Drawing.Color.Transparent;
            rectWatermark.StrokeWidth = 5;
            rectWatermark.StrokeFill.BackgroundColor = System.Drawing.Color.FromArgb(127, System.Drawing.Color.Red);
            rectWatermark.TextForeColor = System.Drawing.Color.FromArgb(127, System.Drawing.Color.Red);

            //Rotate 45 degrees
            Rotate rotAction = new Rotate();
            rotAction.Angle = 45;

            //Apply rotation on watermark
            rectWatermark.Actions.Add(rotAction);

            //add watermark to composite image
            this.ImageDraw2.Elements.Add(rectWatermark);
        }
        else
        {
            //Remove watermark...
            if (this.ImageDraw2.Elements.Count == 2)
            {
                this.ImageDraw2.Elements.RemoveAt(1);
            }
        }
    }
    protected void chkWatermark_CheckedChanged(object sender, EventArgs e)
    {
        this.Watermark(this.chkWatermark.Checked);
    }
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get ImageElement...
        ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;
        //Set page to display
        imgElem.MultiPageIndex = int.Parse(this.ddlPages.SelectedValue);
        //Set output image name/id
        this.ImageDraw2.OutputImageName = "Page" + this.ddlPages.SelectedValue;
    }
    private void DisplayTiffPage(int increment)
    {
        //get total pages
        int totalPages = (int)ViewState["TotalPages"];

        //get ImageElement...
        ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;

        //get current page
        int cIndex = imgElem.MultiPageIndex + increment;

        if (cIndex < 0)
        {
            cIndex = 0;
        }
        else if (cIndex > totalPages - 1)
        {
            cIndex = totalPages - 1;
        }

        //Set page to display
        imgElem.MultiPageIndex = cIndex;

        //Set output image name/id
        //this.ImageDraw2.OutputImageName = "Page" + Request["DocumentoCodigo"] + cIndex.ToString();

        //Update drop down list index
        this.ddlPages.SelectedIndex = cIndex;
    }
    protected void prevButton_Click(object sender, ImageClickEventArgs e)
    {
        this.DisplayTiffPage(-1);
    }
    protected void nextButton_Click(object sender, ImageClickEventArgs e)
    {
        this.DisplayTiffPage(1);
    }
    protected void rotarIzqButton_Click(object sender, ImageClickEventArgs e)
    {
        //get ImageElement...
        ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;

        //Rotate 45 degrees

        Rotate rotAction = new Rotate();
        rotAction.Angle = 90;

        imgElem.Actions.Add(rotAction);

    }
    protected void rotarDerButton_Click(object sender, ImageClickEventArgs e)
    {
        //get ImageElement...
        ImageElement imgElem = this.ImageDraw2.Elements[0] as ImageElement;

        //Rotate 45 degrees

        Rotate rotAction = new Rotate();
        rotAction.Angle = 270;

        imgElem.Actions.Add(rotAction);

    }
    protected void DeleteButton_Click(object sender, ImageClickEventArgs e)
    {
        String Folio = Request["ImagenFolio"];
        String GrupoCodigo = Request["GrupoCodigo"];
        String NumeroDocumento = Request["DocumentoCodigo"];
        String GrupoPadre = Request["GrupoPadreCodigo"];

        if (GrupoPadre == "1")
        {
            DSImagenTableAdapters.RadicadoImagenTableAdapter TAImgRad = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
            TAImgRad.Delete(GrupoCodigo, Convert.ToInt32(NumeroDocumento), Convert.ToInt32(Folio));
        }
        else if (GrupoPadre == "2")
        {
            DSImagenTableAdapters.RegistroImagenTableAdapter TAImgReg = new DSImagenTableAdapters.RegistroImagenTableAdapter();
            TAImgReg.Delete(GrupoCodigo, Convert.ToInt32(NumeroDocumento), Convert.ToInt32(Folio));
        }
        Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=1");

    }
    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        String Folio = Request["ImagenFolio"];
        String GrupoCodigo = Request["GrupoCodigo"];
        String NumeroDocumento = Request["DocumentoCodigo"];
        String GrupoPadre = Request["GrupoPadreCodigo"];

        if (GrupoPadre == "1")
        {
            if (GrupoCodigo == "4")
            {
                DSFacturaTableAdapters.facturaImagen_eliminarFacturaImagen_av2TableAdapter TAeliminar = new DSFacturaTableAdapters.facturaImagen_eliminarFacturaImagen_av2TableAdapter();
                TAeliminar.EliminarImagen(Convert.ToInt32(NumeroDocumento), Convert.ToInt32(Folio));
            }
            else
            {
                DSImagenTableAdapters.RadicadoImagenTableAdapter TAImgRad = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
                TAImgRad.Delete(GrupoCodigo, Convert.ToInt32(NumeroDocumento), Convert.ToInt32(Folio));
            }
        }
        else if (GrupoPadre == "2")
        {
            DSImagenTableAdapters.RegistroImagenTableAdapter TAImgReg = new DSImagenTableAdapters.RegistroImagenTableAdapter();
            TAImgReg.Delete(GrupoCodigo, Convert.ToInt32(NumeroDocumento), Convert.ToInt32(Folio));
        }
        Response.Redirect("~/AlfanetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoPadreCodigo=" + GrupoPadre + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=1");
        //Response.Redirect("~/AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=" + NumeroDocumento + "&GrupoCodigo=" + GrupoCodigo + "&ImagenFolio=1");

        //LOG ELIMINAR
        string ActLogCod = "ELIMINAR";
        DateTime Fechain = DateTime.Now;
        //OBTENER CONSECUTIVO DE LOGS
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter Consecutivos = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        DSGrupoSQL.ConsecutivoLogsDataTable Conse = new DSGrupoSQL.ConsecutivoLogsDataTable();
        Conse = Consecutivos.GetConseActual(ConsecutivoCodigo);
        DataRow[] fila = Conse.Select();
        string x = fila[0].ItemArray[0].ToString();
        string LOG = Convert.ToString(x);
        string Datosini = " Documento: " + NumeroDocumento;
        string Datosfin1 = " Se elimina el siguiente archivo:" + LNImagen.Text;
        string username = Profile.GetProfile(Profile.UserName).UserName.ToString();
        DSUsuarioTableAdapters.UserIdByUserNameTableAdapter objUsr = new DSUsuarioTableAdapters.UserIdByUserNameTableAdapter();
        string UsrId = objUsr.Aspnet_UserIDByUserName(username).ToString();
        DateTime FechaFin = DateTime.Now.AddMilliseconds(50);
        Int64 LogId = Convert.ToInt64(LOG);
        string IP = Session["IP"].ToString();
        string NombreEquipo = Session["Nombrepc"].ToString();
        System.Web.HttpBrowserCapabilities nav = Request.Browser;
        string Navegador = nav.Browser.ToString() + " Version: " + nav.Version.ToString();
        //Insert log eliminar en visorimagenes
        DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter Eliminar = new DSLogAlfaNetTableAdapters.LogAlfaNetTableAdapter();
        Eliminar.InsertVisor(LogId, username, Fechain, ActLogCod, ModuloLog, Convert.ToInt32(NumeroDocumento), GrupoCodigo, Datosini, Datosfin1, FechaFin, IP, NombreEquipo, Navegador);
        //Actualiza consecutivo
        DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter ConseLogs = new DSGrupoSQLTableAdapters.ConsecutivoLogsTableAdapter();
        ConseLogs.GetConsecutivos(ConsecutivoCodigo);
    }
    protected void ImgBtnPrintPDF_Click(object sender, ImageClickEventArgs e)
    {
        int Imagenescount = ImageDraw2.Elements.Count;
        if (Imagenescount > 0)
        {

            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(HttpContext.Current.Server.MapPath("~/devjoker.pdf"), FileMode.Create));
            document.Open();

            ImageElement ImgEle = new ImageElement();
            if (Imagenescount > 0)
            {
                ImgEle = this.ImageDraw2.Elements[0] as ImageElement;
            }
            else if (Imagenescount > 1)
            {
                ImgEle = this.ImageDraw2.Elements[1] as ImageElement;
            }

            ImgEle.Name = "MyImage";

            int t = ImgEle.MultiPageCount;

            ViewState["TotalPages"] = t;
            for (int i = 0; i < t; i++)
            {
                //Set page to display
                ImgEle.MultiPageIndex = i;

                Byte[] BinaryImg = ImageDraw2.GetOutputImageBinary();

                iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(BinaryImg);

                png.Alignment = iTextSharp.text.Image.DEFAULT;
                png.ScalePercent(55);
                document.Add(png);
            }
            // Fin de Interface Image draw         

            document.Close();
            Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Buffer = true;
            Response.AddHeader("Content-disposition", "attachment; filename=" + "devjoker.pdf");
            HttpContext.Current.Response.Charset = String.Empty;
            Response.ContentType = "application/pdf";
            Response.TransmitFile(HttpContext.Current.Server.MapPath("~/devjoker.pdf"));
            HttpContext.Current.Response.End();

            //File.Delete(Server.MapPath("~/devjoker.pdf"));
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        //ImageElement ImgEle = new ImageElement();
        //if (Imagenescount > 0)
        //{
        //    ImgEle = this.ImageDraw1.Elements[0] as ImageElement;
        //}
        //else if (Imagenescount > 1)
        //{
        //    ImgEle = this.ImageDraw1.Elements[1] as ImageElement;
        //}

        //ImgEle.Name = "MyImage";

        //ImgEle.MultiPageIndex = this.ddlPages.SelectedIndex;

        //Byte[] BinaryImg = ImageDraw1.GetOutputImageBinary();
        //BinaryImg.

        //BinaryImg.

        //iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(BinaryImg);

        //png.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
        //png.ScalePercent(80);
        //document.Add(png);

    }
    protected void ImageButtonguardar_click(object sender, EventArgs e)
    {
        string Path_flie = "";
        if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 1)
        {
            DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
            DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
            DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

            Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
            int codigoR = Convert.ToInt32(CodigoRuta);
            String Grupo = "Radicados";
            String Ano = DateTime.Today.Year.ToString();
            String Mes = DateTime.Today.Month.ToString();

            Path_flie = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");
        }
        if (Convert.ToInt32(Request["GrupoPadreCodigo"]) == 2)
        {
            DSImagenTableAdapters.RegistroImagenTableAdapter TARegistroImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();
            DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
            DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

            Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
            int codigoR = Convert.ToInt32(CodigoRuta);
            String Grupo = "Registros";
            String Ano = DateTime.Today.Year.ToString();
            String Mes = DateTime.Today.Month.ToString();

            Path_flie = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");


        }
        string filename = this.HFFileName.Value;

        if (filename != "")
        {

            string path1 = Path_flie + filename;

            //string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Radicar un Documento.exe");
            //string path = this.HFPath.Value + this.HFFileName.Value;
            System.IO.FileInfo file = new System.IO.FileInfo(path1);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                //Response.Write("This file does not exist.");
            }
        }
    }
}
