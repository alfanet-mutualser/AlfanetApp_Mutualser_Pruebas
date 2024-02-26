<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavDocRecibido.ascx.cs" Inherits="AlfaNetDocumentos_NavDocRecibido" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebToolbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebToolbar" TagPrefix="igtbar" %>

    <script type="text/javascript">            
         
         
        //Variable global para el estado del checkbox
        
        var EstadoCk = 0;
            
        //Variable global para el radicado    
        
         
            
        //Visor de Imagenes Recibida
           function VImagenes(evt,NumeroDocumento,GrupoCodigo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetImagen/VisorImagenes/VisorImagenes.aspx?DocumentoCodigo=' + NumeroDocumento + '&GrupoCodigo=' + GrupoCodigo + '&GrupoPadreCodigo=1&Admon=S&ImagenFolio=1', 'NewWindow', 'top=0,left=0, width=800,height=1000,status=yes, resizable=yes,scrollbars=yes,menubar=yes');
            
        }
         //Visor de Imagenes Recibida
           function RegresarRadicado(evt,NumeroDocumento) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/NuevoDocRecibido1.aspx?RadicadoCodigo=' + NumeroDocumento);
            
        }   
        //Visor de Imagenes Recibida
           function ImpresionSticker(evt,NumeroDocumento,GrupoCodigo) 
        {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            hidden = open('../../AlfaNetDocumentos/DocRecibido/StickerImpresion.aspx?RadicadoCodigo=' + NumeroDocumento + '&GrupoCodigo=1&Admon=S&GrupoPadreCodigo=1&CodBar='+EstadoCk, 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes,menubar=yes');
            
        }
        function url(CheckBoxObj,GrupoCodigo) 
        {
            //var email= prompt('Please enter your email address', ' ');
            //alert(document.getElementById("<%=HFRadicadoCodigo.ClientID%>").getAttribute("value"));
            //var ID = this.document.getElementById("<%=HFGrupoCodigo.ClientID%>").Value;
            //ID.Value = email;
            var CodBar;
             if (CheckBoxObj.checked == true) 
           {
           CodBar = '1';    
           } 
           else
           {
           CodBar = '0';
           }
            //var Grupo = document.getElementById("<%=HFGrupoCodigo.ClientID%>").getAttribute("value");
            //var NroDoc = document.getElementById("<%=HFRadicadoCodigo.ClientID%>").getAttribute("value");
            EstadoCk = CodBar;
            //hidden = open('../../AlfaNetDocumentos/DocRecibido/StickerImpresion.aspx?Admon=S&RadicadoCodigo='+NroDoc+'&GrupoCodigo='+GrupoCodigo+'&GrupoPadreCodigo=1&CodBar='+CodBar, 'NewWindow','top=0,left=0, width=800,height=600,status=yes, resizable=yes,scrollbars=yes,menubar=yes');
           //window.open('../../AlfaNetDocumentos/DocRecibido/StickerImpresion.aspx?Admon=S" + "&RadicadoCodigo="+Request["RadicadoCodigo"]+ "&GrupoCodigo="+Request["GrupoCodigo"]+ "', 'NewWindow','top=0,left=0, width=800,height=600,titlebar=yes,menubar=yes, resizable=yes,scrollbars=yes');
        }   
            
            
             
</script>

<script language="JavaScript">

  var Pages = new Array()
  var ImageCount
  var CurrentImage

  function Initialisation()
  {
    document.form1.scanbutton.disabled = false;
    document.form1.loadbutton.disabled = false;
    document.form1.savebutton.disabled = true;

    document.form1.rotate90button.disabled = true;
    document.form1.rotate180button.disabled = true;
    document.form1.rotate270button.disabled = true;
    document.form1.cropbutton.disabled = true;
    document.form1.despecklebutton.disabled = true;

    document.form1.prevbutton.disabled = true;
    document.form1.nextbutton.disabled = true;

    document.form1.pagenumtext.value = "";

    csxi.AutoZoom = true;
    csxi.ScaleToGray = true;

    ImageCount = 0;
  }

  function ScanClick()
  {
    csxi.SelectTwainDevice();
    
    csxi.TwainMultiImage = true;
    csxi.UseADF = true;
    ImageCount = 0;
    csxi.Acquire();
    CurrentImage = ImageCount;

    if (ImageCount > 0)
    {
      document.form1.savebutton.disabled = false;
      document.form1.rotate90button.disabled = false;
      document.form1.rotate180button.disabled = false;
      document.form1.rotate270button.disabled = false;
      document.form1.cropbutton.disabled = false;
      document.form1.despecklebutton.disabled = false;
      if (ImageCount > 1)
      {
        document.form1.prevbutton.disabled = false;
        document.form1.nextbutton.disabled = false;
      }
      else
      {
        document.form1.prevbutton.disabled = true;
        document.form1.nextbutton.disabled = true;
      }
    }

  }

  function PrevClick()
  {
    if (CurrentImage > 1)
    {
      CurrentImage -= 1;
      csxi.ReadBinary(0, Pages[CurrentImage]);
      csxi.Redraw();
      document.form1.pagenumtext.value = "Page " + CurrentImage + " of " + ImageCount; 
    }
  }

  function NextClick()
  {
    if (CurrentImage < ImageCount)
    {
      CurrentImage += 1;
      csxi.ReadBinary(0, Pages[CurrentImage]);
      csxi.Redraw();
      document.form1.pagenumtext.value = "Page " + CurrentImage + " of " + ImageCount; 
    }
  }

  function Rotate90Click()
  {
    csxi.Rotate(90.0);
    csxi.Redraw();
    Pages[CurrentImage] = csxi.WriteBinary(0); 
  }

  function Rotate180Click()
  {
    csxi.Rotate(180.0);
    csxi.Redraw();
    Pages[CurrentImage] = csxi.WriteBinary(0); 
  }

  function Rotate270Click()
  {
    csxi.Rotate(270.0);
    csxi.Redraw();
    Pages[CurrentImage] = csxi.WriteBinary(0); 
  }

  function CropClick()
  {
    csxi.MouseSelectRectangle();
    csxi.CropToSelection();
    csxi.Redraw();
    Pages[CurrentImage] = csxi.WriteBinary(0); 
  }

  function DespeckleClick()
  {
    csxi.Despeckle();
    csxi.Redraw();
    Pages[CurrentImage] = csxi.WriteBinary(0); 
  }

  function SaveClick()
  {
    for(var i = 1; i<=ImageCount; i++)
    {
      csxi.ReadBinary(0, Pages[i]);
      csxi.Redraw();
      document.form1.pagenumtext.value = "Page " + i + " of " + ImageCount; 
      if (csxi.ColorFormat == 6)
      {
        csxi.Compression = 2;
      }
      else
      {
        csxi.Compression = 0;
      } 
      csxi.AddToTIF(0);
    }
    csxi.WriteTIFDialog();
    csxi.ReadBinary(0, Pages[CurrentImage]);
    csxi.Redraw();
    document.form1.pagenumtext.value = "Page " + CurrentImage + " of " + ImageCount; 
  }

  function LoadClick()
  {
    csxi.ReadImageNumber = 1;
    csxi.LoadDialog();
    Pages[1] = csxi.WriteBinary(0);
    csxi.Redraw();
    ImageCount = csxi.ImageCount(csxi.LastFileName);
    if (ImageCount > 1)
    {
      for(var i = 2; i<=ImageCount; i++)
      {
        csxi.ReadImageNumber = i;
        csxi.LoadFromFile(csxi.LastFileName);
        Pages[i] = csxi.WriteBinary(0);
        csxi.Redraw();
      }
    }
    CurrentImage = 1;
    csxi.ReadBinary(0, Pages[CurrentImage]);
    csxi.Redraw();
    document.form1.pagenumtext.value = "Page " + CurrentImage + " of " + ImageCount;
 
    if (ImageCount > 0)
    {
      document.form1.savebutton.disabled = false;
      document.form1.rotate90button.disabled = false;
      document.form1.rotate180button.disabled = false;
      document.form1.rotate270button.disabled = false;
      document.form1.cropbutton.disabled = false;
      document.form1.despecklebutton.disabled = false;
      if (ImageCount > 1)
      {
        document.form1.prevbutton.disabled = false;
        document.form1.nextbutton.disabled = false;
      }
      else
      {
        document.form1.prevbutton.disabled = true;
        document.form1.nextbutton.disabled = true;
      }
    }
  }

function csxiacquire()
  {
    csxi.Redraw();
    ImageCount += 1;
    Pages[ImageCount] = csxi.WriteBinary(0);
    document.form1.pagenumtext.value = "Page " + ImageCount + " of " + ImageCount; 
  }


//-->
</script>
<link rel="Stylesheet"
        type="text/css"
        href="../../AlfaNetStyle.css" />

<script language="Javascript" for="csxi" event="onacquire()">
  csxiacquire()
</script>

   
<table style="width: 100%">
    <tr>
        <td>
            <asp:Image ID="Image3" runat="server" ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/sticker.png" Height="42px" Width="36px" ToolTip="Impresion de Sticker" /><br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="|||||||" 
                ToolTip="Sticker Codigo de Barras" Width="36px" /></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Sticker"></asp:Label></td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="Image1" runat="server" Height="42px" ImageUrl="~/AlfaNetImagen/ToolBar/Iconos/imagenes.png"
                Width="36px" ToolTip="Visor de Imagenes" /></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Imagenes"></asp:Label></td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="Panel1" runat="server" CssClass="popupControl" Height="590px" Width="440px">
            
<iframe runat="server" id="Default3" style="width: 440px; height: 590px" enableviewstate="true" visible="true"></iframe> 
    <br />
            </asp:Panel>
            <asp:Image ID="Image2" runat="server" Visible="false" Height="42px" ImageUrl="~/AlfaNetImagen/ToolBar/images.jpg"
                Width="36px" ToolTip="Visor de Imagenes" />
            <cc1:PopupControlExtender ID="PopupControlExtender1" runat="server" OffsetX="-486" OffsetY="-550" PopupControlID="Panel1" Position="Right" TargetControlID="Image2">
            </cc1:PopupControlExtender>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LbScanner" runat="server" Visible="false" Text="Escanear"></asp:Label></td>
    </tr>
</table>
<asp:HiddenField ID="HFGrupoPadreCodigo" runat="server" />
<asp:HiddenField ID="HFGrupoCodigo" runat="server" />

<asp:HiddenField ID="HFRadicadoCodigo" runat="server" />


