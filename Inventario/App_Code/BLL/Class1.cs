using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{

    private SqlConnection conectar;
    private SqlDataAdapter adaptador;
    private DataTable tabla;

    public void inicia()
    {
        try
        {

            conectar = new SqlConnection();
            //conectar.ConnectionString = (@"Data Source=Alyso;Initial Catalog=Inventario;Integrated Security=True");
            // conectar.ConnectionString = (@"Data Source=ALFANET2;Initial Catalog=Alfanet_Pruebas;password=Mutual2016$;User Id=sa; Connect Timeout=720");
			conectar.ConnectionString = (@"Data Source=192.168.211.197;Initial Catalog=Alfanet_Pruebas;password=Bogota2020$$;User Id=archivar; Connect Timeout=720");
            conectar.Open();
        }
        catch
        {
        }
    }
    public void cerrar()
    {
        try
        {
            conectar.Close();
        }
        catch
        {
        }
    }

    public string UnidadDocumentalInsertar(String DDLDependencia, String TBFechaExtremaInicial, String TBFechaExtremaFinal, String TBNomUnidad, String TBDetUnidad, String DDLUbicacion, String DDLForma, String TBNumFolios, String DDLSerie, String DDLAccion, String DDLTipologia, String TBRegInventario)
    {

        inicia();

        

        try
        {
            String[] dependencia = DDLDependencia.Split('|');
            SqlParameter prm1 = new SqlParameter("@DependenciaCodigo",   dependencia[0]);
            SqlParameter prm2 = new SqlParameter("@FechaExtremaInicial", Convert.ToDateTime(TBFechaExtremaInicial));
            SqlParameter prm3 = new SqlParameter("@FechaExtremaFinal", TBFechaExtremaFinal);
            SqlParameter prm4 = new SqlParameter("@UnidadNombre", TBNomUnidad);
            SqlParameter prm5 = new SqlParameter("@UnidadDetalle", TBDetUnidad);
            String[] ubicacion = DDLUbicacion.Split('|');
            SqlParameter prm6 = new SqlParameter("@UbicacionCodigo", ubicacion[0]);
            String[] forma = DDLForma.Split('|');
            SqlParameter prm7 = new SqlParameter("@FormaCodigo", forma[0]);
            SqlParameter prm8 = new SqlParameter("@NumeroFolios", TBNumFolios);
            String[] serie = DDLSerie.Split('|');
            SqlParameter prm9 = new SqlParameter("@SerieCodigo", serie[0]);
            String[] accion = DDLAccion.Split('|');
            SqlParameter prm10 = new SqlParameter("@WFAccionCodigo", accion[0]);
            String[] tipologia = DDLTipologia.Split('|');
            SqlParameter prm11 = new SqlParameter("@TipologiaCodigo", tipologia[0]);
            SqlParameter prm12 = new SqlParameter("@RegistroInventario", TBRegInventario);

            SqlCommand InsertarUnidadDocumental = new SqlCommand("UnidadDocumentalInsertar", conectar);
            InsertarUnidadDocumental.CommandType = CommandType.StoredProcedure;

            InsertarUnidadDocumental.Parameters.Add(prm1);
            InsertarUnidadDocumental.Parameters.Add(prm2);
            InsertarUnidadDocumental.Parameters.Add(prm3);
            InsertarUnidadDocumental.Parameters.Add(prm4);
            InsertarUnidadDocumental.Parameters.Add(prm5);
            InsertarUnidadDocumental.Parameters.Add(prm6);
            InsertarUnidadDocumental.Parameters.Add(prm7);
            InsertarUnidadDocumental.Parameters.Add(prm8);
            InsertarUnidadDocumental.Parameters.Add(prm9);
            InsertarUnidadDocumental.Parameters.Add(prm10);
            InsertarUnidadDocumental.Parameters.Add(prm11);
            InsertarUnidadDocumental.Parameters.Add(prm12);

            InsertarUnidadDocumental.ExecuteNonQuery();

            DataSet1TableAdapters.UnidadDocumental_ReadUnidadDocumentalUltTableAdapter unidad = new DataSet1TableAdapters.UnidadDocumental_ReadUnidadDocumentalUltTableAdapter();
            DataSet1.UnidadDocumental_ReadUnidadDocumentalUltDataTable unid = new DataSet1.UnidadDocumental_ReadUnidadDocumentalUltDataTable();
            unid = unidad.GetData();
            String uni = Convert.ToString(unid.Rows[0].ItemArray[0].ToString().Trim());

            return "Unidad Documental N°" + uni;


            //return "true";
        }
        
        catch (Exception ex)
        {
            string menerror = Convert.ToString(ex.Message);
            //return ex.Message;
            if (menerror == "Instrucción INSERT en conflicto con la restricción FOREIGN KEY \"FK_UnidadConservacion_Dependencia\". El conflicto ha aparecido en la base de datos \"Inventario\", tabla \"dbo.Dependencia\", column 'DependenciaCodigo'.\r\nSe terminó la instrucción.")
            {
                return "Favor verificar la dependencia";
            }
            else
                if (menerror == "Instrucción INSERT en conflicto con la restricción FOREIGN KEY \"FK_UnidadConservacion_Ubicacion\". El conflicto ha aparecido en la base de datos \"Inventario\", tabla \"dbo.UbicacionGeografica\", column 'UbicacionCodigo'.\r\nSe terminó la instrucción.")
                {
                    return "Favor verificar la Ubicacion Geofrafica";
                }
                else
                    if (menerror == "Instrucción INSERT en conflicto con la restricción FOREIGN KEY \"FK_UnidadConservacion_Forma_de_conservacion\". El conflicto ha aparecido en la base de datos \"Inventario\", tabla \"dbo.Forma_de_conservacion\", column 'FormaCodigo'.\r\nSe terminó la instrucción.")
                    {
                        return "Favor verificar la Forma de Conservación";
                    }
                    else
                        if (menerror == "Instrucción INSERT en conflicto con la restricción FOREIGN KEY \"FK_UnidadConservacion_Serie\". El conflicto ha aparecido en la base de datos \"Inventario\", tabla \"dbo.Serie\", column 'SerieCodigo'.\r\nSe terminó la instrucción.")
                        {
                            return "Favor verificar la Serie";
                        }
                        else
                            if (menerror == "Instrucción INSERT en conflicto con la restricción FOREIGN KEY \"FK_UnidadConservacion_WFAccion\". El conflicto ha aparecido en la base de datos \"Inventario\", tabla \"dbo.WFAccion\", column 'WFAccionCodigo'.\r\nSe terminó la instrucción.")
                            {
                                return "Favor verificar la Acción";
                            }
                            else
                                if (menerror == "Instrucción INSERT en conflicto con la restricción FOREIGN KEY \"FK_UnidadConservacion_Tipologia\". El conflicto ha aparecido en la base de datos \"Inventario\", tabla \"dbo.Tipologia\", column 'TipologiaCodigo'.\r\nSe terminó la instrucción.")
                                {
                                    return "Favor verificar la Tipologia";
                                }
                                else
                                    if (menerror == "No se puede insertar una fila de clave duplicada en el objeto 'dbo.UnidadConservacion' con índice único 'IX_RegistroInventario'.\r\nSe terminó la instrucción.")
                                {
                                    return "Registro de Inventario ya se encuentra en Alfanet";
                                }                                    
                                    else
                                    {
                                        return "Favor validar información ";
                                    }
        }
        
    }
    public DataTable Datos(string str)
    {

        
        try
        {
            adaptador = new SqlDataAdapter(str, conectar);
            tabla = new DataTable();
            adaptador.Fill(tabla);
        }
        catch
        {
        }
        return tabla;

    }
}


