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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
//using Entity;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.X509;
using System.Security.Cryptography;
using SysX509 = System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;


//namespace Plantillas
//{
    public partial class Page_FinalizarPlantilla : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["registro"] = 0;
            }
        }
        /// <summary>
        /// Crea El documento pdf a partir de la plantilla, con el stiker
        /// que lleva el número de registro.
        /// </summary>
        /// <param name="nameFile">Nombre del archivo que se va a generar</param>
        /// <param name="registro">Número de registro para el stiker</param>
        /// <returns></returns>
        private string CreatePDFDocument(string nameFile, string registro, byte[] imgFirma)
        {
            try
            {
                //obtener variables pdf
                DataSet ds = new DataSet();
                Business BI = new Business();
                string codplantilla = Request.QueryString["plantilla"].ToString();
                string dependencia = Request.QueryString["depusuario"].ToString();
                string cliente = "MINISTERIO DE TECNOLOGIAS DE LA INFORMACION Y LAS COMUNICACIONES";
                string fechaRad = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString();
                string horaRad = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                //ds = BI.buscarPlnatilla(codplantilla, dependencia);
                //string contenido = Session["textoPlantilla"].ToString(); //ds.Tables[0].Rows[0]["HTML"].ToString();

                string target = createPath() + nameFile;
                //creacion pdf                
                Document document = new Document(PageSize.LETTER, 110f, 60f, 90f, 100f);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(target, FileMode.Create));
                //ItsEvents e = new ItsEvents();
                // + nameFile
                   
                //writer.PageEvent = e;
                document.Open();

                //iTextSharp.text.Image header = iTextSharp.text.Image.GetInstance(Server.MapPath(@"~\Plantillas\Plantillas\Imagenes\Encabezado.png"));
                //header.ScalePercent(74f);
                //header.SetAbsolutePosition(document.PageSize.Width - 36f - 540f, document.PageSize.Height - 72f);

                //iTextSharp.text.Image footer = iTextSharp.text.Image.GetInstance(Server.MapPath(@"~\Plantillas\Plantillas\Imagenes\Pie.png"));
                //footer.ScalePercent(74f);
                //footer.SetAbsolutePosition(document.PageSize.Width - 36f - 540f, document.PageSize.Height - 72f - 700f);
                //document.Add(header);
                //document.Add(footer);

                //iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(document.PageSize.Width - 160f, 640f, 120f, 5f);
                //rect.BorderWidth = 10f;
                //rect.BorderColor = iTextSharp.text.BaseColor.BLACK;

		iTextSharp.text.Image header = iTextSharp.text.Image.GetInstance(Server.MapPath(@"~\Plantillas\Plantillas\Imagenes\Encabezado.png"));
                header.ScalePercent(80f);
                header.SetAbsolutePosition(document.PageSize.Width - 90f - 540f, document.PageSize.Height - 110f);

                iTextSharp.text.Image footer = iTextSharp.text.Image.GetInstance(Server.MapPath(@"~\Plantillas\Plantillas\Imagenes\Pie.png"));
                footer.ScalePercent(74f);
                footer.SetAbsolutePosition(document.PageSize.Width - 45f - 540f, document.PageSize.Height - 100f - 700f);
                document.Add(header);
                document.Add(footer);

                iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(document.PageSize.Width - 160f, 640f, 120f, 80f);
                rect.BorderWidth = 10f;
                rect.BorderColor = iTextSharp.text.BaseColor.BLACK;

		PdfContentByte cb = writer.DirectContent;

                PdfPTable table = new PdfPTable(1);
                PdfPCell cel1 = new PdfPCell(new Phrase(cliente, FontFactory.GetFont("arial", 6, BaseColor.BLACK)));
                cel1.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                cel1.BorderWidthLeft = 0.9f;
                cel1.VerticalAlignment = 1;
                cel1.HorizontalAlignment = 1;
                cel1.BorderColor = BaseColor.LIGHT_GRAY;
                cel1.Colspan = 4;                
                table.AddCell(cel1);

                PdfPCell cel2 = new PdfPCell(new Paragraph("Fecha: " + fechaRad.ToString() + "         Hora: " + horaRad.ToString(), FontFactory.GetFont("arial", 6, BaseColor.BLACK)));
                cel2.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                cel2.BorderWidthLeft = 0.9f;
                cel2.BorderColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cel2);

                PdfPCell cel3 = new PdfPCell(new Paragraph("Registro No: " + registro, FontFactory.GetFont("arial", 6, BaseColor.BLACK)));
                cel3.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                cel3.BorderWidthLeft = 1f;
                cel3.BorderColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cel3);

                Business intelligence = null;
                DataSet DSRadicado = null;
                DataSet DSProcedencia = null;
                DataSet DSCiudad = null;

                intelligence = new Business();
                DSRadicado = new DataSet();
                DSProcedencia = new DataSet();
                DSCiudad = new DataSet();

                string radicado = Request.QueryString["radicado"].ToString();

                if (radicado.Contains(" |"))
                {
                    radicado = radicado.Remove(radicado.IndexOf(" |"));
                }

                DSRadicado = intelligence.obtenerDatosRadicado(radicado);

                string codProcedencia = DSRadicado.Tables[0].Rows[0]["ProcedenciaCodigo"].ToString();
                DSProcedencia = intelligence.obtenerDatosProcedencia(codProcedencia);


                string codciudad = DSProcedencia.Tables[0].Rows[0]["CiudadCodigo"].ToString();
                DSCiudad = intelligence.obtenerDatosCiudad(codciudad);

                string procNonbre = DSProcedencia.Tables[0].Rows[0]["ProcedenciaNombre"].ToString();
                string ciudadnombre = DSCiudad.Tables[0].Rows[0]["CiudadNombre"].ToString();

                PdfPCell cel4 = new PdfPCell(new Paragraph("Destino: " + procNonbre  , FontFactory.GetFont("arial", 6, BaseColor.BLACK)));
                cel4.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                cel4.BorderWidthLeft = 1f;
                cel4.BorderColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cel4);

                PdfPCell cel5 = new PdfPCell(new Paragraph("" + ciudadnombre , FontFactory.GetFont("arial", 6, BaseColor.BLACK)));
                cel5.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                cel5.BorderWidthLeft = 1f;
                cel5.BorderColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cel5);

                //document.Add(table);

                table.LockedWidth = true;


                float[] width = { 150 };
                table.SetTotalWidth(width);
                table.WriteSelectedRows(0, 5, document.PageSize.Width - 200f, document.PageSize.Height - 120f, writer.DirectContent);
                cb.Stroke();

                string html = Session["textoPlantilla"].ToString();//contenido;
                Paragraph par = new Paragraph();
                par.Alignment = 3;
                foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
                {
                    par.Add(E);
                }
                document.Add(par);

                iTextSharp.text.Image firma = iTextSharp.text.Image.GetInstance(imgFirma);
                firma.ScalePercent(74f);
                firma.SetAbsolutePosition(document.PageSize.Width - 36f - 450f, document.PageSize.Height - 72f - 600f);
                document.Add(firma);
                
                document.Close();
                return "OK";
                //writer.Close();
            }
            catch (Exception ex)
            {
                return "ERROR: al crear el Archivo PDF. " + ex.Message;
            }
            finally
            {
                //aca toca poner el cierre de los reader, el document etc, en caso de que ocurra algun error.
            }
        }

        protected void LBFirmar_Click(object sender, ImageClickEventArgs e)
        {
            LBFirmar.Enabled = false;
            //if (Session["registro"].ToString()=="0")
            if (Session["registro"].Equals(0))
	   //if (String.IsNullOrEmpty(Session["registro"].ToString()))
            {                
                try
                {
                    if (fuImagenFirma.HasFile)
                    {
                        if (valImgFirma(fuImagenFirma.FileName))
                        {
                            //Creamos el registro
                            DatosRegistro datos = new DatosRegistro();
                            datos = (DatosRegistro)Session["datos"];
                            string registro = registrar(datos);
                            crearRadicadoFuente(Convert.ToInt32(registro));
                            //sí el registro se realiza, creamos el pdf.
                            if (registro != "0")
                            {
                                string imagenName = "respuesta.pdf";
                                string nombreArchivo = 2 + "_" + registro + "_" + DateTime.Now.ToString("yyyyMMdd") + "_" + imagenName;
                                Session["ImgFirmaImageUrl"] = registro;
                                string creo = CreatePDFDocument(nombreArchivo, registro, fuImagenFirma.FileBytes);
                                if (creo == "OK")
                                {                                    
                                    //byte[] file = GetPdf(nombreArchivo);
                                    guardarArchivo(registro, nombreArchivo);                                    
                                    Session["registro"] = 1;
                                    upmessagealfa.Update();
                                    this.LblMessageBox.Text = "El registro No. " + registro + " se ha creado correctamente";
                                    this.MPEMessage.Enabled = true;
                                    this.MPEMessage.Show();                                   
                                    pnlBotonFirmar.Visible = false;
                                    pnlBotonAdjuntarVisualizar.Visible = true;
                                }
                                else
                                {                                    
                                    upmessagealfa.Update();
                                    this.LblMessageBox.Text = "Se ha creado el registro No. " + registro + ". <br /> El sistema no pudo generar el archivo asociado al registro.";

                                    this.MPEMessage.Enabled = true;
                                    this.MPEMessage.Show();
                                }
                            }
                            else
                            {
                                LBFirmar.Enabled = true;                                
                                upmessagealfa.Update();
                                this.LblMessageBox.Text = "En este momento no es posible generar el registro, por favor intente mas tarde";
                                this.MPEMessage.Enabled = true;
                                this.MPEMessage.Show();
                                LBFirmar.Enabled = false;
                            }
                        }
                        else
                        {
                            LBFirmar.Enabled = true;                            
                            upmessagealfa.Update();
                            this.LblMessageBox.Text = "Seleccione un formato de imagen válido jpg ó png)";
                            this.MPEMessage.Enabled = true;
                            this.MPEMessage.Show();
                        }
                    }
                    else
                    {
                        LBFirmar.Enabled = true;                        
                        upmessagealfa.Update();
                        this.LblMessageBox.Text = "Seleccione la imagen de su firma en formato .jpg ó .png";

                        this.MPEMessage.Enabled = true;
                        this.MPEMessage.Show();
                    }
                }
                catch (Exception ex)
                {                    
                    LBFirmar.Enabled = true;                    
                    upmessagealfa.Update();
                    this.LblMessageBox.Text = "Error en el sistema " + ex.Message;
                    this.MPEMessage.Enabled = true;
                    this.MPEMessage.Show();
                }
            }
            else
            {
                LBFirmar.Enabled = true;
                pnlBotonFirmar.Visible = false;
                pnlBotonAdjuntarVisualizar.Visible = true;
            }
        }

        private bool valImgFirma(string p)
        {
            if (p.ToLower().EndsWith(".png") || p.ToLower().EndsWith(".jpg"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public byte[] GetPdf(string nombreArchivo)
        {
            //lo toma del servidor de la carpeta temp que se cree para esto.
            string path = ConfigurationSettings.AppSettings["RutaTemp"] + nombreArchivo;

            try
            {
                byte[] file = File.ReadAllBytes(path);
                return file;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void signPdf(byte[] pdfFile, X509Certificate2 objCert2, string nombreArchivo)
        {
            //ruta donde va a guardar en el cliente de manera temporal el archivo firmado.
            string target = createPath()+nombreArchivo;
            PdfReader objReader = new PdfReader(pdfFile);
            PdfStamper objStamper = PdfStamper.CreateSignature(objReader, new FileStream(target, FileMode.Create), '\0');

            PdfSignatureAppearance objSA = objStamper.SignatureAppearance;
            PdfDictionary objDict = new PdfDictionary();
            try
            {
                X509CertificateParser objCP = new X509CertificateParser();

                Org.BouncyCastle.X509.X509Certificate[] objChain = new Org.BouncyCastle.X509.X509Certificate[] { objCP.ReadCertificate(objCert2.RawData) };



                objSA.SetVisibleSignature(new iTextSharp.text.Rectangle(100, 100, 300, 200), 1, null);

                objSA.SignDate = DateTime.Now;
                objSA.Certificate = objChain[0];//objSA.SetCrypto(null, objChain, null, null);
                objSA.CertificationLevel = PdfSignatureAppearance.CERTIFIED_NO_CHANGES_ALLOWED;
                objSA.Reason = "Firma";
                objSA.Location = "Colombia";
                objSA.Acro6Layers = true;
                objSA.SignatureRenderingMode = iTextSharp.text.pdf.PdfSignatureAppearance.RenderingMode.NAME_AND_DESCRIPTION;//objSA.Render = PdfSignatureAppearance.SignatureRender.NameAndDescription;


                PdfSignature objSignature = new PdfSignature(PdfName.ADOBE_PPKMS, PdfName.ADBE_PKCS7_SHA1);
                objSignature.Date = new PdfDate(objSA.SignDate);
                objSignature.Name = objCert2.Subject;//iTextSharp.text.pdf.security.PdfPKCS7.GetSubjectFields(objChain[0]).GetField("CN");
                if (objSA.Reason != null)
                    objSignature.Reason = objSA.Reason;
                if (objSA.Location != null)
                    objSignature.Location = objSA.Location;
                objSA.CryptoDictionary = objSignature;
                int intCSize = 4000;
                Dictionary<PdfName, int> objTable = new Dictionary<PdfName, int>();
                objTable[PdfName.CONTENTS] = intCSize * 2 + 2;
                objSA.PreClose(objTable);
                //objSA.PreClose(
                HashAlgorithm objSHA1 = new SHA1CryptoServiceProvider();

                Stream objStream = objSA.GetRangeStream();//objSA.RangeStream;

                int intRead = 0;
                byte[] bytBuffer = new byte[8192];
                while ((intRead = objStream.Read(bytBuffer, 0, 8192)) > 0)
                    objSHA1.TransformBlock(bytBuffer, 0, intRead, bytBuffer, 0);
                objSHA1.TransformFinalBlock(bytBuffer, 0, 0);

                byte[] bytPK = SignMsg(objSHA1.Hash, objCert2, false);
                byte[] bytOut = new byte[intCSize];

                Array.Copy(bytPK, 0, bytOut, 0, bytPK.Length);

                objDict.Put(PdfName.CONTENTS, new PdfString(bytOut).SetHexWriting(true));
                objSA.Close(objDict);

            }
            catch (Exception ex)
            {
                //objSA.Close(objDict);
                //objReader.Close();
                throw ex;
            }
        }
        /// <summary>
        /// Crea la ruta donde vamos a guardar la imagen tanto en la base de datos
        /// como fisicamente en el servidor en caso de que no exista.
        /// </summary>
        /// <returns></returns>
        private string createPath()
        {
            //string GGrupo = "2";

            DSImagenTableAdapters.RegistroImagenTableAdapter TARegistroImagen = new DSImagenTableAdapters.RegistroImagenTableAdapter();
            DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
            DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

            Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
            int codigoR = Convert.ToInt32(CodigoRuta);
            String Grupo = "Registros";
            String Ano = DateTime.Today.Year.ToString();
            String Mes = DateTime.Today.Month.ToString();

            string PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");
            if (CodigoRuta == null)
            {
                TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 2, PathVirtual);
                //CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "2");
                //codigoR = Convert.ToInt32(CodigoRuta);
                if (Directory.Exists(PathVirtual))
                {
                    //TARegistroImagen.InsertRegistroImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                    //this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);
                    return PathVirtual;
                }
                else
                {
                    Directory.CreateDirectory(PathVirtual);
                    //TARegistroImagen.InsertRegistroImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                    //this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);
                    return PathVirtual;
                }
            }
            else
            {
                if (Directory.Exists(PathVirtual))
                {
                    //TARegistroImagen.InsertRegistroImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                    //this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);
                    return PathVirtual;
                }
                else
                {
                    Directory.CreateDirectory(PathVirtual);
                    //TARegistroImagen.InsertRegistroImagen(GGrupo, Convert.ToInt32(this.HFNroDoc.Value), nombreArchivo, codigoR);
                    //this.FileUpload1.SaveAs(PathVirtual + nombreArchivo);
                    return PathVirtual;
                }
            }
        }
        private byte[] SignMsg(byte[] message, X509Certificate2 objCert2, bool detached)
        {
            try
            {
                //Creamos el contenedor
                ContentInfo contentInfo = new ContentInfo(message);
                //Instanciamos el objeto SignedCms con el contenedor
                SignedCms objSignedCms = new SignedCms(contentInfo, detached);
                //Creamos el "firmante"
                CmsSigner objCmsSigner = new CmsSigner(objCert2);
                // Include the following line if the top certificate in the
                // smartcard is not in the trusted list.
                objCmsSigner.IncludeOption = X509IncludeOption.EndCertOnly;//objCmsSigner.IncludeOption = SysX509.X509IncludeOption.EndCertOnly;
                //  Sign the CMS/PKCS #7 message. The second argument is
                //  needed to ask for the pin.
                objSignedCms.ComputeSignature(objCmsSigner, false);
                //Encodeamos el mensaje CMS/PKCS #7
                return objSignedCms.Encode();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void crearRadicadoFuente(int registro)
        {
            try
            {
                string radicadofuente = Request.QueryString["radicado"];
                Session["Plantilla_RegistroNro"] = registro;
                if (radicadofuente != "")
                {
                    if (radicadofuente.Contains("|"))
                    {
                        radicadofuente = radicadofuente.Remove(radicadofuente.IndexOf("|"));
                    }
                    int radicado = Convert.ToInt32(radicadofuente);                    
                    Business intelligence = new Business();
                    intelligence.crearRadicadoFuente("2", registro, "1", radicado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string registrar(DatosRegistro datos)
        {
            try
            {
                Business BI = new Business();
                string registroCodigo = BI.crearRegistro(datos.grupoCodigo,
                                                            datos.wFMovimientoFecha,
                                                            datos.procedenciaCodDestino,
                                                            datos.dependenciaCodDestino,
                                                            datos.dependenciaCodigo,
                                                            datos.naturalezaCodigo,
                                                            datos.radicadoCodigo,
                                                            datos.registroDetalle,
                                                            datos.registroGuia,
                                                            datos.registroEmpGuia,
                                                            datos.anexoExtRegistro,
                                                            datos.logDigitador,
                                                            datos.expedienteCodigo,
                                                            datos.medioCodigo,
                                                            datos.serieCodigo,
                                                            datos.regPesoEnvio,
                                                            datos.regValorEnvio,
                                                            datos.registroTipo,
                                                            datos.wFAccionCodigo,
                                                            datos.wFMovimientoFechaEst,
                                                            datos.wFMovimientoFechaFin,
                                                            datos.wFMovimientoTipo,
                                                            datos.wFMovimientoNotas,
                                                            datos.wFMovimientoMultitarea,
                                                            datos.userId).ToString();
                return registroCodigo;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// Asocial la imagen al registro en la base de datos.
        /// </summary>
        /// <param name="registro">El registro que se ha generado</param>
        /// <param name="nombreArchivo">El nombre del archivo que se ha generado.</param>
        private void guardarArchivo(string registro,string nombreArchivo)
        {
            Business BI = new Business();
            DataSet ds = new DataSet();
            
            
                Business intelligence = new Business();
                DataSet datas = new DataSet();
                datas = intelligence.obtenerCodigoRuta(DateTime.Today.Year, DateTime.Today.Month, "2");
                string CodigoRuta = "";
                foreach (DataRow var in datas.Tables[0].Rows)
                {
                    CodigoRuta = datas.Tables[0].Rows[0]["ImagenRutaCodigo"].ToString();
                }
                
                string ano = DateTime.Today.Year.ToString();
                string mes = DateTime.Today.Month.ToString();

                String PathVirtual = ConfigurationSettings.AppSettings["RutaRepositorio"] + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\";

                if (CodigoRuta == null || CodigoRuta == "")
                {
                    intelligence.insertarImagen(1, "", DateTime.Today.Year, DateTime.Today.Month, 2, PathVirtual);

                    ds = intelligence.obtenerCodigoRuta(DateTime.Today.Year, DateTime.Today.Month, "2");

                    foreach (DataRow var in ds.Tables[0].Rows)
                    {
                        CodigoRuta = ds.Tables[0].Rows[0]["ImagenRutaCodigo"].ToString();
                    }
                    int codigoR = Convert.ToInt32(CodigoRuta);
                    if (Directory.Exists(PathVirtual))
                    {
                        intelligence.insertarRegistroImagen("2", Convert.ToInt32(registro), nombreArchivo, codigoR);
                    }
                    else
                    {
                        Directory.CreateDirectory(PathVirtual);
                        intelligence.insertarRegistroImagen("2", Convert.ToInt32(registro), nombreArchivo, codigoR);
                    }
                }
                else
                {
                    int codigoR = Convert.ToInt32(CodigoRuta);
                    if (Directory.Exists(PathVirtual))
                    {
                        intelligence.insertarRegistroImagen("2", Convert.ToInt32(registro), nombreArchivo, codigoR);
                    }
                    else
                    {
                        Directory.CreateDirectory(PathVirtual);
                        intelligence.insertarRegistroImagen("2", Convert.ToInt32(registro), nombreArchivo, codigoR);
                    }
                }
            
        }       

        private void addSticker(string pdf,string nombreArchivo,string registro)
        {
            string path = ConfigurationSettings.AppSettings["RutaRepositorio"] + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\"+pdf;
            string fechaRad = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString();
            string horaRad = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            PdfReader reader = null;
            FileStream fs = null;
            PdfStamper stamp = null;
            //Document document = null;


            try
            {
                reader = new PdfReader(path);
                //document = new Document();
                
                string outputPdf = ConfigurationSettings.AppSettings["RutaRepositorio"] + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\" + nombreArchivo;
                fs = new FileStream(outputPdf, FileMode.CreateNew, FileAccess.Write);
                stamp = new PdfStamper(reader, fs);

                PdfContentByte over = stamp.GetOverContent(1);
                over.BeginText();
                BaseFont font = BaseFont.CreateFont(@"c:\windows\fonts\arial.ttf", BaseFont.CP1252, true);
                over.SetFontAndSize(font, 8f);
                over.ShowTextAligned(4, fechaRad, 480f, 688f, 0f);
                over.ShowTextAligned(4, horaRad, 528f, 688f, 0f);
                over.ShowTextAligned(4, registro, 496f, 677f, 0f);
                over.EndText();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
                reader.Close();
                if (stamp != null) stamp.Close();
                if (fs != null) fs.Close();                
            }
        }


        protected void abrirPagina()
        {
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append(@"<script type='text/javascript'>");
            //sb.Append(@"$('#document').ready(function() {");
            //sb.Append(@"$('#dialog').dialog({");
            //sb.Append(@"modal: true,");
            //sb.Append(@"autoOpen: false");
            //sb.Append(@"});");
            ////sb.Append(@"$('#IBPlantillaSalir').click(function() {");
            ////sb.Append(@"alert('hola');");
            //sb.Append(@"$('#dialog').dialog('open');");
            ////sb.Append(@"return false;");
            ////sb.Append(@"});");
            //sb.Append(@"});");
            //sb.Append(@"</script>");
            //ScriptManager.RegisterStartupScript(this, Page.GetType(), "JScript", sb.ToString(), false);
        }

        protected void LBAdjuntar_Click(object sender, EventArgs e)
        {
            //LNumRegistro.Text = firma.Value.ToString();
            //Session["ImgFirmaImageUrl"] = Session["NumRegistro"].ToString();
            //string registro = Session["Plantilla_RegistroNro"].ToString();
            //Session["Plantilla_RegistroNro"] = Session["Plantilla_RegistroNro"].ToString();
            //LMessagePlantilla.Text = registro;
            //message();
            //Page.RegisterStartupScript("script", "<script>window.open('../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?" + "DocumentoCodigo=" + Session["Plantilla_RegistroNro"].ToString() + "&GrupoCodigo=2&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1' ,'Titulo','height=800', 'width=600')</script>");
            //ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "<script>window.open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?" + "DocumentoCodigo=" + registro + "&GrupoCodigo=2&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1' ,'Titulo','height=1000', 'width=2000')</script>", false);
		            //LNumRegistro.Text = firma.Value.ToString();
            //Session["ImgFirmaImageUrl"] = Session["NumRegistro"].ToString();
            string registro = Session["Plantilla_RegistroNro"].ToString();
            Session["Plantilla_RegistroNro"] = Session["Plantilla_RegistroNro"].ToString();
            //LMessagePlantilla.Text = registro;
            //message();
            //Page.RegisterStartupScript("script", "<script>window.open('../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?" + "DocumentoCodigo=" + Session["Plantilla_RegistroNro"].ToString() + "&GrupoCodigo=2&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1' ,'Titulo','height=800', 'width=600')</script>");

            string ventana = "<script>window.open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?" + "DocumentoCodigo=" + registro + "&GrupoCodigo=2&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1' ,'Titulo','height=1000', 'width=2000', 'top=50', 'left=50')</script>";
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", ventana.ToString(), false);
        
        }

        protected void LBCopiar_Click(object sender, EventArgs e)
        {            
            PCorreos.Visible = true;
            /* System.Text.StringBuilder sb = new System.Text.StringBuilder();
             sb.Append(@"<script type='text/javascript'>");
             sb.Append(@"$('#document').ready(function() {");
             sb.Append(@"$('#DivCorreos').dialog({");
             sb.Append(@"modal: false,");
             sb.Append(@"autoOpen: true,");
             sb.Append(@"title: 'Vista Previa Documento',");
             sb.Append(@"open: function(type, data) {");
             sb.Append(@"$(this).parent().appendTo('form');");
             sb.Append(@"}");
             sb.Append(@"});");
             //sb.Append(@"$('#IBPlantillaSalir').click(function() {");
             //sb.Append(@"alert('hola');");
             //sb.Append(@"$('#DivCorreos').dialog('open');");
             //sb.Append(@"return false;");
             //sb.Append(@"});");
             sb.Append(@"});");
             sb.Append(@"</script>");
             ScriptManager.RegisterStartupScript(this, Page.GetType(), "JScript", sb.ToString(), false);*/

        }

        protected void RBLCarreos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBLCarreos.SelectedValue == "1")
            {
                this.ACECorreos.ServiceMethod = "GetProcedenciaByTextNombre";
                //this.PopCDestino.Enabled = true;
                //this.ImageButton12.Visible = false;
            }
            else if (RBLCarreos.SelectedValue == "0")
            {
                this.ACECorreos.ServiceMethod = "GetDependenciaByText";
                //this.PopCDestino.Enabled = false;
                //this.ImageButton12.Visible = true;
            }
        }
        protected void IBCarreos_Click(object sender, ImageClickEventArgs e)
        {
            string email = TBCorreos.Text;
            LBCorreos.Items.Add(email);
            TBCorreos.Text = "";
        }
        protected void IBCorreosBorrar_Click(object sender, ImageClickEventArgs e)
        {
            LBCorreos.Items.Remove(LBCorreos.SelectedItem);
        }

        protected void LBCerrar_Click(object sender, EventArgs e)
        {
            PCorreos.Visible = false;
        }

        protected void LBEnviar_Click(object sender, EventArgs e)
        {
            Business intelligence = null;
            DataSet DSRadicado = null;
            DataSet DSProcedencia = null;
            DataSet imagenes = null;
            DataSet codigoImagenRuta = null;
            DataSet correoDep = null;
            DataSet datosProcedencia = null;
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            //MembershipUser usuario;
            MailMessage mail = null;
            Attachment attachment = null;
            try
            {
                intelligence = new Business();
                mail = new MailMessage();

                DSRadicado = new DataSet();
                DSProcedencia = new DataSet();
                
                string radicado = Request.QueryString["radicado"].ToString();
                if (radicado.Contains(" |"))
                {
                    radicado = radicado.Remove(radicado.IndexOf(" |"));
                }
                if (radicado != "")
                {
                    DSRadicado = intelligence.obtenerDatosRadicado(radicado);
                    string codProcedencia = DSRadicado.Tables[0].Rows[0]["ProcedenciaCodigo"].ToString();

                    DSProcedencia = intelligence.obtenerDatosProcedencia(codProcedencia);
                    string procedenciaMail = DSProcedencia.Tables[0].Rows[0]["ProcedenciaMail1"].ToString();
                    string procNonbre = DSProcedencia.Tables[0].Rows[0]["ProcedenciaNombre"].ToString();
                    string registro = Session["Plantilla_RegistroNro"].ToString();
                    if (procedenciaMail != "" || procedenciaMail != null)
                    {
                        if (Regex.IsMatch(procedenciaMail, expresion))
                        {                            
                            imagenes = new DataSet();
                            codigoImagenRuta = new DataSet();
                            //OBTENER IMAGENES DEL REGISTRO
                            string file = string.Empty;
                            string codigoRuta = string.Empty;
                            string ruta = string.Empty;
                            string imgs = string.Empty;
                            string imgsFinal = string.Empty;
                            imagenes = intelligence.obtenerImagenesRegistro("2", Convert.ToInt32(registro));
                            if (imagenes.Tables[0].Rows.Count != 0)
                            {
                                foreach (DataRow item in imagenes.Tables[0].Rows)
                                {
                                    file = item["RegistroImagenNombre"].ToString();
                                    codigoRuta = item["ImagenRutaCodigo"].ToString();
                                    codigoImagenRuta = intelligence.obtenerImagenruta(Convert.ToInt32(codigoRuta));
                                    foreach (DataRow items in codigoImagenRuta.Tables[0].Rows)
                                    {
                                        ruta = items["ImagenRutaPath"].ToString();

                                        imgs = ruta + file;
                                        attachment = new Attachment(imgs);
                                        mail.Attachments.Add(attachment);
                                    }
                                }
                            }

                            string Body = "Tiene un nuevo Registro Nro. " + registro;
                            correoDep = new DataSet();
                            string mails = "";
                            datosProcedencia = new DataSet();
                            string ccmails = "";
                            string cmails = "";
                            string usersdep = "";
                            //string mailcc = "";
                            //string mensajefinal = "";
                            string[] emails;

                            foreach (System.Web.UI.WebControls.ListItem item in LBCorreos.Items)
                            {
                                cmails = string.Empty;
                                mails = item.ToString();
                                emails = mails.Split('|');
                                mails = emails[0];
                                datosProcedencia = intelligence.obtenerDatosProcedencia(mails);
                                if (datosProcedencia.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow row in datosProcedencia.Tables[0].Rows)
                                    {
                                        cmails = row["ProcedenciaMail1"].ToString(); //SE OBTIENE LA PROCEDENCIA.
                                    }
                                }
                                DataSet DSUsuarioxDependencia = new DataSet();
                                DSUsuarioxDependencia = intelligence.obtenerUsuariosxDependencia(mails);
                                if (DSUsuarioxDependencia.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow row in DSUsuarioxDependencia.Tables[0].Rows)
                                    {
                                        usersdep = row["userid"].ToString();
                                        //string U = Convert.ToString(usersdep);
                                        System.Guid UId = new Guid(usersdep);

                                        MembershipUser user = Membership.GetUser(UId);
                                        cmails = user.Email.ToString();
                                    }
                                }

                                if (Regex.IsMatch(cmails, expresion))
                                {
                                    if (Regex.Replace(cmails, expresion, String.Empty).Length == 0)
                                    {
                                        if (cmails.ToString() != "")
                                        {
                                            ccmails += cmails + ",";
                                        }
                                        if (DSUsuarioxDependencia.Tables[0].Rows.Count > 0 && datosProcedencia.Tables[0].Rows.Count > 0)
                                        {
                                            //ccmails = ccmails.Substring(0, ccmails.Length - 1);
                                        }
                                    }                                    
                                }
                            }
				//SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
				//SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
                            SmtpClient SmtpServer = new SmtpClient("valeriana.mincomunicaciones.gov.co");
                            //mail.From = new MailAddress("alfanett@mintic.gov.co", "Mintic", System.Text.Encoding.UTF8);
				mail.From = new MailAddress("notificacion@mintic.gov.co", "MINTIC", System.Text.Encoding.UTF8);                            
				if (Regex.IsMatch(procedenciaMail, expresion))
                            {
                                if (Regex.Replace(procedenciaMail.ToString().Trim(), expresion, String.Empty).Length == 0)
                                {
                                    mail.To.Add(procedenciaMail);
                                    if (ccmails != "")
                                    {
                                        mail.CC.Add(ccmails);
                                    }

                                    mail.Subject = "Registro No: " + registro;
                                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                                    mail.Body = Body;
                                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                                    SmtpServer.Port = 25;
				   //SmtpServer.Port = 587;
                                    //SmtpServer.Credentials = new System.Net.NetworkCredential("notificacion@mintic.gov.co","Anonymous");
                                   //SmtpServer.Credentials = new System.Net.NetworkCredential("alfanett@mintic.gov.co", "Mintic2012");
					//SmtpServer.Credentials = new System.Net.NetworkCredential("alfanetpruebas@gmail.com", "pollito1");
                                    SmtpServer.UseDefaultCredentials = false;
					SmtpServer.EnableSsl = false;

                                    SmtpServer.Send(mail);
                                    //LMessagePlantilla.Text = "La respuesta ha sido enviada exitosamente";
                                    //message();
                                    upmessagealfa.Update();
                                    this.LblMessageBox.Text = "La respuesta ha sido enviada exitosamente";

                                    this.MPEMessage.Enabled = true;
                                    this.MPEMessage.Show();
                                }
                                else
                                {
                                    //return false;
                                }
                            }
                            else
                            {
                                //LMessagePlantilla.Text = "El correo Electronico de " + DSProcedencia.Tables[0].Rows[0]["ProcedenciaNombre"].ToString() + " no es Válido.<br />";
                                //message();
                                upmessagealfa.Update();
                                this.LblMessageBox.Text = "El correo Electronico de " + DSProcedencia.Tables[0].Rows[0]["ProcedenciaNombre"].ToString() + " no es Válido.<br />";

                                this.MPEMessage.Enabled = true;
                                this.MPEMessage.Show();
                            }
                            //btnFinalizar.Enabled = true;
                        }
                        else
                        {
                            lbtnPrint.Visible = true;
                            //LMessagePlantilla.Text = "El correo electrónico del destinatario: " + procNonbre + " no es válido. Debe enviar la respuesta en medio físico, la cual puede descargar aquí: ";

                            //message();
                            upmessagealfa.Update();
                            this.LblMessageBox.Text = "El correo electrónico del destinatario: " + procNonbre + " no es válido. Debe enviar la respuesta en medio físico, la cual puede descargar en la opción de Visualizar, Anexar, Imprimir";

                            this.MPEMessage.Enabled = true;
                            this.MPEMessage.Show();
                        }
                    }
                    else
                    {
                        //LMessagePlantilla.Text = "El correo electrónico del destinatario no existe. Debe enviar la respuesta en medio físico";
                        //message();
                        upmessagealfa.Update();
                        this.LblMessageBox.Text = "El correo electrónico del destinatario no existe. Debe enviar la respuesta en medio físico";

                        this.MPEMessage.Enabled = true;
                        this.MPEMessage.Show();
                    }
                }
                else
                {
                    string registro = Session["Plantilla_RegistroNro"].ToString();
                    imagenes = new DataSet();
                    codigoImagenRuta = new DataSet();
                    //OBTENER IMAGENES DEL REGISTRO
                    string file = string.Empty;
                    string codigoRuta = string.Empty;
                    string ruta = string.Empty;
                    string imgs = string.Empty;
                    string imgsFinal = string.Empty;
                    imagenes = intelligence.obtenerImagenesRegistro("2", Convert.ToInt32(registro));
                    if (imagenes.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow item in imagenes.Tables[0].Rows)
                        {
                            file = item["RegistroImagenNombre"].ToString();
                            codigoRuta = item["ImagenRutaCodigo"].ToString();
                            codigoImagenRuta = intelligence.obtenerImagenruta(Convert.ToInt32(codigoRuta));
                            foreach (DataRow items in codigoImagenRuta.Tables[0].Rows)
                            {
                                ruta = items["ImagenRutaPath"].ToString();

                                imgs = ruta + file;
                                attachment = new Attachment(imgs);
                                mail.Attachments.Add(attachment);
                            }
                        }
                    }
                    string Body = "Tiene un nuevo Registro Nro. " + registro;
                    correoDep = new DataSet();
                    string mails = "";
                    datosProcedencia = new DataSet();
                    string ccmails = "";
                    string cmails = "";
                    string usersdep = "";
                    //string mailcc = "";
                    //string mensajefinal = "";
                    string[] emails;

                    foreach (System.Web.UI.WebControls.ListItem item in LBCorreos.Items)
                    {
                        cmails = string.Empty;
                        mails = item.ToString();
                        emails = mails.Split('|');
                        mails = emails[0];

                        datosProcedencia = intelligence.obtenerDatosProcedencia(mails);
                        if (datosProcedencia.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in datosProcedencia.Tables[0].Rows)
                            {
                                cmails = row["ProcedenciaMail1"].ToString(); //SE OBTIENE LA PROCEDENCIA.
                            }
                        }

                        DataSet DSUsuarioxDependencia = new DataSet();
                        DSUsuarioxDependencia = intelligence.obtenerUsuariosxDependencia(mails);
                        if (DSUsuarioxDependencia.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in DSUsuarioxDependencia.Tables[0].Rows)
                            {
                                usersdep = row["userid"].ToString();
                                //string U = Convert.ToString(usersdep);
                                System.Guid UId = new Guid(usersdep);

                                MembershipUser user = Membership.GetUser(UId);
                                cmails = user.Email.ToString();
                            }
                        }
                        if (Regex.IsMatch(cmails, expresion))
                        {
                            if (Regex.Replace(cmails, expresion, String.Empty).Length == 0)
                            {
                                if (cmails.ToString() != "")
                                {
                                    ccmails += cmails + ",";
                                }
                                if (DSUsuarioxDependencia.Tables[0].Rows.Count > 0 && datosProcedencia.Tables[0].Rows.Count > 0)
                                {
                                    //ccmails = ccmails.Substring(0, ccmails.Length - 1);
                                }
                            }
                        }
                    }
			//SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
                          SmtpClient SmtpServer = new SmtpClient("valeriana.mincomunicaciones.gov.co");
			//SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    //mail.From = new MailAddress("alfanett@mintic.gov.co", "Mintic", System.Text.Encoding.UTF8);
                    mail.From = new MailAddress("notificacion@mintic.gov.co", "MINTIC", System.Text.Encoding.UTF8);
			if (ccmails != "")
                    {
                        mail.CC.Add(ccmails);
                    }
                    mail.Subject = "Registro No: " + registro;
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                    mail.Body = Body;
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    SmtpServer.Port = 25;

                        //SmtpServer.Credentials = new System.Net.NetworkCredential("notificacion@mintic.gov.co","Anonymous");
                        //SmtpServer.Credentials = new System.Net.NetworkCredential("alfanett@mintic.gov.co", "Mintic2012");
			//SmtpServer.Credentials = new System.Net.NetworkCredential("alfanetpruebas@gmail.com", "pollito1");
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.EnableSsl = false;

                    SmtpServer.Send(mail);
                    //LMessagePlantilla.Text = "La respuesta ha sido enviada exitosamente";
                    //message();
                    upmessagealfa.Update();
                    this.LblMessageBox.Text = "La respuesta ha sido enviada exitosamente";

                    this.MPEMessage.Enabled = true;
                    this.MPEMessage.Show();                
                }
            }
            catch (Exception ex)
            {
                //LMessagePlantilla.Text = "Falló el envío del correo electrónico con la respuesta. Descripción: "+ex.Message;
                //message();
                upmessagealfa.Update();
                this.LblMessageBox.Text = "Falló el envío del correo electrónico con la respuesta. Descripción: " + ex.Message;
                this.MPEMessage.Enabled = true;
                this.MPEMessage.Show();
            }
        }

        protected void btnCerrar_Click(object sender, ImageClickEventArgs e)
        {
            this.MPEMessage.Enabled = false;
        }

        protected void message()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(@"$(document).ready(function () {");            
            sb.Append(@"$('#dialog').dialog();");
            sb.Append(@"return false;");            
            sb.Append(@"});");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "JScript", sb.ToString(), false);
        }
        
        protected void btnContinuarACopiarCorreos_Click(object sender, ImageClickEventArgs e)
        {
            pnlEnviarPorCorreo.Visible = true;
            pnlBotonAdjuntarVisualizar.Visible = false;            
        }
        //protected void btnContinuarAEnviarPorCorreo_Click(object sender, ImageClickEventArgs e)
        //{
        //    //pnlCopiarACorreos.Visible = false;
        //    pnlEnviarPorCorreo.Visible = true;
        //}
        protected void btnFinalizar_Click(object sender, ImageClickEventArgs e)
        {
            //Con este boton se esta cerrando desde javascript con el evento OnClientClick
            if (lbtnPrint.Visible == true)
            {
                lbtnPrint.Visible = false;
            }
            Session.Remove("textoPlantilla");
            //Session["textoPlantilla"]
        }
        protected void btnAtrasAdjuntar_Click(object sender, ImageClickEventArgs e)
        {
            //pnlCopiarACorreos.Visible = false;
            //pnlBotonAdjuntarVisualizar.Visible = true;
        }
        protected void btnAtrasEnviarEmail_Click(object sender, ImageClickEventArgs e)
        {
            if (lbtnPrint.Visible == true)
            {
                lbtnPrint.Visible = false;
            }
            pnlBotonAdjuntarVisualizar.Visible = true;
            pnlEnviarPorCorreo.Visible = false;
            
        }
        protected void lbtnPrint_Click(object sender, EventArgs e)
        {
            string registro = Session["Plantilla_RegistroNro"].ToString();
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "<script>window.open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?" + "DocumentoCodigo=" + registro + "&GrupoCodigo=2&GrupoPadreCodigo=2&Admon=S&ImagenFolio=1' ,'Titulo','height=1000', 'width=1000')</script>", false);
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            DatosRegistro datos = (DatosRegistro)Session["datos"];
            Session["datos"] = null;
            //Session.Remove("datos");
            Response.Redirect("Page_RegistrarPlantilla.aspx?RadicadoCodigo=" + datos.radicadoCodigo);
        }
}
//}
