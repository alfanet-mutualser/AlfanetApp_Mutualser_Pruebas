using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using System.IO;
using System.Drawing;
using System.Configuration;


public partial class ImportarDatos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private SqlConnection conectar;
    private SqlDataAdapter adaptador;
    private DataTable tabla;
    string NombreImagen2;
    String Ano = DateTime.Today.Year.ToString();
    String Mes = DateTime.Today.Month.ToString();
    public void inicia()
    {
        try
        {

            conectar = new SqlConnection();
            conectar.ConnectionString = (@"Data Source=ALYSO;Initial Catalog=pruebas1;password=UN@b2015;User Id=sa; Connect Timeout=720");
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        FileUpload1.Visible = false;
        Button1.Visible = false;
        Label5.Visible = false;
        Label4.Visible = true;
        FiUpImagenes.Visible = true;
        cargarImagen.Visible = true;
        try
        {

            if (FileUpload1.HasFile)
            {


                string path = string.Concat((Server.MapPath("~/Temp/" + FileUpload1.FileName)));
                FileUpload1.PostedFile.SaveAs(path);
                OleDbConnection OleDBcon = new OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;");

                OleDbCommand cmd = new OleDbCommand("SELECT * from [Hoja1$]", OleDBcon);

                OleDbDataAdapter oleDA = new OleDbDataAdapter(cmd);

                DataSet ds = new DataSet();
                oleDA.TableMappings.Add("Table", "ExcelTest");

                oleDA.Fill(ds);
                ds.Tables["ExcelTest"].Columns.Add("Resultado");
                inicia();
                foreach (DataRow drow in ds.Tables["ExcelTest"].Rows)
                {
                    Class1 cls = new Class1();
                    string r;
                    try
                    {
                        SqlParameter prm1 = new SqlParameter("@DependenciaCodigo", drow["DependenciaCodigo"].ToString());
                        SqlParameter prm2 = new SqlParameter("@FechaExtremaInicial", Convert.ToDateTime(drow["FechaExtremaInicial"].ToString()));
                        SqlParameter prm3 = new SqlParameter("@FechaExtremaFinal", Convert.ToDateTime(drow["FechaExtremaFinal"].ToString()));
                        SqlParameter prm4 = new SqlParameter("@UnidadNombre", drow["UnidadNombre"].ToString());
                        SqlParameter prm5 = new SqlParameter("@UnidadDetalle", drow["UnidadDetalle"].ToString());
                        SqlParameter prm6 = new SqlParameter("@UbicacionCodigo", drow["UbicacionCodigo"].ToString());
                        SqlParameter prm7 = new SqlParameter("@FormaCodigo", drow["FormaCodigo"].ToString());
                        SqlParameter prm8 = new SqlParameter("@NumeroFolios", drow["NumeroFolios"].ToString());
                        SqlParameter prm9 = new SqlParameter("@SerieCodigo", drow["SerieCodigo"].ToString());
                        SqlParameter prm10 = new SqlParameter("@WFAccionCodigo", drow["WFAccionCodigo"].ToString());
                        SqlParameter prm11 = new SqlParameter("@TipologiaCodigo", drow["TipologiaCodigo"].ToString());
                        SqlParameter prm12 = new SqlParameter("@RegistroInventario", drow["RegistroInventario"].ToString());

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

                        r = "Unidad Documental No" + uni;
                    }

                    catch (Exception ex)
                    {
                        string menerror = Convert.ToString(ex.Message);
						r = menerror;
                        
                    }

                    drow["Resultado"] = r;

                }
                cerrar();

                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();

                Label1.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                Label2.Text = ("");

                Label3.ForeColor = Color.Green;
                Label3.Text = "Datos cargados";
            }
            else
            {
                Label1.Text = "";
                Label3.Text = "";
                Label2.ForeColor = Color.Red;
                Label2.Text = "No se encontro archivo, intentelo de nuevo";
                GridView1.DataBind();
                lblMessage.Text = "";
            }
        }
        catch
		{
			lblMessage.Text = "No es posible continuar con el proceso, verifique los registros y reinicie el proceso de carga nuevamente";
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
        }


    }

    public DataTable Datos(string str)
    {
        inicia();

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
        cerrar();
    }

    protected void cargarImagen_Click(object sender, EventArgs e)
    {
        string cadena = @"Data Source=ALYSO;Initial Catalog=pruebas1;password=UN@b2015;User Id=sa; MultipleActiveResultSets=true; Connect Timeout=720";

        string NombreImagen;
        string Nombre;
        string Ruta;
        int n = 0;
        int s = 0;
        int i = 0;
        string j;

        SqlConnection cnx;
        SqlCommand cmd;
        SqlCommand query;
        SqlDataReader dr;


        cnx = new SqlConnection(cadena);
        cnx.Open();

        query = new SqlCommand();
        cmd = new SqlCommand();


        String PathVirtual = HttpContext.Current.Server.MapPath("~/Uploads/" + Ano + "/" + Mes + "/");

        if (FiUpImagenes.HasFile && FiUpImagenes.PostedFiles.All(x => x.ContentLength < 1024000000))
            foreach (HttpPostedFile postedFile in FiUpImagenes.PostedFiles)
            {
                cnx.Close();
                cnx.Open();
                NombreImagen = Path.GetFileName(postedFile.FileName);
                
                string[] NombreImagencod = NombreImagen.Split('.');
                NombreImagen2 = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + NombreImagen;
                if (NombreImagencod[2] != null)
                {
                    Nombre = NombreImagencod[0] + "." + NombreImagencod[1];
                }
                else
                {
                    Nombre = NombreImagencod[0];
                }
                query = new SqlCommand("SELECT RegistroInventario  FROM UnidadConservacion WHERE RegistroInventario = @NombreImagen");
                query.Parameters.AddWithValue("@NombreImagen", Nombre);

                query.Connection = cnx;
                dr = query.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    LblRegInv.Text = dr.GetValue(0).ToString();

                    if (dr[0] != null)
                    {
                        Ruta = Server.MapPath("~/Uploads/" + Ano + "/" + Mes + "/");
                        cnx.Close();
                        cnx.Open();

                        SqlCommand cmp = new SqlCommand();
                        cmp.Connection = cnx;
                        cmp.CommandType = CommandType.StoredProcedure;
                        cmp.CommandText = ("ImagenRuta_ConsultaRutaPath");
                        cmp.Parameters.AddWithValue("@Ruta", Ruta);

                        cnx.Close();
                        cnx.Open();
                        SqlDataReader ds = cmp.ExecuteReader();
                        ds.Read();
                        dr.Close();

                        if (ds.HasRows)
                        {
                            j = ds.GetValue(0).ToString();
                            if (j == Ruta)
                            {
                            }
                        }

                        else
                        {
                            cnx.Close();
                            cnx.Open();
                            cmd.Connection = cnx;
                            cmd.CommandText = "INSERT INTO ImagenRuta (ImagenRutaCodigo, ImagenRutaDescripcion, ImagenRutaAnio, ImagenRutaMes, ImagenRutaPath, ImagenrutaGrupo) VALUES ((SELECT ImagenRutaCodigo  = MAX(ImagenRutaCodigo)+1 from ImagenRuta),'Inventarios' ,'" + Ano + "', '" + Mes + "', '" + Ruta + "', '" + 30 + "')";
                            cmd.ExecuteReader();
                        }

                        SqlCommand cmo = new SqlCommand();
                        cmo.Connection = cnx;
                        cmo.CommandType = CommandType.StoredProcedure;
                        cmo.CommandText = ("ImagenRuta_ConsultaImagenRutaCodigo");
                        cmo.Parameters.AddWithValue("@Ruta", Ruta);

                        cnx.Close();
                        cnx.Open();
                        SqlDataReader dre = cmo.ExecuteReader();
                        dre.Read();

                        string ConsultaImagenRutaCodigo;
                        ConsultaImagenRutaCodigo = dre.GetValue(0).ToString();

                        SqlCommand cmdo = new SqlCommand();
                        cmdo.Connection = cnx;
                        cmdo.CommandType = CommandType.StoredProcedure;
                        if (NombreImagencod[2] != null)
                        {
                            Nombre = NombreImagencod[0] + "." + NombreImagencod[1];
                        }
                        else
                        {
                            Nombre = NombreImagencod[0];
                        }
                        cmdo.CommandText = ("Inventarios_InsertarRegInvImagenFolios");
                        cmdo.Parameters.AddWithValue("@NombreImagen", Nombre);

                        cnx.Close();
                        cnx.Open();
                        SqlDataReader dra = cmdo.ExecuteReader();
                        dra.Read();

                        string ImagenFolios;
                        ImagenFolios = dra.GetValue(0).ToString();

                        if (ConsultaImagenRutaCodigo == Ruta)
                        {
                            LblImRutCod.Text = ConsultaImagenRutaCodigo;
                            cmd.CommandText = "INSERT INTO InventarioImagen (RegistroInventario, RegInvNombre, ImagenRutaCodigo, GrupoCodigo) VALUES  ('" + LblRegInv.Text + "' , '" + NombreImagen2 + "' , '" + ConsultaImagenRutaCodigo + "','" + 30 + "')";
                        }
                        else
                        {
                            cmd.CommandText = "INSERT INTO InventarioImagen (RegistroInventario, RegInvNombre, ImagenRutaCodigo, RegInvImagenFolio, GrupoCodigo) VALUES  ('" + LblRegInv.Text + "' , '" + NombreImagen2 + "' , '" + ConsultaImagenRutaCodigo + "','"+ImagenFolios+"' , '" + 30 + "')";
                        }
                        if (null != this.FiUpImagenes.PostedFiles)
                        {
                            for (int a = 0; a < FiUpImagenes.TemplateSourceDirectory.Length; a++)
                            {
                                if (!Directory.Exists(PathVirtual))
                                    Directory.CreateDirectory(PathVirtual);
                            }
                        }

                        FiUpImagenes.PostedFiles[i].SaveAs(PathVirtual + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + FiUpImagenes.PostedFiles[i].FileName);

                        cmd.Connection = cnx;
                        dr.Close();
                        ds.Close();
                        dre.Close();
                        cmd.ExecuteReader();
                        try
                        {
                            if (FiUpImagenes.HasFile)
                            {
                                // Se verifica que la extensión sea de un formato válido
                                string ext = FiUpImagenes.PostedFiles[i].FileName;
                                ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                                string[] formatos =
                                  new string[] { "jpg", "jpeg", "bmp", "png", "gif", "tif", "pdf" };
                                if (Array.IndexOf(formatos, ext) < 0)
                                    MensajeError("Formato de imagen inválido.");
                                else if (disco.Checked)
                                    GuardarArchivo(FiUpImagenes.PostedFiles[i]);
                            }
                            else
                                MensajeError("Seleccione un archivo del disco duro.");
                        }
                        catch (Exception ex)
                        {
                            MensajeError(ex.Message);
                        }
                        s = s + 1;
                        lblSuccess.Text = string.Format("" + s + " archivos cargados.", FileUpload1.PostedFiles.Count);
                    }
                }
                else
                {
                    n = n + 1;
                    lblSuccess1.Text = string.Format("" + n + " archivos no cargados.", FileUpload1.PostedFiles.Count);
                }
				i = i + 1;
            }

       
    }



    private void GuardarArchivo(HttpPostedFile file)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = (@"Data Source=ALYSO;Initial Catalog=pruebas1;password=UN@b2015;User Id=sa; MultipleActiveResultSets=true; Connect Timeout=720");
        {
            string query = "SELECT COUNT(*) FROM UnidadConservacion WHERE RegistroInventario=@RegistroInventario";
            SqlCommand cmd = new SqlCommand(query, conn);
            string extension = System.IO.Path.GetExtension(file.FileName);
            string ff = file.FileName.Substring(0, file.FileName.Length - extension.Length);
            cmd.Parameters.AddWithValue("RegistroInventario", ff);
            conn.Open();

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
            {
                MensajeError("No se Encuentra creado el registro");
            }
            else
            {
                // Se carga la ruta física de la carpeta Userfiles del sitio
                string ruta = Server.MapPath("~/Uploads/" + Ano + "/" + Mes + "/");

                // Si el directorio no existe, crearlo
                if (!Directory.Exists(ruta))
                    Directory.CreateDirectory(ruta);

                string archivo = String.Format("{0}\\{1}", ruta, NombreImagen2);


                    file.SaveAs(archivo);

            }
        }
    }
 
    private void MensajeError(string mensaje)
    {
        literalMensaje.Text = String.Format("<div style='color:red;' class=\"error\">{0}</div>", mensaje);
    }
}