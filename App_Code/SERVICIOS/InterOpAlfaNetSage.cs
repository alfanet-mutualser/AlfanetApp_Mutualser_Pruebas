using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System;
////////////////////////////////////////
using System.IO;
using System.Net;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
using WebServiceAlfaBDU;
using System.Data;
///////////////////////////////////////////////////

/// <summary>
/// Descripción breve de InterOpAlfaNet_Sage
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class InterOpAlfaNet_Sage : System.Web.Services.WebService {

    //string Procedencia_Codigo ="";
    FuncionalidadServicioImplementacion bdu = new FuncionalidadServicioImplementacion();

    public InterOpAlfaNet_Sage () {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public String BDU()
    {
        try
        {
            string Resultex;
            Resultex = "a";
            IAB_003Request RequestIAB003 = new IAB_003Request();
            IAB_003Response ResponseIAB003 = new IAB_003Response();
            //IMB_001Request RequestIAB001 = new IMB_001Request();
            IMB_001Response ResponseIMB001 = new IMB_001Response();

            ResponseIMB001 = bdu.IMB_001();

            RequestIAB003.NitOperador = "860014923";
            RequestIAB003.ClaseServicio = "13";
            RequestIAB003.NumeroExpediente = "52684";
            RequestIAB003.Sucursal = "4";
            ResponseIAB003 = bdu.IAB_003(RequestIAB003);
            
            return Resultex;
        }
        catch (Exception ex)
        {
            string Resultex;
            Resultex = "Ocurrio un problema. ";
            //Exception inner = Error.InnerException;
            Resultex += ErrorHandled.FindError(ex);
            Resultex += " " + ex.Message;
            return Resultex;
        }
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


    //Autor: Anderson Ardila Martinez
    //Fecha: 06/02/2011
    //Consulta Comunicaciones x Tramite
    [WebMethod]
    public String[] ConsultaComunicadosXTramite(string vDocumentoCodigo, string vExpedienteCodigo)
    {
        try
        {
            DataTable tablaComunicado = new DataTable();
            DataTable tablaImagen = new DataTable();
            rutinas ejecutar = new rutinas();
            tablaComunicado = ejecutar.rtn_traer_ComunicadosxTramite(vDocumentoCodigo, vExpedienteCodigo);
            String[] registros = new String[tablaComunicado.Rows.Count + 1];

            if (tablaComunicado.Rows.Count == 0)
            {
                registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>No hay registros con esos datos</ERROR>" + "</Root>";
                return registros;
            }

            string salida = " <?xml version=\"1.0\" encoding=\"utf-8\"?>";
            salida += "<Root>";
            registros[0] = salida;
            int contador = 0;
            int contador2 = 0;

            foreach (DataRow dr in tablaComunicado.Rows)
            {
                contador = contador + 1;
                contador2 = 0;
                salida = "";

                salida += "<Documento Nro=\"" + dr["DocumentoNro"].ToString() + "\"" + ">";

                //Ruta del Archivo
                tablaImagen = ejecutar.rtn_traer_RutaImagenxTramite(vDocumentoCodigo, dr["TipoDocumento"].ToString());
                foreach (DataRow dr2 in tablaImagen.Rows)
                {
                    contador2 = contador2 + 1;
                    salida += "<Archivo\"" + contador2 + "\"" + ">";
                    salida += dr2["Ruta"].ToString();
                    salida += "</Archivo>";
                }
                

                //Expediente
                salida += "<Expediente>";
                salida += dr["Expediente"].ToString();
                salida += "</Expediente>";
                

                //Tipo de Documento
                salida += "<Tipo_Documento>";
                salida += dr["TipoDocumento"].ToString();
                salida += "</Tipo_Documento>";

                //Detalle del Documento
                salida += "<Detalle_Documento>";
                salida += dr["Detalle"].ToString();
                salida += "</Detalle_Documento>";

                salida += "</Documento>";
      
                registros[contador] = salida;
            }

            registros[contador] += "</Root>";
            return registros;

        }
        catch (Exception Ex)
        {
            String[] registros = new String[1];
            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>" + Ex.Message.ToString() + "</ERROR>" + "</Root>";
            return registros;
        }
    }
    //Fin Anderson Ardila


    //Autor: Anderson Ardila Martinez
    //Fecha: 09/02/2011
    //Consulta Comunicaciones x Fecha y Naturaleza
    [WebMethod]
    public String[] ConsultaComunicadosXFechaNaturaleza(string vFechaInicial, string vNaturalezaCodigo)
    {
        try
        {
            DataTable tablaComunicado = new DataTable();
            rutinas ejecutar = new rutinas();
            tablaComunicado = ejecutar.rtn_traer_ComunicadosXFechaNaturaleza(vFechaInicial, vNaturalezaCodigo);
            String[] registros = new String[tablaComunicado.Rows.Count + 1];

            if (tablaComunicado.Rows.Count == 0)
            {
                registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>No hay registros con esos datos</ERROR>" + "</Root>";
                return registros;
            }

            string salida = " <?xml version=\"1.0\" encoding=\"utf-8\"?>";
            salida += "<Root>";
            registros[0] = salida;
            int contador = 0;

            foreach (DataRow dr in tablaComunicado.Rows)
            {
                contador = contador + 1;
                salida = "";

                //Documento
                salida += "<Documento Nro=\"" + dr["DocumentoNro"].ToString() + "\"" + ">";

                //Expediente
                salida += "<Expediente>";
                salida += dr["Expediente"].ToString();
                salida += "</Expediente>";


                //Tipo de Documento
                salida += "<Tipo_Documento>";
                salida += dr["TipoDocumento"].ToString();
                salida += "</Tipo_Documento>";

                salida += "</Documento>";

                registros[contador] = salida;
            }

            registros[contador] += "</Root>";
            return registros;

        }
        catch (Exception Ex)
        {
            String[] registros = new String[1];
            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>" + Ex.Message.ToString() + "</ERROR>" + "</Root>";
            return registros;
        }
    }
    //Fin Anderson Ardila

    }