using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.IO;

using Neodynamic.WebControls.ImageDraw;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using iTextSharp.text;
using iTextSharp.text.pdf;
using zeus;

public partial class AlfaNetManual_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {/*
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "C:\\Documents and Settings\\Administrador\\Mis documentos\\Downloads\\Capacitacion Visual C Sharp.pdf";
            proc.Start();
            proc.Close();*/

            /*this.FramePDF.Attributes["Src"] = "~/Documents and Settings/Administrador/Mis documentos/Downloads/Capacitacion Visual C Sharp.pdf";//@VirtualPath + HFFileName.Value;
            this.FramePDF.DataBind();
            this.FramePDF.Visible = true;*/

            //Response.Redirect("http://www.mipagina.com/documentos/midocumento.pdf")  
            //Response.Redirect("documentos/midocumento.pdf")  

            Response.Redirect("http://192.168.1.100//alfanet//alfanetmanual//Manual operativo ALFANET.pdf");  

            //De manera relativa: 

            Response.Redirect("alfanetmanual//Manual operativo ALFANET.pdf"); 

            /*Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "Capacitacion Visual C Sharp.pdf");
            Response.ContentType = "application/pdf";
            Response.TransmitFile("C:\\Documents and Settings\\Administrador\\Mis documentos\\Downloads\\Capacitacion Visual C Sharp.pdf");
            Response.End();*/
        }
        catch (Exception ex)
        {
            this.lerror.Text= "Error: " + ex.Message+" | "+ex.Data+" | "+ex.Source+" | "+ex.StackTrace+" | "+ex.TargetSite;
        }
    }
}
