using System;
using System.Data;

using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections.Generic;


/// <summary>
/// Descripción breve de Class2
/// </summary>
public class rutinas : System.Web.UI.Page
{

    // FUNCONES SQL
    public DataTable rtn_ejecutarprocedimientoalmacenado(string nombredelprocedimiento, string parametros)
    {
        // en la cadena de parametros se mandan los parametros separados por un | palo 
        // y cada propiedad del parametros se separa con una coma ,
        // eJ; @codigo,varchar,input,1111|@nombre,varchar,input,hola
        // el ultimo no lleva palo, aqui se lo colocamos

        string cadenadeconexion = this.rtn_cadenadeconexion();
        System.Data.DataTable table = new DataTable();
        ParameterDirection[] xtiposdedireccion = { ParameterDirection.Input, ParameterDirection.InputOutput, ParameterDirection.Output, ParameterDirection.ReturnValue };
        String xx = "";
        int xdifere = 0;
        DataColumn column;
        DataRow row;


            SqlDbType[] xtiposdedatosobjeto = { SqlDbType.Char, SqlDbType.DateTime, SqlDbType.Decimal, SqlDbType.Int, SqlDbType.VarChar };
            SqlDataReader xreader;
            SqlConnection xconexion = new SqlConnection(cadenadeconexion);
            SqlCommand xcomando = new SqlCommand();
            xcomando.Connection = xconexion;
            xcomando.CommandType = CommandType.StoredProcedure;
            xcomando.CommandText = nombredelprocedimiento;
            parametros = parametros.ToUpper();
            parametros = parametros.Trim() + "|";
            if (parametros.Length == 1) parametros = "";
            while (parametros.Length != 0)
            {
                SqlParameter xparameter = new SqlParameter();
                int xpos = parametros.IndexOf("|");
                String xparametro = parametros.Substring(0, xpos);
                xparametro.Trim();
                xdifere = parametros.Length - xpos - 1;
                parametros = parametros.Substring(xpos + 1, xdifere);
                xparametro = xparametro + ",";
                int xcontador = 0;
                while (xparametro.Length != 0)
                {
                    xpos = xparametro.IndexOf(",");
                    String xvalordelparametro = xparametro.Substring(0, xpos);
                    xvalordelparametro.Trim();
                    xdifere = xparametro.Length - xpos - 1;
                    xparametro = xparametro.Substring(xpos + 1, xdifere);
                    xcontador = xcontador + 1;
                    if (xcontador.Equals(1)) xparameter.ParameterName = xvalordelparametro;
                    if (xcontador.Equals(2))
                    {
                        for (int i = 0; i <= xtiposdedatosobjeto.Length - 1; i++)
                        {
                            xx = Convert.ToString(xtiposdedatosobjeto[i]);
                            xx = xx.ToUpper();
                            if (xvalordelparametro.Equals(xx))
                            {
                                xparameter.SqlDbType = xtiposdedatosobjeto[i];
                                break;
                            }
                        }
                    }

                    if (xcontador.Equals(3))
                    {
                        for (int i = 0; i <= xtiposdedireccion.Length - 1; i++)
                        {
                            xx = Convert.ToString(xtiposdedireccion[i]);
                            xx = xx.ToUpper();
                            if (xvalordelparametro.Equals(xx))
                            {
                                xparameter.Direction = xtiposdedireccion[i];
                                break;
                            }
                        }
                    }

                    if (xcontador.Equals(4))
                    {
                        xparameter.Value = xvalordelparametro;
                        if (xparameter.SqlDbType.Equals(SqlDbType.Decimal)) xparameter.Value = Convert.ToDecimal(xvalordelparametro);
                        if (xparameter.SqlDbType.Equals(SqlDbType.Int)) xparameter.Value = Convert.ToInt32(xvalordelparametro);
                        if (xparameter.SqlDbType.Equals(SqlDbType.DateTime)) xparameter.Value = Convert.ToDateTime(xvalordelparametro);
                    }
                }
                xcomando.Parameters.Add(xparameter);
            }


            try
            {
                xconexion.Open();
                xreader = xcomando.ExecuteReader();
            }
            catch (Exception ee)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "error";
                table.Columns.Add(column);
                row = table.NewRow();
                row["error"] = "!!Error!! " + ee.Message.ToString();
                table.Rows.Add(row);
                return table;
            }

           

