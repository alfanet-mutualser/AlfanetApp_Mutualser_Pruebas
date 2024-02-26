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
using System.Web.Configuration;
using System.Collections;
using System.Text;
using System.DirectoryServices;



//using DSRadicadoTableAdapters;
//using DSGrupoSQLTableAdapters;                 


/// <summary>
/// Descripción breve de ExpedienteBLL
/// </summary>
//

[System.ComponentModel.DataObject]
public class MailBLL
{
    // Constructor Serie Adapter
    private System.Net.Mail.MailMessage _Correo = null; 
    protected System.Net.Mail.MailMessage Correo
    {
        get
        {
            if (_Correo == null)
                _Correo = new  System.Net.Mail.MailMessage();

            return _Correo;
        }
    }
    private System.Net.Mail.SmtpClient _Smtp = null;
    protected System.Net.Mail.SmtpClient Smtp
    {
        get
        {
            if (_Smtp == null)
            {
                _Smtp = new System.Net.Mail.SmtpClient();
                //_Smtp.Host = "192.168.254.2";
				// _Smtp.Host = "correo.mutualser.org";
				// _Smtp.Host = "mutualser-org.mail.protection.outlook.com";
				_Smtp.Host = "mail.mutualser.org";
                _Smtp.EnableSsl = false;
                _Smtp.Port = 25;
                // _Smtp.Credentials = new System.Net.NetworkCredential("alfanet", "Mei7eboc");
                _Smtp.UseDefaultCredentials = false;
			
            }
            return _Smtp;
        }
    } 
   // [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public  void EnvioCorreo(String De,String Para,String Asunto,String Mensaje,bool EsHtml,String Prioridad)
    {   //De:
        Correo.From = new System.Net.Mail.MailAddress(De);
        //Para:
        Correo.To.Add(Para);
        Correo.Subject = Asunto;
        //correo.Body = " Hola mi nombre es " & edNOMBRE.Text & " mis datos personales son: " & edTelefono.Text & " " & edDireccion.Text & " " & edBarrio.Text & " este es un mail de Contacto de " & edEmail.Text & " presento la siguiente solicitud y presento la siguiente observación  " & edObservacion.Text";
        Correo.Body = Mensaje;
        Correo.IsBodyHtml = EsHtml;
        if (Prioridad == "1")
            Correo.Priority = System.Net.Mail.MailPriority.High;
        else if(Prioridad == "2")
           Correo.Priority = System.Net.Mail.MailPriority.Normal;
        else if(Prioridad == "3")
           Correo.Priority = System.Net.Mail.MailPriority.Low;

       //Smtp.Host = "smtp.gmail.com";
       //Smtp.EnableSsl = true;

       //Smtp.Credentials = new System.Net.NetworkCredential("soporte.archivar", "pollito1");
        
       try
       {
            Smtp.Send(Correo);
            //r.Text = "Mensaje enviado satisfactoriamente";
       }
       catch (Exception e)
       {
           //Exception inner = e.InnerException;
           //this.LblMessageBox.Text += ErrorHandled.FindError(inner);
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
       }
    }
    public void EnvioCorreoMsg(System.Net.Mail.MailMessage msg)
    {   
        try
        {
            Smtp.Send(msg);
            //r.Text = "Mensaje enviado satisfactoriamente";
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error en la capa BLL. " + e.Message);
        }
    }
    
    
}
