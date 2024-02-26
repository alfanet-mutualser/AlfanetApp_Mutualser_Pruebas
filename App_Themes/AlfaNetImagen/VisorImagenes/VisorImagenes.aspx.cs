using System;
using Microsoft;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DSRadicadoTableAdapters;
using DSGrupoSQLTableAdapters;
using System.Data.SqlClient;
using ASP;
using System.Web.Configuration;
using System.Collections;
using System.Collections.Generic;
using AjaxControlToolkit;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public partial class _VisorImagenes : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {  
        try
        {
            // *********************** 
            if (!IsPostBack)
            {
                String CodImagenReg = Request["RegistroCodigo"];
                string CodImagenRad = Request["RadicadoCodigo"];
                string senrodoc;

                // *********************** 
                if (CodImagenReg != null)
                {
                    senrodoc = CodImagenReg;
                    Session["NroDoc"] = CodImagenReg;
                }

                if (CodImagenRad != null)
                {
                    senrodoc = CodImagenRad;
                    Session["NroDoc"] = CodImagenRad;
                }
                // ***********************

                senrodoc = (string)(Session["NroDoc"]);

                // ***********************
                if (Session["NroDoc"] != null) 
                {
                        senrodoc = Session["NroDoc"].ToString();
                        
                        string Grupo = senrodoc.Substring(0, 1);
                        HFTipoDoc.Value = Grupo;
                        
                        string nrodoc = senrodoc.Substring(1);
                        this.HFImagenes.Value = nrodoc;
                        
                        this.DataList1.DataSource = "";

                        // *********************** Radicados
                        if(Grupo == "1")
                        {
                            this.NavDocRecibido1.Visible = true;
                            this.NavDocEnviado1.Visible = false;
                            DataList1.DataSource = ODSRadImagen;
                            this.Label22.Text = "Radicado Nro" + " " + nrodoc; 
                        }

                        // *********************** Registros
                        if (Grupo == "2")
                        {
                            this.NavDocRecibido1.Visible = false;
                            this.NavDocEnviado1.Visible = true; 
                            DataList1.DataSource = ODSRegImagen;
                            this.Label22.Text = "Registro Nro" + " " + nrodoc;
                        }

                        this.DataList1.DataBind();
                        Session["NroDoc"] = Session["NroDoc"];
                }
                else
                {
                  this.ExceptionDetails.Text = "No ha Cargado Ningun Documento !";
                  this.NavDocRecibido1.Visible = false;
                  this.NavDocEnviado1.Visible = false; 
                }
                // ***********************
            }
            // ***********************

            /*
            DSRadicado.Radicado_ReadRadDataTable radicados = new DSRadicado.Radicado_ReadRadDataTable();
            radicados = ObjRad.GetDataBy(NroRad);
            DataRow[] rows = radicados.Select();

            PruebaImg.ImagenesDataTable mImagen = new PruebaImg.ImagenesDataTable();
            mImagen = mImagen.ge
            //ODSRadImagen.Select(
            this.HyperLink1.Text = "Here";

            RadicadoDataSource
             */

            //DataRow[] rows = ODSRadImagen.Select();
           // this.HyperLink1.Text = ODSRadImagen.Select().
              
            //dt = ODSRadImagen.Select
            
            //PruebaImg.ImagenesDataTable mImagen = new PruebaImg.ImagenesDataTable();
            //DataRow[] rows = mImagen.Select(

            /*
            PruebaImgTableAdapters.ImagenesTableAdapter mTA = new PruebaImgTableAdapters.ImagenesTableAdapter();
            PruebaImg.ImagenesDataTable mDT = new PruebaImg.ImagenesDataTable();
            mDT = mTA.GetRadDataImagenes(160);
            PruebaImg.ImagenesRow mRow = mDT[0];
            // Output HTTP headers providing information about the binary data
            Response.ContentType = "image/gif";
            // Output the binary data
            // But first we need to strip out the OLE header
            */

            /*
            const int OleHeaderLenght = 78;
            int strippedImageLength = mRow.Imagen.Length - 78;
            byte[] strippedImageData = new byte[strippedImageLength];
            Array.Copy(mRow.Imagen, OleHeaderLenght,strippedImageData, 0, strippedImageLength);
            
            Response.BinaryWrite(strippedImageData);
            */
            
            //Response.BinaryWrite(mRow.Imagen);

            //this.DataList1.Items.



        }
        catch (Exception Error)
        {
         this.ExceptionDetails.Text = "Problema" + Error;
        }
    }
     





    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        Label7.Text = "";

        if (this.FileUpload12.HasFile)
          {
            try
            {
                //Recuperamos la cadena de conexión del fichero web.config
                
                byte[] arrImage = FileUpload12.FileBytes;
                
                int Numero = this.DataList1.Items.Count;
                int? mValor;
                mValor = Convert.ToInt32(HFImagenes.Value.ToString() + Numero);
                                     
                    if(HFTipoDoc.Value == "1")
                        {  
                            PruebaImgTableAdapters.ImagenesTableAdapter TAImg = new PruebaImgTableAdapters.ImagenesTableAdapter();
                            TAImg.Insert(mValor, this.FileUpload12.FileName.ToString(), null, HFImagenes.Value.ToString(), null, arrImage);
                            DataList1.DataSource = ODSRadImagen;
                        }
                    else
                        {
                            PruebaImgTableAdapters.RegSelectImagenTableAdapter TARegImg = new PruebaImgTableAdapters.RegSelectImagenTableAdapter();
                            TARegImg.Insert(mValor, this.FileUpload12.FileName.ToString(), null, HFImagenes.Value.ToString(), null, arrImage);
                            DataList1.DataSource = ODSRegImagen;
                        }
                DataList1.DataBind();
                Session["NroDoc"] = Session["NroDoc"];
              }
            catch (Exception ex)
            {
                this.ExceptionDetails.Text = "Error: " + ex.Message.ToString();
            }
        }
        else
            this.ExceptionDetails.Text = "Especifique un fichero, por favor.";        
    }

}

           
      