            int xnumerodecampos = xreader.FieldCount;
            string[] campos = new string[xnumerodecampos];
            for (int i = 0; i <= xnumerodecampos - 1; i++)
            {
                campos[i] = xreader.GetName(i);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = campos[i];
                table.Columns.Add(column);
            }
            while (xreader.Read())
            {
                row = table.NewRow();
                for (int i = 0; i <= xnumerodecampos - 1; i++)
                {
                    row[xreader.GetName(i)] = xreader[i].ToString();
                }
                table.Rows.Add(row);
            }

            xconexion.Close();
            xconexion.Dispose();
            xreader.Close();
            xreader.Dispose();
        return table;
    }
    public string rtn_ejecutarsql(string comando)
    {

        string cadenadeconexion = this.rtn_cadenadeconexion();


        comando = comando.Trim();
        if (comando.Length == 0) return "  ";
        string xmensaje = "";
            SqlConnection xconexion = new SqlConnection(cadenadeconexion);
            SqlCommand xcomando = new SqlCommand(comando, xconexion);
            try
            {
                xconexion.Open();
                xcomando.ExecuteNonQuery();
                xconexion.Close();
                xconexion.Dispose();
                xmensaje = "(ok)";
            }
            catch (Exception e)
            {
                xconexion.Close();
                xconexion.Dispose();
                xmensaje = e.Message.ToString();

            }

       

        return xmensaje;
    }
    public DataTable rtn_creartabla( string comando)
    {
        string cadenadeconexion = this.rtn_cadenadeconexion();


        System.Data.DataTable table = new DataTable();
        DataSet xdataset = new DataSet();


            SqlConnection xconexion = new SqlConnection(cadenadeconexion);
            SqlCommand xcomando = new SqlCommand(comando, xconexion);
            SqlDataAdapter xadaptador = new SqlDataAdapter(comando, xconexion);
            xconexion.Open();
            xadaptador.Fill(xdataset);
            table = xdataset.Tables[0];
            xconexion.Close();

        System.Data.DataTable tabla = new DataTable();
        DataColumn dc = new DataColumn();

        foreach (DataColumn dtc in table.Columns)
        {
            dc = new DataColumn();
            dc.ColumnName = dtc.ColumnName;
            dc.DataType = System.Type.GetType("System.String");
            tabla.Columns.Add(dc);
        }

        DataRow dr;
        foreach (DataRow dtr in table.Rows)
        {
            dr = tabla.NewRow();
            foreach (DataColumn dtc in table.Columns)
            {
                dr[dtc.ColumnName] = dtr[dtc.ColumnName].ToString();
            }
            tabla.Rows.Add(dr);
        }



        return tabla;
    }
    
    // rutinas para grupos
    public DataTable rtn_traer_grupos()
    {
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Grupo_consulta", "");
        return tabla;

    }
    public DataTable rtn_traer_grupos_por_codigopadre(string codigo)
    {
        string parametros = "@codigo,varchar,input," + codigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Grupo_ConsultaByCodigopadre", parametros);
        return tabla;

    }
    public DataTable rtn_traer_grupos_por_Id(string codigo)
    {
        string parametros = "@codigo,varchar,input," + codigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Grupo_ConsultaById", parametros);
        return tabla;

    }
    public DataTable rtn_traer_tbtablas_por_Id( string codigo)
    {
        string parametros = "@codigo,varchar,input," + codigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("tbtablas_ConsultaById", parametros);
        return tabla;

    }

    // rutinas para radicados
    public DataTable rtn_traer_radicados_por_grupo(string codigo,String RadicadoCodigo)
    {

        string parametros = "@codigo,varchar,input," + codigo +"|";
        parametros += "@RadicadoCodigo,varchar,input," + RadicadoCodigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Radicado_ReadRadicadoByGrupo", parametros);
        return tabla;
       
    }
    public DataTable rtn_traer_radicados_por_grupo_por_id(string grupo , string codigo)
    {

        string  parametros =  "@gruporadicadocodigo,varchar,input," + grupo + "|" ;
        parametros += "@radicadocodigo,varchar,input," + codigo;
    
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Radicado_ReadUnRad", parametros);
        return tabla;

    }
    public DataTable rtn_registrar_log(string documento,string userID,string operacion,string entrada,string grupo)
    {
        /*
         @documento varchar(200),
	@userid varchar(200),
	@parametros varchar(200),
	@operacion varchar(20),
	@grupo varchar(20)
         
         
         */
        string parametros = "@documento,varchar,input," + documento + "|";
        parametros += "@userid,varchar,input," + userID + "|";
        parametros += "@parametros,varchar,input," + entrada + "|";
        parametros += "@operacion,varchar,input," + operacion + "|";
        parametros += "@grupo,varchar,input," + grupo +"";
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("registrar_alfanetlog", parametros);
        return tabla;
        /*
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Radicado_ReadUnRad1", parametros);
        return tabla;*/

    }
    public DataTable rtn_validar_radicado(string codigo)
    {

        DataTable tabla = new DataTable();
        tabla = this.rtn_creartabla("select radicadocodigo from radicado where radicadocodigo = "+ codigo);
        return tabla;

    }
    public DataTable rtn_traer_estado_radicado(string codigo)
    {
        string parametros = "@codigo,int,input," + codigo ;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Radicado_ConsultarEstado", parametros);
        return tabla;

    }
    public DataTable rtn_traer_dependencia_actual(string codigo)
    {
        string parametros = "@codigo,int,input," + codigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Radicado_ConsultarDependenciaActual", parametros);
        return tabla;

    }
    public DataTable rtn_traer_respuesta(string nit ,  string radicado , string expediente  )
    {
        nit = nit.Trim();
        radicado = radicado.Trim();
        expediente = expediente.Trim();
        
        if (nit.Length == 0) nit = "NULL";
        if (radicado.Length == 0) radicado = "0";
        if (expediente.Length == 0) expediente = "NULL";

        string parametros = "@nit,varchar,input," + nit + "|" ;
        parametros += "@codigo,int,input," + radicado + "|";
        parametros += "@expediente,varchar,input," + expediente;

        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Radicado_ConsultarRespuesta", parametros);
        return tabla;

    }
    public DataTable rtn_traer_traza_del_radicado(string nit, string radicado, string expediente, string naturaleza,string fechadesde ,string fechahasta)
    {
        nit = nit.Trim();
        radicado = radicado.Trim();
        expediente = expediente.Trim();

        if (nit.Length == 0) nit = "NULL";
        if (radicado.Length == 0) radicado = "0";
        if (expediente.Length == 0) expediente = "NULL";

        string parametros = "@nit,varchar,input," + nit + "|";
        parametros += "@codigo,int,input," + radicado + "|";
        parametros += "@expediente,varchar,input," + expediente + "|";
        parametros += "@naturaleza,varchar,input," + naturaleza + "|";
        parametros += "@fechadesde,datetime,input," + fechadesde + "|";
        parametros += "@fechahasta,datetime,input," + fechahasta    ;

        DataTable tabla = new DataTable();


        tabla = this.rtn_ejecutarprocedimientoalmacenado("Radicado_ConsultarTraza", parametros);
        return tabla;

    }
        
    // rutinas para registros
    public DataTable rtn_traer_registros_por_grupo_por_id(string grupo, string codigo)
    {
        string parametros = "@grupo,varchar,input," + grupo + "|";
        parametros += "@registrocodigo,varchar,input," + codigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Registro_ReadRegistro", parametros);
        return tabla;
    }
    public DataTable rtn_traer_registros_por_grupo(string grupo,String RegistroCodigo)
    {
        string parametros = "@grupo,varchar,input," + grupo + "|";
        parametros += "@RegistroCodigo,varchar,input," + RegistroCodigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Registro_ReadRegByGrupo", parametros);
        return tabla;
    }
    
    // rutinas para procedencias
    public DataTable rtn_traer_procedencia_por_id(string codigo)
    {
        string parametros = "@procedenciaNUI,varchar,input," + codigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Procedencia_SelectById", parametros);
        return tabla;

    }
    public DataTable rtn_actualizar_procedencia_por_id
       (string nit       , string razonsocial, string direccion , string  telefono1,
        string telefono2 ,  string fax       , string ciudad    , 
        string correo1   , string correo2    , string paginaweb , string  sucursal )
        
    {
        string parametros =  "@procedenciaNUI          ,varchar,input," + nit         + "|";
               parametros += "@procedenciacodigo       ,varchar,input," + nit         + "|";
               parametros += "@procedencianombre       ,varchar,input," + razonsocial + "|";
               parametros += "@procedencianuipadre     ,varchar,input," + "NULL"      + "|";
               parametros += "@procedenciadireccion    ,varchar,input," + direccion   + "|";
               parametros += "@procedenciatelefono1    ,varchar,input," + telefono1   + "|";
               parametros += "@procedenciatelefono2    ,varchar,input," + telefono2   + "|";
               parametros += "@procedenciafax          ,varchar,input," + fax         + "|";
               parametros += "@procedenciamail1        ,varchar,input," + correo1     + "|";
               parametros += "@procedenciamail2        ,varchar,input," + correo2     + "|";
               parametros += "@procedenciapaginaweb    ,varchar,input," + paginaweb   + "|";
               parametros += "@ciudadcodigo            ,varchar,input," + ciudad      + "|";
               parametros += "@procedenciahabilitar    ,varchar,input," + "1"         + "|";
               parametros += "@procedenciapermiso      ,varchar,input," + "1"         + "|";
               parametros += "@original_procedencianui ,varchar,input," + nit;


        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Procedencia_UpdateProcedencia", parametros);
        return tabla;

    }
    
    // rutinas para expedientes
    public DataTable rtn_validar_expediente(string codigo)
    {

        DataTable tabla = new DataTable();
        tabla = this.rtn_creartabla("select expedientecodigo from expediente where expedientecodigo = " +"'" +  codigo.Trim() + "'" );
        return tabla;

    }
    public DataTable rtn_actualizar_preexpediente(string nit, string sucursal, string expediente ,  string clasedeservicio)
    
    {
        string parametros = "@ExpedienteProcedenciaCodigo               ,varchar,input," + nit + "|";
        parametros += "@sucursal                ,varchar,input," + sucursal + "|";
        parametros += "@ExpedienteCodigo              ,varchar,input," + expediente + "|";
        parametros += "@ExpedienteClaseServicio         ,varchar,input," + clasedeservicio;


        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Expediente_UpdatePreexpediente", parametros);
        return tabla;

    }
    
    //Rutina consulta BDI
    public DataTable rtn_Getalfanetbdi(string RadicadoCodigo, string GrupoCodigo)
    {
        string parametros = "@RadicadoCodigo               ,varchar,input," + RadicadoCodigo + "|";
        parametros += "@GrupoCodigo         ,varchar,input," + GrupoCodigo;
        
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Radicado_ReadBDI", parametros);
        return tabla;

    }

    // rutinas radicadosfuente
    public DataTable rtn_traer_radicadofuente_por_grupo_por_id(string grupo, int codigo)
    {

        string parametros = "@gruporegistrocodigo,varchar,input," + grupo + "|";
        parametros += "@registrocodigo,int,input," + codigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("RadicadoFuente_ReadRadicadoFuente", parametros);
        return tabla;

    }
    public DataTable rtn_insertar_radicadofuente_por_grupo_por_id(string gruporegistro, int codigoregistro,string grupofuente,int codigofuente)
    {

        string parametros = "@gruporegistrocodigo,varchar,input," + gruporegistro + "|";
        parametros += "@registrocodigo,int,input," + codigoregistro + "|" ;
        parametros += "@gruporadicadocodigofuente,varchar,input," + grupofuente + "|";
        parametros += "@radicadocodigofuente,int,input," + codigofuente;

        
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("RadicadoFuente_CreateRadicadoFuente", parametros);
        return tabla;

    }
    public DataTable rtn_borrar_radicadofuente_por_grupo_por_id(string grupo, int codigo)
    {

        string parametros = "@Grupo_Original_RegistroCodigo,varchar,input," + grupo + "|";
        parametros += "@Original_RegistroCodigo,int,input," + codigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("RadicadoFuente_DeleteRadicadoFuente", parametros);
        return tabla;

    }
    
    //Consulta Archivos x Tramite
    public DataTable rtn_traer_FilexTramite(string ProcedenciaCodigo, string RadicadoCodigo, string ExpedienteCodigo)
    {
        ProcedenciaCodigo = ProcedenciaCodigo.Trim();
        RadicadoCodigo = RadicadoCodigo.Trim();
        ExpedienteCodigo = ExpedienteCodigo.Trim();

        if (ProcedenciaCodigo.Length == 0) ProcedenciaCodigo = "NULL";
        if (RadicadoCodigo.Length == 0) RadicadoCodigo = "NULL";
        if (ExpedienteCodigo.Length == 0) ExpedienteCodigo = "NULL";

        string parametros = "@ProcedenciaCodigo,varchar,input," + ProcedenciaCodigo + "|";
        parametros += "@RadicadoCodigo,varchar,input," + RadicadoCodigo + "|";
        parametros += "@ExpedienteCodigo,varchar,input," + ExpedienteCodigo;

        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Radicado_ConsultarFilexTramite", parametros);
        return tabla;

    }

    //Autor: Anderson Ardila Martinez
    //Fecha: 06/02/2011
    //Consulta Comunicados x Tramite
    public DataTable rtn_traer_ComunicadosxTramite(string vDocumentoCodigo, string vExpedienteCodigo)
    {
        if (vDocumentoCodigo.Length == 0) vDocumentoCodigo = "NULL";
        if (vExpedienteCodigo.Length == 0) vExpedienteCodigo = "NULL";

        string parametros = "@DocumentoCodigo,varchar,input," + vDocumentoCodigo + "|";
        parametros += "@ExpedienteCodigo,varchar,input," + vExpedienteCodigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("WS_Read_ComunicadosByTramite", parametros);
        return tabla;
    }    
    //Fin Anderson Ardila

    //Autor: Anderson Ardila Martinez
    //Fecha: 07/02/2011
    //Consulta RutaImagen x Tramite
    public DataTable rtn_traer_RutaImagenxTramite(string vDocumentoCodigo, string vGrupoCodigo)
    {
        if (vDocumentoCodigo.Length == 0) vDocumentoCodigo = "NULL";
        if (vGrupoCodigo.Length == 0) vGrupoCodigo = "NULL";

        string parametros = "@DocumentoCodigo,varchar,input," + vDocumentoCodigo + "|";
        parametros += "@GrupoCodigo,varchar,input," + vGrupoCodigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("WS_Read_RutaImagenByTramite", parametros);
        return tabla;
    }
    //Fin Anderson Ardila


    //Autor: Anderson Ardila Martinez
    //Fecha: 09/02/2011
    //Consulta RutaImagen x Tramite
    public DataTable rtn_traer_ComunicadosXFechaNaturaleza(string vFechaInicial, string vNaturalezaCodigo)
    {
        if (vNaturalezaCodigo.Length == 0) vNaturalezaCodigo = "NULL";
        if (vFechaInicial.Length == 0) vFechaInicial = DateTime.Now.ToString();

        string parametros = "@FechaInicial,Datetime,input," + vFechaInicial + "|";
        parametros += "@NaturalezaCodigo,varchar,input," + vNaturalezaCodigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("WS_Read_ComunicadosByFechaNaturaleza", parametros);
        return tabla;
    }
    //Fin Anderson Ardila

    //Cadena Conexion
    public string rtn_cadenadeconexion()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnStrSQLServer"].ToString(); ;

    }

    //Autor: Juan   
    //Fecha: 21/02/2011
    //Consulta Comunicados x Tramite
    public DataTable rtn_actualizar_DesarchivarDoc(string vDocumentoCodigo, string vGrupoCodigo)
    {
        if (vDocumentoCodigo.Length == 0) vDocumentoCodigo = "NULL";
        if (vGrupoCodigo.Length == 0) vGrupoCodigo = "NULL";

        string parametros = "@DocumentoCodigo,varchar,input," + vDocumentoCodigo + "|";
        parametros += "@GrupoCodigo,varchar,input," + vGrupoCodigo;
        DataTable tabla = new DataTable();
        tabla = this.rtn_ejecutarprocedimientoalmacenado("Update_WFMovimientosDesarchivar", parametros);
        return tabla;
    }
    //Fin Anderson Ardila

}