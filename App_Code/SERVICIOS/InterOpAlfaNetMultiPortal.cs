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
using WebServiceAlfaBDU;
using System.Data;
//

/// <summary>
/// Descripción breve de RadicarTramite
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class InterOpAlfaNetMultiPortal : System.Web.Services.WebService
{
    //string Procedencia_Codigo ="";
    FuncionalidadServicioImplementacion bdu = new FuncionalidadServicioImplementacion();
    
    public string Buscar_BDU(string codigo_expediente)
    {
    
        if (codigo_expediente == null)
        {
            return "No Existe";
        }
        else
        {
            return "Existe";
        }
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
            Resultex = "Ocurrio un problema al Radicar. ";
            //Exception inner = Error.InnerException;
            Resultex += ErrorHandled.FindError(ex);
            Resultex += " " + ex.Message;
            return Resultex;
        }
    }

    [WebMethod]
    public string Radicar_Tramite(string NUI, string Nombre, string Direccion, string Ciudad, string Telefono1, string Telefono2, string Email1, string Email2, string Fax, string url, string Naturaleza, string Dependencia, string Expediente, string Detalle, string NombreArchivo) 
    {
         try
         {
             if (Expediente == "")
             {
                 Expediente = null;
             }                   

             if (Expediente != null)
             {

                 //IAB_003Request RequestIAB003 = new IAB_003Request();
                 //IAB_003Response ResponseIAB003 = new IAB_003Response();
                 //RequestIAB003.NitOperador = "860014923";
                 //RequestIAB003.ClaseServicio = "13";
                 //RequestIAB003.NumeroExpediente = "51766";
                 //ResponseIAB003 = bdu.IAB_003(RequestIAB003);
                 //ResponseIAB003.Result[0].NumeroExpediente = 
                 //ResponseIAB003.Result[]
                 //Request req = new Request();
                 //req.                 
             }                         
             
             String Fecha = Convert.ToString(DateTime.Now);
             RadicarTramiteIn.insertarprocedenciaDataTable Dtabla = new RadicarTramiteIn.insertarprocedenciaDataTable();
             RadicarTramiteInTableAdapters.insertarprocedenciaTableAdapter Tabla = new RadicarTramiteInTableAdapters.insertarprocedenciaTableAdapter();

             Dtabla = Tabla.GetData(NUI, Nombre, Direccion, Ciudad, Telefono1, Telefono2, Email1, Email2, Fax, url, Naturaleza, Dependencia, Expediente, Detalle, DateTime.Now);
            
             string coderror;
             if (Dtabla[0].ErrorNumber==null)
             {
                 coderror = "0";
             }
             else
             {
                 coderror = "1";
             }
             string Result;
             Result = "<Root>" + "<RadicadoCodigo>" + Dtabla[0].RadicadoCodigo + "</RadicadoCodigo>" + "<ExpedienteCodigo>" + Dtabla[0].ExpedienteCodigo + "</ExpedienteCodigo>" + "<CodigoError>" + coderror + "</CodigoError>" + "<MensajeError>" + Dtabla[0].ErrorMessage + "</MensajeError>" + "</Root>";
             if (url == "")
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
                 }
                 if (!Directory.Exists(PathVirtual))
                 {
                     Directory.CreateDirectory(PathVirtual);
                 }
                 TARadicadoImagen.InsertRadicadoImagen("1", Convert.ToInt32(Dtabla[0].RadicadoCodigo), Dtabla[0].RadicadoCodigo + "_1.pdf", codigoR);
                 if (Expediente != "101" && Expediente != "102")
                 {
                     TARadicadoImagen.InsertRadicadoImagen("1", Convert.ToInt32(Dtabla[0].RadicadoCodigo), Dtabla[0].RadicadoCodigo + "_2.pdf", codigoR);
                 }
             }
             else
             {
                 Descargar(url, Dtabla[0].RadicadoCodigo);
             }
             return Result;
         }
         catch (Exception ex)
         {
             string Resultex;
              Resultex="Ocurrio un problema al Radicar. ";
             //Exception inner = Error.InnerException;
              Resultex += ErrorHandled.FindError(ex);
              Resultex += " "+ ex.Message;
              return Resultex;
         }
   }

    [WebMethod]
    public String[] TraerEstadoSolicitud(string numerodeidentificacion, string numeroderadicacion, string numerodeexpediente)
    {
        DataTable tabla = new DataTable();
        rutinas ejecutar = new rutinas();
        tabla = ejecutar.rtn_traer_respuesta(numerodeidentificacion, numeroderadicacion, numerodeexpediente);
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
            salida += "<radicado id=\"" + dr["RADICADO"].ToString() + "\"" + ">";

            // trae Fechavencimiento
            salida += "<Fecha_Radicacion>";
            salida += dr["FECHARADICACION"].ToString();
            salida += "</Fecha_Radicacion>";

            // trae Fechavencimiento
            salida += "<Fecha_Vencimiento>";
            salida += dr["FECHAVENCIMIENTO"].ToString();
            salida += "</Fecha_Vencimiento>";

            // trae estado
            salida += "<estado_del_documento>";
            salida += dr["ESTADO"].ToString();
            salida += "</estado_del_documento>";

            // trae funcionario actual
            salida += "<funcionario_que_tiene_el_tramite>";
            salida += dr["nombredependenciaactual"].ToString();
            salida += "</funcionario_que_tiene_el_tramite>";

            // trae numero de respuesta
            salida += "<numero_de_respuesta>";
            salida += dr["numeroderespuesta"].ToString();
            salida += "</numero_de_respuesta>";

            // fecha de respuesta
            salida += "<fecha_de_respuesta>";
            salida += dr["fechaderespuesta"].ToString();
            salida += "</fecha_de_respuesta>";


            // funcionario que respondio
            salida += "<funcionario_que_respondio>";
            salida += dr["nombrefuncionariorespuesta"].ToString();
            salida += "</funcionario_que_respondio>";


            //  respuesta
            salida += "<respuesta>";
            salida += dr["respuesta"].ToString();
            salida += "</respuesta>";


            // ruta imagen
            salida += "<rutaimagen>";
            salida += dr["rutaimagenrespuesta"].ToString() + dr["nombreimagen"].ToString();
            salida += "</rutaimagen>";

            salida += "</radicado>";
            //salida += "</Root>";

            registros[contador] = salida;
        }

        registros[contador] += "</Root>";


        return registros;

    }

    [WebMethod]
    public String[] TraerEstadoTraza(string numerodeidentificacion, string numeroderadicacion, string numerodeexpediente, string naturaleza, string fechadesde, string fechahasta)
    {


        DataTable tabla = new DataTable();
        rutinas ejecutar = new rutinas();
        String[] registros = new String[1];
        DateTime xfechadesde;
        DateTime xfechahasta;

        if (naturaleza.Trim().Length == 0)
        {
            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>La Naturaleza es obligatoria</ERROR>" + "</Root>";
            return registros;

        }


        try
        {
            xfechadesde = Convert.ToDateTime(fechadesde);
        }
        catch (Exception ee)
        {

            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>La fecha desde es incorrecta el formato debe ser DD/MM/AAAA</ERROR>" + "</Root>";
            return registros;

        }



        try
        {
            xfechahasta = Convert.ToDateTime(fechahasta);
        }
        catch (Exception ee)
        {

            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>La fecha hasta es incorrecta el formato debe ser DD/MM/AAAA</ERROR>" + "</Root>";
            return registros;

        }


        if (xfechadesde > xfechahasta)
        {
            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>La fecha desde no puede ser mayor que la fecha hasta </ERROR>" + "</Root>";
            return registros;
        }

        xfechahasta = xfechahasta.AddDays(1);

        fechahasta = Convert.ToString(xfechahasta);


        tabla = ejecutar.rtn_traer_traza_del_radicado(numerodeidentificacion, numeroderadicacion, numerodeexpediente, naturaleza, fechadesde, fechahasta);
        string salida = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Root>";


        registros = new String[tabla.Rows.Count + 1];
        registros[0] = salida;
        int contador = 0;
        if (tabla.Rows.Count == 0)
        {
            registros[0] = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + " < Root > " + "<ERROR>No hay registros con esos datos</ERROR>" + "</Root>";
            return registros;
        }

        foreach (DataRow dr in tabla.Rows)
        {
            contador = contador + 1;
            salida = "";
            salida += "<radicado id=\"" + dr["numeroderadicacion"].ToString() + "\"" + " > ";

            // dependencia origen
            salida += "<dependencia_origen>";
            salida += dr["dependenciaorigen"].ToString();
            salida += "</dependencia_origen>";

            // dependencia destino
            salida += "<dependencia_destino>";
            salida += dr["dependenciadestino"].ToString();
            salida += "</dependencia_destino>";

            // paso
            salida += "<paso>";
            salida += dr["paso"].ToString();
            salida += "</paso>";


            // paso actual
            salida += "<paso_actual>";
            salida += dr["pasoactual"].ToString();
            salida += "</paso_actual>";


            // paso final
            salida += "<paso_final>";
            salida += dr["pasofinal"].ToString();
            salida += "</paso_final>";


            //  fecha
            salida += "<fecha>";
            salida += dr["fecha"].ToString();
            salida += "</fecha>";


            // fecha estado actual
            salida += "<fecha_estado_actual>";
            salida += dr["fechaestadoactual"].ToString();
            salida += "</fecha_estado_actual>";

            // fecha estado final
            salida += "<fecha_estado_final>";
            salida += dr["fechaestadofinal"].ToString();
            salida += "</fecha_estado_final>";

            // motas
            salida += "<notas>";
            salida += dr["notas"].ToString();
            salida += "</notas>";

            // serie
            salida += "<serie>";
            salida += dr["serie"].ToString();
            salida += "</serie>";

            // multitaterea
            salida += "<multitarea>";
            salida += dr["multitarea"].ToString();
            salida += "</multitarea>";

            // aacion
            salida += "<accion>";
            salida += dr["accion"].ToString();
            salida += "</accion>";

            // tipo de movimiento
            salida += "<tipo_de_movimiento>";
            salida += dr["tipodemovimiento"].ToString();
            salida += "</tipo_de_movimiento>";

            // grupo
            salida += "<grupo>";
            salida += dr["grupo"].ToString();
            salida += "</grupo>";

            salida += "</radicado>";

            registros[contador] = salida;
        }

        registros[contador] += "</Root>";



        return registros;

    }

    public string Descargar(string URL, String Radicado)
    {
        string sizeURL;
        string[] search;
        int sizeNombre;
        string NombreArchivo;

        try
        {

            sizeURL = Convert.ToString(URL.Length);

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

            WebClient Client = new WebClient();
            //Client.DownloadFile(URL, "../../../Bajando/" + NombreArchivo);


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
                    TARadicadoImagen.InsertRadicadoImagen("1", Convert.ToInt32(Radicado), NombreArchivo, codigoR);
                    Client.DownloadFile(URL, PathVirtual + NombreArchivo);
                    //this.FileUpload1.SaveAs(PathVirtual + this.FileUpload1.FileName);
                }
                else
                {
                    Directory.CreateDirectory(PathVirtual);
                    TARadicadoImagen.InsertRadicadoImagen("1", Convert.ToInt32(Radicado), NombreArchivo, codigoR);
                    Client.DownloadFile(URL, PathVirtual + NombreArchivo);
                    //this.FileUpload1.SaveAs(PathVirtual + this.FileUpload1.FileName);
                }
            }
            else
            {
                if (Directory.Exists(PathVirtual))
                {
                    TARadicadoImagen.InsertRadicadoImagen("1", Convert.ToInt32(Radicado), NombreArchivo, codigoR);
                    Client.DownloadFile(URL, PathVirtual + NombreArchivo);
                    //this.FileUpload1.SaveAs(PathVirtual + this.FileUpload1.FileName);
                }
                else
                {
                    Directory.CreateDirectory(PathVirtual);
                    TARadicadoImagen.InsertRadicadoImagen("1", Convert.ToInt32(Radicado), NombreArchivo, codigoR);
                    Client.DownloadFile(URL, PathVirtual + NombreArchivo);
                    //this.FileUpload1.SaveAs(PathVirtual + this.FileUpload1.FileName);

                }
            }

            return null;
        }

        catch (Exception Ex)
        {
            return Ex.Message.ToString();
        }

    }


}



