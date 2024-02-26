using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

//namespace Business
//{
    public class Business
    {
        public DataSet cargarPlantillas()
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.cargarPlantillas();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet cargarPlantillas(string dependencia)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.cargarPlantillas(dependencia);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet TraerHTMLPlantilla(string codPlantilla)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.TraerHTMLPlantillas(codPlantilla);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CombinaCampos(string Tabla, string mCampo, string mTablaSecundaria, string radicadoCodigo)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.CombinaCampos(Tabla, mCampo, mTablaSecundaria, radicadoCodigo);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet cargarDatos(string radicado)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.cargarDatos(radicado);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int crearRegistro(string grupoCodigo, DateTime wFMovimientoFecha, string procedenciaCodDestino, string dependenciaCodDestino, string dependenciaCodigo, string naturalezaCodigo, int radicadoCodigo, string registroDetalle, string registroGuia, string registroEmpGuia, string anexoExtRegistro, string logDigitador, string expedienteCodigo, string medioCodigo, string serieCodigo, string regPesoEnvio, string regValorEnvio, string registroTipo, string wFAccionCodigo, DateTime wFMovimientoFechaEst, DateTime wFMovimientoFechaFin, int wFMovimientoTipo, string wFMovimientoNotas, string wFMovimientoMultitarea, string userId)
        {
            try
            {
                Data dal = new Data();
                int registro = dal.crearRegistros(grupoCodigo, wFMovimientoFecha, procedenciaCodDestino, dependenciaCodDestino, dependenciaCodigo, naturalezaCodigo, radicadoCodigo, registroDetalle, registroGuia, registroEmpGuia, anexoExtRegistro, logDigitador, expedienteCodigo, medioCodigo, serieCodigo, regPesoEnvio, regValorEnvio, registroTipo, wFAccionCodigo, wFMovimientoFechaEst, wFMovimientoFechaFin, wFMovimientoTipo, wFMovimientoNotas, wFMovimientoMultitarea, userId);
                return registro;
            }
            catch (Exception )
            {
                return 0;
            }
        }

        public void crearRadicadoFuente(string gRegistroCodigo, int registro, string gRadicadoCodigoFuente, int radicado)
        {
            try
            {
                Data dal = new Data();
                dal.crearRadicadoFuente(gRegistroCodigo, registro, gRadicadoCodigoFuente, radicado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insertarPlantilla(string codPlantilla, string dependenciaCodigo, string html)
        {
            try
            {
                Data dal = new Data();
                dal.insertarPlantilla(codPlantilla, dependenciaCodigo, html);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet buscarPlnatilla(string mCodPlantilla, string mCodDep)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.buscarPlantilla(mCodPlantilla, mCodDep);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet obtenerCodigoRuta(int ano, int mes, string grupo)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.obtenerCodigoRuta(ano, mes, grupo);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insertarImagen(int rutaCodigo, string rutaDescripcion, int ano, int mes, int rutaGrupo, string PathVirtual)
        {
            try
            {
                Data dal = new Data();
                //DataSet ds = new DataSet();
                dal.insertarImagen(rutaCodigo, rutaDescripcion, ano, mes, rutaGrupo, PathVirtual);
                //return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insertarRegistroImagen(string grupo, int registro, string nombreArchivo, int codigoR)
        {
            try
            {
                Data dal = new Data();
                //DataSet ds = new DataSet();
                dal.insertarRegistroImagen(grupo, registro, nombreArchivo, codigoR);
                //return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet obtenerDatosRadicado(string radicado)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.obtenerDatosRadicado(radicado);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet obtenerDatosRegistro(string registro)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.obtenerDatosRegistro(registro);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet obtenerDatosProcedencia(string codProcedencia)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.obtenerDatosProcedencia(codProcedencia);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

	public DataSet obtenerDatosCiudad(string codciudad)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.obtenerDatosCiudad(codciudad);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet obtenerImagenesRegistro(string grupo, int registro)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.obtenerImagenesRegistro(grupo, registro);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet obtenerImagenruta(int codigoRuta)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.obtenerImagenruta(codigoRuta);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet obtenerUsuariosxDependencia(string mails)
        {
            try
            {
                Data dal = new Data();
                DataSet ds = new DataSet();
                ds = dal.obtenerUsuariosxDependencia(mails);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDependenciaByText(string prefixText, string estado)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.GetDependenciaByText(prefixText, estado);
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetExpedienteByTextNombre(string prefixText, bool estado)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.GetExpedienteByTextNombre(prefixText, estado);
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMedioByText(string prefixText, string estado)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.GetMedioByText(prefixText, estado);
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetNaturalezaByText(string prefixText, string estado)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.GetNaturalezaByText(prefixText, estado);
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetProcedenciaByTextNombre(string prefixText, string estado)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.GetProcedenciaByTextNombre(prefixText, estado);
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSerieByText(string prefixText, string estado)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.GetSerieByText(prefixText, estado);
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRadicadoByCodigo(string prefixText)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.GetRadicadoByCodigo(prefixText);
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetWFAccionTextByText(string prefixText, string estado)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.GetWFAccionTextByText(prefixText, estado);
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerUserId(string depUsuario)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.obtenerUserId(depUsuario);
                return data.Tables[0].Rows[0]["userid"].ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public string ReadUsersByUserName(string username)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.ReadUsersByUserName(username);
                return data.Tables[0].Rows[0]["userid"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetProcedenciaByID(string destino)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.GetProcedenciaByID(destino);
                return data.Tables[0].Rows[0]["ProcedenciaNombre"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDependenciaByID(string destino)
        {
            try
            {
                Data dal = new Data();
                DataSet data = new DataSet();
                data = dal.GetDependenciaByID(destino);
                return data.Tables[0].Rows[0]["DependenciaNombre"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
//}
