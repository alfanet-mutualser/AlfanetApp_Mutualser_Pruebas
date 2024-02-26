using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSRegistroTableAdapters;
using DSRadicadoTableAdapters;
using DSGrupoSQLTableAdapters;
using DSFacturaTableAdapters;
using System.Globalization;
using System.Collections.Generic;

/// <summary>
/// Descripción breve de FacturaBLL
/// </summary>   
/// 

[System.ComponentModel.DataObject]
public class FacturaBLL
{
    private consultas_radicacionmasiva_av2TableAdapter FacturaAdapter = null;
    protected consultas_radicacionmasiva_av2TableAdapter AdapterFacturasConsultas
    {
        get
        {
            if (FacturaAdapter == null)
                FacturaAdapter = new consultas_radicacionmasiva_av2TableAdapter();

            return FacturaAdapter;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSFactura.consultas_radicacionmasiva_av2DataTable BuscarRad(string Radicador, string porImagen, string radInicial, string radFinal, string fechaInicial, string fechaFinal, string FacnReciboIni, string FacnReciboFin, string facValorMenor, string facValorMayor, string detalle, string nombreNit, string unidad, string ubicacion, string modalidad, string expediente, string numFacIni, string comEgresoIni, string comEgresoFin, string numFacFinal, string ciudadInicial, string ciudadFinal)
    {
        try
        {
            string strbase = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings.Get("BaseDatos"));

            // Radicador
            if (Radicador != "" && Radicador != null)
            {
                if (Radicador.Contains(" | "))
                {
                    Radicador = Radicador.Remove(Radicador.IndexOf(" | "));
                }
                else
                {
                    Radicador = null;
                }
            }
            else
            {
                Radicador = null;
            }
            // Por Imagen
            if (porImagen != "" && porImagen != null)
            {
                porImagen = porImagen;
            }
            else
            {
                porImagen = null;
            }
            // Rad Inicial - Final
            if (radInicial == "" || radInicial == null)
            {
                radInicial = null;
            }
            else
            {
                int RadCodIni = Convert.ToInt32(radInicial);
                radInicial = Convert.ToString(RadCodIni);
            }

            if (radFinal == "" || radFinal == null)
            {
                radFinal = null;
            }
            else
            {
                int RadCodFin = Convert.ToInt32(radFinal);
                radFinal = Convert.ToString(RadCodFin);
            }
            // Fecha Inicial - Final
            DateTime WFMovimientoFechaDateTime;
            if (fechaInicial == "" || fechaInicial == null)
            {

                WFMovimientoFechaDateTime = Convert.ToDateTime("10/10/1753");
                fechaInicial = WFMovimientoFechaDateTime.Year + "/" + WFMovimientoFechaDateTime.Month + "/" + WFMovimientoFechaDateTime.Day;

            }
            else
            {
                WFMovimientoFechaDateTime = Convert.ToDateTime(fechaInicial);
                fechaInicial = WFMovimientoFechaDateTime.Year + "/" + WFMovimientoFechaDateTime.Month + "/" + WFMovimientoFechaDateTime.Day;
            }

            DateTime WFMovimientoFecha1DateTime;
            if (fechaFinal == "" || fechaFinal == null)
            {
                WFMovimientoFecha1DateTime = Convert.ToDateTime("30/12/9999");
                fechaFinal = WFMovimientoFecha1DateTime.Year + "/" + WFMovimientoFecha1DateTime.Month + "/" + WFMovimientoFecha1DateTime.Day;
            }
            else
            {
                WFMovimientoFecha1DateTime = Convert.ToDateTime(fechaFinal + " " + "23:59:59");
                fechaFinal = WFMovimientoFecha1DateTime.Year + "/" + WFMovimientoFecha1DateTime.Month + "/" + WFMovimientoFecha1DateTime.Day;
            }
            // Remison Inicial - Final
            if (FacnReciboIni == "" || FacnReciboIni == null)
            {
                FacnReciboIni = null;
            }
            else
            {
                int redmiIni = Convert.ToInt32(FacnReciboIni);
                FacnReciboIni = Convert.ToString(redmiIni);
            }

            if (FacnReciboFin == "" || FacnReciboFin == null)
            {
                FacnReciboFin = null;
            }
            else
            {
                int redmiFin = Convert.ToInt32(FacnReciboFin);
                FacnReciboFin = Convert.ToString(redmiFin);
            }
            // factura ValorMenor - ValorMayor
            if (facValorMenor == "" || facValorMenor == null)
            {
                facValorMenor = null;
            }
            else
            {
                int Factvalormenor = Convert.ToInt32(facValorMenor);
                facValorMenor = Convert.ToString(Factvalormenor);
            }

            if (facValorMayor == "" || facValorMayor == null)
            {
                facValorMayor = null;
            }
            else
            {
                int Factvalormayor = Convert.ToInt32(facValorMayor);
                facValorMayor = Convert.ToString(Factvalormayor);
            }
            // DETALLE
            if (detalle != "" && detalle != null)
            {
                detalle = detalle;
            }
            else
            {
                detalle = null;
            }
            // Procedencia nombre NIT
            if (nombreNit != "" && nombreNit != null)
            {
                if (nombreNit.Contains(" | "))
                {
                    nombreNit = nombreNit.Remove(nombreNit.IndexOf(" | "));
                }
                else
                {
                    nombreNit = null;
                }
            }
            else
            {
                nombreNit = null;
            }
            // UNIDAD
            if (unidad != "" && unidad != null)
            {
                unidad = unidad;
            }
            else
            {
                unidad = null;
            }
            // UBICACION - CIUDAD
            if (ubicacion != "" && ubicacion != null)
            {
                if (ubicacion.Contains(" | "))
                {
                    ubicacion = ubicacion.Remove(ubicacion.IndexOf(" | "));
                }
                else
                {
                    modalidad = null;

                }
            }
            // modalidad
            if (modalidad != "" && modalidad != null)
            {
                modalidad = "%" + modalidad + "%";
            }
            else
            {
                modalidad = null;
            }
            // Expediente
            if (expediente != "" && expediente != null)
            {
                if (expediente.Contains(" | "))
                {
                    expediente = expediente.Remove(expediente.IndexOf(" | "));
                }
            }
            else
            {
                expediente = null;
            }
            // Numero Factura Inicial - Final
            if (numFacIni == "" || numFacIni == null)
            {
                numFacIni = null;
            }
            else
            {
                int NumFactIni = Convert.ToInt32(numFacIni);
                numFacIni = Convert.ToString(NumFactIni);
            }

            if (numFacFinal == "" || numFacFinal == null)
            {
                numFacFinal = null;
            }
            else
            {
                int NumFactFin = Convert.ToInt32(numFacFinal);
                numFacFinal = Convert.ToString(NumFactFin);
            }
            // Comprobantes Inicial - Final
            if (comEgresoIni == "" || comEgresoIni == null)
            {
                comEgresoIni = null;
            }
            else
            {
                int comproIni = Convert.ToInt32(comEgresoIni);
                comEgresoIni = Convert.ToString(comproIni);
            }

            if (comEgresoFin == "" || comEgresoFin == null)
            {
                comEgresoFin = null;
            }
            else
            {
                int comproFin = Convert.ToInt32(comEgresoFin);
                comEgresoFin = Convert.ToString(comproFin);
            }
            // CIUDAD INICIAL - FINAL
            if (ciudadInicial == "" || ciudadInicial == null)
            {
                ciudadInicial = null;
            }
            else
            {
                int CiytyInic = Convert.ToInt32(ciudadInicial);
                ciudadInicial = Convert.ToString(CiytyInic);
            }

            if (ciudadFinal == "" || ciudadFinal == null)
            {
                ciudadFinal = null;
            }
            else
            {
                int CiytyFin = Convert.ToInt32(ciudadFinal);
                ciudadFinal = Convert.ToString(CiytyFin);
            }

            if (strbase == "SqlServer")
            {
                DataTable dataT = AdapterFacturasConsultas.BuscarRadicados(Radicador, porImagen, radInicial, radFinal, fechaInicial, fechaFinal, FacnReciboIni, FacnReciboFin, facValorMenor, facValorMayor, detalle, nombreNit, unidad, ubicacion, modalidad, expediente, numFacIni, comEgresoIni, comEgresoFin, numFacFinal, ciudadInicial, ciudadFinal);
                if (dataT == null || dataT.Rows.Count < 1)
                {
                    return null;
                }
                else
                {


                    return AdapterFacturasConsultas.BuscarRadicados(Radicador, porImagen, radInicial, radFinal, fechaInicial, fechaFinal, FacnReciboIni, FacnReciboFin, facValorMenor, facValorMayor, detalle, nombreNit, unidad, ubicacion, modalidad, expediente, numFacIni, comEgresoIni, comEgresoFin, numFacFinal, ciudadInicial, ciudadFinal);
                }
            }
            else
            {
                //mDataTable = ObjDependencia.ReadDependenciaByText(DependenciaNombre, DependenciaHabilitar);
                ////return mDataTable;
                //DSDependenciaSQL.DependenciaByTextDataTable Datos = new DSDependenciaSQL.DependenciaByTextDataTable();

                //foreach (DataRow row in mDataTable.Rows)
                //{
                //    DSDependenciaSQL.DependenciaByTextRow Fila = Datos.NewDependenciaByTextRow();
                //    Fila.DependenciaCodigo = row.ItemArray[0].ToString();
                //    Fila.DependenciaNombre = row.ItemArray[1].ToString();
                //    Datos.Rows.Add(Fila);
                //}

                //return Datos;
                //Datos.Dispose();
                return null;
            }
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }
    /// <summary>
    /// Actualiza el campo detalle y Unidad Almacenamiento en la tabla facturas e inserta los comprobantes de egreso de un consecutivo.
    /// </summary>
    /// <param name="codigo">Consecutivo facturas</param>
    /// <param name="detalle">Detalle de tabla facturas</param>
	/// <param name="detalle">Detalle de tabla facturas</param>
    /// <param name="compEgresoList">Listado de comprobantes de egreso que serán insertados</param>
    /// <param name="config">Configuración base de datos</param>
    /// <returns>string</returns>
     public string UpdateRadicado(string codigo, string detalle, string unidadAlmac, List<string> compEgresoList)
    {
        string result = string.Empty;
        try
        {
            if (codigo == "")
            {
                return "El campo número de radicado no puede ser modificado para realizar este proceso.";
            }
            if (detalle != "" || unidadAlmac != "")
            {
                bool actualizoDetalle = UpdateDetalleRadicado(codigo, detalle, unidadAlmac);
                if (actualizoDetalle)
                {
                    result = "Detalle y Unidad de Almacenamiento actualizados correctamente. ";
                }
                else
                {
                    result = "El detalle y Unidad de Almacenamiento, no han sido actualizados. ";
                }
            }
            else
            {
                result = "El detalle y Unidad de Almacenamiento, no fueron actualizados debido a que no se puede reemplazar por valores vacíos. ";
            }
            if (compEgresoList.Count > 0)
            {
                bool inserto = InsertComprobantesEgreso(codigo, compEgresoList);
                if (inserto)
                {
                    result += "El(Los) comprobante(s) se almacenaron correctamente.";
                }
                else
                {
                    result += "Alguno(s) de los comprobantes posiblemente no pudieron ser insertados.";
                }
            }
            return "Radicado: " + codigo + ". " + result;
        }
        catch (Exception)
        {
            return "Ocurrió un problema al realizar el proceso de actualización. Por favor intente de nuevo más tarde.";
        }
    }
    /// <summary>
    /// Actualiza el campo detalle y Unidad Almacenamiento de un consecutivo en la tabla facturas
    /// </summary>
    /// <param name="codigo">Consecutivo que será actualizado en su campo detalle</param>
    /// <param name="detalle">Nuevo detalle que va a ser ingresado a la tabla facturas</param>
    /// <param name="config">Configuración del motor de base de datos</param>
    /// <returns>bool</returns>
    private bool UpdateDetalleRadicado(string codigo, string detalle, string unidadAlmac)
    {

        try
        {
            DSFacturaTableAdapters.consultas_radicacionmasiva_av2TableAdapter objadapapter = new DSFacturaTableAdapters.consultas_radicacionmasiva_av2TableAdapter();
            DSFactura.consultas_radicacionmasiva_av2DataTable tablaUpdate = new DSFactura.consultas_radicacionmasiva_av2DataTable();

            int actualizo = objadapapter.facturas_updatedetalle_av2(Convert.ToDecimal(codigo), detalle, unidadAlmac);
            if (actualizo > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
    /// <summary>
    /// Inserta los comprobantes de egreso de un consecutivo de facturas.
    /// </summary>
    /// <param name="codigo">Consecutivo de la tabla facturas que al que se le insertarán los comprobantes de egreso.</param>
    /// <param name="compEgresoList">Listado de comprobantes de egreso que se almacenarán asociados a un consecutivo de facturas</param>
    /// <param name="config">Configuración de base de datos.</param>
    /// <returns>bool</returns>
    private bool InsertComprobantesEgreso(string codigo, List<string> compEgresoList)
    {

        try
        {
            DSFacturaTableAdapters.consultas_radicacionmasiva_av2TableAdapter objadapapter = new DSFacturaTableAdapters.consultas_radicacionmasiva_av2TableAdapter();
            DSFactura.consultas_radicacionmasiva_av2DataTable tablaUpdate = new DSFactura.consultas_radicacionmasiva_av2DataTable();
            int? salida = 0;
            bool i;

            foreach (string item in compEgresoList)
            {
                objadapapter.facturas_insertcomprobante_egreso_av2(Convert.ToDecimal(codigo), item, out salida);
                if (salida == 1) { i = true; };
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

}
