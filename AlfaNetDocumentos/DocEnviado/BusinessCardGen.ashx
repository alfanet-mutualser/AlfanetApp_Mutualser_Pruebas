<%@ WebHandler Language="C#" Class="BusinessCardGen" %>

using System;
using System.Web;

using Neodynamic.WebControls.ImageDraw;

public class BusinessCardGen : IHttpHandler {
    
    public void ProcessRequest (HttpContext context)
    
    {
                
        //Get the info to create the travel card
        string fullname = "";
        string jobtitle = "";
        string addressline1 = "";
        string addressline2 = "";
        string phone = "";
        string email = "";
        
        if (context.Request["fullname"] != null)
        {
            fullname = context.Request["fullname"];
        }
        if (context.Request["jobtitle"] != null)
        {
            jobtitle = context.Request["jobtitle"];
        }
        if (context.Request["addressline1"] != null)
        {
            addressline1 = context.Request["addressline1"];
        }
        if (context.Request["addressline2"] != null)
        {
            addressline2 = context.Request["addressline2"];
            
        }
        if (context.Request["phone"] != null)
        {
            phone = context.Request["phone"];
        }
        if (context.Request["email"] != null)
        {
            email = context.Request["email"];
        }
        
        //Create an instance of ImageDraw
        ImageDraw imgDraw = new ImageDraw();
        //Basic settings
        imgDraw.Canvas.AutoSize = true;
        imgDraw.ImageFormat = ImageDrawFormat.Jpeg;
        imgDraw.JpegCompressionLevel = 90;    
        
        //Create an ImageElement to wrap the business card design
        ImageElement imgElemCard = new ImageElement();
        imgElemCard.Source = ImageSource.File;
        imgElemCard.SourceFile = context.Server.MapPath("~/images/card1.jpg");
        //Add element to output image
        imgDraw.Elements.Add(imgElemCard);
        
        
        //Create TextElement objects for each fields

        //Fecha 
            TextElement txtCiudadFecha = new TextElement();
            txtCiudadFecha.AutoSize = true;
            txtCiudadFecha.Font.Name = "CiudadFecha";
            txtCiudadFecha.Font.Size = 10f;
            txtCiudadFecha.Font.Unit = FontUnit.Point;
            txtCiudadFecha.ForeColor = System.Drawing.Color.Black;
            txtCiudadFecha.Text = DateTime.Today.ToLongDateString();
            txtCiudadFecha.TextQuality = System.Drawing.Text.TextRenderingHint.AntiAlias;
            txtCiudadFecha.X = 100;
            txtCiudadFecha.Y = 230;
            //Add element to output image
            imgDraw.Elements.Add(txtCiudadFecha);
        

        ////Phone TextElement primer Destino 
        //if (phone.Length > 0)
        //{
        //    TextElement txtElemPhone = new TextElement();
        //    txtElemPhone.AutoSize = true;
        //    txtElemPhone.Font.Name = "Georgia";
        //    txtElemPhone.Font.Size = 10f;
        //    txtElemPhone.Font.Unit = FontUnit.Point;
        //    txtElemPhone.ForeColor = System.Drawing.Color.Black;
        //    txtElemPhone.Text = "Remite: " + phone;
        //    txtElemPhone.TextQuality = System.Drawing.Text.TextRenderingHint.AntiAlias;
        //    txtElemPhone.X = 100;
        //    txtElemPhone.Y = 280;
        //    //Add element to output image
        //    imgDraw.Elements.Add(txtElemPhone);
        //}

        //Job Title TextElement Para:
        if (jobtitle.Length > 0)
        {
            TextElement txtElemJob = new TextElement();
            txtElemJob.AutoSize = true;
            txtElemJob.Font.Name = "Arial";
            txtElemJob.Font.Size = 10f;
            txtElemJob.Font.Unit = FontUnit.Point;
            txtElemJob.ForeColor = System.Drawing.Color.Black;
            txtElemJob.Text = jobtitle;
            txtElemJob.TextQuality = System.Drawing.Text.TextRenderingHint.AntiAlias;
            txtElemJob.X = 100;
            txtElemJob.Y = 300;
            //Add element to output image
            imgDraw.Elements.Add(txtElemJob);
        }
        
        //Full Name TextElement
        if (fullname.Length > 0)
        {
            TextElement txtElemName = new TextElement();
            txtElemName.AutoSize = true;
            txtElemName.Font.Name = "Arial";
            txtElemName.Font.Size = 14f;
            txtElemName.Font.Unit = FontUnit.Point;
            txtElemName.Font.Bold = true;
            txtElemName.ForeColor = System.Drawing.Color.Black;
            txtElemName.Text = fullname;
            txtElemName.TextQuality = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            txtElemName.X = 100;
            txtElemName.Y = 340;
            //Add element to output image
            imgDraw.Elements.Add(txtElemName);
        }
        
               
        //Address Lines TextElement
        if (addressline1.Length > 0)
        {
            TextElement txtElemAddress = new TextElement();
            txtElemAddress.AutoSize = true;
            txtElemAddress.Font.Name = "Times New Roman";
            txtElemAddress.Font.Italic = true;
            txtElemAddress.Font.Size = 11f;
            txtElemAddress.Font.Unit = FontUnit.Point;
            txtElemAddress.ForeColor = System.Drawing.Color.Black;
            txtElemAddress.Text = addressline1 + "\n" + addressline2;
            txtElemAddress.TextQuality = System.Drawing.Text.TextRenderingHint.AntiAlias;
            txtElemAddress.X = 22;
            txtElemAddress.Y = 70;
            //Add element to output image
            imgDraw.Elements.Add(txtElemAddress);
        }
        //Address Lines TextElement
        if (addressline2.Length > 0)
        {
            TextElement txtElemAddress1 = new TextElement();
            txtElemAddress1.AutoSize = true;
            txtElemAddress1.Font.Name = "Times New Roman";
            txtElemAddress1.Font.Italic = true;
            txtElemAddress1.Font.Size = 11f;
            txtElemAddress1.Font.Unit = FontUnit.Point;
            txtElemAddress1.ForeColor = System.Drawing.Color.Black;
            txtElemAddress1.Text = addressline1 + "\n" + addressline2;
            txtElemAddress1.TextQuality = System.Drawing.Text.TextRenderingHint.AntiAlias;
            txtElemAddress1.X = 22;
            txtElemAddress1.Y = 100;
            //Add element to output image
            imgDraw.Elements.Add(txtElemAddress1);
        }
        
                
        //Email TextElement
        if (email.Length > 0)
        {
            TextElement txtElemEmail = new TextElement();
            txtElemEmail.AutoSize = true;
            txtElemEmail.Font.Name = "Georgia";
            txtElemEmail.Font.Size = 11f;
            txtElemEmail.Font.Unit = FontUnit.Point;
            txtElemEmail.ForeColor = System.Drawing.Color.Black;
            txtElemEmail.Text = email;
            txtElemEmail.TextQuality = System.Drawing.Text.TextRenderingHint.AntiAlias;
            txtElemEmail.X = 100;
            txtElemEmail.Y = 300;
            //Add element to output image
            imgDraw.Elements.Add(txtElemEmail);
        }
        
        
         //imgDraw.Save(@"F:\AlfaNet\prueba.png");
        //Render the output image
        context.Response.ContentType = "image/png";
        context.Response.BinaryWrite(imgDraw.GetOutputImageBinary());
        //return imgDraw;
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}