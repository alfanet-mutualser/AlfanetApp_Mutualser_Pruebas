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
using DSRadicadoTableAdapters;
using DSGrupoSQLTableAdapters;
using System.IO;
using System.Web.Configuration;
using System.Collections;
using System.Text;
using System.DirectoryServices;


//using DS

/// <summary>
/// Descripción breve de ExpedienteBLL
/// </summary>
//

[System.ComponentModel.DataObject]
public class RadicadoBLL
{
    private Radicado_ConsultasRadicadoTableAdapter _RadicadoConsultasAdapter = null;
    protected Radicado_ConsultasRadicadoTableAdapter AdapterRadicadoConsultas
    {
       get
        {
            if (_RadicadoConsultasAdapter == null)
                _RadicadoConsultasAdapter = new Radicado_ConsultasRadicadoTableAdapter();

            return _RadicadoConsultasAdapter;
        }
    }
    private Radicado_ConsultasGestionTareasTableAdapter  _RadicadoGestionTAdapter = null;
    protected Radicado_ConsultasGestionTareasTableAdapter AdapterRadicadoGestionT
    {
        get
        {
            if (_RadicadoGestionTAdapter == null)
                _RadicadoGestionTAdapter = new Radicado_ConsultasGestionTareasTableAdapter();

            return _RadicadoGestionTAdapter;
        }
    }
    //private Radicado_ConsultasGestionTareasPruebaTableAdapter _RadicadoGestionTPruebaAdapter = null;
    //protected Radicado_ConsultasGestionTareasPruebaTableAdapter AdapterRadicadoGestionTPrueba
    //{
    //    get
    //    {
    //        if (_RadicadoGestionTPruebaAdapter == null)
    //            _RadicadoGestionTPruebaAdapter = new Radicado_ConsultasGestionTareasPruebaTableAdapter();

    //        return _RadicadoGestionTPruebaAdapter;
    //    }
    //}
    public Int32 varprueba;
    private Radicado1TableAdapter _RadicadoAdapter = null;
    protected Radicado1TableAdapter AdapterRadicado
    {
        get
        {
            if (_RadicadoAdapter == null)
                _RadicadoAdapter = new Radicado1TableAdapter();

            return _RadicadoAdapter;
        }
    }
    private GrupoTableAdapter _GrupoAdapter = null;
    protected GrupoTableAdapter AdapterGrupo
    {
        get
        {
            if (_GrupoAdapter == null)
                _GrupoAdapter = new GrupoTableAdapter();

            return _GrupoAdapter;
        }
    }
    private PlantillaPQRTableAdapter _PlantillaPQRAdapter = null;
    protected PlantillaPQRTableAdapter AdapterPlantillaPQR
    {
        get
        {
            if (_PlantillaPQRAdapter == null)
                _PlantillaPQRAdapter = new PlantillaPQRTableAdapter();

            return _PlantillaPQRAdapter;
        }
    }
    private Radicado_ReadRadTableAdapter _RadicadoReadAdapter = null;
    protected Radicado_ReadRadTableAdapter AdapterRadicadoRead
    {
        get
        {
            if (_RadicadoReadAdapter == null)
                _RadicadoReadAdapter = new Radicado_ReadRadTableAdapter();

            return _RadicadoReadAdapter;
        }
    }
    // SELECT PlantillaPQR METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSRadicado.PlantillaPQRDataTable GetPlantillaPQR()
    {
        return AdapterPlantillaPQR.GetPlantillaPQR();
    }
    // SELECT Grupo METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSGrupoSQL.GrupoDataTable GetGroupById()
    {
        return AdapterGrupo.GetGroupById("1");
    }
    // SELECT Radicado METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSRadicado.Radicado_ReadRadDataTable GetRadicadoByCodigo1(string RadicadoCodigo)
    {
        return AdapterRadicadoRead.GetRadicadoByCodigo(RadicadoCodigo);
    }
    // SELECT Radicado METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSRadicado.Radicado_ReadRadDataTable GetDataBy(string RadicadoCodigo, string GrupoRadicadoCodigo)
    {
        return AdapterRadicadoRead.GetDataBy(RadicadoCodigo, GrupoRadicadoCodigo);
    }
    // SELECT Consultas Radicado METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSRadicado.Radicado_ConsultasRadicadoDataTable GetConsultasRadicado(String WFMovimientoFecha, String WFMovimientoFecha1, String RadicadoCodigo, String RadicadoCodigo1, String ExpedienteCodigo, String ProcedenciaCodigo, String ProcedenciaNombre, String MedioCodigo, String DependenciaCodDestino, String DependenciaNomDestino, String RadicadoDetalle, String RadicadoNumeroExterno, String RadicadoAnexo, String NaturalezaCodigo, String NaturalezaNombre, String DependenciaConsulta, string RadicadoGuia)
    {
        try
        {
            if (ProcedenciaCodigo != "" && ProcedenciaCodigo != null)
            {
                if (ProcedenciaCodigo.Contains(" | "))
                {
                    ProcedenciaCodigo = ProcedenciaCodigo.Remove(ProcedenciaCodigo.IndexOf(" | "));
                    ProcedenciaNombre = null;
                }
                else
                {
                    ProcedenciaNombre = "%" + ProcedenciaNombre + "%";
                    ProcedenciaCodigo = null;
                }
            }
            else
            {
                ProcedenciaCodigo = null;
            }


            if (NaturalezaCodigo != "" && NaturalezaCodigo != null)
            {
                if (NaturalezaCodigo.Contains(" | "))
                {
                    NaturalezaCodigo = NaturalezaCodigo.Remove(NaturalezaCodigo.IndexOf(" | "));
                    NaturalezaNombre = null;
                }
                else
                {
                    NaturalezaCodigo = null;
                    NaturalezaNombre = "%" + NaturalezaNombre + "%";
                }
            }
            else
            {
                NaturalezaCodigo = null;
            }

            if ( RadicadoDetalle != "" &&  RadicadoDetalle != null)
            {
                 RadicadoDetalle = "%" +  RadicadoDetalle + "%";
            }
            else
            {
                 RadicadoDetalle = null;
            }

            if (RadicadoGuia != "" && RadicadoGuia != null)
            {
                RadicadoGuia = "%" + RadicadoGuia + "%";
            }
            else
            {
                RadicadoGuia = null;
            }

            if (ExpedienteCodigo != "" && ExpedienteCodigo != null)
            {
                if (ExpedienteCodigo.Contains(" | "))
                {
                    ExpedienteCodigo = ExpedienteCodigo.Remove(ExpedienteCodigo.IndexOf(" | "));
                }
            }
            else
            {
                ExpedienteCodigo = null;
            }
            if (MedioCodigo != "" && MedioCodigo != null)
            {
                if (MedioCodigo.Contains(" | "))
                {
                    MedioCodigo = MedioCodigo.Remove(MedioCodigo.IndexOf(" | "));
                }
            }
            else
            {
                MedioCodigo = null;
            }

            
            if (DependenciaCodDestino != "" && DependenciaCodDestino != null)
            {
                if (DependenciaCodDestino.Contains(" | "))
                {
                    DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));
                    DependenciaNomDestino = null;
                }
                else
                {
                    DependenciaNomDestino = "%" + DependenciaNomDestino + "%";
                    DependenciaCodDestino = null;
                }
            }
            else
            {
                DependenciaCodDestino = null;
            }


