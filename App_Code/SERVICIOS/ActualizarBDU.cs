using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using WebServiceAlfaBDU;



/// <summary>
/// Descripción breve de ActualizarProcedencia
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ActualizarBDU : System.Web.Services.WebService {
    FuncionalidadServicioImplementacion bdu = new FuncionalidadServicioImplementacion();
    public ActualizarBDU () 
    {
        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string ModificarProcedencia
       (string nit       , string razonsocial, string direccion , string  telefono1, 
        string telefono2 ,  string fax       , string ciudad    , 
        string correo1   , string correo2    , string paginaweb , string  sucursal )
    
    {

        string salida = "";
        DataTable tabla = new DataTable();
        rutinas ejecutar = new rutinas();
        tabla = ejecutar.rtn_actualizar_procedencia_por_id
            (
            nit,
            razonsocial,
            direccion,
            telefono1,
            telefono2,
            fax,
            ciudad,
            correo1,
            correo2,
            paginaweb,
            sucursal 
            );

        if (tabla.Columns.Count == 1)
        {
            salida = "Error " + tabla.Rows[0]["error"].ToString();
        }

        if (tabla.Columns.Count>1)
        {
        if (tabla.Rows.Count==0) salida = "Error el Nui(Nit)  no existe ";
        if (tabla.Rows.Count > 0) salida =  "Ok. proceso existoso " ;
        }

        return salida;

    }

    [WebMethod]
    public string ModificarPreExpediente
       (string nit, string sucursal, string expediente, string ClaseDeServicio)
    {

        string salida = "";
        DataTable tabla = new DataTable();
        rutinas ejecutar = new rutinas();
        tabla = ejecutar.rtn_actualizar_preexpediente(nit, sucursal, expediente, ClaseDeServicio);

        if (tabla.Columns.Count == 1)
        {
            salida = "Error " + tabla.Rows[0]["error"].ToString();
        }

        if (tabla.Columns.Count > 1)
        {
            if (tabla.Rows.Count == 0) salida = " 0 filas actualizadas ";
            if (tabla.Rows.Count > 0) salida = "Actualizacion de preexpediente Ok.. ";
        }


        //foreach (DataRow xreader in tabla.Rows)
        //{
            
        //    string xerror = xreader["error"].ToString().Trim();
        //    string xfilas = xreader["filas"].ToString().Trim();

        //    if ((xerror == "0") && (xfilas == "0")) salida = " 0 filas actualizadas ";
        //    if ((xerror != "0") && (xfilas == "0")) salida = "Error.." + xerror;
        //    if ((xerror == "0") && (xfilas != "0")) salida = "proceso actualizacion de preexpediente Ok.." + xfilas + " Registros Actualizados";


        //}
        return salida;

    }

    [WebMethod]
    public string GetAlfaNetBDI
       (string Radicado, string GrupoCodigo)
    {
        string salida = "";
        DataTable tabla = new DataTable();
        rutinas ejecutar = new rutinas();
        tabla = ejecutar.rtn_Getalfanetbdi(Radicado, GrupoCodigo);
        DataRow[] rows = tabla.Select();
        if (tabla.Rows.Count == 0)
        {
            salida = "El Radicado No Existe ";
        }
        else if (tabla.Rows.Count >= 1)
        {
            salida = "<Root>" + "<Radicado>" + rows[0]["radicado"].ToString() + "</Radicado>" + "<FechaRadicado>" + rows[0]["fecharadicado"].ToString() + "</FechaRadicado>" + "<Remitente>" + rows[0]["remitente"].ToString() + "</Remitente>" + "<FechaRecibido>" + rows[0]["fecharecibido"].ToString() + "</FechaRecibido>" + "<Vinculo>" + rows[0]["vinculo"].ToString() + "</Vinculo>" + "</Root>";  
                  
        }                        
        return salida;
    }


}

