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
//using DS

/// <summary>
/// Descripción breve de ExpedienteBLL
/// </summary>
//

[System.ComponentModel.DataObject]
public class RegistroBLL
{
    private Registro_ConsultasRegistroTableAdapter _RegistroConsultasAdapter = null;
    protected Registro_ConsultasRegistroTableAdapter AdapterRegistroConsultas
    {
        get
        {
            if (_RegistroConsultasAdapter == null)
                _RegistroConsultasAdapter = new Registro_ConsultasRegistroTableAdapter();

            return _RegistroConsultasAdapter;
        }
    }

    public Int32 varprueba;

    private Registro_CreateRegistroTableAdapter _RegistroAdapter = null;
    protected Registro_CreateRegistroTableAdapter AdapterRegistro
    {
        get
        {
            if (_RegistroAdapter == null)
                _RegistroAdapter = new Registro_CreateRegistroTableAdapter();

            return _RegistroAdapter;
        }
    }
    
    private Registro_ReadRegistroTableAdapter _RegistroReadAdapter = null;
    protected Registro_ReadRegistroTableAdapter AdapterRegistroRead
    {
        get
        {
            if (_RegistroReadAdapter == null)
                _RegistroReadAdapter = new Registro_ReadRegistroTableAdapter();

            return _RegistroReadAdapter;
        }
    }
    private Registro_ReadRegTableAdapter _RegistroReadRegAdapter = null;
    protected Registro_ReadRegTableAdapter AdapterRegistroReadReg
    {
        get
        {
            if (_RegistroReadRegAdapter == null)
                _RegistroReadRegAdapter = new Registro_ReadRegTableAdapter();

            return _RegistroReadRegAdapter;
        }
    }   
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSRegistro.Registro_ReadRegDataTable GetRegistroCodigoByCodigo(String Grupo, string RegistroCodigo)
    {
        return AdapterRegistroReadReg.GetData(Grupo, RegistroCodigo);
        
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSRegistro.Registro_ReadRegistroDataTable GetRegistroById(String Grupo, string RegistroCodigo)
    {
        return AdapterRegistroRead.GetRegistroById(Grupo, RegistroCodigo);
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DSRegistro.Registro_ConsultasRegistroDataTable GetConsultasRegistro(String RegistroTipo, String WFMovimientoFecha, String WFMovimientoFecha1, String RegistroCodigo, String RegistroCodigo1, String RadicadoCodigo, String ExpedienteCodigo, String ProcedenciaCodigo, String MedioCodigo, String DependenciaCodDestino, String RegistroDetalle, String AnexoExtRegistro, String NaturalezaCodigo, String NaturalezaNombre, String DependenciaCodigo, String SerieCodigo, String RemiteNombre, String DestinoNombre, String DependenciaConsulta, string RegistroGuia)
    {
        try
        {
            if (RegistroTipo == "")
            {
                RegistroTipo = null;
            }

            if (ProcedenciaCodigo != "" && ProcedenciaCodigo != null)
            {
                if (ProcedenciaCodigo.Contains(" | "))
                {
                    ProcedenciaCodigo = ProcedenciaCodigo.Remove(ProcedenciaCodigo.IndexOf(" | "));
                    DestinoNombre = null;
                }
                else
                {
                    ProcedenciaCodigo = null;
                    DestinoNombre = "%" + DestinoNombre + "%";
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

            
            if (RegistroDetalle != "" && RegistroDetalle != null)
            {
                RegistroDetalle = "%" + RegistroDetalle + "%";
             }
             else
            {
                RegistroDetalle = null;
            }

            if (RegistroGuia != "" && RegistroGuia != null)
            {
                RegistroGuia = "%" + RegistroGuia + "%";
            }
            else
            {
                RegistroGuia = null;
            }

            if (AnexoExtRegistro != "" && AnexoExtRegistro != null)
            {
                AnexoExtRegistro = "%" + AnexoExtRegistro + "%";
            }
            else
            {
                AnexoExtRegistro = null;
            }
   
            if (DependenciaCodDestino != "" && DependenciaCodDestino != null)
            {
                if (DependenciaCodDestino.Contains(" | "))
                {
                    DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));
                    DestinoNombre = null;
                }
                else
                {
                    DestinoNombre = "%" + DestinoNombre + "%";
                    DependenciaCodDestino = null;
                }
            }
            else
            {
                DependenciaCodDestino = null;
            }




            if (DependenciaCodigo != "" && DependenciaCodigo != null)
            {
                if (DependenciaCodigo.Contains(" | "))
                {
                    DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                    RemiteNombre = null;
                }
                else
                {
                    RemiteNombre= "%" + RemiteNombre + "%";
                    DependenciaCodigo = null;
                }
            }
            else
            {
                DependenciaCodigo = null;
            }



            if (RegistroCodigo == "" || RegistroCodigo == null)
            {
                RegistroCodigo = null;
            }
            else
            {
                int RegCodIni = Convert.ToInt32(RegistroCodigo);
                RegistroCodigo = Convert.ToString(RegCodIni);
            }

            if (RegistroCodigo1 == "" || RegistroCodigo1 == null)
            {
                RegistroCodigo1 = null;
            }
            else
            {
                int RegCodFin = Convert.ToInt32(RegistroCodigo1);
                RegistroCodigo1 = Convert.ToString(RegCodFin);
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
            return AdapterRegistroConsultas.GetConsultasRegistroData(RegistroTipo, WFMovimientoFechaDateTime, WFMovimientoFecha1DateTime, RegistroCodigo, RegistroCodigo1, RadicadoCodigo, ExpedienteCodigo, ProcedenciaCodigo, MedioCodigo, DependenciaCodigo, RemiteNombre, DependenciaCodDestino, DestinoNombre, RegistroDetalle, AnexoExtRegistro, NaturalezaCodigo, NaturalezaNombre, SerieCodigo, DependenciaConsulta, RegistroGuia);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }

    // CREATE Registro METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert,true)]

    public string AddRegistro(String GrupoCodigo, DateTime WFMovimientoFecha, String ProcedenciaCodDestino, String DependenciaCodDestino, String DependenciaCodigo, String NaturalezaCodigo, int RadicadoCodigo, String RegistroDetalle, String RegistroGuia,String RegPesoEnvio, String RegistroEmpGuia, String AnexoExtRegistro, String LogDigitador, String ExpedienteCodigo, String MedioCodigo, String SerieCodigo, String RegValorEnvio, String RegistroTipo, String WFAccionCodigo, DateTime WFMovimientoFechaEst, DateTime WFMovimientoFechaFin, int WFMovimientoTipo, String WFMovimientoNotas, String WFMovimientoMultitarea)  
        {
        try
        {
            DSRegistro.Registro_CreateRegistroDataTable Registros = new DSRegistro.Registro_CreateRegistroDataTable();
            DSRegistro.Registro_CreateRegistroRow Registro = Registros.NewRegistro_CreateRegistroRow();

            if (DependenciaCodigo != null)
            {
                if (DependenciaCodigo.Contains(" | "))
                {
                    DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                }

            }
            if (DependenciaCodDestino != null)
            {
                if (DependenciaCodDestino.Contains(" | "))
                {
                    DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));
                }

            }
            if (ProcedenciaCodDestino != null)
            {
                if (ProcedenciaCodDestino.Contains(" | "))
                {
                    ProcedenciaCodDestino = ProcedenciaCodDestino.Remove(ProcedenciaCodDestino.IndexOf(" | "));
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
            //RadicadoCodigo = null;
            //{
            //    if (RadicadoCodigo.Contains(" | "))
            //    {
            //        RadicadoCodigo = RadicadoCodigo.Remove(RadCodString.IndexOf(" | "));
            //    }
            //}

            //   Radicado.GrupoCodigo =  GrupoCodigo;
            //   Radicado.WFMovimientoFecha = WFMovimientoFecha;
            //   Radicado.RadicadoFechaProcedencia = RadicadoFechaProcedencia;
            //   Radicado.ProcedenciaCodigo = ProcedenciaCodigo;
            //   Radicado.RadicadoNumeroExterno = RadicadoNumeroExterno;
            //   Radicado.NaturalezaCodigo = NaturalezaCodigo;
            //   //Radicado.DependenciaCodigo = DependenciaCodigo;
            //   Radicado.RadicadoDetalle = RadicadoDetalle;
            //   Radicado.RadicadoFechaVencimiento= RadicadoFechaVencimiento; 
            //   Radicado.ExpedienteCodigo = ExpedienteCodigo;
            //   Radicado.MedioCodigo = MedioCodigo;
            //   Radicado.DependenciaCodigo = DependenciaCodigo;
            ////*****************Falta la seleccion de dependencia este parametro depende de la estructura de proceso*******
            //   Radicado.DependenciaCodDestino = DependenciaCodDestino;
            //   Radicado.WFAccionCodigo = WFAccionCodigo;
            //   Radicado.WFMovimientoFechaEst = WFMovimientoFechaEst;
            //   Radicado.WFMovimientoFechaFin = WFMovimientoFechaFin;
            //   Radicado.WFMovimientoTipo = WFMovimientoTipo;
            //   Radicado.WFMovimientoNotas = WFMovimientoNotas;
            //   //*****************Falta la seleccion de Serie este parametro depende de la estructura de proceso*******
            //   Radicado.SerieCodigo = SerieCodigo;
            //   Radicado.WFMovimientoMultitarea = WFMovimientoMultitarea;
            //   Radicados.AddRadicado1Row(Radicado);

            ////////////////////////////////////////////////
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserId = Convert.ToString(CodigoRuta);
            ////////////////////////////////////////////////
              int? Result = 1;
              Object ObjRptaAddReg;
              ObjRptaAddReg = AdapterRegistro.Registro_CreateRegistro(ref  Result, GrupoCodigo, WFMovimientoFecha, ProcedenciaCodDestino, DependenciaCodDestino, DependenciaCodigo, NaturalezaCodigo, RadicadoCodigo, RegistroDetalle, RegistroGuia, RegistroEmpGuia, AnexoExtRegistro, LogDigitador, ExpedienteCodigo, MedioCodigo, SerieCodigo, RegPesoEnvio, RegValorEnvio, RegistroTipo, WFAccionCodigo, WFMovimientoFechaEst, WFMovimientoFechaFin, WFMovimientoTipo, WFMovimientoNotas, WFMovimientoMultitarea,UserId);
            string regiscod;
            if (ObjRptaAddReg == null)
            {
                String RptaAddReg = Convert.ToString(ObjRptaAddReg);
                regiscod = Convert.ToString(Result);
            }
            else
            {
                //throw new Exception(" Ocurrio un Error al crear el registro debe verificar que los parametros sean validos");
                regiscod = "Error al crear registro. Verifique que los parametros sean validos";
            }
            //AdapterRadicado.Radicado_CreateRadicado1(Radicados,GrupoCodigo, WFMovimientoFecha, RadicadoFechaProcedencia, ProcedenciaCodigo, RadicadoNumeroExterno, NaturalezaCodigo, DependenciaCodigo, RadicadoDetalle, RadicadoFechaVencimiento, ExpedienteCodigo, MedioCodigo, DependenciaCodDestino, WFAccionCodigo, RadicadoFechaVencimiento, RadicadoFechaVencimiento, WFMovimientoTipo, WFMovimientoNotas, SerieCodigo,ref  Result, WFMovimientoMultitarea);
                 
               //// Return true if precesely one row was inserted, otherwise false
                
               //varprueba = Convert.ToInt32(Result);
            //int rowsAffected = AdapterRadicado.Update(Radicados);
               return  regiscod; 
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
}

    // CREATE Registro BDU METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]

    public string AddRegistroBDU(String GrupoCodigo, DateTime WFMovimientoFecha, String ProcedenciaCodDestino, String DependenciaCodDestino, String DependenciaCodigo,
                              String NaturalezaCodigo, int RadicadoCodigo, String RegistroDetalle, String RegistroGuia, String RegPesoEnvio, String RegistroEmpGuia,
                              String AnexoExtRegistro, String LogDigitador, String ExpedienteCodigo, String MedioCodigo, String SerieCodigo, String RegValorEnvio,
                              String RegistroTipo, String WFAccionCodigo, DateTime WFMovimientoFechaEst, DateTime WFMovimientoFechaFin, int WFMovimientoTipo,
                              String WFMovimientoNotas, String WFMovimientoMultitarea)
    {
        try
        {
            DSRegistro.Registro_CreateRegistroDataTable Registros = new DSRegistro.Registro_CreateRegistroDataTable();
            DSRegistro.Registro_CreateRegistroRow Registro = Registros.NewRegistro_CreateRegistroRow();

            if (DependenciaCodigo != null)
            {
                if (DependenciaCodigo.Contains(" | "))
                {
                    DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                }

            }
            if (DependenciaCodDestino != null)
            {
                if (DependenciaCodDestino.Contains(" | "))
                {
                    DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));
                }

            }
            if (ProcedenciaCodDestino != null)
            {
                if (ProcedenciaCodDestino.Contains(" | "))
                {
                    ProcedenciaCodDestino = ProcedenciaCodDestino.Remove(ProcedenciaCodDestino.IndexOf(" | "));
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

            String UserId;
            MembershipUser user = Membership.GetUser();
            if (user != null)
            {
                Object CodigoRuta = user.ProviderUserKey;
                UserId = Convert.ToString(CodigoRuta);
            }
            else
            {
                UserId = LogDigitador;
                LogDigitador = "TLINEA";
            }

            int? Result = 1;
            Object ObjRptaAddReg = null;
            DSRegistro.Registro_CreateRegistroDataTable DTCREREG = new DSRegistro.Registro_CreateRegistroDataTable();
            DTCREREG = AdapterRegistro.GetCreateRegistroBdu(ref  Result, GrupoCodigo, WFMovimientoFecha, ProcedenciaCodDestino, DependenciaCodDestino,
                                                                  DependenciaCodigo, NaturalezaCodigo, RadicadoCodigo, RegistroDetalle, RegistroGuia,
                                                                  RegistroEmpGuia, AnexoExtRegistro, LogDigitador, ExpedienteCodigo, MedioCodigo, SerieCodigo,
                                                                  RegPesoEnvio, RegValorEnvio, RegistroTipo, WFAccionCodigo, WFMovimientoFechaEst,
                                                                  WFMovimientoFechaFin, WFMovimientoTipo, WFMovimientoNotas, WFMovimientoMultitarea, UserId);


            string regiscod;
            if (DTCREREG.Count == 0)
            {
                String RptaAddReg = Convert.ToString(ObjRptaAddReg);
                regiscod = Convert.ToString(Result);
            }
            else
            {
                string coderror = DTCREREG[0].ErrorMessage;
                regiscod = "Error al crear registro. Verifique que los parametros sean validos" + coderror;
            }
            return regiscod;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
        }

        // Copias Registro METHOD
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]

    public string CopiasRegistro(String DependenciaCodigo, DateTime RadicadoFechaVencimiento, String DependenciaCodDestino, String ProcedenciaCodDestino, String WFAccionCodigo, DateTime WFMovimientoFechaEst, DateTime WFMovimientoFechaFin, int WFMovimientoTipo, String WFMovimientoNotas, String SerieCodigo, String RegistroCodigo, String Grupo, DateTime WFMovimientoFecha, String WFMovimientoMultitarea)
        {
            try
            {
               if (DependenciaCodDestino != null)
                {
                    if (DependenciaCodDestino.Contains(" | "))
                    {
                        DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));
                    }

                }
                if (ProcedenciaCodDestino != null)
                {
                    if (ProcedenciaCodDestino.Contains(" | "))
                    {
                        ProcedenciaCodDestino = ProcedenciaCodDestino.Remove(ProcedenciaCodDestino.IndexOf(" | "));
                    }

                }
                if (RegistroCodigo != null)
                {
                    if (RegistroCodigo.Contains(" | "))
                    {
                        RegistroCodigo = RegistroCodigo.Remove(RegistroCodigo.IndexOf(" | "));
                    }
                }
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
                if (DependenciaCodigo != null)
                {
                    if (DependenciaCodigo.Contains(" | "))
                    {
                        DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                    }
                } 
                int? RegCodNull;
                RegCodNull = Convert.ToInt32(RegistroCodigo);

                ////////////////////////////////////////////////
                MembershipUser user = Membership.GetUser();
                Object CodigoRuta = user.ProviderUserKey;
                String UserId = Convert.ToString(CodigoRuta);
                ////////////////////////////////////////////////

                AdapterRegistro.Registro_CopiasRegistro(RegCodNull, Grupo, WFMovimientoFecha, ProcedenciaCodDestino, DependenciaCodDestino, DependenciaCodigo, SerieCodigo, WFAccionCodigo, WFMovimientoFechaEst, WFMovimientoFechaFin, WFMovimientoTipo, WFMovimientoNotas, WFMovimientoMultitarea,UserId);
                //AdapterRegistro.Registro_CreateRegistro(ref  Result, GrupoCodigo, WFMovimientoFecha, ProcedenciaCodDestino, DependenciaCodDestino, DependenciaCodigo, NaturalezaCodigo, RadicadoCodigo, RegistroDetalle, RegistroGuia, RegistroEmpGuia, AnexoExtRegistro, LogDigitador, ExpedienteCodigo, MedioCodigo, SerieCodigo, RegPesoEnvio, RegValorEnvio, RegistroTipo, WFAccionCodigo, WFMovimientoFechaEst, WFMovimientoFechaFin, WFMovimientoTipo, WFMovimientoNotas, WFMovimientoMultitarea);
                //// Return true if precesely one row was inserted, otherwise false
                string regiscod = Convert.ToString(RegCodNull);
                return regiscod;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error en la capa BLL. " + e.Message);
            }
        }
        // COPIA TODOS Registro METHOD
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public string CopiaTodosRegistro(String DependenciaCodigo, String DependenciaCodDestino, String WFAccionCodigo, DateTime WFMovimientoFechaEst, DateTime WFMovimientoFechaFin, int WFMovimientoTipo, String WFMovimientoNotas, String SerieCodigo, String RegistroCodigo, String Grupo, DateTime WFMovimientoFecha, String WFMovimientoMultitarea)
        {
            try
            {
                if (RegistroCodigo != null)
                {
                    if (RegistroCodigo.Contains(" | "))
                    {
                        RegistroCodigo = RegistroCodigo.Remove(RegistroCodigo.IndexOf(" | "));
                    }
                }
                int? RegCodNull;
                RegCodNull = Convert.ToInt32(RegistroCodigo);

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
                Resultado = AdapterRegistro.Registro_CopiasTodosRegistro(DependenciaCodigo, DependenciaCodDestino, WFAccionCodigo, WFMovimientoFechaEst, WFMovimientoFechaFin, WFMovimientoTipo, WFMovimientoNotas, SerieCodigo, RegCodNull, Grupo, WFMovimientoFecha, WFMovimientoMultitarea, UserId);
                //// Return true if precesely one row was inserted, otherwise false
                string radicacod = Convert.ToString(Resultado);
                return radicacod;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error en la capa BLL. " + e.Message);
            }
        }
    // Update Registro METHOD
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public void UpdateRegistro(String RegistroCodigo, DateTime WFMovimientoFecha, String ProcedenciaCodDestino, String DependenciaCodDestino, String DependenciaCodigo, String NaturalezaCodigo, int RadicadoCodigo, String RegistroDetalle, String RegistroGuia, String RegPesoEnvio, String RegistroEmpGuia, String AnexoExtRegistro, String LogDigitador, String ExpedienteCodigo, String MedioCodigo, String SerieCodigo, String RegValorEnvio, String RegistroTipo, String Original_RegistroCodigo, String Original_GrupoCodigo, String GrupoCodigo, String CodigoMotDevolucion,String FechaDevolucion, String FechaActDevolucion)
    {
        try
        {
            DSRegistro.Registro_ReadRegistroDataTable UpRegistro = new DSRegistro.Registro_ReadRegistroDataTable();
            DSRegistro.Registro_ReadRegistroRow UpRowRegistro = UpRegistro.NewRegistro_ReadRegistroRow();


            if (DependenciaCodigo != null)
            {
                if (DependenciaCodigo.Contains(" | "))
                {
                    DependenciaCodigo = DependenciaCodigo.Remove(DependenciaCodigo.IndexOf(" | "));
                }

            }
            if (DependenciaCodDestino != null)
            {
                if (DependenciaCodDestino.Contains(" | "))
                {
                    DependenciaCodDestino = DependenciaCodDestino.Remove(DependenciaCodDestino.IndexOf(" | "));
                }

            }
            if (ProcedenciaCodDestino != null)
            {
                if (ProcedenciaCodDestino.Contains(" | "))
                {
                    ProcedenciaCodDestino = ProcedenciaCodDestino.Remove(ProcedenciaCodDestino.IndexOf(" | "));
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
            if (SerieCodigo != null)
            {
                if (SerieCodigo.Contains(" | "))
                {
                    SerieCodigo = SerieCodigo.Remove(SerieCodigo.IndexOf(" | "));
                }

            }
            if (Original_RegistroCodigo != null)
            {
                if (Original_RegistroCodigo.Contains(" | "))
                {
                    Original_RegistroCodigo = Original_RegistroCodigo.Remove(Original_RegistroCodigo.IndexOf(" | "));
                }

            }
            if (RegistroCodigo != null)
            {
                if (RegistroCodigo.Contains(" | "))
                {
                    RegistroCodigo = RegistroCodigo.Remove(RegistroCodigo.IndexOf(" | "));
                }

            }

            //UpRowRadicado.GrupoCodigo = GrupoCodigo;
            //UpRowRadicado.WFMovimientoFecha = WFMovimientoFecha;
            //UpRowRadicado.RadicadoFechaProcedencia = RadicadoFechaProcedencia;
            //UpRowRadicado.ProcedenciaCodigo = ProcedenciaCodigo;
            //UpRowRadicado.RadicadoNumeroExterno = RadicadoNumeroExterno;
            //UpRowRadicado.NaturalezaCodigo = NaturalezaCodigo;
            ////Radicado.DependenciaCodigo = DependenciaCodigo;
            //UpRowRadicado.RadicadoDetalle = RadicadoDetalle;
            //UpRowRadicado.RadicadoFechaVencimiento = RadicadoFechaVencimiento;
            //UpRowRadicado.ExpedienteCodigo = ExpedienteCodigo;
            //UpRowRadicado.MedioCodigo = MedioCodigo;
            //UpRowRadicado.RadicadoCodigo = Convert.ToInt32(RadicadoCodigo);
            //UpRowRadicado.Original_RadicadoCodigo = Original_RadicadoCodigo;
            //UpRowRadicado.Original_GrupoCodigo = GrupoCodigo;
            //UpRowRadicado.DependenciaCodigo = DependenciaCodigo;
            ////*****************Falta la seleccion de dependencia este parametro depende de la estructura de proceso*******
            //UpRowRadicado.DependenciaCodDestino = DependenciaCodDestino;
            ////*****************Falta la seleccion de Serie este parametro depende de la estructura de proceso*******
            ////UpRadicado.LoadDataRow(UpRowRadicado,true);
            //UpRadicado.AddRadicado_ReadRadRow(UpRowRadicado);
            DateTime FechaDevolucionDateTime;
                        
            if (FechaDevolucion == "" || FechaDevolucion == null)
            {

                FechaDevolucionDateTime = Convert.ToDateTime("01/01/1753");
            }
            else
            {
                FechaDevolucionDateTime = Convert.ToDateTime(FechaDevolucion);
            }
            
            int Resultupdate;

            ////////////////////////////////////////////////
            MembershipUser user = Membership.GetUser();
            Object CodigoRuta = user.ProviderUserKey;
            String UserIdAud = Convert.ToString(CodigoRuta);
            ////////////////////////////////////////////////     

            Resultupdate = AdapterRegistroRead.Registro_UpdateRegistro(RegistroCodigo, WFMovimientoFecha, ProcedenciaCodDestino, DependenciaCodDestino, DependenciaCodigo, NaturalezaCodigo, RadicadoCodigo, RegistroDetalle, RegistroGuia, RegistroEmpGuia, AnexoExtRegistro, LogDigitador, ExpedienteCodigo, MedioCodigo, SerieCodigo, RegPesoEnvio, RegValorEnvio, RegistroTipo, Original_RegistroCodigo, Original_GrupoCodigo, GrupoCodigo, CodigoMotDevolucion, FechaDevolucionDateTime, Convert.ToDateTime(FechaActDevolucion),UserIdAud);
           //Resultupdate = AdapterRadicadoRea.Radicado_UpdateRadicado(RadicadoCodigo,GrupoCodigo,WFMovimientoFecha,RadicadoFechaProcedencia,ProcedenciaCodigo,RadicadoNumeroExterno,NaturalezaCodigo,DependenciaCodigo,RadicadoDetalle,RadicadoFechaVencimiento,ExpedienteCodigo,MedioCodigo,DependenciaCodDestino,Original_RadicadoCodigo,Original_GrupoCodigo);
            
               //UpRadicado = AdapterRadicadoRead.GetRadicadoByUpdate(RadicadoCodigo,GrupoCodigo,WFMovimientoFecha,RadicadoFechaProcedencia,ProcedenciaCodigo,RadicadoNumeroExterno,NaturalezaCodigo,DependenciaCodigo,RadicadoDetalle,RadicadoFechaVencimiento,ExpedienteCodigo,MedioCodigo,DependenciaCodDestino,Original_RadicadoCodigo,Original_GrupoCodigo);
    //        //AdapterRadicadoRead.Update(UpRadicado);
    //        //AdapterRadicado.Radicado_CreateRadicado1(Radicados, GrupoCodigo, WFMovimientoFecha, RadicadoFechaProcedencia, ProcedenciaCodigo, RadicadoNumeroExterno, NaturalezaCodigo, DependenciaCodigo, RadicadoDetalle, RadicadoFechaVencimiento, ExpedienteCodigo, MedioCodigo, DependenciaCodDestino, WFAccionCodigo, RadicadoFechaVencimiento, RadicadoFechaVencimiento, WFMovimientoTipo, WFMovimientoNotas, SerieCodigo, ref  Result, WFMovimientoMultitarea);

    //        //// Return true if precesely one row was inserted, otherwise false
    //        //string radicacod = Convert.ToString(Result);
    //        //varprueba = Convert.ToInt32(Result);    

    //        //int rowsAffected = AdapterRadicadoRead.(UpRadicado);
    //        //return rowsAffected;
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
}