            if (RadicadoCodigo == "" ||RadicadoCodigo == null)
            {
                RadicadoCodigo = null;
            }
            else
            {
                int RadCodIni = Convert.ToInt32(RadicadoCodigo);
                RadicadoCodigo = Convert.ToString(RadCodIni);
            }

            if (RadicadoCodigo1 == "" || RadicadoCodigo1 == null)
            {
                RadicadoCodigo1 = null;
            }
            else
            {
                int RadCodFin = Convert.ToInt32(RadicadoCodigo1);
                RadicadoCodigo1 = Convert.ToString(RadCodFin);
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
                WFMovimientoFecha1DateTime = Convert.ToDateTime(WFMovimientoFecha1 +" "+"23:59:59");
            }
           // DSRadicado.Radicado_ConsultasRadicadoDataTable Con = new DSRadicado.Radicado_ConsultasRadicadoDataTable();
           // Con = AdapterRadicadoConsultas.GetDataConsultasRadicado(WFMovimientoFechaDateTime, WFMovimientoFecha1DateTime, RadicadoCodigo, RadicadoCodigo1, ExpedienteCodigo, ProcedenciaCodigo, MedioCodigo, DependenciaCodDestino, RadicadoDetalle, RadicadoNumeroExterno, RadicadoAnexo, NaturalezaCodigo);
            return AdapterRadicadoConsultas.GetDataConsultasRadicado(WFMovimientoFechaDateTime, WFMovimientoFecha1DateTime, RadicadoCodigo, RadicadoCodigo1, ExpedienteCodigo, ProcedenciaNombre, ProcedenciaCodigo, MedioCodigo, DependenciaCodDestino, DependenciaNomDestino, RadicadoDetalle, RadicadoNumeroExterno, RadicadoAnexo, NaturalezaCodigo, NaturalezaNombre, DependenciaConsulta, RadicadoGuia);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
       }
    // SELECT Gestion Radicado METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSRadicado.Radicado_ConsultasGestionTareasDataTable GetGTRadicado(String WFMovimientoFecha, String WFMovimientoFecha1, String WFMovimientoFechaFin, String WFMovimientoFechaFin1, String RadicadoFechaVencimiento, String RadicadoFechaVencimiento1, int WFMovimientoTipo, int WFMovimientoTipo1, String WFMovimientoPasoActual, String WFMovimientoPasoFinal, string DependenciaCodOrigen, String DependenciaCodDestino, String RadicadoCodigoFuente, String WFProcesoCodigo, String WFAccionCodigo, String SerieCodigo, String NaturalezaCodigo, String ProcedenciaCodigo, String ExpedienteCodigo)
       {
           try
           {
               if (WFMovimientoPasoActual == "")
                   WFMovimientoPasoActual = null;
               if (WFMovimientoPasoFinal == "")
                   WFMovimientoPasoFinal = null;
               if (RadicadoCodigoFuente != "" && RadicadoCodigoFuente != null)
               {
                   if (RadicadoCodigoFuente.Contains(" | "))
                   {
                       RadicadoCodigoFuente = RadicadoCodigoFuente.Remove(RadicadoCodigoFuente.IndexOf(" | "));
                   }
               }
               else
               {
                   RadicadoCodigoFuente = null;
               }
               if (WFAccionCodigo != "" && WFAccionCodigo != null)
               {
                   if (WFAccionCodigo.Contains(" | "))
                   {
                       WFAccionCodigo = WFAccionCodigo.Remove(WFAccionCodigo.IndexOf(" | "));
                   }
               }
               else
               {
                   WFAccionCodigo = null;
               }
               if (WFProcesoCodigo != "" && WFProcesoCodigo != null)
               {
                   if (WFProcesoCodigo.Contains(" | "))
                   {
                       WFProcesoCodigo = WFProcesoCodigo.Remove(WFProcesoCodigo.IndexOf(" | "));
                   }
               }
               else
               {
                   WFProcesoCodigo = null;
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
               if (NaturalezaCodigo != "" && NaturalezaCodigo != null)
               {
                   if (NaturalezaCodigo.Contains(" | "))
                   {
                       NaturalezaCodigo = NaturalezaCodigo.Remove(NaturalezaCodigo.IndexOf(" | "));
                   }
               }
               else
               {
                   NaturalezaCodigo = null;
               }
               if (DependenciaCodDestino != "" && DependenciaCodDestino != null)
               {
                   if (DependenciaCodDestino.Contains(" | "))
                   {
                       DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));
                   }
               }
               else
               {
                   DependenciaCodDestino = null;
               }
               if (DependenciaCodOrigen != "" && DependenciaCodOrigen != null)
               {
                   if (DependenciaCodOrigen.Contains(" | "))
                   {
                       DependenciaCodOrigen = DependenciaCodOrigen.Remove(DependenciaCodOrigen.IndexOf(" | "));
                   }
               }
               else
               {
                   DependenciaCodOrigen = null;
               }
               if (ProcedenciaCodigo != "" && ProcedenciaCodigo != null)
               {
                   if (ProcedenciaCodigo.Contains(" | "))
                   {
                       ProcedenciaCodigo = ProcedenciaCodigo.Remove(ProcedenciaCodigo.IndexOf(" | "));
                   }
                   else if (ProcedenciaCodigo == "")
                   {
                       ProcedenciaCodigo = null;
                   }
               }
               else
               {
                   ProcedenciaCodigo = null;
               }
               if (ExpedienteCodigo != "" && ExpedienteCodigo != null)
               {
                   if (ExpedienteCodigo.Contains(" | "))
                   {
                       ExpedienteCodigo = ExpedienteCodigo.Remove(ExpedienteCodigo.IndexOf(" | "));
                   }
                   else if (ExpedienteCodigo == "")
                   {
                       ExpedienteCodigo = null;
                   }
               }
               else
               {
                   ExpedienteCodigo = null;
               }
               DateTime WFMovimientoFechaDateTime;
               if (WFMovimientoFecha == "" || WFMovimientoFecha == null)
               {
                   //WFMovimientoFechaDateTime = null;
                   WFMovimientoFechaDateTime = Convert.ToDateTime("01/01/1753");
               }
               else
               {
                   WFMovimientoFechaDateTime = Convert.ToDateTime(WFMovimientoFecha);
               }

               DateTime WFMovimientoFecha1DateTime;
               if (WFMovimientoFecha1 == "" || WFMovimientoFecha1 == null)
               {
                   //WFMovimientoFecha1DateTime = null;
                   WFMovimientoFecha1DateTime = DateTime.MaxValue;
               }
               else
               {
                   WFMovimientoFecha1DateTime = Convert.ToDateTime(WFMovimientoFecha1 + " " + "23:59:59");
               }
               DateTime WFMovimientoFechaFinDateTime;
               if (WFMovimientoFechaFin == "" || WFMovimientoFechaFin == null)
               {
                   //WFMovimientoFechaFinDateTime = null;
                   WFMovimientoFechaFinDateTime = Convert.ToDateTime("01/01/1753");
               }
               else
               {
                   WFMovimientoFechaFinDateTime = Convert.ToDateTime(WFMovimientoFechaFin);
               }

               DateTime WFMovimientoFechaFin1DateTime;
               if (WFMovimientoFechaFin1 == "" || WFMovimientoFechaFin1 == null)
               {
                   //WFMovimientoFechaFin1DateTime = null;
                   WFMovimientoFechaFin1DateTime = DateTime.MaxValue;
               }
               else
               {
                   WFMovimientoFechaFin1DateTime = Convert.ToDateTime(WFMovimientoFechaFin1 + " " + "23:59:59");
               }

               DateTime RadicadoFechaVencimientoDateTime;
               if (RadicadoFechaVencimiento == "" || RadicadoFechaVencimiento == null)
               {
                   //RadicadoFechaVencimientoDateTime = null;
                   RadicadoFechaVencimientoDateTime = Convert.ToDateTime("01/01/1753");
               }
               else
               {
                   RadicadoFechaVencimientoDateTime = Convert.ToDateTime(RadicadoFechaVencimiento);
               }

               DateTime RadicadoFechaVencimiento1DateTime;
               if (RadicadoFechaVencimiento1 == "" || RadicadoFechaVencimiento1 == null)
               {
                   //RadicadoFechaVencimiento1DateTime = null;
                   RadicadoFechaVencimiento1DateTime = DateTime.MaxValue;
               }
               else
               {
                   RadicadoFechaVencimiento1DateTime = Convert.ToDateTime(RadicadoFechaVencimiento1 + " " + "23:59:59");
               }
               return AdapterRadicadoGestionT.GetGestionTareasPruebaBy(WFMovimientoFechaDateTime, WFMovimientoFecha1DateTime, WFMovimientoFechaFinDateTime, WFMovimientoFechaFin1DateTime, RadicadoFechaVencimientoDateTime, RadicadoFechaVencimiento1DateTime, WFMovimientoTipo, WFMovimientoTipo1, WFMovimientoPasoActual, WFMovimientoPasoFinal, DependenciaCodOrigen, DependenciaCodDestino, RadicadoCodigoFuente, WFProcesoCodigo, WFAccionCodigo, SerieCodigo, NaturalezaCodigo, ProcedenciaCodigo, ExpedienteCodigo);
               //return AdapterRadicadoGestionT.GetRecibidoGestionTareas(WFMovimientoFechaDateTime, WFMovimientoFecha1DateTime, WFMovimientoFechaFinDateTime, WFMovimientoFechaFin1DateTime, RadicadoFechaVencimientoDateTime, RadicadoFechaVencimiento1DateTime, WFMovimientoTipo, WFMovimientoTipo1, WFMovimientoPasoActual, WFMovimientoPasoFinal, DependenciaCodOrigen, DependenciaCodDestino, RadicadoCodigoFuente, WFProcesoCodigo, WFAccionCodigo, SerieCodigo, NaturalezaCodigo, ProcedenciaCodigo, ExpedienteCodigo);
                  
           }
           catch (Exception e)
           {
               throw new ApplicationException("Error en la capa BLL. " + e.Message);
           }
       }


       // SELECT Gestion Radicado v2 METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSRadicado.Radicado_ConsultasGestionTareasDataTable GetGTRadicadov2(String WFMovimientoFecha, String WFMovimientoFecha1, String WFMovimientoFechaFin, String WFMovimientoFechaFin1, String RadicadoFechaVencimiento, String RadicadoFechaVencimiento1, int WFMovimientoTipo, int WFMovimientoTipo1, String WFMovimientoPasoActual, String WFMovimientoPasoFinal, string DependenciaCodOrigen, String DependenciaCodDestino, String RadicadoCodigoFuente, String WFProcesoCodigo, String WFAccionCodigo, String SerieCodigo, String NaturalezaCodigo, String ProcedenciaCodigo, String ExpedienteCodigo, String DependenciaConsulta)
       {
           try
           {
               if (WFMovimientoPasoActual == "")
                   WFMovimientoPasoActual = null;
               if (WFMovimientoPasoFinal == "")
                   WFMovimientoPasoFinal = null;
               if (RadicadoCodigoFuente != "" && RadicadoCodigoFuente != null)
               {
                   if (RadicadoCodigoFuente.Contains(" | "))
                   {
                       RadicadoCodigoFuente = RadicadoCodigoFuente.Remove(RadicadoCodigoFuente.IndexOf(" | "));
                   }
               }
               else
               {
                   RadicadoCodigoFuente = null;
               }
               if (WFAccionCodigo != "" && WFAccionCodigo != null)
               {
                   if (WFAccionCodigo.Contains(" | "))
                   {
                       WFAccionCodigo = WFAccionCodigo.Remove(WFAccionCodigo.IndexOf(" | "));
                   }
               }
               else
               {
                   WFAccionCodigo = null;
               }
               if (WFProcesoCodigo != "" && WFProcesoCodigo != null)
               {
                   if (WFProcesoCodigo.Contains(" | "))
                   {
                       WFProcesoCodigo = WFProcesoCodigo.Remove(WFProcesoCodigo.IndexOf(" | "));
                   }
               }
               else
               {
                   WFProcesoCodigo = null;
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
               if (NaturalezaCodigo != "" && NaturalezaCodigo != null)
               {
                   if (NaturalezaCodigo.Contains(" | "))
                   {
                       NaturalezaCodigo = NaturalezaCodigo.Remove(NaturalezaCodigo.IndexOf(" | "));
                   }
               }
               else
               {
                   NaturalezaCodigo = null;
               }
               if (DependenciaCodDestino != "" && DependenciaCodDestino != null)
               {
                   if (DependenciaCodDestino.Contains(" | "))
                   {
                       DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));
                   }
               }
               else
               {
                   DependenciaCodDestino = null;
               }
               if (DependenciaCodOrigen != "" && DependenciaCodOrigen != null)
               {
                   if (DependenciaCodOrigen.Contains(" | "))
                   {
                       DependenciaCodOrigen = DependenciaCodOrigen.Remove(DependenciaCodOrigen.IndexOf(" | "));
                   }
               }
               else
               {
                   DependenciaCodOrigen = null;
               }
               if (ProcedenciaCodigo != "" && ProcedenciaCodigo != null)
               {
                   if (ProcedenciaCodigo.Contains(" | "))
                   {
                       ProcedenciaCodigo = ProcedenciaCodigo.Remove(ProcedenciaCodigo.IndexOf(" | "));
                   }
                   else if (ProcedenciaCodigo == "")
                   {
                       ProcedenciaCodigo = null;
                   }
               }
               else
               {
                   ProcedenciaCodigo = null;
               }
               if (ExpedienteCodigo != "" && ExpedienteCodigo != null)
               {
                   if (ExpedienteCodigo.Contains(" | "))
                   {
                       ExpedienteCodigo = ExpedienteCodigo.Remove(ExpedienteCodigo.IndexOf(" | "));
                   }
                   else if (ExpedienteCodigo == "")
                   {
                       ExpedienteCodigo = null;
                   }
               }
               else
               {
                   ExpedienteCodigo = null;
               }
               DateTime WFMovimientoFechaDateTime;
               if (WFMovimientoFecha == "" || WFMovimientoFecha == null)
               {
                   //WFMovimientoFechaDateTime = null;
                   WFMovimientoFechaDateTime = Convert.ToDateTime("01/01/1753");
               }
               else
               {
                   WFMovimientoFechaDateTime = Convert.ToDateTime(WFMovimientoFecha);
               }

               DateTime WFMovimientoFecha1DateTime;
               if (WFMovimientoFecha1 == "" || WFMovimientoFecha1 == null)
               {
                   //WFMovimientoFecha1DateTime = null;
                   WFMovimientoFecha1DateTime = DateTime.MaxValue;
               }
               else
               {
                   WFMovimientoFecha1DateTime = Convert.ToDateTime(WFMovimientoFecha1 + " " + "23:59:59");
               }
               DateTime WFMovimientoFechaFinDateTime;
               if (WFMovimientoFechaFin == "" || WFMovimientoFechaFin == null)
               {
                   //WFMovimientoFechaFinDateTime = null;
                   WFMovimientoFechaFinDateTime = Convert.ToDateTime("01/01/1753");
               }
               else
               {
                   WFMovimientoFechaFinDateTime = Convert.ToDateTime(WFMovimientoFechaFin);
               }

               DateTime WFMovimientoFechaFin1DateTime;
               if (WFMovimientoFechaFin1 == "" || WFMovimientoFechaFin1 == null)
               {
                   //WFMovimientoFechaFin1DateTime = null;
                   WFMovimientoFechaFin1DateTime = DateTime.MaxValue;
               }
               else
               {
                   WFMovimientoFechaFin1DateTime = Convert.ToDateTime(WFMovimientoFechaFin1 + " " + "23:59:59");
               }

               DateTime RadicadoFechaVencimientoDateTime;
               if (RadicadoFechaVencimiento == "" || RadicadoFechaVencimiento == null)
               {
                   //RadicadoFechaVencimientoDateTime = null;
                   RadicadoFechaVencimientoDateTime = Convert.ToDateTime("01/01/1753");
               }
               else
               {
                   RadicadoFechaVencimientoDateTime = Convert.ToDateTime(RadicadoFechaVencimiento);
               }

               DateTime RadicadoFechaVencimiento1DateTime;
               if (RadicadoFechaVencimiento1 == "" || RadicadoFechaVencimiento1 == null)
               {
                   //RadicadoFechaVencimiento1DateTime = null;
                   RadicadoFechaVencimiento1DateTime = DateTime.MaxValue;
               }
               else
               {
                   RadicadoFechaVencimiento1DateTime = Convert.ToDateTime(RadicadoFechaVencimiento1 + " " + "23:59:59");
               }
               return AdapterRadicadoGestionT.GetConsultasGestTareas2By(WFMovimientoFechaDateTime, WFMovimientoFecha1DateTime, WFMovimientoFechaFinDateTime, WFMovimientoFechaFin1DateTime, RadicadoFechaVencimientoDateTime, RadicadoFechaVencimiento1DateTime, WFMovimientoTipo, WFMovimientoTipo1, WFMovimientoPasoActual, WFMovimientoPasoFinal, DependenciaCodOrigen, DependenciaCodDestino, RadicadoCodigoFuente, WFProcesoCodigo, WFAccionCodigo, SerieCodigo, NaturalezaCodigo, ProcedenciaCodigo, ExpedienteCodigo,DependenciaConsulta);
               //return AdapterRadicadoGestionT.GetRecibidoGestionTareas(WFMovimientoFechaDateTime, WFMovimientoFecha1DateTime, WFMovimientoFechaFinDateTime, WFMovimientoFechaFin1DateTime, RadicadoFechaVencimientoDateTime, RadicadoFechaVencimiento1DateTime, WFMovimientoTipo, WFMovimientoTipo1, WFMovimientoPasoActual, WFMovimientoPasoFinal, DependenciaCodOrigen, DependenciaCodDestino, RadicadoCodigoFuente, WFProcesoCodigo, WFAccionCodigo, SerieCodigo, NaturalezaCodigo, ProcedenciaCodigo, ExpedienteCodigo);

           }
           catch (Exception e)
           {
               throw new ApplicationException("Error en la capa BLL. " + e.Message);
           }
       }



      // SELECT Gestion Radicado v3 METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSRadicado.Radicado_ConsultasGestionTareasDataTable GetGTRadicadov3(String WFMovimientoFecha, String WFMovimientoFecha1, String WFMovimientoFechaFin, String WFMovimientoFechaFin1, String RadicadoFechaVencimiento, String RadicadoFechaVencimiento1, int WFMovimientoTipo, int WFMovimientoTipo1, String WFMovimientoPasoActual, String WFMovimientoPasoFinal, string DependenciaCodOrigen, String DependenciaCodDestino, String RadicadoCodigoFuente, String WFProcesoCodigo, String WFAccionCodigo, String SerieCodigo, String NaturalezaCodigo, String ProcedenciaCodigo, String ExpedienteCodigo, String Detalle, String DependenciaConsulta)
    {

           try
           {
               if (WFMovimientoPasoActual == "")
                   WFMovimientoPasoActual = null;
               if (WFMovimientoPasoFinal == "")
                   WFMovimientoPasoFinal = null;
               if (RadicadoCodigoFuente != "" && RadicadoCodigoFuente != null)
               {
                   if (RadicadoCodigoFuente.Contains(" | "))
                   {
                       RadicadoCodigoFuente = RadicadoCodigoFuente.Remove(RadicadoCodigoFuente.IndexOf(" | "));
                   }
               }
               else
               {
                   RadicadoCodigoFuente = null;
               }
               if (WFAccionCodigo != "" && WFAccionCodigo != null)
               {
                   if (WFAccionCodigo.Contains(" | "))
                   {
                       WFAccionCodigo = WFAccionCodigo.Remove(WFAccionCodigo.IndexOf(" | "));
                   }
               }
               else
               {
                   WFAccionCodigo = null;
               }
               if (WFProcesoCodigo != "" && WFProcesoCodigo != null)
               {
                   if (WFProcesoCodigo.Contains(" | "))
                   {
                       WFProcesoCodigo = WFProcesoCodigo.Remove(WFProcesoCodigo.IndexOf(" | "));
                   }
               }
               else
               {
                   WFProcesoCodigo = null;
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
               if (NaturalezaCodigo != "" && NaturalezaCodigo != null)
               {
                   if (NaturalezaCodigo.Contains(" | "))
                   {
                       NaturalezaCodigo = NaturalezaCodigo.Remove(NaturalezaCodigo.IndexOf(" | "));
                   }
               }
               else
               {
                   NaturalezaCodigo = null;
               }
               if (DependenciaCodDestino != "" && DependenciaCodDestino != null)
               {
                   if (DependenciaCodDestino.Contains(" | "))
                   {
                       DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));
                   }
               }
               else
               {
                   DependenciaCodDestino = null;
               }
               if (DependenciaCodOrigen != "" && DependenciaCodOrigen != null)
               {
                   if (DependenciaCodOrigen.Contains(" | "))
                   {
                       DependenciaCodOrigen = DependenciaCodOrigen.Remove(DependenciaCodOrigen.IndexOf(" | "));
                   }
               }
               else
               {
                   DependenciaCodOrigen = null;
               }
               if (ProcedenciaCodigo != "" && ProcedenciaCodigo != null)
               {
                   if (ProcedenciaCodigo.Contains(" | "))
                   {
                       ProcedenciaCodigo = ProcedenciaCodigo.Remove(ProcedenciaCodigo.IndexOf(" | "));
                   }
                   else if (ProcedenciaCodigo == "")
                   {
                       ProcedenciaCodigo = null;
                   }
               }
               else
               {
                   ProcedenciaCodigo = null;
               }
               if (ExpedienteCodigo != "" && ExpedienteCodigo != null)
               {
                   if (ExpedienteCodigo.Contains(" | "))
                   {
                       ExpedienteCodigo = ExpedienteCodigo.Remove(ExpedienteCodigo.IndexOf(" | "));
                   }
                   else if (ExpedienteCodigo == "")
                   {
                       ExpedienteCodigo = null;
                   }
               }
               else
               {
                   ExpedienteCodigo = null;
               }
               DateTime WFMovimientoFechaDateTime;
               if (WFMovimientoFecha == "" || WFMovimientoFecha == null)
               {
                   //WFMovimientoFechaDateTime = null;
                   WFMovimientoFechaDateTime = Convert.ToDateTime("01/01/1753");
               }
               else
               {
                   WFMovimientoFechaDateTime = Convert.ToDateTime(WFMovimientoFecha);
               }

               DateTime WFMovimientoFecha1DateTime;
               if (WFMovimientoFecha1 == "" || WFMovimientoFecha1 == null)
               {
                   //WFMovimientoFecha1DateTime = null;
                   WFMovimientoFecha1DateTime = DateTime.MaxValue;
               }
               else
               {
                   WFMovimientoFecha1DateTime = Convert.ToDateTime(WFMovimientoFecha1 + " " + "23:59:59");
               }
               DateTime WFMovimientoFechaFinDateTime;
               if (WFMovimientoFechaFin == "" || WFMovimientoFechaFin == null)
               {
                   //WFMovimientoFechaFinDateTime = null;
                   WFMovimientoFechaFinDateTime = Convert.ToDateTime("01/01/1753");
               }
               else
               {
                   WFMovimientoFechaFinDateTime = Convert.ToDateTime(WFMovimientoFechaFin);
               }

               DateTime WFMovimientoFechaFin1DateTime;
               if (WFMovimientoFechaFin1 == "" || WFMovimientoFechaFin1 == null)
               {
                   //WFMovimientoFechaFin1DateTime = null;
                   WFMovimientoFechaFin1DateTime = DateTime.MaxValue;
               }
               else
               {
                   WFMovimientoFechaFin1DateTime = Convert.ToDateTime(WFMovimientoFechaFin1 + " " + "23:59:59");
               }

               DateTime RadicadoFechaVencimientoDateTime;
               if (RadicadoFechaVencimiento == "" || RadicadoFechaVencimiento == null)
               {
                   //RadicadoFechaVencimientoDateTime = null;
                   RadicadoFechaVencimientoDateTime = Convert.ToDateTime("01/01/1753");
               }
               else
               {
                   RadicadoFechaVencimientoDateTime = Convert.ToDateTime(RadicadoFechaVencimiento);
               }

               DateTime RadicadoFechaVencimiento1DateTime;
               if (RadicadoFechaVencimiento1 == "" || RadicadoFechaVencimiento1 == null)
               {
                   //RadicadoFechaVencimiento1DateTime = null;
                   RadicadoFechaVencimiento1DateTime = DateTime.MaxValue;
               }
               else
               {
                   RadicadoFechaVencimiento1DateTime = Convert.ToDateTime(RadicadoFechaVencimiento1 + " " + "23:59:59");
               }
               return AdapterRadicadoGestionT.GetConsultasGestTareas3By(WFMovimientoFechaDateTime, WFMovimientoFecha1DateTime, WFMovimientoFechaFinDateTime, WFMovimientoFechaFin1DateTime, RadicadoFechaVencimientoDateTime, RadicadoFechaVencimiento1DateTime, WFMovimientoTipo, WFMovimientoTipo1, WFMovimientoPasoActual, WFMovimientoPasoFinal, DependenciaCodOrigen, DependenciaCodDestino, RadicadoCodigoFuente, WFProcesoCodigo, WFAccionCodigo, SerieCodigo, NaturalezaCodigo, ProcedenciaCodigo, ExpedienteCodigo, Detalle, DependenciaConsulta);
               //return AdapterRadicadoGestionT.GetRecibidoGestionTareas(WFMovimientoFechaDateTime, WFMovimientoFecha1DateTime, WFMovimientoFechaFinDateTime, WFMovimientoFechaFin1DateTime, RadicadoFechaVencimientoDateTime, RadicadoFechaVencimiento1DateTime, WFMovimientoTipo, WFMovimientoTipo1, WFMovimientoPasoActual, WFMovimientoPasoFinal, DependenciaCodOrigen, DependenciaCodDestino, RadicadoCodigoFuente, WFProcesoCodigo, WFAccionCodigo, SerieCodigo, NaturalezaCodigo, ProcedenciaCodigo, ExpedienteCodigo);

           }
           catch (Exception e)
           {
               throw new ApplicationException("Error en la capa BLL. " + e.Message);
           }
       }


     // CREATE RADICADO METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert,true)]
    public string AddRadicado(String GrupoCodigo, DateTime WFMovimientoFecha, DateTime RadicadoFechaProcedencia, String ProcedenciaCodigo,String WFProcesoCodigo, String RadicadoNumeroExterno, String NaturalezaCodigo, String DependenciaCodigo, String RadicadoDetalle, String RadicadoAnexo, DateTime RadicadoFechaVencimiento, String ExpedienteCodigo, String MedioCodigo, String DependenciaCodDestino, String WFAccionCodigo,String WFMovimientoPasoActual, String WFMovimientoPasoFinal, DateTime WFMovimientoFechaEst, DateTime WFMovimientoFechaFin, int WFMovimientoTipo, String WFMovimientoNotas, String SerieCodigo, String WFMovimientoMultitarea, String NumeroGuia)  
        {
        try
        {
            GrupoCodigo = "1";

           if (WFProcesoCodigo != null)
            {
                if (WFProcesoCodigo.Contains(" | "))
                {
                    WFProcesoCodigo = WFProcesoCodigo.Remove(WFProcesoCodigo.IndexOf(" | "));
                }

            }
            if (ProcedenciaCodigo != null)
            {
                if (ProcedenciaCodigo.Contains(" | "))
                {
                    ProcedenciaCodigo = ProcedenciaCodigo.Remove(ProcedenciaCodigo.IndexOf(" | "));
                }
                else if (ProcedenciaCodigo == "")
                {
                    ProcedenciaCodigo = null;
                }
                

            }
            if (NaturalezaCodigo != null)
            {
                if (NaturalezaCodigo.Contains(" | "))
                {
                    NaturalezaCodigo = NaturalezaCodigo.Remove(NaturalezaCodigo.IndexOf(" | "));
                }
                else if (NaturalezaCodigo == "")
                {
                    NaturalezaCodigo = null;
                }

            }
            if (ExpedienteCodigo != null)
            {

                if (ExpedienteCodigo.Contains(" | "))
                {
                    ExpedienteCodigo = ExpedienteCodigo.Remove(ExpedienteCodigo.IndexOf(" | "));
                }
                else if (ExpedienteCodigo == "")
                {
                    ExpedienteCodigo = null;
                }

            }
            
            if (MedioCodigo != null)
            {
                if (MedioCodigo.Contains(" | "))
                {
                    MedioCodigo = MedioCodigo.Remove(MedioCodigo.IndexOf(" | "));
                }
                else if (MedioCodigo == "")
                {
                    MedioCodigo = null;
                }

            }
            if (WFAccionCodigo != null)
            {
                if (WFAccionCodigo.Contains(" | "))
                {
                    WFAccionCodigo = WFAccionCodigo.Remove(WFAccionCodigo.IndexOf(" | "));
                }
                else if (WFAccionCodigo == "")
                {
                    WFAccionCodigo = null;
                }

            }
            if (DependenciaCodDestino != null)
            {
                if (DependenciaCodDestino.Contains(" | "))
                {
                    DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));
                }
                else if (DependenciaCodDestino == "")
                {
                    DependenciaCodDestino = null;
                }


            }
            if (SerieCodigo != null)
            {
                if (SerieCodigo.Contains(" | "))
                {
                    SerieCodigo = SerieCodigo.Remove(SerieCodigo.IndexOf(" | "));
                }
                else if (SerieCodigo == "")
                {
                    SerieCodigo = null;
                }

            }
            if (DependenciaCodigo != null)
            {
                if (DependenciaCodigo.Contains(" | "))
                {
                    DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                }
                else if (DependenciaCodigo == "")
                {
                    DependenciaCodigo = null;
                }
            }
            ////////////////////////////////////////////////
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserId = Convert.ToString(CodigoRuta);
            ////////////////////////////////////////////////
               int? Result = 1;
               DSRadicado.Radicado1DataTable DTRadCreate = new DSRadicado.Radicado1DataTable();

               DTRadCreate = AdapterRadicado.GetRadicado_CreateRadicado(GrupoCodigo, WFMovimientoFecha, RadicadoFechaProcedencia, ProcedenciaCodigo, WFProcesoCodigo, RadicadoNumeroExterno, NaturalezaCodigo, DependenciaCodigo, RadicadoDetalle, RadicadoAnexo, RadicadoFechaVencimiento, ExpedienteCodigo, MedioCodigo, DependenciaCodDestino, WFAccionCodigo, WFMovimientoPasoActual, WFMovimientoPasoFinal, RadicadoFechaVencimiento, RadicadoFechaVencimiento, WFMovimientoTipo, WFMovimientoNotas, SerieCodigo, ref  Result, WFMovimientoMultitarea, NumeroGuia,UserId,"0");
                   //AdapterRadicado.Radicado_CreateRadicado(GrupoCodigo, WFMovimientoFecha, RadicadoFechaProcedencia, ProcedenciaCodigo, WFProcesoCodigo, RadicadoNumeroExterno, NaturalezaCodigo, DependenciaCodigo, RadicadoDetalle, RadicadoAnexo, RadicadoFechaVencimiento, ExpedienteCodigo, MedioCodigo, DependenciaCodDestino, WFAccionCodigo, WFMovimientoPasoActual, WFMovimientoPasoFinal, RadicadoFechaVencimiento, RadicadoFechaVencimiento, WFMovimientoTipo, WFMovimientoNotas, SerieCodigo, ref  Result, WFMovimientoMultitarea);
                string radicacod;   
               if (DTRadCreate.Count > 0)
               {
                   radicacod = DTRadCreate.Rows[0].ItemArray[21].ToString();
               }
               else
               {
                   radicacod = Convert.ToString(Result);
               }
               //// Return true if precesely one row was inserted, otherwise false
               
               return  radicacod; 
        }
        catch (Exception e)
        {
            // Specify file, instructions, and privelegdes
            //FileStream file = new FileStream(@"F:\FBSCGR MIGRACION ORACLE\AlfaNet\testMutual.txt", FileMode.OpenOrCreate, FileAccess.Write);

            // Create a new stream to write to the file
            StreamWriter sw = File.AppendText(@"Z:\Alfanet\AlfaNetApp\testMutual.txt");

            // Write a string to the file
            sw.WriteLine(" Source: " + e.Source + "\n Contenido: " + e.Message + " \n Datos Ingresados: " + GrupoCodigo + "|" + WFMovimientoFecha + "|" + RadicadoFechaProcedencia + "|" + ProcedenciaCodigo + "|" + WFProcesoCodigo + "|" + RadicadoNumeroExterno + "|" + NaturalezaCodigo + "|" + DependenciaCodigo + "|" + RadicadoDetalle + "|" + RadicadoAnexo + "|" + RadicadoFechaVencimiento + "|" + ExpedienteCodigo + "|" + MedioCodigo + "|" + DependenciaCodDestino + "|" + WFAccionCodigo + "|" + WFMovimientoPasoActual + "|" + WFMovimientoPasoFinal + "|" + WFMovimientoFechaEst + "|" + WFMovimientoFechaFin + "|" + WFMovimientoTipo + "|" + WFMovimientoNotas + "|" + SerieCodigo + "|" + WFMovimientoMultitarea + "|" + NumeroGuia);

            // Close StreamWriter
            sw.Close();

            // Close file
            //file.Close();

            /*
            StreamWriter t1;
            if (File.Exists(@"C:\testMutual.txt"))
            {
                t1 = File.CreateText(@"C:\testMutual.txt");
                t1.WriteLine("\n Source: "+e.Source+"\n Contenido: "+e.Message+" \n Datos Ingresados: "+GrupoCodigo+"|"+WFMovimientoFecha+"|"+ RadicadoFechaProcedencia+"|"+ ProcedenciaCodigo+"|"+ WFProcesoCodigo+"|"+ RadicadoNumeroExterno+"|"+ NaturalezaCodigo+"|"+ DependenciaCodigo+"|"+RadicadoDetalle+"|"+ RadicadoAnexo+"|"+ RadicadoFechaVencimiento+"|"+ ExpedienteCodigo+"|"+ MedioCodigo+"|"+ DependenciaCodDestino+"|"+ WFAccionCodigo+"|"+ WFMovimientoPasoActual+"|"+ WFMovimientoPasoFinal+"|"+ WFMovimientoFechaEst+"|"+ WFMovimientoFechaFin+"|"+ WFMovimientoTipo+"|"+ WFMovimientoNotas+"|"+ SerieCodigo +"|"+ WFMovimientoMultitarea+"|"+NumeroGuia);
                t1.Close();
            }*/
           
              

            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }
    
    // COPIA RADICADO METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public string CopiaRadicado(String DependenciaCodigo, DateTime RadicadoFechaVencimiento, String DependenciaCodDestino, String WFAccionCodigo, DateTime WFMovimientoFechaEst, DateTime WFMovimientoFechaFin, int WFMovimientoTipo, String WFMovimientoNotas, String SerieCodigo, String RadicadoCodigo, String Grupo, DateTime WFMovimientoFecha, String WFMovimientoMultitarea)
        {                                    
            try
            { 
                if (RadicadoCodigo != null)
                {
                    if (RadicadoCodigo.Contains(" | "))
                    {
                        RadicadoCodigo = RadicadoCodigo.Remove(RadicadoCodigo.IndexOf(" | "));
                    }
                }
                int? RadCodNull;
                RadCodNull = Convert.ToInt32(RadicadoCodigo);

                 if (WFAccionCodigo != null)
                {
                    if (WFAccionCodigo.Contains(" | "))
                    {
                        WFAccionCodigo = WFAccionCodigo.Remove(WFAccionCodigo.IndexOf(" | "));
                    }
                }
                if (SerieCodigo != null)
                {
                    if (SerieCodigo.Contains(" | "))
                    {
                        SerieCodigo = SerieCodigo.Remove(SerieCodigo.IndexOf(" | "));
                    }
                }
                if (DependenciaCodDestino != null)
                {
                    if (DependenciaCodDestino.Contains(" | "))
                    {
                        DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));
                        
                    }
                }
                if (DependenciaCodigo != null)
                {
                    if (DependenciaCodigo.Contains(" | "))
                    {
                        DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                    }
                }                                
                int Resultado = 1;

                ////////////////////////////////////////////////
                MembershipUser user = Membership.GetUser();
                Object CodigoRuta = user.ProviderUserKey;
                String UserId = Convert.ToString(CodigoRuta);
                ////////////////////////////////////////////////
                Resultado = AdapterRadicado.Radicado_CopiasRadicado(DependenciaCodigo, RadicadoFechaVencimiento, DependenciaCodDestino, WFAccionCodigo, WFMovimientoFechaEst, WFMovimientoFechaFin, WFMovimientoTipo, WFMovimientoNotas, SerieCodigo, RadCodNull, Grupo, WFMovimientoFecha, WFMovimientoMultitarea,UserId);
                //// Return true if precesely one row was inserted, otherwise false
                string radicacod = Convert.ToString(Resultado);
                return radicacod;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error en la capa BLL. " + e.Message);
            }
        }
    // COPIA TODOS RADICADO METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public string CopiaTodosRadicado(String DependenciaCodigo, DateTime RadicadoFechaVencimiento, String DependenciaCodDestino, String WFAccionCodigo, DateTime WFMovimientoFechaEst, DateTime WFMovimientoFechaFin, int WFMovimientoTipo, String WFMovimientoNotas, String SerieCodigo, String RadicadoCodigo, String Grupo, DateTime WFMovimientoFecha, String WFMovimientoMultitarea)
        {
            try
            {
                if (RadicadoCodigo != null)
                {
                    if (RadicadoCodigo.Contains(" | "))
                    {
                        RadicadoCodigo = RadicadoCodigo.Remove(RadicadoCodigo.IndexOf(" | "));
                    }
                }
                int? RadCodNull;
                RadCodNull = Convert.ToInt32(RadicadoCodigo);

                if (WFAccionCodigo != null)
                {
                    if (WFAccionCodigo.Contains(" | "))
                    {
                        WFAccionCodigo = WFAccionCodigo.Remove(WFAccionCodigo.IndexOf(" | "));
                    }
                }
                if (SerieCodigo != null)
                {
                    if (SerieCodigo.Contains(" | "))
                    {
                        SerieCodigo = SerieCodigo.Remove(SerieCodigo.IndexOf(" | "));
                    }
                }
                if (DependenciaCodDestino != null)
                {
                    if (DependenciaCodDestino.Contains(" | "))
                    {
                        DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));

                    }
                }
                if (DependenciaCodigo != null)
                {
                    if (DependenciaCodigo.Contains(" | "))
                    {
                        DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                    }
                }
                int Resultado = 1;
                ////////////////////////////////////////////////
                MembershipUser user = Membership.GetUser();
                Object CodigoRuta = user.ProviderUserKey;
                String UserId = Convert.ToString(CodigoRuta);
                ////////////////////////////////////////////////
                Resultado = AdapterRadicado.Radicado_CopiasTodosRadicado(DependenciaCodigo, RadicadoFechaVencimiento, DependenciaCodDestino, WFAccionCodigo, WFMovimientoFechaEst, WFMovimientoFechaFin, WFMovimientoTipo, WFMovimientoNotas, SerieCodigo, RadCodNull, Grupo, WFMovimientoFecha, WFMovimientoMultitarea,UserId);
                //// Return true if precesely one row was inserted, otherwise false
                string radicacod = Convert.ToString(Resultado);
                return radicacod;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error en la capa BLL. " + e.Message);
            }
        }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public void UpdateRadicado(String RadicadoCodigo, String GrupoCodigo, DateTime WFMovimientoFecha, DateTime RadicadoFechaProcedencia, String ProcedenciaCodigo, String RadicadoNumeroExterno, String NaturalezaCodigo, String DependenciaCodigo, String RadicadoDetalle, String RadicadoAnexo, DateTime RadicadoFechaVencimiento, String ExpedienteCodigo, String MedioCodigo, String DependenciaCodDestino, String Original_RadicadoCodigo, String Original_GrupoCodigo, String NumeroGuia)
    {
        try
        {
            DSRadicado.Radicado_ReadRadDataTable UpRadicado = new DSRadicado.Radicado_ReadRadDataTable();
            DSRadicado.Radicado_ReadRadRow UpRowRadicado =  UpRadicado.NewRadicado_ReadRadRow();
           
            if (ProcedenciaCodigo != null)
            {
                if (ProcedenciaCodigo.Contains(" | "))
                {
                    ProcedenciaCodigo = ProcedenciaCodigo.Remove(ProcedenciaCodigo.IndexOf(" | "));
                }

            }
            if (NaturalezaCodigo != null)
            {
                if (NaturalezaCodigo.Contains(" | "))
                {
                    NaturalezaCodigo = NaturalezaCodigo.Remove(NaturalezaCodigo.IndexOf(" | "));
                }

            }
            if (ExpedienteCodigo != null)
            {
                if (ExpedienteCodigo.Contains(" | "))
                {
                    ExpedienteCodigo = ExpedienteCodigo.Remove(ExpedienteCodigo.IndexOf(" | "));
                }

            }
            if (MedioCodigo != null)
            {
                if (MedioCodigo.Contains(" | "))
                {
                    MedioCodigo = MedioCodigo.Remove(MedioCodigo.IndexOf(" | "));
                }

            }
            if (RadicadoCodigo != null)
            {
                if (RadicadoCodigo.Contains(" | "))
                {
                    RadicadoCodigo = RadicadoCodigo.Remove(RadicadoCodigo.IndexOf(" | "));
                }

            }
            if (Original_RadicadoCodigo != null)
            {
                if (Original_RadicadoCodigo.Contains(" | "))
                {
                    Original_RadicadoCodigo = Original_RadicadoCodigo.Remove(Original_RadicadoCodigo.IndexOf(" | "));
                }

            }
            ////////////////////////////////////////////////
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserIdAud = Convert.ToString(CodigoRuta);
            ////////////////////////////////////////////////            
            int Resultupdate;
            Resultupdate = AdapterRadicadoRead.Radicado_UpdateRadicado(RadicadoCodigo,GrupoCodigo,WFMovimientoFecha,RadicadoFechaProcedencia,ProcedenciaCodigo,RadicadoNumeroExterno,NaturalezaCodigo,DependenciaCodigo,RadicadoDetalle,RadicadoAnexo,RadicadoFechaVencimiento,ExpedienteCodigo,MedioCodigo,DependenciaCodDestino,Original_RadicadoCodigo,Original_GrupoCodigo, NumeroGuia,UserIdAud);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }
    private string CStr(DataRow dataRow)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    internal System.Collections.Generic.IEnumerable<DataRow> GetRadicadoByCodigo(string prefixText)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    // Update PlantillaPQR METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public void Update_Plantilla (String DependenciaCodigo, String ExpedienteCodigo, String MedioCodigo, String WFAccionCodigo)
    {
        try
        {
           
            if (ExpedienteCodigo != null)
            {
                if (ExpedienteCodigo.Contains(" | "))
                {
                    ExpedienteCodigo = ExpedienteCodigo.Remove(ExpedienteCodigo.IndexOf(" | "));
                }

            }
            if (MedioCodigo != null)
            {
                if (MedioCodigo.Contains(" | "))
                {
                    MedioCodigo = MedioCodigo.Remove(MedioCodigo.IndexOf(" | "));
                }

            }
            if (WFAccionCodigo != null)
            {
                if (WFAccionCodigo.Contains(" | "))
                {
                    WFAccionCodigo = WFAccionCodigo.Remove(WFAccionCodigo.IndexOf(" | "));
                }

            }
            if (DependenciaCodigo != null)
            {
                if (DependenciaCodigo.Contains(" | "))
                {
                    DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                }
            }

            //int? Result = 1;
            DSRadicado.PlantillaPQRDataTable DTPQR = new DSRadicado.PlantillaPQRDataTable();
             DSRadicado.PlantillaPQRRow UpRowPQR = DTPQR.NewPlantillaPQRRow();
             DTPQR = AdapterPlantillaPQR.GetPlantillaPQR();
             
             UpRowPQR.AccionCodigo = WFAccionCodigo;
             UpRowPQR.DependenciaCodigo = DependenciaCodigo;
             UpRowPQR.ExpedienteCodigo = ExpedienteCodigo;
             UpRowPQR.MedioCodigo = MedioCodigo;

             //DTPQR.AddPlantillaPQRRow(MedioCodigo,ExpedienteCodigo,DependenciaCodigo,WFAccionCodigo,null,null,null,null);

             int rowsAffected = AdapterPlantillaPQR.Update(MedioCodigo, ExpedienteCodigo, DependenciaCodigo, WFAccionCodigo, DTPQR.Rows[0].ItemArray[0].ToString(), DTPQR.Rows[0].ItemArray[1].ToString(), DTPQR.Rows[0].ItemArray[2].ToString(), DTPQR.Rows[0].ItemArray[3].ToString());
            //AdapterRadicado.Radicado_CreateRadicado(GrupoCodigo, WFMovimientoFecha, RadicadoFechaProcedencia, ProcedenciaCodigo, WFProcesoCodigo, RadicadoNumeroExterno, NaturalezaCodigo, DependenciaCodigo, RadicadoDetalle, RadicadoAnexo, RadicadoFechaVencimiento, ExpedienteCodigo, MedioCodigo, DependenciaCodDestino, WFAccionCodigo, WFMovimientoPasoActual, WFMovimientoPasoFinal, RadicadoFechaVencimiento, RadicadoFechaVencimiento, WFMovimientoTipo, WFMovimientoNotas, SerieCodigo, ref  Result, WFMovimientoMultitarea);

            //// Return true if precesely one row was inserted, otherwise false
           // string radicacod = Convert.ToString(Result);
            //return radicacod;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }
    public void Create_Plantilla(String DependenciaCodigo, String ExpedienteCodigo, String MedioCodigo, String WFAccionCodigo)
    {
        try
        {

            if (ExpedienteCodigo != null)
            {
                if (ExpedienteCodigo.Contains(" | "))
                {
                    ExpedienteCodigo = ExpedienteCodigo.Remove(ExpedienteCodigo.IndexOf(" | "));
                }

            }
            if (MedioCodigo != null)
            {
                if (MedioCodigo.Contains(" | "))
                {
                    MedioCodigo = MedioCodigo.Remove(MedioCodigo.IndexOf(" | "));
                }

            }
            if (WFAccionCodigo != null)
            {
                if (WFAccionCodigo.Contains(" | "))
                {
                    WFAccionCodigo = WFAccionCodigo.Remove(WFAccionCodigo.IndexOf(" | "));
                }

            }
            if (DependenciaCodigo != null)
            {
                if (DependenciaCodigo.Contains(" | "))
                {
                    DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                }
            }

            //int? Result = 1;
            //DSRadicado.PlantillaPQRDataTable DTPQR = new DSRadicado.PlantillaPQRDataTable();
            //DSRadicado.PlantillaPQRRow UpRowPQR = DTPQR.NewPlantillaPQRRow();
            //DTPQR = AdapterPlantillaPQR.GetPlantillaPQR();

            //UpRowPQR.AccionCodigo = WFAccionCodigo;
            //UpRowPQR.DependenciaCodigo = DependenciaCodigo;
            //UpRowPQR.ExpedienteCodigo = ExpedienteCodigo;
            //UpRowPQR.MedioCodigo = MedioCodigo;

            //DTPQR.AddPlantillaPQRRow(UpRowPQR);
            //DTPQR.AddPlantillaPQRRow(MedioCodigo,ExpedienteCodigo,DependenciaCodigo,WFAccionCodigo,null,null,null,null);
            //int rowsAffected = AdapterPlantillaPQR.Update(UpRowPQR);
            int rowsAffected = AdapterPlantillaPQR.Insert(MedioCodigo, ExpedienteCodigo, DependenciaCodigo, WFAccionCodigo);
            //AdapterRadicado.Radicado_CreateRadicado(GrupoCodigo, WFMovimientoFecha, RadicadoFechaProcedencia, ProcedenciaCodigo, WFProcesoCodigo, RadicadoNumeroExterno, NaturalezaCodigo, DependenciaCodigo, RadicadoDetalle, RadicadoAnexo, RadicadoFechaVencimiento, ExpedienteCodigo, MedioCodigo, DependenciaCodDestino, WFAccionCodigo, WFMovimientoPasoActual, WFMovimientoPasoFinal, RadicadoFechaVencimiento, RadicadoFechaVencimiento, WFMovimientoTipo, WFMovimientoNotas, SerieCodigo, ref  Result, WFMovimientoMultitarea);

            //// Return true if precesely one row was inserted, otherwise false
            // string radicacod = Convert.ToString(Result);
            //return radicacod;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }

}
