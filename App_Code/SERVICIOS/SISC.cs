using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Net;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
using System.Data;


/// <summary>
/// Descripción breve de SISC
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SISC : System.Web.Services.WebService
{

    public SISC()
    {
        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }
        
    [WebMethod]
    public string Radicar_Tramite(string NUI, string Nombre, string Direccion, string Ciudad, string Telefono1, string Telefono2, string Email1, string Email2, string Fax, string Naturaleza, string Dependencia, string Expediente, string Detalle, string URL)
    {
        string coderror = null;
        string url;

        url = URL;
        try
        {
            if (Expediente == "")
            {
                Expediente = null;
            }
            if (Detalle == "")
            {
                Detalle = null;
            }
            string respuesta;

            string sizeURL;
            string[] search;
            int sizeNombre;
            string NombreArchivo = null;

            WebClient Client = new WebClient();

            String Grupo = "Radicados";
            String Ano = DateTime.Today.Year.ToString();
            String Mes = DateTime.Today.Month.ToString();

            String PathVirtual = HttpContext.Current.Server.MapPath("~/AlfaNetRepositorioImagenes/" + Grupo + "/" + Ano + "/" + Mes + "/");

            sizeURL = Convert.ToString(URL.Length);

            if (URL != "")
            {
                if (URL.Contains("\\"))
                {
                    search = URL.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

                }
                else //if (URL.Contains("/"))
                {
                    search = URL.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                }
                sizeNombre = search.Length;
                NombreArchivo = Convert.ToString(search.GetValue(sizeNombre - 1));

                Client.DownloadFile(URL, PathVirtual + NombreArchivo);
                Client.Dispose();
            }
          
            String Fecha = Convert.ToString(DateTime.Now);
            RadicarTramiteUAndesTableAdapters.Expediente_RadicarTramiteUATableAdapter Tabla = new RadicarTramiteUAndesTableAdapters.Expediente_RadicarTramiteUATableAdapter();
            RadicarTramiteUAndes.Expediente_RadicarTramiteUADataTable Dtabla = new RadicarTramiteUAndes.Expediente_RadicarTramiteUADataTable();
            Dtabla = Tabla.GetData(NUI, Nombre, Direccion, Ciudad, Telefono1, Telefono2, Email1, Email2, Fax, Naturaleza, Dependencia, Expediente, Detalle, url, DateTime.Now);
            coderror = Dtabla[0].ErrorNumber;
            if (coderror == null)
            {
                coderror = "0";
            }
            else
            {
                coderror = "1";
            }
            string Result;
            Result = "<Root>" + "<RadicadoCodigo>" + Dtabla[0].RadicadoCodigo + "</RadicadoCodigo>" + "<WFMovimientoFecha>" + Dtabla[0].WFMovimientoFecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Dtabla[0].ExpedienteCodigo + "</ExpedienteCodigo>" + "<CodigoError>" + coderror + "</CodigoError>" + "<MensajeError>" + Dtabla[0].ErrorMessage + "</MensajeError>" + "</Root>";
            if (URL != "")
            {
                String Descarga = RegistrarImg(URL, Dtabla[0].RadicadoCodigo, PathVirtual, NombreArchivo);
                if (Descarga != null)
                {
                    Result = "<Root>" + "<RadicadoCodigo>" + Dtabla[0].RadicadoCodigo + "</RadicadoCodigo>" + "<WFMovimientoFecha>" + Dtabla[0].WFMovimientoFecha + "</WFMovimientoFecha>" + "<ExpedienteCodigo>" + Dtabla[0].ExpedienteCodigo + "</ExpedienteCodigo>" + "<CodigoError>" + 1 + "</CodigoError>" + "<MensajeError>" + Descarga + "</MensajeError>" + "</Root>";
                }
            }
           
            return Result;
        }
        catch (Exception ex)
        {
            string Resultex;

            String Result;
            Resultex = "Ocurrio un problema al Radicar. ";
            //Exception inner = Error.InnerException;
            Resultex += ErrorHandled.FindError(ex);
            Resultex += " " + ex.Message;
            Result = "<Root>" + "<RadicadoCodigo></RadicadoCodigo>" + "<WFMovimientoFecha></WFMovimientoFecha><ExpedienteCodigo></ExpedienteCodigo>" + "<CodigoError>" + "1" + "</CodigoError>" + "<MensajeError>" + Resultex + "</MensajeError>" + "</Root>";
            return Result;
        }

    }

    public string RegistrarImg(string URL, String Radicado, String PathVirtual, String NombreArchivo)
    {
       

        try
        {                              
            DSImagenTableAdapters.RadicadoImagenTableAdapter TARadicadoImagen = new DSImagenTableAdapters.RadicadoImagenTableAdapter();
            DSImagenTableAdapters.ImagenRutaTableAdapter TAImgRuta = new DSImagenTableAdapters.ImagenRutaTableAdapter();
            DSImagen.ImagenRutaDataTable DTImgRuta = new DSImagen.ImagenRutaDataTable();

            Object CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
            int codigoR = Convert.ToInt32(CodigoRuta);
            
            if (CodigoRuta == null)
            {
                TAImgRuta.Insert(1, "", DateTime.Today.Year, DateTime.Today.Month, 1, PathVirtual);
            }
                CodigoRuta = TAImgRuta.SelectRutaCodigoByAnioMesGrupo(DateTime.Today.Year, DateTime.Today.Month, "1");
                codigoR = Convert.ToInt32(CodigoRuta);
                if (!Directory.Exists(PathVirtual))
                {
                    Directory.CreateDirectory(PathVirtual); 
                    
                }                               
            TARadicadoImagen.InsertRadicadoImagen("1", Convert.ToInt32(Radicado), NombreArchivo, codigoR);
                                      
            return null;
        }

        catch (Exception Ex)
        {
            return Ex.Message.ToString();
        }

    }

    [WebMethod]
    public String[] ArchivosxTramite(string numerodeidentificacion, string numeroderadicacion, string numerodetramite)
    {
        try
        {
            DataTable tabla = new DataTable();
            rutinas ejecutar = new rutinas();
            tabla = ejecutar.rtn_traer_FilexTramite(numerodeidentificacion, numeroderadicacion, numerodetramite);
            string salida = " <?xml version=\"1.0\" encoding=\"utf-8\"?>";
            salida += "<Root>";

            String[] registros = new String[tabla.Rows.Count + 1];
            registros[0] = salida;
            int contador = 0;
            foreach (DataRow dr in tabla.Rows)
            {
                contador = contador + 1;
                salida = "";
                //salida += "<Root>";
                salida += "<Tramite NumeroDocumento=\"" + dr["NumeroDocumento"].ToString() + "\"" + ">";

                // trae Tipo_de_Documento
                salida += "<Tipo_de_Documento>";
                salida += dr["GrupoNombre"].ToString();
                salida += "</Tipo_de_Documento>";

                // trae Numero_de_Tramite
                salida += "<Numero_de_Tramite>";
                salida += dr["ExpedienteCodigo"].ToString();
                salida += "</Numero_de_Tramite>";

                // ruta rutaimagen
                salida += "<RutaImagen>";
                salida += dr["ImagenRutaPath"].ToString() + dr["NombreImagen"].ToString();
                salida += "</RutaImagen>";

                salida += "</Tramite>";
                //salida += "</Root>";

                registros[contador] = salida;
            }

            if (contador == 0)
            {
                salida = "";                
                salida += "<Tramite NumeroDocumento>";
                salida += "</Tramite NumeroDocumento>";

                // trae Tipo_de_Documento
                salida += "<Tipo_de_Documento>";               
                salida += "</Tipo_de_Documento>";

                // trae Numero_de_Tramite
                salida += "<Numero_de_Tramite>";
                salida += "</Numero_de_Tramite>";

                // ruta rutaimagen
                salida += "<RutaImagen>";                
                salida += "</RutaImagen>";

                salida += "</Tramite>";
                //salida += "</Root>";
                registros[contador] = salida;
            }

            registros[contador] += "</Root>";


            return registros;

        }
        catch (Exception ex)
        {


        }
        finally
        {

        }
        return null;


    }
}
