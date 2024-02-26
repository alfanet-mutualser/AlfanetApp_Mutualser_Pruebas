using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

//namespace Data
//{
    public class Data
    {
        Database DB;
        public DataSet cargarPlantillas()
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Plantilla_ListaPermisos"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public DataSet cargarPlantillas(string dependencia)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Plantilla_Lista"))
            {
                try
                {
                    DB.AddInParameter(dbcommand, "dependencia", DbType.String, dependencia);
                    DataSet ds = new DataSet();
                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet TraerHTMLPlantillas(string codPlantilla)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Plantilla_SelectById"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@vCodigo", DbType.String, codPlantilla);
                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }   

        public DataSet CombinaCampos(string Tabla, string mCampo, string mTablaSecundaria, string radicadoCodigo)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Plantilla_Combina_Campos"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@vTablaDocumento", DbType.String, Tabla);
                    DB.AddInParameter(dbcommand, "@vNroDocumento", DbType.String, radicadoCodigo);
                    DB.AddInParameter(dbcommand, "@vTablaSecundaria", DbType.String, mTablaSecundaria);
                    DB.AddInParameter(dbcommand, "@vCampo", DbType.String, mCampo);
                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet cargarDatos(string radicado)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Radicado_ReadUnRad"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@gruporadicadocodigo", DbType.String, "1");
                    DB.AddInParameter(dbcommand, "@radicadocodigo", DbType.String, radicado);
                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int crearRegistros(string grupoCodigo, DateTime wFMovimientoFecha, string procedenciaCodDestino
            , string dependenciaCodDestino, string dependenciaCodigo, string naturalezaCodigo, int radicadoCodigo
            , string registroDetalle, string registroGuia, string registroEmpGuia, string anexoExtRegistro
            , string logDigitador, string expedienteCodigo, string medioCodigo, string serieCodigo
            , string regPesoEnvio, string regValorEnvio, string registroTipo, string wFAccionCodigo
            , DateTime wFMovimientoFechaEst, DateTime wFMovimientoFechaFin, int wFMovimientoTipo
            , string wFMovimientoNotas, string wFMovimientoMultitarea, string userId)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Registro_CreateRegistro"))
            {
                try
                {
                    DB.AddInParameter(dbcommand, "@GrupoCodigo", DbType.String, grupoCodigo);
                    DB.AddInParameter(dbcommand, "@WFMovimientoFecha", DbType.DateTime, wFMovimientoFecha);
                    DB.AddInParameter(dbcommand, "@ProcedenciaCodDestino", DbType.String, procedenciaCodDestino);
                    DB.AddInParameter(dbcommand, "@DependenciaCodDestino", DbType.String, dependenciaCodDestino);
                    DB.AddInParameter(dbcommand, "@DependenciaCodigo", DbType.String, dependenciaCodigo);
                    DB.AddInParameter(dbcommand, "@NaturalezaCodigo", DbType.String, naturalezaCodigo);
                    DB.AddInParameter(dbcommand, "@RadicadoCodigo", DbType.Int32, radicadoCodigo);
                    DB.AddInParameter(dbcommand, "@RegistroDetalle", DbType.String, registroDetalle);
                    DB.AddInParameter(dbcommand, "@RegistroGuia", DbType.String, registroGuia);
                    DB.AddInParameter(dbcommand, "@RegistroEmpGuia", DbType.String, registroEmpGuia);
                    DB.AddInParameter(dbcommand, "@AnexoExtRegistro", DbType.String, anexoExtRegistro);
                    DB.AddInParameter(dbcommand, "@LogDigitador", DbType.String, logDigitador);
                    DB.AddInParameter(dbcommand, "@ExpedienteCodigo", DbType.String, expedienteCodigo);
                    DB.AddInParameter(dbcommand, "@MedioCodigo", DbType.String, medioCodigo);
                    DB.AddInParameter(dbcommand, "@SerieCodigo", DbType.String, serieCodigo);
                    DB.AddInParameter(dbcommand, "@RegPesoEnvio", DbType.String, regPesoEnvio);
                    DB.AddInParameter(dbcommand, "@RegValorEnvio", DbType.String, regValorEnvio);
                    DB.AddInParameter(dbcommand, "@RegistroTipo", DbType.String, registroTipo);
                    DB.AddInParameter(dbcommand, "@WFAccionCodigo", DbType.String, wFAccionCodigo);
                    DB.AddInParameter(dbcommand, "@WFMovimientoFechaEst", DbType.DateTime, wFMovimientoFechaEst);
                    DB.AddInParameter(dbcommand, "@WFMovimientoFechaFin", DbType.DateTime, wFMovimientoFechaFin);
                    DB.AddInParameter(dbcommand, "@WFMovimientoTipo", DbType.Int32, wFMovimientoTipo);
                    DB.AddInParameter(dbcommand, "@WFMovimientoNotas", DbType.String, wFMovimientoNotas);
                    DB.AddInParameter(dbcommand, "@WFMovimientoMultitarea", DbType.String, wFMovimientoMultitarea);
                    DB.AddInParameter(dbcommand, "@UserId", DbType.String, userId);

                    DB.AddOutParameter(dbcommand, "@RegistroCodigo", DbType.Int32, 1);
                    DB.ExecuteNonQuery(dbcommand);
                    int registro = Convert.ToInt32(DB.GetParameterValue(dbcommand, "@RegistroCodigo"));
                    //Byte isValid = Convert.ToByte(_db.GetParameterValue(_dbCommand, "isvalid"));

                    return registro;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void crearRadicadoFuente(string gRegistroCodigo, int registro, string gRadicadoCodigoFuente, int radicado)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("RadicadoFuente_CreateRadicadoFuente"))
            {
                try
                {
                    DB.AddInParameter(dbcommand, "@GrupoRegistroCodigo", DbType.String, gRegistroCodigo);
                    DB.AddInParameter(dbcommand, "@RegistroCodigo", DbType.Int32, registro);
                    DB.AddInParameter(dbcommand, "@GrupoRadicadoCodigoFuente", DbType.String, gRadicadoCodigoFuente);
                    DB.AddInParameter(dbcommand, "@RadicadoCodigoFuente", DbType.Int32, radicado);
                    int insert = DB.ExecuteNonQuery(dbcommand);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void insertarPlantilla(string codPlantilla, string dependenciaCodigo, string html)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("PlantillaControl_Insert"))
            {
                try
                {
                    DB.AddInParameter(dbcommand, "@CodigoPlantilla", DbType.String, codPlantilla);
                    DB.AddInParameter(dbcommand, "@CodDependencia", DbType.String, dependenciaCodigo);
                    DB.AddInParameter(dbcommand, "@HTML", DbType.String, html);

                    int insert = DB.ExecuteNonQuery(dbcommand);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet buscarPlantilla(string mCodPlantilla, string mCodDep)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("PlantillaControl_SelectById"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@CodigoPlantilla", DbType.String, mCodPlantilla);
                    DB.AddInParameter(dbcommand, "@CodDependencia", DbType.String, mCodDep);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet obtenerCodigoRuta(int ano, int mes, string grupo)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("SelectRutaCodigoByAnioMesGrupo"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@ImagenRutaAnio", DbType.Int32, ano);
                    DB.AddInParameter(dbcommand, "@ImagenRutaMes", DbType.Int32, mes);
                    DB.AddInParameter(dbcommand, "@ImagenRutaGrupo", DbType.String, grupo);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void insertarImagen(int rutaCodigo, string rutaDescripcion, int ano, int mes, int rutaGrupo, string PathVirtual)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("ImagenRuta_Insert"))
            {
                try
                {
                    //DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@ImagenRutaCodigo", DbType.Int32, rutaCodigo);
                    DB.AddInParameter(dbcommand, "@ImagenRutaDescripcion", DbType.String, rutaDescripcion);
                    DB.AddInParameter(dbcommand, "@ImagenRutaAnio", DbType.Int32, ano);
                    DB.AddInParameter(dbcommand, "@ImagenRutaMes", DbType.Int32, mes);
                    DB.AddInParameter(dbcommand, "@ImagenRutaGrupo", DbType.Int32, rutaGrupo);
                    DB.AddInParameter(dbcommand, "@ImagenRutaPath", DbType.String, PathVirtual);

                    int ok = DB.ExecuteNonQuery(dbcommand);
                    //return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void insertarRegistroImagen(string grupo, int registro, string nombreArchivo, int codigoR)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("RegistroImagen_Insert"))
            {
                try
                {
                    //DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@GrupoCodigo", DbType.String, grupo);
                    DB.AddInParameter(dbcommand, "@RegistroCodigo", DbType.Int32, registro);
                    DB.AddInParameter(dbcommand, "@RegistroImagenNombre", DbType.String, nombreArchivo);
                    DB.AddInParameter(dbcommand, "@ImagenRutaCodigo", DbType.Int32, codigoR);

                    int ok = DB.ExecuteNonQuery(dbcommand);
                    //return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet obtenerDatosRadicado(string radicado)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Radicado_ReadRad"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@RadicadoCodigo", DbType.String, radicado);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet obtenerDatosRegistro(string registro)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Registro_ReadRegistro"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@RegistroCodigo", DbType.String, registro);
                    DB.AddInParameter(dbcommand, "@grupo", DbType.String, '2');
                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet obtenerDatosProcedencia(string codProcedencia)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Procedencia_ReadProcedenciaById"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@ProcedenciaNUI", DbType.String, codProcedencia);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

	public DataSet obtenerDatosCiudad(string codciudad)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Ciudad_ReadCiudadById"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@CiudadCodigo", DbType.String, codciudad);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet obtenerImagenesRegistro(string grupo, int registro)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("RegistroImagen_SelectById"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@GrupoRegistroCodigo", DbType.String, grupo);
                    DB.AddInParameter(dbcommand, "@RegistroCodigo", DbType.Int32, registro);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet obtenerImagenruta(int codigoRuta)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("ImagenRuta_SelectById"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@ImagenRutaCodigo", DbType.Int32, codigoRuta);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet obtenerUsuariosxDependencia(string mails)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("ReadUserxDependenciabyDependencia"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@DependenciaCodigo", DbType.String, mails);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet GetDependenciaByText(string prefixText, string estado)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Dependencia_ReadDependenciaByText"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@DependenciaNombre", DbType.String, prefixText);
                    DB.AddInParameter(dbcommand, "@DependenciaHabilitar", DbType.String, estado);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet GetExpedienteByTextNombre(string prefixText, bool estado)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Expediente_ReadExpedienteByTextNombre"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@ExpedienteNombre", DbType.String, prefixText);
                    DB.AddInParameter(dbcommand, "@ExpedienteHabilitar", DbType.Boolean, estado);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet GetMedioByText(string prefixText, string estado)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Medio_ReadMedioByText"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@MedioNombre", DbType.String, prefixText);
                    DB.AddInParameter(dbcommand, "@MedioHabilitar", DbType.String, estado);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet GetNaturalezaByText(string prefixText, string estado)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Naturaleza_ReadNaturalezaByText"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@NaturalezaNombre", DbType.String, prefixText);
                    DB.AddInParameter(dbcommand, "@NaturalezaHabilitar", DbType.String, estado);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet GetProcedenciaByTextNombre(string prefixText, string estado)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Procedencia_ReadProcedenciaByText"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@ProcedenciaNombre", DbType.String, prefixText);
                    DB.AddInParameter(dbcommand, "@ProcedenciaHabilitar", DbType.String, estado);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet GetSerieByText(string prefixText, string estado)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Serie_ReadSerieByText"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@SerieNombre", DbType.String, prefixText);
                    DB.AddInParameter(dbcommand, "@SerieHabilitar", DbType.String, estado);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet GetRadicadoByCodigo(string prefixText)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Radicado_ReadRad"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@RadicadoCodigo", DbType.String, prefixText);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet GetWFAccionTextByText(string prefixText, string estado)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("WFAccion_SelectByText"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@WFAccionNombre", DbType.String, prefixText);
                    DB.AddInParameter(dbcommand, "@WFAccionHabilitar", DbType.String, estado);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet obtenerUserId(string depUsuario)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("ReadUserxDependenciabyDependencia"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@DependenciaCodigo", DbType.String, depUsuario);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        
        public DataSet ReadUsersByUserName(string username)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Aspnet_Users_ReadUsersByUserName"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@UserName", DbType.String, username);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet GetProcedenciaByID(string destino)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Procedencia_ReadProcedenciaById"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@ProcedenciaNUI", DbType.String, destino);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet GetDependenciaByID(string destino)
        {
            DB = DatabaseFactory.CreateDatabase("conexion");
            using (DbCommand dbcommand = DB.GetStoredProcCommand("Dependencia_ReadDependenciaById"))
            {
                try
                {
                    DataSet ds = new DataSet();
                    DB.AddInParameter(dbcommand, "@DependenciaCodigo", DbType.String, destino);

                    ds = DB.ExecuteDataSet(dbcommand);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
//}
