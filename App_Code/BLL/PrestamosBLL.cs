using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSPrestamosTableAdapters;

/// <summary>
/// Descripción breve de Prestamos
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class PrestamosBLL
{
	public PrestamosBLL()
	{
        //
		// TODO: Agregar aquí la lógica del constructor
	    //
	}
    //Contructor PrestamosTableAdapter
    private PrestamosTableAdapter _PrestamosAdapter = null;
    protected PrestamosTableAdapter AdapterPrestamos
    {
        get
        {
            if (_PrestamosAdapter == null)
                _PrestamosAdapter = new PrestamosTableAdapter();

            return _PrestamosAdapter;
        }
    }
    // SELECT Prestamos METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSPrestamos.PrestamosDataTable GetPrestamos()
    {
        return AdapterPrestamos.GetPrestamos();
    }
    // SELECT Prestamos METHOD BY ID
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSPrestamos.PrestamosDataTable GetPrestamosById(int PrestamoCodigo)
    {
        return AdapterPrestamos.GetPrestamosById(PrestamoCodigo);
    }
    // INSERT Prestamos METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public String Create_Prestamos(String PrestamoCodigo, String GrupoCodigo, DateTime WFMovimientoFecha, String UserName, String DependenciaCodigo, String SerieCodigo, String PrestamoCarpeta, String Recibe)
    {
        try
        {
            int PrestamoCod = 0;
            if (PrestamoCodigo != null)
            {
                if (PrestamoCodigo.Contains(" | "))
                {
                    PrestamoCodigo = PrestamoCodigo.Remove(PrestamoCodigo.IndexOf(" | "));
                    PrestamoCod = Convert.ToInt32(PrestamoCodigo);
                }

            }
            else
            {
                PrestamoCod = 0;
            }
            

            if (SerieCodigo != null)
            {
                if (SerieCodigo.Contains(" | "))
                {
                    SerieCodigo = SerieCodigo.Remove(SerieCodigo.IndexOf(" | "));
                }
            }
            
            if (DependenciaCodigo != null)
            {
                if (DependenciaCodigo.Contains(" | "))
                {
                    DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                }
            }
            if(Recibe != null)
            {
                Recibe.Trim();
            }
            DSPrestamos.PrestamosDataTable DTPRestamos = new DSPrestamos.PrestamosDataTable();
            //DSPrestamosTableAdapters.PrestamosTableAdapter DSPRESTAMOS = new PrestamosTableAdapter();
            
                     int rowAfected = AdapterPrestamos.Insert(PrestamoCod, GrupoCodigo, WFMovimientoFecha, UserName, DependenciaCodigo, SerieCodigo,"1", PrestamoCarpeta, Recibe);
                           int ROW = AdapterPrestamos.FillPrestamos(DTPRestamos);
                          PrestamoCodigo =  DTPRestamos.Rows[ROW-1].ItemArray[0].ToString();
            return  PrestamoCodigo; 
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }
    // Update Prestamos METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public String Update_Prestamos(String PrestamoCodigo, String GrupoCodigo, DateTime WFMovimientoFecha, String UserName, String DependenciaCodigo, String SerieCodigo, String PrestamoCarpeta,String PrestamoEstado, String Recibe)
    {
        try
        {

            if (PrestamoCodigo != null)
            {
                if (PrestamoCodigo.Contains(" | "))
                {
                    PrestamoCodigo = PrestamoCodigo.Remove(PrestamoCodigo.IndexOf(" | "));
                }

            }
            if (DependenciaCodigo != null)
            {
                if (DependenciaCodigo.Contains(" | "))
                {
                    DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                }

            }
            if (SerieCodigo != null)
            {
                if (SerieCodigo.Contains(" | "))
                {
                    SerieCodigo = SerieCodigo.Remove(SerieCodigo.IndexOf(" | "));
                }

            }
            int PrestamoCod = 0;
            if (PrestamoCodigo != null || PrestamoCodigo != "")
            {
                if (PrestamoCodigo.Contains(" | "))
                {
                    PrestamoCodigo = PrestamoCodigo.Remove(PrestamoCodigo.IndexOf(" | "));
                    PrestamoCod = Convert.ToInt32(PrestamoCodigo);
                }
                else
                {
                    PrestamoCod = Convert.ToInt32(PrestamoCodigo);
                }

            }
            else
            {
                PrestamoCod = 0;
            }
            if(Recibe != null)
            {
                Recibe.Trim();
            }

            //if (RadicadoCodigo == "" || RadicadoCodigo == null)
            //{
            //    RadicadoCodigo = null;
            //}
            //else
            //{
            //    int RadCodIni = Convert.ToInt32(RadicadoCodigo);
            //    RadicadoCodigo = Convert.ToString(RadCodIni);
            //}       

            //int? Result = 1;
            //DSPrestamos.PrestamosDataTable DTPrestamos = new DSPrestamos.PrestamosDataTable();
            //DSPrestamos.PrestamosRow UpRwoPrestamos = DTPrestamos.NewPrestamosRow();

            //DTPrestamos = AdapterPrestamos.GetPrestamos();

            //UpRwoPrestamos.DependenciaCodigo = DependenciaCodigo;
            //UpRwoPrestamos.SerieCodigo = SerieCodigo;
            //UpRwoPrestamos.PrestamoCodigo = PrestamoCod;
            //UpRwoPrestamos.GrupoCodigo = GrupoCodigo;
            //UpRwoPrestamos.PrestamoCarpeta = PrestamoCarpeta;
            //UpRwoPrestamos.WFMovimientoFecha = WFMovimientoFecha;
            

            //DTPrestamos.AddPrestamosRow(UpRwoPrestamos);

            //DTPQR.AddPlantillaPQRRow(MedioCodigo,ExpedienteCodigo,DependenciaCodigo,WFAccionCodigo,null,null,null,null);

            int rowsAffected = AdapterPrestamos.Update(PrestamoCod, GrupoCodigo, WFMovimientoFecha, UserName, DependenciaCodigo, SerieCodigo, PrestamoCarpeta, PrestamoEstado, PrestamoCod, GrupoCodigo, Recibe);
            return PrestamoCodigo; 
            //AdapterRadicado.Radicado_CreateRadicado(GrupoCodigo, WFMovimientoFecha, RadicadoFechaProcedencia, ProcedenciaCodigo, WFProcesoCodigo, RadicadoNumeroExterno, NaturalezaCodigo, DependenciaCodigo, RadicadoDetalle, RadicadoAnexo, RadicadoFechaVencimiento, ExpedienteCodigo, MedioCodigo, DependenciaCodDestino, WFAccionCodigo, WFMovimientoPasoActual, WFMovimientoPasoFinal, RadicadoFechaVencimiento, RadicadoFechaVencimiento, WFMovimientoTipo, WFMovimientoNotas, SerieCodigo, ref  Result, WFMovimientoMultitarea);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }
    // SELECT Consultas Prestamos METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSPrestamos.PrestamosDataTable GetConsultasPrestamos(String PrestamoCodigo, String PrestamoCodigo1, String WFMovimientoFecha, String UserName, String WFMovimientoFecha1, String DependenciaCodigo, String SerieCodigo, String Recibe)
    {
        try
        {
            if (DependenciaCodigo != "" && DependenciaCodigo != null)
            {
                if (DependenciaCodigo.Contains(" | "))
                {
                    DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                }
            }
            else
            {
                DependenciaCodigo = null;
            }
            if (SerieCodigo != "" && SerieCodigo != null)
            {
                if (SerieCodigo.Contains(" | "))
                {
                    SerieCodigo = SerieCodigo.Remove(SerieCodigo.IndexOf(" | "));
                }
            }
            else
            {
                SerieCodigo = null;
            }


            if (PrestamoCodigo == "" || PrestamoCodigo == null)
            {
                PrestamoCodigo = null;
            }
            else
            {
                int RadCodIni = Convert.ToInt32(PrestamoCodigo);
                PrestamoCodigo = Convert.ToString(RadCodIni);
            }

            if (PrestamoCodigo1 == "" || PrestamoCodigo1 == null)
            {
                PrestamoCodigo1 = null;
            }
            else
            {
                int RadCodFin = Convert.ToInt32(PrestamoCodigo1);
                PrestamoCodigo1 = Convert.ToString(RadCodFin);
            }
            DateTime WFMovimientoFechaDateTime;
            if (WFMovimientoFecha == "" || WFMovimientoFecha == null)
            {

                WFMovimientoFechaDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                WFMovimientoFechaDateTime = Convert.ToDateTime(WFMovimientoFecha);
            }
            DateTime WFMovimientoFecha1DateTime;
            if (WFMovimientoFecha1 == "" || WFMovimientoFecha1 == null)
            {
                WFMovimientoFecha1DateTime = DateTime.MaxValue;
            }
            else
            {
                WFMovimientoFecha1DateTime = Convert.ToDateTime(WFMovimientoFecha1 + " " + "23:59:59");
            }
            if(Recibe != null)
            {
                Recibe.Trim();
            }
            // DSRadicado.Radicado_ConsultasRadicadoDataTable Con = new DSRadicado.Radicado_ConsultasRadicadoDataTable();
            return AdapterPrestamos.GetConsultaPrestamos(PrestamoCodigo, PrestamoCodigo1, WFMovimientoFechaDateTime, UserName, WFMovimientoFecha1DateTime, DependenciaCodigo, SerieCodigo, Recibe);
            // Con = AdapterRadicadoConsultas.GetDataConsultasRadicado(WFMovimientoFechaDateTime, WFMovimientoFecha1DateTime, RadicadoCodigo, RadicadoCodigo1, ExpedienteCodigo, ProcedenciaCodigo, MedioCodigo, DependenciaCodDestino, RadicadoDetalle, RadicadoNumeroExterno, RadicadoAnexo, NaturalezaCodigo);
            //return AdapterRadicadoConsultas.GetDataConsultasRadicado(WFMovimientoFechaDateTime, WFMovimientoFecha1DateTime, RadicadoCodigo, RadicadoCodigo1, ExpedienteCodigo, ProcedenciaCodigo, MedioCodigo, DependenciaCodDestino, RadicadoDetalle, RadicadoNumeroExterno, RadicadoAnexo, NaturalezaCodigo);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }
    // Update Prestamos METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public String Terminar_Prestamos(String PrestamoCodigo, String GrupoCodigo, DateTime WFMovimientoFechaDevolucion, String PrestamoEstado)
    {
        try
        {            
            int PrestamoCod = 0;
            if (PrestamoCodigo != null || PrestamoCodigo != "")
            {
                if (PrestamoCodigo.Contains(" | "))
                {
                    PrestamoCodigo = PrestamoCodigo.Remove(PrestamoCodigo.IndexOf(" | "));
                    PrestamoCod = Convert.ToInt32(PrestamoCodigo);
                }
                else
                {
                    PrestamoCod = Convert.ToInt32(PrestamoCodigo);
                }

            }
            else
            {
                PrestamoCod = 0;
            }
            
            int rowsAffected = AdapterPrestamos.Prestamo_TerminarPrestamo(PrestamoCod, GrupoCodigo, WFMovimientoFechaDevolucion,PrestamoEstado);
            return PrestamoCodigo;
          
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }
}
