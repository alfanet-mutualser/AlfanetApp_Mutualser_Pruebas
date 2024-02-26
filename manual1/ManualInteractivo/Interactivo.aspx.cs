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

public partial class AlfaNetManual_ManualInteractivo_Interactivo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string filename = "Radicar un Documento.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Radicar un Documento.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string filename = "Inicio de sesion recuperacion y cambio de contraseña.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Inicio de sesion recuperacion y cambio de contraseña.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        string filename = "Enviar un documento.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Enviar un documento.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        string filename = "como buscar un documento enviado existente.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/como buscar un documento enviado existente.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        string filename = "Como buscar un radicado recibido existente.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Como buscar un radicado recibido existente.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
     protected void LinkButton6_Click(object sender, EventArgs e)
    {
        string filename = "Visor de Imagenes.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Visor de Imagenes.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        string filename = "Documentos Recibidos Externos.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/~/AlfaNetManual/ManualInteractivo/Videos/Documentos Recibidos Externos.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        string filename = "Documentos Enviados Externos.exe";
        if (filename != "")
        {
            string path = Server.MapPath("ManualInteractivo/Videos/Documentos Enviados Externos.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        string filename = "Documentos Enviados Internos.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Documentos Enviados Internos.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        string filename = "Gestion Expedientes.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Gestion Expedientes.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        string filename = "Gestion Recibidos.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Gestion Recibidos.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        string filename = "Gestion Enviados.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Gestion Enviados.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        string filename = "Gestion de Tareas.exe";
        if (filename != "")
        {
            string path = Server.MapPath("~/AlfaNetManual/ManualInteractivo/Videos/Gestion de Tareas.exe");
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("This file does not exist.");
            }
        }
    }
    
    
}
